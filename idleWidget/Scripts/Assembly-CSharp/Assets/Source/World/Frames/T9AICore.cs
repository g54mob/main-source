using System.Collections.Generic;
using Assets.Source.Item;
using Assets.Source.Player;

namespace Assets.Source.World.Frames
{
	public class T9AICore : CraftingFrame
	{
		public override int AutoWorkerCount => 6;

		public override int HandCraftButtonCount => 1;

		public override float TimePerClick => 0.25f;

		public override TechNode RequiredTech => "t9f_ai_core";

		public T9AICore()
		{
			base.ItemHint = "ai_core";
			base.PlacementTech = "t9u_ai_core_placement";
			base.MusicName = "FugueForOneSyntheticHeart";
			_reagents["superconductor"] = 1;
			_reagents["silicon"] = 1;
			_reagents["thinking_core"] = 1;
			_results["ai_core"] = 1;
			_baseCraftingTime = 1f;
			_firstCost = new List<ItemType> { "nanoprocessor", "quantum_widget" };
			_baseCost = new List<ItemType> { "nanoprocessor", "unshackled_widget" };
			_extraCostMultiplier = 1.3f;
		}

		protected override float CalculatePlacementBonus()
		{
			if (base.Terrain != 2)
			{
				return 1f;
			}
			return base.PlacementTech.UpgradeMultiplier;
		}
	}
}
