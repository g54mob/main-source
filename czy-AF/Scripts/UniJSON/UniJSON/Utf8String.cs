using System;
using System.Linq;
using System.Text;

namespace UniJSON
{
	public struct Utf8String : IComparable<Utf8String>
	{
		public static readonly Encoding Encoding = new UTF8Encoding(encoderShouldEmitUTF8Identifier: false);

		public readonly ArraySegment<byte> Bytes;

		public int ByteLength
		{
			get
			{
				ArraySegment<byte> bytes = Bytes;
				return bytes.Count;
			}
		}

		public byte this[int i]
		{
			get
			{
				ArraySegment<byte> bytes = Bytes;
				byte[] array = bytes.Array;
				bytes = Bytes;
				return array[bytes.Offset + i];
			}
		}

		public bool IsEmpty => ByteLength == 0;

		public bool IsInt
		{
			get
			{
				for (int i = 0; i < ByteLength; i++)
				{
					byte b = this[i];
					if (b != 48 && b != 49 && b != 50 && b != 51 && b != 52 && b != 53 && b != 54 && b != 55 && b != 56 && b != 57 && (i != 0 || b != 45))
					{
						if (b != 46 && b != 101)
						{
							break;
						}
						return false;
					}
				}
				return true;
			}
		}

		public Utf8Iterator GetIterator()
		{
			return new Utf8Iterator(Bytes);
		}

		public int CompareTo(Utf8String other)
		{
			int i;
			for (i = 0; i < ByteLength && i < other.ByteLength; i++)
			{
				if (this[i] < other[i])
				{
					return 1;
				}
				if (this[i] > other[i])
				{
					return -1;
				}
			}
			if (i < ByteLength)
			{
				return -1;
			}
			if (i < other.ByteLength)
			{
				return 1;
			}
			return 0;
		}

		public Utf8String(ArraySegment<byte> bytes)
		{
			Bytes = bytes;
		}

		public Utf8String(byte[] bytes, int offset, int count)
			: this(new ArraySegment<byte>(bytes, offset, count))
		{
		}

		public Utf8String(byte[] bytes)
			: this(bytes, 0, bytes.Length)
		{
		}

		public static Utf8String From(string src)
		{
			return new Utf8String(Encoding.GetBytes(src));
		}

		public static Utf8String From(string src, byte[] bytes)
		{
			if (src.Sum((char c2) => Utf8Iterator.ByteLengthFromChar(c2)) > bytes.Length)
			{
				throw new OverflowException();
			}
			int count = 0;
			foreach (char c in src)
			{
				if ((uint)c <= 127u)
				{
					bytes[count++] = (byte)c;
				}
				else if ((uint)c <= 2047u)
				{
					bytes[count++] = (byte)(0xC0 | (0x1FuL & (ulong)((int)c >> 6)));
					bytes[count++] = (byte)(0x80 | (0x3F & c));
				}
				else
				{
					bytes[count++] = (byte)(0xE0 | (0xFuL & (ulong)((int)c >> 12)));
					bytes[count++] = (byte)(0x80 | (0x3FuL & (ulong)((int)c >> 6)));
					bytes[count++] = (byte)(0x80 | (0x3F & c));
				}
			}
			return new Utf8String(new ArraySegment<byte>(bytes, 0, count));
		}

		public static Utf8String From(int src)
		{
			if (src >= 0)
			{
				if (src < 10)
				{
					return new Utf8String(new byte[1] { (byte)(48 + src) });
				}
				if (src < 100)
				{
					return new Utf8String(new byte[2]
					{
						(byte)(48 + src / 10),
						(byte)(48 + src % 10)
					});
				}
				if (src < 1000)
				{
					return new Utf8String(new byte[3]
					{
						(byte)(48 + src / 100),
						(byte)(48 + src / 10),
						(byte)(48 + src % 10)
					});
				}
				if (src < 10000)
				{
					return new Utf8String(new byte[4]
					{
						(byte)(48 + src / 1000),
						(byte)(48 + src / 100),
						(byte)(48 + src / 10),
						(byte)(48 + src % 10)
					});
				}
				if (src < 100000)
				{
					return new Utf8String(new byte[5]
					{
						(byte)(48 + src / 10000),
						(byte)(48 + src / 1000),
						(byte)(48 + src / 100),
						(byte)(48 + src / 10),
						(byte)(48 + src % 10)
					});
				}
				if (src < 1000000)
				{
					return new Utf8String(new byte[6]
					{
						(byte)(48 + src / 100000),
						(byte)(48 + src / 10000),
						(byte)(48 + src / 1000),
						(byte)(48 + src / 100),
						(byte)(48 + src / 10),
						(byte)(48 + src % 10)
					});
				}
				if (src < 10000000)
				{
					return new Utf8String(new byte[7]
					{
						(byte)(48 + src / 1000000),
						(byte)(48 + src / 100000),
						(byte)(48 + src / 10000),
						(byte)(48 + src / 1000),
						(byte)(48 + src / 100),
						(byte)(48 + src / 10),
						(byte)(48 + src % 10)
					});
				}
				if (src < 100000000)
				{
					return new Utf8String(new byte[8]
					{
						(byte)(48 + src / 10000000),
						(byte)(48 + src / 1000000),
						(byte)(48 + src / 100000),
						(byte)(48 + src / 10000),
						(byte)(48 + src / 1000),
						(byte)(48 + src / 100),
						(byte)(48 + src / 10),
						(byte)(48 + src % 10)
					});
				}
				if (src < 1000000000)
				{
					return new Utf8String(new byte[9]
					{
						(byte)(48 + src / 100000000),
						(byte)(48 + src / 10000000),
						(byte)(48 + src / 1000000),
						(byte)(48 + src / 100000),
						(byte)(48 + src / 10000),
						(byte)(48 + src / 1000),
						(byte)(48 + src / 100),
						(byte)(48 + src / 10),
						(byte)(48 + src % 10)
					});
				}
				return new Utf8String(new byte[10]
				{
					(byte)(48 + src / 1000000000),
					(byte)(48 + src / 100000000),
					(byte)(48 + src / 10000000),
					(byte)(48 + src / 1000000),
					(byte)(48 + src / 100000),
					(byte)(48 + src / 10000),
					(byte)(48 + src / 1000),
					(byte)(48 + src / 100),
					(byte)(48 + src / 10),
					(byte)(48 + src % 10)
				});
			}
			throw new NotImplementedException();
		}

