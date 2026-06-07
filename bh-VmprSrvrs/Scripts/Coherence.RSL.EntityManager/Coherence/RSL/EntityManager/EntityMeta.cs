using Coherence.Common;
using Coherence.Entities;

namespace Coherence.RSL.EntityManager
{
	public struct EntityMeta
	{
		public static EntityMeta Empty;

		public uint StateAuthority;

		public uint InputAuthority;

		public bool IsConnectionEntity;

		public bool HasPosition;

		public Vector3d Position;

		public bool HasArchetype;

		public uint Archetype;

		public uint ArchetypeLODLevel;

		public bool IsPersistent;

		public string UUID;

		public bool IsConnected;

		public bool PreserveChildren;

		public Entity ConnectedTo;

		public bool IsGlobal;

		public string Tag;

		public uint Scene;

		public bool IsOrphan => false;

		public bool IsIndexed => false;

		public bool IsTagged => false;

		public bool IsUnique => false;

		public static EntityMeta New()
		{
			return default(EntityMeta);
		}

		public void SetAuthority(AuthorityType authType, uint newAuthority)
		{
		}

		public override string ToString()
		{
			return null;
		}
	}
}
