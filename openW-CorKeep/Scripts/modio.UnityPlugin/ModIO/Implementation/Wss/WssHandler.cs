using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ModIO.Implementation.Wss.Messages;
using ModIO.Implementation.Wss.Messages.Objects;

namespace ModIO.Implementation.Wss
{
	internal static class WssHandler
	{
		private static ISocketConnection Socket = new SocketConnection();

		private static Dictionary<string, TaskCompletionSource<WssMessage>> WaitingForMessages = new Dictionary<string, TaskCompletionSource<WssMessage>>();

		private static Dictionary<string, Action<WssMessage>> SubscribedMessageListeners = new Dictionary<string, Action<WssMessage>>();

		private static Dictionary<string, WssMessage> UnhandledMessages = new Dictionary<string, WssMessage>();

		private static string GatewayUrl => $"wss://g-{Settings.server.gameId}.ws.modapi.io/";

		public static async Task<ResultAnd<WssMessage>> WaitForMessage(string messageOperation, bool checkPreviousUnhandledMessages = false)
		{
			if (checkPreviousUnhandledMessages && UnhandledMessages.ContainsKey(messageOperation))
			{
				ResultAnd<WssMessage> result = ResultAnd.Create(ResultBuilder.Success, UnhandledMessages[messageOperation]);
				UnhandledMessages.Remove(messageOperation);
				return result;
			}
			TaskCompletionSource<WssMessage> tcs = new TaskCompletionSource<WssMessage>();
			while (WaitingForMessages.ContainsKey(messageOperation))
			{
				await WaitingForMessages[messageOperation].Task;
			}
			WaitingForMessages.Add(messageOperation, tcs);
			await Task.WhenAny(tcs.Task, Task.Delay(900000));
			Result result2 = (tcs.Task.IsCompleted ? ResultBuilder.Success : ResultBuilder.Create(20602u));
			WssMessage value = (tcs.Task.IsCompleted ? tcs.Task.Result : default(WssMessage));
			if (result2.code == 0 && string.IsNullOrEmpty(value.operation))
			{
				result2 = ResultBuilder.Create(20506u);
			}
			return ResultAnd.Create(result2, value);
		}

		public static async Task<ResultAnd<T>> DoMessageHandshake<T>(WssMessage message) where T : struct
		{
			Task<ResultAnd<WssMessage>> task = WaitForMessage("device_login");
			Result result = await Send(message);
			Logger.Log(LogLevel.Verbose, "[Socket] SENT (" + message.operation + ")");
			if (!result.Succeeded())
			{
				Logger.Log(LogLevel.Verbose, "[Socket] Failed to send");
				return ResultAnd.Create(result, default(T));
			}
			Logger.Log(LogLevel.Verbose, "[Socket] Waiting for initial response");
			ResultAnd<WssMessage> resultAnd = await task;
			if (resultAnd.result.Succeeded())
			{
				Logger.Log(LogLevel.Verbose, "[Socket] deserializing initial response");
				if (resultAnd.value.TryGetValue<T>(out var output))
				{
					return ResultAnd.Create(ResultBuilder.Success, output);
				}
				Logger.Log(LogLevel.Verbose, "[Socket] Failed to deserialize");
				return ResultAnd.Create(20603u, default(T));
			}
			return ResultAnd.Create(resultAnd.result, default(T));
		}

		public static void CancelWaitingFor(string messageOperation)
		{
			if (WaitingForMessages.ContainsKey(messageOperation))
			{
				TaskCompletionSource<WssMessage> taskCompletionSource = WaitingForMessages[messageOperation];
				WaitingForMessages.Remove(messageOperation);
				taskCompletionSource.SetResult(default(WssMessage));
			}
		}

		private static void CancelAllAwaitingMessages()
		{
			List<TaskCompletionSource<WssMessage>> list = WaitingForMessages.Values.ToList();
			WaitingForMessages.Clear();
			foreach (TaskCompletionSource<WssMessage> item in list)
			{
				item.SetResult(default(WssMessage));
			}
		}

		public static async Task Shutdown()
		{
			await Socket.CloseConnection();
			CancelAllAwaitingMessages();
			UnhandledMessages.Clear();
			await Task.Yield();
		}

		private static async Task<Result> EnsureConnection()
		{
			if (!Socket.Connected())
			{
				return await Socket.SetupConnection(GatewayUrl, Receive, Disconnected);
			}
			return ResultBuilder.Success;
		}

		public static async Task<Result> Send(WssMessage message)
		{
			WssMessages messages = new WssMessages(message);
			Result result = await EnsureConnection();
			if (!result.Succeeded())
			{
				return result;
			}
			return await Socket.SendData(messages);
		}

		private static void Receive(WssMessages messages)
		{
			WssMessage[] messages2 = messages.messages;
			for (int i = 0; i < messages2.Length; i++)
			{
				WssMessage wssMessage = messages2[i];
				if (wssMessage.operation == "failed_operation")
				{
					ProcessErrorObject(wssMessage);
					continue;
				}
				if (WaitingForMessages.ContainsKey(wssMessage.operation))
				{
					TaskCompletionSource<WssMessage> taskCompletionSource = WaitingForMessages[wssMessage.operation];
					WaitingForMessages.Remove(wssMessage.operation);
					taskCompletionSource.SetResult(wssMessage);
					continue;
				}
				Logger.Log(LogLevel.Verbose, "[Socket] Received unexpected message operation (" + wssMessage.operation + ").\nCaching it temporarily in case we listen for it immediately after.");
				if (UnhandledMessages.ContainsKey(wssMessage.operation))
				{
					UnhandledMessages[wssMessage.operation] = wssMessage;
				}
				else
				{
					UnhandledMessages.Add(wssMessage.operation, wssMessage);
				}
			}
		}

		private static void ProcessErrorObject(WssMessage message)
		{
			if (message.TryGetValue<WssErrorObject>(out var output))
			{
				Logger.Log(LogLevel.Error, "[Socket] Error received from WssMessages:\n" + $"Error: [{output.error.code}]" + $" [{output.error.error_ref}]" + " " + output.error.message);
				if (WaitingForMessages.ContainsKey(output.operation))
				{
					TaskCompletionSource<WssMessage> taskCompletionSource = WaitingForMessages[output.operation];
					WaitingForMessages.Remove(output.operation);
					taskCompletionSource.SetResult(default(WssMessage));
				}
				else if (SubscribedMessageListeners.ContainsKey(output.operation))
				{
					SubscribedMessageListeners[output.operation]?.Invoke(message);
					WaitingForMessages.Remove(output.operation);
				}
				else
				{
					Logger.Log(LogLevel.Warning, "[Socket:Internal] Could not find any matching listener for the error operation: " + output.operation);
				}
			}
			else
			{
				Logger.Log(LogLevel.Error, "[Socket:Internal] Failed to cast WssMessage (operation \"" + message.operation + "\") into WssErrorObject");
			}
		}

		private static async void Disconnected()
		{
			if (WaitingForMessages.Count > 0)
			{
				Logger.Log(LogLevel.Warning, "[Socket] Disconnected while the WssHandler was still waiting for messages. Attempting to reconnect the WebSocket.");
				CancelAllAwaitingMessages();
				if (!(await EnsureConnection()).Succeeded())
				{
					Logger.Log(LogLevel.Error, "[Socket] Failed to re-establish Socket connection. Listeners for WssMessages have been cancelled");
				}
				else
				{
					Logger.Log(LogLevel.Warning, "[Socket] Re-established Socket connection. Listeners for WssMessages have been cancelled");
				}
			}
		}
	}
}
