using System.Collections.Generic;
using Assets.Source.Item;
using Assets.Source.Player;

namespace Assets.Source.World.Frames
{
	public class T7Power : PowerPlantFrame
	{
		public override int AutoWorkerMax => 6;

		public override int HandCraftButtonCount => 1;

		public override TechNode RequiredTech => "t7f_power";

		public T7Power()
		{
			base.ItemHint = "power_dummy_nuclear";
			base.PlacementTech = "t7u_power_placement";
			base.MusicName = "FugueForOneSyntheticHeart";
			_powerStorageAmount = 500;
			_reagents["fuel_rod"] = 1;
			_results["power"] = 39;
			_baseCraftingTime = 5f;
			_firstCost = new List<ItemType> { "mainframe_widget" };
			_baseCost = new List<ItemType> { "fuel_rod", "cloud_widget" };
			_extraCostMultiplier = 1.2999999523162842;
		}

		protected override double CalculatePlacementBonus(WorldFrame triggeredBy)
		{
			double num = 1.0;
			foreach (byte item in GetAdjacentTerrain())
			{
				if (item == 0)
				{
					num += base.PlacementTech.UpgradeMultiplier;
				}
			}
			return num;
		}
	}
}
