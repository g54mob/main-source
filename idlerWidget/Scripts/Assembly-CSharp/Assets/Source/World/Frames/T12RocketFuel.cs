using System.Collections.Generic;
using Assets.Source.Item;
using Assets.Source.Player;

namespace Assets.Source.World.Frames
{
	public class T12RocketFuel : CraftingFrame
	{
		public override int AutoWorkerCount => 6;

		public override int HandCraftButtonCount => 1;

		public override TechNode RequiredTech => "t12f_rocket_fuel";

		public T12RocketFuel()
		{
			base.ItemHint = "rocket_fuel";
			base.MusicName = "EvolvingCities";
			base.CheaperFirstWorker = false;
			_reagents["oil"] = 2;
			_reagents["fuel_rod"] = 1;
			_reagents["power"] = 20;
			_results["rocket_fuel"] = 1;
			_baseCraftingTime = 3f;
			_autoCraftingTime = 8f;
			_firstCost = new List<ItemType> { "portable_reactor", "omega_widget" };
			_baseCost = new List<ItemType> { "portable_reactor", "omega_widget" };
			_extraCostMultiplier = 0.8f;
		}

		public override ManualCrafter CreateHandCrafter(WorldAnchor slot)
		{
			return new ManualMultiCrafter(this, slot, 10);
		}
	}
}
