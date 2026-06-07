using System.Collections.Generic;
using Coherence.Entities;
using Coherence.RSL.ReplicationManager.ClientWorld;

namespace Coherence.RSL.ReplicationManager.OutBuffer
{
	public class QuerySync
	{
		public struct Result
		{
			public bool LiveQuerySynced;

			public bool GlobalQuerySynced;
		}

		private Entity connectionEntity;

		private bool connectionEntitySynced;

		private QueryStatus liveQuery;

		private QueryStatus globalQuery;

		public bool LiveQuerySynced => false;

		public bool GlobalQuerySynced => false;

		public QuerySync(Entity connectionEntity)
		{
		}

		public Result Ack(IReadOnlyList<Entity> acked)
		{
			return default(Result);
		}

		public Result Update(WorldProcessResult result)
		{
			return default(Result);
		}

		public bool AllSynced()
		{
			return false;
		}

		public bool AnySynced()
		{
			return false;
		}

		public Result GetQuerySyncResult()
		{
			return default(Result);
		}
	}
}
