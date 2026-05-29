using System.Collections.Generic;
using Assets.Source.Item;
using Assets.Source.Player;

namespace Assets.Source.World.Frames
{
	public class T6Microprocessor : CraftingFrame
	{
		public override int AutoWorkerCount => 6;

		public override int HandCraftButtonCount => 1;

		public override float TimePerClick => 0.2f;

		public override TechNode RequiredTech => "t6f_microprocessor";

		public T6Microprocessor()
		{
			base.ItemHint = "microprocessor";
			base.PlacementTech = "t6u_microprocessor_placement";
			base.MusicName = "MarchOfTheWakingLights";
			_reagents["silicon"] = 1;
			_reagents["circuit_board"] = 1;
			_reagents["thinking_core"] = 1;
			_results["microprocessor"] = 1;
			_baseCraftingTime = 1f;
			_firstCost = new List<ItemType> { "circuit_board", "integrated_widget" };
			_baseCost = new List<ItemType> { "thinking_core", "mainframe_widget" };
			_extraCostMultiplier = 1.3f;
		}

		protected override float CalculatePlacementBonus()
		{
			if (WorldMap.Current.GetTerrain(base.Position) == 8)
			{
				return 1f;
			}
			foreach (byte item in GetAdjacentTerrain())
			{
				if (item == 8)
				{
					return base.PlacementTech.UpgradeMultiplier;
				}
			}
			return 1f;
		}
	}
}
