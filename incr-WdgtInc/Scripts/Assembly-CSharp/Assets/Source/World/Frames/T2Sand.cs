using System.Collections.Generic;
using Assets.Source.Item;
using Assets.Source.Player;

namespace Assets.Source.World.Frames
{
	public class T2Sand : CraftingFrame
	{
		public override int AutoWorkerMax => 6;

		public override int HandCraftButtonCount => 1;

		public override TechNode RequiredTech => "t2f_sand";

		public T2Sand()
		{
			base.ItemHint = "sand";
			base.PlacementTech = "t2u_sand_placement";
			base.MusicName = "FugueForOneSyntheticHeart";
			_results["sand"] = 1;
			_baseCraftingTime = 10f;
			_firstCost = new List<ItemType> { "iron_ingot", "widget" };
			_baseCost = new List<ItemType> { "iron_ingot", "spinning_widget" };
		}

		public override ManualCrafter CreateHandCrafter(WorldAnchor slot)
		{
			return new T2SandManualCrafter(this, slot);
		}

		protected override double CalculatePlacementBonus(WorldFrame triggeredBy)
		{
			if (WorldMap.Current.GetTerrain(base.Position) == 3)
			{
				return base.PlacementTech.UpgradeMultiplier;
			}
			return 1.0;
		}
	}
}
