using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PajamaLlama;
using UnityEngine.Pool;

[Serializable]
public class DialogueTriggers
{
	[Serializable]
	public class PersistentData
	{
		private readonly List<ushort> _triggeredTriggersIDs = new List<ushort>();

		public PersistentData(DialogueTriggers triggers)
		{
			foreach (DialogueTrigger triggeredDialogue in triggers._triggeredDialogues)
			{
				if (triggeredDialogue.TriggerOnlyOnce)
				{
					_triggeredTriggersIDs.Add(triggeredDialogue.UniqueID);
				}
			}
		}

		public void Restore(DialogueTriggers triggers)
		{
			triggers._triggeredDialogues.Clear();
			foreach (ushort id in _triggeredTriggersIDs)
			{
				DialogueTrigger dialogueTrigger = triggers._triggers.Find((DialogueTrigger trigger) => trigger.UniqueID == id);
				if (dialogueTrigger != null)
				{
					triggers._triggeredDialogues.Add(dialogueTrigger);
				}
			}
		}
	}

	[SerializeField]
	[NamedArrayElement(new string[] { "_trigger" })]
	private List<DialogueTrigger> _triggers = new List<DialogueTrigger>();

	private WeakReference<IDialogueContextProvider> _contextProvider;

	private readonly HashSet<DialogueTrigger> _triggeredDialogues = new HashSet<DialogueTrigger>();

	private bool _isListeningToDialogueEndEvent;

	public DialogueTriggers()
	{
	}

	public DialogueTriggers(DialogueTriggers other)
	{
		_triggers = new List<DialogueTrigger>(other._triggers);
		_contextProvider = other._contextProvider;
		_triggeredDialogues = new HashSet<DialogueTrigger>(other._triggeredDialogues);
	}

	~DialogueTriggers()
	{
		Uninitialize();
	}

	public void OnValidate()
	{
		if (_triggers.IsNullOrEmpty())
		{
			return;
		}
		HashSet<ushort> hashSet = CollectionPool<HashSet<ushort>, ushort>.Get();
		foreach (DialogueTrigger trigger in _triggers)
		{
			if (trigger.UniqueID != 0)
			{
				if (!hashSet.Contains(trigger.UniqueID))
				{
					hashSet.Add(trigger.UniqueID);
				}
				else
				{
					trigger.AssignUniqueID(0);
				}
			}
		}
		foreach (DialogueTrigger trigger2 in _triggers)
		{
			if (trigger2.UniqueID == 0)
			{
				ushort num;
				do
				{
					num = (ushort)UnityEngine.Random.Range(1, 65535);
				}
				while (hashSet.Contains(num));
				trigger2.AssignUniqueID(num);
			}
		}
		CollectionPool<HashSet<ushort>, ushort>.Release(hashSet);
	}

	public void Initialize(IDialogueContextProvider contextProvider)
	{
		_contextProvider = new WeakReference<IDialogueContextProvider>(contextProvider);
		if (contextProvider.SupportedTriggers.IsNullOrEmpty())
		{
			return;
		}
		foreach (DialogueTriggerType supportedTrigger in contextProvider.SupportedTriggers)
		{
			if (HasDialogueAssigned(supportedTrigger))
			{
				AttachTriggerEvent(supportedTrigger);
			}
		}
	}

	public void Uninitialize()
	{
		_contextProvider = null;
		if (_isListeningToDialogueEndEvent)
		{
			GameEventDispatcher.RemoveListener(GameEventType.DialogueEnded, OnAgentSelected);
		}
		_isListeningToDialogueEndEvent = false;
		GameEventDispatcher.RemoveListener(GameEventType.AgentSelected, OnAgentSelected);
		GameEventDispatcher.RemoveListener(GameEventType.LandmarkSelected, OnLandmarkSelected);
		GameEventDispatcher.RemoveListener(GameEventType.BuildableSelected, OnBuildableSelected);
		GameEventDispatcher.RemoveListener(GameEventType.RegionEntered, OnLandmarkRegionEntered);
		GameEventDispatcher.RemoveListener(GameEventType.FlotsamItemSalvage, OnFlotsamItemSalvaged);
	}

