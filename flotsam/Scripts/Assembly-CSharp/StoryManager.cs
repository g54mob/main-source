using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using M4.Session;
using PajamaLlama.Flotsam.Narrative;
using PajamaLlama.Flotsam.Onboarding;
using PajamaLlama.Flotsam.World;
using UnityEngine;

public class StoryManager : SceneBehaviour
{
	[Serializable]
	public class PersistentData
	{
		[OptionalField(VersionAdded = 2)]
		private readonly List<ushort> _activeDistressSignalSenderIDs = new List<ushort>();

		[OptionalField(VersionAdded = 3)]
		private readonly List<Quest.PersistentData> _pendingQuests = new List<Quest.PersistentData>();

		private readonly List<Quest.PersistentData> _questsData = new List<Quest.PersistentData>();

		[OptionalField(VersionAdded = 4)]
		private readonly List<Quest.PersistentData> _restartedQuests = new List<Quest.PersistentData>();

		[OptionalField(VersionAdded = 2)]
		private readonly List<int> _triggeredTutorialNotificationIDs = new List<int>();

		[OptionalField(VersionAdded = 3)]
		private readonly IScenarioPersistentData _scenarioPersistentData;

		private readonly int _currentTutorialIndex = -1;

		public PersistentData()
		{
			StoryManager storyManager = GameManager.StoryManager;
			if (storyManager._activeDistressSignalQuests.Count > 0)
			{
				_activeDistressSignalSenderIDs = new List<ushort>(storyManager._activeDistressSignalQuests.Count);
				foreach (AgentDescriptor key in storyManager._activeDistressSignalQuests.Keys)
				{
					_activeDistressSignalSenderIDs.Add(key.UniqueID);
				}
			}
			foreach (Quest pendingQuest in storyManager._pendingQuests)
			{
				PersistQuest(pendingQuest, _pendingQuests);
			}
			using ListPool<Quest>.List list = ListPool<Quest>.Get();
			list.AddRange(storyManager._activeQuests);
			list.AddRange(storyManager._completedQuests);
			list.AddRange(storyManager._failedQuests);
			foreach (Quest item in list)
			{
				PersistQuest(item, _questsData);
			}
			foreach (Quest restartedQuest in storyManager._restartedQuests)
			{
				PersistQuest(restartedQuest, _restartedQuests);
			}
			storyManager._trigger.PopulateTriggeredTutorials(_triggeredTutorialNotificationIDs);
			if ((bool)storyManager._scenarioInstance)
			{
				_scenarioPersistentData = storyManager._scenarioInstance.GetPersistentData();
			}
		}

		private void PersistQuest(Quest quest, List<Quest.PersistentData> questDataList)
		{
			if (quest == null)
			{
				Debug.LogException(new NullReferenceException("Unable to persist NULL quest reference"));
			}
			else
			{
				questDataList.Add(new Quest.PersistentData(quest));
			}
		}

		public void Restore()
		{
			StoryManager storyManager = GameManager.StoryManager;
			foreach (Quest.PersistentData questsDatum in _questsData)
			{
				questsDatum.Restore();
			}
			RestoreRestartedQuests(storyManager._restartedQuests);
			if (!_triggeredTutorialNotificationIDs.IsNullOrEmpty())
			{
				storyManager._trigger.RestoreTriggeredTutorials(_triggeredTutorialNotificationIDs);
			}
		}

		public void RestoreReferences()
		{
			StoryManager storyManager = GameManager.StoryManager;
			if (_activeDistressSignalSenderIDs != null)
			{
				foreach (ushort activeDistressSignalSenderID in _activeDistressSignalSenderIDs)
				{
					if (ActorDescriptor.TryGet<AgentDescriptor>(out var actorDescriptor, activeDistressSignalSenderID))
					{
						Quest quest = new Quest(storyManager._distressSignalQuest);
						storyManager._activeDistressSignalQuests.Add(actorDescriptor, quest);
						quest.Start(actorDescriptor);
					}
				}
			}
			RestorePendingQuests(storyManager._pendingQuests);
			foreach (Quest.PersistentData questsDatum in _questsData)
			{
				questsDatum.RestoreReferences();
			}
			if (_scenarioPersistentData != null)
			{
				storyManager._scenarioInstance = _scenarioPersistentData.Restore(storyManager._prototypeScenario);
			}
			else
			{
				storyManager.InstantiateScenario(storyManager._prototypeScenario);
			}
		}

