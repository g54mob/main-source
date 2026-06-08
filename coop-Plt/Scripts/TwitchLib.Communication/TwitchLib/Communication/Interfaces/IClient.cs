using System;
using TwitchLib.Communication.Events;

namespace TwitchLib.Communication.Interfaces
{
	public interface IClient
	{
		TimeSpan DefaultKeepAliveInterval { get; set; }

		int SendQueueLength { get; }

		int WhisperQueueLength { get; }

		bool IsConnected { get; }

		IClientOptions Options { get; }

		event EventHandler<OnConnectedEventArgs> OnConnected;

		event EventHandler<OnDataEventArgs> OnData;

		event EventHandler<OnDisconnectedEventArgs> OnDisconnected;

		event EventHandler<OnErrorEventArgs> OnError;

		event EventHandler<OnFatalErrorEventArgs> OnFatality;

		event EventHandler<OnMessageEventArgs> OnMessage;

		event EventHandler<OnMessageThrottledEventArgs> OnMessageThrottled;

		event EventHandler<OnWhisperThrottledEventArgs> OnWhisperThrottled;

		event EventHandler<OnSendFailedEventArgs> OnSendFailed;

		event EventHandler<OnStateChangedEventArgs> OnStateChanged;

		event EventHandler<OnReconnectedEventArgs> OnReconnected;

		void Close(bool callDisconnect = true);

		void Dispose();

		bool Open();

		bool Send(string message);

		bool SendWhisper(string message);

		void Reconnect();

		void MessageThrottled(OnMessageThrottledEventArgs eventArgs);

		void SendFailed(OnSendFailedEventArgs eventArgs);

		void Error(OnErrorEventArgs eventArgs);

		void WhisperThrottled(OnWhisperThrottledEventArgs eventArgs);
	}
}
