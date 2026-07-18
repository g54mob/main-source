using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using UnityEngine;

namespace SimpleJSON
{
	public abstract class JSONNode
	{
		public struct Enumerator
		{
			private enum Type
			{
				None = 0,
				Array = 1,
				Object = 2
			}

			private Type type;

			private Dictionary<string, JSONNode>.Enumerator m_Object;

			private List<JSONNode>.Enumerator m_Array;

			public bool IsValid => type != Type.None;

			public KeyValuePair<string, JSONNode> Current
			{
				get
				{
					if (type == Type.Array)
					{
						return new KeyValuePair<string, JSONNode>(string.Empty, m_Array.Current);
					}
					if (type == Type.Object)
					{
						return m_Object.Current;
					}
					return new KeyValuePair<string, JSONNode>(string.Empty, null);
				}
			}

			public Enumerator(List<JSONNode>.Enumerator aArrayEnum)
			{
				type = Type.Array;
				m_Object = default(Dictionary<string, JSONNode>.Enumerator);
				m_Array = aArrayEnum;
			}

			public Enumerator(Dictionary<string, JSONNode>.Enumerator aDictEnum)
			{
				type = Type.Object;
				m_Object = aDictEnum;
				m_Array = default(List<JSONNode>.Enumerator);
			}

			public bool MoveNext()
			{
				if (type == Type.Array)
				{
					return m_Array.MoveNext();
				}
				if (type == Type.Object)
				{
					return m_Object.MoveNext();
				}
				return false;
			}
		}

		public struct ValueEnumerator
		{
			private Enumerator m_Enumerator;

			public JSONNode Current => m_Enumerator.Current.Value;

			public ValueEnumerator(List<JSONNode>.Enumerator aArrayEnum)
				: this(new Enumerator(aArrayEnum))
			{
			}

			public ValueEnumerator(Dictionary<string, JSONNode>.Enumerator aDictEnum)
				: this(new Enumerator(aDictEnum))
			{
			}

			public ValueEnumerator(Enumerator aEnumerator)
			{
				m_Enumerator = aEnumerator;
			}

			public bool MoveNext()
			{
				return m_Enumerator.MoveNext();
			}

			public ValueEnumerator GetEnumerator()
			{
				return this;
			}
		}

		public struct KeyEnumerator
		{
			private Enumerator m_Enumerator;

			public string Current => m_Enumerator.Current.Key;

			public KeyEnumerator(List<JSONNode>.Enumerator aArrayEnum)
				: this(new Enumerator(aArrayEnum))
			{
			}

			public KeyEnumerator(Dictionary<string, JSONNode>.Enumerator aDictEnum)
				: this(new Enumerator(aDictEnum))
			{
			}

			public KeyEnumerator(Enumerator aEnumerator)
			{
				m_Enumerator = aEnumerator;
			}

			public bool MoveNext()
			{
				return m_Enumerator.MoveNext();
			}

			public KeyEnumerator GetEnumerator()
			{
				return this;
			}
		}

		public class LinqEnumerator : IEnumerator<KeyValuePair<string, JSONNode>>, IEnumerator, IDisposable, IEnumerable<KeyValuePair<string, JSONNode>>, IEnumerable
		{
			private JSONNode m_Node;

			private Enumerator m_Enumerator;

			public KeyValuePair<string, JSONNode> Current => m_Enumerator.Current;

			object IEnumerator.Current => m_Enumerator.Current;

			internal LinqEnumerator(JSONNode aNode)
			{
				m_Node = aNode;
				if (m_Node != null)
				{
					m_Enumerator = m_Node.GetEnumerator();
				}
			}

			public bool MoveNext()
			{
				return m_Enumerator.MoveNext();
			}

			public void Dispose()
			{
				m_Node = null;
				m_Enumerator = default(Enumerator);
			}

			public IEnumerator<KeyValuePair<string, JSONNode>> GetEnumerator()
			{
				return new LinqEnumerator(m_Node);
			}

			public void Reset()
			{
				if (m_Node != null)
				{
					m_Enumerator = m_Node.GetEnumerator();
				}
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				return new LinqEnumerator(m_Node);
			}
		}

		public static bool forceASCII = false;

		public static bool longAsString = false;

		public static bool allowLineComments = true;

		[ThreadStatic]
		private static StringBuilder m_EscapeBuilder;

		public static byte Color32DefaultAlpha = byte.MaxValue;

		public static float ColorDefaultAlpha = 1f;

		public static JSONContainerType VectorContainerType = JSONContainerType.Array;

		public static JSONContainerType QuaternionContainerType = JSONContainerType.Array;

		public static JSONContainerType RectContainerType = JSONContainerType.Array;

		public static JSONContainerType ColorContainerType = JSONContainerType.Array;

		public abstract JSONNodeType Tag { get; }

		public virtual JSONNode this[int aIndex]
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public virtual JSONNode this[string aKey]
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public virtual string Value
		{
			get
			{
				return "";
			}
			set
			{
			}
		}

		public virtual int Count => 0;

		public virtual bool IsNumber => false;

		public virtual bool IsString => false;

		public virtual bool IsBoolean => false;

		public virtual bool IsNull => false;

		public virtual bool IsArray => false;

		public virtual bool IsObject => false;

		public virtual bool Inline
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public virtual IEnumerable<JSONNode> Children
		{
			get
			{
				yield break;
			}
		}

