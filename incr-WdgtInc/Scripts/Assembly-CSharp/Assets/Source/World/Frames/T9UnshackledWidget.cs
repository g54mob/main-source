using System.Collections.Generic;
using Assets.Source.Item;
using Assets.Source.Player;

namespace Assets.Source.World.Frames
{
	public class T9UnshackledWidget : CraftingFrame
	{
		public override int AutoWorkerMax => 6;

		public override int HandCraftButtonCount => 1;

		public override float TimePerClick => 0.5f;

		public override TechNode RequiredTech => "t9f_unshackled_widget";

		public T9UnshackledWidget()
		{
			base.ItemHint = "unshackled_widget";
			base.PlacementTech = "t9u_unshackled_widget_placement";
			base.MusicName = "TheLongestYear";
			base.CheaperFirstWorker = false;
			_reagents["quantum_widget"] = 1;
			_reagents["ai_core"] = 2;
			_results["unshackled_widget"] = 1;
			_baseCraftingTime = 1f;
			_firstCost = new List<ItemType> { "nanoprocessor", "quantum_widget" };
			_baseCost = new List<ItemType> { "nanoprocessor", "unshackled_widget" };
			_extraCostMultiplier = 1.2999999523162842;
		}

		protected override double CalculatePlacementBonus(WorldFrame triggeredBy)
		{
			int num = 0;
			foreach (WorldFrame adjacentFrame in GetAdjacentFrames())
			{
				if (adjacentFrame is T9AICore)
				{
					num++;
					continue;
				}
				return 1.0;
			}
			if (num != 2)
			{
				return 1.0;
			}
			return base.PlacementTech.UpgradeMultiplier;
		}
	}
}
