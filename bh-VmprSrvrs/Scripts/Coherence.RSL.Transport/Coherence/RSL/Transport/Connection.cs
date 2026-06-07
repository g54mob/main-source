using System;
using System.Net;
using Coherence.Brook;
using Coherence.Log;
using Coherence.Transport;

namespace Coherence.RSL.Transport
{
	public class Connection : ITransportConnection
	{
		private IListenTransport transport;

		private IPEndPoint endpoint;

		private ConnectionID connectionID;

		private SessionID sessionID;

		private Logger logger;

		public Action<IInOctetStream> RecvChannel { private get; set; }

		public IPEndPoint Address => null;

		public ITransport Transport => null;

		public int HeaderSize => 0;

		public ConnectionID ID()
		{
			return default(ConnectionID);
		}

		public bool IsReliable()
		{
			return false;
		}

		public SessionID SessionID()
		{
			return default(SessionID);
		}

		public bool CanSend()
		{
			return false;
		}

		public Connection(IListenTransport transport, IPEndPoint endpoint, ConnectionID connectionID, SessionID sessionID, Logger logger)
		{
		}

		public void SendPacket(IOutOctetStream data)
		{
		}

		public void HandleIncomingPacket(IInOctetStream data)
		{
		}

		public void Close(IOutOctetStream optionalData = null)
		{
		}

		private bool HandleSessionID(SessionID id)
		{
			return false;
		}
	}
}
