using System.Collections.Generic;
using Assets.Source.Item;
using Assets.Source.Player;

namespace Assets.Source.World.Frames
{
	public class T4CopperOre : CraftingFrame
	{
		public override int AutoWorkerMax => 6;

		public override int HandCraftButtonCount => 4;

		public override TechNode RequiredTech => "t4f_copper_ore";

		public T4CopperOre()
		{
			base.ItemHint = "copper_ore";
			base.PlacementTech = "t4u_copper_ore_placement";
			base.MusicName = "DancingOperators";
			_results["copper_ore"] = 1;
			_baseCraftingTime = 3f;
			_firstCost = new List<ItemType> { "capacitor_widget" };
			_baseCost = new List<ItemType> { "computational_widget" };
		}

		protected override double CalculatePlacementBonus(WorldFrame triggeredBy)
		{
			if (WorldMap.Current.GetTerrain(base.Position) == 6)
			{
				return base.PlacementTech.UpgradeMultiplier;
			}
			return 1.0;
		}
	}
}
