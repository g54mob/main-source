using System;
using System.Collections;
using System.Globalization;
using System.Reflection;
using System.Text;

namespace TinyJSON
{
	public sealed class Encoder
	{
		private static readonly Type includeAttrType = typeof(Include);

		private static readonly Type excludeAttrType = typeof(Exclude);

		private static readonly Type typeHintAttrType = typeof(TypeHint);

		private StringBuilder builder;

		private EncodeOptions options;

		private int indent;

		private bool PrettyPrintEnabled => (options & EncodeOptions.PrettyPrint) == EncodeOptions.PrettyPrint;

		private bool TypeHintsEnabled => (options & EncodeOptions.NoTypeHints) != EncodeOptions.NoTypeHints;

		private bool IncludePublicPropertiesEnabled => (options & EncodeOptions.IncludePublicProperties) == EncodeOptions.IncludePublicProperties;

		private Encoder(EncodeOptions options)
		{
			this.options = options;
			builder = new StringBuilder();
			indent = 0;
		}

		public static string Encode(object obj)
		{
			return Encode(obj, EncodeOptions.None);
		}

		public static string Encode(object obj, EncodeOptions options)
		{
			Encoder encoder = new Encoder(options);
			encoder.EncodeValue(obj, forceTypeHint: false);
			return encoder.builder.ToString();
		}

		private void EncodeValue(object value, bool forceTypeHint)
		{
			if (value == null)
			{
				builder.Append("null");
			}
			else if (value is string value2)
			{
				EncodeString(value2);
			}
			else if (value is bool)
			{
				builder.Append(value.ToString().ToLower());
			}
			else if (value is Enum)
			{
				EncodeString(value.ToString());
			}
			else if (value is Array value3)
			{
				EncodeArray(value3, forceTypeHint);
			}
			else if (value is IList value4)
			{
				EncodeList(value4, forceTypeHint);
			}
			else if (value is IDictionary value5)
			{
				EncodeDictionary(value5, forceTypeHint);
			}
			else if (value is char)
			{
				EncodeString(value.ToString());
			}
			else
			{
				EncodeOther(value, forceTypeHint);
			}
		}

		private void EncodeObject(object value, bool forceTypeHint)
		{
			Type type = value.GetType();
			AppendOpenBrace();
			forceTypeHint = forceTypeHint || TypeHintsEnabled;
			bool includePublicPropertiesEnabled = IncludePublicPropertiesEnabled;
			bool firstItem = !forceTypeHint;
			if (forceTypeHint)
			{
				if (PrettyPrintEnabled)
				{
					AppendIndent();
				}
				EncodeString("@type");
				AppendColon();
				EncodeString(type.FullName);
				firstItem = false;
			}
			FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
			foreach (FieldInfo fieldInfo in fields)
			{
				bool forceTypeHint2 = false;
				bool flag = fieldInfo.IsPublic;
				object[] customAttributes = fieldInfo.GetCustomAttributes(inherit: true);
				foreach (object obj in customAttributes)
				{
					if (excludeAttrType.IsAssignableFrom(obj.GetType()))
					{
						flag = false;
					}
					if (includeAttrType.IsAssignableFrom(obj.GetType()))
					{
						flag = true;
					}
					if (typeHintAttrType.IsAssignableFrom(obj.GetType()))
					{
						forceTypeHint2 = true;
					}
				}
				if (flag)
				{
					AppendComma(firstItem);
					EncodeString(fieldInfo.Name);
					AppendColon();
					EncodeValue(fieldInfo.GetValue(value), forceTypeHint2);
					firstItem = false;
				}
			}
			PropertyInfo[] properties = type.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
			foreach (PropertyInfo propertyInfo in properties)
			{
				if (!propertyInfo.CanRead)
				{
					continue;
				}
				bool forceTypeHint3 = false;
				bool flag2 = includePublicPropertiesEnabled;
				object[] customAttributes = propertyInfo.GetCustomAttributes(inherit: true);
				foreach (object obj2 in customAttributes)
				{
					if (excludeAttrType.IsAssignableFrom(obj2.GetType()))
					{
						flag2 = false;
					}
					if (includeAttrType.IsAssignableFrom(obj2.GetType()))
					{
						flag2 = true;
					}
					if (typeHintAttrType.IsAssignableFrom(obj2.GetType()))
					{
						forceTypeHint3 = true;
					}
				}
				if (flag2)
				{
					AppendComma(firstItem);
					EncodeString(propertyInfo.Name);
					AppendColon();
					EncodeValue(propertyInfo.GetValue(value, null), forceTypeHint3);
					firstItem = false;
				}
			}
			AppendCloseBrace();
		}

