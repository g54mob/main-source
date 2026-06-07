using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Coherence.Common;
using Coherence.Connection;
using Coherence.Log;
using Coherence.Runtime;

namespace Coherence.Cloud
{
	public class RequestFactory : IUpdatable, IRequestFactoryInternal, IRequestFactory, IDisposableInternal, IDisposable
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CSendCustomRequestAsync_003Ed__52 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<string> _003C_003Et__builder;

			public string endpoint;

			public string path;

			public string method;

			public string body;

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

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CSendRequestAsync_003Ed__50 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<string> _003C_003Et__builder;

			public RequestFactory _003C_003E4__this;

			public string method;

			public string basePath;

			public string pathParams;

			public string requestName;

			public string body;

			public Dictionary<string, string> headers;

			public string sessionToken;

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

		private Lazy<WebSocketManager> lazyWebSocket;

		private readonly IRuntimeSettings runtimeSettings;

		private readonly RequestIdSource idSource;

		private readonly Logger logger;

		private readonly RequestThrottle throttle;

		private Dictionary<(string, string), string> responsesDictionary;

		private Dictionary<string, List<Action<string>>> pushCallbacks;

		private Dictionary<string, List<Action<string>>> delayedPushCallbackRemoval;

		private Dictionary<string, OnRequest> delayedWebSocketCallbackAddition;

		private bool useWebSocket;

		private WebSocketManager WebSocket => null;

		public bool IsReady => false;

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

		RequestThrottle IRequestFactoryInternal.Throttle => null;

		public event Action OnWebSocketConnect
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

		public event Action OnWebSocketDisconnect
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

		public event Action OnWebSocketConnectionError
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

		public RequestFactory(IRuntimeSettings runtimeSettings, bool useWebSocket = true)
		{
		}

		~RequestFactory()
		{
		}

		public void ForceCreateWebSocket()
		{
		}

		public void AddPushCallback(string requestPath, Action<string> onPushCallback)
		{
		}

		public void RemovePushCallback(string requestPath, Action<string> onPushCallback)
		{
		}

		public void SetRequestThrottling(TimeSpan requestInterval)
		{
		}

		public TimeSpan GetRequestCooldown(string request, string method)
		{
			return default(TimeSpan);
		}

		public void SendRequest(string basePath, string method, string body, Dictionary<string, string> headers, string requestName, string sessionToken, Action<RequestResponse<string>> callback)
		{
		}

		public void SendRequest(string basePath, string pathParams, string method, string body, Dictionary<string, string> headers, string requestName, string sessionToken, Action<RequestResponse<string>> callback)
		{
		}

		public Task<string> SendRequestAsync(string basePath, string method, string body, Dictionary<string, string> headers, string requestName, string sessionToken)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CSendRequestAsync_003Ed__50))]
		public Task<string> SendRequestAsync(string basePath, string pathParams, string method, string body, Dictionary<string, string> headers, string requestName, string sessionToken)
		{
			return null;
		}

		public void SendCustomRequest(string endpoint, string path, string method, string body, Action<RequestResponse<string>> callback)
		{
		}

		[AsyncStateMachine(typeof(_003CSendCustomRequestAsync_003Ed__52))]
		public Task<string> SendCustomRequestAsync(string endpoint, string path, string method, string body)
		{
			return null;
		}

		public void Dispose()
		{
		}

		private void OnWebSocketConnected()
		{
		}

		private void OnWebSocketDisconnected()
		{
		}

		private void OnWebSocketConnectionHasError()
		{
		}

		private void OnWebSocketParamsNotValid(string msg)
		{
		}

		void IUpdatable.Update()
		{
		}

		private void CleanStalePushCallbacks()
		{
		}
	}
}