		private void RestoreRestartedQuests(List<Quest> restoredQuests)
		{
			if (_restartedQuests == null)
			{
				return;
			}
			foreach (Quest.PersistentData restartedQuest in _restartedQuests)
			{
				if (restartedQuest.TryRestore(out var instance))
				{
					restoredQuests.Add(instance);
				}
			}
		}

		private void RestorePendingQuests(List<Quest> restoredQuests)
		{
			if (_pendingQuests == null)
			{
				return;
			}
			foreach (Quest.PersistentData pendingQuest in _pendingQuests)
			{
				if (ActorDescriptor.TryGet<AgentDescriptor>(out var actorDescriptor, pendingQuest.QuestGiverID))
				{
					restoredQuests.Add(new Quest(actorDescriptor.AgentProfile.Quest, actorDescriptor));
				}
			}
		}
	}

	[Header("Game Start")]
	[Header("Tutorials")]
	[SerializeField]
	private ScenarioBase _tutorialScenario;

	[SerializeField]
	private TutorialTrigger _trigger;

	[Header("Main Narrative")]
	[SerializeField]
	private QuestProperties _distressSignalQuest;

	[SerializeField]
	private ScenarioBase _storyModeScenario;

	[Header("Persistence")]
	[SerializeField]
	[Tooltip("A reference to the PrototypeScenario to restore games that were saved before scenario's were split up (0.9.0e9")]
	private PrototypeScenario _prototypeScenario;

	private readonly List<Quest> _pendingDistressSignals = new List<Quest>();

	private readonly Dictionary<AgentDescriptor, Quest> _activeDistressSignalQuests = new Dictionary<AgentDescriptor, Quest>();

	private readonly List<Quest> _pendingQuests = new List<Quest>();

	private readonly List<Quest> _activeQuests = new List<Quest>();

	private readonly List<Quest> _completedQuests = new List<Quest>();

	private readonly List<Quest> _failedQuests = new List<Quest>();

	private readonly List<Quest> _restartedQuests = new List<Quest>();

	private readonly List<Quest> _logQuests = new List<Quest>();

	private ScenarioBase _scenarioInstance;

	private static Quest _lastStartedQuest = null;

	private bool _started;

	public IReadOnlyList<Quest> ActiveQuests => _activeQuests;

	public static DialogueContext DialogueContext { get; } = new DialogueContext();

	public static int LastRegionScoutedDay { get; private set; }

	public static Quest TrackedQuest { get; set; }

	private void Start()
	{
		DialogueContext.Initialize();
		ScenarioBase successor;
		if (_scenarioInstance == null)
		{
			if (Session.Profile.ActiveRun.IsTutorial && _tutorialScenario != null)
			{
				InstantiateScenario(_tutorialScenario);
			}
			else if (_storyModeScenario != null)
			{
				InstantiateScenario(_storyModeScenario);
			}
		}
		else if (_scenarioInstance.TryGetSuccessor(out successor))
		{
			InstantiateScenario(successor);
		}
		GameEventDispatcher.AddListener(GameEventType.QuestStarted, OnQuestStarted);
		GameEventDispatcher.AddListener(GameEventType.QuestFailed, OnQuestFailed);
		GameEventDispatcher.AddListener(GameEventType.QuestAbandoned, OnQuestAbandoned);
		if ((bool)_scenarioInstance)
		{
			_scenarioInstance.Start();
		}
		else
		{
			Debug.LogException(new Exception("StoryManager could not start scenario, because the scenario is NULL!"));
		}
		StartActiveQuests();
		_started = true;
		GameEventDispatcher.Dispatch(GameEventType.StoryManagerStart);
	}

	private void Update()
	{
		for (int num = _activeQuests.Count - 1; num >= 0; num--)
		{
			Quest quest = _activeQuests[num];
			switch (quest.QuestState)
			{
			case Quest.State.Completed:
				_activeQuests.RemoveAt(num);
				_completedQuests.Add(quest);
				GameEvent.Dispatch(GameEventType.CompletedQuestsUpdated);
				break;
			case Quest.State.Failed:
			case Quest.State.Abandoned:
				_activeQuests.Remove(quest);
				_failedQuests.Add(quest);
				GameEvent.Dispatch(GameEventType.FailedQuestsUpdated);
				break;
			}
		}
		_trigger.Update();
	}

