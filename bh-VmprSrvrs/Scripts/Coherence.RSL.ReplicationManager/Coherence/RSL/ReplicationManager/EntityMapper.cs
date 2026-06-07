using System.Collections.Generic;
using Coherence.Core;
using Coherence.Entities;
using Coherence.Log;

namespace Coherence.RSL.ReplicationManager
{
	public class EntityMapper : IEntityMapper
	{
		private EntityIDGenerator entitySource;

		private Dictionary<Entity, Entity> absoluteByRelative;

		private Dictionary<Entity, Entity> relativeByAbsolute;

		private Dictionary<ushort, Entity> relativeIndexMap;

		private ushort startID;

		private ushort latestIndex;

		private ushort indexRange;

		private Logger logger;

		public EntityMapper(EntityIDGenerator entitySource, Logger logger)
		{
		}

		public EntityMapper(EntityIDGenerator entitySource, ushort startID, ushort endID)
		{
		}

		public bool HasRelativeEntityMapped(Entity relativeEntity)
		{
			return false;
		}

		public bool FindAbsoluteEntity(Entity relativeEntity, out Entity absoluteEntity)
		{
			absoluteEntity = default(Entity);
			return false;
		}

		public bool FindRelativeEntity(Entity absoluteEntity, out Entity relativeEntity)
		{
			relativeEntity = default(Entity);
			return false;
		}

		public IEntityMapper.Error MapToAbsoluteEntity(Entity relativeEntity, bool createEntityIfNotFound, out Entity absoluteEntity)
		{
			absoluteEntity = default(Entity);
			return default(IEntityMapper.Error);
		}

		public IEntityMapper.Error MapToRelativeEntity(Entity absoluteEntity, bool createEntityIfNotFound, out Entity relativeEntity)
		{
			relativeEntity = default(Entity);
			return default(IEntityMapper.Error);
		}

		public IEntityMapper.Error UnmapRelativeEntity(Entity relativeEntity, string reason)
		{
			return default(IEntityMapper.Error);
		}

		private void Associate(Entity absoluteEntity, Entity relativeEntity)
		{
		}

		private bool FindNextEmptyIndex(out ushort index)
		{
			index = default(ushort);
			return false;
		}

		private IEntityMapper.Error MapAbsoluteToRelative(Entity absoluteEntity, out Entity relativeEntity)
		{
			relativeEntity = default(Entity);
			return default(IEntityMapper.Error);
		}

		private void AssertRanges()
		{
		}
	}
}
