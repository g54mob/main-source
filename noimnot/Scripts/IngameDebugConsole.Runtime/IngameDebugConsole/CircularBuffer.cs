namespace IngameDebugConsole
{
	public class CircularBuffer<T>
	{
		private readonly T[] array;

		private int startIndex;

		public int Count { get; private set; }

		public T this[int index] => default(T);

		public CircularBuffer(int capacity)
		{
		}

		public void Add(T value)
		{
		}

		public T[] ToArray()
		{
			return null;
		}
	}
}