	private void OnDestroy()
	{
		Clear();
		DialogueContext.Uninitialize();
		if ((bool)_scenarioInstance)
		{
			_scenarioInstance.Destroy();
		}
	}

	public void Initialize()
	{
		_pendingQuests.Clear();
		_activeQuests.Clear();
		_completedQuests.Clear();
		_trigger.Initialize();
	}

	private void InstantiateScenario(ScenarioBase scenario)
	{
		if (_scenarioInstance != null)
		{
			_scenarioInstance.Destroy();
		}
		_scenarioInstance = scenario.GetInstance();
	}

	private void Uninitialize()
	{
		GameEventDispatcher.RemoveListener(GameEventType.RegionScouted, OnRegionScouted);
		GameEventDispatcher.RemoveListener(GameEventType.QuestFailed, OnQuestFailed);
		GameEventDispatcher.RemoveListener(GameEventType.QuestAbandoned, OnQuestAbandoned);
	}

	public void Clear()
	{
		TrackedQuest = null;
		_activeDistressSignalQuests.Clear();
		_activeQuests.Clear();
		_completedQuests.Clear();
		DialogueContext.Clear();
		Uninitialize();
		_trigger.Reset();
	}

	protected override void OnGameStart()
	{
	}

	private void StartActiveQuests()
	{
		for (int num = _activeQuests.Count - 1; num >= 0; num--)
		{
			Quest quest = _activeQuests[num];
			Quest.State questState = quest.QuestState;
			if ((uint)questState <= 1u)
			{
				quest.Start();
			}
		}
	}

	private bool HasDistressSignal(AgentDescriptor actorDescriptor)
	{
		foreach (Quest pendingDistressSignal in _pendingDistressSignals)
		{
			if (pendingDistressSignal.QuestGiver == actorDescriptor)
			{
				return true;
			}
		}
		return _activeDistressSignalQuests.ContainsKey(actorDescriptor);
	}

	private void PopulateLogQuests(List<QuestType> questLogTypes)
	{
		_logQuests.Clear();
		PopulateLogQuests(_activeQuests, questLogTypes);
		PopulateLogQuests(_completedQuests, questLogTypes);
	}

	private void PopulateLogQuests(IEnumerable<Quest> quests, List<QuestType> questLogTypes)
	{
		foreach (Quest quest in quests)
		{
			if (questLogTypes.Contains(quest.Properties.QuestType))
			{
				_logQuests.Add(quest);
			}
		}
	}

	private Quest p_StartQuest(QuestProperties questProperties, AgentDescriptor questGiver, float delay)
	{
		if (!_started)
		{
			return null;
		}
		if (p_TryGetQuest(out var quest, questProperties))
		{
			switch (quest.QuestState)
			{
			case Quest.State.Completed:
				if (questProperties.IsRestartable)
				{
					_completedQuests.Remove(quest);
					_restartedQuests.Add(quest);
					quest = new Quest(questProperties);
					break;
				}
				Debug.LogException(new Exception($"Unable to restart Quest '{questProperties}'. Could you have forgotten to toggle the 'Is Restartable' flag on the QuestProperties?"));
				return null;
			default:
				Debug.LogException(new Exception($"Unable to start Quest '{questProperties}' in QuestState.{quest.QuestState}. Not implemented"));
				return null;
			case Quest.State.NotStarted:
				break;
			}
		}
		else
		{
			quest = new Quest(questProperties);
		}
		_activeQuests.AddUnique(quest);
		if (delay > 0f)
		{
			StartCoroutine(quest.DelayedStart(questGiver, delay));
		}
		else
		{
			quest.Start(questGiver);
		}
		return quest;
	}

	private Construction SpawnTownheart()
	{
		Vector3 positionTownheart = GameManager.Settings.SessionSettings.StartingScenario.PositionTownheart;
		Buildable buildable = ((!Session.Profile.ActiveRun.TownheartProperties) ? GameManager.Settings.SessionSettings.StartingScenario.Townheart : Session.Profile.ActiveRun.TownheartProperties.Prefab);
		Buildable buildable2 = Buildable.Place(buildable, positionTownheart, Quaternion.identity, 0, instantPlacement: true);
		if (buildable2.TryReturnBuildableExtendable<MooringPoint>(out var buildableExtendable))
		{
			buildableExtendable.SpawnStartingBoat();
		}
		return buildable2.ReturnExtendable<Construction>();
	}

