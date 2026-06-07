using Coherence.Entities;

namespace Coherence.Toolkit
{
	public class NetworkEntityState
	{
		public CoherenceClientConnection ClientConnection;

		public Entity EntityID { get; }

		public string CoherenceUUID { get; internal set; }

		public ObservableAuthorityType AuthorityType { get; }

		public bool IsOrphaned { get; internal set; }

		public bool NetworkInstantiated { get; }

		public bool IsMyClientConnection => false;

		public float LastTimeRequestedOrphanAdoption { get; internal set; }

		public ICoherenceSync Sync { get; internal set; }

		public bool HasStateAuthority => false;

		public bool HasInputAuthority => false;

		internal NetworkEntityState(Entity entityId, AuthorityType authority, bool isOrphaned, bool networkInstantiated, ICoherenceSync sync, string uuid)
		{
		}
	}
}
