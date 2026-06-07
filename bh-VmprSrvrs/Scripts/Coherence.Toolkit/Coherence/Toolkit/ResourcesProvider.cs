using System;
using UnityEngine;

namespace Coherence.Toolkit
{
	[Serializable]
	[DisplayName("Resources", "Load this prefab using the Resources system. The prefab must be inside a Resources folder.")]
	public sealed class ResourcesProvider : INetworkObjectProvider
	{
		[SerializeField]
		[ReadOnly(false)]
		private string resourcesPath;

		private ICoherenceSync syncObject;

		private int references;

		public int References => 0;

		public void LoadAsset(string networkAssetId, Action<ICoherenceSync> onLoaded)
		{
		}

		public ICoherenceSync LoadAsset(string networkAssetId)
		{
			return null;
		}

		private void GetSyncObject(string networkAssetId)
		{
		}

		public void Release(ICoherenceSync obj)
		{
		}

		public void OnApplicationQuit()
		{
		}

		private ICoherenceSync LoadCoherenceSync()
		{
			return null;
		}

		public void Initialize(CoherenceSyncConfig entry)
		{
		}

		public bool Validate(CoherenceSyncConfig entry)
		{
			return false;
		}
	}
}
