using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using UnityEngine;

public static class JSON
{
	public class Array
	{
		private List<object> array;

		public List<object> RawArray => array;

		public int Count => array.Count;

		public object this[int index] => ToObject(array[index]);

		public Array(List<object> array)
		{
			this.array = array;
		}

		public bool GetBool(int index)
		{
			return ToBool(this[index]);
		}

		public int GetInt(int index)
		{
			return ToInt(this[index]);
		}

		public long GetLong(int index)
		{
			return ToLong(this[index], 0L);
		}

		public float GetFloat(int index)
		{
			return ToFloat(this[index]);
		}

		public string GetString(int index)
		{
			return JSON.ToString(this[index]);
		}

		public Color32 GetColor(int index)
		{
			return ToColor(this[index]);
		}

		public Array GetArray(int index)
		{
			return ToArray(this[index]);
		}

		public Dictionary GetDictionary(int index)
		{
			return ToDictionary(this[index]);
		}

		public DateTime GetDateTime(int index)
		{
			return ToDateTime(this[index]);
		}
	}

	public class Dictionary
	{
		private Dictionary<string, object> dictionary;

		public Dictionary<string, object> RawDictionary => dictionary;

		public Dictionary<string, object>.KeyCollection Keys => dictionary.Keys;

		public object this[string key]
		{
			get
			{
				if (!dictionary.ContainsKey(key))
				{
					return null;
				}
				return ToObject(dictionary[key]);
			}
		}

		public Dictionary(Dictionary<string, object> dictionary)
		{
			this.dictionary = dictionary;
		}

		public bool GetBool(string key, bool defaultValue = false)
		{
			return ToBool(this[key], defaultValue);
		}

		public int GetInt(string key, int defaultValue = 0)
		{
			return ToInt(this[key], defaultValue);
		}

		public long GetLong(string key, long defaultValue = 0L)
		{
			return ToLong(this[key], defaultValue);
		}

		public float GetFloat(string key, float defaultValue = 0f)
		{
			return ToFloat(this[key], defaultValue);
		}

		public string GetString(string key)
		{
			return JSON.ToString(this[key]);
		}

		public Color32 GetColor(string key)
		{
			return ToColor(this[key]);
		}

		public Array GetArray(string key)
		{
			return ToArray(this[key]);
		}

		public DateTime GetDateTime(string key)
		{
			return ToDateTime(this[key]);
		}

		public Dictionary GetDictionary(string key)
		{
			return ToDictionary(this[key]);
		}

		public bool ContainsKey(string key)
		{
			return dictionary.ContainsKey(key);
		}

		public static Dictionary Merge(Dictionary left, Dictionary right)
		{
			return new Dictionary(MergeDictionary(left.dictionary, right.dictionary));
		}

		public Dictionary Clone()
		{
			return new Dictionary(CloneObject(dictionary) as Dictionary<string, object>);
		}

		public static Dictionary<string, object> MergeDictionary(Dictionary<string, object> left, Dictionary<string, object> right)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			foreach (string key in left.Keys)
			{
				dictionary[key] = CloneObject(left[key]);
			}
			foreach (string key2 in right.Keys)
			{
				object left2 = (dictionary.ContainsKey(key2) ? dictionary[key2] : null);
				object right2 = right[key2];
				dictionary[key2] = MergeObject(left2, right2);
			}
			return dictionary;
		}

		private static object MergeObject(object left, object right)
		{
			if (left is Dictionary<string, object> && right is Dictionary<string, object>)
			{
				return MergeDictionary(left as Dictionary<string, object>, right as Dictionary<string, object>);
			}
			return CloneObject(right);
		}

