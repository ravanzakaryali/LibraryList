using System;
using System.Collections.Generic;
using System.Text;

namespace CustomExceptions.Exceptions
{
    public class NumberIsWrong : Exception
    {
        public NumberIsWrong(string message) : base(message) { }
    }
}
