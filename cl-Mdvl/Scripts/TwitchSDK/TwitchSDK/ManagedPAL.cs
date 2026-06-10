using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TwitchSDK.Interop;

namespace TwitchSDK
{
	public class ManagedPAL : PlatformAbstractionLayer
	{
		private readonly HttpClient Http = new HttpClient
		{
			Timeout = TimeSpan.FromSeconds(10.0)
		};

		private readonly CancellationTokenSource CancelSource = new CancellationTokenSource();

		private readonly Dictionary<int, ClientWebSocket> ActiveWebSockets = new Dictionary<int, ClientWebSocket>();

		private int NextWebSocketHandle = 1;

		private static readonly Encoding Utf8NoBOM = new UTF8Encoding(encoderShouldEmitUTF8Identifier: false);

		private CancellationToken C => CancelSource.Token;

		protected virtual string HttpUserAgent => "Twitch-Route-66";

		protected override void DisposeManaged()
		{
			CancelSource.Cancel();
			lock (ActiveWebSockets)
			{
				foreach (KeyValuePair<int, ClientWebSocket> activeWebSocket in ActiveWebSockets)
				{
					activeWebSocket.Value.Dispose();
				}
				ActiveWebSockets.Clear();
			}
		}

		protected override Task Sleep(SleepRequest req)
		{
			return Task.Delay(req.Milliseconds, C);
		}

		protected override async Task<WebRequestResult> WebRequest(WebRequestRequest request)
		{
			Console.WriteLine("Querying at " + request.Uri + " with " + request.RequestBody + " and " + request.Authorization);
			HttpRequestMessage httpRequestMessage = new HttpRequestMessage
			{
				RequestUri = new Uri(request.Uri)
			};
			bool flag = false;
			switch (request.Method)
			{
			case TwitchSDK.Interop.HttpMethod.Get:
				httpRequestMessage.Method = System.Net.Http.HttpMethod.Get;
				break;
			case TwitchSDK.Interop.HttpMethod.Post:
				httpRequestMessage.Method = System.Net.Http.HttpMethod.Post;
				flag = true;
				break;
			case TwitchSDK.Interop.HttpMethod.Put:
				httpRequestMessage.Method = System.Net.Http.HttpMethod.Put;
				flag = true;
				break;
			case TwitchSDK.Interop.HttpMethod.Patch:
				httpRequestMessage.Method = new System.Net.Http.HttpMethod("PATCH");
				flag = true;
				break;
			case TwitchSDK.Interop.HttpMethod.Delete:
				httpRequestMessage.Method = System.Net.Http.HttpMethod.Delete;
				break;
			default:
				throw new NotImplementedException();
			}
			if (flag)
			{
				httpRequestMessage.Content = new StringContent(request.RequestBody, Encoding.UTF8, request.ContentType);
			}
			if (!string.IsNullOrEmpty(request.ClientId))
			{
				httpRequestMessage.Headers.Add("Client-Id", request.ClientId);
			}
			if (!string.IsNullOrEmpty(request.Authorization))
			{
				httpRequestMessage.Headers.Add("Authorization", request.Authorization);
			}
			httpRequestMessage.Headers.UserAgent.Add(new ProductInfoHeaderValue(HttpUserAgent, "0.2"));
			using HttpResponseMessage response = await Http.SendAsync(httpRequestMessage, HttpCompletionOption.ResponseContentRead, C).ConfigureAwait(continueOnCapturedContext: false);
			string text = await response.Content.ReadAsStringAsync().ConfigureAwait(continueOnCapturedContext: false);
			Console.WriteLine("Response: " + text);
			return new WebRequestResult
			{
				HttpStatus = (int)response.StatusCode,
				ResponseBody = text
			};
		}

		protected virtual Task<string> GetFileIOBasePath(CancellationToken _)
		{
			return Task.FromResult(Directory.GetCurrentDirectory());
		}

		protected override async Task<string> ReadFile(ReadFileRequest req)
		{
			string content = string.Empty;
			try
			{
				content = File.ReadAllText(Path.Combine(await GetFileIOBasePath(C).ConfigureAwait(continueOnCapturedContext: false), req.Path));
			}
			catch (FileNotFoundException)
			{
			}
			return content;
		}

