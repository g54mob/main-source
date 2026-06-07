using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using BestHTTP.Extensions;
using BestHTTP.Futures;
using BestHTTP.Logger;
using BestHTTP.SignalRCore.Messages;

namespace BestHTTP.SignalRCore
{
	public sealed class HubConnection : IHeartbeat
	{
		public static readonly object[] EmptyArgs;

		private long lastInvocationId;

		private int lastStreamId;

		private Dictionary<long, InvocationDefinition> invocations;

		private Dictionary<string, Subscription> subscriptions;

		private DateTime lastMessageSentAt;

		private DateTime lastMessageReceivedAt;

		private DateTime connectionStartedAt;

		private RetryContext currentContext;

		private DateTime reconnectStartTime;

		private DateTime reconnectAt;

		private List<TransportTypes> triedoutTransports;

		private TaskCompletionSource<HubConnection> connectAsyncTaskCompletionSource;

		private TaskCompletionSource<HubConnection> closeAsyncTaskCompletionSource;

		public Uri Uri { get; private set; }

		public ConnectionStates State { get; private set; }

		public ITransport Transport { get; private set; }

		public IProtocol Protocol { get; private set; }

		public IAuthenticationProvider AuthenticationProvider { get; set; }

		public NegotiationResult NegotiationResult { get; private set; }

		public HubOptions Options { get; private set; }

		public int RedirectCount { get; private set; }

		public IRetryPolicy ReconnectPolicy { get; set; }

		public LoggingContext Context { get; private set; }

		public event Action<HubConnection, Uri, Uri> OnRedirected
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action<HubConnection> OnConnected
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action<HubConnection, string> OnError
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action<HubConnection> OnClosed
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Func<HubConnection, Message, bool> OnMessage
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action<HubConnection, string> OnReconnecting
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action<HubConnection> OnReconnected
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action<HubConnection, ITransport, TransportEvents> OnTransportEvent
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public HubConnection(Uri hubUri, IProtocol protocol)
		{
		}

		public HubConnection(Uri hubUri, IProtocol protocol, HubOptions options)
		{
		}

		public void StartConnect()
		{
		}

		public Task<HubConnection> ConnectAsync()
		{
			return null;
		}

		private void OnAsyncConnectedCallback(HubConnection hub)
		{
		}

		private void OnAsyncConnectFailedCallback(HubConnection hub, string error)
		{
		}

		private void OnAuthenticationSucceded(IAuthenticationProvider provider)
		{
		}

		private void OnAuthenticationFailed(IAuthenticationProvider provider, string reason)
		{
		}

		private void StartNegotiation()
		{
		}

		private void ConnectImpl(TransportTypes transport)
		{
		}

		private bool IsTransportSupported(string transportName)
		{
			return false;
		}

		private void OnNegotiationRequestFinished(HTTPRequest req, HTTPResponse resp)
		{
		}

		public void StartClose()
		{
		}

		public Task<HubConnection> CloseAsync()
		{
			return null;
		}

		private void OnClosedAsyncCallback(HubConnection hub)
		{
		}

		private void OnClosedAsyncErrorCallback(HubConnection hub, string error)
		{
		}

		public IFuture<TResult> Invoke<TResult>(string target, params object[] args)
		{
			return null;
		}

		public Task<TResult> InvokeAsync<TResult>(string target, params object[] args)
		{
			return null;
		}

		public Task<TResult> InvokeAsync<TResult>(string target, CancellationToken cancellationToken = default(CancellationToken), params object[] args)
		{
			return null;
		}

		public IFuture<object> Send(string target, params object[] args)
		{
			return null;
		}

		public Task<object> SendAsync(string target, params object[] args)
		{
			return null;
		}

		public Task<object> SendAsync(string target, CancellationToken cancellationToken = default(CancellationToken), params object[] args)
		{
			return null;
		}

		private long InvokeImp(string target, object[] args, Action<Message> callback, Type itemType, bool isStreamingInvocation = false)
		{
			return 0L;
		}

		internal void SendMessage(Message message)
		{
		}

		public DownStreamItemController<TDown> GetDownStreamController<TDown>(string target, params object[] args)
		{
			return null;
		}

		public UpStreamItemController<TResult> GetUpStreamController<TResult>(string target, int paramCount, bool downStream, object[] args)
		{
			return null;
		}

		public void On(string methodName, Action callback)
		{
		}

		public void On<T1>(string methodName, Action<T1> callback)
		{
		}

		public void On<T1, T2>(string methodName, Action<T1, T2> callback)
		{
		}

		public void On<T1, T2, T3>(string methodName, Action<T1, T2, T3> callback)
		{
		}

		public void On<T1, T2, T3, T4>(string methodName, Action<T1, T2, T3, T4> callback)
		{
		}

		private void On(string methodName, Type[] paramTypes, Action<object[]> callback)
		{
		}

		public void Remove(string methodName)
		{
		}

		internal Subscription GetSubscription(string methodName)
		{
			return null;
		}

		internal Type GetItemType(long invocationId)
		{
			return null;
		}

		internal void OnMessages(List<Message> messages)
		{
		}

		private void Transport_OnStateChanged(TransportStates oldState, TransportStates newState)
		{
		}

		private TransportTypes? GetNextTransportToTry()
		{
			return null;
		}

		private void SetState(ConnectionStates state, string errorReason = null, bool allowReconnect = true)
		{
		}

		void IHeartbeat.OnHeartbeatUpdate(TimeSpan dif)
		{
		}
	}
}
