using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using I2.Loc;
using PajamaLlama.Attributes;
using PajamaLlama.I2Language;
using UnityEngine;

public abstract class QuestObjectiveBase : IQuestObjective, ICloneable, IDialogueContextProvider, ILocalizationParamsManager
{
	[Serializable]
	public class PersistentData : IQuestObjective.IPersistentData
	{
		[OptionalField]
		private readonly bool _wasActivated;

		[OptionalField]
		private readonly bool _isCompleted;

		[OptionalField]
		private readonly bool _hasTriggeredGroupCompletedEvent;

		public int ObjectiveHashCode { get; }

		public PersistentData(QuestObjectiveBase objective)
		{
			ObjectiveHashCode = objective._uniqueID;
			_wasActivated = objective._wasActivated;
			_isCompleted = objective.IsCompleted();
			_hasTriggeredGroupCompletedEvent = objective._hasTriggeredGroupCompletedEvent;
		}

		public virtual bool TryRestore(IQuestObjective objective)
		{
			if (objective.UniqueID == ObjectiveHashCode && objective is QuestObjectiveBase questObjectiveBase)
			{
				questObjectiveBase._wasActivated = _wasActivated;
				if (_isCompleted)
				{
					questObjectiveBase.SetCompleted(sendEvent: false);
				}
				questObjectiveBase._hasTriggeredGroupCompletedEvent = _hasTriggeredGroupCompletedEvent;
				return true;
			}
			return false;
		}
	}

	[SerializeField]
	protected LocalizedString _description;

	[SerializeField]
	[Wrapper("_localizationParameters")]
	private LocalizationParameters _localizationParameters = new LocalizationParameters();

	[SerializeField]
	private bool _isObjectiveOptional;

	[SerializeField]
	private bool _isHidden;

	[SerializeField]
	[Tooltip("List of Unlockables this objective requires, they will be unlocked when the objective is activated.")]
	private Unlockable[] _requiredUnlockables;

	[SerializeField]
	protected DialogueTriggers _dialogueTriggers = new DialogueTriggers();

	[SerializeField]
	[Tooltip("If there is an OnCompleted dialogue, completed will be set on EndOfDialogue. If for some reason that behaviour needs to be overriden, that can be done here. (None = completed is set when the dialogue is triggered)")]
	private DialogueResponseType _completeOnDialogueResponse = DialogueResponseType.EndOfDialogue;

	[SerializeField]
	[Tooltip("If the objective is not completed within this many days after being started, the quest will fail")]
	private int _daysTimeLimit;

	[SerializeField]
	private WorldTileSpawningBlocker _worldTileSpawningBlocker = new WorldTileSpawningBlocker();

	[SerializeField]
	[HideInInspector]
	private ushort _uniqueID;

	protected readonly List<DialogueTriggerType> _supportedDialogueTriggers = new List<DialogueTriggerType>
	{
		DialogueTriggerType.OnObjectiveShown,
		DialogueTriggerType.OnObjectiveCompleted,
		DialogueTriggerType.OnObjectiveTimedOut
	};

	private bool _wasActivated;

	private bool _isCompleted;

	private bool _hasTriggeredGroupCompletedEvent;

	public Quest Quest { get; protected set; }

	public bool IsActive { get; private set; }

	public virtual bool IsOptional => _isObjectiveOptional;

	public bool IsHidden => _isHidden;

	public virtual int DaysTimeLimit => _daysTimeLimit;

	public ushort UniqueID => _uniqueID;

	DialogueTreeProperties IDialogueContextProvider.DialogueProperties => null;

	IReadOnlyList<DialogueTriggerType> IDialogueContextProvider.SupportedTriggers => _supportedDialogueTriggers;

	public QuestObjectiveBase()
	{
	}

	public QuestObjectiveBase(QuestObjectiveBase other)
	{
		_description = other._description;
		_localizationParameters = other._localizationParameters;
		_isObjectiveOptional = other._isObjectiveOptional;
		_isHidden = other._isHidden;
		_requiredUnlockables = other._requiredUnlockables;
		_dialogueTriggers = new DialogueTriggers(other._dialogueTriggers);
		_daysTimeLimit = other._daysTimeLimit;
		_worldTileSpawningBlocker = new WorldTileSpawningBlocker(other._worldTileSpawningBlocker);
		_uniqueID = other._uniqueID;
		_supportedDialogueTriggers = new List<DialogueTriggerType>(other._supportedDialogueTriggers);
		Quest = other.Quest;
		_isCompleted = other._isCompleted;
		_hasTriggeredGroupCompletedEvent = other._hasTriggeredGroupCompletedEvent;
	}

	public void OnValidate()
	{
		if (_dialogueTriggers != null)
		{
			_dialogueTriggers.OnValidate();
		}
	}

	public virtual void SetActive(bool active)
	{
		IsActive = active;
		if (active)
		{
			if (!_wasActivated)
			{
				_dialogueTriggers.TriggerDialogue(DialogueTriggerType.OnObjectiveActivated);
				_wasActivated = true;
			}
			if (!_requiredUnlockables.IsNullOrEmpty())
			{
				Unlockable[] requiredUnlockables = _requiredUnlockables;
				for (int i = 0; i < requiredUnlockables.Length; i++)
				{
					requiredUnlockables[i].Unlock();
				}
			}
			_worldTileSpawningBlocker.SetQuestObjective(this);
		}
		else
		{
			_worldTileSpawningBlocker.Disable();
		}
	}

