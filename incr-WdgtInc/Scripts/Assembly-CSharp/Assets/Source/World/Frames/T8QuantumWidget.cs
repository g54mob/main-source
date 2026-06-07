using System.Collections.Generic;
using Assets.Source.Item;
using Assets.Source.Player;

namespace Assets.Source.World.Frames
{
	public class T8QuantumWidget : CraftingFrame
	{
		public override int AutoWorkerMax => 6;

		public override int HandCraftButtonCount => 1;

		public override TechNode RequiredTech => "t8f_quantum_widget";

		public T8QuantumWidget()
		{
			base.ItemHint = "quantum_widget";
			base.PlacementTech = "t8u_quantum_widget_placement";
			base.MusicName = "YouWereAlwaysInTheRightPlace";
			base.CheaperFirstWorker = false;
			_reagents["nanoprocessor"] = 2;
			_reagents["portable_reactor"] = 2;
			_reagents["cloud_widget"] = 1;
			_results["quantum_widget"] = 1;
			_baseCraftingTime = 2f;
			_firstCost = new List<ItemType> { "fuel_rod", "cloud_widget" };
			_baseCost = new List<ItemType> { "fuel_rod", "quantum_widget" };
			_extraCostMultiplier = 1.2999999523162842;
		}

		public override ManualCrafter CreateHandCrafter(WorldAnchor slot)
		{
			return new ManualMultiCrafter(this, slot, 2);
		}

		protected override double CalculatePlacementBonus(WorldFrame triggeredBy)
		{
			if (base.Terrain != 4)
			{
				return 1.0;
			}
			return base.PlacementTech.UpgradeMultiplier;
		}
	}
}
