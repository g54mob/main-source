using System;
using System.Collections.Generic;
using Assets.Nimbatus.Scripts.Common.Helpers;
using Sirenix.OdinInspector;

namespace Assets.Nimbatus.Scripts.GalaxyMap.Shops
{
	[Serializable]
	public class ShopInventory : SerializedScriptableObject
	{
		public List<ShopInventorySettings> InventoryItems = new List<ShopInventorySettings>();

		public ShopInventoryItem GetItem(int seed, EMissionComplexity difficulty)
		{
			Random random = new Random(seed);
			return InventoryItems.RandomItemProbability((ShopInventorySettings i) => (!i.UseProbabilityByComplexity) ? i.Probability : i.ProbabilityByDifficulty.Evaluate((float)difficulty), random.Next()).GetShopInventoryItem(random.Next());
		}
	}
}
