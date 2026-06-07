namespace Coherence.Common.Pooling.Storage
{
	public interface IPoolStorage<T>
	{
		bool TryTake(out T item);

		void Add(T item);
	}
}
