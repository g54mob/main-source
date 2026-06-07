using System.Collections.Generic;

namespace Coherence.Entities
{
	public class EntityComparer : IEqualityComparer<Entity>
	{
		public bool Equals(Entity a, Entity b)
		{
			return false;
		}

		public int GetHashCode(Entity obj)
		{
			return 0;
		}
	}
}
