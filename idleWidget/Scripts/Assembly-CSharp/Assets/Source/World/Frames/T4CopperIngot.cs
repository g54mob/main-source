using System;
using System.Collections.Generic;
using Assets.Source.Item;
using Assets.Source.Player;

namespace Assets.Source.World.Frames
{
	public class T4CopperIngot : FurnaceFrame
	{
		public override FrameUpgrade AutoFurnaceUpgrade => GetCustomUpgrade(1);

		public override int AutoWorkerCount => 6;

		public override TechNode RequiredTech => "t4f_copper_ingot";

		public T4CopperIngot()
		{
			base.ItemHint = "copper_ingot";
			base.PlacementTech = "t4u_copper_ingot_placement";
			base.MusicName = "EvolvingCities";
			_reagents["copper_ore"] = 1;
			_results["copper_ingot"] = 1;
			_firstCost = new List<ItemType> { "power", "capacitor_widget" };
			_baseCost = new List<ItemType> { "battery", "computational_widget" };
			_extraCostMultiplier = 1.2f;
			_baseCraftingTime = 0.3f;
			_baseMaxContents = 20;
		}

		protected override float CalculatePlacementBonus()
		{
			if (WorldMap.Current.GetTerrain(base.Position) != 7)
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
