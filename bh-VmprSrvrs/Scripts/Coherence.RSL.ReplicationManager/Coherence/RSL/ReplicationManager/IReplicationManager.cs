using Coherence.Connection;
using Coherence.RSL.Brisk.Connection;
using Coherence.RSL.Transport;

namespace Coherence.RSL.ReplicationManager
{
	public interface IReplicationManager
	{
		bool PersistenceReady { get; }

		void AddClient(IUserConnection userConnection, ClientID clientID);

		void RemoveClient(ConnectionID CID);
	}
}
