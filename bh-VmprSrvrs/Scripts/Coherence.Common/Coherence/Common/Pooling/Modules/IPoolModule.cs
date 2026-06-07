namespace Coherence.Common.Pooling.Modules
{
	public interface IPoolModule<T>
	{
		void OnRent(in T item);

		void OnReturn(in T item);
	}
}
