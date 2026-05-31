using System.Collections.Generic;
using Assets.Source.Item;
using Assets.Source.Player;

namespace Assets.Source.World.Frames
{
	public class T12ProcessorAmalgamation : CraftingFrame
	{
		public override int AutoWorkerCount => 6;

		public override float AutoworkerCostMultiplier => 3f;

		public override int HandCraftButtonCount => 1;

		public override TechNode RequiredTech => "t12f_processor_amalgamation";

		public T12ProcessorAmalgamation()
		{
			base.ItemHint = "processor_amalgamation";
			base.MusicName = "MarchOfTheWakingLights";
			base.CheaperFirstWorker = false;
			_reagents["circuit_board"] = 1;
			_reagents["microprocessor"] = 1;
			_reagents["nanoprocessor"] = 1;
			_reagents["picoprocessor"] = 1;
			_results["processor_amalgamation"] = 1;
			_baseCraftingTime = 1f;
			_firstCost = new List<ItemType> { "picoprocessor", "sentient_widget" };
			_baseCost = new List<ItemType> { "sentient_widget", "omega_widget" };
			_extraCostMultiplier = 1.3f;
		}
	}
}
