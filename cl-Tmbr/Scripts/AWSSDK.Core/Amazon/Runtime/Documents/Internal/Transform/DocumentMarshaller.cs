using System;
using System.Collections.Generic;
using System.Text.Json;

namespace Amazon.Runtime.Documents.Internal.Transform
{
	public class DocumentMarshaller
	{
		public static DocumentMarshaller Instance { get; } = new DocumentMarshaller();

		private DocumentMarshaller()
		{
		}

		public void Write(Utf8JsonWriter writer, Document doc)
		{
			switch (doc.Type)
			{
			case DocumentType.Null:
				writer.WriteNullValue();
				break;
			case DocumentType.Bool:
				writer.WriteBooleanValue(doc.AsBool());
				break;
			case DocumentType.Double:
				writer.WriteNumberValue(doc.AsDouble());
				break;
			case DocumentType.Int:
				writer.WriteNumberValue(doc.AsInt());
				break;
			case DocumentType.String:
				writer.WriteStringValue(doc.AsString());
				break;
			case DocumentType.List:
				writer.WriteStartArray();
				foreach (Document item in doc.AsList())
				{
					Write(writer, item);
				}
				writer.WriteEndArray();
				break;
			case DocumentType.Long:
				writer.WriteNumberValue(doc.AsLong());
				break;
			case DocumentType.Dictionary:
				writer.WriteStartObject();
				foreach (KeyValuePair<string, Document> item2 in doc.AsDictionary())
				{
					writer.WritePropertyName(item2.Key);
					Write(writer, item2.Value);
				}
				writer.WriteEndObject();
				break;
			default:
				throw new ArgumentException($"Unknown Document Type: {doc.Type}");
			}
		}
	}
}
