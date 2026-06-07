using Assets.Nimbatus.Scripts.Receivables;
using Assets.Nimbatus.Scripts.Receivables.ReceivableSettings;
using Assets.Nimbatus.Scripts.World.Terrain.ClimateZone;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.GalaxyMap.Shops
{
	public class ShopInventorySettings
	{
		public int MinStack = 1;

		public int MaxStack = 1;

		public bool UseProbabilityByComplexity;

		[HideIf("UseProbabilityByComplexity", true)]
		[Indent(1)]
		public float Probability = 1f;

		[ShowIf("UseProbabilityByComplexity", true)]
		[Indent(1)]
		public AnimationCurve ProbabilityByDifficulty = new AnimationCurve(new Keyframe(1f, 0.1f), new Keyframe(5f, 0.9f));

		public ItemPrice Price = new ItemPrice(ETerrainMaterial.CommonOre, 100);

		public BaseReceivableSettings Receivable;

		public ShopInventoryItem GetShopInventoryItem(int seed)
		{
			BaseReceivable item = Receivable.CreateReceivable(seed, 1);
			int stackSize = Random.Range(MinStack, MaxStack + 1);
			return new ShopInventoryItem
			{
				Item = item,
				Price = Price,
				StackSize = stackSize
			};
		}
	}
}
