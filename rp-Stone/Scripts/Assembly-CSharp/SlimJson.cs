using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using UnityEngine;

public class SlimJson
{
	public static bool identationEnabled = true;

	private static Stack<StringBuilder> serializationStack = new Stack<StringBuilder>();

	private static Stack<char> bracketStack = new Stack<char>();

	private static List<string> split = new List<string>();

	private static string identation = "";

	private static List<string> identationList = new List<string>();

	private static int identationIndex;

	private static char[] dictSpecialChars = new char[8] { '\\', ',', ':', '{', '}', '\n', '[', ']' };

	private static string[] dictEscapedSpecialChars = new string[8] { "\\\\", "\\,", "\\:", "\\{", "\\}", "\\\n", "\\[", "\\]" };

	private static List<char> arrayDelimiters = new List<char> { ',', ']' };

	private static List<char> dictDelimiters = new List<char> { ',', '}' };

	private static List<char> dictKeyDelimiters = new List<char> { ':' };

	private static Stack<StringBuilder> stringBuilderPool = new Stack<StringBuilder>();

	public static void BeginSerialization()
	{
		StringBuilder stringBuilder = GetStringBuilder();
		stringBuilder.Append("{");
		serializationStack.Push(stringBuilder);
	}

	public static string EndSerialization()
	{
		StringBuilder stringBuilder = serializationStack.Pop();
		stringBuilder.Append("}");
		string result = stringBuilder.ToString();
		RecycleStringBuilder(stringBuilder);
		return result;
	}

	public static void AddProperty(string key, string property)
	{
		if (key == null)
		{
			Console.Write("Key is null for string " + property);
		}
		if (property == null)
		{
			Console.Write("String property is null for key " + key + ". Converting to empty string.");
			property = "";
		}
		StringBuilder stringBuilder = serializationStack.Pop();
		char c = stringBuilder[stringBuilder.Length - 1];
		if (c != '[' && c != '{')
		{
			stringBuilder.Append(',');
			AppendIdentation(stringBuilder);
		}
		stringBuilder.Append(key);
		stringBuilder.Append(':');
		AppendWithQuotesIfNeeded(stringBuilder, property);
		serializationStack.Push(stringBuilder);
	}

	private static void AppendIdentation(StringBuilder top)
	{
		if (identationEnabled)
		{
			top.Append('\n');
			top.Append(identation);
		}
	}

	public static void AddProperty(string key, int property)
	{
		if (key == null)
		{
			Console.Write("Key is null for integer " + property);
		}
		StringBuilder stringBuilder = serializationStack.Pop();
		char c = stringBuilder[stringBuilder.Length - 1];
		if (c != '[' && c != '{')
		{
			stringBuilder.Append(',');
			AppendIdentation(stringBuilder);
		}
		stringBuilder.Append(key);
		stringBuilder.Append(':');
		stringBuilder.Append(property);
		serializationStack.Push(stringBuilder);
	}

	public static void AddProperty(string key, long property)
	{
		if (key == null)
		{
			Console.Write("Key is null for long " + property);
		}
		StringBuilder stringBuilder = serializationStack.Pop();
		char c = stringBuilder[stringBuilder.Length - 1];
		if (c != '[' && c != '{')
		{
			stringBuilder.Append(',');
			AppendIdentation(stringBuilder);
		}
		stringBuilder.Append(key);
		stringBuilder.Append(':');
		stringBuilder.Append(property);
		serializationStack.Push(stringBuilder);
	}

	public static void AddProperty(string key, bool property)
	{
		if (key == null)
		{
			Console.Write("Key is null for boolean " + property);
		}
		StringBuilder stringBuilder = serializationStack.Pop();
		char c = stringBuilder[stringBuilder.Length - 1];
		if (c != '[' && c != '{')
		{
			stringBuilder.Append(',');
			AppendIdentation(stringBuilder);
		}
		stringBuilder.Append(key);
		stringBuilder.Append(':');
		stringBuilder.Append(property);
		serializationStack.Push(stringBuilder);
	}

	public static void AddProperty(string key, float property)
	{
		if (key == null)
		{
			Console.Write("Key is null for float " + property);
		}
		StringBuilder stringBuilder = serializationStack.Pop();
		char c = stringBuilder[stringBuilder.Length - 1];
		if (c != '[' && c != '{')
		{
			stringBuilder.Append(',');
			AppendIdentation(stringBuilder);
		}
		stringBuilder.Append(key);
		stringBuilder.Append(':');
		stringBuilder.Append(property.ToString(CultureInfo.InvariantCulture));
		serializationStack.Push(stringBuilder);
	}

