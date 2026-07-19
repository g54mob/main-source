using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace UniJSON
{
	public static class Utf8StringExtensions
	{
		public static void WriteTo(this Utf8String src, Stream dst)
		{
			ArraySegment<byte> bytes = src.Bytes;
			byte[] array = bytes.Array;
			bytes = src.Bytes;
			int offset = bytes.Offset;
			bytes = src.Bytes;
			dst.Write(array, offset, bytes.Count);
		}

		public static Utf8Iterator GetFirst(this Utf8String src)
		{
			Utf8Iterator iterator = src.GetIterator();
			iterator.MoveNext();
			return iterator;
		}

		public static bool TrySearchByte(this Utf8String src, Func<byte, bool> pred, out int pos)
		{
			for (pos = 0; pos < src.ByteLength; pos++)
			{
				if (pred(src[pos]))
				{
					return true;
				}
			}
			return false;
		}

		public static bool TrySearchAscii(this Utf8String src, byte target, int start, out int pos)
		{
			Utf8Iterator utf8Iterator = new Utf8Iterator(src.Bytes, start);
			while (utf8Iterator.MoveNext())
			{
				byte current = utf8Iterator.Current;
				if (current > 127)
				{
					continue;
				}
				if (current == target)
				{
					pos = utf8Iterator.BytePosition;
					return true;
				}
				if (current == 92)
				{
					switch ((char)utf8Iterator.Second)
					{
					case '"':
					case '/':
					case '\\':
					case 'b':
					case 'f':
					case 'n':
					case 'r':
					case 't':
						utf8Iterator.MoveNext();
						break;
					case 'u':
						utf8Iterator.MoveNext();
						utf8Iterator.MoveNext();
						utf8Iterator.MoveNext();
						utf8Iterator.MoveNext();
						break;
					default:
						throw new ParserException("unknown escape: " + utf8Iterator.Second);
					}
				}
			}
			pos = -1;
			return false;
		}

		public static IEnumerable<Utf8String> Split(this Utf8String src, byte delimiter)
		{
			int num = 0;
			Utf8Iterator p = new Utf8Iterator(src.Bytes);
			while (p.MoveNext())
			{
				if (p.Current == delimiter)
				{
					if (p.BytePosition - num == 0)
					{
						yield return default(Utf8String);
					}
					else
					{
						yield return src.Subbytes(num, p.BytePosition - num);
					}
					num = p.BytePosition + 1;
				}
			}
			if (num < p.BytePosition)
			{
				yield return src.Subbytes(num, p.BytePosition - num);
			}
		}

		public static sbyte ToSByte(this Utf8String src)
		{
			sbyte b = 0;
			Utf8Iterator utf8Iterator = new Utf8Iterator(src.Bytes);
			while (utf8Iterator.MoveNext())
			{
				b = utf8Iterator.Current switch
				{
					48 => (sbyte)(b * 10), 
					49 => (sbyte)(b * 10 + 1), 
					50 => (sbyte)(b * 10 + 2), 
					51 => (sbyte)(b * 10 + 3), 
					52 => (sbyte)(b * 10 + 4), 
					53 => (sbyte)(b * 10 + 5), 
					54 => (sbyte)(b * 10 + 6), 
					55 => (sbyte)(b * 10 + 7), 
					56 => (sbyte)(b * 10 + 8), 
					57 => (sbyte)(b * 10 + 9), 
					_ => throw new ArgumentOutOfRangeException(), 
				};
			}
			return b;
		}

		public static short ToInt16(this Utf8String src)
		{
			short num = 0;
			Utf8Iterator utf8Iterator = new Utf8Iterator(src.Bytes);
			while (utf8Iterator.MoveNext())
			{
				num = utf8Iterator.Current switch
				{
					48 => (short)(num * 10), 
					49 => (short)(num * 10 + 1), 
					50 => (short)(num * 10 + 2), 
					51 => (short)(num * 10 + 3), 
					52 => (short)(num * 10 + 4), 
					53 => (short)(num * 10 + 5), 
					54 => (short)(num * 10 + 6), 
					55 => (short)(num * 10 + 7), 
					56 => (short)(num * 10 + 8), 
					57 => (short)(num * 10 + 9), 
					_ => throw new ArgumentOutOfRangeException(), 
				};
			}
			return num;
		}

		public static int ToInt32(this Utf8String src)
		{
			int num = 0;
			int num2 = 1;
			Utf8Iterator utf8Iterator = new Utf8Iterator(src.Bytes);
			bool flag = true;
			while (utf8Iterator.MoveNext())
			{
				byte current = utf8Iterator.Current;
				if (flag)
				{
					flag = false;
					if (current == 45)
					{
						num2 = -1;
						continue;
					}
				}
				num = current switch
				{
					48 => num * 10, 
					49 => num * 10 + 1, 
					50 => num * 10 + 2, 
					51 => num * 10 + 3, 
					52 => num * 10 + 4, 
					53 => num * 10 + 5, 
					54 => num * 10 + 6, 
					55 => num * 10 + 7, 
					56 => num * 10 + 8, 
					57 => num * 10 + 9, 
					_ => throw new ArgumentOutOfRangeException(), 
				};
			}
			return num * num2;
		}

		public static long ToInt64(this Utf8String src)
		{
			long num = 0L;
			Utf8Iterator utf8Iterator = new Utf8Iterator(src.Bytes);
			while (utf8Iterator.MoveNext())
			{
				num = utf8Iterator.Current switch
				{
					48 => num * 10, 
					49 => num * 10 + 1, 
					50 => num * 10 + 2, 
					51 => num * 10 + 3, 
					52 => num * 10 + 4, 
					53 => num * 10 + 5, 
					54 => num * 10 + 6, 
					55 => num * 10 + 7, 
					56 => num * 10 + 8, 
					57 => num * 10 + 9, 
					_ => throw new ArgumentOutOfRangeException(), 
				};
			}
			return num;
		}

		public static byte ToByte(this Utf8String src)
		{
			byte b = 0;
			Utf8Iterator utf8Iterator = new Utf8Iterator(src.Bytes);
			while (utf8Iterator.MoveNext())
			{
				b = utf8Iterator.Current switch
				{
					48 => (byte)(b * 10), 
					49 => (byte)(b * 10 + 1), 
					50 => (byte)(b * 10 + 2), 
					51 => (byte)(b * 10 + 3), 
					52 => (byte)(b * 10 + 4), 
					53 => (byte)(b * 10 + 5), 
					54 => (byte)(b * 10 + 6), 
					55 => (byte)(b * 10 + 7), 
					56 => (byte)(b * 10 + 8), 
					57 => (byte)(b * 10 + 9), 
					_ => throw new ArgumentOutOfRangeException(), 
				};
			}
			return b;
		}

		public static ushort ToUInt16(this Utf8String src)
		{
			ushort num = 0;
			Utf8Iterator utf8Iterator = new Utf8Iterator(src.Bytes);
			while (utf8Iterator.MoveNext())
			{
				num = utf8Iterator.Current switch
				{
					48 => (ushort)(num * 10), 
					49 => (ushort)(num * 10 + 1), 
					50 => (ushort)(num * 10 + 2), 
					51 => (ushort)(num * 10 + 3), 
					52 => (ushort)(num * 10 + 4), 
					53 => (ushort)(num * 10 + 5), 
					54 => (ushort)(num * 10 + 6), 
					55 => (ushort)(num * 10 + 7), 
					56 => (ushort)(num * 10 + 8), 
					57 => (ushort)(num * 10 + 9), 
					_ => throw new ArgumentOutOfRangeException(), 
				};
			}
			return num;
		}

		public static uint ToUInt32(this Utf8String src)
		{
			uint num = 0u;
			Utf8Iterator utf8Iterator = new Utf8Iterator(src.Bytes);
			while (utf8Iterator.MoveNext())
			{
				num = utf8Iterator.Current switch
				{
					48 => num * 10, 
					49 => num * 10 + 1, 
					50 => num * 10 + 2, 
					51 => num * 10 + 3, 
					52 => num * 10 + 4, 
					53 => num * 10 + 5, 
					54 => num * 10 + 6, 
					55 => num * 10 + 7, 
					56 => num * 10 + 8, 
					57 => num * 10 + 9, 
					_ => throw new ArgumentOutOfRangeException(), 
				};
			}
			return num;
		}

		public static ulong ToUInt64(this Utf8String src)
		{
			ulong num = 0uL;
			Utf8Iterator utf8Iterator = new Utf8Iterator(src.Bytes);
			while (utf8Iterator.MoveNext())
			{
				num = utf8Iterator.Current switch
				{
					48 => num * 10, 
					49 => num * 10 + 1, 
					50 => num * 10 + 2, 
					51 => num * 10 + 3, 
					52 => num * 10 + 4, 
					53 => num * 10 + 5, 
					54 => num * 10 + 6, 
					55 => num * 10 + 7, 
					56 => num * 10 + 8, 
					57 => num * 10 + 9, 
					_ => throw new ArgumentOutOfRangeException(), 
				};
			}
			return num;
		}

		public static float ToSingle(this Utf8String src)
		{
			return float.Parse(src.ToAscii(), CultureInfo.InvariantCulture);
		}

		public static double ToDouble(this Utf8String src)
		{
			return double.Parse(src.ToAscii(), CultureInfo.InvariantCulture);
		}

		public static Utf8String GetLine(this Utf8String src)
		{
			if (!src.TrySearchAscii(10, 0, out var pos))
			{
				return src;
			}
			return src.Subbytes(0, pos + 1);
		}
	}
}
