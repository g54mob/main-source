using System.Collections.Generic;
using Assets.Source.Item;
using Assets.Source.Player;

namespace Assets.Source.World.Frames
{
	public class T7CloudWidget : CraftingFrame
	{
		public override int AutoWorkerMax => 6;

		public override int HandCraftButtonCount => 1;

		public override TechNode RequiredTech => "t7f_cloud_widget";

		public T7CloudWidget()
		{
			base.ItemHint = "cloud_widget";
			base.PlacementTech = "t7u_cloud_widget_placement";
			base.MusicName = "TheLongestYear";
			base.CheaperFirstWorker = false;
			_reagents["mainframe_widget"] = 2;
			_reagents["power"] = 99;
			_results["cloud_widget"] = 1;
			_baseCraftingTime = 1f;
			_firstCost = new List<ItemType> { "microprocessor", "mainframe_widget" };
			_baseCost = new List<ItemType> { "microprocessor", "cloud_widget" };
			_extraCostMultiplier = 1.399999976158142;
		}

		public override AutoWorker CreateAutoWorker(WorldAnchor slot)
		{
			return new T7CloudWidgetCrafter(this, slot);
		}

		protected override double CalculatePlacementBonus(WorldFrame triggeredBy)
		{
			if (WorldMap.Current.GetTerrain(base.Position) != 8)
			{
				return 1.0;
			}
			return base.PlacementTech.UpgradeMultiplier;
		}
	}
}
