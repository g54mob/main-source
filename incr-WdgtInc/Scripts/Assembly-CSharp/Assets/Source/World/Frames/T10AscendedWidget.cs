using System.Collections.Generic;
using Assets.Source.Item;
using Assets.Source.Player;

namespace Assets.Source.World.Frames
{
	public class T10AscendedWidget : CraftingFrame
	{
		public override int AutoWorkerMax => 6;

		public override int HandCraftButtonCount => 1;

		public override TechNode RequiredTech => "t10f_ascended_widget";

		public T10AscendedWidget()
		{
			base.ItemHint = "ascended_widget";
			base.PlacementTech = "t10u_ascended_widget_placement";
			base.MusicName = "YouWereAlwaysInTheRightPlace";
			base.CheaperFirstWorker = false;
			_reagents["ascension_booster"] = 1;
			_reagents["nanoprocessor"] = 2;
			_reagents["unshackled_widget"] = 1;
			_results["ascended_widget"] = 1;
			_baseCraftingTime = 0.9f;
			_firstCost = new List<ItemType> { "superconductor", "unshackled_widget" };
			_baseCost = new List<ItemType> { "superconductor", "ascended_widget" };
			_extraCostMultiplier = 1.2999999523162842;
		}

		protected override double CalculatePlacementBonus(WorldFrame triggeredBy = null)
		{
			if (base.Terrain != 8)
			{
				return 1.0;
			}
			using (IEnumerator<WorldFrame> enumerator = GetAdjacentFrames().GetEnumerator())
			{
				if (enumerator.MoveNext())
				{
					_ = enumerator.Current;
					return 1.0;
				}
			}
			return base.PlacementTech.UpgradeMultiplier;
		}
	}
}
