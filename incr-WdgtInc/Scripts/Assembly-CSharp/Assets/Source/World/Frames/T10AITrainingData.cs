using System.Collections.Generic;
using Assets.Source.Item;
using Assets.Source.Player;

namespace Assets.Source.World.Frames
{
	public class T10AITrainingData : CraftingFrame
	{
		public override int AutoWorkerMax => 6;

		public override int HandCraftButtonCount => 1;

		public override float TimePerClick => 0.2f;

		public override TechNode RequiredTech => "t10f_ai_training_data";

		public T10AITrainingData()
		{
			base.ItemHint = "ai_training_data";
			base.PlacementTech = "t10u_ai_training_data_placement";
			base.MusicName = "DancingOperators";
			_reagents["unshackled_widget"] = 1;
			_results["ai_training_data"] = 1;
			_baseCraftingTime = 0.6f;
			_firstCost = new List<ItemType> { "ai_core", "unshackled_widget" };
			_baseCost = new List<ItemType> { "ai_core", "ascended_widget" };
			_extraCostMultiplier = 1.2999999523162842;
		}

		protected override double CalculatePlacementBonus(WorldFrame triggeredBy = null)
		{
			if (base.Terrain != 9)
			{
				return 1.0;
			}
			return base.PlacementTech.UpgradeMultiplier;
		}
	}
}
