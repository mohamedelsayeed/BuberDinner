using BuberDinner.Application.Authentication.Common;
using BuberDinner.Application.Common.Authentication;
using BuberDinner.Application.Common.Persistence;
using BuberDinner.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberDinner.Application.Authentication.Query
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, AuthenticationResult>
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;

        public LoginQueryHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }

        public async Task<AuthenticationResult> Handle(LoginQuery query, CancellationToken cancellationToken)
        {
            if (_userRepository.GetUserByEmail(query.Email) is not User user)
            {
                throw new Exception("User with given email doesn't exist");
            }
            if (user.Password != query.Password)
            {
                throw new Exception("wrong password");
            }

            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(user, token);
        }
    }
}
