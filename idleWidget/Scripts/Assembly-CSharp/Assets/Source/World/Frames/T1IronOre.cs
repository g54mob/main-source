using System.Collections.Generic;
using Assets.Source.Item;
using Assets.Source.Player;

namespace Assets.Source.World.Frames
{
	public class T1IronOre : CraftingFrame
	{
		public override int AutoWorkerCount => 6;

		public override int HandCraftButtonCount => 4;

		public override TechNode RequiredTech => "t1f_iron_ore";

		public T1IronOre()
		{
			base.ItemHint = "iron_ore";
			base.PlacementTech = "t1u_iron_ore_placement";
			base.MusicName = "DancingOperators";
			_results["iron_ore"] = 1;
			_baseCraftingTime = 3f;
			_firstCost = new List<ItemType>();
			_baseCost = new List<ItemType> { "iron_ingot", "widget" };
		}

		protected override float CalculatePlacementBonus()
		{
			if (WorldMap.Current.GetTerrain(base.Position) == 6)
			{
				return base.PlacementTech.UpgradeMultiplier;
			}
			return 1f;
		}
	}
}
