using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using PajamaLlama.Flotsam.Narrative;
using UnityEngine;

public class RadioMessagesManager : IDialogueInteractable
{
	[Serializable]
	public class PersistentData
	{
		[OptionalField(VersionAdded = 2)]
		private readonly RadioMessageManagerState _state;

		[OptionalField(VersionAdded = 3)]
		private readonly RadioMessage.PersistentData[] _radioMessages;

		[OptionalField(VersionAdded = 2)]
		private readonly RadioMessage.PersistentData _activeRadioMessage;

		[OptionalField]
		private readonly int _activeRadionMessageDayReceived;

		[OptionalField(VersionAdded = 3)]
		private readonly int _radioBuiltDay;

		[OptionalField(VersionAdded = 2)]
		private readonly List<int> _pendingRadioMessages;

		[OptionalField(VersionAdded = 2)]
		private readonly List<int> _activeRadioMessages;

		[OptionalField(VersionAdded = 2)]
		private readonly List<int> _receivedRadioMessages;

		private readonly List<RadioMessage.PersistentData> _unreadRadioMessages;

		public PersistentData()
		{
			RadioMessagesManager radioMessagesManager = GameManager.RadioMessagesManager;
			if (radioMessagesManager != null)
			{
				_state = radioMessagesManager.State;
				_activeRadioMessage = RadioMessage.GetPersistentData(radioMessagesManager._activeRadioMessage);
				_activeRadionMessageDayReceived = radioMessagesManager._activeRadioMessageDayReceived;
				_radioBuiltDay = radioMessagesManager.RadioBuiltDay;
				_radioMessages = new RadioMessage.PersistentData[radioMessagesManager._radioMessages.Count];
				for (int i = 0; i < _radioMessages.Length; i++)
				{
					_radioMessages[i] = RadioMessage.GetPersistentData(radioMessagesManager._radioMessages[i]);
				}
			}
		}

		public void RestoreReferences()
		{
			RadioMessagesManager radioMessagesManager = GameManager.RadioMessagesManager;
			_ = GameManager.PersistenceManager;
			if (_radioMessages != null)
			{
				RadioMessage.PersistentData[] radioMessages = _radioMessages;
				for (int i = 0; i < radioMessages.Length; i++)
				{
					if (radioMessages[i].TryRestore(out var radioMessage))
					{
						radioMessagesManager.RestoreRadioMessage(radioMessage);
					}
				}
			}
			_activeRadioMessage?.TryRestore(out radioMessagesManager._activeRadioMessage);
			if (GameManager.TimeManager.Days.Count < _activeRadionMessageDayReceived)
			{
				Debug.LogException(new Exception($"A game was restored where the last radio message was received in the future. Current day: {GameManager.TimeManager.Days.Count}, Received Day {_activeRadionMessageDayReceived}"));
				radioMessagesManager._activeRadioMessageDayReceived = 0;
			}
			else
			{
				radioMessagesManager._activeRadioMessageDayReceived = _activeRadionMessageDayReceived;
			}
			if (_radioBuiltDay == 0 && !radioMessagesManager.HasRadioStation())
			{
				radioMessagesManager.RadioBuiltDay = -1;
			}
			else
			{
				radioMessagesManager.RadioBuiltDay = _radioBuiltDay;
			}
			radioMessagesManager.SetState(_state);
		}
	}

	private readonly List<RadioMessage> _radioMessages = new List<RadioMessage>();

	private GameplaySettings _settings;

	private RadioMessage _activeRadioMessage;

	private int _activeRadioMessageDayReceived = -1;

	private bool _regionWasEntered;

	public RadioMessageManagerState State { get; private set; }

	public bool IsReceivingRadioSignals
	{
		get
		{
			if (CanReceiveRadioMessages() && State == RadioMessageManagerState.ReceivingRadioSignals)
			{
				return ReturnPendingRadioMessages().Count > 0;
			}
			return false;
		}
	}

	public DialogueTreeProperties DialogueProperties
	{
		get
		{
			if (!TryGetReceivingDialogue(out var dialogue))
			{
				return null;
			}
			return dialogue.Dialogue;
		}
	}

	public int RadioBuiltDay { get; private set; } = -1;

	public void Initialize()
	{
		Clear();
		_settings = GameManager.Settings.GameplaySettings;
		GameEventDispatcher.AddListener(GameEventType.RegionEntered, OnRegionEntered);
		GameEventDispatcher.AddListener(GameEventType.TransitionedFromMapView, OnTransitionedFromMapView);
		if ((bool)_settings.RadioQuest)
		{
			GameEventDispatcher.AddListener(GameEventType.QuestCompleted, OnQuestCompleted);
		}
		GameEventDispatcher.AddListener(GameEventType.BuildableBuilt, OnUpdateWaitingForRadioStation);
		GameEventDispatcher.AddListener(GameEventType.RadioMessageReceived, OnRadioMessageReceived);
		GameEventDispatcher.AddListener(GameEventType.GameStart, OnActiveRadioMessageEvent);
		GameEventDispatcher.AddListener(GameEventType.AgentAddedToPlayerCommunity, OnActiveRadioMessageEvent);
		GameEventDispatcher.AddListener(GameEventType.QuestUpdated, OnActiveRadioMessageEvent);
	}

