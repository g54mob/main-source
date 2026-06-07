using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using PajamaLlama.Flotsam.Narrative;
using UnityEngine;

public class Quest : IDialogueInteractable, IPersistentReference, IPanelContext, IPage, IComparable<IPage>
{
	public enum State
	{
		NotStarted = 0,
		Started = 1,
		Completed = 2,
		Failed = 3,
		Abandoned = 4
	}

	[Serializable]
	public class PersistentData : PersistentReference<Quest>
	{
		private readonly int _persistentID = -1;

		[OptionalField(VersionAdded = 3)]
		private readonly ushort _questGiverID;

		private readonly State _questState;

		[OptionalField(VersionAdded = 3)]
		private readonly List<QuestVariableBase.IPersistentData> _variables;

		private readonly List<IQuestObjective.IPersistentData> _objectivesData = new List<IQuestObjective.IPersistentData>();

		[OptionalField(VersionAdded = 3)]
		private readonly bool _isWaitingForDelayedStart;

		[OptionalField(VersionAdded = 2)]
		private readonly ReplayableDialogue.PersistentData _replayableDialogue;

		public ushort QuestGiverID => _questGiverID;

		public PersistentData(Quest quest)
			: base(quest)
		{
			_persistentID = GameManager.PersistenceManager.ReturnPropertiesIndex(quest.Properties);
			if (quest.QuestGiver != null)
			{
				_questGiverID = quest.QuestGiver.UniqueID;
			}
			_questState = quest.QuestState;
			_isWaitingForDelayedStart = quest.IsWaitingForDelayedStart;
			if (!quest.Variables.IsNullOrEmpty())
			{
				_variables = new List<QuestVariableBase.IPersistentData>();
				QuestVariableBase[] variables = quest.Variables;
				for (int i = 0; i < variables.Length; i++)
				{
					if (variables[i].TryGetPersistentData(out var persistentData))
					{
						_variables.Add(persistentData);
					}
				}
			}
			if (quest.Objectives != null)
			{
				foreach (IQuestObjective objective in quest.Objectives.Objectives)
				{
					_objectivesData.Add(objective.GetPersistentData());
				}
			}
			_replayableDialogue = ReplayableDialogue.PersistentData.Get(quest._replayableDialogue);
		}

		public override void Restore()
		{
			base.Restore();
			if (TryRestore(out var _))
			{
				StoryManager.RestoreQuest(base.Instance);
			}
		}

		public bool TryRestore(out Quest instance)
		{
			instance = null;
			if (GameManager.PersistenceManager.TryReturnPropertiesReference<QuestProperties>(_persistentID, out var reference))
			{
				base.Instance = new Quest(reference);
				if (!_variables.IsNullOrEmpty())
				{
					foreach (QuestVariableBase.IPersistentData variable in _variables)
					{
						RestoreVariable(variable);
					}
				}
				if (_objectivesData.Count > 0)
				{
					base.Instance.PopulateObjectives();
					base.Instance._objectivesDataToRestore = new List<IQuestObjective.IPersistentData>(_objectivesData);
				}
				else
				{
					base.Instance.Objectives = null;
				}
				base.Instance.QuestState = ((_questState != State.Started) ? _questState : State.NotStarted);
				if (_replayableDialogue != null)
				{
					_replayableDialogue.Restore(base.Instance._replayableDialogue);
				}
				instance = base.Instance;
			}
			return instance != null;
		}

		private void RestoreVariable(QuestVariableBase.IPersistentData persistentData)
		{
			if (base.Instance != null)
			{
				QuestVariableBase[] variables = base.Instance.Variables;
				for (int i = 0; i < variables.Length && !variables[i].TryRestorePersistentData(persistentData); i++)
				{
				}
			}
		}

		public void RestoreReferences()
		{
			if (ActorDescriptor.TryGet<AgentDescriptor>(out var actorDescriptor, _questGiverID))
			{
				base.Instance.QuestGiver = actorDescriptor;
			}
			if ((GameManager.Initialized && _questState == State.Started) || _isWaitingForDelayedStart)
			{
				base.Instance.Start();
			}
			QuestVariableBase[] variables = base.Instance.Variables;
			for (int i = 0; i < variables.Length; i++)
			{
				variables[i].RestoreReferences();
			}
		}
	}

