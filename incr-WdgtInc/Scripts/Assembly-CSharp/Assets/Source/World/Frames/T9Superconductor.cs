using System.Collections.Generic;
using Assets.Source.Item;
using Assets.Source.Player;

namespace Assets.Source.World.Frames
{
	public class T9Superconductor : CraftingFrame
	{
		public override int AutoWorkerMax => 6;

		public override int HandCraftButtonCount => 1;

		public override TechNode RequiredTech => "t9f_superconductor";

		public T9Superconductor()
		{
			base.ItemHint = "superconductor";
			base.PlacementTech = "t9u_superconductor_placement";
			base.MusicName = "MarchOfTheWakingLights";
			_reagents["helium"] = 1;
			_reagents["nanoprocessor"] = 1;
			_reagents["iron_ingot"] = 1;
			_results["superconductor"] = 1;
			_baseCraftingTime = 3f;
			_firstCost = new List<ItemType> { "portable_reactor", "quantum_widget" };
			_baseCost = new List<ItemType> { "portable_reactor", "unshackled_widget" };
			_extraCostMultiplier = 1.2999999523162842;
		}

		public override ManualCrafter CreateHandCrafter(WorldAnchor slot)
		{
			return new ManualMultiCrafter(this, slot, 3);
		}

		protected override double CalculatePlacementBonus(WorldFrame triggeredBy)
		{
			bool flag = false;
			bool flag2 = false;
			foreach (WorldFrame adjacentFrame in GetAdjacentFrames())
			{
				if (adjacentFrame is T1IronOre)
				{
					flag = true;
				}
				else if (adjacentFrame is T9Helium)
				{
					flag2 = true;
				}
			}
			if (!(flag && flag2))
			{
				return 1.0;
			}
			return base.PlacementTech.UpgradeMultiplier;
		}
	}
}