	public bool TriggerDialogue(DialogueTriggerType trigger, Action<DialogueResponseType, Dialogue> responseCallback = null)
	{
		if (!TryGetDialogueContextOrUninitialize(out var contextProvider))
		{
			return false;
		}
		foreach (DialogueTrigger trigger2 in _triggers)
		{
			if (trigger2.Type != trigger)
			{
				continue;
			}
			if (!_triggeredDialogues.Contains(trigger2))
			{
				if (!_isListeningToDialogueEndEvent)
				{
					GameEventDispatcher.AddListener(GameEventType.DialogueEnded, OnDialogueEnded);
					_isListeningToDialogueEndEvent = true;
				}
				trigger2.Trigger(contextProvider, responseCallback);
				_triggeredDialogues.Add(trigger2);
			}
			return true;
		}
		return false;
	}

	public bool HasDialogueAssigned(DialogueTriggerType trigger)
	{
		IDialogueContextProvider target;
		DialogueTreeProperties dialogueProperties = (_contextProvider.TryGetTarget(out target) ? target.DialogueProperties : null);
		foreach (DialogueTrigger trigger2 in _triggers)
		{
			if (trigger2.Type == trigger)
			{
				return trigger2.ValidateDialogue(dialogueProperties);
			}
		}
		return false;
	}

	public bool TryFindTrigger(ushort uniqueID, out DialogueTrigger dialogueTrigger)
	{
		dialogueTrigger = _triggers.Find((DialogueTrigger trigger) => trigger.UniqueID == uniqueID);
		return dialogueTrigger != null;
	}

	private bool TryGetDialogueContextOrUninitialize(out IDialogueContextProvider contextProvider)
	{
		contextProvider = null;
		if (_contextProvider == null)
		{
			Debug.LogWarning("Trying to trigger a dialogue while DialogueTriggers is uninitialized. If this is caused by the tutorial this warning can be ignored.");
			return false;
		}
		if (_contextProvider.TryGetTarget(out contextProvider))
		{
			return true;
		}
		Debug.LogException(new ArgumentException("Context provider for dialogue triggers is null! Uninitializing DialogueTriggers to avoid further errors."));
		Uninitialize();
		contextProvider = null;
		return false;
	}

	private void AttachTriggerEvent(DialogueTriggerType trigger)
	{
		switch (trigger)
		{
		case DialogueTriggerType.OnAgentSelected:
		case DialogueTriggerType.OnAgentFromPlayerCommunitySelected:
		case DialogueTriggerType.OnOutsiderAgentSelected:
			GameEventDispatcher.AddListener(GameEventType.AgentSelected, OnAgentSelected);
			break;
		case DialogueTriggerType.OnLandmarkSelected:
			GameEventDispatcher.AddListener(GameEventType.LandmarkSelected, OnLandmarkSelected);
			break;
		case DialogueTriggerType.OnBuildableSelected:
			GameEventDispatcher.AddListener(GameEventType.BuildableSelected, OnBuildableSelected);
			break;
		case DialogueTriggerType.OnLandmarkRegionEntered:
			GameEventDispatcher.AddListener(GameEventType.RegionEntered, OnLandmarkRegionEntered);
			break;
		case DialogueTriggerType.OnFlotsamItemSalvaged:
			GameEventDispatcher.AddListener(GameEventType.FlotsamItemSalvage, OnFlotsamItemSalvaged);
			break;
		case DialogueTriggerType.OnObjectivesGroupCompleted:
			break;
		}
	}

