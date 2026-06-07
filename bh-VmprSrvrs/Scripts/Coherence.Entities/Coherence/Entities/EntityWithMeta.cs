using System.ComponentModel;

namespace Coherence.Entities
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public struct EntityWithMeta
	{
		public Entity EntityId;

		public bool HasMeta;

		public bool HasStateAuthority;

		public bool HasInputAuthority;

		public bool IsOrphan;

		public uint LOD;

		public EntityOperation Operation;

		public DestroyReason DestroyReason;

		public bool IsAlive => false;

		public bool IsDestroyed => false;

		public override string ToString()
		{
			return null;
		}
	}
}
