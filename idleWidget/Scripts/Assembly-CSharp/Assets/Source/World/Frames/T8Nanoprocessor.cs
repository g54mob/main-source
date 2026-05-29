using System.Collections.Generic;
using Assets.Source.Item;
using Assets.Source.Player;

namespace Assets.Source.World.Frames
{
	public class T8Nanoprocessor : CraftingFrame
	{
		public override int AutoWorkerCount => 6;

		public override int HandCraftButtonCount => 1;

		public override TechNode RequiredTech => "t8f_nanoprocessor";

		public T8Nanoprocessor()
		{
			base.ItemHint = "nanoprocessor";
			base.PlacementTech = "t8u_nanoprocessor_placement";
			base.MusicName = "MarchOfTheWakingLights";
			_reagents["microprocessor"] = 1;
			_reagents["widget_particle"] = 42;
			_results["nanoprocessor"] = 1;
			_baseCraftingTime = 0.5f;
			_firstCost = new List<ItemType> { "microprocessor", "cloud_widget" };
			_baseCost = new List<ItemType> { "microprocessor", "quantum_widget" };
			_extraCostMultiplier = 1.3f;
		}

		public override ManualCrafter CreateHandCrafter(WorldAnchor slot)
		{
			return new T8NanoprocessorManualCrafter(this, slot);
		}

		protected override float CalculatePlacementBonus()
		{
			if (base.Terrain != 9)
			{
				return 1f;
			}
			return base.PlacementTech.UpgradeMultiplier;
		}
	}
}
