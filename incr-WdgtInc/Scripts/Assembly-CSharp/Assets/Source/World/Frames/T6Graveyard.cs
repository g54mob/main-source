using System.Collections.Generic;
using Assets.Behaviour.Util;
using Assets.Source.Item;
using Assets.Source.Player;
using UnityEngine;

namespace Assets.Source.World.Frames
{
	public class T6Graveyard : CraftingFrame
	{
		public override int AutoWorkerMax => 6;

		public override int HandCraftButtonCount => 0;

		public override TechNode RequiredTech => "t6f_graveyard";

		public T6Graveyard()
		{
			base.IconName = "Items2_5";
			base.MusicName = "EvolvingCities";
			_reagents["human_remains"] = 1;
			_baseCost = new List<ItemType> { "thinking_core", "mainframe_widget" };
			_extraCostMultiplier = 1.2999999523162842;
			_autoCraftingTime = 12f;
		}

		public override void OnConstructionCompleted()
		{
			int num = 0;
			foreach (T6Graveyard frame in WorldMap.Current.GetFrames<T6Graveyard>())
			{
				if (frame.Construction == null)
				{
					num++;
				}
			}
			SteamStatsManager.Set(SteamStatType.Graveyards, num);
		}

		public override bool IsValidPlacement(WorldMap map, Vector2Int pos)
		{
			bool flag = GamePlayer.Current.HasTech(TechNode.IndenturedServitude3);
			byte terrain = map.GetTerrain(pos);
			if (terrain == 8 || (flag && terrain == 9))
			{
				return false;
			}
			for (int i = -1; i <= 1; i++)
			{
				for (int j = -1; j <= 1; j++)
				{
					if (i != 0 || j != 0)
					{
						Vector2Int pos2 = new Vector2Int(pos.x + i, pos.y + j);
						terrain = map.GetTerrain(pos2);
						if (terrain == 8 || (flag && terrain == 9))
						{
							return true;
						}
						if (map.GetFrame(pos2) is T6Graveyard)
						{
							return true;
						}
					}
				}
			}
			return false;
		}
	}
}
