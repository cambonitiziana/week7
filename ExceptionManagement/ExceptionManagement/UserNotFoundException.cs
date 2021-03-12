using System;
using System.Collections.Generic;
using System.Text;

namespace ExceptionManagement
{
    public  class UserNotFoundException: Exception // le costum exception ereditano dalla classe Exception
    {
        public UserNotFoundException() : base() { }//costruttore che ereditiamo da exception

        public UserNotFoundException(string message) : base(message) { }

        public UserNotFoundException(string message, Exception inner) : base(message, inner) { }
    }
}
