using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

public class Wamp
{
	public class TimeoutException : Exception
	{
		public TimeoutException(string message)
			: base(message)
		{
		}
	}

	public class WampNotConnectedException : Exception
	{
		public WampNotConnectedException(string message)
			: base(message)
		{
		}
	}

	public class ErrorException : Exception
	{
		internal string Json { get; set; }

		internal Messages MessageId { get; set; }

		internal int RequestId { get; set; }

		internal string Uri { get; set; }

		public ErrorException(string message)
			: base(message)
		{
		}

		public static ErrorException FromResponse(string response)
		{
			string pattern = "^\\[\\s*8,\\s*(\\d+)\\s*,\\s*(\\d+)\\s*,\\s*\\{\\s*\\}\\s*,\\s*\"([^,\\s]+)\"\\s*,\\[\\s*\\]\\s*,\\s*(\\{)";
			Match match = Regex.Match(response, pattern, RegexOptions.Singleline);
			if (match.Groups.Count != 5)
			{
				throw new ErrorException("Invalid ERROR message.");
			}
			Messages messageId = (Messages)int.Parse(match.Groups[1].Value);
			int requestId = int.Parse(match.Groups[2].Value);
			string value = match.Groups[3].Value;
			string json = response.Substring(match.Groups[4].Index, response.Length - match.Groups[4].Index - 1);
			return new ErrorException("Error " + value + " in " + messageId.ToString() + " operation.")
			{
				Json = json,
				MessageId = messageId,
				RequestId = requestId,
				Uri = value
			};
		}
	}

	internal enum Messages
	{
		HELLO = 1,
		WELCOME = 2,
		GOODBYE = 6,
		ERROR = 8,
		SUBSCRIBE = 32,
		SUBSCRIBED = 33,
		UNSUBSCRIBE = 34,
		UNSUBSCRIBED = 35,
		EVENT = 36,
		CALL = 48,
		RESULT = 50
	}

	private class Response
	{
		public Messages MessageId { get; set; }

		public int RequestId { get; set; }

		public int ContextSpecificResultId { get; set; }

		public uint SubscriptionId { get; set; }

		public string Json { get; set; }
	}

	public delegate void PublishHandler(string json);

	public delegate void DisconnectedHandler();

	private ClientWebSocket ws;

	private int sessionId;

	private int currentRequestId;

	private CancellationTokenSource stopServerTokenSource = new CancellationTokenSource();

	private TaskCompletionSource<Response> taskCompletion = new TaskCompletionSource<Response>();

	private ConcurrentDictionary<uint, PublishHandler> subscriptions = new ConcurrentDictionary<uint, PublishHandler>();

	public event DisconnectedHandler Disconnected;

	private async Task Send(string msg, int timeout)
	{
		try
		{
			using (CancellationTokenSource cts = new CancellationTokenSource(timeout))
			{
				ArraySegment<byte> buffer = new ArraySegment<byte>(Encoding.UTF8.GetBytes(msg));
				await ws.SendAsync(buffer, WebSocketMessageType.Text, endOfMessage: true, cts.Token);
			}
		}
		catch (TaskCanceledException)
		{
			throw new TimeoutException("Timeout when sending message.");
		}
	}

	private Response Parse(string msg)
	{
		Match match = Regex.Match(msg, "^\\[\\s*(\\d+)", RegexOptions.Singleline);
		if (match.Groups.Count != 2)
		{
			throw new ErrorException("Error while parsing response from server.");
		}
		switch ((Messages)int.Parse(match.Groups[1].Value))
		{
		case Messages.WELCOME:
			return ParseWelcome(msg);
		case Messages.GOODBYE:
			return ParseGoodbye(msg);
		case Messages.SUBSCRIBED:
			return ParseSubscribed(msg);
		case Messages.UNSUBSCRIBED:
			return ParseUnsubscribed(msg);
		case Messages.EVENT:
			return ParseEvent(msg);
		case Messages.RESULT:
			return ParseResult(msg);
		case Messages.ERROR:
			throw ErrorException.FromResponse(msg);
		default:
			throw new ErrorException("Unexpected result from server.");
		}
	}

	private static Response ParseResult(string msg)
	{
		Match match = Regex.Match(msg, "^\\[\\s*50,\\s*(\\d+)\\s*,\\s*\\{\\s*\\}\\s*,\\s*\\[\\s*\\]\\s*,\\s*(\\{)", RegexOptions.Singleline);
		if (!match.Success || match.Groups.Count != 3)
		{
			throw new ErrorException("Invalid RESULT message.");
		}
		return new Response
		{
			MessageId = Messages.RESULT,
			RequestId = int.Parse(match.Groups[1].Value),
			Json = msg.Substring(match.Groups[2].Index, msg.Length - match.Groups[2].Index - 1)
		};
	}

