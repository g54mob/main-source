using System;
using System.Collections.Generic;
using Coherence.Log;

namespace Coherence.Toolkit
{
	public class UniquenessManager : IDisposable
	{
		private Dictionary<string, UniqueObjectReplacement> uniqueObjectReplacementDict;

		private Queue<string> registeredUniqueIds;

		private readonly Logger logger;

		internal UniquenessManager(Logger logger)
		{
		}

		public void RegisterUniqueId(string uniqueIdentifier)
		{
		}

		internal string GetUniqueId()
		{
			return null;
		}

		public UniqueObjectReplacement TryGetUniqueObject(string uuid)
		{
			return null;
		}

		internal bool FindUniqueObjectForNewRemoteNetworkEntity(SpawnInfo info, Action onBeforeLocalObjectInit)
		{
			return false;
		}

		internal bool RegisterUniqueCoherenceSyncAndDestroyIfDuplicate(ICoherenceSync sync, string uuid)
		{
			return false;
		}

		internal bool ReplaceRemoteDuplicatedEntity(ICoherenceSync sync, NetworkEntityState entity)
		{
			return false;
		}

		internal void OnUniqueObjectDestroyed(string uuid)
		{
		}

		private bool CheckUniqueObjectReplacement(string uuid, Action onBeforeLocalObjectInit)
		{
			return false;
		}

		private void RemoveEntityFromObjectReplacementDict(string uuid)
		{
		}

		void IDisposable.Dispose()
		{
		}
	}
}
