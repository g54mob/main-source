using System.Collections.Generic;
using Coherence.Entities;
using Coherence.Log;

namespace Coherence.Core
{
	public class EntityIDGenerator
	{
		public enum Error
		{
			None = 0,
			OutOfIDs = 1
		}

		private ushort runningEntityID;

		private readonly ushort startID;

		private readonly ushort endID;

		private readonly bool isAbsolute;

		private readonly Queue<Entity> reusableIDs;

		private readonly HashSet<ushort> reusableIDIndexes;

		public ushort MaxIndex => 0;

		public EntityIDGenerator(ushort startID, ushort endID, bool isAbsolute, Logger logger)
		{
		}

		public Error GetEntity(out Entity entity)
		{
			entity = default(Entity);
			return default(Error);
		}

		public void ReleaseEntity(Entity id)
		{
		}

		public void Reset()
		{
		}
	}
}