	public static void AddProperty(string key, DateTime property)
	{
		if (key == null)
		{
			Console.Write("Key is null for dateTime " + property);
		}
		AddProperty(key, property.ToString(CultureInfo.InvariantCulture));
	}

	public static void AddProperty(string key, Color property)
	{
		if (key == null)
		{
			Color color = property;
			Console.Write("Key is null for color " + color.ToString());
		}
		string property2 = "#" + ColorUtility.ToHtmlStringRGB(property);
		AddProperty(key, property2);
	}

	public static void AddProperty(string key, Dictionary<string, object> dict)
	{
		if (key == null)
		{
			Console.Write("Key is null for float " + dict);
		}
		StringBuilder stringBuilder = serializationStack.Pop();
		if (stringBuilder.Length > 0)
		{
			int num = stringBuilder.Length - 1;
			char c = stringBuilder[num];
			while (num >= 0 && (c = stringBuilder[num]) == '\n')
			{
				num--;
			}
			if (c != '[' && c != '{')
			{
				stringBuilder.Append(',');
				AppendIdentation(stringBuilder);
			}
		}
		stringBuilder.Append(key);
		stringBuilder.Append(":{");
		AppendIdentation(stringBuilder);
		bool flag = false;
		foreach (string key2 in dict.Keys)
		{
			object obj = dict[key2];
			if (obj is Dictionary<string, object>)
			{
				serializationStack.Push(stringBuilder);
				AddProperty(key2, obj as Dictionary<string, object>);
				serializationStack.Pop();
			}
			else if (obj is IEnumerable<object>)
			{
				object[] array = null;
				array = ((!(obj is object[])) ? new List<object>(obj as IEnumerable<object>).ToArray() : (obj as object[]));
				serializationStack.Push(stringBuilder);
				AddProperty(key2, array, enforceString: true);
				serializationStack.Pop();
			}
			else
			{
				if (flag)
				{
					stringBuilder.Append(',');
				}
				AppendIdentation(stringBuilder);
				stringBuilder.Append(key2);
				stringBuilder.Append(':');
				StringBuilder stringBuilder2 = GetStringBuilder();
				stringBuilder2.Append((obj != null) ? obj.ToString() : "null");
				for (int i = 0; i < dictSpecialChars.Length; i++)
				{
					stringBuilder2.Replace(dictSpecialChars[i].ToString(), dictEscapedSpecialChars[i]);
				}
				stringBuilder.Append(stringBuilder2);
			}
			flag = true;
		}
		AppendIdentation(stringBuilder);
		stringBuilder.Append('}');
		serializationStack.Push(stringBuilder);
	}

	public static void AddProperty(string key, string[] arr)
	{
		AddProperty(key, arr, false);
	}

	public static void AddProperty(string key, int[] arr)
	{
		AddProperty(key, arr, false);
	}

	public static void AddProperty<T>(string key, T[] arr, bool enforceString = false)
	{
		if (key == null)
		{
			Console.Write("Key is null for array " + arr);
		}
		if (arr == null)
		{
			Console.Write("Array property is null for key " + key + ". Converting to an empty array.");
			arr = new T[0];
		}
		StringBuilder stringBuilder = serializationStack.Pop();
		int num = stringBuilder.Length - 1;
		char c = stringBuilder[num];
		while (num > 0 && (c == '\n' || c == '\t' || c == ' '))
		{
			c = stringBuilder[--num];
		}
		if (c != '[' && c != '{')
		{
			stringBuilder.Append(',');
			AppendIdentation(stringBuilder);
		}
		if (arr.Length == 0)
		{
			stringBuilder.Append(key);
			stringBuilder.Append(":[]");
		}
		else
		{
			stringBuilder.Append(key);
			stringBuilder.Append(":[");
			increaseIdentation();
			for (int i = 0; i < arr.Length; i++)
			{
				if (i >= 1)
				{
					stringBuilder.Append(',');
				}
				AppendIdentation(stringBuilder);
				string str = ((arr[i] != null) ? arr[i].ToString() : "null");
				AppendWithQuotesIfNeeded(stringBuilder, str, enforceString && arr[i] is string);
			}
			decreaseIdentation();
			AppendIdentation(stringBuilder);
			stringBuilder.Append(']');
		}
		serializationStack.Push(stringBuilder);
	}

