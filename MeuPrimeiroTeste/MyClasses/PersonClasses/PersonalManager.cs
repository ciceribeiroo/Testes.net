using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClasses.PersonClasses
{
    public class PersonalManager
    {
        public Person CreatePerson(string first, string last, bool isSupervisor)
        {
            Person ret = null;
            if (!string.IsNullOrEmpty(first))
            {
                if (isSupervisor)
                {
                    ret = new Supervisor();
                }
                else
                {
                    ret = new Employee();
                }
                ret.FirstName = first;
                ret.LastName = last;
            }

            return ret;
        }

        public List<Person> GetPeople()
        {
            List<Person> people = new List<Person>();

            people.Add(new Person() { FirstName = "a", LastName = "b" });
            people.Add(new Person() { FirstName = "c", LastName = "d" });
            people.Add(new Person() { FirstName = "e", LastName = "f" });

            return people;
        }

        public List<Person> GetSupervisor()
        {
            List<Person> people = new List<Person>();

            people.Add(CreatePerson("Carla", "Ferreira", true));
            people.Add(CreatePerson("Laura", "Antonia", true));

            return people;
        }
    }
}
