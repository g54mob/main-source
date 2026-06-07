using System.Collections.Generic;
using Assets.Source.Item;
using Assets.Source.Player;

namespace Assets.Source.World.Frames
{
	public class T6Silicon : CraftingFrame
	{
		public override int AutoWorkerMax => 6;

		public override int HandCraftButtonCount => 1;

		public override TechNode RequiredTech => "t6f_silicon";

		public T6Silicon()
		{
			base.ItemHint = "silicon";
			base.PlacementTech = "t6u_silicon_placement";
			base.MusicName = "FastLanesLightRain";
			_reagents["sand"] = 1;
			_reagents["power"] = 3;
			_results["silicon"] = 1;
			_baseCraftingTime = 0.7f;
			_firstCost = new List<ItemType> { "circuit_board", "integrated_widget" };
			_baseCost = new List<ItemType> { "thinking_core", "mainframe_widget" };
			_extraCostMultiplier = 1.2999999523162842;
		}

		protected override double CalculatePlacementBonus(WorldFrame triggeredBy)
		{
			foreach (WorldFrame adjacentFrame in GetAdjacentFrames())
			{
				if (adjacentFrame is T2Sand)
				{
					return base.PlacementTech.UpgradeMultiplier;
				}
			}
			return 1.0;
		}
	}
}
