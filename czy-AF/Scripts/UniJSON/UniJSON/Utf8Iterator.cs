using System;
using System.Collections;
using System.Collections.Generic;

namespace UniJSON
{
	public struct Utf8Iterator : IEnumerator<byte>, IEnumerator, IDisposable
	{
		private byte[] m_bytes;

		private int m_offset;

		private int m_start;

		private int m_position;

		private int m_end;

		public const uint Mask1 = 1u;

		public const uint Mask2 = 3u;

		public const uint Mask3 = 7u;

		public const uint Mask4 = 15u;

		public const uint Mask5 = 31u;

		public const uint Mask6 = 63u;

		public const uint Mask7 = 127u;

		public const uint Mask11 = 2047u;

		public const uint Head1 = 128u;

		public const uint Head2 = 192u;

		public const uint Head3 = 224u;

		public const uint Head4 = 240u;

		public int BytePosition => m_position - m_offset;

		public int CurrentByteLength
		{
			get
			{
				byte current = Current;
				if (current <= 127)
				{
					return 1;
				}
				if (current <= 223)
				{
					return 2;
				}
				if (current <= 239)
				{
					return 3;
				}
				if (current <= 247)
				{
					return 4;
				}
				throw new Exception("invalid utf8");
			}
		}

		public byte Current => m_bytes[m_position];

		object IEnumerator.Current => Current;

		public byte Second => m_bytes[m_position + 1];

		public byte Third => m_bytes[m_position + 2];

		public byte Fourth => m_bytes[m_position + 3];

		public uint Unicode => CurrentByteLength switch
		{
			1 => Current, 
			2 => (uint)(((0x1F & Current) << 6) | (0x3F & Second)), 
			3 => (uint)(((0xF & Current) << 12) | ((0x3F & Second) << 6) | (0x3F & Third)), 
			4 => (uint)(((7 & Current) << 18) | ((0x3F & Second) << 12) | ((0x3F & Third) << 6) | (0x3F & Fourth)), 
			_ => throw new Exception("invalid utf8"), 
		};

		public char Char => CurrentByteLength switch
		{
			1 => (char)Current, 
			2 => (char)(((0x1F & Current) << 6) | (0x3F & Second)), 
			3 => (char)(((0xF & Current) << 12) | ((0x3F & Second) << 6) | (0x3F & Third)), 
			4 => throw new NotImplementedException(), 
			_ => throw new Exception("invalid utf8"), 
		};

		public Utf8Iterator(ArraySegment<byte> range, int start = 0)
		{
			m_bytes = range.Array;
			m_offset = range.Offset;
			m_start = m_offset + start;
			m_position = -1;
			m_end = range.Offset + range.Count;
		}

		public static int ByteLengthFromChar(char c)
		{
			if ((uint)c <= 127u)
			{
				return 1;
			}
			if ((uint)c <= 2047u)
			{
				return 2;
			}
			return 3;
		}

		public void Dispose()
		{
		}

		public bool MoveNext()
		{
			if (m_position == -1)
			{
				m_position = m_start;
			}
			else
			{
				m_position += CurrentByteLength;
			}
			return m_position < m_end;
		}

		public void Reset()
		{
			m_position = -1;
		}
	}
}
