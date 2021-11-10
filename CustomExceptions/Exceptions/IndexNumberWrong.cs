using System;
using System.Collections.Generic;
using System.Text;

namespace CustomExceptions.Exceptions
{
    public class IndexNumberWrong : NumberIsWrong
    {
        public IndexNumberWrong(string message) : base(message) { }
    }
}
