namespace NGenerics.DataStructures.Queues
{
	public class ClassicPriorityQueue<T> : PriorityQueue<T, int>
	{
		public ClassicPriorityQueue(PriorityQueueType queueType)
			: base(queueType)
		{
		}
	}
}
