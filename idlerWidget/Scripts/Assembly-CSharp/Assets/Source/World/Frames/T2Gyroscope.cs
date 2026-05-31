using System.Collections.Generic;
using Assets.Source.Item;
using Assets.Source.Player;

namespace Assets.Source.World.Frames
{
	public class T2Gyroscope : CraftingFrame
	{
		public override int AutoWorkerCount => 6;

		public override int HandCraftButtonCount => 1;

		public override float TimePerClick => 0.5f;

		public override TechNode RequiredTech => "t2f_gyroscope";

		public T2Gyroscope()
		{
			base.ItemHint = "gyroscope";
			base.PlacementTech = "t2u_gyroscope_placement";
			base.MusicName = "MarchOfTheWakingLights";
			_reagents["glass"] = 1;
			_reagents["widget"] = 1;
			_results["gyroscope"] = 1;
			_baseCraftingTime = 1f;
			_firstCost = new List<ItemType> { "iron_ingot", "widget" };
			_baseCost = new List<ItemType> { "widget", "spinning_widget" };
			_extraCostMultiplier = 1.3f;
		}

		protected override float CalculatePlacementBonus()
		{
			foreach (WorldFrame adjacentFrame in GetAdjacentFrames())
			{
				if (adjacentFrame is T2Glass)
				{
					return base.PlacementTech.UpgradeMultiplier;
				}
			}
			return 1f;
		}
	}
}
