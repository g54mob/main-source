using System;
using System.Collections;
using System.Globalization;
using System.Text;

namespace TH20.Analytics
{
	internal sealed class MiniJSONSerializer
	{
		private readonly StringBuilder _builder;

		private MiniJSONSerializer()
		{
			_builder = new StringBuilder();
		}

		public static string Serialize(object obj)
		{
			MiniJSONSerializer miniJSONSerializer = new MiniJSONSerializer();
			miniJSONSerializer.SerializeValue(obj);
			return miniJSONSerializer._builder.ToString();
		}

		private void SerializeValue(object value)
		{
			if (value == null)
			{
				_builder.Append("null");
			}
			else if (value is string str)
			{
				SerializeString(str);
			}
			else if (value is bool)
			{
				_builder.Append(((bool)value) ? "true" : "false");
			}
			else if (value is IList anArray)
			{
				SerializeArray(anArray);
			}
			else if (value is IDictionary obj)
			{
				SerializeObject(obj);
			}
			else if (value is IDictionaryContainer dictionaryContainer)
			{
				IDictionary obj2;
				if ((obj2 = dictionaryContainer.AsIDictionary()) != null)
				{
					SerializeObject(obj2);
				}
			}
			else if (value is char)
			{
				SerializeString(new string((char)value, 1));
			}
			else
			{
				SerializeOther(value);
			}
		}

		private void SerializeObject(IDictionary obj)
		{
			bool flag = true;
			_builder.Append('{');
			foreach (object key in obj.Keys)
			{
				if (!flag)
				{
					_builder.Append(',');
				}
				SerializeString(key.ToString());
				_builder.Append(':');
				SerializeValue(obj[key]);
				flag = false;
			}
			_builder.Append('}');
		}

		private void SerializeArray(IList anArray)
		{
			_builder.Append('[');
			bool flag = true;
			for (int i = 0; i < anArray.Count; i++)
			{
				object value = anArray[i];
				if (!flag)
				{
					_builder.Append(',');
				}
				SerializeValue(value);
				flag = false;
			}
			_builder.Append(']');
		}

		private void SerializeString(string str)
		{
			_builder.Append('"');
			char[] array = str.ToCharArray();
			foreach (char c in array)
			{
				switch (c)
				{
				case '"':
					_builder.Append("\\\"");
					continue;
				case '\\':
					_builder.Append("\\\\");
					continue;
				case '\b':
					_builder.Append("\\b");
					continue;
				case '\f':
					_builder.Append("\\f");
					continue;
				case '\n':
					_builder.Append("\\n");
					continue;
				case '\r':
					_builder.Append("\\r");
					continue;
				case '\t':
					_builder.Append("\\t");
					continue;
				}
				int num = Convert.ToInt32(c);
				if (num >= 32 && num <= 126)
				{
					_builder.Append(c);
					continue;
				}
				_builder.Append("\\u");
				_builder.Append(num.ToString("x4"));
			}
			_builder.Append('"');
		}

		private void SerializeOther(object value)
		{
			if (value is float)
			{
				_builder.Append(((float)value).ToString("R", CultureInfo.InvariantCulture));
			}
			else if (value is int || value is uint || value is long || value is sbyte || value is byte || value is short || value is ushort || value is ulong)
			{
				_builder.Append(value);
			}
			else if (value is double || value is decimal)
			{
				_builder.Append(Convert.ToDouble(value).ToString("R", CultureInfo.InvariantCulture));
			}
			else
			{
				SerializeString(value.ToString());
			}
		}
	}
}
