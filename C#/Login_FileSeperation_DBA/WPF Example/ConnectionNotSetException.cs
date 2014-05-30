using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Example
{
    public class ConnectionNotSetException : Exception
    {
        public ConnectionNotSetException()
        {

        }

        public ConnectionNotSetException(string message)
            : base(message)
        {

        }

        public ConnectionNotSetException(string message, Exception inner)
            : base(message, inner)
        {

        }
    }
}
