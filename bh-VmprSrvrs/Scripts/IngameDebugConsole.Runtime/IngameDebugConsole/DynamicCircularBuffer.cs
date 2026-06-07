namespace IngameDebugConsole
{
	public class DynamicCircularBuffer<T>
	{
		private T[] arr;

		private int startIndex;

		public int Count { get; private set; }

		public T this[int index]
		{
			get
			{
				return default(T);
			}
			set
			{
			}
		}

		public DynamicCircularBuffer(int initialCapacity = 2)
		{
		}

		public void Add(T value)
		{
		}

		public T RemoveFirst()
		{
			return default(T);
		}

		public T RemoveLast()
		{
			return default(T);
		}
	}
}
