using System.Collections.Generic;
using Coherence.Entities;

namespace Coherence.Toolkit
{
	internal class CoherenceLoopLookup
	{
		private readonly Dictionary<Entity, ICoherenceSyncUpdater> updateLookup;

		private readonly Dictionary<Entity, ICoherenceSyncUpdater> lateUpdateLookup;

		private readonly Dictionary<Entity, ICoherenceSyncUpdater> fixedUpdateLookup;

		public Dictionary<Entity, ICoherenceSyncUpdater>.ValueCollection Get(CoherenceSync.InterpolationLoop loop)
		{
			return null;
		}

		public void Add(Entity id, ICoherenceSyncUpdater updater, CoherenceSync.InterpolationLoop interpolationLocation)
		{
		}

		public void Remove(Entity id, CoherenceSync.InterpolationLoop interpolationLocation)
		{
		}

		public void Clear()
		{
		}
	}
}
