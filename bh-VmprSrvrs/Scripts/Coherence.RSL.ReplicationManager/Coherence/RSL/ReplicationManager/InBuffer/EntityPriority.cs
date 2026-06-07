using Coherence.Entities;

namespace Coherence.RSL.ReplicationManager.InBuffer
{
	public struct EntityPriority
	{
		public Entity Entity { get; private set; }

		public long Priority { get; private set; }

		public uint Authority { get; private set; }

		public bool WasTransferred { get; private set; }

		public bool IsInternal { get; private set; }

		public EntityOperation Operation { get; private set; }

		public bool HasUpdates { get; private set; }

		public bool HasRemoves { get; private set; }

		public EntityPriority(Entity entity, long priority, uint authority, bool wasTransferred, bool isInternal, EntityOperation operation, bool hasUpdates, bool hasRemoves)
		{
			Entity = default(Entity);
			Priority = 0L;
			Authority = 0u;
			WasTransferred = false;
			IsInternal = false;
			Operation = default(EntityOperation);
			HasUpdates = false;
			HasRemoves = false;
		}

		public bool HasExistenceOperation()
		{
			return false;
		}
	}
}
