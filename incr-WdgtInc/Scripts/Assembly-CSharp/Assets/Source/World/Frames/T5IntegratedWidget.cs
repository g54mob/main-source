using System.Collections.Generic;
using Assets.Source.Item;
using Assets.Source.Player;

namespace Assets.Source.World.Frames
{
	public class T5IntegratedWidget : CraftingFrame
	{
		public override int AutoWorkerMax => 6;

		public override int HandCraftButtonCount => 1;

		public override TechNode RequiredTech => "t5f_integrated_widget";

		public T5IntegratedWidget()
		{
			base.ItemHint = "integrated_widget";
			base.PlacementTech = "t5u_integrated_widget_placement";
			base.MusicName = "TheLongestYear";
			base.CheaperFirstWorker = false;
			_reagents["bottled_lightning"] = 1;
			_reagents["thinking_core"] = 1;
			_reagents["capacitor_widget"] = 1;
			_results["integrated_widget"] = 1;
			_baseCraftingTime = 0.5f;
			_firstCost = new List<ItemType> { "circuit_board", "computational_widget" };
			_baseCost = new List<ItemType> { "circuit_board", "integrated_widget" };
			_extraCostMultiplier = 1.2999999523162842;
		}

		protected override double CalculatePlacementBonus(WorldFrame triggeredBy)
		{
			foreach (WorldFrame adjacentFrame in GetAdjacentFrames())
			{
				if (adjacentFrame is T5ThinkingCore)
				{
					return base.PlacementTech.UpgradeMultiplier;
				}
			}
			return 1.0;
		}
	}
}
