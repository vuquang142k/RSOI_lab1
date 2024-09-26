using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;
using Person.APIContext;
using Person.DataAccess;
using Person.InterfaceDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonTests
{
    public class PersonAccessObject : IDisposable
    {
        public ApiContext peopleContext { get; }
        public IPersonRepository personRepository { get; }

        public PersonAccessObject()
        {
            var builder = new DbContextOptionsBuilder<ApiContext>();
            builder.UseInMemoryDatabase("person");

            peopleContext = new ApiContext(builder.Options);
            personRepository = new PersonDA(peopleContext);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                peopleContext.Database.EnsureDeleted();
                peopleContext?.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
