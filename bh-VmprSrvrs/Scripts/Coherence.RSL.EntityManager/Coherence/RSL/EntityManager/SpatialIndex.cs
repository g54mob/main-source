using System.Collections.Generic;
using Coherence.Common;
using Coherence.Entities;
using Coherence.Log;
using Coherence.RSL.EntityManager.Query;

namespace Coherence.RSL.EntityManager
{
	public class SpatialIndex
	{
		private Dictionary<Entity, SpatialInfo> indexed;

		private Logger logger;

		public SpatialIndex(Logger logger)
		{
		}

		public void Insert(Entity entity, Vector3d position)
		{
		}

		public void Update(Entity entity, Vector3d oldPos, Vector3d newPos)
		{
		}

		public void Remove(Entity entity, Vector3d pos)
		{
		}

		public bool Exists(Entity entity)
		{
			return false;
		}

		public List<SpatialInfo> SerchIntersect(BoundingRect rect)
		{
			return null;
		}
	}
}