		private static object CloneObject(object jsonObject)
		{
			if (jsonObject is List<object>)
			{
				List<object> list = jsonObject as List<object>;
				List<object> list2 = new List<object>(list.Count);
				for (int i = 0; i < list.Count; i++)
				{
					list2.Add(CloneObject(list[i]));
				}
				return list2;
			}
			if (jsonObject is Dictionary<string, object>)
			{
				Dictionary<string, object> dictionary = jsonObject as Dictionary<string, object>;
				Dictionary<string, object> dictionary2 = new Dictionary<string, object>();
				{
					foreach (string key in dictionary.Keys)
					{
						dictionary2[key] = CloneObject(dictionary[key]);
					}
					return dictionary2;
				}
			}
			if (jsonObject is string)
			{
				return string.Copy(jsonObject as string);
			}
			return jsonObject;
		}
	}

	public static object Load(string filename, bool forceSystemRead = false)
	{
		string text = null;
		TextAsset textAsset = null;
		if (filename.EndsWith(".txt") || forceSystemRead)
		{
			text = File.ReadAllText(filename);
		}
		else
		{
			textAsset = Resources.Load(filename, typeof(TextAsset)) as TextAsset;
			if (textAsset == null)
			{
				return null;
			}
			text = textAsset.text;
		}
		object jsonObject = Json.Deserialize(text);
		if (textAsset != null)
		{
			Resources.UnloadAsset(textAsset);
		}
		return ToObject(jsonObject);
	}

	public static object LoadFromString(string jsonText)
	{
		object obj = null;
		try
		{
			obj = Json.Deserialize(jsonText);
		}
		catch (OverflowException)
		{
			Debug.LogFormat("JSON.LoadFromString: Unable to parse JSON '{0}'", jsonText);
			return null;
		}
		return ToObject(obj);
	}

	public static bool ToBool(object jsonObject, bool defaultValue = false)
	{
		if (jsonObject == null || !(jsonObject is bool))
		{
			return defaultValue;
		}
		return (bool)jsonObject;
	}

	public static int ToInt(object jsonObject, int defaultValue = 0)
	{
		if (jsonObject == null || !(jsonObject is long))
		{
			return defaultValue;
		}
		return Convert.ToInt32((long)jsonObject);
	}

	public static long ToLong(object jsonObject, long defaultValue = 0L)
	{
		if (jsonObject == null || !(jsonObject is long))
		{
			return defaultValue;
		}
		return Convert.ToInt64((long)jsonObject);
	}

	public static float ToFloat(object jsonObject, float defaultValue = 0f)
	{
		if (jsonObject == null)
		{
			return defaultValue;
		}
		return Convert.ToSingle(jsonObject);
	}

	public static string ToString(object jsonObject)
	{
		if (jsonObject == null || !(jsonObject is string))
		{
			return null;
		}
		return jsonObject as string;
	}

	public static Color32 ToColor(object jsonObject)
	{
		Array array = ToArray(jsonObject);
		if (array == null || (array.Count != 3 && array.Count != 4))
		{
			return Color.white;
		}
		Color32 result = new Color32((byte)array.GetInt(0), (byte)array.GetInt(1), (byte)array.GetInt(2), byte.MaxValue);
		if (array.Count == 4)
		{
			result.a = (byte)array.GetInt(3);
		}
		return result;
	}

	public static Dictionary ToDictionary(object jsonObject)
	{
		if (jsonObject == null || !(jsonObject is Dictionary))
		{
			return null;
		}
		return jsonObject as Dictionary;
	}

	public static Array ToArray(object jsonObject)
	{
		if (jsonObject == null || !(jsonObject is Array))
		{
			return null;
		}
		return jsonObject as Array;
	}

	public static DateTime ToDateTime(object jsonObject)
	{
		DateTime result = DateTime.MinValue;
		if (jsonObject is string s && long.TryParse(s, out var result2))
		{
			try
			{
				result = DateTime.FromBinary(result2);
			}
			catch (ArgumentException)
			{
			}
		}
		return result;
	}

	public static object ToObject(object jsonObject)
	{
		if (jsonObject is Dictionary<string, object>)
		{
			return new Dictionary(jsonObject as Dictionary<string, object>);
		}
		if (jsonObject is List<object>)
		{
			return new Array(jsonObject as List<object>);
		}
		return jsonObject;
	}
}
public static class Json
{
	public static class JsonFormatter
	{
		private class StringWalker
		{
			private readonly string _s;

