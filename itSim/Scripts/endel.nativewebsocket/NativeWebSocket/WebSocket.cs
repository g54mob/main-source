using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.WebSockets;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

namespace NativeWebSocket
{
	public class WebSocket : IWebSocket
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CClose_003Ed__37 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public WebSocket _003C_003E4__this;

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
		private struct _003CConnect_003Ed__27 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public WebSocket _003C_003E4__this;

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
		private struct _003CHandleQueue_003Ed__33 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public WebSocket _003C_003E4__this;

			public List<ArraySegment<byte>> queue;

			public WebSocketMessageType messageType;

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
		private struct _003CReceive_003Ed__36 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public WebSocket _003C_003E4__this;

			private WebSocketCloseCode _003CcloseCode_003E5__2;

			private ArraySegment<byte> _003Cbuffer_003E5__3;

			private ConfiguredTaskAwaitable.ConfiguredTaskAwaiter _003C_003Eu__1;

			private object _003C_003E7__wrap3;

			private int _003C_003E7__wrap4;

			private WebSocketReceiveResult _003Cresult_003E5__6;

			private MemoryStream _003Cms_003E5__7;

			private TaskAwaiter<WebSocketReceiveResult> _003C_003Eu__2;

			private TaskAwaiter _003C_003Eu__3;

			private object _003C_003Eu__4;

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
		private struct _003CSendMessage_003Ed__32 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public ArraySegment<byte> buffer;

			public WebSocket _003C_003E4__this;

			public WebSocketMessageType messageType;

			public List<ArraySegment<byte>> queue;

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

		private Uri uri;

		private Dictionary<string, string> headers;

		private List<string> subprotocols;

		private ClientWebSocket m_Socket;

		private CancellationTokenSource m_TokenSource;

		private CancellationToken m_CancellationToken;

		private readonly object OutgoingMessageLock;

		private readonly object IncomingMessageLock;

		private bool isSending;

		private List<ArraySegment<byte>> sendBytesQueue;

		private List<ArraySegment<byte>> sendTextQueue;

		private List<byte[]> m_MessageList;

		public WebSocketState State => default(WebSocketState);

		public event WebSocketOpenEventHandler OnOpen
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

		public event WebSocketMessageEventHandler OnMessage
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

		public event WebSocketErrorEventHandler OnError
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

		public event WebSocketCloseEventHandler OnClose
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

		public WebSocket(string url, Dictionary<string, string> headers = null)
		{
		}

		public WebSocket(string url, string subprotocol, Dictionary<string, string> headers = null)
		{
		}

		public WebSocket(string url, List<string> subprotocols, Dictionary<string, string> headers = null)
		{
		}

		public void CancelConnection()
		{
		}

		[AsyncStateMachine(typeof(_003CConnect_003Ed__27))]
		public Task Connect()
		{
			return null;
		}

		public Task Send(byte[] bytes)
		{
			return null;
		}

		public Task SendText(string message)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CSendMessage_003Ed__32))]
		private Task SendMessage(List<ArraySegment<byte>> queue, WebSocketMessageType messageType, ArraySegment<byte> buffer)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CHandleQueue_003Ed__33))]
		private Task HandleQueue(List<ArraySegment<byte>> queue, WebSocketMessageType messageType)
		{
			return null;
		}

		public void DispatchMessageQueue()
		{
		}

		[AsyncStateMachine(typeof(_003CReceive_003Ed__36))]
		public Task Receive()
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CClose_003Ed__37))]
		public Task Close()
		{
			return null;
		}
	}
}
