using System;
using System.Collections.Generic;
using UnityEngine;

namespace Dorfromantik
{
	[Serializable]
	public class TurnData
	{
		public TileData_003 placedTileData;

		public int tileStackHeight;

		public RewardSystemData rewardSystemData;

		public List<QuestWatcherState> questWatcherStates = new List<QuestWatcherState>();

		public List<ChallengeData_002> challengeStates = new List<ChallengeData_002>();

		public List<int[]> connectedPreplacedTilePositions = new List<int[]>();

		public int generatedTileCount;

		public int generatedQuestCount;

		public int discardedTileCount;

		public List<TileData_003> stackedTiles;

		public TurnData(Tile placedTile, TileStack tileStack, RewardSystem rewardSystem, QuestManager questManager, SessionQuestWatcher sessionQuestWatcher, List<Vector2Int> connectedPreplacedTilePositions)
		{
			if ((bool)placedTile)
			{
				placedTileData = new TileData_003(placedTile);
			}
			StoreStackedTiles(tileStack);
			rewardSystemData = new RewardSystemData(rewardSystem);
			tileStackHeight = tileStack.RawHeight;
			foreach (QuestWatcher allQuestWatcher in questManager.AllQuestWatchers)
			{
				if (allQuestWatcher.QuestTile.State == TileState.placed)
				{
					questWatcherStates.Add(new QuestWatcherState(allQuestWatcher));
				}
			}
			foreach (WatchedSessionQuest watchedSessionQuest in sessionQuestWatcher.watchedSessionQuests)
			{
				challengeStates.Add(new ChallengeData_002(watchedSessionQuest.SessionQuest));
			}
			this.connectedPreplacedTilePositions = new List<int[]>();
			foreach (Vector2Int connectedPreplacedTilePosition in connectedPreplacedTilePositions)
			{
				this.connectedPreplacedTilePositions.Add(new int[2] { connectedPreplacedTilePosition.x, connectedPreplacedTilePosition.y });
			}
		}

		public TurnData(Tile placedTile)
		{
			placedTileData = new TileData_003(placedTile);
		}

		public void AddData(TileStack tileStack, RewardSystem rewardSystem, QuestManager questManager, SessionQuestWatcher sessionQuestWatcher, List<Vector2Int> connectedPreplacedTilePositions)
		{
			rewardSystemData = new RewardSystemData(rewardSystem);
			tileStackHeight = tileStack.RawHeight;
			foreach (QuestWatcher allQuestWatcher in questManager.AllQuestWatchers)
			{
				if (allQuestWatcher.QuestTile.State == TileState.placed)
				{
					questWatcherStates.Add(new QuestWatcherState(allQuestWatcher));
				}
			}
			foreach (WatchedSessionQuest watchedSessionQuest in sessionQuestWatcher.watchedSessionQuests)
			{
				challengeStates.Add(new ChallengeData_002(watchedSessionQuest.SessionQuest));
			}
			this.connectedPreplacedTilePositions = new List<int[]>();
			foreach (Vector2Int connectedPreplacedTilePosition in connectedPreplacedTilePositions)
			{
				this.connectedPreplacedTilePositions.Add(new int[2] { connectedPreplacedTilePosition.x, connectedPreplacedTilePosition.y });
			}
		}

		public void StoreStackedTiles(TileStack tileStack)
		{
			stackedTiles = new List<TileData_003>();
			foreach (Tile generatedTile in tileStack.GetGeneratedTiles())
			{
				stackedTiles.Add(new TileData_003(generatedTile));
			}
		}
	}
}
