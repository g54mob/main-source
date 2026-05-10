namespace FishNet.Utility.Performance
{
	public class BasicQueue<T>
	{
		private T[] Collection;

		private T[] _resizeBuffer;

		private int _read;

		private int _written;

		public int Capacity => 0;

		public int Count => 0;

		public int WriteIndex { get; private set; }

		public T this[int simulatedIndex]
		{
			get
			{
				return default(T);
			}
			set
			{
			}
		}

		public void Enqueue(T data)
		{
		}

		public bool TryDequeue(out T result)
		{
			result = default(T);
			return false;
		}

		public T Dequeue()
		{
			return default(T);
		}

		public bool TryPeek(out T result)
		{
			result = default(T);
			return false;
		}

		public T Peek()
		{
			return default(T);
		}

		public void Clear()
		{
		}

		private void Resize()
		{
		}
	}
}
