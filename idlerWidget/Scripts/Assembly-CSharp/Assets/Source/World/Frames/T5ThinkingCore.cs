using System.Collections.Generic;
using Assets.Source.Item;
using Assets.Source.Player;

namespace Assets.Source.World.Frames
{
	public class T5ThinkingCore : CraftingFrame
	{
		public override int AutoWorkerCount => 6;

		public override int HandCraftButtonCount => 1;

		public override float TimePerClick => 0.2f;

		public override TechNode RequiredTech => "t5f_thinking_core";

		public T5ThinkingCore()
		{
			base.ItemHint = "thinking_core";
			base.PlacementTech = "t5u_thinking_core_placement";
			base.MusicName = "FugueForOneSyntheticHeart";
			_reagents["capacitor_widget"] = 1;
			_reagents["computational_widget"] = 1;
			_results["thinking_core"] = 1;
			_baseCraftingTime = 1f;
			_firstCost = new List<ItemType> { "circuit_board", "computational_widget" };
			_baseCost = new List<ItemType> { "circuit_board", "integrated_widget" };
			_extraCostMultiplier = 1.3f;
		}

		protected override float CalculatePlacementBonus()
		{
			using (IEnumerator<WorldFrame> enumerator = GetAdjacentFrames().GetEnumerator())
			{
				if (enumerator.MoveNext())
				{
					_ = enumerator.Current;
					return 1f;
				}
			}
			return base.PlacementTech.UpgradeMultiplier;
		}
	}
}
