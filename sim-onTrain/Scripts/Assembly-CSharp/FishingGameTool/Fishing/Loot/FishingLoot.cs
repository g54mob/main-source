using System.Collections.Generic;
using FishingGameTool.Fishing.LootData;
using UnityEngine;

namespace FishingGameTool.Fishing.Loot
{
	[AddComponentMenu("Fishing Game Tool/Fishing Loot")]
	public class FishingLoot : MonoBehaviour
	{
		public List<FishingLootData> _fishingLoot = new List<FishingLootData>();

		public List<FishingLootData> GetFishingLoot()
		{
			return _fishingLoot;
		}
	}
}
