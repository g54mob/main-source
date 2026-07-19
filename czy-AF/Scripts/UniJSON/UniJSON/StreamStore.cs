using System;
using System.IO;
using System.Text;

namespace UniJSON
{
	public class StreamStore : IStore
	{
		private Stream m_s;

		private BinaryWriter m_w;

		public ArraySegment<byte> Bytes
		{
			get
			{
				if (!(m_s is MemoryStream memoryStream))
				{
					throw new NotImplementedException();
				}
				return new ArraySegment<byte>(memoryStream.GetBuffer(), 0, (int)memoryStream.Position);
			}
		}

		public StreamStore(Stream s)
		{
			m_s = s;
			m_w = new BinaryWriter(m_s);
		}

		public void Clear()
		{
			m_s.SetLength(0L);
		}

		public void Write(sbyte value)
		{
			m_w.Write(value);
		}

		public void Write(byte value)
		{
			m_w.Write(value);
		}

		public void Write(char c)
		{
			m_w.Write(c);
		}

		public void Write(string src)
		{
			m_w.Write(Encoding.UTF8.GetBytes(src));
		}

		public void Write(ArraySegment<byte> bytes)
		{
			m_w.Write(bytes.Array, bytes.Offset, bytes.Count);
		}

		public void WriteBigEndian(int value)
		{
			throw new NotImplementedException();
		}

		public void WriteBigEndian(float value)
		{
			throw new NotImplementedException();
		}

		public void WriteBigEndian(double value)
		{
			throw new NotImplementedException();
		}

		public void WriteBigEndian(long value)
		{
			throw new NotImplementedException();
		}

		public void WriteBigEndian(short value)
		{
			throw new NotImplementedException();
		}

		public void WriteBigEndian(uint value)
		{
			throw new NotImplementedException();
		}

		public void WriteBigEndian(ulong value)
		{
			throw new NotImplementedException();
		}

		public void WriteBigEndian(ushort value)
		{
			throw new NotImplementedException();
		}

		public void WriteLittleEndian(long value)
		{
			m_w.Write(value);
		}

		public void WriteLittleEndian(uint value)
		{
			m_w.Write(value);
		}

		public void WriteLittleEndian(short value)
		{
			m_w.Write(value);
		}

		public void WriteLittleEndian(ulong value)
		{
			m_w.Write(value);
		}

		public void WriteLittleEndian(double value)
		{
			m_w.Write(value);
		}

		public void WriteLittleEndian(float value)
		{
			m_w.Write(value);
		}

		public void WriteLittleEndian(int value)
		{
			m_w.Write(value);
		}

		public void WriteLittleEndian(ushort value)
		{
			m_w.Write(value);
		}
	}
}
