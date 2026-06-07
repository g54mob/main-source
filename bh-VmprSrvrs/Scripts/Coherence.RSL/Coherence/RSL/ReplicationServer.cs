using System;
using Coherence.Common;
using Coherence.Connection;
using Coherence.Log;
using Coherence.RSL.Brisk;
using Coherence.RSL.ReplicationManager;
using Coherence.RSL.Transport;
using Coherence.Transport;

namespace Coherence.RSL
{
	public class ReplicationServer : IReplicationServerLite, IDisposable
	{
		private Logger logger;

		private IDSource idSource;

		private TransportManager transportManager;

		private Server briskServer;

		private Coherence.RSL.ReplicationManager.ReplicationManager replicationManager;

		private NetworkManager networkManager;

		public bool IsListening => false;

		public string LastNetworkError => null;

		public int TotalConnectedClients => 0;

		public ReplicationServer(IExtendedDefinition root, EndpointData endpoint, string env, string projectID, int maxClients, double minQueryDistance, int sendFrequency, TimeSpan disconnectTimeout, string secret, HostAuthority hostAuthority, Logger logger, TransportConditioner.Configuration conditioningConfig = null)
		{
		}

		public void Tick()
		{
		}

		public void Dispose()
		{
		}

		private void DisposeSafely(IDisposable disposable)
		{
		}
	}
}
