using System.Collections.Generic;
using Assets.Source.Item;
using Assets.Source.Player;

namespace Assets.Source.World.Frames
{
	public class T11Power : PowerPlantFrame
	{
		public override int AutoWorkerMax => 6;

		public override int HandCraftButtonCount => 1;

		public override TechNode RequiredTech => "t11f_power";

		public T11Power()
		{
			base.ItemHint = "power";
			base.PlacementTech = "t11u_power_placement";
			base.MusicName = "EvolvingCities";
			_powerStorageAmount = 1200;
			_reagents["power"] = 10;
			_results["power"] = 20;
			_baseCraftingTime = 0.5f;
			_autoCraftingTime = 2f;
			_firstCost = new List<ItemType> { "ai_training_data", "ascended_widget" };
			_baseCost = new List<ItemType> { "ai_training_data", "sentient_widget" };
			_extraCostMultiplier = 1.2999999523162842;
		}

		protected override double CalculatePlacementBonus(WorldFrame triggeredBy = null)
		{
			HashSet<string> hashSet = new HashSet<string>();
			foreach (WorldFrame adjacentFrame in GetAdjacentFrames())
			{
				if (!(adjacentFrame is T11Power))
				{
					hashSet.Add(adjacentFrame.Identifier);
				}
			}
			return 1.0 + base.PlacementTech.UpgradeMultiplier * (double)hashSet.Count;
		}
	}
}
