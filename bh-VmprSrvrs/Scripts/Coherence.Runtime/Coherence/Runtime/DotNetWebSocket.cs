using System;
using System.Diagnostics;
using System.Net.WebSockets;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using Coherence.Log;
using UnityEngine;

namespace Coherence.Runtime
{
	public class DotNetWebSocket : IWebSocket
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CCloseAsync_003Ed__28 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public DotNetWebSocket _003C_003E4__this;

			private ClientWebSocket _003CdisposedWs_003E5__2;

			private TaskAwaiter _003C_003Eu__1;

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
		private struct _003CCloseSocketAsync_003Ed__31 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public DotNetWebSocket _003C_003E4__this;

			public ClientWebSocket socket;

			private bool _003CwasOpen_003E5__2;

			private TaskAwaiter _003C_003Eu__1;

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
		private struct _003COpenSocketAsync_003Ed__29 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public DotNetWebSocket _003C_003E4__this;

			public string endpoint;

			private TaskAwaiter _003C_003Eu__1;

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
		private struct _003CRunReceive_003Ed__30 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public DotNetWebSocket _003C_003E4__this;

			private byte[] _003Cbuffer_003E5__2;

			private int _003CreceivedBytes_003E5__3;

			private ValueTaskAwaiter<ValueWebSocketReceiveResult> _003C_003Eu__1;

			private TaskAwaiter _003C_003Eu__2;

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
		private struct _003CSendAsync_003Ed__33 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public DotNetWebSocket _003C_003E4__this;

			public string text;

			public string requestId;

			public int requestCounter;

			private Awaitable.Awaiter _003C_003Eu__1;

			private TaskAwaiter _003C_003Eu__2;

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

		private ClientWebSocket ws;

		private CancellationTokenSource abortTokenSource;

		private CancellationToken abortToken;

		private Task receiveTask;

		private Task connectTask;

		private Task sendTask;

		private readonly Coherence.Log.Logger logger;

		public bool PingWebSocket => false;

		private event Action OnConnect
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

		private event Action OnDisconnect
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

		private event Action<Error, string> OnWebSocketFail
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

		private event Action<string> OnReceive
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

		private event Action<int, string, Error, string> OnSendFail
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

		public void OpenSocket(string endpoint, Action onConnect, Action onDisconnect, Action<string> onReceive, Action<Error, string> onError, Action<int, string, Error, string> onSendFail)
		{
		}

		public void Send(int requestCounter, string requestId, string message)
		{
		}

		public void Update()
		{
		}

		[AsyncStateMachine(typeof(_003CCloseAsync_003Ed__28))]
		public Task CloseAsync()
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003COpenSocketAsync_003Ed__29))]
		private Task OpenSocketAsync(string endpoint)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CRunReceive_003Ed__30))]
		private Task RunReceive()
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CCloseSocketAsync_003Ed__31))]
		private Task CloseSocketAsync(ClientWebSocket socket)
		{
			return null;
		}

		private void CancelAndDisposeToken()
		{
		}

		[AsyncStateMachine(typeof(_003CSendAsync_003Ed__33))]
		private Task SendAsync(int requestCounter, string requestId, string text)
		{
			return null;
		}
	}
}
