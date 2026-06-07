using System;
using UnityEngine;
using VampireSurvivors.Data;

namespace Coherence.Toolkit
{
	[Serializable]
	[DisplayName("CharacterProvider", "Load a Character Prefab using the CharacterFactory.")]
	public sealed class CharacterProvider : INetworkObjectProvider
	{
		[SerializeField]
		private CharacterType _characterType;

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
