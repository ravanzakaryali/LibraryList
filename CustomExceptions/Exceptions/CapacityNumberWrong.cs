using System;
using System.Collections.Generic;
using System.Text;

namespace CustomExceptions.Exceptions
{
    public class CapacityNumberWrong : NumberIsWrong
    {
        public CapacityNumberWrong(string message) : base(message) { }
    }
}