		public Utf8String Concat(Utf8String rhs)
		{
			byte[] array = new byte[ByteLength + rhs.ByteLength];
			ArraySegment<byte> bytes = Bytes;
			byte[] array2 = bytes.Array;
			bytes = Bytes;
			Buffer.BlockCopy(array2, bytes.Offset, array, 0, ByteLength);
			bytes = rhs.Bytes;
			byte[] array3 = bytes.Array;
			bytes = rhs.Bytes;
			Buffer.BlockCopy(array3, bytes.Offset, array, ByteLength, rhs.ByteLength);
			return new Utf8String(array);
		}

		public override string ToString()
		{
			if (ByteLength == 0)
			{
				return "";
			}
			Encoding encoding = Encoding;
			ArraySegment<byte> bytes = Bytes;
			byte[] array = bytes.Array;
			bytes = Bytes;
			int offset = bytes.Offset;
			bytes = Bytes;
			return encoding.GetString(array, offset, bytes.Count);
		}

		public string ToAscii()
		{
			if (ByteLength == 0)
			{
				return "";
			}
			Encoding aSCII = Encoding.ASCII;
			ArraySegment<byte> bytes = Bytes;
			byte[] array = bytes.Array;
			bytes = Bytes;
			int offset = bytes.Offset;
			bytes = Bytes;
			return aSCII.GetString(array, offset, bytes.Count);
		}

		public bool StartsWith(Utf8String rhs)
		{
			if (rhs.ByteLength > ByteLength)
			{
				return false;
			}
			for (int i = 0; i < rhs.ByteLength; i++)
			{
				if (this[i] != rhs[i])
				{
					return false;
				}
			}
			return true;
		}

		public bool EndsWith(Utf8String rhs)
		{
			if (rhs.ByteLength > ByteLength)
			{
				return false;
			}
			for (int i = 1; i <= rhs.ByteLength; i++)
			{
				if (this[ByteLength - i] != rhs[rhs.ByteLength - i])
				{
					return false;
				}
			}
			return true;
		}

		public int IndexOf(byte code)
		{
			return IndexOf(0, code);
		}

		public int IndexOf(int offset, byte code)
		{
			ArraySegment<byte> bytes = Bytes;
			int num = offset + bytes.Offset;
			int num2 = 0;
			while (true)
			{
				int num3 = num2;
				bytes = Bytes;
				if (num3 >= bytes.Count)
				{
					break;
				}
				bytes = Bytes;
				if (bytes.Array[num] == code)
				{
					int num4 = num;
					bytes = Bytes;
					return num4 - bytes.Offset;
				}
				num2++;
				num++;
			}
			return -1;
		}

		public Utf8String Subbytes(int offset)
		{
			return Subbytes(offset, ByteLength - offset);
		}

		public Utf8String Subbytes(int offset, int count)
		{
			ArraySegment<byte> bytes = Bytes;
			byte[] array = bytes.Array;
			bytes = Bytes;
			return new Utf8String(array, bytes.Offset + offset, count);
		}

		private static bool IsSpace(byte b)
		{
			if ((uint)(b - 9) <= 4u || b == 32)
			{
				return true;
			}
			return false;
		}

		public Utf8String TrimStart()
		{
			int i;
			for (i = 0; i < ByteLength && IsSpace(this[i]); i++)
			{
			}
			return Subbytes(i);
		}

		public Utf8String TrimEnd()
		{
			int num = ByteLength - 1;
			while (num >= 0 && IsSpace(this[num]))
			{
				num--;
			}
			return Subbytes(0, num + 1);
		}

		public Utf8String Trim()
		{
			return TrimStart().TrimEnd();
		}

		public override bool Equals(object obj)
		{
			if (obj is Utf8String)
			{
				return Equals((Utf8String)obj);
			}
			return false;
		}

		public static bool operator ==(Utf8String x, Utf8String y)
		{
			return x.Equals(y);
		}

		public static bool operator !=(Utf8String x, Utf8String y)
		{
			return !(x == y);
		}

		public bool Equals(Utf8String other)
		{
			if (ByteLength != other.ByteLength)
			{
				return false;
			}
			for (int i = 0; i < ByteLength; i++)
			{
				if (this[i] != other[i])
				{
					return false;
				}
			}
			return true;
		}

		public override int GetHashCode()
		{
			return ByteLength.GetHashCode();
		}

		public static Utf8String operator +(Utf8String l, Utf8String r)
		{
			return new Utf8String(l.Bytes.Concat(r.Bytes));
		}
	}
}
