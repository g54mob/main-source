using System;
using System.Collections.Generic;
using System.Net;
using Coherence.Brook;
using Coherence.Connection;
using Coherence.Log;
using Coherence.Transport;

namespace Coherence.RSL.Transport
{
	public class TransportManager : IConnectionManager, IDisposable
	{
		private Logger logger;

		private IListenTransport transport;

		private Random rng;

		private IDSource idSource;

		private readonly List<(IInOctetStream, IPEndPoint)> incomingBuffer;

		private Dictionary<IPEndPoint, ITransportConnection> connections;

		public Action<ITransportConnection> OnConnectionAttempt { get; set; }

		public bool IsListening => false;

		public string LastTransportError { get; private set; }

		public TransportManager(EndpointData endpoint, IDSource idSource, IListenTransport transport, Logger logger)
		{
		}

		public void Dispose()
		{
		}

		public void Tick()
		{
		}

		public void OnConnectionClosed(ITransportConnection connection)
		{
		}

		private bool VerifyNewConnectionSessionID(SessionID sessionID)
		{
			return false;
		}

		private void HandleIncomingPackets()
		{
		}

		private void HandleNewConnection(IPEndPoint address, IInOctetStream packet)
		{
		}

		private IInOctetStream PrependSessionID(IInOctetStream packet, SessionID sessionID)
		{
			return null;
		}

		private SessionID GenerateSessionID()
		{
			return default(SessionID);
		}

		private void OnTransportError(ConnectionException e)
		{
		}

		public bool HasConnection(IPEndPoint address)
		{
			return false;
		}
	}
}
