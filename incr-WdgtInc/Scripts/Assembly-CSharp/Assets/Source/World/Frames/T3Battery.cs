using System.Collections.Generic;
using Assets.Source.Item;
using Assets.Source.Player;

namespace Assets.Source.World.Frames
{
	public class T3Battery : CraftingFrame
	{
		public override int AutoWorkerMax => 6;

		public override int HandCraftButtonCount => 1;

		public override float TimePerClick => 0.25f;

		public override TechNode RequiredTech => "t3f_battery";

		public T3Battery()
		{
			base.ItemHint = "battery";
			base.PlacementTech = "t3u_battery_placement";
			base.MusicName = "DancingOperators";
			_reagents["power"] = 1;
			_reagents["iron_ingot"] = 1;
			_reagents["widget"] = 1;
			_results["battery"] = 1;
			_baseCraftingTime = 1f;
			_firstCost = new List<ItemType> { "spinning_widget", "glass" };
			_baseCost = new List<ItemType> { "capacitor_widget", "glass" };
			_extraCostMultiplier = 1.2999999523162842;
		}

		protected override double CalculatePlacementBonus(WorldFrame triggeredBy)
		{
			foreach (byte item in GetAdjacentTerrain(includeSelf: true))
			{
				if (item == 5 || item == 0)
				{
					return 1.0;
				}
			}
			return base.PlacementTech.UpgradeMultiplier;
		}
	}
}
