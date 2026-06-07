namespace NGenerics.DataStructures.Queues
{
	public interface IDeque<T>
	{
		T Head { get; }

		T Tail { get; }

		T DequeueHead();

		T DequeueTail();

		void EnqueueHead(T item);

		void EnqueueTail(T item);
	}
}
