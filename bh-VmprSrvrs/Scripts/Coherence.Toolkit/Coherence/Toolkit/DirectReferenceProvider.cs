using System;
using UnityEngine;

namespace Coherence.Toolkit
{
	[Serializable]
	[DisplayName("Direct Reference", "Load this prefab using a direct reference to the asset. The prefab cannot be inside a Resources folder.")]
	public sealed class DirectReferenceProvider : INetworkObjectProvider
	{
		[SerializeField]
		[ReadOnly(false)]
		private GameObject prefab;

		public void LoadAsset(string networkAssetId, Action<ICoherenceSync> onLoaded)
		{
		}

		public ICoherenceSync LoadAsset(string networkAssetId)
		{
			return null;
		}

		public void Release(ICoherenceSync obj)
		{
		}

		public void OnApplicationQuit()
		{
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
