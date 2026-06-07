using System.Collections.Generic;
using Coherence.Connection;
using Coherence.Log;

namespace Coherence.Toolkit.Relay
{
	public class CoherenceRelayManager
	{
		internal delegate RelayConnectionHolder RelayConnectionHolderCreator(IRelayConnection connection);

		private readonly Dictionary<IRelayConnection, RelayConnectionHolder> connections;

		private readonly List<IRelayConnection> pendingRemoves;

		private EndpointData endpointData;

		private IRelay relay;

		private bool isOpen;

		private bool isUpdatingConnections;

		private readonly Logger logger;

		private readonly RelayConnectionHolderCreator relayConnectionHolderCreator;

		internal IRelay CurrentRelay => null;

		internal CoherenceRelayManager(Logger logger)
		{
		}

		internal CoherenceRelayManager(RelayConnectionHolderCreator relayConnectionHolderCreator, Logger logger)
		{
		}

		internal void Open(EndpointData newEndpointData)
		{
		}

		internal void Close()
		{
		}

		internal void Update()
		{
		}

		private void UpdateRelayedConnections()
		{
		}

		private void HandlePendingConnectionRemovals()
		{
		}

		public void OpenRelayConnection(IRelayConnection connection)
		{
		}

		public void CloseAndRemoveRelayConnection(IRelayConnection connection)
		{
		}

		private void HandleConnectionError(IRelayConnection connection, ConnectionException e)
		{
		}

		internal void SetRelay(IRelay newRelay)
		{
		}
	}
}
