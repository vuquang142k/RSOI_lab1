using Person.InterfaceDB;
using Person.Model;

namespace Person.Service
{
    public class PersonService
    {
        private IPersonRepository personDA;
        public PersonService(IPersonRepository personDA)
        {
            this.personDA = personDA;
        }
        
        public List<People>? getAllPerson()
        {
            var res = personDA.getAllPerson();
            return res;
        }
        public People? FindById(int id)
        {
            var res = personDA.FindById(id);
            if (res == null) throw new PersonNotFoundException();
            return res;
        }
        public People? Add(People obj)
        {
            if (obj.age < 0 || obj.name.Trim() == "" || obj.address.Trim() == "" || obj.work.Trim() == "") throw new ErrorInputException();
            return personDA.Add(obj);
        }
        public People? updatePerson(int id, People person)
        {
            if (person.age < 0 || person.name.Trim() == "" || person.address.Trim() == "" || person.work.Trim() == "") throw new ErrorInputException();
            var res = personDA.updatePerson(id, person);
            if (res == null) throw new PersonNotFoundException();
            return res;
        }
        public int deletePerson(int id)
        {
            var res = personDA.deletePerson(id);
            if (res < 0) throw new PersonNotFoundException();
            return res;
        }
    }
}
