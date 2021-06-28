using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testjwt.Models;

namespace testjwt.identityserver
{
    public interface IAuthenticateService
    {
        bool IsAuthenticated(User request, out string token);
    }
}
