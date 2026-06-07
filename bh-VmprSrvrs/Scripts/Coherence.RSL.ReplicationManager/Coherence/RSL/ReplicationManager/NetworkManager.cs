using System;
using System.Collections.Generic;
using Coherence.Connection;
using Coherence.Log;
using Coherence.RSL.Brisk.Connection;
using Coherence.RSL.Transport;
using Coherence.SimulationFrame;

namespace Coherence.RSL.ReplicationManager
{
	public class NetworkManager : IDisposable
	{
		private enum VerifyError
		{
			None = 0,
			InvalidChallenge = 1,
			IncompatibleVersion = 2
		}

		public static string ENVIRONMENT_DEV;

		public static string ENVIRONMENT_ENDUSER;

		private EndpointData endpoint;

		private string projectId;

		private string env;

		private int maxClients;

		private string secret;

		private Version rsVersion;

		private IReplicationManager replicationManager;

		private ClientIDs clientIDs;

		private Logger logger;

		private Dictionary<ConnectionID, IUserConnection> connections;

		private List<ConnectionID> connectionsToClose;

		private const string cloudProjectId = "coherence";

		public bool WaitForPersistence { private get; set; }

		public NetworkManager(EndpointData endpoint, string projectID, string env, int maxClients, string secret, IReplicationManager replicationManager, Logger logger)
		{
		}

		public void Dispose()
		{
		}

		public void Tick()
		{
		}

		public void HandleNewConnection(IUserConnection connection)
		{
		}

		public int GetTotalClientConnections()
		{
			return 0;
		}

		private void AcceptConnection(IUserConnection conn, AbsoluteSimulationFrame frame, ClientID clientID)
		{
		}

		private void CloseConnection(ConnectionID connectionID)
		{
		}

		private VerifyError VerifyChallenge(IUserConnection conn, out ConnectionType connectionType)
		{
			connectionType = default(ConnectionType);
			return default(VerifyError);
		}

		private VerifyError VerifyAuthToken(string authToken, bool isSimulator, string roomSecret, out ConnectionType connectionType)
		{
			connectionType = default(ConnectionType);
			return default(VerifyError);
		}

		private ConnectionType ParseConnectionType(string typ)
		{
			return default(ConnectionType);
		}
	}
}
