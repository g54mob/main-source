using System.Collections.Generic;
using Coherence.Entities;
using Coherence.Log;
using Coherence.RSL.EntityManager;

namespace Coherence.RSL.ReplicationManager.ClientWorld
{
	public struct EntityChange
	{
		public long Priority;

		public bool IsInternal;

		public ChangeType Type;

		public Entity Entity;

		public EntityMeta Meta;

		public ICoherenceComponentData[] Data;

		public bool WasTransferred;

		public List<uint> Remove;

		public DestroyReason Reason;

		public ChannelID ChannelID;

		public static EntityChange NewCreateChange(long priority, bool isInternal, Entity entity, ICoherenceComponentData[] data, EntityMeta meta, ChannelID channelID)
		{
			return default(EntityChange);
		}

		public static EntityChange NewUpdateChange(long priority, bool isInternal, Entity entity, ICoherenceComponentData[] data, EntityMeta meta, bool wasTransferred, ChannelID channelID)
		{
			return default(EntityChange);
		}

		public static EntityChange NewRemoveChange(long priority, bool isInternal, Entity entity, IReadOnlyList<uint> removedComponents, EntityMeta meta, ChannelID channelID)
		{
			return default(EntityChange);
		}

		public static EntityChange NewDestroyChange(long priority, bool isInternal, Entity entity, DestroyReason reason, ChannelID channelID)
		{
			return default(EntityChange);
		}

		public IEntityMapper.Error MapToRelativeEntity(IEntityMapper mapper, Logger logger)
		{
			return default(IEntityMapper.Error);
		}

		public bool ContainsOrderedComponent(IComponentInfo root)
		{
			return false;
		}

		public override string ToString()
		{
			return null;
		}
	}
}
