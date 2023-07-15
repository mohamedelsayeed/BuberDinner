using BuberDinner.Application.Authentication.Command;
using BuberDinner.Application.Authentication.Query;
using BuberDinner.Contracts.Authentication;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers
{
    [Route("auth")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly ISender _sender;

        public AuthenticationController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var command = new RegisterCommand(request.FirstName,
                request.LastName,
                request.Email,
                request.Password);

            var response = await _sender.Send(command);

            return Ok(response);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var query = new LoginQuery(
                request.Email,
                request.Password);

            var response = await _sender.Send(query);

            return Ok(response);
        }
    }
}
