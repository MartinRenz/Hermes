using Hermes.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Hermes.Services
{
    public sealed class Hermes : IHermes
    {
        private readonly IServiceProvider _serviceProvider;

        public Hermes(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<TResponse> Send<TResponse>(
            IRequest<TResponse> message,
            CancellationToken cancellationToken = default)
        {
            var handlerType = typeof(IRequestHandler<,>)
                .MakeGenericType(message.GetType(), typeof(TResponse));

            dynamic handler = _serviceProvider.GetRequiredService(handlerType);

            return await handler.Handle((dynamic)message, cancellationToken);
        }

        public async Task Send(
            IRequest request,
            CancellationToken cancellationToken = default)
        {
            var handlerType = typeof(IRequestHandler<>)
                .MakeGenericType(request.GetType());

            dynamic handler = _serviceProvider.GetRequiredService(handlerType);

            await handler.Handle((dynamic)request, cancellationToken);
        }
    }
}