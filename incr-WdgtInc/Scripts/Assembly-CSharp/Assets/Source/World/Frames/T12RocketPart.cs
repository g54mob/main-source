using System.Collections.Generic;
using Assets.Source.Item;
using Assets.Source.Player;

namespace Assets.Source.World.Frames
{
	public class T12RocketPart : CraftingFrame
	{
		public override int AutoWorkerMax => 6;

		public override int HandCraftButtonCount => 1;

		public override TechNode RequiredTech => "t12f_rocket_part";

		public T12RocketPart()
		{
			_autoCraftingTime = 30f;
			base.ItemHint = "rocket_part";
			base.MusicName = "FugueForOneSyntheticHeart";
			base.CheaperFirstWorker = false;
			_reagents["omega_project_casing"] = 1;
			_reagents["omega_project_shielding"] = 1;
			_results["rocket_part"] = 1;
			_baseCraftingTime = 2f;
			_firstCost = new List<ItemType> { "superconductor", "omega_widget" };
			_baseCost = new List<ItemType> { "superconductor", "omega_widget" };
			_extraCostMultiplier = 0.800000011920929;
		}

		public override ManualCrafter CreateHandCrafter(WorldAnchor slot)
		{
			return new ManualMultiCrafter(this, slot, 2);
		}
	}
}
