using BuberDinner.Application.Authentication.Command;
using BuberDinner.Application.Authentication.Query;
using BuberDinner.Contracts.Authentication;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers
{
    [Route("auth")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly ISender _sender;
        private readonly IMapper _mapper;

        public AuthenticationController(ISender sender, IMapper mapper)
        {
            _sender = sender;
            _mapper = mapper;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var command = _mapper.Map<RegisterCommand>(request);

            var response = await _sender.Send(command);

            return Ok(_mapper.Map<AuthenticationResponse>(response));
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var query = _mapper.Map<LoginQuery>(request);

            var response = await _sender.Send(query);

            return Ok(_mapper.Map<AuthenticationResponse>(response));
        }
    }
}
