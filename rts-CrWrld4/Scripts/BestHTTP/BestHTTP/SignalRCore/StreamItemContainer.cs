using System.Collections.Generic;

namespace BestHTTP.SignalRCore
{
	public sealed class StreamItemContainer<T>
	{
		public readonly long id;

		public bool IsCanceled;

		public List<T> Items { get; private set; }

		public T LastAdded { get; private set; }

		public StreamItemContainer(long _id)
		{
		}

		public void AddItem(T item)
		{
		}
	}
}