		private void EncodeDictionary(IDictionary value, bool forceTypeHint)
		{
			if (value.Count == 0)
			{
				builder.Append("{}");
				return;
			}
			AppendOpenBrace();
			bool firstItem = true;
			foreach (object key in value.Keys)
			{
				AppendComma(firstItem);
				EncodeString(key.ToString());
				AppendColon();
				EncodeValue(value[key], forceTypeHint);
				firstItem = false;
			}
			AppendCloseBrace();
		}

		private void EncodeList(IList value, bool forceTypeHint)
		{
			if (value.Count == 0)
			{
				builder.Append("[]");
				return;
			}
			AppendOpenBracket();
			bool firstItem = true;
			foreach (object item in value)
			{
				AppendComma(firstItem);
				EncodeValue(item, forceTypeHint);
				firstItem = false;
			}
			AppendCloseBracket();
		}

		private void EncodeArray(Array value, bool forceTypeHint)
		{
			if (value.Rank == 1)
			{
				EncodeList(value, forceTypeHint);
				return;
			}
			int[] indices = new int[value.Rank];
			EncodeArrayRank(value, 0, indices, forceTypeHint);
		}

		private void EncodeArrayRank(Array value, int rank, int[] indices, bool forceTypeHint)
		{
			AppendOpenBracket();
			int lowerBound = value.GetLowerBound(rank);
			int upperBound = value.GetUpperBound(rank);
			if (rank == value.Rank - 1)
			{
				for (int i = lowerBound; i <= upperBound; i++)
				{
					indices[rank] = i;
					AppendComma(i == lowerBound);
					EncodeValue(value.GetValue(indices), forceTypeHint);
				}
			}
			else
			{
				for (int j = lowerBound; j <= upperBound; j++)
				{
					indices[rank] = j;
					AppendComma(j == lowerBound);
					EncodeArrayRank(value, rank + 1, indices, forceTypeHint);
				}
			}
			AppendCloseBracket();
		}

		private void EncodeString(string value)
		{
			builder.Append('"');
			char[] array = value.ToCharArray();
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
				if (num >= 32 && num <= 126)
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

		private void EncodeOther(object value, bool forceTypeHint)
		{
			if (value is float || value is double || value is int || value is uint || value is long || value is sbyte || value is byte || value is short || value is ushort || value is ulong || value is decimal)
			{
				builder.Append(string.Format(CultureInfo.InvariantCulture, "{0}", value));
			}
			else
			{
				EncodeObject(value, forceTypeHint);
			}
		}

		private void AppendIndent()
		{
			for (int i = 0; i < indent; i++)
			{
				builder.Append('\t');
			}
		}

		private void AppendOpenBrace()
		{
			builder.Append('{');
			if (PrettyPrintEnabled)
			{
				builder.Append('\n');
				indent++;
			}
		}

		private void AppendCloseBrace()
		{
			if (PrettyPrintEnabled)
			{
				builder.Append('\n');
				indent--;
				AppendIndent();
			}
			builder.Append('}');
		}

		private void AppendOpenBracket()
		{
			builder.Append('[');
			if (PrettyPrintEnabled)
			{
				builder.Append('\n');
				indent++;
			}
		}

		private void AppendCloseBracket()
		{
			if (PrettyPrintEnabled)
			{
				builder.Append('\n');
				indent--;
				AppendIndent();
			}
			builder.Append(']');
		}

		private void AppendComma(bool firstItem)
		{
			if (!firstItem)
			{
				builder.Append(',');
				if (PrettyPrintEnabled)
				{
					builder.Append('\n');
				}
			}
			if (PrettyPrintEnabled)
			{
				AppendIndent();
			}
		}

		private void AppendColon()
		{
			builder.Append(':');
			if (PrettyPrintEnabled)
			{
				builder.Append(' ');
			}
		}
	}
}
