using System.Collections.Generic;
using Assets.Source.Item;
using Assets.Source.Player;

namespace Assets.Source.World.Frames
{
	public class T1BasicWidget : CraftingFrame
	{
		public override int AutoWorkerMax => 6;

		public override float TimePerClick => 0.2f;

		public override TechNode RequiredTech => "t1f_widget";

		public T1BasicWidget()
		{
			base.ItemHint = "widget";
			base.PlacementTech = "t1u_widget_placement";
			base.MusicName = "TheLongestYear";
			_reagents["iron_ingot"] = 1;
			_results["widget"] = 1;
			_firstCost = new List<ItemType>();
			_baseCost = new List<ItemType> { "iron_ingot", "widget" };
			_extraCostMultiplier = 1.399999976158142;
			_baseCraftingTime = 1f;
		}

		protected override double CalculatePlacementBonus(WorldFrame triggeredBy = null)
		{
			bool flag = false;
			foreach (WorldFrame adjacentFrame in GetAdjacentFrames())
			{
				if (adjacentFrame is T1BasicWidget)
				{
					if (flag)
					{
						return 1.0;
					}
					flag = true;
				}
			}
			if (!flag)
			{
				return 1.0;
			}
			return base.PlacementTech.UpgradeMultiplier;
		}
	}
}
