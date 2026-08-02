using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace GRP.Net
{
	public class NetServer
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CDisconnect_003Ed__24 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public float delay;

			public NetServer _003C_003E4__this;

			public NetConn conn;

			private TaskAwaiter<int> _003C_003Eu__1;

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

		public NetManager manager;

		public NetTransport transport;

		public List<NetConn> connections;

		public Dictionary<int, NetConn> connectionById;

		private Dictionary<Type, List<NetServerHandlerDelegate>> handlers;

		public event Action<NetConn> OnConnected
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

		public event Action<NetConn> OnDisconnected
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

		public event Action<NetConn, TransportError, string> OnError
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

		public event Action<NetConn, Exception> OnTransportException
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

		public NetServer(NetManager manager)
		{
		}

		public void EarlyUpdate()
		{
		}

		public void LateUpdate()
		{
		}

		public void Destroy()
		{
		}

		public void SendToAll<T>(T message, NetChannel channel = NetChannel.Reliable) where T : struct, NetMessage
		{
		}

		public void SendToOne<T>(NetConn conn, T message, NetChannel channel = NetChannel.Reliable) where T : struct, NetMessage
		{
		}

		public void Disconnect(NetConn conn)
		{
		}

		[AsyncStateMachine(typeof(_003CDisconnect_003Ed__24))]
		public void Disconnect(NetConn conn, float delay)
		{
		}

		public void RegisterHandler<T>(Action<NetConn, T> handler) where T : struct, NetMessage
		{
		}

		public void UnregisterHandler<T>() where T : struct, NetMessage
		{
		}

		private void HandleOnConnected(int connectionId)
		{
		}

		private void HandleOnDataReceived(int connectionId, ArraySegment<byte> segment, NetChannel channel)
		{
		}

		private void HandleOnError(int connectionId, TransportError error, string message)
		{
		}

		private void HandleOnTransportException(int connectionId, Exception exception)
		{
		}

		private void HandleOnServerDisconnected(int connectionId)
		{
		}
	}
}
