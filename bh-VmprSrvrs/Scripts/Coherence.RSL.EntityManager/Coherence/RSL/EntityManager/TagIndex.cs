using System.Collections.Generic;
using Coherence.Entities;
using Coherence.Log;

namespace Coherence.RSL.EntityManager
{
	public class TagIndex
	{
		private Dictionary<string, HashSet<Entity>> lookup;

		private Dictionary<Entity, string> reverseLookup;

		private Logger logger;

		public TagIndex(Logger logger)
		{
		}

		public void Upsert(Entity entity, string tag)
		{
		}

		public void Remove(Entity entity)
		{
		}

		public List<Entity> GetEntitiesWithTag(string tag)
		{
			return null;
		}
	}
}
