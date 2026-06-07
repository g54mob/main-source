using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using Coherence.Brook;
using Coherence.Brook.Octet;
using Coherence.Common;
using Coherence.Common.Pooling;
using Coherence.Connection;
using Coherence.Log;
using Coherence.Stats;

namespace Coherence.Transport
{
	public class UdpTransportV2 : IListenTransport, ITransport
	{
		private struct ReceiveEvent
		{
			public ArraySegment<byte> Data;

			public ConnectionException Error;

			public IPEndPoint From;
		}

		public const int HeaderSizeBytes = 4;

		private static readonly IPEndPoint AnyEndpoint;

		private Socket socket;

		private IPEndPoint remoteEndPoint;

		private readonly IStats stats;

		private readonly Logger logger;

		private SessionID sessionId;

		private ushort roomId;

		private ushort maxBufferSize;

		private readonly Timeout timeout;

		private readonly Pool<byte[]> bufferPool;

		private readonly Pool<PooledInOctetStream> streamPool;

		private readonly ConcurrentQueue<ReceiveEvent> receiveQueue;

		public TransportState State { get; private set; }

		public bool IsReliable => false;

		public bool CanSend => false;

		public int HeaderSize => 0;

		public string Description => null;

		private bool IsInListenMode => false;

		private bool IsInClientMode => false;

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

		public void PrepareDisconnect()
		{
		}

		public UdpTransportV2(ushort maxBufferSize, IStats stats, Logger logger, IDateTimeProvider dateTimeProvider = null)
		{
		}

		public void Open(EndpointData endpoint, ConnectionSettings settings)
		{
		}

		public void Listen(EndpointData endpoint, ConnectionSettings settings)
		{
		}

		public void Close()
		{
		}

		private void Close(bool raiseError)
		{
		}

		private void StartReceiving()
		{
		}

		private void Receive(SocketAsyncEventArgs args)
		{
		}

		private void DataReceived(SocketAsyncEventArgs args)
		{
		}

		public void Send(IOutOctetStream stream)
		{
		}

		public void SendTo(IOutOctetStream stream, IPEndPoint endpoint, SessionID sessionID)
		{
		}

		private void Send(IOutOctetStream stream, SessionID sessionID, IPEndPoint endpoint = null)
		{
		}

		private void WriteHeader(IOutOctetStream stream, SessionID sessionID)
		{
		}

		public void Receive(List<(IInOctetStream, IPEndPoint)> buffer)
		{
		}

		private bool HandleRoomId(InOctetStream stream)
		{
			return false;
		}

		private bool HandleSessionId(InOctetStream stream)
		{
			return false;
		}

		private void HandleTimeout(ConnectionTimeoutException timeoutException)
		{
		}

		private static IPEndPoint GetIPEndPoint(in EndpointData endpoint)
		{
			return null;
		}
	}
}
