using System;
using System.Collections.Generic;
using Assets.Source.Item;
using Assets.Source.Player;

namespace Assets.Source.World.Frames
{
	public class T4CircuitBoard : CraftingFrame
	{
		public override int AutoWorkerCount => 6;

		public override int HandCraftButtonCount => 1;

		public override float TimePerClick => 0.2f;

		public override TechNode RequiredTech => "t4f_circuit_board";

		public T4CircuitBoard()
		{
			base.ItemHint = "circuit_board";
			base.PlacementTech = "t4u_circuit_board_placement";
			base.MusicName = "MarchOfTheWakingLights";
			_reagents["copper_ingot"] = 1;
			_reagents["plastic"] = 1;
			_results["circuit_board"] = 1;
			_baseCraftingTime = 1f;
			_firstCost = new List<ItemType> { "battery", "capacitor_widget" };
			_baseCost = new List<ItemType> { "battery", "computational_widget" };
			_extraCostMultiplier = 1.3f;
		}

		protected override float CalculatePlacementBonus()
		{
			int num = 0;
			foreach (WorldFrame adjacentFrame in GetAdjacentFrames())
			{
				_ = adjacentFrame;
				num++;
			}
			foreach (byte item in GetAdjacentTerrain())
			{
				if (item == 1 || item == 0)
				{
					num++;
				}
			}
			if (num != 8)
			{
				return 1f;
			}
			return base.PlacementTech.UpgradeMultiplier;
		}

		public override void OnAddFrame()
		{
			throw new NotImplementedException();
		}
	}
}
