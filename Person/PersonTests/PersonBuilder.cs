using Person.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonTests
{
    public class PersonBuilder
    {
        private int Id;
        private string Name;
        private int Age;
        private string Address;
        private string Work;

        public PersonBuilder()
        {
            Id = 0;
            Name = string.Empty;
            Age = 0;
            Address = string.Empty;
            Work = string.Empty;
        }

        public People Build()
        {
            var person = new People()
            {
                id = Id,
                name = Name,
                age = Age,
                address = Address,
                work = Work
            };

            return person;
        }

        public PersonBuilder WherePersonId(int personId)
        {
            Id = personId;
            return this;
        }

        public PersonBuilder WhereAge(int age)
        {
            Age = age;
            return this;
        }
    }
}