	private static Response ParseSubscribed(string msg)
	{
		Match match = Regex.Match(msg, "^\\[\\s*33,\\s*(\\d+)\\s*,\\s*(\\d+)\\s*]$", RegexOptions.Singleline);
		if (!match.Success || match.Groups.Count != 3)
		{
			throw new ErrorException("Invalid SUBSCRIBED message.");
		}
		return new Response
		{
			MessageId = Messages.SUBSCRIBED,
			RequestId = int.Parse(match.Groups[1].Value),
			SubscriptionId = uint.Parse(match.Groups[2].Value)
		};
	}

	private static Response ParseUnsubscribed(string msg)
	{
		Match match = Regex.Match(msg, "^\\[\\s*35,\\s*(\\d+)\\s*]$", RegexOptions.Singleline);
		if (!match.Success || match.Groups.Count != 2)
		{
			throw new ErrorException("Invalid UNSUBSCRIBED message.");
		}
		return new Response
		{
			MessageId = Messages.UNSUBSCRIBED,
			RequestId = int.Parse(match.Groups[1].Value)
		};
	}

	private static Response ParseGoodbye(string msg)
	{
		Match match = Regex.Match(msg, "^\\[\\s*6", RegexOptions.Singleline);
		if (!match.Success || match.Groups.Count != 1)
		{
			throw new ErrorException("Invalid GOODBYE message.");
		}
		return new Response
		{
			MessageId = Messages.GOODBYE
		};
	}

	private static Response ParseWelcome(string msg)
	{
		Match match = Regex.Match(msg, "^\\[\\s*2,\\s*(\\d+)", RegexOptions.Singleline);
		if (!match.Success || match.Groups.Count != 2)
		{
			throw new ErrorException("Invalid WELCOME message.");
		}
		return new Response
		{
			MessageId = Messages.WELCOME,
			RequestId = 0,
			ContextSpecificResultId = int.Parse(match.Groups[1].Value)
		};
	}

	private static Response ParseEvent(string msg)
	{
		Match match = Regex.Match(msg, "^\\[\\s*36,\\s*(\\d+)\\s*,\\s*(\\d+)\\s*,\\s*\\{\\s*\\}\\s*,\\s*\\[\\s*\\]\\s*,\\s*(\\{)", RegexOptions.Singleline);
		if (match.Groups.Count != 4)
		{
			throw new ErrorException("Invalid EVENT message.");
		}
		return new Response
		{
			MessageId = Messages.EVENT,
			RequestId = int.Parse(match.Groups[2].Value),
			ContextSpecificResultId = int.Parse(match.Groups[1].Value),
			Json = msg.Substring(match.Groups[3].Index, msg.Length - match.Groups[3].Index - 1)
		};
	}

	private async Task<Response> ReceiveMessage()
	{
		List<IEnumerable<byte>> segments = new List<IEnumerable<byte>>();
		try
		{
			WebSocketReceiveResult webSocketReceiveResult;
			do
			{
				byte[] array = new byte[4096];
				ArraySegment<byte> segment = new ArraySegment<byte>(array, 0, array.Length);
				webSocketReceiveResult = await ws.ReceiveAsync(segment, stopServerTokenSource.Token);
				segments.Add(segment.Skip(segment.Offset).Take(webSocketReceiveResult.Count));
			}
			while (!webSocketReceiveResult.EndOfMessage);
		}
		catch (WebSocketException ex)
		{
			throw ex.InnerException;
		}
		catch (Exception)
		{
			throw new ErrorException("Error receiving response from server.");
		}
		try
		{
			byte[] bytes = segments.SelectMany((IEnumerable<byte> t) => t).ToArray();
			string msg = Encoding.UTF8.GetString(bytes);
			return Parse(msg);
		}
		catch (ErrorException ex3)
		{
			throw ex3;
		}
		catch (Exception)
		{
			throw new ErrorException("Error while parsing response from server.");
		}
	}

	private async Task<Response> Receive(int timeout)
	{
		Task task = await Task.WhenAny(taskCompletion.Task, Task.Delay(timeout));
		if (task != taskCompletion.Task)
		{
			taskCompletion = new TaskCompletionSource<Response>();
			throw new TimeoutException("Timeout when receiving message.");
		}
		if (task.Exception != null)
		{
			taskCompletion = new TaskCompletionSource<Response>();
			if (task.Exception.InnerException.InnerException != null)
			{
				throw task.Exception.InnerException.InnerException;
			}
			throw task.Exception;
		}
		Response result = taskCompletion.Task.Result;
		taskCompletion = new TaskCompletionSource<Response>();
		return result;
	}

