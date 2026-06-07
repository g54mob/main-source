using System.Collections.Generic;
using Coherence.Entities;

namespace Coherence.RSL.ReplicationManager.OutBuffer
{
	public class Changes
	{
		private List<ChangeBuffer> changes;

		public Changes(int size)
		{
		}

		public void Add(ChangeBuffer change)
		{
		}

		public ChangeBuffer GetDelta(ChangeBuffer changes, IComponentInfo componentInfo)
		{
			return null;
		}

		private List<uint> UpdateComponents(ref EntityState existing, ref EntityState changedState)
		{
			return null;
		}

		private void DiffChanges(Dictionary<Entity, EntityState> droppedChanges, bool isInternalData, IComponentInfo componentInfo)
		{
		}
	}
}
