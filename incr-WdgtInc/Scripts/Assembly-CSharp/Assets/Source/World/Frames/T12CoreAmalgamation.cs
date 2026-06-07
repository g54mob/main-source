using System.Collections.Generic;
using Assets.Source.Item;
using Assets.Source.Player;

namespace Assets.Source.World.Frames
{
	public class T12CoreAmalgamation : CraftingFrame
	{
		public override int AutoWorkerMax => 6;

		public override double AutoworkerCostMultiplier => 3.0;

		public override int HandCraftButtonCount => 1;

		public override float TimePerClick => 0.2f;

		public override TechNode RequiredTech => "t12f_core_amalgamation";

		public T12CoreAmalgamation()
		{
			base.ItemHint = "core_amalgamation";
			base.MusicName = "FugueForOneSyntheticHeart";
			base.CheaperFirstWorker = false;
			_reagents["thinking_core"] = 1;
			_reagents["ai_core"] = 1;
			_reagents["sentient_core"] = 1;
			_results["core_amalgamation"] = 1;
			_baseCraftingTime = 1f;
			_firstCost = new List<ItemType> { "picoprocessor", "sentient_widget" };
			_baseCost = new List<ItemType> { "sentient_widget", "omega_widget" };
			_extraCostMultiplier = 1.2999999523162842;
		}
	}
}
