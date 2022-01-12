using System;
using System.Collections.Generic;
using System.Text;

namespace Auth.Service.Manager.Abstraction
{
    public interface IJwtAuthenticationManager
    {
        string Authenticate(string userName, string password);
    }
}
