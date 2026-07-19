using System;

namespace UniGLTF
{
	public class ArraySegmentByteBuffer : IBytesBuffer
	{
		private ArraySegment<byte> m_bytes;

		public string Uri { get; private set; }

		public ArraySegmentByteBuffer(ArraySegment<byte> bytes)
		{
			m_bytes = bytes;
		}

		public glTFBufferView Extend<T>(ArraySegment<T> array, glBufferTarget target) where T : struct
		{
			throw new NotImplementedException();
		}

		public ArraySegment<byte> GetBytes()
		{
			return m_bytes;
		}
	}
}