		public IEnumerable<JSONNode> DeepChildren
		{
			get
			{
				foreach (JSONNode child in Children)
				{
					foreach (JSONNode deepChild in child.DeepChildren)
					{
						yield return deepChild;
					}
				}
			}
		}

		public IEnumerable<KeyValuePair<string, JSONNode>> Linq => new LinqEnumerator(this);

		public KeyEnumerator Keys => new KeyEnumerator(GetEnumerator());

		public ValueEnumerator Values => new ValueEnumerator(GetEnumerator());

		public virtual double AsDouble
		{
			get
			{
				double result = 0.0;
				if (double.TryParse(Value, NumberStyles.Float, CultureInfo.InvariantCulture, out result))
				{
					return result;
				}
				return 0.0;
			}
			set
			{
				Value = value.ToString(CultureInfo.InvariantCulture);
			}
		}

		public virtual int AsInt
		{
			get
			{
				return (int)AsDouble;
			}
			set
			{
				AsDouble = value;
			}
		}

		public virtual float AsFloat
		{
			get
			{
				return (float)AsDouble;
			}
			set
			{
				AsDouble = value;
			}
		}

		public virtual bool AsBool
		{
			get
			{
				bool result = false;
				if (bool.TryParse(Value, out result))
				{
					return result;
				}
				return !string.IsNullOrEmpty(Value);
			}
			set
			{
				Value = (value ? "true" : "false");
			}
		}

		public virtual long AsLong
		{
			get
			{
				long result = 0L;
				if (long.TryParse(Value, out result))
				{
					return result;
				}
				return 0L;
			}
			set
			{
				Value = value.ToString();
			}
		}

		public virtual ulong AsULong
		{
			get
			{
				ulong result = 0uL;
				if (ulong.TryParse(Value, out result))
				{
					return result;
				}
				return 0uL;
			}
			set
			{
				Value = value.ToString();
			}
		}

		public virtual JSONArray AsArray => this as JSONArray;

		public virtual JSONObject AsObject => this as JSONObject;

		internal static StringBuilder EscapeBuilder
		{
			get
			{
				if (m_EscapeBuilder == null)
				{
					m_EscapeBuilder = new StringBuilder();
				}
				return m_EscapeBuilder;
			}
		}

		public virtual decimal AsDecimal
		{
			get
			{
				if (!decimal.TryParse(Value, out var result))
				{
					result = default(decimal);
				}
				return result;
			}
			set
			{
				Value = value.ToString();
			}
		}

		public virtual char AsChar
		{
			get
			{
				if (IsString && Value.Length > 0)
				{
					return Value[0];
				}
				if (IsNumber)
				{
					return (char)AsInt;
				}
				return '\0';
			}
			set
			{
				if (IsString)
				{
					Value = value.ToString();
				}
				else if (IsNumber)
				{
					AsInt = value;
				}
			}
		}

		public virtual uint AsUInt
		{
			get
			{
				return (uint)AsDouble;
			}
			set
			{
				AsDouble = value;
			}
		}

		public virtual byte AsByte
		{
			get
			{
				return (byte)AsInt;
			}
			set
			{
				AsInt = value;
			}
		}

		public virtual sbyte AsSByte
		{
			get
			{
				return (sbyte)AsInt;
			}
			set
			{
				AsInt = value;
			}
		}

		public virtual short AsShort
		{
			get
			{
				return (short)AsInt;
			}
			set
			{
				AsInt = value;
			}
		}

		public virtual ushort AsUShort
		{
			get
			{
				return (ushort)AsInt;
			}
			set
			{
				AsInt = value;
			}
		}

		public virtual DateTime AsDateTime
		{
			get
			{
				if (!DateTime.TryParse(Value, CultureInfo.InvariantCulture, DateTimeStyles.None, out var result))
				{
					result = new DateTime(0L);
				}
				return result;
			}
			set
			{
				Value = value.ToString(CultureInfo.InvariantCulture);
			}
		}

		public virtual TimeSpan AsTimeSpan
		{
			get
			{
				if (!TimeSpan.TryParse(Value, CultureInfo.InvariantCulture, out var result))
				{
					result = new TimeSpan(0L);
				}
				return result;
			}
			set
			{
				Value = value.ToString();
			}
		}

		public virtual Guid AsGuid
		{
			get
			{
				Guid.TryParse(Value, out var result);
				return result;
			}
			set
			{
				Value = value.ToString();
			}
		}

		public virtual byte[] AsByteArray
		{
			get
			{
				if (IsNull || !IsArray)
				{
					return null;
				}
				int count = Count;
				byte[] array = new byte[count];
				for (int i = 0; i < count; i++)
				{
					array[i] = this[i].AsByte;
				}
				return array;
			}
			set
			{
				if (IsArray && value != null)
				{
					Clear();
					for (int i = 0; i < value.Length; i++)
					{
						Add(value[i]);
					}
				}
			}
		}

		public virtual List<byte> AsByteList
		{
			get
			{
				if (IsNull || !IsArray)
				{
					return null;
				}
				int count = Count;
				List<byte> list = new List<byte>(count);
				for (int i = 0; i < count; i++)
				{
					list.Add(this[i].AsByte);
				}
				return list;
			}
			set
			{
				if (IsArray && value != null)
				{
					Clear();
					for (int i = 0; i < value.Count; i++)
					{
						Add(value[i]);
					}
				}
			}
		}