	public void Clear()
	{
		State = RadioMessageManagerState.WaitingForRadioStation;
		RadioBuiltDay = -1;
		_radioMessages.Clear();
		_activeRadioMessage = null;
		_activeRadioMessageDayReceived = -1;
		GameEventDispatcher.RemoveListener(GameEventType.RegionEntered, OnRegionEntered);
		GameEventDispatcher.RemoveListener(GameEventType.TransitionedFromMapView, OnTransitionedFromMapView);
		GameEventDispatcher.RemoveListener(GameEventType.QuestCompleted, OnQuestCompleted);
		GameEventDispatcher.RemoveListener(GameEventType.BuildableBuilt, OnUpdateWaitingForRadioStation);
		GameEventDispatcher.RemoveListener(GameEventType.RadioMessageReceived, OnRadioMessageReceived);
		GameEventDispatcher.RemoveListener(GameEventType.GameStart, OnActiveRadioMessageEvent);
		GameEventDispatcher.RemoveListener(GameEventType.AgentAddedToPlayerCommunity, OnActiveRadioMessageEvent);
		GameEventDispatcher.RemoveListener(GameEventType.QuestCompleted, OnActiveRadioMessageEvent);
	}

	public void OnDestroy()
	{
		Clear();
	}

	private IEnumerator UpdateWaitingForRadioStation(float delay)
	{
		yield return new WaitForSeconds(delay);
		OnUpdateWaitingForRadioStation(null);
	}

	private void OnUpdateWaitingForRadioStation(GameEvent gameEvent)
	{
		ReturnPendingRadioMessages();
		if (State == RadioMessageManagerState.WaitingForRadioStation && HasRadioStation() && StoryManager.IsQuestCompleted(_settings.RadioQuest) && HasPendingRadioMessages())
		{
			if (RadioBuiltDay < 0)
			{
				RadioBuiltDay = GameManager.TimeManager.Days.Count;
			}
			SetState((_activeRadioMessageDayReceived >= 0) ? RadioMessageManagerState.WaitingForRadioSignals : RadioMessageManagerState.ReceivingRadioSignals);
		}
	}

	private void OnQuestCompleted(GameEvent gameEvent)
	{
		if (gameEvent is QuestEvent questEvent && questEvent.Quest.Properties == _settings.RadioQuest)
		{
			CoroutineMotor.StartRoutine(UpdateWaitingForRadioStation(_settings.RadioQuestCompletedDelay));
		}
	}

	private void OnRadioMessageReceived(GameEvent gameEvent)
	{
		if (gameEvent is RadioMessageEvent { Message: not null } radioMessageEvent)
		{
			OnRadioMessageReceived(radioMessageEvent.Message);
		}
	}

	private void OnRadioMessageReceived(RadioMessage radioMessage)
	{
		if (_radioMessages.Remove(radioMessage))
		{
			_activeRadioMessage = radioMessage;
			_activeRadioMessage.Trigger();
			_activeRadioMessageDayReceived = _activeRadioMessage.DayReceived;
			SetState(RadioMessageManagerState.ProcessingRadioSignal);
		}
		else if (radioMessage != null)
		{
			string text = ((radioMessage != null) ? radioMessage.Properties.name : "NULL");
			Debug.LogException(new Exception("Unable to removed received radio message '" + text + "'"));
		}
	}

	private void OnActiveRadioMessageEvent(GameEvent gameEvent = null)
	{
		if (State == RadioMessageManagerState.ProcessingRadioSignal)
		{
			if (_activeRadioMessage == null || _activeRadioMessage.IsCompleted())
			{
				SetState(HasRadioStation() ? RadioMessageManagerState.WaitingForRadioSignals : RadioMessageManagerState.WaitingForRadioStation);
			}
			else if (_activeRadioMessage.IsFailed())
			{
				Debug.LogException(new Exception($"Radio message '{_activeRadioMessage.Properties}' has failed, adding it back to pending radio messages."));
				SetState(HasRadioStation() ? RadioMessageManagerState.WaitingForRadioSignals : RadioMessageManagerState.WaitingForRadioStation);
			}
			else
			{
				_activeRadioMessage.EvaluateOutOfRange(GameManager.WorldManager.World.TownheartWorldPosition, _settings.RadioMessageFailDistance);
			}
		}
	}

	private void OnRegionEntered(GameEvent gameEvent)
	{
		_regionWasEntered = CanReceiveRadioMessages();
	}