	private async Task<Response> ReceiveExpect(Messages message, int requestId, int timeout)
	{
		Response obj = await Receive(timeout);
		if (obj.MessageId != message)
		{
			throw new ErrorException(message.ToString() + ": invalid response. Did not receive expected answer.");
		}
		if (obj.RequestId != requestId)
		{
			throw new ErrorException(message.ToString() + ": invalid request id for result.");
		}
		return obj;
	}

	internal async Task Connect(string host, int timeout)
	{
		_ = 2;
		try
		{
			Uri uri = new Uri(host);
			using (CancellationTokenSource cts = new CancellationTokenSource())
			{
				if (ws == null)
				{
					ws = new ClientWebSocket();
				}
				await ws.ConnectAsync(uri, cts.Token);
			}
			await Send($"[{1},\"realm1\"]", timeout);
			StartListen();
			sessionId = (await ReceiveExpect(Messages.WELCOME, 0, timeout)).ContextSpecificResultId;
		}
		catch (WebSocketException ex)
		{
			ws.Dispose();
			ws = new ClientWebSocket();
			throw new ErrorException(ex.ToString());
		}
		catch (Exception ex2)
		{
			throw new ErrorException(ex2.ToString());
		}
	}

	internal bool IsConnected()
	{
		if (ws == null)
		{
			return false;
		}
		return ws.State == WebSocketState.Open;
	}

	internal WebSocketState SocketState()
	{
		if (ws == null)
		{
			return WebSocketState.None;
		}
		return ws.State;
	}

	internal async Task Close(int timeout)
	{
		_ = 2;
		try
		{
			await Send($"[{6},{{}},\"bye_from_csharp_client\"]", timeout);
			await ReceiveExpect(Messages.GOODBYE, 0, timeout);
			stopServerTokenSource.Cancel();
			using (CancellationTokenSource cts = new CancellationTokenSource(timeout))
			{
				await ws.CloseOutputAsync(WebSocketCloseStatus.NormalClosure, "wamp_close", cts.Token);
			}
		}
		catch (WebSocketException)
		{
			ws.Dispose();
			stopServerTokenSource.Cancel();
		}
	}

	private void ProcessEvent(Response message)
	{
		int contextSpecificResultId = message.ContextSpecificResultId;
		PublishHandler value = null;
		if (!subscriptions.TryGetValue((uint)contextSpecificResultId, out value))
		{
			throw new ErrorException("UNSUBSCRIBE: unknown subscription id.");
		}
		value(message.Json);
	}

	private void StartListen()
	{
		CancellationToken ct = stopServerTokenSource.Token;
		Task.Factory.StartNew(delegate
		{
			ct.ThrowIfCancellationRequested();
			while (true)
			{
				try
				{
					Task<Response> task = ReceiveMessage();
					task.Wait();
					if (task.Result.MessageId == Messages.EVENT)
					{
						ProcessEvent(task.Result);
					}
					else
					{
						if (taskCompletion == null)
						{
							throw new ErrorException("Received WAMP message that we did not expect.");
						}
						taskCompletion.SetResult(task.Result);
					}
					if (ct.IsCancellationRequested)
					{
						break;
					}
				}
				catch (Exception ex)
				{
					if (ex.InnerException.GetType() == typeof(WebSocketException) && (ex.InnerException as WebSocketException).WebSocketErrorCode == WebSocketError.ConnectionClosedPrematurely)
					{
						if (taskCompletion != null)
						{
							taskCompletion.SetException(ex);
						}
						OnDisconnect();
						break;
					}
					if (ws.State != WebSocketState.Open)
					{
						OnDisconnect();
						break;
					}
					if (taskCompletion != null)
					{
						taskCompletion.SetException(ex);
					}
				}
			}
		}, stopServerTokenSource.Token);
	}

	private void OnDisconnect()
	{
		if (this.Disconnected != null)
		{
			this.Disconnected();
		}
	}

	internal async Task<string> Call(string uri, string args, string options, int timeout)
	{
		int requestId = ++currentRequestId;
		await Send($"[{48},{requestId},{options},\"{uri}\",[],{args}]", timeout);
		return (await ReceiveExpect(Messages.RESULT, requestId, timeout)).Json;
	}

	internal async Task<uint> Subscribe(string topic, string options, PublishHandler publishEvent, int timeout)
	{
		int requestId = ++currentRequestId;
		await Send($"[{32},{requestId},{options},\"{topic}\"]", timeout);
		Response response = await ReceiveExpect(Messages.SUBSCRIBED, requestId, timeout);
		subscriptions.TryAdd(response.SubscriptionId, publishEvent);
		return response.SubscriptionId;
	}

	internal async Task Unsubscribe(uint subscriptionId, int timeout)
	{
		int requestId = ++currentRequestId;
		await Send($"[{34},{requestId},{subscriptionId}]", timeout);
		await ReceiveExpect(Messages.UNSUBSCRIBED, requestId, timeout);
		subscriptions.TryRemove(subscriptionId, out var _);
	}
}
