using System.Collections.Generic;
using System.Numerics;
using Assets.Source.Item;
using Assets.Source.Player;
using UnityEngine;

namespace Assets.Source.World.Frames
{
	public class T10Leveler : CraftingFrame
	{
		private static List<ItemType> _items = new List<ItemType>();

		private static int _craftCount;

		public override int AutoWorkerMax => 6;

		public override double AutoworkerCostMultiplier => 3.0;

		public override TechNode RequiredTech => "t10f_leveler";

		public override string PlacementGuideHint => "@HintPlacementLeveler";

		public T10Leveler()
		{
			base.IconName = "Items2_2";
			base.MusicName = "YouWereAlwaysInTheRightPlace";
			_reagents["power"] = 10;
			List<ItemType> obj = new List<ItemType> { "ascended_widget" };
			List<ItemType> firstCost = obj;
			_baseCost = obj;
			_firstCost = firstCost;
			_autoCraftingTime = 30f;
			_extraCostMultiplier = 0.5;
		}

		public override bool IsValidPlacement(WorldMap map, Vector2Int pos)
		{
			if (map.GetTerrain(pos) != 8)
			{
				return false;
			}
			return base.IsValidPlacement(map, pos);
		}

		public override IEnumerable<KeyValuePair<ItemType, BigInteger>> GetResults()
		{
			_updateItems();
			yield return KeyValuePair.Create(SeededRandom.Global.Choose(_items), new BigInteger(1));
		}

		public override void OnItemAutocrafted(ItemType i, BigInteger count)
		{
			_craftCount++;
			if (_craftCount > 25 && _convertCityTile())
			{
				_craftCount -= 25;
			}
		}

		private void _updateItems()
		{
			if (_items.Count > 0 && _craftCount % 10 != 0)
			{
				return;
			}
			_items.Clear();
			foreach (ItemType inventoryItem in GamePlayer.Current.GetInventoryItems())
			{
				if (inventoryItem.Tier <= 11)
				{
					_items.Add(inventoryItem);
				}
			}
		}

		private bool _convertCityTile()
		{
			byte terrain = WorldMap.Current.GetTerrain(base.Position);
			if (terrain != 8 && terrain != 9)
			{
				return false;
			}
			List<Vector2Int> tileArea = WorldMap.Current.GetTileArea(base.Position);
			for (int i = 0; i < tileArea.Count; i++)
			{
				if (WorldMap.Current.GetTerrain(tileArea[i]) == 8)
				{
					WorldMap.Current.SetTerrain(tileArea[i], 9);
					return true;
				}
			}
			return false;
		}
	}
}
