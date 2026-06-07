namespace Utility
{
	public class IntArrayCircularBuffer : FourBytesArrayCircularBuffer<int>
	{
		public IntArrayCircularBuffer(int size)
			: base(size)
		{
		}
	}
}
