namespace Okane.Application;

public interface IRequestHandler<in TRequest, out TResponse>
{
    TResponse Handle(TRequest request);
}