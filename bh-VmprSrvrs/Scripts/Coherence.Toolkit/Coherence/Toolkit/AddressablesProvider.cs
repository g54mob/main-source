using System;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Coherence.Toolkit
{
	[Serializable]
	[DisplayName("Addressables", "Load this Prefab using the Addressables package.")]
	public sealed class AddressablesProvider : INetworkObjectProvider
	{
		[SerializeField]
		private AssetReference assetReference;

		private int references;

		public int References => 0;

		public bool IsAssetLoaded => false;

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

		private void InvokeCallback(GameObject go, Action<ICoherenceSync> onLoaded)
		{
		}
	}
}
