public interface IAsyncJob<T> : IGenericAsyncJob
{
	T GetResult();
}
