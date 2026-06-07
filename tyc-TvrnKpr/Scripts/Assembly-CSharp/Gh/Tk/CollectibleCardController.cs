using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting;
using UnityEngine.Serialization;

namespace Gh.Tk
{
	[InitializeOnGameStarted]
	public class CollectibleCardController : SingletonMonoBehaviour<CollectibleCardController>
	{
		[FormerlySerializedAs("_tradingCardPrefab")]
		[SerializeField]
		private GameObject _collectibleCardPrefab;

		private PrefabObjectPool _collectibleCardPool;

		[field: SerializeField]
		public List<CollectibleCardData> AllCollectibleCards { get; private set; }

		public Dictionary<int, CollectibleCardData> AllCollectibleCardsDict { get; private set; }

		[Preserve]
		private static void OnGameStarted()
		{
		}

		private static void OnCloudInventoryChanged(object sender, EventArgs e)
		{
		}

		public override void Awake()
		{
		}

		public IEnumerable<GreenbackRewardData> GetUnseenRewards()
		{
			return null;
		}

		public IEnumerable<GreenbackRewardData> GetCardRewardsPendingUnpack()
		{
			return null;
		}

		public int GetCardAmountPendingUnpack()
		{
			return 0;
		}

		private void SynchronizeRewardsFromServer()
		{
		}

		public CollectibleCard3DUIView GetCardView(CollectibleCardData cardData, bool useDissolveMaterials = true, bool enableRarityEffects = false)
		{
			return null;
		}
	}
}
