using System;

namespace UniJSON
{
	public struct JsonValue : IListTreeItem, IValue<JsonValue>
	{
		public Utf8String Segment;

		private int _childCount;

		private static Utf8String s_true = Utf8String.From("true");

		private static Utf8String s_false = Utf8String.From("false");

		public ArraySegment<byte> Bytes => Segment.Bytes;

		public ValueNodeType ValueType { get; private set; }

		public int ParentIndex { get; private set; }

		public int ChildCount => _childCount;

		public void SetBytesCount(int count)
		{
			Segment = new Utf8String(new ArraySegment<byte>(Bytes.Array, Bytes.Offset, count));
		}

		public void SetChildCount(int count)
		{
			_childCount = count;
		}

		public JsonValue(Utf8String segment, ValueNodeType valueType, int parentIndex)
		{
			this = default(JsonValue);
			Segment = segment;
			ValueType = valueType;
			ParentIndex = parentIndex;
		}

		public JsonValue New(ArraySegment<byte> bytes, ValueNodeType valueType, int parentIndex)
		{
			return new JsonValue(new Utf8String(bytes), valueType, parentIndex);
		}

		public JsonValue Key(Utf8String key, int parentIndex)
		{
			return new JsonValue(JsonString.Quote(key), ValueNodeType.String, parentIndex);
		}

		public override string ToString()
		{
			ValueNodeType valueType = ValueType;
			if ((uint)valueType <= 2u || (uint)(valueType - 4) <= 6u)
			{
				return Segment.ToString();
			}
			throw new NotImplementedException();
		}

		public bool GetBoolean()
		{
			if (Segment == s_true)
			{
				return true;
			}
			if (Segment == s_false)
			{
				return false;
			}
			throw new DeserializationException("invalid boolean: " + Segment.ToString());
		}

		public sbyte GetSByte()
		{
			return Segment.ToSByte();
		}

		public short GetInt16()
		{
			return Segment.ToInt16();
		}

		public int GetInt32()
		{
			return Segment.ToInt32();
		}

		public long GetInt64()
		{
			return Segment.ToInt64();
		}

		public byte GetByte()
		{
			return Segment.ToByte();
		}

		public ushort GetUInt16()
		{
			return Segment.ToUInt16();
		}

		public uint GetUInt32()
		{
			return Segment.ToUInt32();
		}

		public ulong GetUInt64()
		{
			return Segment.ToUInt64();
		}

		public float GetSingle()
		{
			return Segment.ToSingle();
		}

		public double GetDouble()
		{
			return Segment.ToDouble();
		}

		public string GetString()
		{
			return JsonString.Unquote(Segment.ToString());
		}

		public Utf8String GetUtf8String()
		{
			return JsonString.Unquote(Segment);
		}

		public T GetValue<T>()
		{
			switch (ValueType)
			{
			case ValueNodeType.Null:
				return GenericCast<object, T>.Null();
			case ValueNodeType.Boolean:
				return GenericCast<bool, T>.Cast(GetBoolean());
			case ValueNodeType.Integer:
				return GenericCast<int, T>.Cast(GetInt32());
			case ValueNodeType.Number:
			case ValueNodeType.NaN:
			case ValueNodeType.Infinity:
			case ValueNodeType.MinusInfinity:
				return GenericCast<double, T>.Cast(GetDouble());
			case ValueNodeType.String:
				return GenericCast<string, T>.Cast(GetString());
			default:
				throw new NotImplementedException();
			}
		}
	}
}
