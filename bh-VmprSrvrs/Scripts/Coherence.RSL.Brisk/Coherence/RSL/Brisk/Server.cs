using System;
using System.Collections.Generic;
using Coherence.Log;
using Coherence.RSL.Brisk.Connection;
using Coherence.RSL.Transport;

namespace Coherence.RSL.Brisk
{
	public class Server : IDisposable
	{
		public Action<Coherence.RSL.Brisk.Connection.Connection> OnConnectionUpgrade;

		private IConnectionManager connectionManager;

		private TimeSpan disconnectTimeout;

		private int sendFrequency;

		private Dictionary<ConnectionID, Coherence.RSL.Brisk.Connection.Connection> connections;

		private List<Coherence.RSL.Brisk.Connection.Connection> toCloseCache;

		private readonly OutStreamPool streamPool;

		private Logger logger;

		public Server(IConnectionManager connectionManager, TimeSpan disconnectTimeout, int sendFrequency, Logger logger)
		{
		}

		public void Dispose()
		{
		}

		public void Tick()
		{
		}

		public void SetDisconnectTimeout(TimeSpan disconnectTimeout)
		{
		}

		private void OnConnectionAttempt(ITransportConnection connection)
		{
		}

		private void OnUpgrade(Coherence.RSL.Brisk.Connection.Connection connection)
		{
		}

		private void OnClose(Coherence.RSL.Brisk.Connection.Connection connection)
		{
		}
	}
}
