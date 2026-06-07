using System;
using System.Collections.Generic;
using System.Net;
using Coherence.Brook;
using Coherence.Common;
using Coherence.Connection;
using Coherence.Log;

namespace Coherence.Transport
{
	public class ListenTransportConditioner : TransportConditioner, IListenTransport, ITransport
	{
		private struct OutgoingSendToData
		{
			public IOutOctetStream Data;

			public IPEndPoint Endpoint;

			public SessionID SessionID;
		}

		private readonly IListenTransport transport;

		private readonly Queue<OutgoingSendToData> heldOutgoingSendToPackets;

		private readonly Queue<DelayedPacket<OutgoingSendToData>> delayedOutgoingSendToPackets;

		public ListenTransportConditioner(IListenTransport transport, IDateTimeProvider dateTimeProvider, Logger logger)
			: base(null, null, null)
		{
		}

		public void Listen(EndpointData entpointData, ConnectionSettings settings)
		{
		}

		public void SendTo(IOutOctetStream data, IPEndPoint endpoint, SessionID sessionID)
		{
		}

		protected override void FlushDelayedOutgoingPackets()
		{
		}

		protected override void ProcessDelayedOutgoingPackets(DateTime now)
		{
		}
	}
}
