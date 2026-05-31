using System;
using System.Collections.Generic;
using Assets.Source.Item;
using Assets.Source.Player;

namespace Assets.Source.World.Frames
{
	public class T4ComputationalWidget : CraftingFrame
	{
		public override int AutoWorkerCount => 6;

		public override int HandCraftButtonCount => 1;

		public override TechNode RequiredTech => "t4f_computational_widget";

		public T4ComputationalWidget()
		{
			base.ItemHint = "computational_widget";
			base.PlacementTech = "t4u_computational_widget_placement";
			base.MusicName = "YouWereAlwaysInTheRightPlace";
			base.CheaperFirstWorker = false;
			_reagents["capacitor_widget"] = 1;
			_reagents["spinning_widget"] = 2;
			_reagents["circuit_board"] = 1;
			_results["computational_widget"] = 1;
			_baseCraftingTime = 0.5f;
			_firstCost = new List<ItemType> { "capacitor_widget", "spinning_widget" };
			_baseCost = new List<ItemType> { "computational_widget", "battery" };
			_extraCostMultiplier = 1.4f;
		}

		protected override float CalculatePlacementBonus()
		{
			foreach (WorldFrame adjacentFrame in GetAdjacentFrames())
			{
				if (adjacentFrame is T4ComputationalWidget)
				{
					return 1f;
				}
			}
			return base.PlacementTech.UpgradeMultiplier;
		}

		public override void OnAddFrame()
		{
			throw new NotImplementedException();
		}
	}
}
