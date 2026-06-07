using Coherence.Entities;
using Coherence.ProtocolDef;
using Coherence.RSL.EntityManager;

namespace Coherence.RSL.ReplicationManager.OutBuffer
{
	public struct EntityState
	{
		public bool IsDirty;

		public EntityOperation Operation;

		public long Priority;

		public EntityMeta Meta;

		public DeltaComponents Components;

		public bool WasTransferred;

		public bool IsInternal;

		public DestroyReason DestroyReason;

		public int PriorityIndex;

		public bool IsDestroy => false;

		public bool IsCreate => false;

		public bool IsUpdate => false;

		public bool HasExistencenceOperation => false;

		public static EntityState New()
		{
			return default(EntityState);
		}

		public static EntityState Diff(EntityState old, EntityState current)
		{
			return default(EntityState);
		}

		public static EntityState Merge(EntityState old, EntityState change)
		{
			return default(EntityState);
		}

		public EntityState Clone()
		{
			return default(EntityState);
		}

		public void Reset()
		{
		}

		public void ResetWithOldState(EntityState lostState, IDefinition root)
		{
		}

		public new string ToString()
		{
			return null;
		}
	}
}
