using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RyansLibrary
{
    public class StringMismatchException : Exception
    {
        public StringMismatchException(string message) : base(message)
        {

        }
    }

    public class ScrabbleException : Exception
    {
        public ScrabbleException(string message) : base (message)
        {

        }
    }
}
