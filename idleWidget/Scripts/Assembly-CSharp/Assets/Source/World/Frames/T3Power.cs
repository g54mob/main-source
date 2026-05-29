using System.Collections.Generic;
using Assets.Source.Item;
using Assets.Source.Player;

namespace Assets.Source.World.Frames
{
	public class T3Power : PowerPlantFrame
	{
		public override int AutoWorkerCount => 6;

		public override int HandCraftButtonCount => 1;

		public override TechNode RequiredTech => "t3f_power";

		public T3Power()
		{
			base.ItemHint = "power";
			base.PlacementTech = "t3u_power_placement";
			base.MusicName = "FastLanesLightRain";
			_powerStorageAmount = 100;
			_reagents["oil"] = 1;
			_results["power"] = 1;
			_baseCraftingTime = 1f;
			_firstCost = new List<ItemType> { "spinning_widget", "gyroscope" };
			_baseCost = new List<ItemType> { "capacitor_widget", "spinning_widget" };
			_extraCostMultiplier = 1.2f;
		}

		protected override float CalculatePlacementBonus()
		{
			bool flag = false;
			bool flag2 = false;
			foreach (WorldFrame adjacentFrame in GetAdjacentFrames())
			{
				if (adjacentFrame is T3Oil)
				{
					flag = true;
				}
				else if (adjacentFrame is T3Power)
				{
					flag2 = true;
				}
			}
			if (!(flag && flag2))
			{
				return 1f;
			}
			return base.PlacementTech.UpgradeMultiplier;
		}
	}
}