			public int Index { get; private set; }

			public bool IsEscaped { get; private set; }

			public char CurrentChar { get; private set; }

			public StringWalker(string s)
			{
				_s = s;
				Index = -1;
			}

			public bool MoveNext()
			{
				if (Index == _s.Length - 1)
				{
					return false;
				}
				if (!IsEscaped)
				{
					IsEscaped = CurrentChar == '\\';
				}
				else
				{
					IsEscaped = false;
				}
				Index++;
				CurrentChar = _s[Index];
				return true;
			}
		}

		private class IndentWriter
		{
			private readonly StringBuilder _result = new StringBuilder();

			private int _indentLevel;

			public void Indent()
			{
				_indentLevel++;
			}

			public void UnIndent()
			{
				if (_indentLevel > 0)
				{
					_indentLevel--;
				}
			}

			public void WriteLine(string line)
			{
				_result.AppendLine(CreateIndent() + line);
			}

			private string CreateIndent()
			{
				StringBuilder stringBuilder = new StringBuilder();
				for (int i = 0; i < _indentLevel; i++)
				{
					stringBuilder.Append("    ");
				}
				return stringBuilder.ToString();
			}

			public override string ToString()
			{
				return _result.ToString();
			}
		}

		private static StringWalker _walker;

		private static IndentWriter _writer = new IndentWriter();

		private static StringBuilder _currentLine = new StringBuilder();

		private static bool _quoted;

		public static void ResetLine()
		{
			_currentLine.Length = 0;
		}

		public static string Format(string json)
		{
			_walker = new StringWalker(json);
			_writer = new IndentWriter();
			_currentLine = new StringBuilder();
			ResetLine();
			while (MoveNextChar())
			{
				if (!_quoted && IsOpenBracket())
				{
					WriteCurrentLine();
					AddCharToLine();
					WriteCurrentLine();
					_writer.Indent();
				}
				else if (!_quoted && IsCloseBracket())
				{
					WriteCurrentLine();
					_writer.UnIndent();
					AddCharToLine();
				}
				else if (!_quoted && IsColon())
				{
					AddCharToLine();
					WriteCurrentLine();
				}
				else
				{
					AddCharToLine();
				}
			}
			WriteCurrentLine();
			return _writer.ToString();
		}

		private static bool MoveNextChar()
		{
			bool result = _walker.MoveNext();
			if (IsApostrophe())
			{
				_quoted = !_quoted;
			}
			return result;
		}

		public static bool IsApostrophe()
		{
			if (_walker.CurrentChar == '"')
			{
				return !_walker.IsEscaped;
			}
			return false;
		}

		public static bool IsOpenBracket()
		{
			if (_walker.CurrentChar != '{')
			{
				return _walker.CurrentChar == '[';
			}
			return true;
		}

		public static bool IsCloseBracket()
		{
			if (_walker.CurrentChar != '}')
			{
				return _walker.CurrentChar == ']';
			}
			return true;
		}

		public static bool IsColon()
		{
			return _walker.CurrentChar == ',';
		}

		private static void AddCharToLine()
		{
			_currentLine.Append(_walker.CurrentChar);
		}

		private static void WriteCurrentLine()
		{
			string text = _currentLine.ToString().Trim();
			if (text.Length > 0)
			{
				_writer.WriteLine(text);
			}
			ResetLine();
		}
	}

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

		private char PeekChar => Convert.ToChar(json.Peek());

		private char NextChar => Convert.ToChar(json.Read());

		private string NextWord
		{
			get
			{
				StringBuilder stringBuilder = new StringBuilder();
				while (" \t\n\r{}[],:\"".IndexOf(PeekChar) == -1)
				{
					stringBuilder.Append(NextChar);
					if (json.Peek() == -1)
					{
						break;
					}
				}
				return stringBuilder.ToString();
			}
		}

