using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Coherence.Toolkit
{
	[PreloadedSingleton]
	public sealed class CoherenceSyncConfigRegistry : PreloadedSingleton<CoherenceSyncConfigRegistry>, IEnumerable<CoherenceSyncConfig>, IEnumerable
	{
		[SerializeField]
		private List<CoherenceSyncConfig> storedConfigs;

		private readonly List<CoherenceSyncConfig> configs;

		private readonly Dictionary<string, CoherenceSyncConfig> syncGuidToConfigDictionary;

		private readonly Dictionary<int, CoherenceSyncConfig> networkIdToConfigDictionary;

		public int Count => 0;

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
		private static void RuntimeInitialize()
		{
		}

		public CoherenceSyncConfig GetAt(int index)
		{
			return null;
		}

		public List<CoherenceSyncConfig>.Enumerator GetEnumerator()
		{
			return default(List<CoherenceSyncConfig>.Enumerator);
		}

		IEnumerator<CoherenceSyncConfig> IEnumerable<CoherenceSyncConfig>.GetEnumerator()
		{
			return null;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return null;
		}

		internal void Store()
		{
		}

		internal void ClearStore()
		{
		}

		private void RegisterStored()
		{
		}

		internal bool Register(CoherenceSyncConfig config)
		{
			return false;
		}

		internal bool Deregister(CoherenceSyncConfig config)
		{
			return false;
		}

		internal bool Deregister(string syncGuid)
		{
			return false;
		}

		private void DeregisterAll()
		{
		}

		internal void WarmUp(CoherenceBridge bridge)
		{
		}

		internal void CleanUp()
		{
		}

		public bool TryGetFromAssetId(string assetId, out CoherenceSyncConfig config)
		{
			config = null;
			return false;
		}

		public bool GetFromNetworkId(int networkId, out CoherenceSyncConfig config)
		{
			config = null;
			return false;
		}
	}
}
