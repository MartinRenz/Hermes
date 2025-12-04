namespace Hermes.Interfaces
{
    public interface IHermes
    {
        Task<TResponse> Send<TResponse>(IRequest<TResponse> message, CancellationToken cancellationToken = default);
        Task Send(IRequest request, CancellationToken cancellationToken = default);
    }
}