namespace Utility
{
	public class FloatArrayCircularBuffer : FourBytesArrayCircularBuffer<float>
	{
		public FloatArrayCircularBuffer(int size)
			: base(size)
		{
		}
	}
}
