using System.Collections.Generic;
using Assets.Source.Item;
using Assets.Source.Player;

namespace Assets.Source.World.Frames
{
	public class T12WidgetAmalgamation : CraftingFrame
	{
		public override int AutoWorkerMax => 6;

		public override double AutoworkerCostMultiplier => 3.0;

		public override int HandCraftButtonCount => 1;

		public override TechNode RequiredTech => "t12f_widget_amalgamation";

		public T12WidgetAmalgamation()
		{
			base.ItemHint = "widget_amalgamation";
			base.MusicName = "TheLongestYear";
			base.CheaperFirstWorker = false;
			_reagents["widget"] = 1;
			_reagents["spinning_widget"] = 1;
			_reagents["capacitor_widget"] = 1;
			_reagents["computational_widget"] = 1;
			_reagents["integrated_widget"] = 1;
			_reagents["mainframe_widget"] = 1;
			_reagents["cloud_widget"] = 1;
			_reagents["quantum_widget"] = 1;
			_reagents["unshackled_widget"] = 1;
			_reagents["ascended_widget"] = 1;
			_reagents["sentient_widget"] = 1;
			_results["widget_amalgamation"] = 1;
			_baseCraftingTime = 1f;
			_firstCost = new List<ItemType> { "picoprocessor", "sentient_widget" };
			_baseCost = new List<ItemType> { "sentient_widget", "omega_widget" };
			_extraCostMultiplier = 1.2999999523162842;
		}
	}
}
