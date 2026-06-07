using System.Collections.Generic;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.RSL.ReplicationManager.ClientWorld
{
	public struct WorldProcessResult
	{
		public List<EntityChange> Changes;

		public List<Entity> LiveQuery;

		public List<Entity> GlobalQuery;

		public List<IBaseRequest> GeneratedRequests;

		public void AddChange(EntityChange change)
		{
		}

		public void Reset()
		{
		}

		public bool MapToRelative(IEntityMapper mapper, Logger logger)
		{
			return false;
		}
	}
}