	private readonly ReplayableDialogue _replayableDialogue = new ReplayableDialogue();

	private List<DialogueBranch> _dialogueBranches;

	private List<IQuestObjective.IPersistentData> _objectivesDataToRestore;

	public int PersistentIndex { get; set; } = -1;

	public QuestProperties Properties { get; }

	public virtual DialogueTreeProperties DialogueProperties
	{
		get
		{
			if (!(Properties.DialogueProperties != null))
			{
				if (!(QuestGiver != null) || !(QuestGiver.AgentProfile != null))
				{
					return null;
				}
				return QuestGiver.AgentProfile.DialogueProperties;
			}
			return Properties.DialogueProperties;
		}
	}

	public AgentDescriptor QuestGiver { get; private set; }

	public QuestVariableBase[] Variables { get; private set; }

	public QuestObjectives Objectives { get; private set; }

	public State QuestState { get; private set; }

	public bool IsCompleted => QuestState == State.Completed;

	public bool IsWaitingForDelayedStart { get; private set; }

	public bool Tracked { get; private set; }

	public PanelID PanelID => PanelID.Achievement;

	private bool IsQuest
	{
		get
		{
			if (Properties.QuestType != QuestType.Quest)
			{
				return Properties.QuestType == QuestType.Main;
			}
			return true;
		}
	}

	string IPage.ID => null;

	string IPage.Name => Properties.QuestTitle;

	Sprite IPage.Icon => null;

	string IPage.CompareString => null;

	public Quest(QuestProperties properties)
	{
		Properties = properties;
		Variables = new QuestVariableBase[Properties.Variables.Length];
		for (int i = 0; i < Properties.Variables.Length; i++)
		{
			Variables[i] = Properties.Variables[i].Clone() as QuestVariableBase;
		}
	}

	public Quest(QuestProperties properties, AgentDescriptor questGiver)
		: this(properties)
	{
		QuestGiver = questGiver;
	}

	~Quest()
	{
		Uninitialize();
	}

	public bool TryStart()
	{
		if (QuestState == State.NotStarted)
		{
			StartDialogue(this, Properties.QuestType == QuestType.DistressSignal);
			return true;
		}
		Debug.Log("Unable to try and start quest '" + Properties.name + "'. It was already started");
		return false;
	}

	public IEnumerator DelayedStart(AgentDescriptor questGiver, float delay)
	{
		IsWaitingForDelayedStart = true;
		yield return new WaitForSeconds(delay);
		IsWaitingForDelayedStart = false;
		Start(questGiver);
	}

	public void Start(AgentDescriptor questGiver = null)
	{
		if (!IsWaitingForDelayedStart)
		{
			if (!CanBeStarted())
			{
				Debug.LogException(new Exception($"Quest '{Properties}' is being started, but it has already been {QuestState}."));
			}
			if (QuestGiver == null || questGiver != null)
			{
				QuestGiver = questGiver;
			}
			QuestState = State.Started;
			InitializeDialogueTriggers();
			GameEventDispatcher.AddListener(GameEventType.WorldTileRemoved, OnWorldTileRemoved);
			GameEventDispatcher.AddListener(GameEventType.DialogueBranchConditionsTriggered, OnDialogueBranchConditionsTriggered);
			GameEventDispatcher.AddListener(GameEventType.DialogueStartRequest, OnDialogueStartRequest);
			if (_objectivesDataToRestore == null && TryGetEntryPoint(out var _))
			{
				_replayableDialogue.Start(this);
			}
			else
			{
				StartObjectives();
			}
		}
	}

	public void SetCompleted()
	{
		if (QuestState != State.Completed)
		{
			Uninitialize();
			QuestState = State.Completed;
			if (IsQuest && Properties.DialogueProperties.HasDialogueBranchType(DialogueBranchType.QuestCompleted))
			{
				StartDialogue(this);
			}
			else
			{
				OnQuestCompleted();
			}
		}
	}

