using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine.Networking;

namespace Muna.API
{
	internal class UnityClient : MunaClient
	{
		private class SSEDownloadHandler : DownloadHandlerScript
		{
			public readonly Queue<string> lines = new Queue<string>();

			private string buffer = string.Empty;

			protected override bool ReceiveData(byte[] data, int dataLength)
			{
				buffer += Encoding.UTF8.GetString(data, 0, dataLength);
				while (true)
				{
					int num = buffer.IndexOf('\n');
					if (num < 0)
					{
						break;
					}
					lines.Enqueue(buffer.Substring(0, num));
					buffer = buffer.Substring(num + 1);
				}
				return true;
			}

			protected override void CompleteContent()
			{
				if (buffer.Length > 0)
				{
					lines.Enqueue(buffer);
					buffer = string.Empty;
				}
			}
		}

		private const int Timeout = 300;

		public UnityClient(string url, string? accessKey)
			: base(url.TrimEnd('/'), accessKey)
		{
		}

		public override async Task<T?> Request<T>(string method, string path, Dictionary<string, object?>? payload = null)
		{
			using UnityWebRequest client = new UnityWebRequest(url + path, method)
			{
				downloadHandler = new DownloadHandlerBuffer(),
				disposeDownloadHandlerOnDispose = true,
				disposeUploadHandlerOnDispose = true,
				timeout = 300
			};
			if (!string.IsNullOrEmpty(accessKey))
			{
				client.SetRequestHeader("Authorization", "Bearer " + accessKey);
			}
			if (payload != null)
			{
				JsonSerializerSettings settings = new JsonSerializerSettings
				{
					NullValueHandling = NullValueHandling.Ignore
				};
				string s = JsonConvert.SerializeObject(payload, settings);
				client.SetRequestHeader("Content-Type", "application/json");
				client.uploadHandler = new UploadHandlerRaw(Encoding.UTF8.GetBytes(s));
			}
			client.SendWebRequest();
			while (!client.isDone)
			{
				await Task.Yield();
			}
			string text = client.downloadHandler.text;
			if (client.responseCode == 0L)
			{
				throw new MunaAPIException("Failed to get response from server. Check that you have an internet connection.", (int)client.responseCode);
			}
			if (client.responseCode >= 400)
			{
				ErrorResponse? errorResponse = JsonConvert.DeserializeObject<ErrorResponse>(text);
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
				throw new MunaAPIException((string)obj, (int)client.responseCode);
			}
			return JsonConvert.DeserializeObject<T>(text);
		}

		public override async IAsyncEnumerable<T> Stream<T>(string method, string path, Dictionary<string, object?>? payload = null)
		{
			SSEDownloadHandler handler = new SSEDownloadHandler();
			using UnityWebRequest client = new UnityWebRequest(url + path, method)
			{
				downloadHandler = handler,
				disposeDownloadHandlerOnDispose = true,
				disposeUploadHandlerOnDispose = true,
				timeout = 300
			};
			if (!string.IsNullOrEmpty(accessKey))
			{
				client.SetRequestHeader("Authorization", "Bearer " + accessKey);
			}
			client.SetRequestHeader("Accept", "text/event-stream");
			if (payload != null)
			{
				JsonSerializerSettings settings = new JsonSerializerSettings
				{
					NullValueHandling = NullValueHandling.Ignore
				};
				string s = JsonConvert.SerializeObject(payload, settings);
				client.SetRequestHeader("Content-Type", "application/json");
				client.uploadHandler = new UploadHandlerRaw(Encoding.UTF8.GetBytes(s));
			}
			client.SendWebRequest();
			while (client.responseCode == 0L && !client.isDone)
			{
				await Task.Yield();
			}
			if (client.responseCode == 0L)
			{
				throw new MunaAPIException("Failed to get response from server. Check that you have an internet connection.", (int)client.responseCode);
			}
			if (client.responseCode >= 400)
			{
				while (!client.isDone)
				{
					await Task.Yield();
				}
				StringBuilder stringBuilder = new StringBuilder();
				while (handler.lines.Count > 0)
				{
					stringBuilder.AppendLine(handler.lines.Dequeue());
				}
				ErrorResponse? errorResponse = JsonConvert.DeserializeObject<ErrorResponse>(stringBuilder.ToString());
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
				throw new MunaAPIException((string)obj, (int)client.responseCode);
			}
			string eventName = null;
			string data = string.Empty;
			while (true)
			{
				if (handler.lines.Count > 0)
				{
					string text = handler.lines.Dequeue().Trim();
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
				else
				{
					if (client.isDone)
					{
						break;
					}
					await Task.Yield();
				}
			}
			if (eventName != null || !string.IsNullOrEmpty(data))
			{
				yield return ParseSSEEvent<T>(eventName, data);
			}
		}

		public override async Task<Stream> Download(string url)
		{
			using UnityWebRequest request = UnityWebRequest.Get(url);
			request.timeout = 300;
			request.SendWebRequest();
			while (!request.isDone)
			{
				await Task.Yield();
			}
			if (request.result != UnityWebRequest.Result.Success)
			{
				throw new InvalidOperationException(request.error);
			}
			byte[] data = request.downloadHandler.data;
			return new MemoryStream(data, 0, data.Length, writable: false, publiclyVisible: false);
		}

		public override async Task Upload(Stream stream, string url, string? mime = null)
		{
			using UnityWebRequest client = new UnityWebRequest(url, "PUT")
			{
				uploadHandler = new UploadHandlerRaw(ToArray(stream)),
				downloadHandler = new DownloadHandlerBuffer(),
				disposeDownloadHandlerOnDispose = true,
				disposeUploadHandlerOnDispose = true,
				timeout = 300
			};
			client.SetRequestHeader("Content-Type", mime ?? "application/octet-stream");
			client.SendWebRequest();
			while (!client.isDone)
			{
				await Task.Yield();
			}
			if (client.error != null)
			{
				throw new InvalidOperationException("Failed to upload stream with error: " + client.error);
			}
		}

		private static T ParseSSEEvent<T>(string? eventName, string data) where T : class
		{
			return new JObject
			{
				["event"] = eventName,
				["data"] = JToken.Parse(data)
			}.ToObject<T>();
		}

		private static byte[] ToArray(Stream stream)
		{
			if (stream is MemoryStream memoryStream)
			{
				return memoryStream.ToArray();
			}
			using MemoryStream memoryStream2 = new MemoryStream();
			stream.CopyTo(memoryStream2);
			return memoryStream2.ToArray();
		}
	}
}
