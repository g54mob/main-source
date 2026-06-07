using System.Collections.Generic;
using Assets.Source.Item;
using Assets.Source.Player;

namespace Assets.Source.World.Frames
{
	public class T7FuelRod : CraftingFrame
	{
		public override int AutoWorkerMax => 6;

		public override int HandCraftButtonCount => 1;

		public override float TimePerClick => 0.25f;

		public override TechNode RequiredTech => "t7f_fuel_rod";

		public T7FuelRod()
		{
			base.ItemHint = "fuel_rod";
			base.PlacementTech = "t7u_fuel_rod_placement";
			base.MusicName = "EvolvingCities";
			_reagents["iron_ingot"] = 1;
			_reagents["gyroscope"] = 1;
			_reagents["uranium"] = 1;
			_reagents["power"] = 9;
			_results["fuel_rod"] = 1;
			_autoCraftingTime = 12f;
			_firstCost = new List<ItemType> { "gyroscope", "mainframe_widget" };
			_baseCost = new List<ItemType> { "gyroscope", "cloud_widget" };
			_extraCostMultiplier = 1.2999999523162842;
		}

		protected override double CalculatePlacementBonus(WorldFrame triggeredBy)
		{
			if (WorldMap.Current.GetTerrain(base.Position) != 7)
			{
				return 1.0;
			}
			return base.PlacementTech.UpgradeMultiplier;
		}
	}
}
