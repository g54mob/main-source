using System.Collections.Generic;
using System.Text.Json;
using Sentry.Extensibility;
using Sentry.Internal;
using Sentry.Internal.Extensions;

namespace Sentry.Protocol
{
	public sealed class Response : ISentryJsonSerializable, ICloneable<Response>, IUpdatable<Response>, IUpdatable
	{
		public const string Type = "response";

		internal Dictionary<string, string>? InternalHeaders { get; private set; }

		public long? BodySize { get; set; }

		public string? Cookies { get; set; }

		public object? Data { get; set; }

		public IDictionary<string, string> Headers => InternalHeaders ?? (InternalHeaders = new Dictionary<string, string>());

		public short? StatusCode { get; set; }

		internal void AddHeaders(IEnumerable<KeyValuePair<string, IEnumerable<string>>> headers)
		{
			foreach (KeyValuePair<string, IEnumerable<string>> header in headers)
			{
				Headers.Add(header.Key, string.Join("; ", header.Value));
			}
		}

		public Response Clone()
		{
			Response response = new Response();
			response.UpdateFrom(this);
			return response;
		}

		public void UpdateFrom(Response source)
		{
			if (!BodySize.HasValue)
			{
				long? num = (BodySize = source.BodySize);
			}
			if (Cookies == null)
			{
				string text = (Cookies = source.Cookies);
			}
			if (Data == null)
			{
				object obj = (Data = source.Data);
			}
			if (!StatusCode.HasValue)
			{
				short? num2 = (StatusCode = source.StatusCode);
			}
			source.InternalHeaders?.TryCopyTo(Headers);
		}

		public void UpdateFrom(object source)
		{
			if (source is Response source2)
			{
				UpdateFrom(source2);
			}
		}

		public void WriteTo(Utf8JsonWriter writer, IDiagnosticLogger? logger)
		{
			writer.WriteStartObject();
			writer.WriteString("type", "response");
			writer.WriteNumberIfNotNull("body_size", BodySize);
			writer.WriteStringIfNotWhiteSpace("cookies", Cookies);
			writer.WriteDynamicIfNotNull("data", Data, logger);
			writer.WriteStringDictionaryIfNotEmpty("headers", InternalHeaders);
			writer.WriteNumberIfNotNull("status_code", StatusCode);
			writer.WriteEndObject();
		}

		public static Response FromJson(JsonElement json)
		{
			long? bodySize = json.GetPropertyOrNull("body_size")?.GetInt64();
			string cookies = json.GetPropertyOrNull("cookies")?.GetString();
			object data = json.GetPropertyOrNull("data")?.GetDynamicOrNull();
			Dictionary<string, string> dictionary = json.GetPropertyOrNull("headers")?.GetStringDictionaryOrNull();
			short? statusCode = json.GetPropertyOrNull("status_code")?.GetInt16();
			return new Response
			{
				BodySize = bodySize,
				Cookies = cookies,
				Data = data,
				InternalHeaders = dictionary?.WhereNotNullValue().ToDict(),
				StatusCode = statusCode
			};
		}
	}
}
