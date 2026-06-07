using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Net;
using System.Runtime.CompilerServices;
using Coherence.Brook;
using Coherence.Common;
using Coherence.Connection;
using Coherence.Flux;
using Coherence.Log;
using Coherence.Stats;

namespace Coherence.Transport
{
	public class UdpTransport : ITransport
	{
		public const int HeaderSizeBytes = 4;

		protected readonly Coherence.Flux.Flux flux;

		protected readonly Logger logger;

		protected readonly IDateTimeProvider dateTimeProvider;

		protected DateTime lastValidPacketTime;

		protected ConnectionSettings settings;

		protected bool dev_blockTraffic;

		private readonly IStats stats;

		private readonly UdpClient port;

		private readonly ConcurrentQueue<(IInOctetStream stream, IPEndPoint from)> receiveQueue;

		private SessionID sessionID;

		public TransportState State { get; protected set; }

		public bool IsReliable => false;

		public bool CanSend => false;

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

		public UdpTransport(IStats stats, Logger logger, IDateTimeProvider dateTimeProvider = null)
		{
		}

		private void DevSetup()
		{
		}

		public void Open(EndpointData endpoint, ConnectionSettings settings)
		{
		}

		public void Close()
		{
		}

		public void Send(IOutOctetStream stream)
		{
		}

		private void WriteHeaderWithSpaceForRoomID(IOutOctetStream stream)
		{
		}

		public void Receive(List<(IInOctetStream, IPEndPoint)> buffer)
		{
		}

		public void PrepareDisconnect()
		{
		}

		protected void RaiseOnOpen()
		{
		}

		protected void RaiseOnError(ConnectionException exception)
		{
		}

		protected virtual void CheckForTimeout(bool anyValidPacketReceived)
		{
		}

		protected virtual bool HandleSessionID(IInOctetStream stream)
		{
			return false;
		}

		private void OnPacket(IInOctetStream stream, IPEndPoint receivedFrom)
		{
		}
	}
}
