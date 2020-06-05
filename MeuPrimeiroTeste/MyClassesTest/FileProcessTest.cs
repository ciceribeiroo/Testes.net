using System;
using System.Configuration;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyClasses;

namespace MyClassesTest
{
    [TestClass]
    public class FileProcessTest
    {
        private string _GoodFileName;
        private const string BAD_FILE_NAME = @"C:\Users\dinamica.txt";

        public TestContext TestContext { get; set; }

        #region Test Initialize e Cleanup
        [TestInitialize]
        public void TestInitialize()
        {
            if(TestContext.TestName == "FileNameDoesExists")
            {
                SetGoodFileName();
                if (!string.IsNullOrEmpty(_GoodFileName))
                {
                    TestContext.WriteLine("Creating File");
                    File.AppendAllText(_GoodFileName, "Some text");
                }
            }
        }

        [TestCleanup]
        public void TestCleanup()
        {
            if (TestContext.TestName == "FileNameDoesExists")
            {
                if (!string.IsNullOrEmpty(_GoodFileName))
                {
                    File.Delete(_GoodFileName);
                    TestContext.WriteLine("Deleting File");
                }
            }
        }

        #endregion

        [TestMethod]
        [Description("Check to see if a file does exist")]
        [Owner("Alice")]
        [Priority(0)]
        [TestCategory("NotException")]
        public void FileNameDoesExists()
        {
            FileProcess fp = new FileProcess();
            bool fromCall;

            TestContext.WriteLine("Testing File");
            fromCall = fp.FileExists(_GoodFileName);
            
            Assert.IsTrue(fromCall);
        }

        public void SetGoodFileName()
        {
            _GoodFileName = ConfigurationManager.AppSettings["GoodFileName"];
            if (_GoodFileName.Contains("[AppPath]"))
            {
                _GoodFileName = _GoodFileName.Replace("[AppPath]",
                    Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
            }
        }

        private const string FILE_NAME = @"FileToDeploy.txt";

        [TestMethod]
        [Owner("Alice")]
        [DeploymentItem(FILE_NAME)]
        public void FileNameDoesExistUsingDeploymentItem()
        {
            FileProcess fp = new FileProcess();
            string fileName;
            bool fromCall;

            fileName =$@"{TestContext.DeploymentDirectory}\{FILE_NAME}";
            TestContext.WriteLine("Checking File");

            fromCall = fp.FileExists(fileName);

            Assert.IsTrue(fromCall);
        }

        #region AreSame/AreNotSame Tests

        [TestMethod]
        public void AreSameTest()
        {
            FileProcess x = new FileProcess();
            FileProcess y = x;

            Assert.AreSame(x, y);
        }

        [TestMethod]
        public void AreNotSameTest()
        {
            FileProcess x = new FileProcess();
            FileProcess y = new FileProcess();

            Assert.AreNotSame(x, y);
        }

        #endregion

        [TestMethod]
        [Timeout(3900)]
        [Priority(0)]
        [TestCategory("NotException")]
        public void SimulateTimeOut()
        {
            System.Threading.Thread.Sleep(3000);
        }

        [TestMethod]
        [Priority(0)]
        [TestCategory("NotException")]
        public void FileNameDoesNotExists()
        {
            FileProcess fp = new FileProcess();
            bool fromCall;

            fromCall = fp.FileExists(BAD_FILE_NAME);
            Assert.IsFalse(fromCall);
        }
        [TestMethod]
        [Priority(1)]
        [TestCategory("Exception")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FileNameNullOrEmpty_throwsArgumentNullException()
        {
            FileProcess fp = new FileProcess();
            fp.FileExists("");
        }

        [TestMethod]
        [Priority(1)]
        [TestCategory("Exception")]
        public void FileNameNullOrEmpty_throwsArgumentNullException_UsingTryCatch()
        {
            FileProcess fp = new FileProcess();
            try
            {
                fp.FileExists("");
            }
            catch(ArgumentException)
            {
                return;
            }
            Assert.Fail("Falha Esperada");
        }
    }
}
