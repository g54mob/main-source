using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.CompilerServices;
using Coherence.Brook;
using Coherence.Common.Pooling;
using Coherence.Connection;
using Coherence.Log;
using Coherence.Transport;

namespace Coherence.Toolkit.Relay
{
	internal class RelayConnectionHolder
	{
		private readonly Logger logger;

		private readonly ITransport replicationServerTransport;

		private readonly IRelayConnection relayConnection;

		private readonly List<(IInOctetStream, IPEndPoint)> serverToClientBuffer;

		private readonly List<ArraySegment<byte>> clientToServerBuffer;

		private readonly Pool<PooledOutOctetStream> oobStreamPool;

		public event Action<IRelayConnection, ConnectionException> OnError
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

		internal RelayConnectionHolder(EndpointData endpointData, IRelayConnection relayConnection, Logger logger, ITransport transport = null)
		{
		}

		internal void Close()
		{
		}

		internal void Update()
		{
		}

		private void SendDisconnectOOBMessage()
		{
		}

		private void RelayToServer(ArraySegment<byte> packet)
		{
		}

		private void HandleConnectionError(ConnectionException e)
		{
		}
	}
}
