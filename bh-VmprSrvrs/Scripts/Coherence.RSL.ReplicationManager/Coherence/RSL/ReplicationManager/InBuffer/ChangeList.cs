using System.Collections.Generic;
using Coherence.Entities;

namespace Coherence.RSL.ReplicationManager.InBuffer
{
	public class ChangeList
	{
		private List<EntityPriority> priorities;

		public IReadOnlyList<EntityPriority> Priorities => null;

		public int Count => 0;

		public ChangeList(int len)
		{
		}

		public void Add(EntityPriority priority)
		{
		}

		public void Set(EntityPriority priority, int index)
		{
		}

		public void Sort()
		{
		}

		public void Clear()
		{
		}

		public void RemoveEntities(IReadOnlyList<Entity> entities)
		{
		}
	}
}
