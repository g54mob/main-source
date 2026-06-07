using System.ComponentModel;

namespace Coherence.Entities
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public struct SerializedMeta
	{
		public byte Version;

		public bool HasStateAuthority;

		public bool HasInputAuthority;

		public bool IsOrphan;

		public uint LOD;

		public EntityOperation Operation;

		public DestroyReason DestroyReason;

		public bool IsDeleted => false;
	}
}
