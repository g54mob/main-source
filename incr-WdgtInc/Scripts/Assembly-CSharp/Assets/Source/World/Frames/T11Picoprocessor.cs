using System.Collections.Generic;
using Assets.Source.Item;
using Assets.Source.Player;

namespace Assets.Source.World.Frames
{
	public class T11Picoprocessor : CraftingFrame
	{
		public override int AutoWorkerMax => 6;

		public override int HandCraftButtonCount => 1;

		public override TechNode RequiredTech => "t11f_picoprocessor";

		public T11Picoprocessor()
		{
			base.ItemHint = "picoprocessor";
			base.PlacementTech = "t11u_picoprocessor_placement";
			base.MusicName = "MarchOfTheWakingLights";
			_reagents["superconductor"] = 1;
			_reagents["nanoprocessor"] = 1;
			_reagents["ai_training_data"] = 1;
			_results["picoprocessor"] = 1;
			_baseCraftingTime = 1f;
			_firstCost = new List<ItemType> { "ai_training_data", "ascended_widget" };
			_baseCost = new List<ItemType> { "ai_training_data", "sentient_widget" };
			_extraCostMultiplier = 1.2999999523162842;
		}

		protected override double CalculatePlacementBonus(WorldFrame triggeredBy = null)
		{
			int num = 0;
			foreach (WorldFrame adjacentFrame in GetAdjacentFrames())
			{
				if (adjacentFrame is T4CircuitBoard || adjacentFrame is T6Microprocessor || adjacentFrame is T8Nanoprocessor)
				{
					num++;
				}
			}
			return 1.0 + (double)num * base.PlacementTech.UpgradeMultiplier;
		}
	}
}