	public static void AddProperty(string key, object[][] arr2D)
	{
		if (key == null)
		{
			Console.Write("Key is null for array " + arr2D);
		}
		if (arr2D == null)
		{
			Console.Write("Array property is null for key " + key + ". Converting to an empty array.");
			arr2D = new object[0][];
		}
		StringBuilder stringBuilder = serializationStack.Pop();
		char c = stringBuilder[stringBuilder.Length - 1];
		if (c != '[' && c != '{')
		{
			stringBuilder.Append(',');
			AppendIdentation(stringBuilder);
		}
		if (arr2D.Length == 0)
		{
			stringBuilder.Append(key);
			stringBuilder.Append(":[]");
		}
		else
		{
			stringBuilder.Append(key);
			stringBuilder.Append(":[");
			increaseIdentation();
			for (int i = 0; i < arr2D.Length; i++)
			{
				if (i >= 1)
				{
					stringBuilder.Append(',');
				}
				AppendIdentation(stringBuilder);
				object[] array = arr2D[i];
				stringBuilder.Append('[');
				for (int j = 0; j < array.Length; j++)
				{
					if (j >= 1)
					{
						stringBuilder.Append(',');
					}
					string str = array[j].ToString();
					AppendWithQuotesIfNeeded(stringBuilder, str);
				}
				stringBuilder.Append(']');
			}
			decreaseIdentation();
			AppendIdentation(stringBuilder);
			stringBuilder.Append(']');
		}
		serializationStack.Push(stringBuilder);
	}

	private static void increaseIdentation()
	{
		identationIndex++;
		if (identationList.Count == 0)
		{
			identationList.Add("");
		}
		while (identationIndex >= identationList.Count)
		{
			string item = identationList[identationList.Count - 1] + "\t";
			identationList.Add(item);
		}
		identation = identationList[identationIndex];
	}

	private static void decreaseIdentation()
	{
		identationIndex--;
		identation = identationList[identationIndex];
	}

	private static string GetLineBreakAndIdentation()
	{
		if (identationEnabled)
		{
			return "\n" + identation;
		}
		return "";
	}

	private static void AppendWithQuotesIfNeeded(StringBuilder sb, string str, bool force = false)
	{
		if (str.Length == 0 || (force && (str[0] == '[' || str[0] == '{')) || str[0] == ' ' || str[str.Length - 1] == ' ' || (str[0] != '[' && str[0] != '{' && (str.IndexOf(',') >= 0 || str.IndexOf('{') > 0 || str.IndexOf('[') > 0 || str.IndexOf('\n') > 0)) || (str[0] == '[' && str[str.Length - 1] != ']'))
		{
			sb.Append('"');
			sb.Append(str);
			sb.Append('"');
		}
		else
		{
			sb.Append(str);
		}
	}

	public static object ParseObject(string sjson)
	{
		int i = 0;
		return ParseObject(sjson, ref i, null);
	}

	public static object ParseObject(string sjson, string key)
	{
		int i = 0;
		Dictionary<string, object> dictionary = ParseObject_Dictionary(sjson, ref i);
		if (dictionary != null && dictionary.ContainsKey(key))
		{
			return dictionary[key];
		}
		return null;
	}

	private static object ParseObject(string sjson, ref int i, List<char> delimiters)
	{
		object obj = null;
		i = SkipFormatting(sjson, i);
		if (sjson[i] == '{')
		{
			return ParseObject_Dictionary(sjson, ref i);
		}
		if (sjson[i] == '[')
		{
			return ParseObject_Array(sjson, ref i);
		}
		string text = ParseObject_String(sjson, ref i, delimiters);
		string text2 = text?.Trim();
		if (text2 == null)
		{
			throw new Exception($"Expected value at index {i}.");
		}
		if (text2.Length == 0)
		{
			return "";
		}
		if (int.TryParse(text, out var result))
		{
			return result;
		}
		if (bool.TryParse(text, out var result2))
		{
			return result2;
		}
		if (text2.StartsWith("\"") && text2.EndsWith("\""))
		{
			text = text2.Substring(1, text.Length - 2);
		}
		if (text2.Equals("null"))
		{
			text = null;
		}
		return text;
	}

