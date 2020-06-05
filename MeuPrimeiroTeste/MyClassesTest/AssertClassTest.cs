using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyClasses.PersonClasses;
using System.Text.RegularExpressions;

namespace MyClassesTest
{
    [TestClass]
    public class AssertClassTest
    {
        public TestContext TestContext { get; set; }

        #region InstanceOfType Test

        [TestMethod]
        public void IsInstanceOfTypeTest()
        {
            PersonalManager manager = new PersonalManager();
            Person per = manager.CreatePerson("Vinicius", "Sobrenome", true);
            Assert.IsInstanceOfType(per, typeof(Supervisor));
        }

        [TestMethod]
        public void IsNullTest()
        {
            PersonalManager manager = new PersonalManager();
            Person per = manager.CreatePerson("", "Sobrenome", true);
            Assert.IsNull(per);
        }

        #endregion

        #region StringAssert Test
        [TestMethod]
        public void ContainsTest()
        {
            string str1 = "Alice Ribeiro";
            string str2 = "Alice";

            StringAssert.Contains(str1, str2);
        }
        [TestMethod]
        public void StarWithTest()
        {
            string str1 = "Todos caixa alta";
            string str2 = "Todos caixa";

            StringAssert.StartsWith(str1, str2);
        }
        [TestMethod]
        public void IsAllLowerCaseTest()
        {
            Regex reg = new Regex(@"^([^A-Z])+$");
            StringAssert.Matches("todos caixa", reg);
        }
        [TestMethod]
        public void IsNotAllLowerCaseTest()
        {
            Regex reg = new Regex(@"^([^A-Z])+$");
            StringAssert.DoesNotMatch("Todos caixa", reg);
        }

        #endregion
    }
}