	public bool IsActiveQuest(QuestProperties questProperties)
	{
		int count = _activeQuests.Count;
		while (0 < count--)
		{
			if (_activeQuests[count].Properties == questProperties)
			{
				return true;
			}
		}
		return false;
	}

	private bool p_TryGetQuest(out Quest quest, QuestProperties properties)
	{
		quest = _pendingQuests.Find((Quest pendingQuest) => pendingQuest.Properties == properties);
		if (quest == null)
		{
			quest = _activeQuests.Find((Quest activeQuest) => activeQuest.Properties == properties);
		}
		if (quest == null)
		{
			quest = _completedQuests.Find((Quest completedQuest) => completedQuest.Properties == properties);
		}
		return quest != null;
	}

	public static void StartScenario(ScenarioBase scenario)
	{
		if (TryGetInstance(out var instance))
		{
			instance.InstantiateScenario(scenario);
			instance._scenarioInstance.Start();
		}
	}

	public static bool StartDistressSignal(AgentDescriptor signalSender)
	{
		if (signalSender.DialogueProperties == null || !signalSender.DialogueProperties.HasDialogueBranchType(DialogueBranchType.DistressSignal) || !TryGetInstance(out var instance) || instance.HasDistressSignal(signalSender))
		{
			return false;
		}
		Quest quest = new Quest(instance._distressSignalQuest, signalSender);
		if (quest.TryStart())
		{
			instance._pendingDistressSignals.Add(quest);
			return true;
		}
		return false;
	}

	public static bool TryStartPendingQuest(Agent agent)
	{
		if (!TryGetInstance(out var instance))
		{
			return false;
		}
		foreach (Quest pendingQuest in instance._pendingQuests)
		{
			if (pendingQuest.QuestGiver == agent.Descriptor)
			{
				pendingQuest.TryStart();
				return true;
			}
		}
		return false;
	}

	public static void StartQuest(Quest quest)
	{
		if (TryGetInstance(out var instance))
		{
			if (instance._pendingQuests.Remove(quest))
			{
				quest.Start(quest.QuestGiver);
				instance._activeQuests.Add(quest);
			}
			else if (instance._pendingDistressSignals.Remove(quest))
			{
				quest.Start(quest.QuestGiver);
				instance._activeDistressSignalQuests.Add(quest.QuestGiver, quest);
			}
		}
	}

	public static Quest StartQuest(QuestProperties questProperties, AgentDescriptor questGiver = null, float delay = 0f)
	{
		if (!TryGetInstance(out var instance))
		{
			return null;
		}
		return instance.p_StartQuest(questProperties, questGiver, delay);
	}

	public static void RestoreQuest(Quest quest)
	{
		if (TryGetInstance(out var instance))
		{
			switch (quest.QuestState)
			{
			case Quest.State.NotStarted:
			case Quest.State.Started:
				instance._activeQuests.Add(quest);
				break;
			case Quest.State.Completed:
				instance._completedQuests.Add(quest);
				break;
			case Quest.State.Failed:
			case Quest.State.Abandoned:
				instance._failedQuests.Add(quest);
				break;
			default:
				Debug.LogException(new NotImplementedException($"Unable to restore quest with Quest.State '{quest.QuestState}'"));
				break;
			}
		}
	}

	public static bool TryGetQuest(QuestProperties properties, out Quest questInstance)
	{
		questInstance = null;
		if (TryGetInstance(out var instance))
		{
			return instance.p_TryGetQuest(out questInstance, properties);
		}
		return false;
	}

	public static bool HasAnyActiveQuest()
	{
		if (TryGetInstance(out var instance))
		{
			return instance._activeQuests.Count > 0;
		}
		return false;
	}

	public static bool IsQuestActiveOrCompleted(QuestProperties questProperties)
	{
		if (TryGetInstance(out var instance))
		{
			foreach (Quest activeQuest in instance._activeQuests)
			{
				if (activeQuest.Properties == questProperties)
				{
					return true;
				}
			}
			foreach (Quest completedQuest in instance._completedQuests)
			{
				if (completedQuest.Properties == questProperties)
				{
					return true;
				}
			}
		}
		return false;
	}

	public static bool IsQuestActive(QuestProperties questProperties)
	{
		if (TryGetInstance(out var instance))
		{
			return instance.IsActiveQuest(questProperties);
		}
		return false;
	}

	public static bool IsQuestCompleted(QuestProperties questProperties)
	{
		if (!TryGetInstance(out var instance) || instance._completedQuests.IsNullOrEmpty())
		{
			return false;
		}
		foreach (Quest completedQuest in instance._completedQuests)
		{
			if (completedQuest.Properties == questProperties)
			{
				return true;
			}
		}
		return false;
	}