	public virtual bool IsCompleted()
	{
		return _isCompleted;
	}

	protected void SetCompleted(bool completed, bool sendEvent = true)
	{
		if (completed != _isCompleted && (!completed || !_dialogueTriggers.TriggerDialogue(DialogueTriggerType.OnObjectiveCompleted, OnObjectiveCompletedTriggerResponse) || _completeOnDialogueResponse == DialogueResponseType.None))
		{
			if (completed)
			{
				SetCompleted(sendEvent: false);
			}
			else
			{
				_isCompleted = false;
			}
			if (sendEvent)
			{
				QuestEvent.DispatchQuestObjectiveUpdatedEvent(this);
			}
		}
	}

	private void SetCompleted(bool sendEvent = true)
	{
		_isCompleted = true;
		Uninitialize();
		if (sendEvent)
		{
			QuestEvent.DispatchQuestObjectiveUpdatedEvent(this);
		}
	}

	private void OnObjectiveCompletedTriggerResponse(DialogueResponseType response, Dialogue dialogue)
	{
		if (_completeOnDialogueResponse != DialogueResponseType.None)
		{
			if (_completeOnDialogueResponse == DialogueResponseType.EndOfDialogue)
			{
				SetCompleted();
			}
			else if (response != DialogueResponseType.EndOfDialogue)
			{
				Debug.LogException(new NotImplementedException($"QuestObjective '{this}' of Quest '{Quest.Properties}' should be completed on dialogue respone {_completeOnDialogueResponse}, but EndOfDialogue was received"));
				SetCompleted();
			}
		}
	}

	public virtual void SetOwningQuest(Quest owningQuest)
	{
		Quest = owningQuest;
	}

	public virtual void Initialize()
	{
		_isCompleted = IsCompleted();
	}

	protected bool InitializeIsCompleted()
	{
		_isCompleted = IsCompleted();
		return _isCompleted;
	}

	public virtual void Uninitialize()
	{
	}

	public virtual void InitializeDialogueTriggers()
	{
		_dialogueTriggers.Initialize(this);
	}

	public virtual void UninitializeDialogueTriggers()
	{
		_dialogueTriggers.Uninitialize();
	}

	public void TriggerDialogue(DialogueTriggerType dialogueTrigger)
	{
		_dialogueTriggers.TriggerDialogue(dialogueTrigger);
	}

	public void AssignUniqueID(ushort id)
	{
		_uniqueID = id;
	}

	public void TriggerObjectivesGroupCompleted()
	{
		if (!_hasTriggeredGroupCompletedEvent)
		{
			_dialogueTriggers.TriggerDialogue(DialogueTriggerType.OnObjectivesGroupCompleted);
			_hasTriggeredGroupCompletedEvent = true;
		}
	}

	public void TriggerShownToPlayer()
	{
		_dialogueTriggers.TriggerDialogue(DialogueTriggerType.OnObjectiveShown);
	}

	public void TriggerTimeOut()
	{
		_dialogueTriggers.TriggerDialogue(DialogueTriggerType.OnObjectiveTimedOut);
	}

	public void AddBlockingSpawner(ISpawner blockingSpawner)
	{
		_worldTileSpawningBlocker.AddBlockingSpawner(blockingSpawner);
	}

	public override string ToString()
	{
		string text;
		if ((string)_description != null)
		{
			LocalizationManager.ParamManagers.Add(this);
			text = _description;
			LocalizationManager.ParamManagers.Remove(this);
		}
		else
		{
			text = GetNonLocalizedDescription();
		}
		string objectiveProgressString = GetObjectiveProgressString();
		if (!objectiveProgressString.IsNullOrEmpty())
		{
			return text + " (" + objectiveProgressString + ")";
		}
		return text;
	}

	protected virtual string GetNonLocalizedDescription()
	{
		return "Missing quest description";
	}

	private string GetObjectiveProgressString()
	{
		if (!TryGetProgressValues(out var currentValue, out var goalValue))
		{
			return string.Empty;
		}
		goalValue = Mathf.Max(1, goalValue);
		return $"{Mathf.Clamp(currentValue, 0, goalValue)}/{goalValue}";
	}

	protected virtual bool TryGetProgressValues(out int currentValue, out int goalValue)
	{
		currentValue = 0;
		goalValue = 0;
		return false;
	}

	public abstract object Clone();

	public bool BlocksSpawning()
	{
		return _worldTileSpawningBlocker.Enabled;
	}

	public bool HasActiveDialogue()
	{
		return _dialogueTriggers.HasActiveDialogue();
	}

	public virtual bool IsObjectInContext(object target, DialogueTriggerType dialogueTriggerType)
	{
		return false;
	}

	public bool TryGetActorDescriptor(DialogueContext.ActorType actorType, out AgentDescriptor actorDescriptor)
	{
		if (Quest != null)
		{
			return Quest.TryGetActorDescriptor(actorType, out actorDescriptor);
		}
		return StoryManager.DialogueContext.TryGetActor(actorType, out actorDescriptor);
	}

	public virtual string GetParameterValue(string param)
	{
		return _localizationParameters.GetParameterValue(param);
	}

	public bool TryFindDialogueTrigger(ushort uniqueID, out DialogueTrigger dialogueTrigger)
	{
		return _dialogueTriggers.TryFindTrigger(uniqueID, out dialogueTrigger);
	}

	public virtual IQuestObjective.IPersistentData GetPersistentData()
	{
		return new PersistentData(this);
	}
}
