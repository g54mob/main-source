using System.Collections.Generic;
using Assets.Source.Item;
using Assets.Source.Player;

namespace Assets.Source.World.Frames
{
	public class T10AscensionBooster : CraftingFrame
	{
		public override int AutoWorkerCount => 6;

		public override int HandCraftButtonCount => 1;

		public override TechNode RequiredTech => "t10f_ascension_booster";

		public T10AscensionBooster()
		{
			base.ItemHint = "ascension_booster";
			base.PlacementTech = "t10u_ascension_booster_placement";
			base.MusicName = "FastLanesLightRain";
			_reagents["ai_training_data"] = 1;
			_reagents["gyroscope"] = 2;
			_reagents["superconductor"] = 2;
			_results["ascension_booster"] = 1;
			_baseCraftingTime = 1f;
			_firstCost = new List<ItemType> { "superconductor", "unshackled_widget" };
			_baseCost = new List<ItemType> { "superconductor", "ascended_widget" };
			_extraCostMultiplier = 1.3f;
		}

		protected override float CalculatePlacementBonus()
		{
			HashSet<string> hashSet = new HashSet<string>();
			foreach (WorldFrame adjacentFrame in GetAdjacentFrames())
			{
				if (!(adjacentFrame is T10AscensionBooster))
				{
					hashSet.Add(adjacentFrame.Identifier);
				}
			}
			if (hashSet.Count < 3)
			{
				return 1f;
			}
			return base.PlacementTech.UpgradeMultiplier;
		}
	}
}
