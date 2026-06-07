using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

[Serializable]
public class JSON
{
	private sealed class _JSON
	{
		private sealed class Parser : IDisposable
		{
			private enum TOKEN
			{
				NONE = 0,
				CURLY_OPEN = 1,
				CURLY_CLOSE = 2,
				SQUARED_OPEN = 3,
				SQUARED_CLOSE = 4,
				COLON = 5,
				COMMA = 6,
				STRING = 7,
				NUMBER = 8,
				TRUE = 9,
				FALSE = 10,
				NULL = 11
			}

			private const string WHITE_SPACE = " \t\n\r";

			private const string WORD_BREAK = " \t\n\r{}[],:\"";

			private StringReader json;

			private char PeekChar => '\0';

			private char NextChar => '\0';

			private string NextWord => null;

			private TOKEN NextToken => default(TOKEN);

			private Parser(string jsonString)
			{
			}

			public static JSON Parse(string jsonString)
			{
				return null;
			}

			public void Dispose()
			{
			}

			private JSON ParseObject()
			{
				return null;
			}

			private List<object> ParseArray()
			{
				return null;
			}

			private object ParseValue()
			{
				return null;
			}

			private object ParseByToken(TOKEN token)
			{
				return null;
			}

			private string ParseString()
			{
				return null;
			}

			private object ParseNumber()
			{
				return null;
			}

			private void EatWhitespace()
			{
			}
		}

		private sealed class Serializer
		{
			private StringBuilder builder;

			private Serializer()
			{
			}

			public static string Serialize(JSON obj)
			{
				return null;
			}

			private void SerializeValue(object value)
			{
			}

			private void SerializeObject(JSON obj)
			{
			}

			private void SerializeDictionary(IDictionary obj)
			{
			}

			private void SerializeArray(IList anArray)
			{
			}

			private void SerializeString(string str)
			{
			}

			private void SerializeOther(object value)
			{
			}
		}

		public static JSON Deserialize(string json)
		{
			return null;
		}

		public static string Serialize(JSON obj)
		{
			return null;
		}
	}

	public Dictionary<string, object> fields;

	public object this[string fieldName]
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public string serialized
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public string ToString(string fieldName)
	{
		return null;
	}

	public decimal ToDecimal(string fieldName)
	{
		return default(decimal);
	}

	public byte ToByte(string fieldName)
	{
		return 0;
	}

	public sbyte ToSByte(string fieldName)
	{
		return 0;
	}

	public short ToInt16(string fieldName)
	{
		return 0;
	}

	public int ToInt(string fieldName)
	{
		return 0;
	}

	public long ToInt64(string fieldName)
	{
		return 0L;
	}

	public float ToFloat(string fieldName)
	{
		return 0f;
	}

	public double ToDouble(string fieldName)
	{
		return 0.0;
	}

	public bool ToBoolean(string fieldName)
	{
		return false;
	}

	public JSON ToJSON(string fieldName)
	{
		return null;
	}

	public bool ContainsKey(string fieldName)
	{
		return false;
	}

	public int Count()
	{
		return 0;
	}

	public static implicit operator Vector2(JSON value)
	{
		return default(Vector2);
	}

	public static explicit operator JSON(Vector2 value)
	{
		return null;
	}

	public static implicit operator Vector3(JSON value)
	{
		return default(Vector3);
	}

	public static explicit operator JSON(Vector3 value)
	{
		return null;
	}

	public static implicit operator Quaternion(JSON value)
	{
		return default(Quaternion);
	}

	public static explicit operator JSON(Quaternion value)
	{
		return null;
	}

	public static implicit operator Color(JSON value)
	{
		return default(Color);
	}

	public static explicit operator JSON(Color value)
	{
		return null;
	}

	public static implicit operator Color32(JSON value)
	{
		return default(Color32);
	}

	public static explicit operator JSON(Color32 value)
	{
		return null;
	}

	public static implicit operator Rect(JSON value)
	{
		return default(Rect);
	}

	public static explicit operator JSON(Rect value)
	{
		return null;
	}

	public T[] ToArray<T>(string fieldName)
	{
		return null;
	}
}
