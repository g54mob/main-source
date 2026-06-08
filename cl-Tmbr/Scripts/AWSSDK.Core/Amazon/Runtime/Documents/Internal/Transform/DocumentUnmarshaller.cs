using System;
using System.Collections.Generic;
using System.Text.Json;
using Amazon.Runtime.Internal.Transform;
using Amazon.Runtime.Internal.Util;

namespace Amazon.Runtime.Documents.Internal.Transform
{
	public class DocumentUnmarshaller : IJsonUnmarshaller<Document, JsonUnmarshallerContext>
	{
		public static DocumentUnmarshaller Instance { get; } = new DocumentUnmarshaller();

		private DocumentUnmarshaller()
		{
		}

		public Document Unmarshall(JsonUnmarshallerContext context, ref StreamingUtf8JsonReader reader)
		{
			context.Read(ref reader);
			switch (context.CurrentTokenType)
			{
			case JsonTokenType.None:
			case JsonTokenType.Null:
				return default(Document);
			case JsonTokenType.True:
			case JsonTokenType.False:
				return new Document(reader.Reader.GetBoolean());
			case JsonTokenType.Number:
			{
				if (reader.Reader.TryGetInt32(out var value2))
				{
					return new Document(value2);
				}
				if (reader.Reader.TryGetInt64(out var value3))
				{
					return new Document(value3);
				}
				if (reader.Reader.TryGetDouble(out var value4))
				{
					return new Document(value4);
				}
				throw new JsonException("Unsupported number type.");
			}
			case JsonTokenType.String:
				return new Document(reader.Reader.GetString());
			case JsonTokenType.StartArray:
			{
				List<Document> list = new List<Document>();
				while (!context.Peek(JsonTokenType.EndArray, ref reader))
				{
					list.Add(Unmarshall(context, ref reader));
				}
				context.Read(ref reader);
				return new Document(list);
			}
			case JsonTokenType.StartObject:
			{
				Dictionary<string, Document> dictionary = new Dictionary<string, Document>();
				while (!context.Peek(JsonTokenType.EndObject, ref reader))
				{
					string key = StringUnmarshaller.Instance.Unmarshall(context, ref reader);
					Document value = Unmarshall(context, ref reader);
					dictionary.Add(key, value);
				}
				context.Read(ref reader);
				return new Document(dictionary);
			}
			default:
				throw new ArgumentException($"Unknown JSON type: {context.CurrentTokenType}");
			}
		}
	}
}
