using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace LightJson.Serialization
{
	public sealed class JsonWriter : IDisposable
	{
		private int indent;

		private bool isNewLine;

		private TextWriter writer;

		private HashSet<IEnumerable<JsonValue>> renderingCollections;

		public string IndentString { get; set; }

		public string SpacingString { get; set; }

		public string NewLineString { get; set; }

		public bool SortObjects { get; set; }

		public JsonWriter()
			: this(pretty: false)
		{
		}

		public JsonWriter(bool pretty)
		{
			if (pretty)
			{
				IndentString = "\t";
				SpacingString = " ";
				NewLineString = "\n";
			}
		}

		private void Initialize()
		{
			indent = 0;
			isNewLine = true;
			writer = new StringWriter();
			renderingCollections = new HashSet<IEnumerable<JsonValue>>();
		}

		private void Write(string text)
		{
			if (isNewLine)
			{
				isNewLine = false;
				WriteIndentation();
			}
			writer.Write(text);
		}

		private void WriteEncodedJsonValue(JsonValue value)
		{
			switch (value.Type)
			{
			case JsonValueType.Null:
				Write("null");
				break;
			case JsonValueType.Boolean:
				Write(value.AsString);
				break;
			case JsonValueType.Number:
				Write(((double)value).ToString(CultureInfo.InvariantCulture));
				break;
			case JsonValueType.String:
				WriteEncodedString(value);
				break;
			case JsonValueType.Object:
				Write($"JsonObject[{value.AsJsonObject.Count}]");
				break;
			case JsonValueType.Array:
				Write($"JsonArray[{value.AsJsonArray.Count}]");
				break;
			default:
				throw new InvalidOperationException("Invalid value type.");
			}
		}

		private void WriteEncodedString(string text)
		{
			Write("\"");
			foreach (char c in text)
			{
				switch (c)
				{
				case '\\':
					writer.Write("\\\\");
					break;
				case '"':
					writer.Write("\\\"");
					break;
				case '/':
					writer.Write("\\/");
					break;
				case '\b':
					writer.Write("\\b");
					break;
				case '\f':
					writer.Write("\\f");
					break;
				case '\n':
					writer.Write("\\n");
					break;
				case '\r':
					writer.Write("\\r");
					break;
				case '\t':
					writer.Write("\\t");
					break;
				default:
					writer.Write(c);
					break;
				}
			}
			writer.Write("\"");
		}

		private void WriteIndentation()
		{
			for (int i = 0; i < indent; i++)
			{
				Write(IndentString);
			}
		}

		private void WriteSpacing()
		{
			Write(SpacingString);
		}

		private void WriteLine()
		{
			Write(NewLineString);
			isNewLine = true;
		}

		private void WriteLine(string line)
		{
			Write(line);
			WriteLine();
		}

		private void AddRenderingCollection(IEnumerable<JsonValue> value)
		{
			if (!renderingCollections.Add(value))
			{
				throw new JsonSerializationException(JsonSerializationException.ErrorType.CircularReference);
			}
		}

		private void RemoveRenderingCollection(IEnumerable<JsonValue> value)
		{
			renderingCollections.Remove(value);
		}

		private void Render(JsonValue value)
		{
			switch (value.Type)
			{
			case JsonValueType.Null:
			case JsonValueType.Boolean:
			case JsonValueType.Number:
			case JsonValueType.String:
				WriteEncodedJsonValue(value);
				break;
			case JsonValueType.Object:
				Render((JsonObject)value);
				break;
			case JsonValueType.Array:
				Render((JsonArray)value);
				break;
			default:
				throw new JsonSerializationException(JsonSerializationException.ErrorType.InvalidValueType);
			}
		}

		private void Render(JsonArray value)
		{
			AddRenderingCollection(value);
			WriteLine("[");
			indent++;
			using (IEnumerator<JsonValue> enumerator = value.GetEnumerator())
			{
				bool flag = enumerator.MoveNext();
				while (flag)
				{
					Render(enumerator.Current);
					flag = enumerator.MoveNext();
					if (flag)
					{
						WriteLine(",");
					}
					else
					{
						WriteLine();
					}
				}
			}
			indent--;
			Write("]");
			RemoveRenderingCollection(value);
		}

		private void Render(JsonObject value)
		{
			AddRenderingCollection(value);
			WriteLine("{");
			indent++;
			using (IEnumerator<KeyValuePair<string, JsonValue>> enumerator = GetJsonObjectEnumerator(value))
			{
				bool flag = enumerator.MoveNext();
				while (flag)
				{
					WriteEncodedString(enumerator.Current.Key);
					Write(":");
					WriteSpacing();
					Render(enumerator.Current.Value);
					flag = enumerator.MoveNext();
					if (flag)
					{
						WriteLine(",");
					}
					else
					{
						WriteLine();
					}
				}
			}
			indent--;
			Write("}");
			RemoveRenderingCollection(value);
		}

		private IEnumerator<KeyValuePair<string, JsonValue>> GetJsonObjectEnumerator(JsonObject jsonObject)
		{
			if (SortObjects)
			{
				SortedDictionary<string, JsonValue> sortedDictionary = new SortedDictionary<string, JsonValue>(StringComparer.Ordinal);
				foreach (KeyValuePair<string, JsonValue> item in jsonObject)
				{
					sortedDictionary.Add(item.Key, item.Value);
				}
				return sortedDictionary.GetEnumerator();
			}
			return jsonObject.GetEnumerator();
		}

		public string Serialize(JsonValue jsonValue)
		{
			Initialize();
			Render(jsonValue);
			return writer.ToString();
		}

		public void Dispose()
		{
			if (writer != null)
			{
				writer.Dispose();
			}
		}

		private static bool IsValidNumber(double number)
		{
			if (!double.IsNaN(number))
			{
				return !double.IsInfinity(number);
			}
			return false;
		}
	}
}
