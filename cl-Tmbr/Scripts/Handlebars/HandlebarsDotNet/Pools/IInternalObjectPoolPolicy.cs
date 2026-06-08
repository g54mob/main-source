namespace HandlebarsDotNet.Pools
{
	internal interface IInternalObjectPoolPolicy<T>
	{
		T Create();

		bool Return(T item);
	}
}
