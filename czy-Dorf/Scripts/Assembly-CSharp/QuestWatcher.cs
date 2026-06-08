using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Dorfromantik;
using UnityEngine;

public class QuestWatcher : MonoBehaviour
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

		public static Func<FulfillmentStatus, bool> _003C_003E9__62_0;

		public static Func<FulfillmentStatus, bool> _003C_003E9__62_1;

		internal bool _003CCheckQuestFulfillment_003Eb__62_0(FulfillmentStatus x)
		{
			return x == FulfillmentStatus.Fulfilled;
		}

		internal bool _003CCheckQuestFulfillment_003Eb__62_1(FulfillmentStatus x)
		{
			return x == FulfillmentStatus.Unfulfillable;
		}
	}

	private sealed class _003CAdvanceQuestQueueAfterDelay_003Ed__64 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public QuestWatcher _003C_003E4__this;

		public float delay;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		[DebuggerHidden]
		public _003CAdvanceQuestQueueAfterDelay_003Ed__64(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			int num = _003C_003E1__state;
			QuestWatcher questWatcher = _003C_003E4__this;
			switch (num)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				questWatcher.CurrentQuestIndex++;
				_003C_003E2__current = new WaitForSeconds(delay);
				_003C_003E1__state = 1;
				return true;
			case 1:
				_003C_003E1__state = -1;
				if (questWatcher.CurrentQuest.displayType == QuestDisplayType.Flag)
				{
					questWatcher.ClosingQuestFlag.Show(newShow: true);
				}
				questWatcher.StartWatching();
				questWatcher.ExecuteFulfillmentStatus(null, isPlacedByPlayer: true);
				return false;
			}
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}
	}

	[SerializeField]
	private List<QuestConditionWatcher> conditionWatchers;

	[SerializeField]
	private List<GroupConditionWatcher> groupConditionWatchers;

	private FulfillmentStatus[] conditionsFulfilled;

	private FulfillmentStatus questFulfillmentStatus;

	[SerializeField]
	private AudioClipOptions questFulfilledSound;

	[SerializeField]
	private AudioClipOptions questUnfulfilledSound;

	[SerializeField]
	private VfxConfiguration questFulfilledFx;

	[SerializeField]
	private RewardSystem rewardSystem;

	[SerializeField]
	private QuestManager questManager;

	[SerializeField]
	private VfxManager vfxManager;

	[SerializeField]
	private SessionQuestManager sessionQuestManager;

	[SerializeField]
	private TilePlacementEventBroadcaster tilePlacementEventBroadcaster;

	[SerializeField]
	private LoadingProgressRouter loadingProgressRouter;

	private bool _003CWatching_003Ek__BackingField;

	private int _003CCurrentQuestIndex_003Ek__BackingField;

	private SessionQuest _003CUnlockingSessionQuest_003Ek__BackingField;

	private List<Quest> questQueue;

	private QuestTile _003CQuestTile_003Ek__BackingField;

	private QuestLabel questLabel;

	private ClosingQuestFlag _003CClosingQuestFlag_003Ek__BackingField;

	private bool fulfillmentStatusExecutionPending;

	private QuestFailedReason questFailedReason;

	private QuestTileData_002 loadedData;

	private Coroutine advanceAfterDelayCoroutine;

	public bool Watching
	{
		get
		{
			return _003CWatching_003Ek__BackingField;
		}
		private set
		{
			_003CWatching_003Ek__BackingField = value;
		}
	}

	public int CurrentQuestIndex
	{
		get
		{
			return _003CCurrentQuestIndex_003Ek__BackingField;
		}
		private set
		{
			_003CCurrentQuestIndex_003Ek__BackingField = value;
		}
	}

	public FulfillmentStatus CurrentFulfillmentStatus => questFulfillmentStatus;

	public TileState State => QuestTile.State;

	public Quest CurrentQuest
	{
		get
		{
			if (questQueue == null || CurrentQuestIndex >= questQueue.Count)
			{
				return null;
			}
			return questQueue[CurrentQuestIndex];
		}
	}

	public SessionQuest UnlockingSessionQuest
	{
		get
		{
			return _003CUnlockingSessionQuest_003Ek__BackingField;
		}
		private set
		{
			_003CUnlockingSessionQuest_003Ek__BackingField = value;
		}
	}

	public QuestTile QuestTile
	{
		get
		{
			return _003CQuestTile_003Ek__BackingField;
		}
		private set
		{
			_003CQuestTile_003Ek__BackingField = value;
		}
	}

	public ClosingQuestFlag ClosingQuestFlag
	{
		get
		{
			return _003CClosingQuestFlag_003Ek__BackingField;
		}
		private set
		{
			_003CClosingQuestFlag_003Ek__BackingField = value;
		}
	}

	public QuestLabel QuestLabel => questLabel;

	public bool HasFollowupQuest
	{
		get
		{
			if (questQueue != null)
			{
				return questQueue.Count > 1;
			}
			return false;
		}
	}

	public event Action<FulfillmentStatus> OnExecuteQuestFulfillment;

	public event Action<bool> OnAffectedByCurrentTile;

	private void Awake()
	{
		conditionWatchers = new List<QuestConditionWatcher>();
		groupConditionWatchers = new List<GroupConditionWatcher>();
		questLabel = GetComponentInChildren<QuestLabel>(includeInactive: true);
	}

	public void Initialize(QuestTile questTile, List<Quest> questQueue, QuestTileData_002 loadedData = null)
	{
		QuestTile = questTile;
		this.questQueue = questQueue;
		this.loadedData = loadedData;
		ClosingQuestFlag = questTile.GetComponentInChildren<ClosingQuestFlag>(includeInactive: true);
	}

	public void SetupQuestLabel()
	{
		questLabel.Setup(questQueue, QuestTile);
		ClosingQuestFlag.Setup(questQueue, QuestTile);
	}

	public void SetSessionQuest(SessionQuest sessionQuest)
	{
		UnlockingSessionQuest = sessionQuest;
		questLabel.SetSessionQuest(sessionQuest);
	}

	public void StartWatching()
	{
		if (loadedData != null)
		{
			if (loadedData.questQueueIndex > CurrentQuestIndex)
			{
				if (questQueue.Count <= CurrentQuestIndex + 1)
				{
					HideQuest();
					return;
				}
				AdvanceQuestInstantly();
			}
			UnityAnalyticsAccessor.SendCustomEvent("quest_spawned", new Dictionary<string, object>
			{
				{ "questTileId", QuestTile.questTileId },
				{ "questId", CurrentQuest.stringId }
			});
		}
		SetupConditionWatchers(QuestTile, loadedData?.targetValue ?? (-1));
		questManager.RemoveQuest(this);
		questManager.AddQuest(this);
		Watching = true;
	}

	public void SetupConditionWatchers(QuestTile questTile, int overwriteTargetValue = -1)
	{
		QuestTile = questTile;
		conditionsFulfilled = new FulfillmentStatus[CurrentQuest.conditions.Count];
		conditionWatchers.Clear();
		groupConditionWatchers.Clear();
		for (int i = 0; i < CurrentQuest.conditions.Count; i++)
		{
			QuestCondition condition = CurrentQuest.conditions[i];
			List<int> watchDirections = questTile.watchDirections;
			if (CurrentQuest.watchType.watchAssociatedGroups)
			{
				GroupConditionWatcher item = new GroupConditionWatcher(condition, watchDirections, CurrentQuest, questTile, i, questManager, overwriteTargetValue);
				conditionWatchers.Add(item);
				groupConditionWatchers.Add(item);
			}
		}
		foreach (QuestConditionWatcher conditionWatcher in conditionWatchers)
		{
			conditionWatcher.OnConditionFulfillmentChanged += ConditionFulfillmentChanged;
			conditionWatcher.OnAffectedByCurrentTile += AffectedByCurrentTile;
			conditionWatcher.InitializeWatchTargets();
		}
	}

	private void ConditionFulfillmentChanged(int index, FulfillmentStatus newFulfilled, int currentValue, int targetValue, QuestFailedReason failedReason)
	{
		if (CurrentQuest.displayType == QuestDisplayType.Bubble)
		{
			questLabel.UpdateConditionStatus(index, newFulfilled, currentValue, targetValue);
		}
		conditionsFulfilled[index] = newFulfilled;
		if (failedReason != QuestFailedReason.Undefined)
		{
			questFailedReason = failedReason;
		}
		CheckQuestFulfillment();
	}

	private void CheckQuestFulfillment()
	{
		FulfillmentStatus questStatus = FulfillmentStatus.Changed;
		if (Enumerable.All(conditionsFulfilled, (FulfillmentStatus x) => x == FulfillmentStatus.Fulfilled))
		{
			questStatus = FulfillmentStatus.Fulfilled;
		}
		if (Enumerable.Any(conditionsFulfilled, (FulfillmentStatus x) => x == FulfillmentStatus.Unfulfillable))
		{
			questStatus = FulfillmentStatus.Unfulfillable;
		}
		questFulfillmentStatus = questStatus;
		if (CurrentQuest.displayType == QuestDisplayType.Bubble)
		{
			questLabel.UpdateQuestStatus(questStatus);
		}
		if (!fulfillmentStatusExecutionPending)
		{
			tilePlacementEventBroadcaster.OnTilePlaced_UndoStored += ExecuteFulfillmentStatus;
			fulfillmentStatusExecutionPending = true;
		}
	}

	private void ExecuteFulfillmentStatus(Tile placedTile, bool isPlacedByPlayer)
	{
		if (!isPlacedByPlayer && loadingProgressRouter.IsLoading)
		{
			return;
		}
		fulfillmentStatusExecutionPending = false;
		switch (questFulfillmentStatus)
		{
		case FulfillmentStatus.Unchanged:
			tilePlacementEventBroadcaster.OnTilePlaced_UndoStored -= ExecuteFulfillmentStatus;
			return;
		case FulfillmentStatus.Fulfilled:
			if (QuestTile == null)
			{
				Debug.LogError("QuestWatcher wants to execute fulfillmentStatus but doesn't exist anymore");
				tilePlacementEventBroadcaster.OnTilePlaced_UndoStored -= ExecuteFulfillmentStatus;
				return;
			}
			rewardSystem.GainQuestTileReward();
			AudioManager.Instance.PlaySoundAtPosition(questFulfilledSound, base.transform.position);
			if (CurrentQuest.displayType == QuestDisplayType.Bubble)
			{
				vfxManager.SpawnEffectAtPosition(questFulfilledFx, questLabel.transform.position);
				rewardSystem.AddScoreAtPosition(rewardSystem.Configuration.questScoreReward, questLabel.transform.position, ScoreFxType.Normal);
				rewardSystem.GainLevels(1);
			}
			else
			{
				rewardSystem.AddScoreAtPosition(rewardSystem.Configuration.closingQuestScoreReward, ClosingQuestFlag.transform.position, ScoreFxType.Normal);
			}
			if ((bool)UnlockingSessionQuest && UnlockingSessionQuest.CurrentState == RewardState.Hidden)
			{
				UnlockingSessionQuest.Unlock();
				if ((bool)UnlockingSessionQuest.compositeParentQuest)
				{
					sessionQuestManager.UpdateSessionQuestData(UnlockingSessionQuest.compositeParentQuest, save: false);
				}
				sessionQuestManager.UpdateSessionQuestData(UnlockingSessionQuest, save: true);
				vfxManager.AddSessionQuestEffectToQueue(UnlockingSessionQuest, 0, SessionQuestFxType.ChallengeUnlocked);
			}
			break;
		case FulfillmentStatus.Unfulfillable:
			if (QuestTile == null)
			{
				Debug.LogError("QuestWatcher wants to execute fulfillmentStatus but doesn't exist anymore");
				tilePlacementEventBroadcaster.OnTilePlaced_UndoStored -= ExecuteFulfillmentStatus;
				return;
			}
			AudioManager.Instance.PlaySoundAtPosition(questUnfulfilledSound, base.transform.position);
			break;
		}
		if (CurrentQuest.displayType == QuestDisplayType.Bubble)
		{
			questLabel.ExecuteQuestStatus(questFulfillmentStatus);
		}
		else
		{
			ClosingQuestFlag.ExecuteQuestStatus(questFulfillmentStatus);
		}
		if (questFulfillmentStatus == FulfillmentStatus.Fulfilled || questFulfillmentStatus == FulfillmentStatus.Unfulfillable)
		{
			rewardSystem.QuestStatusExecuted(this, questFulfillmentStatus, questFailedReason);
			StopWatching();
			UnityAnalyticsAccessor.SendCustomEvent((questFulfillmentStatus == FulfillmentStatus.Fulfilled) ? "quest_fulfilled" : "quest_failed", new Dictionary<string, object>
			{
				{ "questTileId", QuestTile.questTileId },
				{ "questId", CurrentQuest.stringId }
			});
			if (questFulfillmentStatus == FulfillmentStatus.Fulfilled && questQueue.Count > CurrentQuestIndex + 1)
			{
				advanceAfterDelayCoroutine = StartCoroutine(AdvanceQuestQueueAfterDelay(1.5f));
			}
		}
		tilePlacementEventBroadcaster.OnTilePlaced_UndoStored -= ExecuteFulfillmentStatus;
	}

	private IEnumerator AdvanceQuestQueueAfterDelay(float delay)
	{
		return new _003CAdvanceQuestQueueAfterDelay_003Ed__64(0)
		{
			_003C_003E4__this = this,
			delay = delay
		};
	}

	public void AdvanceQuestInstantly()
	{
		CurrentQuestIndex++;
		if (CurrentQuest.displayType == QuestDisplayType.Flag)
		{
			questLabel.Activate(shouldActivate: false, animate: false);
			ClosingQuestFlag.Show(newShow: true, animate: false);
		}
		ExecuteFulfillmentStatus(null, isPlacedByPlayer: true);
	}

	public void StopWatching()
	{
		HighlightWatchTarget(newHighlight: false);
		foreach (QuestConditionWatcher conditionWatcher in conditionWatchers)
		{
			conditionWatcher.OnConditionFulfillmentChanged -= ConditionFulfillmentChanged;
			conditionWatcher.OnAffectedByCurrentTile -= AffectedByCurrentTile;
			conditionWatcher.StopWatching();
		}
		tilePlacementEventBroadcaster.OnTilePlaced_UndoStored -= ExecuteFulfillmentStatus;
		fulfillmentStatusExecutionPending = false;
		if (questFulfillmentStatus == FulfillmentStatus.Unfulfillable || CurrentQuestIndex == questQueue.Count - 1)
		{
			questManager.RemoveQuest(this);
			Watching = false;
		}
	}

	private void AffectedByCurrentTile(bool isAffected)
	{
		this.OnAffectedByCurrentTile?.Invoke(isAffected);
	}

	public void ExpandQuestsDependingOnRelevance(Tile newTile)
	{
		bool flag = false;
		foreach (ElementGroupSegment allElementGroupSegment in newTile.AllElementGroupSegments)
		{
			foreach (GroupConditionWatcher groupConditionWatcher in groupConditionWatchers)
			{
				if (groupConditionWatcher.IsRelevantFor(allElementGroupSegment))
				{
					flag = true;
					break;
				}
			}
			if (flag)
			{
				break;
			}
		}
		questLabel.Expand(flag);
	}

	private void OnDestroy()
	{
		if (tilePlacementEventBroadcaster == null)
		{
			Debug.LogError(base.name + " has no tilePlacementEventBroadcaster");
		}
		tilePlacementEventBroadcaster.OnTilePlaced_UndoStored -= ExecuteFulfillmentStatus;
		questManager.RemoveQuest(this);
	}

	public List<ElementGroup> GetWatchedGroups()
	{
		List<ElementGroup> list = new List<ElementGroup>();
		foreach (GroupConditionWatcher groupConditionWatcher in groupConditionWatchers)
		{
			list.AddRange(groupConditionWatcher.WatchedGroups);
		}
		return list;
	}

	public void HighlightWatchTarget(bool newHighlight)
	{
		if (QuestTile.State != TileState.placed)
		{
			return;
		}
		foreach (GroupConditionWatcher groupConditionWatcher in groupConditionWatchers)
		{
			groupConditionWatcher.HighlightWatchedGroups(newHighlight);
		}
	}

	public QuestConditionWatcher GetConditionWatcher(int conditionIndex)
	{
		if (conditionIndex < conditionWatchers.Count)
		{
			return conditionWatchers[conditionIndex];
		}
		return null;
	}

	public void HideQuest()
	{
		questLabel.Activate(shouldActivate: false, animate: false);
	}

	public void SetState(QuestWatcherState previousQuestWatcherState)
	{
		if (!previousQuestWatcherState.watching)
		{
			return;
		}
		if (Watching && CurrentQuest.displayType == QuestDisplayType.Flag)
		{
			if (advanceAfterDelayCoroutine != null)
			{
				StopCoroutine(advanceAfterDelayCoroutine);
			}
			ClosingQuestFlag.Show(newShow: false);
			StopWatching();
		}
		CurrentQuestIndex = previousQuestWatcherState.questQueueIndex;
		if (CurrentQuest.displayType == QuestDisplayType.Bubble)
		{
			loadedData = new QuestTileData_002(this, previousQuestWatcherState);
			questLabel.Activate(shouldActivate: true, animate: true);
			StartWatching();
		}
		else if (CurrentQuest.displayType == QuestDisplayType.Flag)
		{
			loadedData = new QuestTileData_002(this, previousQuestWatcherState);
			ClosingQuestFlag.Show(newShow: true);
			StartWatching();
		}
	}

	public void ChangeQuestBubbleScale(float newScale)
	{
		questLabel.ChangeScale(newScale);
	}
}
