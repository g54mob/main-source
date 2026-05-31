using System.Collections.Generic;
using Assets.Source.Item;
using Assets.Source.Player;

namespace Assets.Source.World.Frames
{
	public class T6MainframeWidget : CraftingFrame
	{
		public override int AutoWorkerCount => 6;

		public override int HandCraftButtonCount => 1;

		public override float TimePerClick => 0.25f;

		public override TechNode RequiredTech => "t6f_mainframe_widget";

		public T6MainframeWidget()
		{
			base.ItemHint = "mainframe_widget";
			base.PlacementTech = "t6u_mainframe_widget_placement";
			base.MusicName = "YouWereAlwaysInTheRightPlace";
			base.CheaperFirstWorker = false;
			_reagents["integrated_widget"] = 1;
			_reagents["microprocessor"] = 2;
			_results["mainframe_widget"] = 1;
			_baseCraftingTime = 0.75f;
			_firstCost = new List<ItemType> { "circuit_board", "integrated_widget" };
			_baseCost = new List<ItemType> { "circuit_board", "mainframe_widget" };
			_extraCostMultiplier = 1.3f;
		}

		protected override float CalculatePlacementBonus()
		{
			bool flag = false;
			foreach (WorldFrame adjacentFrame in GetAdjacentFrames())
			{
				_ = adjacentFrame;
				if (flag)
				{
					return 1f;
				}
				flag = true;
			}
			if (!flag)
			{
				return 1f;
			}
			return base.PlacementTech.UpgradeMultiplier;
		}
	}
}
