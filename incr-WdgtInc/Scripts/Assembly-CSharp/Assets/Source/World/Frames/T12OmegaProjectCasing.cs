using System.Collections.Generic;
using Assets.Source.Item;
using Assets.Source.Player;

namespace Assets.Source.World.Frames
{
	public class T12OmegaProjectCasing : CraftingFrame
	{
		public override int AutoWorkerMax => 6;

		public override double AutoworkerCostMultiplier => 3.0;

		public override int HandCraftButtonCount => 1;

		public override TechNode RequiredTech => "t12f_omega_project_casing";

		public T12OmegaProjectCasing()
		{
			base.ItemHint = "omega_project_casing";
			base.MusicName = "EvolvingCities";
			base.CheaperFirstWorker = false;
			_reagents["iron_ingot"] = 5;
			_reagents["copper_ingot"] = 5;
			_reagents["superconductor"] = 2;
			_reagents["sentient_widget"] = 1;
			_results["omega_project_casing"] = 1;
			_baseCraftingTime = 1f;
			_firstCost = new List<ItemType> { "picoprocessor", "sentient_widget" };
			_baseCost = new List<ItemType> { "sentient_widget", "omega_widget" };
			_extraCostMultiplier = 1.2999999523162842;
		}
	}
}
