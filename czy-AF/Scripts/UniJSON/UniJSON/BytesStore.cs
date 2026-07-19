using System;
using System.Runtime.InteropServices;
using System.Text;

namespace UniJSON
{
	public class BytesStore : IStore
	{
		private byte[] m_buffer;

		private int m_pos;

		private char[] m_c = new char[1];

		public ArraySegment<byte> Bytes => new ArraySegment<byte>(m_buffer, 0, m_pos);

		public BytesStore()
			: this(64)
		{
		}

		public BytesStore(int size)
			: this(new byte[size])
		{
		}

		public BytesStore(byte[] buffer)
		{
			m_buffer = buffer;
		}

		private void Require(int size)
		{
			if (m_buffer == null)
			{
				m_buffer = new byte[Math.Max(size, 1024)];
			}
			else if (m_pos + size >= m_buffer.Length)
			{
				int num = Math.Max(m_pos + size, m_buffer.Length * 2);
				byte[] buffer = m_buffer;
				m_buffer = new byte[num];
				Buffer.BlockCopy(buffer, 0, m_buffer, 0, m_pos);
			}
		}

		public void Clear()
		{
			m_pos = 0;
		}

		public void Write(char c)
		{
			if (c <= '\u007f')
			{
				Require(1);
				m_buffer[m_pos++] = (byte)c;
				return;
			}
			Require(3);
			m_c[0] = c;
			int bytes = Encoding.UTF8.GetBytes(m_c, 0, 1, m_buffer, m_pos);
			m_pos += bytes;
		}

		public void Write(string src)
		{
			int byteCount = Encoding.UTF8.GetByteCount(src);
			Require(byteCount);
			int bytes = Encoding.UTF8.GetBytes(src, 0, src.Length, m_buffer, m_pos);
			if (byteCount != bytes)
			{
				throw new Exception();
			}
			m_pos += bytes;
		}

		public void Write(ArraySegment<byte> bytes)
		{
			Require(bytes.Count);
			Array.Copy(bytes.Array, bytes.Offset, m_buffer, m_pos, bytes.Count);
			m_pos += bytes.Count;
		}

		public void Write(sbyte value)
		{
			Require(Marshal.SizeOf(value));
			m_buffer[m_pos++] = (byte)value;
		}

		public void Write(byte value)
		{
			Require(Marshal.SizeOf(value));
			m_buffer[m_pos++] = value;
		}

		public void WriteLittleEndian(short value)
		{
			Require(Marshal.SizeOf(value));
			ByteUnion.WordValue wordValue = ByteUnion.WordValue.Create(value);
			m_buffer[m_pos++] = wordValue.Byte0;
			m_buffer[m_pos++] = wordValue.Byte1;
		}

		public void WriteLittleEndian(int value)
		{
			Require(Marshal.SizeOf(value));
			ByteUnion.DWordValue dWordValue = ByteUnion.DWordValue.Create(value);
			m_buffer[m_pos++] = dWordValue.Byte0;
			m_buffer[m_pos++] = dWordValue.Byte1;
			m_buffer[m_pos++] = dWordValue.Byte2;
			m_buffer[m_pos++] = dWordValue.Byte3;
		}

		public void WriteLittleEndian(long value)
		{
			Require(Marshal.SizeOf(value));
			ByteUnion.QWordValue qWordValue = ByteUnion.QWordValue.Create(value);
			m_buffer[m_pos++] = qWordValue.Byte0;
			m_buffer[m_pos++] = qWordValue.Byte1;
			m_buffer[m_pos++] = qWordValue.Byte2;
			m_buffer[m_pos++] = qWordValue.Byte3;
			m_buffer[m_pos++] = qWordValue.Byte4;
			m_buffer[m_pos++] = qWordValue.Byte5;
			m_buffer[m_pos++] = qWordValue.Byte6;
			m_buffer[m_pos++] = qWordValue.Byte7;
		}

		public void WriteLittleEndian(ushort value)
		{
			Require(Marshal.SizeOf(value));
			ByteUnion.WordValue wordValue = ByteUnion.WordValue.Create(value);
			m_buffer[m_pos++] = wordValue.Byte0;
			m_buffer[m_pos++] = wordValue.Byte1;
		}

		public void WriteLittleEndian(uint value)
		{
			Require(Marshal.SizeOf(value));
			ByteUnion.DWordValue dWordValue = ByteUnion.DWordValue.Create(value);
			m_buffer[m_pos++] = dWordValue.Byte0;
			m_buffer[m_pos++] = dWordValue.Byte1;
			m_buffer[m_pos++] = dWordValue.Byte2;
			m_buffer[m_pos++] = dWordValue.Byte3;
		}

		public void WriteLittleEndian(ulong value)
		{
			Require(Marshal.SizeOf(value));
			ByteUnion.QWordValue qWordValue = ByteUnion.QWordValue.Create(value);
			m_buffer[m_pos++] = qWordValue.Byte0;
			m_buffer[m_pos++] = qWordValue.Byte1;
			m_buffer[m_pos++] = qWordValue.Byte2;
			m_buffer[m_pos++] = qWordValue.Byte3;
			m_buffer[m_pos++] = qWordValue.Byte4;
			m_buffer[m_pos++] = qWordValue.Byte5;
			m_buffer[m_pos++] = qWordValue.Byte6;
			m_buffer[m_pos++] = qWordValue.Byte7;
		}

