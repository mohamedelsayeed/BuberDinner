using BuberDinner.Application.Authentication.Common;
using BuberDinner.Application.Common.Authentication;
using BuberDinner.Application.Common.Errors;
using BuberDinner.Application.Common.Persistence;
using BuberDinner.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberDinner.Application.Authentication.Command
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, AuthenticationResult>
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;

        public RegisterCommandHandler(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator)
        {
            _userRepository = userRepository;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public async Task<AuthenticationResult> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            if (_userRepository.GetUserByEmail(request.Email) is not null)
            {
                throw new DuplicateEmailException();
            }

            User user = new()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Password = request.Password
            };

            _userRepository.Add(user);

            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(user, token);
        }
    }
}
