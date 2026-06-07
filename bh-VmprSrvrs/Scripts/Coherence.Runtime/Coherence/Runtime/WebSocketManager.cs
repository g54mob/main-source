using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Coherence.Common;
using Coherence.Connection;
using Coherence.Log;

namespace Coherence.Runtime
{
	public sealed class WebSocketManager : IUpdatable, IDisposableInternal, IDisposable
	{
		private enum Event
		{
			Connected = 0,
			Disconnected = 1
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003COnWebSocketError_003Ed__72 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public WebSocketManager _003C_003E4__this;

			public Error error;

			public string message;

			private TaskAwaiter<bool> _003C_003Eu__1;

			private void MoveNext()
			{
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CValidateWebSocketParameters_003Ed__75 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

			public WebSocketManager _003C_003E4__this;

			private TaskAwaiter<string> _003C_003Eu__1;

			private void MoveNext()
			{
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		private static readonly TimeSpan TimeOutSpan;

		private static readonly TimeSpan TimeoutCheckSpan;

		private readonly IRuntimeSettings runtimeSettings;

		private readonly RequestIdSource idSource;

		private readonly Logger logger;

		private bool wsConnected;

		private bool wsConnecting;

		private IWebSocket ws;

		private ConcurrentQueue<string> receiveQueue;

		private ConcurrentQueue<(int counter, string requestID)> failQueue;

		private List<RequestCallback> requestCallbacks;

		private Dictionary<string, RequestCallback> pushCallbacks;

		private readonly Stopwatch connectBackoffStopwatch;

		private TimeSpan connectBackoff;

		private DateTime nextCheck;

		private string resumeId;

		private bool validatedWsParameters;

		private const string pingEndpoint = "/health";

		private const int pingIntervalSeconds = 30;

		private DateTime nextPingTime;

		private bool isWebGlConnected;

		private ConcurrentQueue<Event> eventQueue;

		private string Endpoint => null;

		private string ClientVersion => null;

		public bool Enabled { get; private set; }

		public long ServerTimestamp { get; private set; }

		string IDisposableInternal.InitializationContext
		{
			[CompilerGenerated]
			get
			{
				return null;
			}
			[CompilerGenerated]
			set
			{
			}
		}

		string IDisposableInternal.InitializationStackTrace
		{
			[CompilerGenerated]
			get
			{
				return null;
			}
			[CompilerGenerated]
			set
			{
			}
		}

		bool IDisposableInternal.IsDisposed
		{
			[CompilerGenerated]
			get
			{
				return false;
			}
			[CompilerGenerated]
			set
			{
			}
		}

		public event Action OnConnect
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

		public event Action OnDisconnect
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

		public event Action OnWebSocketFail
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

		public event Action<string> OnWebSocketParametersNotValid
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

		public event Action<string> OnReceive
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

		public bool IsConnected()
		{
			return false;
		}

		public WebSocketManager(IRuntimeSettings runtimeSettings, RequestIdSource idSource)
		{
		}

		~WebSocketManager()
		{
		}

		public void Connect()
		{
		}

		public void Disconnect()
		{
		}

		public bool AddPushCallback(string requestID, OnRequest callback)
		{
			return false;
		}

		internal void SendRequest(string path, string method, string body, Dictionary<string, string> headers, string sessionToken, OnRequest callback)
		{
		}

		private void OnConnected()
		{
		}

		private void OnDisconnected()
		{
		}

		private void OnReceivedMessage(string messageReceived)
		{
		}

		[AsyncStateMachine(typeof(_003COnWebSocketError_003Ed__72))]
		private void OnWebSocketError(Error error, string message)
		{
		}

		private void OnSendFail(int requestCounter, string requestId, Error error, string message)
		{
		}

		private void OpenSocket()
		{
		}

		[AsyncStateMachine(typeof(_003CValidateWebSocketParameters_003Ed__75))]
		private Task<bool> ValidateWebSocketParameters()
		{
			return null;
		}

		private string GetFinalWsEndpoint(string requestID)
		{
			return null;
		}

		private void Backoff()
		{
		}

		private void Reset()
		{
		}

		private void SendText(int requestCounter, string requestId, string text)
		{
		}

		public void Update()
		{
		}

		private void HandleResponse(string text)
		{
		}

		private bool FindPushCallback(string requestID, out RequestCallback callback)
		{
			callback = default(RequestCallback);
			return false;
		}

		private bool FindRequestCallback(int counter, string requestID, out RequestCallback callback)
		{
			callback = default(RequestCallback);
			return false;
		}

		private bool RemoveRequestCallback(int counter, string requestID)
		{
			return false;
		}

		public void Dispose()
		{
		}

		private void ResetEvents()
		{
		}
	}
}
