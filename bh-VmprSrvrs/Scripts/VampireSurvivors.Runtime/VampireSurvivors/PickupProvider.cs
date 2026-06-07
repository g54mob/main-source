using System;
using Coherence.Toolkit;
using UnityEngine;
using VampireSurvivors.Data;

namespace VampireSurvivors
{
	public class PickupProvider : INetworkObjectProvider
	{
		[SerializeField]
		private ItemType _itemType;

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