	private void OnQuestCompleted()
	{
		if (Properties.ShowQuestCompletePanel)
		{
			GameManager.UIManager.DisplayPanel(this);
		}
		QuestEvent.DispatchQuestUpdated(this);
		QuestEvent.DispatchQuestCompleted(this);
	}

	public void SetFailed()
	{
		if (QuestState != State.Failed)
		{
			Uninitialize();
			QuestVariableBase[] variables = Variables;
			for (int i = 0; i < variables.Length; i++)
			{
				variables[i].Dispose();
			}
			QuestState = State.Failed;
			if (Properties.EndDialogueProperties != null)
			{
				_replayableDialogue.Start(Properties.EndDialogueProperties);
			}
			QuestEvent.DispatchQuestUpdated(this);
			QuestEvent.DispatchQuestFailed(this);
		}
	}

	public void StartTracking()
	{
		if (!Tracked)
		{
			Tracked = true;
			if (StoryManager.TrackedQuest != null)
			{
				StoryManager.TrackedQuest.Tracked = false;
			}
			StoryManager.TrackedQuest = this;
			QuestEvent.Dispatch(GameEventType.QuestTracked, this);
		}
	}

	public void StopTracking()
	{
		if (Tracked)
		{
			if (StoryManager.TrackedQuest == this)
			{
				StoryManager.TrackedQuest = null;
			}
			Tracked = false;
			QuestEvent.Dispatch(GameEventType.QuestTracked, this);
		}
	}

	public void RepeatLastDialogue()
	{
		_replayableDialogue.Replay();
	}

	public bool Validate()
	{
		QuestVariableBase[] variables = Variables;
		for (int i = 0; i < variables.Length; i++)
		{
			if (!variables[i].Validate())
			{
				return false;
			}
		}
		return true;
	}

	private void Uninitialize()
	{
		GameEventDispatcher.RemoveListener(GameEventType.DialogueBranchConditionsTriggered, OnDialogueBranchConditionsTriggered);
		GameEventDispatcher.RemoveListener(GameEventType.DialogueStartRequest, OnDialogueStartRequest);
		GameEventDispatcher.RemoveListener(GameEventType.WorldTileRemoved, OnWorldTileRemoved);
		if (_dialogueBranches != null)
		{
			UninitializeDialogueBranches();
		}
		if (Objectives != null)
		{
			QuestObjectives objectives = Objectives;
			objectives.OnCompleted = (Action)Delegate.Remove(objectives.OnCompleted, new Action(OnObjectivesCompleted));
			QuestObjectives objectives2 = Objectives;
			objectives2.OnObjectiveTimedOut = (Action<IQuestObjective>)Delegate.Remove(objectives2.OnObjectiveTimedOut, new Action<IQuestObjective>(OnObjectiveTimedOut));
			Objectives.Uninitialize();
			Objectives = null;
		}
		QuestVariableBase[] variables = Variables;
		for (int i = 0; i < variables.Length; i++)
		{
			variables[i].ClearReferencingObjectives();
		}
	}

	private void InitializeDialogueTriggers()
	{
		if (PopulateObjectives())
		{
			Objectives.InitializeDialogueTriggers();
		}
	}

	private void StartObjectives()
	{
		if (QuestState != State.Completed && PopulateObjectives())
		{
			QuestObjectives objectives = Objectives;
			objectives.OnCompleted = (Action)Delegate.Combine(objectives.OnCompleted, new Action(OnObjectivesCompleted));
			QuestObjectives objectives2 = Objectives;
			objectives2.OnObjectiveTimedOut = (Action<IQuestObjective>)Delegate.Combine(objectives2.OnObjectiveTimedOut, new Action<IQuestObjective>(OnObjectiveTimedOut));
			if (_objectivesDataToRestore == null)
			{
				Objectives.Start();
			}
			else
			{
				Objectives.Restore(_objectivesDataToRestore);
			}
			_objectivesDataToRestore = null;
			InitializeDialogueBranches();
			if (QuestState != State.Failed)
			{
				QuestEvent.DispatchQuestStarted(this);
			}
		}
		else
		{
			Debug.LogException(new Exception($"Quest '{Properties}' failed to start its objcective!"));
		}
		QuestEvent.DispatchQuestUpdated(this);
	}

