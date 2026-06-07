using System.Collections.Generic;
using Coherence.Entities;

namespace Coherence.Core
{
	internal class EntityRegistry : IEntityRegistry
	{
		private readonly HashSet<Entity> knownEntities;

		public EntityRegistry(HashSet<Entity> knownEntities)
		{
		}

		public bool EntityExists(in Entity entity)
		{
			return false;
		}

		bool IEntityRegistry.EntityExists(in Entity entity)
		{
			return false;
		}
	}
}