	private static string ParseObject_String(string sjson, ref int i, List<char> delimiters)
	{
		if (sjson[i] == '"')
		{
			int num = sjson.IndexOf('"', i + 1);
			int length = num - i - 1;
			string result = sjson.Substring(i + 1, length);
			i = num + 1;
			return result;
		}
		bool flag = false;
		StringBuilder stringBuilder = GetStringBuilder();
		while (i < sjson.Length)
		{
			char c = sjson[i];
			if (!flag && c == '\\')
			{
				flag = true;
				i++;
				continue;
			}
			if (!flag && ((delimiters != null && delimiters.Contains(c)) || c == '\n'))
			{
				break;
			}
			stringBuilder.Append(c);
			flag = false;
			i++;
		}
		string result2 = stringBuilder.ToString();
		RecycleStringBuilder(stringBuilder);
		return result2;
	}

	private static List<object> ParseObject_Array(string sjson, ref int i)
	{
		i++;
		List<object> list = new List<object>();
		char c;
		do
		{
			i = SkipFormatting(sjson, i);
			if (i >= sjson.Length)
			{
				throw new Exception($"Expected ']' at {i}");
			}
			if (sjson[i] == ']')
			{
				i++;
				break;
			}
			object item = ParseObject(sjson, ref i, arrayDelimiters);
			if (i >= sjson.Length)
			{
				throw new Exception($"Expected ']' at {i}");
			}
			i = SkipFormatting(sjson, i);
			c = sjson[i];
			if (c != ']' && c != ',')
			{
				throw new Exception($"Expected ']' at {i}");
			}
			list.Add(item);
			i++;
		}
		while (c != ']');
		return list;
	}

	private static Dictionary<string, object> ParseObject_Dictionary(string sjson, ref int i)
	{
		i++;
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		char c;
		do
		{
			i = SkipFormatting(sjson, i);
			if (i >= sjson.Length)
			{
				throw new Exception($"Expected '}}' at {i}");
			}
			if (sjson[i] == '}')
			{
				break;
			}
			string text = ParseObject_String(sjson, ref i, dictKeyDelimiters);
			if (string.IsNullOrEmpty(text))
			{
				throw new Exception($"Expected key at {i}");
			}
			if (i >= sjson.Length)
			{
				throw new Exception($"Expected ':' at {i}");
			}
			c = sjson[i];
			if (c != ':')
			{
				throw new Exception($"Expected ':' at {i}");
			}
			i++;
			object value = ParseObject(sjson, ref i, dictDelimiters);
			dictionary.Add(text, value);
			i = SkipFormatting(sjson, i);
			if (i >= sjson.Length)
			{
				throw new Exception($"Expected '}}' at {i}");
			}
			c = sjson[i];
			if (c != '}' && c != ',')
			{
				throw new Exception($"Expected '}}' at {i}");
			}
			i++;
		}
		while (c != '}');
		return dictionary;
	}

	public static Dictionary<string, object> ParseDictionary(string sjson, string key)
	{
		object obj = ParseObject(sjson, key);
		if (obj == null || obj is Dictionary<string, object>)
		{
			return obj as Dictionary<string, object>;
		}
		throw new Exception("Key \"" + key + "\" is not a dictionary");
	}

	public static T[] ParseArray<T>(string sjson, string key, Converter<string, T> conversionFunction)
	{
		string[] array = ParseArray(sjson, key);
		if (array == null)
		{
			return null;
		}
		return Array.ConvertAll(array, conversionFunction);
	}

	public static string[] ParseArray(string sjson, string key)
	{
		string text = Parse(sjson, key);
		if (text == null)
		{
			return null;
		}
		return _ParseArrayElements(text);
	}

