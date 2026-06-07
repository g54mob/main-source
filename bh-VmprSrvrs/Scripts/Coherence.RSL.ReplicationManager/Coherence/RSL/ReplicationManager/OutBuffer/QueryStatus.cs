using System.Collections.Generic;
using Coherence.Entities;

namespace Coherence.RSL.ReplicationManager.OutBuffer
{
	public struct QueryStatus
	{
		private bool synced;

		private bool created;

		private HashSet<Entity> unackedEnties;

		public bool Synced => false;

		public void Initialize(IReadOnlyList<Entity> queryBornEntities)
		{
		}

		public void Ack(Entity acked)
		{
		}

		public bool Check()
		{
			return false;
		}
	}
}