	public bool HasActiveDialogue()
	{
		if (GameManager.UIManager.TryGetPanel(PanelID.DialoguePanel, out var panel) && panel.isActiveAndEnabled && panel is DialoguePanel dialoguePanel)
		{
			foreach (DialogueTrigger trigger in _triggers)
			{
				if (dialoguePanel.IsInteractableActiveOrQueued(trigger))
				{
					return true;
				}
			}
		}
		return false;
	}

	private void OnDialogueEnded(GameEvent gameEvent)
	{
		if (!(gameEvent is DialogueGameEvent dialogueGameEvent) || dialogueGameEvent.DialogueProperties == null)
		{
			return;
		}
		DialogueTrigger dialogueTrigger = null;
		bool flag = false;
		foreach (DialogueTrigger triggeredDialogue in _triggeredDialogues)
		{
			if (triggeredDialogue.DialogueProperties == dialogueGameEvent.DialogueProperties)
			{
				if (!triggeredDialogue.TriggerOnlyOnce)
				{
					dialogueTrigger = triggeredDialogue;
				}
				break;
			}
			if (!triggeredDialogue.TriggerOnlyOnce)
			{
				flag = false;
			}
		}
		if (dialogueTrigger != null)
		{
			_triggeredDialogues.Remove(dialogueTrigger);
		}
		if (flag)
		{
			GameEventDispatcher.RemoveListener(GameEventType.DialogueEnded, OnDialogueEnded);
			_isListeningToDialogueEndEvent = false;
		}
	}

	private void OnAgentSelected(GameEvent gameEvent)
	{
		VerifyAgentSelectedContext(gameEvent, DialogueTriggerType.OnAgentSelected);
	}

	private void VerifyAgentSelectedContext(GameEvent gameEvent, DialogueTriggerType triggerType)
	{
		if (TryGetDialogueContextOrUninitialize(out var contextProvider) && gameEvent is AgentEvent agentEvent && contextProvider.IsObjectInContext(agentEvent.Agent, triggerType))
		{
			TriggerDialogue(triggerType);
		}
	}

	private void OnLandmarkSelected(GameEvent gameEvent)
	{
		if (TryGetDialogueContextOrUninitialize(out var contextProvider) && gameEvent is LandmarkNotificationEvent landmarkNotificationEvent && contextProvider.IsObjectInContext(landmarkNotificationEvent.LandmarkBehaviour, DialogueTriggerType.OnLandmarkSelected))
		{
			TriggerDialogue(DialogueTriggerType.OnLandmarkSelected);
		}
	}

	private void OnBuildableSelected(GameEvent gameEvent)
	{
		if (TryGetDialogueContextOrUninitialize(out var contextProvider) && gameEvent is BuildableEvent buildableEvent && contextProvider.IsObjectInContext(buildableEvent.Buildable, DialogueTriggerType.OnBuildableSelected))
		{
			TriggerDialogue(DialogueTriggerType.OnBuildableSelected);
		}
	}

	private void OnLandmarkRegionEntered(GameEvent gameEvent)
	{
		if (!TryGetDialogueContextOrUninitialize(out var contextProvider))
		{
			return;
		}
		IReadOnlyList<LandmarkSpawner> landmarks = GameManager.WorldManager.CurrentRegion.Landmarks;
		if (landmarks.IsNullOrEmpty())
		{
			return;
		}
		foreach (LandmarkSpawner item in landmarks)
		{
			if (contextProvider.IsObjectInContext(item.LandmarkBehaviour, DialogueTriggerType.OnLandmarkRegionEntered))
			{
				TriggerDialogue(DialogueTriggerType.OnLandmarkRegionEntered);
				break;
			}
		}
	}

	private void OnFlotsamItemSalvaged(GameEvent gameEvent)
	{
		if (TryGetDialogueContextOrUninitialize(out var contextProvider) && gameEvent is ItemEvent itemEvent && contextProvider.IsObjectInContext(itemEvent.ItemProperties, DialogueTriggerType.OnFlotsamItemSalvaged))
		{
			TriggerDialogue(DialogueTriggerType.OnFlotsamItemSalvaged);
		}
	}
}
