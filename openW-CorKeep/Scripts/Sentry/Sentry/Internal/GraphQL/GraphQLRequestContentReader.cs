using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Sentry.Internal.GraphQL
{
	internal static class GraphQLRequestContentReader
	{
		private const string OperationNameKey = "operationName";

		private const string QueryKey = "query";

		public static IReadOnlyDictionary<string, object> Read(string requestContent)
		{
			Utf8JsonReader utf8JsonReader = new Utf8JsonReader(Encoding.UTF8.GetBytes(requestContent));
			if (!utf8JsonReader.Read() || utf8JsonReader.TokenType != JsonTokenType.StartObject)
			{
				throw new JsonException("Expected start of object");
			}
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			while (utf8JsonReader.Read())
			{
				if (utf8JsonReader.TokenType == JsonTokenType.EndObject)
				{
					return dictionary;
				}
				if (utf8JsonReader.TokenType != JsonTokenType.PropertyName)
				{
					throw new JsonException("Expected property name");
				}
				string text = utf8JsonReader.GetString();
				if (!utf8JsonReader.Read())
				{
					throw new JsonException("unexpected end of data");
				}
				if (text == "query" || text == "operationName")
				{
					dictionary[text] = utf8JsonReader.GetString();
				}
				else
				{
					utf8JsonReader.Skip();
				}
			}
			throw new JsonException("unexpected end of data");
		}
	}
}
