using System.Collections.Generic;
using Assets.Source.Item;
using Assets.Source.Player;

namespace Assets.Source.World.Frames
{
	public class T11SentientCore : CraftingFrame
	{
		public override int AutoWorkerMax => 6;

		public override int HandCraftButtonCount => 1;

		public override TechNode RequiredTech => "t11f_sentient_core";

		public T11SentientCore()
		{
			base.ItemHint = "sentient_core";
			base.PlacementTech = "t11u_sentient_core_placement";
			base.MusicName = "FugueForOneSyntheticHeart";
			_reagents["ai_core"] = 1;
			_reagents["ai_training_data"] = 1;
			_reagents["power"] = 68;
			_results["sentient_core"] = 1;
			_baseCraftingTime = 1f;
			_firstCost = new List<ItemType> { "ai_training_data", "ascended_widget" };
			_baseCost = new List<ItemType> { "ai_training_data", "sentient_widget" };
			_extraCostMultiplier = 1.2999999523162842;
		}

		protected override double CalculatePlacementBonus(WorldFrame triggeredBy)
		{
			HashSet<byte> hashSet = new HashSet<byte>();
			foreach (byte item in GetAdjacentTerrain(includeSelf: true))
			{
				hashSet.Add(item);
			}
			return 1.0 + base.PlacementTech.UpgradeMultiplier * (double)hashSet.Count;
		}

		public override AutoWorker CreateAutoWorker(WorldAnchor slot)
		{
			return new T11SentientCoreCrafter(this, slot);
		}
	}
}