	private void OnTransitionedFromMapView(GameEvent gameEvent)
	{
		if (_regionWasEntered && CanReceiveRadioMessages())
		{
			OnActiveRadioMessageEvent();
			if (State == RadioMessageManagerState.WaitingForRadioSignals && _settings.RadioMessageDayInterval <= GameManager.TimeManager.Days.Count - _activeRadioMessageDayReceived && HasPendingRadioMessages())
			{
				SetState(RadioMessageManagerState.ReceivingRadioSignals);
			}
		}
		_regionWasEntered = false;
	}

	private void SetState(RadioMessageManagerState state, bool sendEvent = true)
	{
		if (State != state)
		{
			State = state;
			if (IsReceivingRadioSignals && sendEvent && TryGetReceivingDialogue(out var _))
			{
				DialogueGameEvent.DispatchDialogueStartRequest(this);
			}
			if (sendEvent)
			{
				GameEventDispatcher.Dispatch(GameEventType.RadioMessageManagerStateUpdated);
			}
		}
	}

	public List<RadioMessage> ReturnPendingRadioMessages()
	{
		RadioMessageProperties[] array = _settings.ReturnRadioMessages();
		foreach (RadioMessageProperties radioMessageProperties in array)
		{
			if (radioMessageProperties.IsAvailable() && !HasRadioMessage(radioMessageProperties))
			{
				_radioMessages.Insert(0, new RadioMessage(radioMessageProperties));
			}
		}
		return _radioMessages;
	}

	private bool HasRadioStation()
	{
		foreach (Buildable buildable in Community.PlayerCommunity.Buildables)
		{
			if (buildable.BuildPhase == BuildPhase.Finished && IsRadioStation(buildable))
			{
				return true;
			}
		}
		return false;
	}

	private bool IsRadioStation(Buildable buildable)
	{
		if ((bool)_settings)
		{
			return _settings.RadioStations.Contains(buildable.Properties);
		}
		return false;
	}

	public bool CanReceiveRadioMessages()
	{
		if (HasRadioStation() && WorldManager.CanAddNextTile())
		{
			foreach (WorldTileSpawningBlocker spawningBlocker in WorldManager.SpawningBlockers)
			{
				if (spawningBlocker.BlocksRadioMessages())
				{
					return false;
				}
			}
			return true;
		}
		return false;
	}

	private bool HasPendingRadioMessages()
	{
		if (CanReceiveRadioMessages())
		{
			return 0 < ReturnPendingRadioMessages().Count;
		}
		return false;
	}

	private bool HasRadioMessage(RadioMessageProperties properties)
	{
		foreach (RadioMessage radioMessage in _radioMessages)
		{
			if (radioMessage.Properties == properties)
			{
				return true;
			}
		}
		return false;
	}

	private bool TryGetReceivingDialogue(out DialogueBranchReference dialogue)
	{
		foreach (RadioMessage radioMessage in _radioMessages)
		{
			if (radioMessage.TryGetReceivingDialogue(out dialogue))
			{
				return true;
			}
		}
		if (_settings != null)
		{
			dialogue = _settings.RadioMessageReceivingDialogue;
			return true;
		}
		dialogue = default(DialogueBranchReference);
		return false;
	}

	public bool TryGetActiveRadioMessageQuest(out Quest quest)
	{
		if (_activeRadioMessage == null || _activeRadioMessage.IsFailed() || _activeRadioMessage.IsCompleted())
		{
			quest = null;
		}
		else
		{
			quest = _activeRadioMessage.Quest;
		}
		return quest != null;
	}

	public void OnDialogueResponse(DialogueResponseType response, Dialogue dialogue)
	{
	}

	public bool TryGetEntryPoint(out DialogueNodeProperties entryPoint)
	{
		entryPoint = null;
		if (TryGetReceivingDialogue(out var dialogue))
		{
			return dialogue.TryGetReference(out entryPoint);
		}
		return false;
	}

	public bool TryGetMainSpeaker(out AgentDescriptor mainSpeaker)
	{
		if ((bool)_settings && (bool)_settings.RadioTechnician)
		{
			mainSpeaker = _settings.RadioTechnician.GetDescriptor();
			if ((bool)mainSpeaker.Agent && mainSpeaker.Agent.IsAlive && mainSpeaker.Agent.Community == Community.PlayerCommunity)
			{
				return true;
			}
		}
		return StoryManager.DialogueContext.TryGetActor(DialogueContext.ActorType.FirstMate, out mainSpeaker);
	}

	private void RestoreRadioMessage(RadioMessage radioMessage)
	{
		if (radioMessage.Properties.IsAvailable())
		{
			foreach (RadioMessage radioMessage2 in _radioMessages)
			{
				if (radioMessage2.Properties == radioMessage.Properties)
				{
					Debug.LogException(new Exception($"A Duplicate RadioMessage '{radioMessage.Properties}' was persisted."));
					return;
				}
			}
			_radioMessages.Add(radioMessage);
		}
		else
		{
			Debug.LogException(new Exception($"RadioMessage '{radioMessage.Properties}' was persisted, but it it is not available."));
		}
	}
}
