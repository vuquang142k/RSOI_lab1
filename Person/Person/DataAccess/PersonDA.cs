using Person.APIContext;
using Person.InterfaceDB;
using Person.Model;

namespace Person.DataAccess
{
    public class PersonDA : IPersonRepository
    {
        private readonly ApiContext _context;
        public PersonDA(ApiContext context)
        {
            _context = context;
        }
        
        public List<People> getAllPerson()
        {
            var res = _context.people.ToList();
            return res;
        }
        public People? FindById(int id)
        {
            var res = _context.people.Find(id);
            return res;
        }
        public People? Add(People obj)
        {
            var id = _context.people.Count() + 1;

            obj.id = id;
            _context.people.Add(obj);
            _context.SaveChanges();
            return obj;
        }
        public People? updatePerson(int id, People person)
        {
            var personindb = _context.people.Find(id);
            if (personindb == null)
            {
                return null;
            }
            personindb.name = person.name;
            personindb.age = person.age;
            personindb.address = person.address;
            personindb.work = person.work;
            _context.SaveChanges();
            return personindb;
        }
        public int deletePerson(int id)
        {
            var res = _context.people.Find(id);
            if (res == null)
                return -1;
            _context.people.Remove(res);
            _context.SaveChanges();
            return 0;
        }
    }
}
