using System.Collections.Generic;
using Coherence.Entities;

namespace Coherence.Core
{
	internal class SentCache
	{
		private LinkedList<ChangeBuffer> sentChanges;

		public (ChangeBuffer, LinkedList<ChangeBuffer>) Dequeue()
		{
			return default((ChangeBuffer, LinkedList<ChangeBuffer>));
		}

		public void Enqueue(ChangeBuffer changes)
		{
		}

		public void ClearAllChangesForEntity(Entity id)
		{
		}

		public bool HasChangesForEntity(Entity id)
		{
			return false;
		}

		public void ClearComponentChangesForEntity(Entity id, uint componentID)
		{
		}

		public bool HasComponentChangesForEntity(Entity id, uint componentID)
		{
			return false;
		}

		public void BumpPriorities()
		{
		}

		public void GetOrderedComponents(Entity entity, IComponentInfo componentInfo, out DeltaComponents? components)
		{
			components = null;
		}
	}
}
