using System.Collections.Generic;
using Assets.Source.Item;
using Assets.Source.Player;

namespace Assets.Source.World.Frames
{
	public class T7Uranium : CraftingFrame
	{
		public override int AutoWorkerCount => 6;

		public override int HandCraftButtonCount => 2;

		public override TechNode RequiredTech => "t7f_uranium";

		public T7Uranium()
		{
			base.ItemHint = "uranium";
			base.PlacementTech = "t7u_uranium_placement";
			base.MusicName = "DancingOperators";
			_reagents["power"] = 4;
			_results["uranium"] = 1;
			_baseCraftingTime = 6f;
			_autoCraftingTime = 12f;
			_firstCost = new List<ItemType> { "mainframe_widget" };
			_baseCost = new List<ItemType> { "cloud_widget" };
		}

		public override ManualCrafter CreateHandCrafter(WorldAnchor slot)
		{
			return new ManualMultiCrafter(this, slot, 2);
		}

		protected override float CalculatePlacementBonus()
		{
			if (WorldMap.Current.GetTerrain(base.Position) != 3)
			{
				return 1f;
			}
			return base.PlacementTech.UpgradeMultiplier;
		}
	}
}
