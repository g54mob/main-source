using System.Collections.Generic;
using Coherence.Connection;
using Coherence.RSL.Transport;

namespace Coherence.RSL.ReplicationManager
{
	public class ClientIDs
	{
		private Queue<ushort> availableIDs;

		private Dictionary<ConnectionID, ushort> idsByConnectionID;

		public ClientID Allocate(ConnectionID connectionID)
		{
			return default(ClientID);
		}

		public void Free(ConnectionID id)
		{
		}
	}
}
