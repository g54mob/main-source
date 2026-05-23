using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Muna.API
{
	public sealed class DotNetClient : MunaClient
	{
		private readonly HttpClient client;

		public DotNetClient(string url, string? accessKey = null)
			: base(url.TrimEnd('/'), accessKey)
		{
			client = new HttpClient();
			ProductInfoHeaderValue item = new ProductInfoHeaderValue("MunaDotNet", "0.0.51");
			client.DefaultRequestHeaders.UserAgent.Add(item);
		}

		public override async Task<T?> Request<T>(string method, string path, Dictionary<string, object?>? payload = null)
		{
			using HttpResponseMessage response = await SendAsync(method, path, payload);
			return JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
		}

		public override async IAsyncEnumerable<T> Stream<T>(string method, string path, Dictionary<string, object?>? payload = null)
		{
			using HttpResponseMessage response = await SendAsync(method, path, payload, HttpCompletionOption.ResponseHeadersRead);
			using Stream stream = await response.Content.ReadAsStreamAsync();
			using StreamReader reader = new StreamReader(stream);
			string eventName = null;
			string data = string.Empty;
			while (true)
			{
				string text = await reader.ReadLineAsync();
				if (text == null)
				{
					break;
				}
				text = text.Trim();
				if (!string.IsNullOrEmpty(text))
				{
					if (text.StartsWith("event:"))
					{
						eventName = text.Substring("event:".Length).Trim();
					}
					else if (text.StartsWith("data:"))
					{
						string text2 = text.Substring("data:".Length).Trim();
						data = (string.IsNullOrEmpty(data) ? text2 : (data + "\n" + text2));
					}
				}
				else
				{
					if (eventName != null)
					{
						yield return ParseSSEEvent<T>(eventName, data);
					}
					eventName = null;
					data = string.Empty;
				}
			}
			if (eventName != null || !string.IsNullOrEmpty(data))
			{
				yield return ParseSSEEvent<T>(eventName, data);
			}
		}

		public override Task<Stream> Download(string url)
		{
			return client.GetStreamAsync(url);
		}

		public override async Task Upload(Stream stream, string url, string? mime = null)
		{
			using StreamContent content = new StreamContent(stream);
			content.Headers.ContentType = new MediaTypeHeaderValue(mime ?? "application/octet-stream");
			using HttpResponseMessage httpResponseMessage = await client.PutAsync(url, content);
			httpResponseMessage.EnsureSuccessStatusCode();
		}

		private async Task<HttpResponseMessage> SendAsync(string method, string path, Dictionary<string, object?>? payload, HttpCompletionOption completionOption = HttpCompletionOption.ResponseContentRead)
		{
			using HttpRequestMessage message = new HttpRequestMessage(new HttpMethod(method), url + path);
			if (!string.IsNullOrEmpty(accessKey))
			{
				message.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessKey);
			}
			if (completionOption == HttpCompletionOption.ResponseHeadersRead)
			{
				message.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("text/event-stream"));
			}
			if (payload != null)
			{
				JsonSerializerSettings settings = new JsonSerializerSettings
				{
					NullValueHandling = NullValueHandling.Ignore
				};
				string content = JsonConvert.SerializeObject(payload, settings);
				message.Content = new StringContent(content, Encoding.UTF8, "application/json");
			}
			HttpResponseMessage response = await client.SendAsync(message, completionOption);
			if (response.StatusCode >= HttpStatusCode.BadRequest)
			{
				using (response)
				{
					ErrorResponse? errorResponse = JsonConvert.DeserializeObject<ErrorResponse>(await response.Content.ReadAsStringAsync());
					object obj;
					if (errorResponse == null)
					{
						obj = null;
					}
					else
					{
						ErrorResponse.Error[] errors = errorResponse.errors;
						obj = ((errors == null) ? null : errors[0]?.message);
					}
					if (obj == null)
					{
						obj = "An unknown error occurred";
					}
					throw new MunaAPIException((string)obj, (int)response.StatusCode);
				}
			}
			return response;
		}

		private static T ParseSSEEvent<T>(string? eventName, string data) where T : class
		{
			return new JObject
			{
				["event"] = eventName,
				["data"] = JToken.Parse(data)
			}.ToObject<T>();
		}
	}
}
