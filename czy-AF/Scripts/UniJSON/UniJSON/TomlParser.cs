using System;
using System.Collections.Generic;

namespace UniJSON
{
	public static class TomlParser
	{
		private static TomlValue ParseLHS(Utf8String segment, int parentIndex)
		{
			Utf8Iterator iterator = segment.GetIterator();
			while (iterator.MoveNext())
			{
				if (iterator.Current == 34)
				{
					throw new NotImplementedException();
				}
				if (iterator.Current == 46)
				{
					throw new NotImplementedException();
				}
				if (iterator.Current == 32 || iterator.Current == 9 || iterator.Current == 61)
				{
					return new TomlValue(segment.Subbytes(0, iterator.BytePosition), TomlValueType.BareKey, parentIndex);
				}
			}
			throw new NotImplementedException();
		}

		private static TomlValue ParseRHS(Utf8String segment, int parentIndex)
		{
			switch ((char)segment[0])
			{
			case '+':
			case '-':
			case '0':
			case '1':
			case '2':
			case '3':
			case '4':
			case '5':
			case '6':
			case '7':
			case '8':
			case '9':
				if (segment.IsInt)
				{
					return new TomlValue(segment.SplitInteger(), TomlValueType.Integer, parentIndex);
				}
				return new TomlValue(segment, TomlValueType.Float, parentIndex);
			case '"':
			{
				if (segment.TrySearchAscii(34, 1, out var pos))
				{
					return new TomlValue(segment.Subbytes(0, pos + 1), TomlValueType.BasicString, parentIndex);
				}
				Utf8String utf8String = segment;
				throw new ParserException("no close string: " + utf8String.ToString());
			}
			case '[':
				throw new NotImplementedException();
			default:
				throw new NotImplementedException();
			}
		}

		public static ListTreeNode<TomlValue> Parse(Utf8String segment)
		{
			List<TomlValue> list = new List<TomlValue>
			{
				new TomlValue(segment, TomlValueType.Table, -1)
			};
			int parentIndex = 0;
			while (!segment.IsEmpty)
			{
				segment = segment.TrimStart();
				if (segment.IsEmpty)
				{
					break;
				}
				if (segment[0] == 35)
				{
					segment = segment.Subbytes(segment.GetLine().ByteLength);
					continue;
				}
				if (segment.ByteLength >= 4 && segment[0] == 91 && segment[1] == 91)
				{
					throw new NotImplementedException();
				}
				if (segment.ByteLength >= 2 && segment[0] == 91)
				{
					if (!segment.TrySearchByte((byte x) => x == 93, out var pos))
					{
						throw new ParserException("] not found");
					}
					Utf8String segment2 = segment.Subbytes(1, pos - 1).Trim();
					if (segment2.IsEmpty)
					{
						throw new ParserException("empty table name");
					}
					list.Add(new TomlValue(segment2, TomlValueType.Table, 0));
					parentIndex = list.Count - 1;
					segment = segment.Subbytes(segment.GetLine().ByteLength);
					continue;
				}
				TomlValue item = ParseLHS(segment, parentIndex);
				switch (item.TomlValueType)
				{
				case TomlValueType.BareKey:
				case TomlValueType.QuotedKey:
					list.Add(item);
					segment = segment.Subbytes(item.Bytes.Count);
					break;
				case TomlValueType.DottedKey:
					throw new NotImplementedException();
				}
				if (!segment.TrySearchByte((byte x) => x == 61, out var pos2))
				{
					throw new ParserException("= not found");
				}
				segment = segment.Subbytes(pos2 + 1);
				segment = segment.TrimStart();
				TomlValue item2 = ParseRHS(segment, parentIndex);
				list.Add(item2);
				segment = segment.Subbytes(item2.Bytes.Count);
				segment = segment.Subbytes(segment.GetLine().ByteLength);
			}
			return new ListTreeNode<TomlValue>(list);
		}

		public static ListTreeNode<TomlValue> Parse(string Toml)
		{
			return Parse(Utf8String.From(Toml));
		}
	}
}
