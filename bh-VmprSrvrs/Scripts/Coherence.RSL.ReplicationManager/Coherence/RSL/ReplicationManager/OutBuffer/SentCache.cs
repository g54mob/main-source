using System.Collections.Generic;
using Coherence.Common;
using Coherence.Entities;
using Coherence.Log;

namespace Coherence.RSL.ReplicationManager.OutBuffer
{
	public class SentCache
	{
		public enum Error
		{
			None = 0,
			CacheEmpty = 1
		}

		private bool noNull;

		private Queue<ChangeBuffer> queue;

		private Logger logger;

		public SentCache(bool noNull, Logger logger)
		{
		}

		public void InsertSentItem(ChangeBuffer changeBuffer)
		{
		}

		public Error Pop(out ChangeBuffer changeBuffer, out Queue<ChangeBuffer> inFlight)
		{
			changeBuffer = null;
			inFlight = null;
			return default(Error);
		}

		public void BumpPriorities()
		{
		}

		public bool ContainsCreateFor(Entity entity)
		{
			return false;
		}

		public List<uint> GetRemovesFor(Entity entity)
		{
			return null;
		}

		public void ShiftPositionComponents(Vector3d floatingOriginShift)
		{
		}

		public void GetOrderedComponents(Entity entity, out DeltaComponents? components)
		{
			components = null;
		}

		public override string ToString()
		{
			return null;
		}
	}
}
