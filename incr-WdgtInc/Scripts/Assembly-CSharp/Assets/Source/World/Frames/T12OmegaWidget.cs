using System.Collections.Generic;
using Assets.Source.Item;
using Assets.Source.Player;

namespace Assets.Source.World.Frames
{
	public class T12OmegaWidget : CraftingFrame
	{
		public override int AutoWorkerMax => 6;

		public override int HandCraftButtonCount => 1;

		public override TechNode RequiredTech => "t12f_omega_widget";

		public T12OmegaWidget()
		{
			base.ItemHint = "omega_widget";
			base.MusicName = "YouWereAlwaysInTheRightPlace";
			base.CheaperFirstWorker = false;
			_reagents["widget_amalgamation"] = 1;
			_reagents["processor_amalgamation"] = 1;
			_reagents["core_amalgamation"] = 1;
			_reagents["omega_project_casing"] = 1;
			_reagents["omega_project_shielding"] = 1;
			_results["omega_widget"] = 1;
			_baseCraftingTime = 1f;
			_autoCraftingTime = 12f;
			_firstCost = new List<ItemType> { "picoprocessor", "sentient_widget" };
			_baseCost = new List<ItemType> { "omega_widget" };
			_extraCostMultiplier = 1.2999999523162842;
		}
	}
}
