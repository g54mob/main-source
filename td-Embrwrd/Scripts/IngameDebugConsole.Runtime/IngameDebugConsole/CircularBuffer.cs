namespace IngameDebugConsole
{
	public class CircularBuffer<T>
	{
		private T[] arr;

		private int startIndex;

		public int Count { get; private set; }

		public T this[int index] => default(T);

		public CircularBuffer(int capacity)
		{
		}

		public void Add(T value)
		{
		}
	}
}
