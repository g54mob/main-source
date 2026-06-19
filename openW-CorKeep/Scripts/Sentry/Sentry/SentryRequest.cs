using System.Collections.Generic;
using System.Text.Json;
using Sentry.Extensibility;
using Sentry.Internal.Extensions;

namespace Sentry
{
	public sealed class SentryRequest : ISentryJsonSerializable
	{
		internal Dictionary<string, string>? InternalEnv { get; private set; }

		internal Dictionary<string, string>? InternalOther { get; private set; }

		internal Dictionary<string, string>? InternalHeaders { get; private set; }

		public string? Url { get; set; }

		public string? Method { get; set; }

		public string? ApiTarget { get; set; }

		public object? Data { get; set; }

		public string? QueryString { get; set; }

		public string? Cookies { get; set; }

		public IDictionary<string, string> Headers => InternalHeaders ?? (InternalHeaders = new Dictionary<string, string>());

		public IDictionary<string, string> Env => InternalEnv ?? (InternalEnv = new Dictionary<string, string>());

		public IDictionary<string, string> Other => InternalOther ?? (InternalOther = new Dictionary<string, string>());

		internal void AddHeaders(IEnumerable<KeyValuePair<string, IEnumerable<string>>> headers)
		{
			foreach (KeyValuePair<string, IEnumerable<string>> header in headers)
			{
				Headers.Add(header.Key, string.Join("; ", header.Value));
			}
		}

		public SentryRequest Clone()
		{
			SentryRequest sentryRequest = new SentryRequest();
			CopyTo(sentryRequest);
			return sentryRequest;
		}

		internal void CopyTo(SentryRequest? request)
		{
			if (request != null)
			{
				SentryRequest sentryRequest = request;
				if (sentryRequest.ApiTarget == null)
				{
					string text = (sentryRequest.ApiTarget = ApiTarget);
				}
				sentryRequest = request;
				if (sentryRequest.Url == null)
				{
					string text = (sentryRequest.Url = Url);
				}
				sentryRequest = request;
				if (sentryRequest.Method == null)
				{
					string text = (sentryRequest.Method = Method);
				}
				sentryRequest = request;
				if (sentryRequest.Data == null)
				{
					object obj = (sentryRequest.Data = Data);
				}
				sentryRequest = request;
				if (sentryRequest.QueryString == null)
				{
					string text = (sentryRequest.QueryString = QueryString);
				}
				sentryRequest = request;
				if (sentryRequest.Cookies == null)
				{
					string text = (sentryRequest.Cookies = Cookies);
				}
				InternalEnv?.TryCopyTo(request.Env);
				InternalOther?.TryCopyTo(request.Other);
				InternalHeaders?.TryCopyTo(request.Headers);
			}
		}

		public void WriteTo(Utf8JsonWriter writer, IDiagnosticLogger? logger)
		{
			writer.WriteStartObject();
			writer.WriteStringDictionaryIfNotEmpty("env", InternalEnv);
			writer.WriteStringDictionaryIfNotEmpty("other", InternalOther);
			writer.WriteStringDictionaryIfNotEmpty("headers", InternalHeaders);
			writer.WriteStringIfNotWhiteSpace("url", Url);
			writer.WriteStringIfNotWhiteSpace("method", Method);
			writer.WriteDynamicIfNotNull("data", Data, logger);
			writer.WriteStringIfNotWhiteSpace("query_string", QueryString);
			writer.WriteStringIfNotWhiteSpace("cookies", Cookies);
			writer.WriteEndObject();
		}

		public static SentryRequest FromJson(JsonElement json)
		{
			Dictionary<string, string> dictionary = json.GetPropertyOrNull("env")?.GetStringDictionaryOrNull();
			Dictionary<string, string> dictionary2 = json.GetPropertyOrNull("other")?.GetStringDictionaryOrNull();
			Dictionary<string, string> dictionary3 = json.GetPropertyOrNull("headers")?.GetStringDictionaryOrNull();
			string url = json.GetPropertyOrNull("url")?.GetString();
			string method = json.GetPropertyOrNull("method")?.GetString();
			object data = json.GetPropertyOrNull("data")?.GetDynamicOrNull();
			string queryString = json.GetPropertyOrNull("query_string")?.GetString();
			string cookies = json.GetPropertyOrNull("cookies")?.GetString();
			return new SentryRequest
			{
				InternalEnv = dictionary?.WhereNotNullValue().ToDict(),
				InternalOther = dictionary2?.WhereNotNullValue().ToDict(),
				InternalHeaders = dictionary3?.WhereNotNullValue().ToDict(),
				Url = url,
				Method = method,
				Data = data,
				QueryString = queryString,
				Cookies = cookies
			};
		}
	}
}
