using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.WebSockets;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

public class Wamp
{
	public class TimeoutException : Exception
	{
		public TimeoutException(string message)
		{
		}
	}

	public class WampNotConnectedException : Exception
	{
		public WampNotConnectedException(string message)
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
		{
		}

		public static ErrorException FromResponse(string response)
		{
			return null;
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

	[StructLayout((LayoutKind)3)]
	[CompilerGenerated]
	private struct _003CCall_003Ed__34 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<string> _003C_003Et__builder;

		public Wamp _003C_003E4__this;

		public string options;

		public string uri;

		public string args;

		public int timeout;

		private int _003CrequestId_003E5__2;

		private TaskAwaiter _003C_003Eu__1;

		private TaskAwaiter<Response> _003C_003Eu__2;

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
	private struct _003CClose_003Ed__30 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public Wamp _003C_003E4__this;

		public int timeout;

		private TaskAwaiter _003C_003Eu__1;

		private TaskAwaiter<Response> _003C_003Eu__2;

		private CancellationTokenSource _003Ccts_003E5__2;

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

		public string host;

		public Wamp _003C_003E4__this;

		public int timeout;

		private CancellationTokenSource _003Ccts_003E5__2;

		private TaskAwaiter _003C_003Eu__1;

		private TaskAwaiter<Response> _003C_003Eu__2;

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
	private struct _003CReceive_003Ed__25 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<Response> _003C_003Et__builder;

		public Wamp _003C_003E4__this;

		public int timeout;

		private TaskAwaiter<Task> _003C_003Eu__1;

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
	private struct _003CReceiveExpect_003Ed__26 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<Response> _003C_003Et__builder;

		public Wamp _003C_003E4__this;

		public int timeout;

		public Messages message;

		public int requestId;

		private TaskAwaiter<Response> _003C_003Eu__1;

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
	private struct _003CReceiveMessage_003Ed__24 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<Response> _003C_003Et__builder;

		public Wamp _003C_003E4__this;

		private List<IEnumerable<byte>> _003Csegments_003E5__2;

		private ArraySegment<byte> _003Csegment_003E5__3;

		private TaskAwaiter<WebSocketReceiveResult> _003C_003Eu__1;

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
	private struct _003CSend_003Ed__16 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public int timeout;

		public string msg;

		public Wamp _003C_003E4__this;

		private CancellationTokenSource _003Ccts_003E5__2;

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
	private struct _003CSubscribe_003Ed__35 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<uint> _003C_003Et__builder;

		public Wamp _003C_003E4__this;

		public string options;

		public string topic;

		public int timeout;

		public PublishHandler publishEvent;

		private int _003CrequestId_003E5__2;

		private TaskAwaiter _003C_003Eu__1;

		private TaskAwaiter<Response> _003C_003Eu__2;

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
	private struct _003CUnsubscribe_003Ed__36 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public Wamp _003C_003E4__this;

		public uint subscriptionId;

		public int timeout;

		private int _003CrequestId_003E5__2;

		private TaskAwaiter _003C_003Eu__1;

		private TaskAwaiter<Response> _003C_003Eu__2;

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

	private int sessionId;

	private int currentRequestId;

	private CancellationTokenSource stopServerTokenSource;

	private TaskCompletionSource<Response> taskCompletion;

	private ConcurrentDictionary<uint, PublishHandler> subscriptions;

	public event DisconnectedHandler Disconnected
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

	[AsyncStateMachine(typeof(_003CSend_003Ed__16))]
	private Task Send(string msg, int timeout)
	{
		return null;
	}

	private Response Parse(string msg)
	{
		return null;
	}

	private static Response ParseResult(string msg)
	{
		return null;
	}

	private static Response ParseSubscribed(string msg)
	{
		return null;
	}

	private static Response ParseUnsubscribed(string msg)
	{
		return null;
	}

	private static Response ParseGoodbye(string msg)
	{
		return null;
	}

	private static Response ParseWelcome(string msg)
	{
		return null;
	}

	private static Response ParseEvent(string msg)
	{
		return null;
	}

	[AsyncStateMachine(typeof(_003CReceiveMessage_003Ed__24))]
	private Task<Response> ReceiveMessage()
	{
		return null;
	}

	[AsyncStateMachine(typeof(_003CReceive_003Ed__25))]
	private Task<Response> Receive(int timeout)
	{
		return null;
	}

	[AsyncStateMachine(typeof(_003CReceiveExpect_003Ed__26))]
	private Task<Response> ReceiveExpect(Messages message, int requestId, int timeout)
	{
		return null;
	}

	[AsyncStateMachine(typeof(_003CConnect_003Ed__27))]
	internal Task Connect(string host, int timeout)
	{
		return null;
	}

	internal bool IsConnected()
	{
		return false;
	}

	internal WebSocketState SocketState()
	{
		return default(WebSocketState);
	}

	[AsyncStateMachine(typeof(_003CClose_003Ed__30))]
	internal Task Close(int timeout)
	{
		return null;
	}

	private void ProcessEvent(Response message)
	{
	}

	private void StartListen()
	{
	}

	private void OnDisconnect()
	{
	}

	[AsyncStateMachine(typeof(_003CCall_003Ed__34))]
	internal Task<string> Call(string uri, string args, string options, int timeout)
	{
		return null;
	}

	[AsyncStateMachine(typeof(_003CSubscribe_003Ed__35))]
	internal Task<uint> Subscribe(string topic, string options, PublishHandler publishEvent, int timeout)
	{
		return null;
	}

	[AsyncStateMachine(typeof(_003CUnsubscribe_003Ed__36))]
	internal Task Unsubscribe(uint subscriptionId, int timeout)
	{
		return null;
	}
}
