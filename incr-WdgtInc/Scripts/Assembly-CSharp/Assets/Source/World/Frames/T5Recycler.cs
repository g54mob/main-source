using System.Collections.Generic;
using System.Numerics;
using Assets.Source.Item;
using Assets.Source.Player;
using UnityEngine;

namespace Assets.Source.World.Frames
{
	public class T5Recycler : CraftingFrame
	{
		public static ItemType[] AvailableItems = new ItemType[3] { "iron_ingot", "battery", "circuit_board" };

		public override int AutoWorkerMax => 6;

		public override int HandCraftButtonCount => 0;

		public override double AutoworkerCostMultiplier => 3.0;

		public override TechNode RequiredTech => "t5f_recycler";

		public override string PlacementGuideHint => "@HintPlacementRecycler";

		public T5Recycler()
		{
			base.IconName = "Items2_0";
			base.MusicName = "YouWereAlwaysInTheRightPlace";
			List<ItemType> obj = new List<ItemType> { "integrated_widget" };
			List<ItemType> firstCost = obj;
			_baseCost = obj;
			_firstCost = firstCost;
			_reagents["bottled_lightning"] = 1;
			_results["iron_ingot"] = 1;
			_results["battery"] = 1;
			_results["circuit_board"] = 1;
			_autoCraftingTime = 16f;
			_extraCostMultiplier = 0.5;
		}

		public override bool IsValidPlacement(WorldMap map, Vector2Int pos)
		{
			byte terrain = map.GetTerrain(pos);
			if (terrain != 8 && terrain != 9)
			{
				return false;
			}
			return base.IsValidPlacement(map, pos);
		}

		public override IEnumerable<KeyValuePair<ItemType, BigInteger>> GetResults()
		{
			ItemType[] availableItems = AvailableItems;
			foreach (ItemType key in availableItems)
			{
				if (SeededRandom.Global.RandomBool(0.6f))
				{
					yield return KeyValuePair.Create(key, BigInteger.One);
				}
			}
		}

		public override AutoWorker CreateAutoWorker(WorldAnchor slot)
		{
			return new T5RecyclerAutocrafter(this, slot);
		}
	}
}