	private void OnObjectivesCompleted()
	{
		QuestObjectives objectives = Objectives;
		objectives.OnCompleted = (Action)Delegate.Remove(objectives.OnCompleted, new Action(OnObjectivesCompleted));
		SetCompleted();
	}

	private void OnObjectiveTimedOut(IQuestObjective objective)
	{
		SetFailed();
	}

	private void StartDialogue(IDialogueInteractable dialogueInteractable, bool isRadioMessage = false)
	{
		_replayableDialogue.Start(dialogueInteractable, isRadioMessage);
	}

	private void InitializeDialogueBranches()
	{
		UninitializeDialogueBranches();
		_dialogueBranches = DialogueProperties.EntryBranches.Clone();
		foreach (DialogueBranch dialogueBranch in _dialogueBranches)
		{
			if (!dialogueBranch.TriggerConditions.IsNullOrEmpty())
			{
				dialogueBranch.Initialize();
			}
		}
	}

	private void UninitializeDialogueBranches()
	{
		if (_dialogueBranches != null)
		{
			foreach (DialogueBranch dialogueBranch in _dialogueBranches)
			{
				dialogueBranch.Uninitialize();
			}
		}
		_dialogueBranches = null;
	}

	private void OnDialogueBranchConditionsTriggered(GameEvent gameEvent)
	{
		if (!(gameEvent is DialogueGameEvent dialogueGameEvent) || dialogueGameEvent.SpecificBranchEntryNode == null)
		{
			return;
		}
		DialogueTreeProperties dialogueProperties = DialogueProperties;
		if (dialogueProperties == null)
		{
			return;
		}
		foreach (DialogueBranch entryBranch in dialogueProperties.EntryBranches)
		{
			if (entryBranch.EntryNode == dialogueGameEvent.SpecificBranchEntryNode)
			{
				_replayableDialogue.Start(dialogueProperties, dialogueGameEvent.SpecificBranchEntryNode);
				break;
			}
		}
	}

	private void OnDialogueStartRequest(GameEvent gameEvent)
	{
		if (gameEvent is DialogueGameEvent dialogueGameEvent && dialogueGameEvent.DialogueInteractable == this)
		{
			DialogueNodeProperties entryPoint;
			if (dialogueGameEvent.SpecificBranchEntryNode != null)
			{
				_replayableDialogue.RememberBranchForReplay(dialogueGameEvent.SpecificBranchEntryNode, dialogueGameEvent.DialogueInteractable);
			}
			else if (dialogueGameEvent.DialogueInteractable != this && dialogueGameEvent.DialogueInteractable != null && dialogueGameEvent.DialogueInteractable.TryGetEntryPoint(out entryPoint))
			{
				_replayableDialogue.RememberBranchForReplay(entryPoint, dialogueGameEvent.DialogueInteractable);
			}
		}
	}

	private bool PopulateObjectives()
	{
		if (Objectives == null)
		{
			QuestVariableBase[] variables = Variables;
			for (int i = 0; i < variables.Length; i++)
			{
				variables[i].SetOwningQuest(this);
			}
			Objectives = Properties.Objectives.Clone() as QuestObjectives;
			Objectives.SetOwningQuest(this);
		}
		return Objectives != null;
	}

	private bool CanBeStarted()
	{
		if (QuestState != State.NotStarted)
		{
			if (QuestState == State.Completed)
			{
				return Properties.IsRestartable;
			}
			return false;
		}
		return true;
	}

	public bool HasActiveVisibleObjectives()
	{
		if (IsCompleted || Properties.IsHidden || Objectives == null)
		{
			return false;
		}
		return Objectives.HasVisibleObjectives();
	}

	public void PopulateVisibleObjectives(List<IQuestObjective> visibleObjectives)
	{
		Objectives?.PopulateVisibleObjective(visibleObjectives);
	}

	public T GetVariableValue<T>(int id)
	{
		return GetVariableValue<T>(id);
	}

