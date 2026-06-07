using Coherence.Entities;

namespace Coherence.Toolkit
{
	public struct UnsyncedNetworkEntity
	{
		public NetworkEntityState EntityState;

		public ComponentUpdates Updates;

		public uint? LOD;

		public string UniqueUUID;
	}
}
