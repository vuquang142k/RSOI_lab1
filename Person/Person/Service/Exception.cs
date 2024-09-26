using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person.Service
{
    public class PersonNotFoundException : Exception
    {
        public PersonNotFoundException(string information = "Person wasn't found!\n") : base(information) { }
        public PersonNotFoundException(Exception inner, string information = "Person wasn't found!\n") : base(information, inner) { }
    }
    //Input
    public class ErrorInputException : Exception
    {
        public ErrorInputException(string information = "Error Input!\n") : base(information) { }
        public ErrorInputException(Exception inner, string information = "Error Input!\n") : base(information, inner) { }
    }
}
