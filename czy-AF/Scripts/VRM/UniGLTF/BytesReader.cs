using System;
using System.Runtime.InteropServices;
using System.Text;

namespace UniGLTF
{
	public class BytesReader
	{
		private byte[] m_bytes;

		private int m_pos;

		public BytesReader(byte[] bytes, int pos = 0)
		{
			m_bytes = bytes;
			m_pos = pos;
		}

		public string ReadString(int count, Encoding encoding)
		{
			string result = encoding.GetString(m_bytes, m_pos, count);
			m_pos += count;
			return result;
		}

		public float ReadSingle()
		{
			float result = BitConverter.ToSingle(m_bytes, m_pos);
			m_pos += 4;
			return result;
		}

		public byte ReadUInt8()
		{
			return m_bytes[m_pos++];
		}

		public ushort ReadUInt16()
		{
			ushort result = BitConverter.ToUInt16(m_bytes, m_pos);
			m_pos += 2;
			return result;
		}

		public sbyte ReadInt8()
		{
			return (sbyte)m_bytes[m_pos++];
		}

		public short ReadInt16()
		{
			short result = BitConverter.ToInt16(m_bytes, m_pos);
			m_pos += 2;
			return result;
		}

		public int ReadInt32()
		{
			int result = BitConverter.ToInt32(m_bytes, m_pos);
			m_pos += 4;
			return result;
		}

		public void ReadToArray<T>(T[] dst) where T : struct
		{
			int num = new ArraySegment<byte>(m_bytes, m_pos, m_bytes.Length - m_pos).MarshalCopyTo(dst);
			m_pos += num;
		}

		public T ReadStruct<T>() where T : struct
		{
			int num = Marshal.SizeOf(typeof(T));
			using Pin<byte> pin = Pin.Create(new ArraySegment<byte>(m_bytes, m_pos, m_bytes.Length - m_pos));
			T result = (T)Marshal.PtrToStructure(pin.Ptr, typeof(T));
			m_pos += num;
			return result;
		}
	}
}
