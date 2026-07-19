using System;

namespace UniJSON
{
	public static class JsonParser
	{
		private static ValueNodeType GetValueType(Utf8String segment)
		{
			switch (char.ToLower((char)segment[0]))
			{
			case '{':
				return ValueNodeType.Object;
			case '[':
				return ValueNodeType.Array;
			case '"':
				return ValueNodeType.String;
			case 't':
				return ValueNodeType.Boolean;
			case 'f':
				return ValueNodeType.Boolean;
			case 'n':
				if (segment.ByteLength >= 2 && char.ToLower((char)segment[1]) == 'a')
				{
					return ValueNodeType.NaN;
				}
				return ValueNodeType.Null;
			case 'i':
				return ValueNodeType.Infinity;
			case '-':
				if (segment.ByteLength >= 2 && char.ToLower((char)segment[1]) == 'i')
				{
					return ValueNodeType.MinusInfinity;
				}
				goto case '0';
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
					return ValueNodeType.Integer;
				}
				return ValueNodeType.Number;
			default:
			{
				Utf8String utf8String = segment;
				throw new ParserException(utf8String.ToString() + " is not valid json start");
			}
			}
		}

		private static ListTreeNode<JsonValue> ParsePrimitive(ListTreeNode<JsonValue> tree, Utf8String segment, ValueNodeType valueType)
		{
			int i;
			for (i = 1; i < segment.ByteLength && !char.IsWhiteSpace((char)segment[i]) && segment[i] != 125 && segment[i] != 93 && segment[i] != 44 && segment[i] != 58; i++)
			{
			}
			return tree.AddValue(segment.Subbytes(0, i).Bytes, valueType);
		}

		private static ListTreeNode<JsonValue> ParseString(ListTreeNode<JsonValue> tree, Utf8String segment)
		{
			if (segment.TrySearchAscii(34, 1, out var pos))
			{
				return tree.AddValue(segment.Subbytes(0, pos + 1).Bytes, ValueNodeType.String);
			}
			Utf8String utf8String = segment;
			throw new ParserException("no close string: " + utf8String.ToString());
		}

		private static ListTreeNode<JsonValue> ParseArray(ListTreeNode<JsonValue> tree, Utf8String segment)
		{
			ListTreeNode<JsonValue> listTreeNode = tree.AddValue(segment.Bytes, ValueNodeType.Array);
			char c = ']';
			bool flag = true;
			Utf8String src = segment.Subbytes(1);
			while (true)
			{
				if (!src.TrySearchByte((byte x) => !char.IsWhiteSpace((char)x), out var pos))
				{
					throw new ParserException("no white space expected");
				}
				src = src.Subbytes(pos);
				if (src[0] == c)
				{
					break;
				}
				if (flag)
				{
					flag = false;
				}
				else
				{
					if (!src.TrySearchByte((byte x) => x == 44, out var pos2))
					{
						throw new ParserException("',' expected");
					}
					src = src.Subbytes(pos2 + 1);
				}
				if (!src.TrySearchByte((byte x) => !char.IsWhiteSpace((char)x), out var pos3))
				{
					throw new ParserException("not whitespace expected");
				}
				src = src.Subbytes(pos3);
				src = src.Subbytes(Parse(listTreeNode, src).Value.Segment.ByteLength);
			}
			ArraySegment<byte> bytes = src.Bytes;
			int num = bytes.Offset + 1;
			bytes = segment.Bytes;
			int valueBytesCount = num - bytes.Offset;
			listTreeNode.SetValueBytesCount(valueBytesCount);
			return listTreeNode;
		}

		private static ListTreeNode<JsonValue> ParseObject(ListTreeNode<JsonValue> tree, Utf8String segment)
		{
			ListTreeNode<JsonValue> listTreeNode = tree.AddValue(segment.Bytes, ValueNodeType.Object);
			char c = '}';
			bool flag = true;
			Utf8String src = segment.Subbytes(1);
			while (true)
			{
				if (!src.TrySearchByte((byte x) => !char.IsWhiteSpace((char)x), out var pos))
				{
					throw new ParserException("no white space expected");
				}
				src = src.Subbytes(pos);
				if (src[0] == c)
				{
					break;
				}
				if (flag)
				{
					flag = false;
				}
				else
				{
					if (!src.TrySearchByte((byte x) => x == 44, out var pos2))
					{
						throw new ParserException("',' expected");
					}
					src = src.Subbytes(pos2 + 1);
				}
				if (!src.TrySearchByte((byte x) => !char.IsWhiteSpace((char)x), out var pos3))
				{
					throw new ParserException("not whitespace expected");
				}
				src = src.Subbytes(pos3);
				ListTreeNode<JsonValue> self = Parse(listTreeNode, src);
				if (!self.IsString())
				{
					throw new ParserException("object key must string: " + self.Value.Segment.ToString());
				}
				src = src.Subbytes(self.Value.Segment.ByteLength);
				if (!src.TrySearchByte((byte x) => x == 58, out var pos4))
				{
					throw new ParserException(": is not found");
				}
				src = src.Subbytes(pos4 + 1);
				if (!src.TrySearchByte((byte x) => !char.IsWhiteSpace((char)x), out var pos5))
				{
					throw new ParserException("not whitespace expected");
				}
				src = src.Subbytes(pos5);
				src = src.Subbytes(Parse(listTreeNode, src).Value.Segment.ByteLength);
			}
			ArraySegment<byte> bytes = src.Bytes;
			int num = bytes.Offset + 1;
			bytes = segment.Bytes;
			int valueBytesCount = num - bytes.Offset;
			listTreeNode.SetValueBytesCount(valueBytesCount);
			return listTreeNode;
		}

		public static ListTreeNode<JsonValue> Parse(ListTreeNode<JsonValue> tree, Utf8String segment)
		{
			if (!segment.TrySearchByte((byte x) => !char.IsWhiteSpace((char)x), out var pos))
			{
				throw new ParserException("only whitespace");
			}
			segment = segment.Subbytes(pos);
			ValueNodeType valueType = GetValueType(segment);
			switch (valueType)
			{
			case ValueNodeType.Null:
			case ValueNodeType.Boolean:
			case ValueNodeType.Integer:
			case ValueNodeType.Number:
			case ValueNodeType.NaN:
			case ValueNodeType.Infinity:
			case ValueNodeType.MinusInfinity:
				return ParsePrimitive(tree, segment, valueType);
			case ValueNodeType.String:
				return ParseString(tree, segment);
			case ValueNodeType.Array:
				return ParseArray(tree, segment);
			case ValueNodeType.Object:
				return ParseObject(tree, segment);
			default:
				throw new NotImplementedException();
			}
		}

		public static ListTreeNode<JsonValue> Parse(string json)
		{
			return Parse(Utf8String.From(json));
		}

		public static ListTreeNode<JsonValue> Parse(Utf8String json)
		{
			return Parse(default(ListTreeNode<JsonValue>), json);
		}
	}
}
