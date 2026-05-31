using System.Collections.Generic;
using Assets.Source.Item;
using Assets.Source.Player;
using UnityEngine;

namespace Assets.Source.World.Frames
{
	public class T2SpinningWidget : CraftingFrame
	{
		public float SpinnerAngle;

		public float SpinnerSpeed = 0.5f;

		public override int AutoWorkerCount => 6;

		public override int HandCraftButtonCount => 1;

		public override TechNode RequiredTech => "t2f_spinning_widget";

		public T2SpinningWidget()
		{
			base.ItemHint = "spinning_widget";
			base.PlacementTech = "t2u_spinning_widget_placement";
			base.MusicName = "YouWereAlwaysInTheRightPlace";
			base.CheaperFirstWorker = false;
			_reagents["gyroscope"] = 1;
			_reagents["widget"] = 1;
			_results["spinning_widget"] = 1;
			_baseCraftingTime = 0.25f;
			_firstCost = new List<ItemType> { "widget" };
			_baseCost = new List<ItemType> { "widget", "spinning_widget" };
			_extraCostMultiplier = 1.4f;
		}

		public override void ActiveUpdate(float delta)
		{
			base.ActiveUpdate(delta);
			if ((bool)base.ActiveFrame)
			{
				SpinnerAngle += SpinnerSpeed * delta;
				if (SpinnerAngle > 1f)
				{
					SpinnerAngle -= 1f;
				}
			}
		}

		public override void ButtonClicked(WorldAnchor anchor)
		{
			if (anchor.AnchorType == WorldAnchorType.HandCraft)
			{
				if (SpinnerAngle > 0.1f && SpinnerAngle < 0.9f)
				{
					base.ActiveFrame?.ShowWarning(anchor, "Out of Phase");
					SpinnerSpeed = 0.5f;
					return;
				}
				SpinnerSpeed = Mathf.Min(1f, SpinnerSpeed + 0.1f);
			}
			base.ButtonClicked(anchor);
		}

		protected override float CalculatePlacementBonus()
		{
			if (WorldMap.Current.GetTerrain(base.Position) == 6)
			{
				return 1f;
			}
			foreach (byte item in GetAdjacentTerrain())
			{
				if (item == 6)
				{
					return base.PlacementTech.UpgradeMultiplier;
				}
			}
			return 1f;
		}
	}
}
