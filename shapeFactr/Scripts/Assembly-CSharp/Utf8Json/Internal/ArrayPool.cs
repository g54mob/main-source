namespace Utf8Json.Internal
{
	internal class ArrayPool<T>
	{
		private readonly int bufferLength;

		private readonly object gate;

		private int index;

		private T[][] buffers;

		public ArrayPool(int bufferLength)
		{
		}

		public T[] Rent()
		{
			return null;
		}

		public void Return(T[] array)
		{
		}
	}
}
