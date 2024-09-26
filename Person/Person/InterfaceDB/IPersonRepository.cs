using Person.Model;

namespace Person.InterfaceDB
{
    public interface IPersonRepository
    {
        public List<People> getAllPerson();
        public People FindById(int id);
        public People Add(People obj);
        public People? updatePerson(int id, People person);
        public int deletePerson(int id);
    }
}
