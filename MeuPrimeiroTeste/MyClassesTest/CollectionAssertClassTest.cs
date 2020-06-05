using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyClasses.PersonClasses;

namespace MyClassesTest
{
    [TestClass]
    public class CollectionAssertClassTest
    {
        [TestMethod]
        public void AreCollectionEqualsFailsBecauseNoComparerTest()
        {
            PersonalManager PerMgr = new PersonalManager();
            List<Person> peopleExpected = new List<Person>();
            List<Person> peopleActual = new List<Person>();

            peopleExpected.Add(new Person() { FirstName="a", LastName="b" });
            peopleExpected.Add(new Person() { FirstName = "c", LastName = "d" });
            peopleExpected.Add(new Person() { FirstName = "e", LastName = "f" });

            peopleActual = PerMgr.GetPeople();

            CollectionAssert.AreEqual(peopleExpected, peopleActual);
        }
        [TestMethod]
        public void AreCollectionEquivalentTest()
        {
            PersonalManager PerMgr = new PersonalManager();
            List<Person> peopleExpected = new List<Person>();
            List<Person> peopleActual = new List<Person>();

            peopleActual = PerMgr.GetPeople();
            peopleExpected.Add(peopleActual[1]);
            peopleExpected.Add(peopleActual[2]);
            peopleExpected.Add(peopleActual[0]);

            CollectionAssert.AreEquivalent(peopleExpected, peopleActual);
        }
        [TestMethod]
        public void IsCollectionTypeTest()
        {
            PersonalManager PerMgr = new PersonalManager();
            List<Person> peopleActual = new List<Person>();

            peopleActual = PerMgr.GetSupervisor();
            
            CollectionAssert.AllItemsAreInstancesOfType(peopleActual, typeof(Supervisor));
        }
        [TestMethod]
        public void AreCollectionEqualsWithComparerTest()
        {
            PersonalManager PerMgr = new PersonalManager();
            List<Person> peopleExpected = new List<Person>();
            List<Person> peopleActual = new List<Person>();

            peopleExpected.Add(new Person() { FirstName = "a", LastName = "b" });
            peopleExpected.Add(new Person() { FirstName = "c", LastName = "d" });
            peopleExpected.Add(new Person() { FirstName = "e", LastName = "f" });

            peopleActual = PerMgr.GetPeople();

            CollectionAssert.AreEqual(peopleExpected, peopleActual, 
                Comparer<Person>.Create((x,y) =>
                x.FirstName == y.FirstName && x.LastName == y.LastName ? 0 : 1));
        }
    }
}
