using System;

namespace UniJSON
{
	public class ByteBuffer
	{
		private byte[] m_buffer;

		private int m_used;

		public ArraySegment<byte> Bytes => new ArraySegment<byte>(m_buffer, 0, Count);

		public int Count => m_used;

		public int Remain
		{
			get
			{
				if (m_buffer == null)
				{
					return 0;
				}
				return m_buffer.Length - m_used;
			}
		}

		public ByteBuffer()
		{
		}

		public ByteBuffer(byte[] buffer)
		{
			m_buffer = buffer;
		}

		private void Ensure(int size)
		{
			if (m_buffer == null || size >= m_buffer.Length - m_used)
			{
				byte[] array = new byte[m_used + size];
				if (m_buffer != null && m_used > 0)
				{
					Buffer.BlockCopy(m_buffer, 0, array, 0, m_used);
				}
				m_buffer = array;
			}
		}

		public void Push(byte b)
		{
			Ensure(1);
			m_buffer[m_used++] = b;
		}

		public void Push(byte[] buffer)
		{
			Push(new ArraySegment<byte>(buffer));
		}

		public void Push(ArraySegment<byte> buffer)
		{
			Ensure(buffer.Count);
			Buffer.BlockCopy(buffer.Array, buffer.Offset, m_buffer, m_used, buffer.Count);
			m_used += buffer.Count;
		}

		public void Unshift(int size)
		{
			if (size > m_used)
			{
				throw new ArgumentException();
			}
			if (m_used - size < size)
			{
				Buffer.BlockCopy(m_buffer, m_used, m_buffer, 0, m_used - size);
				m_used -= size;
			}
			else
			{
				byte[] array = new byte[m_used];
				Buffer.BlockCopy(m_buffer, size, array, 0, m_used - size);
				m_buffer = array;
			}
		}
	}
}
