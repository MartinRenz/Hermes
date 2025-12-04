using Hermes.Interfaces;

namespace Hermes.Services
{
    public class Hermes : IHermes
    {
        private readonly IServiceProvider _serviceProvider;

        public Hermes(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
    }
}