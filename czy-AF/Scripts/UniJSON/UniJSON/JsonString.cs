using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UniJSON
{
	public static class JsonString
	{
		public static void Escape(string s, IStore w)
		{
			if (string.IsNullOrEmpty(s))
			{
				return;
			}
			IEnumerator<char> enumerator = s.ToCharArray().Cast<char>().GetEnumerator();
			while (enumerator.MoveNext())
			{
				switch (enumerator.Current)
				{
				case '"':
				case '/':
				case '\\':
					w.Write('\\');
					w.Write(enumerator.Current);
					break;
				case '\b':
					w.Write('\\');
					w.Write('b');
					break;
				case '\f':
					w.Write('\\');
					w.Write('f');
					break;
				case '\n':
					w.Write('\\');
					w.Write('n');
					break;
				case '\r':
					w.Write('\\');
					w.Write('r');
					break;
				case '\t':
					w.Write('\\');
					w.Write('t');
					break;
				default:
					w.Write(enumerator.Current);
					break;
				}
			}
		}

		public static void Escape(Utf8String s, IStore w)
		{
			if (s.IsEmpty)
			{
				return;
			}
			Utf8Iterator iterator = s.GetIterator();
			while (iterator.MoveNext())
			{
				switch (iterator.CurrentByteLength)
				{
				case 1:
				{
					byte current = iterator.Current;
					switch (current)
					{
					case 34:
					case 47:
					case 92:
						w.Write((byte)92);
						w.Write(current);
						break;
					case 8:
						w.Write((byte)92);
						w.Write((byte)98);
						break;
					case 12:
						w.Write((byte)92);
						w.Write((byte)102);
						break;
					case 10:
						w.Write((byte)92);
						w.Write((byte)110);
						break;
					case 13:
						w.Write((byte)92);
						w.Write((byte)114);
						break;
					case 9:
						w.Write((byte)92);
						w.Write((byte)116);
						break;
					default:
						w.Write(current);
						break;
					}
					break;
				}
				case 2:
					w.Write(iterator.Current);
					w.Write(iterator.Second);
					break;
				case 3:
					w.Write(iterator.Current);
					w.Write(iterator.Second);
					w.Write(iterator.Third);
					break;
				case 4:
					w.Write(iterator.Current);
					w.Write(iterator.Second);
					w.Write(iterator.Third);
					w.Write(iterator.Fourth);
					break;
				default:
					throw new ParserException("invalid utf8");
				}
			}
		}

		public static string Escape(string s)
		{
			StringBuilder stringBuilder = new StringBuilder();
			Escape(s, new StringBuilderStore(stringBuilder));
			return stringBuilder.ToString();
		}

		public static void Quote(string s, IStore w)
		{
			w.Write('"');
			Escape(s, w);
			w.Write('"');
		}

		public static void Quote(Utf8String s, IStore w)
		{
			w.Write((byte)34);
			Escape(s, w);
			w.Write((byte)34);
		}

		public static string Quote(string s)
		{
			StringBuilder stringBuilder = new StringBuilder();
			Quote(s, new StringBuilderStore(stringBuilder));
			return stringBuilder.ToString();
		}

		public static Utf8String Quote(Utf8String s)
		{
			BytesStore bytesStore = new BytesStore(s.ByteLength);
			Quote(s, bytesStore);
			return new Utf8String(bytesStore.Bytes);
		}

		public static int Unescape(string src, IStore w)
		{
			int writeCount = 0;
			Action<char> action = delegate(char c2)
			{
				if (w != null)
				{
					w.Write(c2);
				}
				int num3 = writeCount + 1;
				writeCount = num3;
			};
			int num = 0;
			int num2 = src.Length - 1;
			while (num < num2)
			{
				if (src[num] == '\\')
				{
					char c = src[num + 1];
					switch (c)
					{
					case '"':
					case '/':
					case '\\':
						action(c);
						num += 2;
						continue;
					case 'b':
						action('\b');
						num += 2;
						continue;
					case 'f':
						action('\f');
						num += 2;
						continue;
					case 'n':
						action('\n');
						num += 2;
						continue;
					case 'r':
						action('\r');
						num += 2;
						continue;
					case 't':
						action('\t');
						num += 2;
						continue;
					}
				}
				action(src[num]);
				num++;
			}
			while (num <= num2)
			{
				action(src[num++]);
			}
			return writeCount;
		}

		public static int Unescape(Utf8String s, IStore w)
		{
			int writeCount = 0;
			Action<byte> action = delegate(byte c)
			{
				if (w != null)
				{
					w.Write(c);
				}
				int num = writeCount + 1;
				writeCount = num;
			};
			Utf8Iterator iterator = s.GetIterator();
			while (iterator.MoveNext())
			{
				switch (iterator.CurrentByteLength)
				{
				case 1:
					if (iterator.Current == 92)
					{
						byte second = iterator.Second;
						switch (second)
						{
						case 34:
						case 47:
						case 92:
							action(second);
							iterator.MoveNext();
							goto end_IL_0038;
						case 98:
							action(8);
							iterator.MoveNext();
							goto end_IL_0038;
						case 102:
							action(12);
							iterator.MoveNext();
							goto end_IL_0038;
						case 110:
							action(10);
							iterator.MoveNext();
							goto end_IL_0038;
						case 114:
							action(13);
							iterator.MoveNext();
							goto end_IL_0038;
						case 116:
							action(9);
							iterator.MoveNext();
							goto end_IL_0038;
						}
					}
					action(iterator.Current);
					break;
				case 2:
					action(iterator.Current);
					action(iterator.Second);
					break;
				case 3:
					action(iterator.Current);
					action(iterator.Second);
					action(iterator.Third);
					break;
				case 4:
					action(iterator.Current);
					action(iterator.Second);
					action(iterator.Third);
					action(iterator.Fourth);
					break;
				default:
					{
						throw new ParserException("invalid utf8");
					}
					end_IL_0038:
					break;
				}
			}
			return writeCount;
		}

		public static string Unescape(string src)
		{
			StringBuilder stringBuilder = new StringBuilder();
			Unescape(src, new StringBuilderStore(stringBuilder));
			return stringBuilder.ToString();
		}

		public static int Unquote(string src, IStore w)
		{
			return Unescape(src.Substring(1, src.Length - 2), w);
		}

		public static int Unquote(Utf8String src, IStore w)
		{
			return Unescape(src.Subbytes(1, src.ByteLength - 2), w);
		}

		public static string Unquote(string src)
		{
			int num = Unquote(src, null);
			if (num == src.Length - 2)
			{
				return src.Substring(1, src.Length - 2);
			}
			StringBuilder stringBuilder = new StringBuilder(num);
			Unquote(src, new StringBuilderStore(stringBuilder));
			return stringBuilder.ToString();
		}

		public static Utf8String Unquote(Utf8String src)
		{
			int num = Unquote(src, null);
			if (num == src.ByteLength - 2)
			{
				return src.Subbytes(1, src.ByteLength - 2);
			}
			BytesStore bytesStore = new BytesStore(num);
			Unquote(src, bytesStore);
			return new Utf8String(bytesStore.Bytes);
		}
	}
}
