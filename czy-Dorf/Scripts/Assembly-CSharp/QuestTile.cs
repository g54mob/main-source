using System.Collections.Generic;
using Dorfromantik;
using UnityEngine;

public class QuestTile : Tile
{
	public List<int> watchDirections;

	public int minTargetCount;

	[SerializeField]
	private Quest currentQuest;

	public QuestTileId id;

	public string questTileId = "";

	public int level = -1;

	private QuestTileData_002 loadedData;

	[SerializeField]
	private RewardSystem rewardSystem;

	[SerializeField]
	private QuestManager questManager;

	[SerializeField]
	private SessionQuestManager sessionQuestManager;

	private QuestGiver _003CQuestGiver_003Ek__BackingField;

	private QuestWatcher _003CQuestWatcher_003Ek__BackingField;

	public QuestGiver QuestGiver
	{
		get
		{
			return _003CQuestGiver_003Ek__BackingField;
		}
		private set
		{
			_003CQuestGiver_003Ek__BackingField = value;
		}
	}

	public QuestWatcher QuestWatcher
	{
		get
		{
			return _003CQuestWatcher_003Ek__BackingField;
		}
		private set
		{
			_003CQuestWatcher_003Ek__BackingField = value;
		}
	}

	protected override void Awake()
	{
		base.Awake();
		QuestGiver = GetComponentInChildren<QuestGiver>();
		QuestWatcher = GetComponentInChildren<QuestWatcher>();
	}

	public void InitializeRandomQuest(bool forceInitializeNewQuest = false)
	{
		if (forceInitializeNewQuest)
		{
			QuestTileData_002 questTileData_ = loadedData;
			if (questTileData_ != null && questTileData_.targetValue == -1)
			{
				loadedData = null;
			}
		}
		if (!OverwritingSingleton<GameSession>.Instance.GameMode.spawnsQuests || (loadedData != null && !loadedData.questActive))
		{
			QuestWatcher.HideQuest();
			return;
		}
		level = loadedData?.questLevel ?? rewardSystem.Level;
		Random.InitState(base.Seed);
		List<Quest> list = new List<Quest>();
		currentQuest = questManager.Configuration.SelectRandomQuest(this, level, loadedData);
		list.Add(currentQuest);
		Quest followupQuest = questManager.GetFollowupQuest(this, currentQuest);
		if ((bool)followupQuest)
		{
			list.Add(followupQuest);
		}
		if (QuestWatcher == null)
		{
			Debug.LogError(base.name + " has no QuestWatcher", this);
		}
		QuestWatcher.Initialize(this, list, loadedData);
		QuestWatcher.SetupQuestLabel();
		if (loadedData != null && loadedData.unlockedChallengeId != ChallengeId.Undefined)
		{
			QuestWatcher.SetSessionQuest(sessionQuestManager.GetSessionQuest(loadedData.unlockedChallengeId));
		}
		QuestWatcher.StartWatching();
		Randomizer.RandomizeSeed();
	}

	public override void BoardInitialization()
	{
		base.BoardInitialization();
		InitializeRandomQuest();
	}

	public override void ChangeTileState(TileState targetState)
	{
		if (base.State != targetState && targetState == TileState.topStackPreview)
		{
			InitializeRandomQuest(forceInitializeNewQuest: true);
		}
		base.ChangeTileState(targetState);
	}

	public void SetupLoadedData(QuestTileData_002 questTileData)
	{
		loadedData = questTileData;
	}
}
