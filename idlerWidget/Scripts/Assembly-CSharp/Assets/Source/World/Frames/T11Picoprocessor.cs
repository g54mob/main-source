using System.Collections.Generic;
using Assets.Source.Item;
using Assets.Source.Player;

namespace Assets.Source.World.Frames
{
	public class T11Picoprocessor : CraftingFrame
	{
		public override int AutoWorkerCount => 6;

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
			_extraCostMultiplier = 1.3f;
		}

		protected override float CalculatePlacementBonus()
		{
			int num = 0;
			foreach (WorldFrame adjacentFrame in GetAdjacentFrames())
			{
				if (adjacentFrame is T4CircuitBoard || adjacentFrame is T6Microprocessor || adjacentFrame is T8Nanoprocessor)
				{
					num++;
				}
			}
			return 1f + (float)num * base.PlacementTech.UpgradeMultiplier;
		}
	}
}