		public virtual string[] AsStringArray
		{
			get
			{
				if (IsNull || !IsArray)
				{
					return null;
				}
				int count = Count;
				string[] array = new string[count];
				for (int i = 0; i < count; i++)
				{
					array[i] = this[i].Value;
				}
				return array;
			}
			set
			{
				if (IsArray && value != null)
				{
					Clear();
					for (int i = 0; i < value.Length; i++)
					{
						Add(value[i]);
					}
				}
			}
		}

		public virtual List<string> AsStringList
		{
			get
			{
				if (IsNull || !IsArray)
				{
					return null;
				}
				int count = Count;
				List<string> list = new List<string>(count);
				for (int i = 0; i < count; i++)
				{
					list.Add(this[i].Value);
				}
				return list;
			}
			set
			{
				if (IsArray && value != null)
				{
					Clear();
					for (int i = 0; i < value.Count; i++)
					{
						Add(value[i]);
					}
				}
			}
		}

		public virtual void Add(string aKey, JSONNode aItem)
		{
		}

		public virtual void Add(JSONNode aItem)
		{
			Add("", aItem);
		}

		public virtual JSONNode Remove(string aKey)
		{
			return null;
		}

		public virtual JSONNode Remove(int aIndex)
		{
			return null;
		}

		public virtual JSONNode Remove(JSONNode aNode)
		{
			return aNode;
		}

		public virtual void Clear()
		{
		}

		public virtual JSONNode Clone()
		{
			return null;
		}

		public virtual bool HasKey(string aKey)
		{
			return false;
		}

		public virtual JSONNode GetValueOrDefault(string aKey, JSONNode aDefault)
		{
			return aDefault;
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			WriteToStringBuilder(stringBuilder, 0, 0, JSONTextMode.Compact);
			return stringBuilder.ToString();
		}

		public virtual string ToString(int aIndent)
		{
			StringBuilder stringBuilder = new StringBuilder();
			WriteToStringBuilder(stringBuilder, 0, aIndent, JSONTextMode.Indent);
			return stringBuilder.ToString();
		}

		internal abstract void WriteToStringBuilder(StringBuilder aSB, int aIndent, int aIndentInc, JSONTextMode aMode);

		public abstract Enumerator GetEnumerator();

		public static implicit operator JSONNode(string s)
		{
			if (s != null)
			{
				return new JSONString(s);
			}
			return JSONNull.CreateOrGet();
		}

		public static implicit operator string(JSONNode d)
		{
			if (!(d == null))
			{
				return d.Value;
			}
			return null;
		}

		public static implicit operator JSONNode(double n)
		{
			return new JSONNumber(n);
		}

		public static implicit operator double(JSONNode d)
		{
			if (!(d == null))
			{
				return d.AsDouble;
			}
			return 0.0;
		}

		public static implicit operator JSONNode(float n)
		{
			return new JSONNumber(n);
		}

		public static implicit operator float(JSONNode d)
		{
			if (!(d == null))
			{
				return d.AsFloat;
			}
			return 0f;
		}

		public static implicit operator JSONNode(int n)
		{
			return new JSONNumber(n);
		}

		public static implicit operator int(JSONNode d)
		{
			if (!(d == null))
			{
				return d.AsInt;
			}
			return 0;
		}

		public static implicit operator JSONNode(long n)
		{
			if (longAsString)
			{
				return new JSONString(n.ToString());
			}
			return new JSONNumber(n);
		}

		public static implicit operator long(JSONNode d)
		{
			if (!(d == null))
			{
				return d.AsLong;
			}
			return 0L;
		}

		public static implicit operator JSONNode(ulong n)
		{
			if (longAsString)
			{
				return new JSONString(n.ToString());
			}
			return new JSONNumber(n);
		}

		public static implicit operator ulong(JSONNode d)
		{
			if (!(d == null))
			{
				return d.AsULong;
			}
			return 0uL;
		}

		public static implicit operator JSONNode(bool b)
		{
			return new JSONBool(b);
		}

		public static implicit operator bool(JSONNode d)
		{
			if (!(d == null))
			{
				return d.AsBool;
			}
			return false;
		}

		public static implicit operator JSONNode(KeyValuePair<string, JSONNode> aKeyValue)
		{
			return aKeyValue.Value;
		}

		public static bool operator ==(JSONNode a, object b)
		{
			if ((object)a == b)
			{
				return true;
			}
			bool flag = a is JSONNull || (object)a == null || a is JSONLazyCreator;
			bool flag2 = b is JSONNull || b == null || b is JSONLazyCreator;
			if (flag && flag2)
			{
				return true;
			}
			if (!flag)
			{
				return a.Equals(b);
			}
			return false;
		}

		public static bool operator !=(JSONNode a, object b)
		{
			return !(a == b);
		}