		protected override async Task WriteFile(WriteFileRequest req)
		{
			File.WriteAllText(Path.Combine(await GetFileIOBasePath(C).ConfigureAwait(continueOnCapturedContext: false), req.Path), req.Data);
		}

		protected override Task Log(LogRequest req)
		{
			switch (req.Level)
			{
			case LogLevel.Debug:
				Console.ForegroundColor = ConsoleColor.Gray;
				break;
			case LogLevel.Info:
				Console.ForegroundColor = ConsoleColor.White;
				break;
			case LogLevel.Warning:
				Console.ForegroundColor = ConsoleColor.Yellow;
				break;
			case LogLevel.Error:
				Console.ForegroundColor = ConsoleColor.Magenta;
				break;
			}
			Console.WriteLine(req.Message);
			Console.ResetColor();
			return Task.CompletedTask;
		}

		protected override async Task<int> CreateWebSocket(CreateWebSocketRequest req)
		{
			ClientWebSocket clientWebSocket = new ClientWebSocket();
			int handle;
			lock (ActiveWebSockets)
			{
				handle = NextWebSocketHandle++;
				ActiveWebSockets[handle] = clientWebSocket;
			}
			await clientWebSocket.ConnectAsync(new Uri(req.Url), C).ConfigureAwait(continueOnCapturedContext: false);
			return handle;
		}

		private ClientWebSocket GetWebSocket(int handle)
		{
			lock (ActiveWebSockets)
			{
				return ActiveWebSockets[handle];
			}
		}

		protected override async Task SendWebSocketMessage(SendWebSocketMessageRequest req)
		{
			ClientWebSocket webSocket = GetWebSocket(req.Handle);
			ArraySegment<byte> buffer = new ArraySegment<byte>(Utf8NoBOM.GetBytes(req.Message));
			await webSocket.SendAsync(buffer, WebSocketMessageType.Text, endOfMessage: true, C).ConfigureAwait(continueOnCapturedContext: false);
		}

		protected override async Task<string> RecvWebSocketMessage(RecvWebSocketMessageRequest req)
		{
			ClientWebSocket ws = GetWebSocket(req.Handle);
			MemoryStream ms = new MemoryStream();
			using (CancellationTokenSource timeoutSource = new CancellationTokenSource(TimeSpan.FromSeconds(req.TimeoutSeconds)))
			{
				using CancellationTokenSource linkedSource = CancellationTokenSource.CreateLinkedTokenSource(C, timeoutSource.Token);
				WebSocketReceiveResult webSocketReceiveResult;
				do
				{
					ArraySegment<byte> buffer = new ArraySegment<byte>(new byte[1024]);
					webSocketReceiveResult = await ws.ReceiveAsync(buffer, linkedSource.Token).ConfigureAwait(continueOnCapturedContext: false);
					if (webSocketReceiveResult.MessageType == WebSocketMessageType.Close)
					{
						throw new EndOfStreamException("websocket is closed");
					}
					if (webSocketReceiveResult.MessageType != WebSocketMessageType.Text)
					{
						throw new InvalidOperationException("not receiving text");
					}
					ms.Write(buffer.Array, 0, webSocketReceiveResult.Count);
				}
				while (!webSocketReceiveResult.EndOfMessage);
			}
			Console.WriteLine("Received websocket message: {0}", Utf8NoBOM.GetString(ms.ToArray()));
			if (ms.TryGetBuffer(out var buffer2))
			{
				return Utf8NoBOM.GetString(buffer2.Array, buffer2.Offset, buffer2.Count);
			}
			return Utf8NoBOM.GetString(ms.ToArray());
		}

		protected override async Task CloseWebSocket(CloseWebSocketRequest req)
		{
			Console.WriteLine("Trying to close WS#" + req.Handle);
			ClientWebSocket ws = GetWebSocket(req.Handle);
			lock (ActiveWebSockets)
			{
				ActiveWebSockets.Remove(req.Handle);
			}
			await ws.CloseAsync(WebSocketCloseStatus.NormalClosure, "normal closure", C).ConfigureAwait(continueOnCapturedContext: false);
			ws.Dispose();
		}
	}
}
