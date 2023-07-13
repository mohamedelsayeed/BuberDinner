using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberDinner.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    public AuthenticationResult Login(string username, string password)
    {
        return new AuthenticationResult(Guid.NewGuid(), "firstname", "lastname", username, "token");
    }

    public AuthenticationResult Register(string firstName, string lastName, string username, string password)
    {
        return new AuthenticationResult(Guid.NewGuid(), firstName, lastName, username, "token");
    }
}