		public override bool Equals(object obj)
		{
			return (object)this == obj;
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		internal static string Escape(string aText)
		{
			StringBuilder escapeBuilder = EscapeBuilder;
			escapeBuilder.Length = 0;
			if (escapeBuilder.Capacity < aText.Length + aText.Length / 10)
			{
				escapeBuilder.Capacity = aText.Length + aText.Length / 10;
			}
			foreach (char c in aText)
			{
				switch (c)
				{
				case '\\':
					escapeBuilder.Append("\\\\");
					continue;
				case '"':
					escapeBuilder.Append("\\\"");
					continue;
				case '\n':
					escapeBuilder.Append("\\n");
					continue;
				case '\r':
					escapeBuilder.Append("\\r");
					continue;
				case '\t':
					escapeBuilder.Append("\\t");
					continue;
				case '\b':
					escapeBuilder.Append("\\b");
					continue;
				case '\f':
					escapeBuilder.Append("\\f");
					continue;
				}
				if (c < ' ' || (forceASCII && c > '\u007f'))
				{
					ushort num = c;
					escapeBuilder.Append("\\u").Append(num.ToString("X4"));
				}
				else
				{
					escapeBuilder.Append(c);
				}
			}
			string result = escapeBuilder.ToString();
			escapeBuilder.Length = 0;
			return result;
		}

		private static JSONNode ParseElement(string token, bool quoted)
		{
			if (quoted)
			{
				return token;
			}
			if (token.Length <= 5)
			{
				string text = token.ToLower();
				switch (text)
				{
				case "false":
				case "true":
					return text == "true";
				case "null":
					return JSONNull.CreateOrGet();
				}
			}
			if (double.TryParse(token, NumberStyles.Float, CultureInfo.InvariantCulture, out var result))
			{
				return result;
			}
			return token;
		}

		public static JSONNode Parse(string aJSON)
		{
			Stack<JSONNode> stack = new Stack<JSONNode>();
			JSONNode jSONNode = null;
			int i = 0;
			StringBuilder stringBuilder = new StringBuilder();
			string aKey = "";
			bool flag = false;
			bool flag2 = false;
			bool flag3 = false;
			for (; i < aJSON.Length; i++)
			{
				switch (aJSON[i])
				{
				case '{':
					if (flag)
					{
						stringBuilder.Append(aJSON[i]);
						break;
					}
					stack.Push(new JSONObject());
					if (jSONNode != null)
					{
						jSONNode.Add(aKey, stack.Peek());
					}
					aKey = "";
					stringBuilder.Length = 0;
					jSONNode = stack.Peek();
					flag3 = false;
					break;
				case '[':
					if (flag)
					{
						stringBuilder.Append(aJSON[i]);
						break;
					}
					stack.Push(new JSONArray());
					if (jSONNode != null)
					{
						jSONNode.Add(aKey, stack.Peek());
					}
					aKey = "";
					stringBuilder.Length = 0;
					jSONNode = stack.Peek();
					flag3 = false;
					break;
				case ']':
				case '}':
					if (flag)
					{
						stringBuilder.Append(aJSON[i]);
						break;
					}
					if (stack.Count == 0)
					{
						throw new Exception("JSON Parse: Too many closing brackets");
					}
					stack.Pop();
					if (stringBuilder.Length > 0 || flag2)
					{
						jSONNode.Add(aKey, ParseElement(stringBuilder.ToString(), flag2));
					}
					if (jSONNode != null)
					{
						jSONNode.Inline = !flag3;
					}
					flag2 = false;
					aKey = "";
					stringBuilder.Length = 0;
					if (stack.Count > 0)
					{
						jSONNode = stack.Peek();
					}
					break;
				case ':':
					if (flag)
					{
						stringBuilder.Append(aJSON[i]);
						break;
					}
					aKey = stringBuilder.ToString();
					stringBuilder.Length = 0;
					flag2 = false;
					break;
				case '"':
					flag = !flag;
					flag2 = flag2 || flag;
					break;
				case ',':
					if (flag)
					{
						stringBuilder.Append(aJSON[i]);
						break;
					}
					if (stringBuilder.Length > 0 || flag2)
					{
						jSONNode.Add(aKey, ParseElement(stringBuilder.ToString(), flag2));
					}
					flag2 = false;
					aKey = "";
					stringBuilder.Length = 0;
					flag2 = false;
					break;
				case '\n':
				case '\r':
					flag3 = true;
					break;
				case '\t':
				case ' ':
					if (flag)
					{
						stringBuilder.Append(aJSON[i]);
					}
					break;
				case '\\':
					i++;
					if (flag)
					{
						char c = aJSON[i];
						switch (c)
						{
						case 't':
							stringBuilder.Append('\t');
							break;
						case 'r':
							stringBuilder.Append('\r');
							break;
						case 'n':
							stringBuilder.Append('\n');
							break;
						case 'b':
							stringBuilder.Append('\b');
							break;
						case 'f':
							stringBuilder.Append('\f');
							break;
						case 'u':
						{
							string s = aJSON.Substring(i + 1, 4);
							stringBuilder.Append((char)int.Parse(s, NumberStyles.AllowHexSpecifier));
							i += 4;
							break;
						}
						default:
							stringBuilder.Append(c);
							break;
						}
					}
					break;
				case '/':
					if (allowLineComments && !flag && i + 1 < aJSON.Length && aJSON[i + 1] == '/')
					{
						while (++i < aJSON.Length && aJSON[i] != '\n' && aJSON[i] != '\r')
						{
						}
					}
					else
					{
						stringBuilder.Append(aJSON[i]);
					}
					break;
				default:
					stringBuilder.Append(aJSON[i]);
					break;
				case '\ufeff':
					break;
				}
			}
			if (flag)
			{
				throw new Exception("JSON Parse: Quotation marks seems to be messed up.");
			}
			if (jSONNode == null)
			{
				return ParseElement(stringBuilder.ToString(), flag2);
			}
			return jSONNode;
		}

		public abstract void SerializeBinary(BinaryWriter aWriter);

		public void SaveToBinaryStream(Stream aData)
		{
			BinaryWriter aWriter = new BinaryWriter(aData);
			SerializeBinary(aWriter);
		}

		public void SaveToCompressedStream(Stream aData)
		{
			throw new Exception("Can't use compressed functions. You need include the SharpZipLib and uncomment the define at the top of SimpleJSON");
		}

		public void SaveToCompressedFile(string aFileName)
		{
			throw new Exception("Can't use compressed functions. You need include the SharpZipLib and uncomment the define at the top of SimpleJSON");
		}

		public string SaveToCompressedBase64()
		{
			throw new Exception("Can't use compressed functions. You need include the SharpZipLib and uncomment the define at the top of SimpleJSON");
		}

		public void SaveToBinaryFile(string aFileName)
		{
			Directory.CreateDirectory(new FileInfo(aFileName).Directory.FullName);
			using FileStream aData = File.OpenWrite(aFileName);
			SaveToBinaryStream(aData);
		}

		public string SaveToBinaryBase64()
		{
			using MemoryStream memoryStream = new MemoryStream();
			SaveToBinaryStream(memoryStream);
			memoryStream.Position = 0L;
			return Convert.ToBase64String(memoryStream.ToArray());
		}

		public static JSONNode DeserializeBinary(BinaryReader aReader)
		{
			JSONNodeType jSONNodeType = (JSONNodeType)aReader.ReadByte();
			switch (jSONNodeType)
			{
			case JSONNodeType.Array:
			{
				int num2 = aReader.ReadInt32();
				JSONArray jSONArray = new JSONArray();
				for (int j = 0; j < num2; j++)
				{
					jSONArray.Add(DeserializeBinary(aReader));
				}
				return jSONArray;
			}
			case JSONNodeType.Object:
			{
				int num = aReader.ReadInt32();
				JSONObject jSONObject = new JSONObject();
				for (int i = 0; i < num; i++)
				{
					string aKey = aReader.ReadString();
					JSONNode aItem = DeserializeBinary(aReader);
					jSONObject.Add(aKey, aItem);
				}
				return jSONObject;
			}
			case JSONNodeType.String:
				return new JSONString(aReader.ReadString());
			case JSONNodeType.Number:
				return new JSONNumber(aReader.ReadDouble());
			case JSONNodeType.Boolean:
				return new JSONBool(aReader.ReadBoolean());
			case JSONNodeType.NullValue:
				return JSONNull.CreateOrGet();
			default:
				throw new Exception("Error deserializing JSON. Unknown tag: " + jSONNodeType);
			}
		}

		public static JSONNode LoadFromCompressedFile(string aFileName)
		{
			throw new Exception("Can't use compressed functions. You need include the SharpZipLib and uncomment the define at the top of SimpleJSON");
		}

		public static JSONNode LoadFromCompressedStream(Stream aData)
		{
			throw new Exception("Can't use compressed functions. You need include the SharpZipLib and uncomment the define at the top of SimpleJSON");
		}

		public static JSONNode LoadFromCompressedBase64(string aBase64)
		{
			throw new Exception("Can't use compressed functions. You need include the SharpZipLib and uncomment the define at the top of SimpleJSON");
		}

		public static JSONNode LoadFromBinaryStream(Stream aData)
		{
			using BinaryReader aReader = new BinaryReader(aData);
			return DeserializeBinary(aReader);
		}

		public static JSONNode LoadFromBinaryFile(string aFileName)
		{
			using FileStream aData = File.OpenRead(aFileName);
			return LoadFromBinaryStream(aData);
		}

		public static JSONNode LoadFromBinaryBase64(string aBase64)
		{
			return LoadFromBinaryStream(new MemoryStream(Convert.FromBase64String(aBase64))
			{
				Position = 0L
			});
		}

		public static implicit operator JSONNode(decimal aDecimal)
		{
			return new JSONString(aDecimal.ToString());
		}

		public static implicit operator decimal(JSONNode aNode)
		{
			return aNode.AsDecimal;
		}

		public static implicit operator JSONNode(char aChar)
		{
			return new JSONString(aChar.ToString());
		}

		public static implicit operator char(JSONNode aNode)
		{
			return aNode.AsChar;
		}

		public static implicit operator JSONNode(uint aUInt)
		{
			return new JSONNumber(aUInt);
		}

		public static implicit operator uint(JSONNode aNode)
		{
			return aNode.AsUInt;
		}

		public static implicit operator JSONNode(byte aByte)
		{
			return new JSONNumber((int)aByte);
		}

		public static implicit operator byte(JSONNode aNode)
		{
			return aNode.AsByte;
		}

		public static implicit operator JSONNode(sbyte aSByte)
		{
			return new JSONNumber(aSByte);
		}

		public static implicit operator sbyte(JSONNode aNode)
		{
			return aNode.AsSByte;
		}

		public static implicit operator JSONNode(short aShort)
		{
			return new JSONNumber(aShort);
		}

		public static implicit operator short(JSONNode aNode)
		{
			return aNode.AsShort;
		}

		public static implicit operator JSONNode(ushort aUShort)
		{
			return new JSONNumber((int)aUShort);
		}

		public static implicit operator ushort(JSONNode aNode)
		{
			return aNode.AsUShort;
		}

		public static implicit operator JSONNode(DateTime aDateTime)
		{
			return new JSONString(aDateTime.ToString(CultureInfo.InvariantCulture));
		}

		public static implicit operator DateTime(JSONNode aNode)
		{
			return aNode.AsDateTime;
		}

		public static implicit operator JSONNode(TimeSpan aTimeSpan)
		{
			return new JSONString(aTimeSpan.ToString());
		}

		public static implicit operator TimeSpan(JSONNode aNode)
		{
			return aNode.AsTimeSpan;
		}

		public static implicit operator JSONNode(Guid aGuid)
		{
			return new JSONString(aGuid.ToString());
		}

		public static implicit operator Guid(JSONNode aNode)
		{
			return aNode.AsGuid;
		}

		public static implicit operator JSONNode(byte[] aByteArray)
		{
			return new JSONArray
			{
				AsByteArray = aByteArray
			};
		}

		public static implicit operator byte[](JSONNode aNode)
		{
			return aNode.AsByteArray;
		}

		public static implicit operator JSONNode(List<byte> aByteList)
		{
			return new JSONArray
			{
				AsByteList = aByteList
			};
		}

		public static implicit operator List<byte>(JSONNode aNode)
		{
			return aNode.AsByteList;
		}

		public static implicit operator JSONNode(string[] aStringArray)
		{
			return new JSONArray
			{
				AsStringArray = aStringArray
			};
		}

		public static implicit operator string[](JSONNode aNode)
		{
			return aNode.AsStringArray;
		}

		public static implicit operator JSONNode(List<string> aStringList)
		{
			return new JSONArray
			{
				AsStringList = aStringList
			};
		}

		public static implicit operator List<string>(JSONNode aNode)
		{
			return aNode.AsStringList;
		}

		public static implicit operator JSONNode(int? aValue)
		{
			if (!aValue.HasValue)
			{
				return JSONNull.CreateOrGet();
			}
			return new JSONNumber(aValue.Value);
		}

		public static implicit operator int?(JSONNode aNode)
		{
			if (aNode == null || aNode.IsNull)
			{
				return null;
			}
			return aNode.AsInt;
		}

		public static implicit operator JSONNode(float? aValue)
		{
			if (!aValue.HasValue)
			{
				return JSONNull.CreateOrGet();
			}
			return new JSONNumber(aValue.Value);
		}

		public static implicit operator float?(JSONNode aNode)
		{
			if (aNode == null || aNode.IsNull)
			{
				return null;
			}
			return aNode.AsFloat;
		}

		public static implicit operator JSONNode(double? aValue)
		{
			if (!aValue.HasValue)
			{
				return JSONNull.CreateOrGet();
			}
			return new JSONNumber(aValue.Value);
		}

		public static implicit operator double?(JSONNode aNode)
		{
			if (aNode == null || aNode.IsNull)
			{
				return null;
			}
			return aNode.AsDouble;
		}

		public static implicit operator JSONNode(bool? aValue)
		{
			if (!aValue.HasValue)
			{
				return JSONNull.CreateOrGet();
			}
			return new JSONBool(aValue.Value);
		}

		public static implicit operator bool?(JSONNode aNode)
		{
			if (aNode == null || aNode.IsNull)
			{
				return null;
			}
			return aNode.AsBool;
		}

		public static implicit operator JSONNode(long? aValue)
		{
			if (!aValue.HasValue)
			{
				return JSONNull.CreateOrGet();
			}
			return new JSONNumber(aValue.Value);
		}

		public static implicit operator long?(JSONNode aNode)
		{
			if (aNode == null || aNode.IsNull)
			{
				return null;
			}
			return aNode.AsLong;
		}

		public static implicit operator JSONNode(short? aValue)
		{
			if (!aValue.HasValue)
			{
				return JSONNull.CreateOrGet();
			}
			return new JSONNumber(aValue.Value);
		}

		public static implicit operator short?(JSONNode aNode)
		{
			if (aNode == null || aNode.IsNull)
			{
				return null;
			}
			return aNode.AsShort;
		}

		private static JSONNode GetContainer(JSONContainerType aType)
		{
			if (aType == JSONContainerType.Array)
			{
				return new JSONArray();
			}
			return new JSONObject();
		}

		public static implicit operator JSONNode(Vector2 aVec)
		{
			JSONNode container = GetContainer(VectorContainerType);
			container.WriteVector2(aVec);
			return container;
		}

		public static implicit operator JSONNode(Vector3 aVec)
		{
			JSONNode container = GetContainer(VectorContainerType);
			container.WriteVector3(aVec);
			return container;
		}

		public static implicit operator JSONNode(Vector4 aVec)
		{
			JSONNode container = GetContainer(VectorContainerType);
			container.WriteVector4(aVec);
			return container;
		}

		public static implicit operator JSONNode(Color aCol)
		{
			JSONNode container = GetContainer(ColorContainerType);
			container.WriteColor(aCol);
			return container;
		}

		public static implicit operator JSONNode(Color32 aCol)
		{
			JSONNode container = GetContainer(ColorContainerType);
			container.WriteColor32(aCol);
			return container;
		}

		public static implicit operator JSONNode(Quaternion aRot)
		{
			JSONNode container = GetContainer(QuaternionContainerType);
			container.WriteQuaternion(aRot);
			return container;
		}

		public static implicit operator JSONNode(Rect aRect)
		{
			JSONNode container = GetContainer(RectContainerType);
			container.WriteRect(aRect);
			return container;
		}

		public static implicit operator JSONNode(RectOffset aRect)
		{
			JSONNode container = GetContainer(RectContainerType);
			container.WriteRectOffset(aRect);
			return container;
		}

		public static implicit operator Vector2(JSONNode aNode)
		{
			return aNode.ReadVector2();
		}

		public static implicit operator Vector3(JSONNode aNode)
		{
			return aNode.ReadVector3();
		}

		public static implicit operator Vector4(JSONNode aNode)
		{
			return aNode.ReadVector4();
		}

		public static implicit operator Color(JSONNode aNode)
		{
			return aNode.ReadColor();
		}

		public static implicit operator Color32(JSONNode aNode)
		{
			return aNode.ReadColor32();
		}

		public static implicit operator Quaternion(JSONNode aNode)
		{
			return aNode.ReadQuaternion();
		}

		public static implicit operator Rect(JSONNode aNode)
		{
			return aNode.ReadRect();
		}

		public static implicit operator RectOffset(JSONNode aNode)
		{
			return aNode.ReadRectOffset();
		}

		public Vector2 ReadVector2(Vector2 aDefault)
		{
			if (IsObject)
			{
				return new Vector2(this["x"].AsFloat, this["y"].AsFloat);
			}
			if (IsArray)
			{
				return new Vector2(this[0].AsFloat, this[1].AsFloat);
			}
			return aDefault;
		}

		public Vector2 ReadVector2(string aXName, string aYName)
		{
			if (IsObject)
			{
				return new Vector2(this[aXName].AsFloat, this[aYName].AsFloat);
			}
			return Vector2.zero;
		}

		public Vector2 ReadVector2()
		{
			return ReadVector2(Vector2.zero);
		}

		public JSONNode WriteVector2(Vector2 aVec, string aXName = "x", string aYName = "y")
		{
			if (IsObject)
			{
				Inline = true;
				this[aXName].AsFloat = aVec.x;
				this[aYName].AsFloat = aVec.y;
			}
			else if (IsArray)
			{
				Inline = true;
				this[0].AsFloat = aVec.x;
				this[1].AsFloat = aVec.y;
			}
			return this;
		}

		public Vector3 ReadVector3(Vector3 aDefault)
		{
			if (IsObject)
			{
				return new Vector3(this["x"].AsFloat, this["y"].AsFloat, this["z"].AsFloat);
			}
			if (IsArray)
			{
				return new Vector3(this[0].AsFloat, this[1].AsFloat, this[2].AsFloat);
			}
			return aDefault;
		}

		public Vector3 ReadVector3(string aXName, string aYName, string aZName)
		{
			if (IsObject)
			{
				return new Vector3(this[aXName].AsFloat, this[aYName].AsFloat, this[aZName].AsFloat);
			}
			return Vector3.zero;
		}

		public Vector3 ReadVector3()
		{
			return ReadVector3(Vector3.zero);
		}

		public JSONNode WriteVector3(Vector3 aVec, string aXName = "x", string aYName = "y", string aZName = "z")
		{
			if (IsObject)
			{
				Inline = true;
				this[aXName].AsFloat = aVec.x;
				this[aYName].AsFloat = aVec.y;
				this[aZName].AsFloat = aVec.z;
			}
			else if (IsArray)
			{
				Inline = true;
				this[0].AsFloat = aVec.x;
				this[1].AsFloat = aVec.y;
				this[2].AsFloat = aVec.z;
			}
			return this;
		}

		public Vector4 ReadVector4(Vector4 aDefault)
		{
			if (IsObject)
			{
				return new Vector4(this["x"].AsFloat, this["y"].AsFloat, this["z"].AsFloat, this["w"].AsFloat);
			}
			if (IsArray)
			{
				return new Vector4(this[0].AsFloat, this[1].AsFloat, this[2].AsFloat, this[3].AsFloat);
			}
			return aDefault;
		}

		public Vector4 ReadVector4()
		{
			return ReadVector4(Vector4.zero);
		}

		public JSONNode WriteVector4(Vector4 aVec)
		{
			if (IsObject)
			{
				Inline = true;
				this["x"].AsFloat = aVec.x;
				this["y"].AsFloat = aVec.y;
				this["z"].AsFloat = aVec.z;
				this["w"].AsFloat = aVec.w;
			}
			else if (IsArray)
			{
				Inline = true;
				this[0].AsFloat = aVec.x;
				this[1].AsFloat = aVec.y;
				this[2].AsFloat = aVec.z;
				this[3].AsFloat = aVec.w;
			}
			return this;
		}

		public Color ReadColor(Color aDefault)
		{
			if (IsObject)
			{
				return new Color(this["r"].AsFloat, this["g"].AsFloat, this["b"].AsFloat, HasKey("a") ? this["a"].AsFloat : ColorDefaultAlpha);
			}
			if (IsArray)
			{
				return new Color(this[0].AsFloat, this[1].AsFloat, this[2].AsFloat, (Count > 3) ? this[3].AsFloat : ColorDefaultAlpha);
			}
			return aDefault;
		}

		public Color ReadColor()
		{
			return ReadColor(Color.clear);
		}

		public JSONNode WriteColor(Color aCol)
		{
			if (IsObject)
			{
				Inline = true;
				this["r"].AsFloat = aCol.r;
				this["g"].AsFloat = aCol.g;
				this["b"].AsFloat = aCol.b;
				this["a"].AsFloat = aCol.a;
			}
			else if (IsArray)
			{
				Inline = true;
				this[0].AsFloat = aCol.r;
				this[1].AsFloat = aCol.g;
				this[2].AsFloat = aCol.b;
				this[3].AsFloat = aCol.a;
			}
			return this;
		}

		public Color32 ReadColor32(Color32 aDefault)
		{
			if (IsObject)
			{
				return new Color32((byte)this["r"].AsInt, (byte)this["g"].AsInt, (byte)this["b"].AsInt, (byte)(HasKey("a") ? this["a"].AsInt : Color32DefaultAlpha));
			}
			if (IsArray)
			{
				return new Color32((byte)this[0].AsInt, (byte)this[1].AsInt, (byte)this[2].AsInt, (byte)((Count > 3) ? this[3].AsInt : Color32DefaultAlpha));
			}
			return aDefault;
		}

		public Color32 ReadColor32()
		{
			return ReadColor32(default(Color32));
		}

		public JSONNode WriteColor32(Color32 aCol)
		{
			if (IsObject)
			{
				Inline = true;
				this["r"].AsInt = aCol.r;
				this["g"].AsInt = aCol.g;
				this["b"].AsInt = aCol.b;
				this["a"].AsInt = aCol.a;
			}
			else if (IsArray)
			{
				Inline = true;
				this[0].AsInt = aCol.r;
				this[1].AsInt = aCol.g;
				this[2].AsInt = aCol.b;
				this[3].AsInt = aCol.a;
			}
			return this;
		}

		public Quaternion ReadQuaternion(Quaternion aDefault)
		{
			if (IsObject)
			{
				return new Quaternion(this["x"].AsFloat, this["y"].AsFloat, this["z"].AsFloat, this["w"].AsFloat);
			}
			if (IsArray)
			{
				return new Quaternion(this[0].AsFloat, this[1].AsFloat, this[2].AsFloat, this[3].AsFloat);
			}
			return aDefault;
		}

		public Quaternion ReadQuaternion()
		{
			return ReadQuaternion(Quaternion.identity);
		}

		public JSONNode WriteQuaternion(Quaternion aRot)
		{
			if (IsObject)
			{
				Inline = true;
				this["x"].AsFloat = aRot.x;
				this["y"].AsFloat = aRot.y;
				this["z"].AsFloat = aRot.z;
				this["w"].AsFloat = aRot.w;
			}
			else if (IsArray)
			{
				Inline = true;
				this[0].AsFloat = aRot.x;
				this[1].AsFloat = aRot.y;
				this[2].AsFloat = aRot.z;
				this[3].AsFloat = aRot.w;
			}
			return this;
		}

		public Rect ReadRect(Rect aDefault)
		{
			if (IsObject)
			{
				return new Rect(this["x"].AsFloat, this["y"].AsFloat, this["width"].AsFloat, this["height"].AsFloat);
			}
			if (IsArray)
			{
				return new Rect(this[0].AsFloat, this[1].AsFloat, this[2].AsFloat, this[3].AsFloat);
			}
			return aDefault;
		}

		public Rect ReadRect()
		{
			return ReadRect(default(Rect));
		}

		public JSONNode WriteRect(Rect aRect)
		{
			if (IsObject)
			{
				Inline = true;
				this["x"].AsFloat = aRect.x;
				this["y"].AsFloat = aRect.y;
				this["width"].AsFloat = aRect.width;
				this["height"].AsFloat = aRect.height;
			}
			else if (IsArray)
			{
				Inline = true;
				this[0].AsFloat = aRect.x;
				this[1].AsFloat = aRect.y;
				this[2].AsFloat = aRect.width;
				this[3].AsFloat = aRect.height;
			}
			return this;
		}

		public RectOffset ReadRectOffset(RectOffset aDefault)
		{
			if (this is JSONObject)
			{
				return new RectOffset(this["left"].AsInt, this["right"].AsInt, this["top"].AsInt, this["bottom"].AsInt);
			}
			if (this is JSONArray)
			{
				return new RectOffset(this[0].AsInt, this[1].AsInt, this[2].AsInt, this[3].AsInt);
			}
			return aDefault;
		}

		public RectOffset ReadRectOffset()
		{
			return ReadRectOffset(new RectOffset());
		}

		public JSONNode WriteRectOffset(RectOffset aRect)
		{
			if (IsObject)
			{
				Inline = true;
				this["left"].AsInt = aRect.left;
				this["right"].AsInt = aRect.right;
				this["top"].AsInt = aRect.top;
				this["bottom"].AsInt = aRect.bottom;
			}
			else if (IsArray)
			{
				Inline = true;
				this[0].AsInt = aRect.left;
				this[1].AsInt = aRect.right;
				this[2].AsInt = aRect.top;
				this[3].AsInt = aRect.bottom;
			}
			return this;
		}

		public Matrix4x4 ReadMatrix()
		{
			Matrix4x4 identity = Matrix4x4.identity;
			if (IsArray)
			{
				for (int i = 0; i < 16; i++)
				{
					identity[i] = this[i].AsFloat;
				}
			}
			return identity;
		}

		public JSONNode WriteMatrix(Matrix4x4 aMatrix)
		{
			if (IsArray)
			{
				Inline = true;
				for (int i = 0; i < 16; i++)
				{
					this[i].AsFloat = aMatrix[i];
				}
			}
			return this;
		}
	}
}