	public T GetVariableValue<T>(QuestObjectiveBase objective, int id)
	{
		QuestVariableBase[] variables = Variables;
		foreach (QuestVariableBase questVariableBase in variables)
		{
			if (questVariableBase.Id == id)
			{
				return questVariableBase.Get<T>(objective);
			}
		}
		return default(T);
	}

	public bool TryGetVariableValue<T>(int id, out T value) where T : class
	{
		return TryGetVariableValue<T>(null, id, out value);
	}

	public bool TryGetVariableValue<T>(QuestObjectiveBase objective, int id, out T value) where T : class
	{
		QuestVariableBase[] variables = Variables;
		foreach (QuestVariableBase questVariableBase in variables)
		{
			if (questVariableBase.Id == id)
			{
				value = questVariableBase.Get<T>(objective);
				return value != null;
			}
		}
		value = null;
		return false;
	}

	public void SetVariableValue<T>(int id, T value)
	{
		QuestVariableBase[] variables = Variables;
		foreach (QuestVariableBase questVariableBase in variables)
		{
			if (questVariableBase.Id == id)
			{
				questVariableBase.Set(value);
				break;
			}
		}
	}

	public bool TryGetActorDescriptor(DialogueContext.ActorType actorType, out AgentDescriptor actorDescriptor)
	{
		if (actorType == DialogueContext.ActorType.QuestGiver && QuestGiver != null)
		{
			actorDescriptor = QuestGiver;
			return true;
		}
		QuestVariableBase[] variables = Variables;
		for (int i = 0; i < variables.Length; i++)
		{
			if (variables[i] is ActorVariable actorVariable && actorVariable.TryGetActorDescriptor(actorType, out actorDescriptor))
			{
				return true;
			}
		}
		return StoryManager.DialogueContext.TryGetActor(actorType, out actorDescriptor);
	}

	public void OnDialogueResponse(DialogueResponseType response, Dialogue dialogue)
	{
		switch (QuestState)
		{
		case State.NotStarted:
			if (response == DialogueResponseType.Yes || Properties.QuestType == QuestType.DistressSignal)
			{
				StoryManager.StartQuest(this);
			}
			break;
		case State.Started:
			if (response == DialogueResponseType.EndOfDialogue && (Objectives == null || !Objectives.IsStarted))
			{
				StartObjectives();
			}
			break;
		case State.Completed:
			if (response == DialogueResponseType.EndOfDialogue)
			{
				OnQuestCompleted();
			}
			break;
		}
	}

	public bool TryGetEntryPoint(out DialogueNodeProperties entryPoint)
	{
		entryPoint = null;
		if (DialogueProperties == null)
		{
			Debug.LogException(new Exception($"Quest '{Properties}' has now dialogue properties set."));
			return false;
		}
		switch (QuestState)
		{
		case State.NotStarted:
			if (Properties.QuestType == QuestType.DistressSignal)
			{
				entryPoint = DialogueProperties.ReturnBranchEntryNode(DialogueBranchType.DistressSignal);
			}
			else
			{
				entryPoint = DialogueProperties.ReturnBranchEntryNode(DialogueBranchType.QuestGiver);
			}
			break;
		case State.Started:
			entryPoint = DialogueProperties.ReturnBranchEntryNode(DialogueBranchType.QuestAccepted);
			break;
		case State.Completed:
			if (Properties.QuestType != QuestType.DistressSignal)
			{
				entryPoint = DialogueProperties.ReturnBranchEntryNode(DialogueBranchType.QuestCompleted);
			}
			else
			{
				entryPoint = null;
			}
			break;
		default:
			Debug.LogException(new NotImplementedException());
			entryPoint = null;
			break;
		}
		return entryPoint != null;
	}

	public bool TryGetMainSpeaker(out AgentDescriptor mainSpeaker)
	{
		mainSpeaker = QuestGiver;
		return true;
	}

	public int CompareTo(IPage other)
	{
		throw new NotImplementedException();
	}

	private void OnWorldTileRemoved(GameEvent gameEvent)
	{
		QuestVariableBase[] variables = Variables;
		for (int i = 0; i < variables.Length; i++)
		{
			if (!variables[i].Validate())
			{
				SetFailed();
				break;
			}
		}
	}
}
