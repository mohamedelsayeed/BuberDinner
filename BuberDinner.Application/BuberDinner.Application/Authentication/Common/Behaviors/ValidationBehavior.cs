using FluentValidation;
using MediatR;

namespace BuberDinner.Application.Authentication.Common.Behaviors
{
    public class ValidationBehavior<TRequest, TRespose> : IPipelineBehavior<TRequest, TRespose>
        where TRequest : IRequest<TRespose>
    {
        private readonly IValidator<TRequest>? _validator;

        public ValidationBehavior(IValidator<TRequest>? validator)
        {
            _validator = validator;
        }

        public async Task<TRespose> Handle(TRequest request, RequestHandlerDelegate<TRespose> next, CancellationToken cancellationToken)
        {
            if (_validator is null)
            {
                return await next();
            }
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);

            if (validationResult.IsValid)
      return await next();
            return (dynamic)validationResult;
        }
    }
}
