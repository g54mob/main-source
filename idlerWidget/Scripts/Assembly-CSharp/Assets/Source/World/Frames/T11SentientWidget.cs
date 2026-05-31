using System.Collections.Generic;
using Assets.Source.Item;
using Assets.Source.Player;

namespace Assets.Source.World.Frames
{
	public class T11SentientWidget : CraftingFrame
	{
		public override int AutoWorkerCount => 6;

		public override int HandCraftButtonCount => 1;

		public override TechNode RequiredTech => "t11f_sentient_widget";

		public T11SentientWidget()
		{
			base.ItemHint = "sentient_widget";
			base.PlacementTech = "t11u_sentient_widget_placement";
			base.MusicName = "TheLongestYear";
			base.CheaperFirstWorker = false;
			_reagents["ascended_widget"] = 1;
			_reagents["picoprocessor"] = 1;
			_reagents["sentient_core"] = 1;
			_results["sentient_widget"] = 1;
			_baseCraftingTime = 0.5f;
			_firstCost = new List<ItemType> { "ai_training_data", "ascended_widget" };
			_baseCost = new List<ItemType> { "ai_training_data", "sentient_widget" };
			_extraCostMultiplier = 1.3f;
		}

		protected override float CalculatePlacementBonus()
		{
			foreach (WorldFrame adjacentFrame in GetAdjacentFrames())
			{
				if (adjacentFrame is T12OmegaWidget)
				{
					return base.PlacementTech.UpgradeMultiplier;
				}
			}
			return 1f;
		}
	}
}
