using System.Collections.Generic;
using Assets.Source.Item;
using Assets.Source.Player;

namespace Assets.Source.World.Frames
{
	public class T12RocketElectronics : CraftingFrame
	{
		public override int AutoWorkerCount => 6;

		public override int HandCraftButtonCount => 1;

		public override TechNode RequiredTech => "t12f_rocket_electronics";

		public T12RocketElectronics()
		{
			_autoCraftingTime = 30f;
			base.ItemHint = "rocket_electronics";
			base.MusicName = "DancingOperators";
			base.CheaperFirstWorker = false;
			_reagents["processor_amalgamation"] = 1;
			_reagents["core_amalgamation"] = 1;
			_results["rocket_electronics"] = 1;
			_baseCraftingTime = 1f;
			_firstCost = new List<ItemType> { "picoprocessor", "omega_widget" };
			_baseCost = new List<ItemType> { "picoprocessor", "omega_widget" };
			_extraCostMultiplier = 0.8f;
		}
	}
}
