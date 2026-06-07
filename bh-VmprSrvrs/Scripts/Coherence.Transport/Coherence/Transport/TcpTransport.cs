using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using Coherence.Brook;
using Coherence.Common;
using Coherence.Common.Pooling;
using Coherence.Connection;
using Coherence.Log;
using Coherence.Stats;

namespace Coherence.Transport
{
	internal class TcpTransport : ITransport
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CConnectClient_003Ed__29 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public TcpClient client;

			public EndpointData endpoint;

			public TcpTransport _003C_003E4__this;

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

		private readonly Logger logger;

		private readonly IStats stats;

		private ConnectionSettings settings;

		private IPEndPoint originalRemoteEndpoint;

		private CancellationTokenSource cancellationSource;

		private ConcurrentQueue<(byte[], ConnectionException)> receiveQueue;

		private AsyncQueue<IOutOctetStream> sendQueue;

		private readonly Pool<PooledInOctetStream> streamPool;

		public TransportState State { get; private set; }

		public bool CanSend => false;

		public bool IsReliable => false;

		public int HeaderSize => 0;

		public string Description => null;

		public event Action OnOpen
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

		public event Action<ConnectionException> OnError
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

		public TcpTransport(IStats stats, Logger logger)
		{
		}

		public void Open(EndpointData endpoint, ConnectionSettings settings)
		{
		}

		public void Close()
		{
		}

		[AsyncStateMachine(typeof(_003CConnectClient_003Ed__29))]
		private Task ConnectClient(TcpClient client, EndpointData endpoint)
		{
			return null;
		}

		public void Send(IOutOctetStream data)
		{
		}

		public void Receive(List<(IInOctetStream, IPEndPoint)> buffer)
		{
		}

		private bool HandleReceiveException(ConnectionException exception)
		{
			return false;
		}

		private ConnectionException GetConnectionException(string message, Exception innerException)
		{
			return null;
		}

		private IPEndPoint GetEndpoint(EndpointData endpointData)
		{
			return null;
		}

		public void PrepareDisconnect()
		{
		}
	}
}
