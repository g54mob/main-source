using System;
using System.Collections.Generic;
using Dorfromantik;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RewardSystem : ScriptableObject
{
	[SerializeField]
	private RewardSystemConfiguration configuration;

	[SerializeField]
	private List<ScoreFxByType> scoreFx;

	[SerializeField]
	private PerfectPlacementFx perfectPlacementFx;

	[SerializeField]
	private float neighboringPerfectPlacementFxDelay = 0.5f;

	[SerializeField]
	private AudioClipOptions perfectPlacementSfx;

	[SerializeField]
	private AudioClipOptions gameOverSound;

	[SerializeField]
	private RewardLibrary rewardLibrary;

	[SerializeField]
	private InputRouter inputRouter;

	[SerializeField]
	private LeaderboardManager leaderboardManager;

	private Dictionary<string, int> rankByLeaderboardId = new Dictionary<string, int>();

	private Dictionary<string, int> localHighscoreByLeaderboardId = new Dictionary<string, int>();

	private int _003CLevel_003Ek__BackingField;

	private int _003CScore_003Ek__BackingField;

	private int _003CPlacedTileCount_003Ek__BackingField;

	private int _003CConsecutivePerfectFits_003Ek__BackingField;

	private int _003CConsecutivePlacementsWithoutRotate_003Ek__BackingField;

	private int _003CPerfectPlacementCount_003Ek__BackingField;

	private int _003CQuestFulfilledCount_003Ek__BackingField;

	private int _003CQuestFailedCount_003Ek__BackingField;

	private int _003CSurroundedTilesCount_003Ek__BackingField;

	private float lastStoredPlaytime;

	private float sessionStartTime;

	private bool _003CIsGameOver_003Ek__BackingField;

	private Dictionary<ScoreFxType, ScoreAddedFX> scoreAddedFxByType;

	public RewardSystemConfiguration Configuration => configuration;

	public int Level
	{
		get
		{
			return _003CLevel_003Ek__BackingField;
		}
		private set
		{
			_003CLevel_003Ek__BackingField = value;
		}
	}

	public int Score
	{
		get
		{
			return _003CScore_003Ek__BackingField;
		}
		private set
		{
			_003CScore_003Ek__BackingField = value;
		}
	}

	public int PlacedTileCount
	{
		get
		{
			return _003CPlacedTileCount_003Ek__BackingField;
		}
		private set
		{
			_003CPlacedTileCount_003Ek__BackingField = value;
		}
	}

	public int ConsecutivePerfectFits
	{
		get
		{
			return _003CConsecutivePerfectFits_003Ek__BackingField;
		}
		private set
		{
			_003CConsecutivePerfectFits_003Ek__BackingField = value;
		}
	}

	public int ConsecutivePlacementsWithoutRotate
	{
		get
		{
			return _003CConsecutivePlacementsWithoutRotate_003Ek__BackingField;
		}
		private set
		{
			_003CConsecutivePlacementsWithoutRotate_003Ek__BackingField = value;
		}
	}

	public int PerfectPlacementCount
	{
		get
		{
			return _003CPerfectPlacementCount_003Ek__BackingField;
		}
		private set
		{
			_003CPerfectPlacementCount_003Ek__BackingField = value;
		}
	}

	public int QuestFulfilledCount
	{
		get
		{
			return _003CQuestFulfilledCount_003Ek__BackingField;
		}
		private set
		{
			_003CQuestFulfilledCount_003Ek__BackingField = value;
		}
	}

	public int QuestFailedCount
	{
		get
		{
			return _003CQuestFailedCount_003Ek__BackingField;
		}
		set
		{
			_003CQuestFailedCount_003Ek__BackingField = value;
		}
	}

	public float Playtime
	{
		get
		{
			float result = (lastStoredPlaytime += Time.time - sessionStartTime);
			sessionStartTime = Time.time;
			return result;
		}
	}

	public int SurroundedTilesCount
	{
		get
		{
			return _003CSurroundedTilesCount_003Ek__BackingField;
		}
		set
		{
			_003CSurroundedTilesCount_003Ek__BackingField = value;
		}
	}

	public bool IsGameOver
	{
		get
		{
			return _003CIsGameOver_003Ek__BackingField;
		}
		private set
		{
			_003CIsGameOver_003Ek__BackingField = value;
		}
	}

	public event Action<int> OnTilesGained;

	public event Action<int> OnScoreChanged;

	public event Action OnConsecutivePerfectFitsChanged;

	public event Action OnConsecutivePlacementsWithoutRotateChanged;

	public event Action<PreplacedTileHint> OnPreplacedTileConnected;

	public event Action<int> OnLevelsGained;

	public event Action<bool, bool> OnGameOver;

	public event Action OnUndoGameOver;

	public event Action OnAutoSave;

	public event Action<QuestWatcher> OnQuestCompleted;

	public event Action OnPerfectPlacement;

	public event Action<QuestWatcher, QuestFailedReason> OnQuestFailed;

	public event Action OnLeaderboardRankChanged;

	public event Action<LeaderboardType> OnLeaderboardUpdateRequested;

	public event Action<LeaderboardType, int, bool> OnNewHighscoreSet;

	public event Action OnNewLocalHighscoreSet;

	public event Action OnReset;

	public void RotateTile(int rotationValue)
	{
		if (rotationValue != 0)
		{
			ConsecutivePlacementsWithoutRotate = 0;
			this.OnConsecutivePlacementsWithoutRotateChanged?.Invoke();
		}
	}

	public void ConnectPreplacedTile(PreplacedTileHint preplacedTileHint)
	{
		this.OnPreplacedTileConnected?.Invoke(preplacedTileHint);
	}

	public void GainTiles(int count)
	{
		this.OnTilesGained?.Invoke(count);
	}

	public void GainQuestTileReward()
	{
		if (Configuration.gainQuestRewardTiles)
		{
			int count = Mathf.RoundToInt(Configuration.questRewardByScore.Evaluate(Score));
			GainTiles(count);
		}
	}

	public void GainLevels(int gainedLevels)
	{
		Level += gainedLevels;
		this.OnLevelsGained?.Invoke(gainedLevels);
	}

	public void AddScore(int added)
	{
		Score += added;
		this.OnScoreChanged?.Invoke(added);
	}

	public void SetStats(RewardSystemData data)
	{
		Level = data.level;
		Score = data.score;
		ConsecutivePerfectFits = data.consecutivePerfectFits;
		ConsecutivePlacementsWithoutRotate = data.consecutivePerfectPlacementsWithoutRotate;
		PerfectPlacementCount = data.perfectPlacementCount;
		QuestFulfilledCount = data.questFulfilledCount;
		QuestFailedCount = data.questFailedCount;
		PlacedTileCount = data.placedTileCount;
		SurroundedTilesCount = data.surroundedTilesCount;
		this.OnReset?.Invoke();
		this.OnScoreChanged?.Invoke(0);
	}

	public void ResetLevelAndScore(SaveGameData_003 loadedData = null)
	{
		scoreAddedFxByType = new Dictionary<ScoreFxType, ScoreAddedFX>();
		foreach (ScoreFxByType item in scoreFx)
		{
			scoreAddedFxByType.Add(item.type, item.scoreFx);
		}
		Level = loadedData?.level ?? 0;
		Score = loadedData?.score ?? 0;
		ConsecutivePerfectFits = loadedData?.consecutivePerfectFits ?? 0;
		ConsecutivePlacementsWithoutRotate = loadedData?.consecutivePlacementsWithoutRotate ?? 0;
		PerfectPlacementCount = loadedData?.perfectPlacements ?? 0;
		QuestFulfilledCount = loadedData?.questsFulfilled ?? 0;
		QuestFailedCount = loadedData?.questsFailed ?? 0;
		PlacedTileCount = loadedData?.placedTileCount ?? 0;
		SurroundedTilesCount = loadedData?.surroundedTilesCount ?? 0;
		lastStoredPlaytime = loadedData?.playtime ?? 0f;
		sessionStartTime = Time.time;
		IsGameOver = false;
		this.OnReset?.Invoke();
		this.OnScoreChanged?.Invoke(0);
	}

	public void ResetScore(int newScore)
	{
		Score = newScore;
		this.OnReset?.Invoke();
		this.OnScoreChanged?.Invoke(0);
	}

	public void GameOver(bool animate, bool setHighscore)
	{
		if (!OverwritingSingleton<GameSession>.Instance.GameMode.doesTriggerGameOver)
		{
			Debug.LogError($"tried triggering GameOver in {OverwritingSingleton<GameSession>.Instance.GameMode}");
			return;
		}
		if (animate)
		{
			AudioManager.Instance.PlaySoundAtPosition(gameOverSound, Vector3.zero);
		}
		if (setHighscore)
		{
			UpdateHighscore(forceUpdate: true);
		}
		UnityAnalyticsAccessor.TriggerGameOverEvent(SceneManager.GetActiveScene().name, new Dictionary<string, object>
		{
			{ "score", Score },
			{ "level", Level },
			{ "questsFulfilled", QuestFulfilledCount },
			{ "questsFailed", QuestFailedCount },
			{ "perfectPlacements", PerfectPlacementCount }
		});
		IsGameOver = true;
		this.OnGameOver?.Invoke(animate, setHighscore);
	}

	public void UndoGameOver()
	{
		IsGameOver = false;
		inputRouter.SetInteractionRestriction(new InteractionRestriction());
		this.OnUndoGameOver?.Invoke();
	}

	public void UpdateHighscore(bool forceUpdate)
	{
		LeaderboardType currentLeaderboard = leaderboardManager.GetCurrentLeaderboard();
		if (currentLeaderboard == null || currentLeaderboard.IsNotInitialized)
		{
			if ((bool)currentLeaderboard)
			{
				Debug.Log("Not updating highscore because leaderboard date is not initialized " + currentLeaderboard.GetLeaderboardId());
			}
		}
		else if (Score >= PlayerPrefsAccessor.GetInt(currentLeaderboard.GetPlayerPrefsScoreKey(), 1))
		{
			SetLocalHighscore(currentLeaderboard, Score);
			this.OnNewHighscoreSet?.Invoke(currentLeaderboard, Score, forceUpdate);
		}
	}

	public void QuestStatusExecuted(QuestWatcher questWatcher, FulfillmentStatus fulfillmentStatus, QuestFailedReason questFailedReason = QuestFailedReason.Undefined)
	{
		switch (fulfillmentStatus)
		{
		case FulfillmentStatus.Fulfilled:
			this.OnQuestCompleted?.Invoke(questWatcher);
			QuestFulfilledCount++;
			break;
		case FulfillmentStatus.Unfulfillable:
			this.OnQuestFailed?.Invoke(questWatcher, questFailedReason);
			QuestFailedCount++;
			break;
		}
	}

	public void AddScoreAtPosition(int score, Vector3 fxPosition, ScoreFxType type, float delay = 0f, bool playSound = true)
	{
		if (configuration.collectScore)
		{
			AddScore(score);
			UnityEngine.Object.Instantiate(scoreAddedFxByType[type], fxPosition, Quaternion.identity).Appear($"+{score}", delay);
			if (type == ScoreFxType.PerfectPlacement)
			{
				UnityEngine.Object.Instantiate(perfectPlacementFx, fxPosition, Quaternion.identity).Play(delay, playSound);
			}
		}
	}

	public void AddTilePlacementScore(Tile newTile)
	{
		int count = newTile.FittingPlacedNeighbors.Count;
		if (count > 0)
		{
			if (Configuration.rewardTileFit)
			{
				int score = CalculateScore(configuration.tileFitScoreCalculationMethod, count, configuration.tileFitScoreModifier);
				AddScoreAtPosition(score, newTile.transform.position, ScoreFxType.Normal);
			}
			foreach (Tile fittingPlacedNeighbor in newTile.FittingPlacedNeighbors)
			{
				fittingPlacedNeighbor.StartWobble(0f);
			}
			foreach (Tile hybridPlacedNeighbor in newTile.HybridPlacedNeighbors)
			{
				hybridPlacedNeighbor.StartWobble(0f);
			}
		}
		if (newTile.FittingPlacedNeighbors.Count == newTile.ClosedEdgeCount)
		{
			ConsecutivePerfectFits++;
		}
		else
		{
			ConsecutivePerfectFits = 0;
		}
		this.OnConsecutivePerfectFitsChanged?.Invoke();
		ConsecutivePlacementsWithoutRotate++;
		this.OnConsecutivePlacementsWithoutRotateChanged?.Invoke();
		PlacedTileCount++;
		if (!Configuration.rewardTileClosed)
		{
			return;
		}
		bool flag = false;
		if (newTile.ClosedEdgeCount == 6)
		{
			if (newTile.FittingPlacedNeighbors.Count == 6)
			{
				AddScoreAtPosition(Configuration.perfectPlacementScore, newTile.transform.position, ScoreFxType.PerfectPlacement);
				GainTiles(Configuration.perfectPlacementTileReward);
				this.OnPerfectPlacement?.Invoke();
				PerfectPlacementCount++;
			}
			SurroundedTilesCount++;
		}
		for (int i = 0; i < 6; i++)
		{
			Tile tile = newTile.NeighborTiles[i];
			if (!tile || tile.ClosedEdgeCount != 6)
			{
				continue;
			}
			if (tile.FittingPlacedNeighbors.Count == 6)
			{
				AddScoreAtPosition(Configuration.perfectPlacementScore, tile.transform.position, ScoreFxType.PerfectPlacement, neighboringPerfectPlacementFxDelay, !flag);
				flag = true;
				GainTiles(Configuration.perfectPlacementTileReward);
				this.OnPerfectPlacement?.Invoke();
				PerfectPlacementCount++;
				foreach (Tile fittingPlacedNeighbor2 in tile.FittingPlacedNeighbors)
				{
					fittingPlacedNeighbor2.StartWobble(neighboringPerfectPlacementFxDelay);
				}
			}
			SurroundedTilesCount++;
		}
	}

	public void SetConfiguration(RewardSystemConfiguration targetConfiguration)
	{
		configuration = targetConfiguration;
	}

	public int CalculateScore(ScoreCalculationMethod calculationMethod, int scoreInput, int scoreModifier)
	{
		return calculationMethod switch
		{
			ScoreCalculationMethod.Linear => scoreModifier * scoreInput, 
			ScoreCalculationMethod.XSquared => Mathf.RoundToInt(Mathf.Pow(scoreModifier, 2f)), 
			ScoreCalculationMethod.TwoPowX => Mathf.RoundToInt(Mathf.Pow(2f, scoreModifier)), 
			_ => scoreModifier, 
		};
	}

	public void RequestLeaderboardRankUpdate()
	{
		LeaderboardType currentLeaderboard = leaderboardManager.GetCurrentLeaderboard();
		if (currentLeaderboard != null)
		{
			this.OnLeaderboardUpdateRequested?.Invoke(currentLeaderboard);
		}
	}

	public void SetLeaderboardRank(LeaderboardType leaderboardType, int newRank, bool callEventOnComplete = true)
	{
		string leaderboardId = leaderboardType.GetLeaderboardId();
		if (!rankByLeaderboardId.ContainsKey(leaderboardId))
		{
			rankByLeaderboardId.Add(leaderboardId, -1);
		}
		rankByLeaderboardId[leaderboardId] = newRank;
		if (callEventOnComplete)
		{
			LeaderboardRankChangedComplete(leaderboardType);
		}
	}

	public void LeaderboardRankChangedComplete(LeaderboardType leaderboardType)
	{
		string leaderboardId = leaderboardType.GetLeaderboardId();
		if (rankByLeaderboardId.ContainsKey(leaderboardId))
		{
			PlayerPrefsAccessor.SetInt(leaderboardType.GetPlayerPrefsRankKey(), rankByLeaderboardId[leaderboardId]);
			this.OnLeaderboardRankChanged?.Invoke();
		}
	}

	public int GetRank(LeaderboardType leaderboardType)
	{
		string leaderboardId = leaderboardType.GetLeaderboardId();
		if (!leaderboardType || !rankByLeaderboardId.ContainsKey(leaderboardId))
		{
			return -1;
		}
		return rankByLeaderboardId[leaderboardId];
	}

	public void SetLocalHighscore(LeaderboardType leaderboardType, int newScore, bool storeInPlayerPrefs = true)
	{
		string leaderboardId = leaderboardType.GetLeaderboardId();
		if (!localHighscoreByLeaderboardId.ContainsKey(leaderboardId))
		{
			localHighscoreByLeaderboardId.Add(leaderboardId, -1);
		}
		localHighscoreByLeaderboardId[leaderboardId] = newScore;
		Debug.Log($"Retrieved new local highscore from {leaderboardId}: {newScore}. Store in PlayerPrefs? {leaderboardType.GetPlayerPrefsScoreKey()}: {storeInPlayerPrefs}");
		if (storeInPlayerPrefs)
		{
			LocalHighscoreChangeComplete(leaderboardType);
		}
	}

	public void LocalHighscoreChangeComplete(LeaderboardType leaderboardType)
	{
		if (localHighscoreByLeaderboardId.ContainsKey(leaderboardType.GetLeaderboardId()))
		{
			int num = localHighscoreByLeaderboardId[leaderboardType.GetLeaderboardId()];
			if (num > PlayerPrefsAccessor.GetInt(leaderboardType.GetPlayerPrefsScoreKey(), 0))
			{
				PlayerPrefsAccessor.SetInt(leaderboardType.GetPlayerPrefsScoreKey(), num);
			}
			this.OnNewLocalHighscoreSet?.Invoke();
		}
	}
}
