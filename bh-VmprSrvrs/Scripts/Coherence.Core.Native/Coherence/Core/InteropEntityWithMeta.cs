using Coherence.Entities;

namespace Coherence.Core
{
	public struct InteropEntityWithMeta
	{
		public InteropEntity EntityId;

		public byte HasMeta;

		public byte HasStateAuthority;

		public byte HasInputAuthority;

		public byte IsOrphan;

		public uint LOD;

		public EntityOperation Operation;

		public DestroyReason DestroyReason;

		public EntityWithMeta Into()
		{
			return default(EntityWithMeta);
		}
	}
}
