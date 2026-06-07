using System.Collections.Generic;
using Assets.Source.Item;
using Assets.Source.Player;

namespace Assets.Source.World.Frames
{
	public class T5BottledLightning : CraftingFrame
	{
		public override int AutoWorkerMax => 6;

		public override int HandCraftButtonCount => 1;

		public override TechNode RequiredTech => "t5f_bottled_lightning";

		public T5BottledLightning()
		{
			base.ItemHint = "bottled_lightning";
			base.PlacementTech = "t5u_bottled_lightning_placement";
			base.MusicName = "FastLanesLightRain";
			_reagents["power"] = 3;
			_reagents["glass"] = 1;
			_results["bottled_lightning"] = 1;
			_baseCraftingTime = 5f;
			_firstCost = new List<ItemType> { "power", "computational_widget" };
			_baseCost = new List<ItemType> { "circuit_board", "integrated_widget" };
			_extraCostMultiplier = 1.2999999523162842;
		}

		public override ManualCrafter CreateHandCrafter(WorldAnchor slot)
		{
			return new ManualMultiCrafter(this, slot, 8);
		}

		protected override double CalculatePlacementBonus(WorldFrame triggeredBy)
		{
			int num = 0;
			foreach (WorldFrame adjacentFrame in GetAdjacentFrames())
			{
				if (adjacentFrame is T5BottledLightning)
				{
					num++;
					continue;
				}
				return 1.0;
			}
			if (num != 2)
			{
				return 1.0;
			}
			return base.PlacementTech.UpgradeMultiplier;
		}
	}
}
