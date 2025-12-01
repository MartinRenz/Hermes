namespace Hermes.Interfaces
{
    public interface IHermes
    {
        void Handle<TMessage>(TMessage message);
    }
}