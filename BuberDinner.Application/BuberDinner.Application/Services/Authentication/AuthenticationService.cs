using BuberDinner.Application.Common.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberDinner.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public AuthenticationResult Register(string firstName, string lastName, string username, string password)
    {
        Guid userId  = Guid.NewGuid();

        var token = _jwtTokenGenerator.GenerateToken(userId, firstName, lastName);

        return new AuthenticationResult(Guid.NewGuid(), firstName, lastName, username, token);
    }
    public AuthenticationResult Login(string username, string password)
    {
        return new AuthenticationResult(Guid.NewGuid(), "firstname", "lastname", username, "token");
    }

}