	private static string[] _ParseArrayElements(string str)
	{
		int num = SkipFormatting(str, 1);
		if (num >= str.Length - 1)
		{
			return new string[0];
		}
		bracketStack.Clear();
		split.Clear();
		for (int i = num; i < str.Length; i++)
		{
			if (i == str.Length - 1)
			{
				string item = Substring(str, num, i - num);
				split.Add(item);
				break;
			}
			char c = str[i];
			if (c == '{' || c == '[')
			{
				bracketStack.Push(c);
			}
			else if (bracketStack.Count > 0 && ((c == '}' && bracketStack.Peek() == '{') || (c == ']' && bracketStack.Peek() == '[')))
			{
				bracketStack.Pop();
			}
			else if (c == ',' && bracketStack.Count == 0)
			{
				int num2 = i - num;
				if (num2 == 0)
				{
					split.Add("");
				}
				else
				{
					string item2 = Substring(str, num, num2);
					split.Add(item2);
				}
				num = SkipFormatting(str, i + 1);
				if (str[num] == ']')
				{
					break;
				}
				i = num - 1;
			}
			else if (num == i && c == '"')
			{
				int num3 = str.IndexOf('"', i + 1);
				if (num3 < 0)
				{
					string text = ((split.Count > 0) ? split[split.Count - 1] : "");
					Utils.LogError("[SlimJson] Failure to find matching end quote after index " + i + ". Last parsed entry = " + text);
					break;
				}
				string item3 = Substring(str, i + 1, num3 - i - 1);
				split.Add(item3);
				i = num3 + 1;
				num = SkipFormatting(str, i + 1);
				if (num >= str.Length || str[num] == ']')
				{
					break;
				}
				i = num - 1;
			}
		}
		return split.ToArray();
	}

	public static string[][] ParseArray2D(string sjson, string key)
	{
		string[] array = ParseArray(sjson, key);
		string[][] array2 = new string[array.Length][];
		for (int i = 0; i < array.Length; i++)
		{
			array2[i] = _ParseArrayElements(array[i]);
		}
		return array2;
	}

	private static int SkipFormatting(string str, int index)
	{
		while (index < str.Length && (str[index] == '\t' || str[index] == '\r' || str[index] == '\n' || str[index] == ' ' || str[index] == '\u2002'))
		{
			index++;
		}
		return index;
	}

	private static string Substring(string str, int startIndex, int length)
	{
		if (length <= 0)
		{
			return "";
		}
		char c = str[startIndex];
		while (c == '\t' || c == '\r' || c == '\n')
		{
			startIndex++;
			length--;
			if (length <= 0)
			{
				return "";
			}
			c = str[startIndex];
		}
		c = str[startIndex + length - 1];
		while (c == '\t' || c == '\r' || c == '\n')
		{
			length--;
			if (length <= 0)
			{
				return "";
			}
			c = str[startIndex + length - 1];
		}
		return str.Substring(startIndex, length);
	}

	public static bool HasKey(string sjson, string key)
	{
		return Parse(sjson, key) != null;
	}

	public static string Parse(string sjson, string key)
	{
		key += ":";
		int length = key.Length;
		int num = -1;
		bracketStack.Clear();
		char c = '.';
		for (int i = 0; i < sjson.Length - length; i++)
		{
			char c2 = sjson[i];
			if (c2 == key[0] && bracketStack.Count == 1 && (c == ' ' || c == '\u2002' || c == ',' || c == '{' || c == '\t' || c2 == '\r' || c == '\n'))
			{
				bool flag = true;
				for (int j = 0; j < key.Length; j++)
				{
					if (sjson[i + j] != key[j])
					{
						flag = false;
						break;
					}
				}
				if (flag)
				{
					num = i;
					break;
				}
			}
			else if (c2 == '{' || c2 == '[')
			{
				bracketStack.Push(c2);
			}
			else if (bracketStack.Count > 0 && ((c2 == '}' && bracketStack.Peek() == '{') || (c2 == ']' && bracketStack.Peek() == '[')))
			{
				bracketStack.Pop();
			}
			c = c2;
		}
		if (num < 0)
		{
			return null;
		}
		num += length;
		char c3 = sjson[num];
		switch (c3)
		{
		case '[':
		case '{':
		{
			bracketStack.Clear();
			bracketStack.Push(c3);
			char c5 = c3;
			for (int l = num + 1; l < sjson.Length; l++)
			{
				char c6 = sjson[l];
				if (c6 == '"')
				{
					c5 = ((c5 != '"') ? '"' : bracketStack.Peek());
				}
				if (c5 == '"')
				{
					continue;
				}
				if ((c6 == '}' && c5 == '{') || (c6 == ']' && c5 == '['))
				{
					bracketStack.Pop();
					if (bracketStack.Count == 0)
					{
						return sjson.Substring(num, l - num + 1);
					}
					c5 = bracketStack.Peek();
				}
				else if (c6 == '{' || c6 == '[')
				{
					bracketStack.Push(c6);
					c5 = c6;
				}
			}
			Console.Write("Failed to parse sjson. " + sjson);
			break;
		}
		case '"':
		{
			int num2 = sjson.IndexOf('"', num + 1);
			return sjson.Substring(num + 1, num2 - num - 1);
		}
		default:
		{
			for (int k = num + 1; k < sjson.Length; k++)
			{
				char c4 = sjson[k];
				if (c4 == ',' || c4 == '}' || c4 == ']')
				{
					return sjson.Substring(num, k - num);
				}
			}
			Console.Write("Failed to parse sjson. " + sjson);
			break;
		}
		}
		return null;
	}