		public void WriteLittleEndian(float value)
		{
			Require(Marshal.SizeOf(value));
			ByteUnion.DWordValue dWordValue = ByteUnion.DWordValue.Create(value);
			m_buffer[m_pos++] = dWordValue.Byte0;
			m_buffer[m_pos++] = dWordValue.Byte1;
			m_buffer[m_pos++] = dWordValue.Byte2;
			m_buffer[m_pos++] = dWordValue.Byte3;
		}

		public void WriteLittleEndian(double value)
		{
			Require(Marshal.SizeOf(value));
			ByteUnion.QWordValue qWordValue = ByteUnion.QWordValue.Create(value);
			m_buffer[m_pos++] = qWordValue.Byte0;
			m_buffer[m_pos++] = qWordValue.Byte1;
			m_buffer[m_pos++] = qWordValue.Byte2;
			m_buffer[m_pos++] = qWordValue.Byte3;
			m_buffer[m_pos++] = qWordValue.Byte4;
			m_buffer[m_pos++] = qWordValue.Byte5;
			m_buffer[m_pos++] = qWordValue.Byte6;
			m_buffer[m_pos++] = qWordValue.Byte7;
		}

		public void WriteBigEndian(short value)
		{
			Require(Marshal.SizeOf(value));
			ByteUnion.WordValue wordValue = ByteUnion.WordValue.Create(value);
			m_buffer[m_pos++] = wordValue.Byte1;
			m_buffer[m_pos++] = wordValue.Byte0;
		}

		public void WriteBigEndian(int value)
		{
			Require(Marshal.SizeOf(value));
			ByteUnion.DWordValue dWordValue = ByteUnion.DWordValue.Create(value);
			m_buffer[m_pos++] = dWordValue.Byte3;
			m_buffer[m_pos++] = dWordValue.Byte2;
			m_buffer[m_pos++] = dWordValue.Byte1;
			m_buffer[m_pos++] = dWordValue.Byte0;
		}

		public void WriteBigEndian(long value)
		{
			Require(Marshal.SizeOf(value));
			ByteUnion.QWordValue qWordValue = ByteUnion.QWordValue.Create(value);
			m_buffer[m_pos++] = qWordValue.Byte7;
			m_buffer[m_pos++] = qWordValue.Byte6;
			m_buffer[m_pos++] = qWordValue.Byte5;
			m_buffer[m_pos++] = qWordValue.Byte4;
			m_buffer[m_pos++] = qWordValue.Byte3;
			m_buffer[m_pos++] = qWordValue.Byte2;
			m_buffer[m_pos++] = qWordValue.Byte1;
			m_buffer[m_pos++] = qWordValue.Byte0;
		}

		public void WriteBigEndian(ushort value)
		{
			Require(Marshal.SizeOf(value));
			ByteUnion.WordValue wordValue = ByteUnion.WordValue.Create(value);
			m_buffer[m_pos++] = wordValue.Byte1;
			m_buffer[m_pos++] = wordValue.Byte0;
		}

		public void WriteBigEndian(uint value)
		{
			Require(Marshal.SizeOf(value));
			ByteUnion.DWordValue dWordValue = ByteUnion.DWordValue.Create(value);
			m_buffer[m_pos++] = dWordValue.Byte3;
			m_buffer[m_pos++] = dWordValue.Byte2;
			m_buffer[m_pos++] = dWordValue.Byte1;
			m_buffer[m_pos++] = dWordValue.Byte0;
		}

		public void WriteBigEndian(ulong value)
		{
			Require(Marshal.SizeOf(value));
			ByteUnion.QWordValue qWordValue = ByteUnion.QWordValue.Create(value);
			m_buffer[m_pos++] = qWordValue.Byte7;
			m_buffer[m_pos++] = qWordValue.Byte6;
			m_buffer[m_pos++] = qWordValue.Byte5;
			m_buffer[m_pos++] = qWordValue.Byte4;
			m_buffer[m_pos++] = qWordValue.Byte3;
			m_buffer[m_pos++] = qWordValue.Byte2;
			m_buffer[m_pos++] = qWordValue.Byte1;
			m_buffer[m_pos++] = qWordValue.Byte0;
		}

		public void WriteBigEndian(float value)
		{
			Require(Marshal.SizeOf(value));
			ByteUnion.DWordValue dWordValue = ByteUnion.DWordValue.Create(value);
			m_buffer[m_pos++] = dWordValue.Byte3;
			m_buffer[m_pos++] = dWordValue.Byte2;
			m_buffer[m_pos++] = dWordValue.Byte1;
			m_buffer[m_pos++] = dWordValue.Byte0;
		}

		public void WriteBigEndian(double value)
		{
			Require(Marshal.SizeOf(value));
			ByteUnion.QWordValue qWordValue = ByteUnion.QWordValue.Create(value);
			m_buffer[m_pos++] = qWordValue.Byte7;
			m_buffer[m_pos++] = qWordValue.Byte6;
			m_buffer[m_pos++] = qWordValue.Byte5;
			m_buffer[m_pos++] = qWordValue.Byte4;
			m_buffer[m_pos++] = qWordValue.Byte3;
			m_buffer[m_pos++] = qWordValue.Byte2;
			m_buffer[m_pos++] = qWordValue.Byte1;
			m_buffer[m_pos++] = qWordValue.Byte0;
		}
	}
}
