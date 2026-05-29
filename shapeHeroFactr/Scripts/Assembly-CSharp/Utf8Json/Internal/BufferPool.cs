namespace Utf8Json.Internal
{
	internal sealed class BufferPool : ArrayPool<byte>
	{
		public static readonly BufferPool Default;

		public BufferPool(int bufferLength)
			: base(0)
		{
		}
	}
}