	public static string Parse(string sjson, string key, string defaultValue)
	{
		string text = Parse(sjson, key);
		if (text == null)
		{
			return defaultValue;
		}
		return text;
	}

	public static T Parse<T>(string sjson, string key, Converter<string, T> conversionFunction)
	{
		string text = Parse(sjson, key);
		if (text == null)
		{
			return default(T);
		}
		return conversionFunction(text);
	}

	public static T ParseEnum<T>(string sjson, string key)
	{
		string text = Parse(sjson, key);
		if (text == null)
		{
			return default(T);
		}
		return (T)Enum.Parse(typeof(T), text);
	}

	public static T[] ParseEnumArray<T>(string sjson, string key)
	{
		string[] array = ParseArray(sjson, key);
		if (array == null)
		{
			return null;
		}
		return Array.ConvertAll(array, (string str) => (T)Enum.Parse(typeof(T), str));
	}

	public static int ParseInt(string sjson, string key, int defaultValue = 0)
	{
		string text = Parse(sjson, key);
		if (text == null)
		{
			return defaultValue;
		}
		return Utils.ParseInt(text);
	}

	public static long ParseLong(string sjson, string key, long defaultValue = 0L)
	{
		string text = Parse(sjson, key);
		if (text == null)
		{
			return defaultValue;
		}
		return Utils.ParseLong(text);
	}

	public static bool ParseBool(string sjson, string key, bool defaultValue = false)
	{
		string text = Parse(sjson, key);
		if (text == null)
		{
			return defaultValue;
		}
		return bool.Parse(text);
	}

	public static float ParseFloat(string sjson, string key, float defaultValue = 0f)
	{
		string text = Parse(sjson, key);
		if (text == null)
		{
			return defaultValue;
		}
		return Utils.ParseFloat(text);
	}

	public static DateTime ParseDateTime(string sjson, string key)
	{
		string text = Parse(sjson, key);
		if (text == null)
		{
			Console.Write("Failed to parse DateTime with key " + key + " in sjson string " + sjson);
			return DateTime.Now;
		}
		return _ParseDateTime(text);
	}

	public static DateTime ParseDateTime(string sjson, string key, DateTime defaultValue)
	{
		string text = Parse(sjson, key);
		if (text == null)
		{
			return defaultValue;
		}
		return _ParseDateTime(text);
	}

	private static DateTime _ParseDateTime(string result)
	{
		if (result.Length == 8)
		{
			try
			{
				int year = Utils.ParseInt(result.Substring(0, 4));
				int month = Utils.ParseInt(result.Substring(4, 2));
				int day = Utils.ParseInt(result.Substring(6, 2));
				return new DateTime(year, month, day);
			}
			catch
			{
			}
		}
		return DateTime.Parse(result, CultureInfo.InvariantCulture);
	}

	public static Color ParseColor(string sjson, string key)
	{
		return ParseColor(sjson, key, Color.white);
	}

	public static Color ParseColor(string sjson, string key, Color defaultValue)
	{
		string text = Parse(sjson, key);
		if (text == null)
		{
			return defaultValue;
		}
		Color color = default(Color);
		if (ColorUtility.TryParseHtmlString(text, out color))
		{
			return color;
		}
		return defaultValue;
	}

	private static StringBuilder GetStringBuilder()
	{
		if (stringBuilderPool.Count > 0)
		{
			return stringBuilderPool.Pop();
		}
		return new StringBuilder(1024);
	}

	private static void RecycleStringBuilder(StringBuilder sb)
	{
		sb.Length = 0;
		stringBuilderPool.Push(sb);
	}
}