		private TOKEN NextToken
		{
			get
			{
				EatWhitespace();
				if (json.Peek() == -1)
				{
					return TOKEN.NONE;
				}
				switch (PeekChar)
				{
				case '{':
					return TOKEN.CURLY_OPEN;
				case '}':
					json.Read();
					return TOKEN.CURLY_CLOSE;
				case '[':
					return TOKEN.SQUARED_OPEN;
				case ']':
					json.Read();
					return TOKEN.SQUARED_CLOSE;
				case ',':
					json.Read();
					return TOKEN.COMMA;
				case '"':
					return TOKEN.STRING;
				case ':':
					return TOKEN.COLON;
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
					return TOKEN.NUMBER;
				default:
					return NextWord switch
					{
						"false" => TOKEN.FALSE, 
						"true" => TOKEN.TRUE, 
						"null" => TOKEN.NULL, 
						_ => TOKEN.NONE, 
					};
				}
			}
		}

		private Parser(string jsonString)
		{
			json = new StringReader(jsonString);
		}

		public static object Parse(string jsonString)
		{
			using Parser parser = new Parser(jsonString);
			return parser.ParseValue();
		}

		public void Dispose()
		{
			json.Dispose();
			json = null;
		}

		private Dictionary<string, object> ParseObject()
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			json.Read();
			while (true)
			{
				switch (NextToken)
				{
				case TOKEN.COMMA:
					continue;
				case TOKEN.NONE:
					return null;
				case TOKEN.CURLY_CLOSE:
					return dictionary;
				}
				string text = ParseString();
				if (text == null)
				{
					return null;
				}
				if (NextToken != TOKEN.COLON)
				{
					return null;
				}
				json.Read();
				dictionary[text] = ParseValue();
			}
		}

		private List<object> ParseArray()
		{
			List<object> list = new List<object>();
			json.Read();
			bool flag = true;
			while (flag)
			{
				TOKEN nextToken = NextToken;
				switch (nextToken)
				{
				case TOKEN.NONE:
					return null;
				case TOKEN.SQUARED_CLOSE:
					flag = false;
					break;
				default:
				{
					object item = ParseByToken(nextToken);
					list.Add(item);
					break;
				}
				case TOKEN.COMMA:
					break;
				}
			}
			return list;
		}

		private object ParseValue()
		{
			TOKEN nextToken = NextToken;
			return ParseByToken(nextToken);
		}

		private object ParseByToken(TOKEN token)
		{
			return token switch
			{
				TOKEN.STRING => ParseString(), 
				TOKEN.NUMBER => ParseNumber(), 
				TOKEN.CURLY_OPEN => ParseObject(), 
				TOKEN.SQUARED_OPEN => ParseArray(), 
				TOKEN.TRUE => true, 
				TOKEN.FALSE => false, 
				TOKEN.NULL => null, 
				_ => null, 
			};
		}

		private string ParseString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			json.Read();
			bool flag = true;
			while (flag)
			{
				if (json.Peek() == -1)
				{
					flag = false;
					break;
				}
				char nextChar = NextChar;
				switch (nextChar)
				{
				case '"':
					flag = false;
					break;
				case '\\':
					if (json.Peek() == -1)
					{
						flag = false;
						break;
					}
					nextChar = NextChar;
					switch (nextChar)
					{
					case '"':
					case '/':
					case '\\':
						stringBuilder.Append(nextChar);
						break;
					case 'b':
						stringBuilder.Append('\b');
						break;
					case 'f':
						stringBuilder.Append('\f');
						break;
					case 'n':
						stringBuilder.Append('\n');
						break;
					case 'r':
						stringBuilder.Append('\r');
						break;
					case 't':
						stringBuilder.Append('\t');
						break;
					case 'u':
					{
						StringBuilder stringBuilder2 = new StringBuilder();
						for (int i = 0; i < 4; i++)
						{
							stringBuilder2.Append(NextChar);
						}
						stringBuilder.Append((char)Convert.ToInt32(stringBuilder2.ToString(), 16));
						break;
					}
					}
					break;
				default:
					stringBuilder.Append(nextChar);
					break;
				}
			}
			return stringBuilder.ToString();
		}

		private object ParseNumber()
		{
			string nextWord = NextWord;
			if (nextWord.IndexOf('.') == -1)
			{
				long.TryParse(nextWord, NumberStyles.Any, CultureInfo.InvariantCulture, out var result);
				return result;
			}
			double.TryParse(nextWord, NumberStyles.Any, CultureInfo.InvariantCulture, out var result2);
			return result2;
		}

		private void EatWhitespace()
		{
			while (" \t\n\r".IndexOf(PeekChar) != -1)
			{
				json.Read();
				if (json.Peek() == -1)
				{
					break;
				}
			}
		}
	}

	private sealed class Serializer
	{
		private StringBuilder builder;

		private bool _preserveEncoding;

		private Serializer()
		{
			builder = new StringBuilder();
		}

		public static string Serialize(object obj, bool preserveEncoding = false)
		{
			Serializer serializer = new Serializer();
			serializer._preserveEncoding = preserveEncoding;
			serializer.SerializeValue(obj);
			return serializer.builder.ToString();
		}

		private void SerializeValue(object value)
		{
			if (value == null)
			{
				builder.Append("null");
			}
			else if (value is string str)
			{
				SerializeString(str);
			}
			else if (value is bool)
			{
				builder.Append(value.ToString().ToLower());
			}
			else if (value is IList anArray)
			{
				SerializeArray(anArray);
			}
			else if (value is JSON.Array array)
			{
				SerializeArray(array.RawArray);
			}
			else if (value is IDictionary obj)
			{
				SerializeObject(obj);
			}
			else if (value is JSON.Dictionary dictionary)
			{
				SerializeObject(dictionary.RawDictionary);
			}
			else if (value is char)
			{
				SerializeString(value.ToString());
			}
			else if (value is DateTime dateTime)
			{
				SerializeString(dateTime.ToBinary().ToString());
			}
			else
			{
				SerializeOther(value);
			}
		}

		private void SerializeObject(IDictionary obj)
		{
			bool flag = true;
			builder.Append('{');
			foreach (object key in obj.Keys)
			{
				if (!flag)
				{
					builder.Append(',');
				}
				SerializeString(key.ToString());
				builder.Append(':');
				SerializeValue(obj[key]);
				flag = false;
			}
			builder.Append('}');
		}

		private void SerializeArray(IList anArray)
		{
			builder.Append('[');
			bool flag = true;
			foreach (object item in anArray)
			{
				if (!flag)
				{
					builder.Append(',');
				}
				SerializeValue(item);
				flag = false;
			}
			builder.Append(']');
		}

		private void SerializeString(string str)
		{
			builder.Append('"');
			char[] array = str.ToCharArray();
			foreach (char c in array)
			{
				switch (c)
				{
				case '"':
					builder.Append("\\\"");
					continue;
				case '\\':
					builder.Append("\\\\");
					continue;
				case '\b':
					builder.Append("\\b");
					continue;
				case '\f':
					builder.Append("\\f");
					continue;
				case '\n':
					builder.Append("\\n");
					continue;
				case '\r':
					builder.Append("\\r");
					continue;
				case '\t':
					builder.Append("\\t");
					continue;
				}
				int num = Convert.ToInt32(c);
				if ((num >= 32 && num <= 126) || _preserveEncoding)
				{
					builder.Append(c);
				}
				else
				{
					builder.Append("\\u" + Convert.ToString(num, 16).PadLeft(4, '0'));
				}
			}
			builder.Append('"');
		}

		private void SerializeOther(object value)
		{
			if (value is float || value is int || value is uint || value is long || value is double || value is sbyte || value is byte || value is short || value is ushort || value is ulong || value is decimal)
			{
				builder.Append(value.ToString());
			}
			else
			{
				SerializeString(value.ToString());
			}
		}
	}

	public static object Deserialize(string json)
	{
		if (json == null)
		{
			return null;
		}
		return Parser.Parse(json);
	}

	public static string Serialize(object obj, bool preserveEncoding = false)
	{
		return Serializer.Serialize(obj, preserveEncoding);
	}
}
