namespace Pug.UnityExtensions
{
	internal class NativePriorityQueueDebugView<T> where T : unmanaged
	{
		private NativePriorityQueue<T> queue;

		public NativePriorityQueue<T>.Node[] Items => queue.ToArray();

		public NativePriorityQueueDebugView(NativePriorityQueue<T> queue)
		{
			this.queue = queue;
		}
	}
}
