using System;
using System.Runtime.InteropServices;

namespace UniGLTF
{
	public class ArrayByteBuffer : IBytesBuffer
	{
		private byte[] m_bytes;

		private int m_used;

		public string Uri { get; private set; }

		public ArrayByteBuffer(byte[] bytes = null)
		{
			Uri = "";
			m_bytes = bytes;
		}

		public glTFBufferView Extend<T>(ArraySegment<T> array, glBufferTarget target) where T : struct
		{
			using Pin<T> pin = Pin.Create(array);
			int num = Marshal.SizeOf(typeof(T));
			return Extend(pin.Ptr, array.Count * num, num, target);
		}

		public glTFBufferView Extend(IntPtr p, int bytesLength, int stride, glBufferTarget target)
		{
			byte[] bytes = m_bytes;
			int num = ((m_used % stride != 0) ? (stride - m_used % stride) : 0);
			if (m_bytes == null || m_used + num + bytesLength > m_bytes.Length)
			{
				m_bytes = new byte[m_used + num + bytesLength];
				if (m_used > 0)
				{
					Buffer.BlockCopy(bytes, 0, m_bytes, 0, m_used);
				}
			}
			if (m_used + num + bytesLength > m_bytes.Length)
			{
				throw new ArgumentOutOfRangeException();
			}
			Marshal.Copy(p, m_bytes, m_used + num, bytesLength);
			glTFBufferView result = new glTFBufferView
			{
				buffer = 0,
				byteLength = bytesLength,
				byteOffset = m_used + num,
				byteStride = stride,
				target = target
			};
			m_used = m_used + num + bytesLength;
			return result;
		}

		public ArraySegment<byte> GetBytes()
		{
			if (m_bytes == null)
			{
				return default(ArraySegment<byte>);
			}
			return new ArraySegment<byte>(m_bytes, 0, m_used);
		}
	}
}
