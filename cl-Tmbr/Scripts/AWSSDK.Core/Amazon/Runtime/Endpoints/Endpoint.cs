using System;
using System.Collections.Generic;
using System.Text.Json;

namespace Amazon.Runtime.Endpoints
{
	public class Endpoint
	{
		public string URL { get; set; }

		public IPropertyBag Attributes { get; set; }

		public IDictionary<string, IList<string>> Headers { get; set; }

		public Endpoint(string url)
			: this(url, null, null)
		{
		}

		public Endpoint(string url, string attributesJson, string headersJson)
		{
			if (string.IsNullOrEmpty(url))
			{
				throw new ArgumentNullException("url");
			}
			URL = url;
			if (!string.IsNullOrEmpty(attributesJson))
			{
				using JsonDocument jsonDocument = JsonDocument.Parse(attributesJson);
				JsonElement rootElement = jsonDocument.RootElement;
				Attributes = PropertyBag.FromJsonElement(rootElement);
			}
			if (string.IsNullOrEmpty(headersJson))
			{
				return;
			}
			using JsonDocument jsonDocument2 = JsonDocument.Parse(headersJson);
			JsonElement rootElement2 = jsonDocument2.RootElement;
			Headers = new Dictionary<string, IList<string>>();
			foreach (JsonProperty item in rootElement2.EnumerateObject())
			{
				List<string> list = new List<string>();
				if (rootElement2.TryGetProperty(item.Name, out var value) && value.ValueKind == JsonValueKind.Array)
				{
					foreach (JsonElement item2 in value.EnumerateArray())
					{
						list.Add(item2.GetString());
					}
				}
				Headers.Add(item.Name, list);
			}
		}
	}
}
