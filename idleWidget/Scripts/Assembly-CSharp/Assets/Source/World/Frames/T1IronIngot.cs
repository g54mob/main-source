using System.Collections.Generic;
using Assets.Source.Item;
using Assets.Source.Player;

namespace Assets.Source.World.Frames
{
	public class T1IronIngot : FurnaceFrame
	{
		public override FrameUpgrade AutoFurnaceUpgrade => GetCustomUpgrade(1);

		public override int AutoWorkerCount => 6;

		public override TechNode RequiredTech => "t1f_iron_ingot";

		public T1IronIngot()
		{
			base.ItemHint = "iron_ingot";
			base.PlacementTech = "t1u_iron_smelter_placement";
			base.MusicName = "EvolvingCities";
			_reagents["iron_ore"] = 1;
			_results["iron_ingot"] = 1;
			_firstCost = new List<ItemType>();
			_baseCost = new List<ItemType> { "iron_ingot", "widget" };
			_extraCostMultiplier = 1.2f;
			_baseCraftingTime = 0.3f;
			_autoCraftingTime = 3f;
			_baseMaxContents = 20;
		}

		protected override float CalculatePlacementBonus()
		{
			float num = 1f;
			foreach (WorldFrame adjacentFrame in GetAdjacentFrames())
			{
				if (adjacentFrame is T1IronIngot)
				{
					num += base.PlacementTech.UpgradeMultiplier;
				}
			}
			return num;
		}
	}
}
