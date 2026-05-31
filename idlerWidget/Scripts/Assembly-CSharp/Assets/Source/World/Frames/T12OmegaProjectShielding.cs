using System.Collections.Generic;
using Assets.Source.Item;
using Assets.Source.Player;

namespace Assets.Source.World.Frames
{
	public class T12OmegaProjectShielding : CraftingFrame
	{
		public override int AutoWorkerCount => 6;

		public override float AutoworkerCostMultiplier => 3f;

		public override int HandCraftButtonCount => 1;

		public override TechNode RequiredTech => "t12f_omega_project_shielding";

		public T12OmegaProjectShielding()
		{
			base.ItemHint = "omega_project_shielding";
			base.MusicName = "FastLanesLightRain";
			base.CheaperFirstWorker = false;
			_reagents["plastic"] = 5;
			_reagents["bottled_lightning"] = 5;
			_reagents["portable_reactor"] = 2;
			_reagents["portable_reactor"] = 2;
			_reagents["sentient_widget"] = 1;
			_results["omega_project_shielding"] = 1;
			_baseCraftingTime = 1f;
			_firstCost = new List<ItemType> { "picoprocessor", "sentient_widget" };
			_baseCost = new List<ItemType> { "sentient_widget", "omega_widget" };
			_extraCostMultiplier = 1.3f;
		}
	}
}