	public static void QueueWorldTile(TileGeneratorBase tile, int indexOffset = 0, int minimumIndex = 0)
	{
		if (TryGetScenarioInstance(out var scenario))
		{
			scenario.QueueWorldTile(tile, indexOffset, minimumIndex);
		}
	}

	private static bool TryGetInstance(out StoryManager instance)
	{
		instance = GameManager.StoryManager;
		return instance;
	}

	private static bool TryGetScenarioInstance(out ScenarioBase scenario)
	{
		scenario = (GameManager.StoryManager ? GameManager.StoryManager._scenarioInstance : null);
		return scenario;
	}

	public static bool TryGetLogQuests(out List<Quest> logQuests, List<QuestType> questLogTypes)
	{
		if (TryGetInstance(out var instance))
		{
			instance.PopulateLogQuests(questLogTypes);
			logQuests = instance._logQuests;
			return logQuests.Count > 0;
		}
		logQuests = null;
		return false;
	}

	public static bool IsActiveQuest(Quest quest)
	{
		if (!quest.IsCompleted)
		{
			if (TrackedQuest != null || _lastStartedQuest != quest)
			{
				return TrackedQuest == quest;
			}
			return true;
		}
		return false;
	}

	public static bool TryGetActiveQuest(out Quest quest)
	{
		quest = null;
		if (TryGetInstance(out var _))
		{
			if (TrackedQuest != null && !TrackedQuest.IsCompleted)
			{
				quest = TrackedQuest;
			}
			else
			{
				quest = _lastStartedQuest;
			}
		}
		if (quest != null)
		{
			return !quest.IsCompleted;
		}
		return false;
	}

	public static bool TryGetQuestLogQuest(out Quest quest)
	{
		if (TryGetActiveQuest(out quest))
		{
			return true;
		}
		quest = null;
		if (TryGetInstance(out var instance))
		{
			if (instance._activeQuests.Count > 0)
			{
				List<Quest> activeQuests = instance._activeQuests;
				quest = activeQuests[activeQuests.Count - 1];
			}
			else if (instance._completedQuests.Count > 0)
			{
				List<Quest> completedQuests = instance._completedQuests;
				quest = completedQuests[completedQuests.Count - 1];
			}
		}
		return quest != null;
	}

	private void OnRegionScouted(GameEvent gameEvent)
	{
		LastRegionScoutedDay = GameManager.TimeManager.Days.Count;
	}

	private void OnQuestStarted(GameEvent gameEvent)
	{
		if (gameEvent is QuestEvent questEvent)
		{
			_lastStartedQuest = questEvent.Quest;
			if (_activeQuests.AddUnique(questEvent.Quest))
			{
				_failedQuests.Remove(questEvent.Quest);
				_completedQuests.Remove(questEvent.Quest);
			}
		}
	}

	private void OnQuestFailed(GameEvent gameEvent)
	{
		if (gameEvent is QuestEvent questEvent)
		{
			if (_pendingDistressSignals.Remove(questEvent.Quest))
			{
				Debug.LogWarning(string.Format("Pending distriss signal quest for actor '{0}' failed!", (questEvent.Quest.QuestGiver == null) ? "NULL" : questEvent.Quest.QuestGiver.Name));
			}
			if (questEvent.Quest.QuestGiver != null && _activeDistressSignalQuests.Remove(questEvent.Quest.QuestGiver))
			{
				Debug.LogWarning(string.Format("Active distriss signal quest for actor '{0}' failed!", (questEvent.Quest.QuestGiver == null) ? "NULL" : questEvent.Quest.QuestGiver.Name));
			}
			if (_pendingQuests.Remove(questEvent.Quest))
			{
				Debug.LogWarning($"Pending quest '{questEvent.Quest.Properties}' failed!");
			}
			if (_activeQuests.Remove(questEvent.Quest))
			{
				Debug.LogWarning($"Active quest '{questEvent.Quest.Properties}' failed!");
			}
			_failedQuests.Add(questEvent.Quest);
		}
	}

	private void OnQuestAbandoned(GameEvent gameEvent)
	{
		OnQuestFailed(gameEvent);
	}

	public void EndGame()
	{
		GameManager.UIManager.DisplayPanel(PanelID.GameOver);
	}
}
