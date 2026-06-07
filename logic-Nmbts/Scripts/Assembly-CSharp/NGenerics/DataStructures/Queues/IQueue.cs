namespace NGenerics.DataStructures.Queues
{
	public interface IQueue<T>
	{
		void Enqueue(T item);

		T Dequeue();

		T Peek();
	}
}
