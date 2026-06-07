namespace Utf8Json.Internal
{
	public struct ArrayBuffer<T>
	{
		public T[] Buffer;

		public int Size;

		public ArrayBuffer(int initialSize)
		{
			Buffer = null;
			Size = 0;
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
