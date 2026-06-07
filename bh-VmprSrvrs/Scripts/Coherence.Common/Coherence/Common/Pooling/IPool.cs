namespace Coherence.Common.Pooling
{
	public interface IPool<T>
	{
		T Rent();

		void Return(T item);
	}
}
