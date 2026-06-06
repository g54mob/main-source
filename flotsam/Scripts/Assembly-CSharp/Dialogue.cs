using System;
using System.Collections.Generic;
using I2.Loc;
using UnityEngine;

public class Dialogue : ILocalizationParamsManager
{
	public Action OnCanProgressDialogue;

	private AgentDescriptor _mainSpeaker;

	private AgentDescriptor _speakerOverride;

	private DialogueContext.ActorType _currentSpeakerOverrideType;

	private IDialogueNode _currentNode;

	public DialogueTreeProperties DialogueProperties { get; }

	public AgentDescriptor CurrentSpeaker
	{
		get
		{
			if (!(_speakerOverride != null))
			{
				return _mainSpeaker;
			}
			return _speakerOverride;
		}
	}

	public AgentDescriptor MainSpeaker => _mainSpeaker;

	public IDialogueNode CurrentNode => _currentNode;

	public DialoguePanelOptions CurrentDialoguePanelOptions
	{
		get
		{
			if (_currentNode == null)
			{
				return null;
			}
			return _currentNode.DialoguePanelOptions;
		}
	}

	public IDialogueInteractable Interactable { get; private set; }

	public bool IsInRepeat { get; private set; }

	public Dialogue(DialogueTreeProperties dialogueProperties)
	{
		DialogueProperties = dialogueProperties;
	}

	public void SetIsRepeat(bool isRepeat)
	{
		IsInRepeat = isRepeat;
	}

	public void RestartDialogue()
	{
		if (_currentNode != null)
		{
			IDialogueNode currentNode = _currentNode;
			currentNode.OnProgressConditionsMet = (Action)Delegate.Remove(currentNode.OnProgressConditionsMet, new Action(TriggerOnProgressConditionsMet));
		}
		_currentNode = null;
		Interactable = null;
	}

	public bool CanProgressDialogue()
	{
		if (_currentNode != null)
		{
			return _currentNode.CanExitNode(IsInRepeat);
		}
		return true;
	}

	public bool ProgressDialogue(DialoguePanel dialoguePanel)
	{
		if (TryProgressInternal(dialoguePanel))
		{
			return true;
		}
		if (_currentNode != null)
		{
			IDialogueNode currentNode = _currentNode;
			currentNode.OnProgressConditionsMet = (Action)Delegate.Remove(currentNode.OnProgressConditionsMet, new Action(TriggerOnProgressConditionsMet));
			_currentNode.ExitNode(dialoguePanel, this);
		}
		_currentNode = null;
		return false;
	}

	public bool PlayDialogueInteractable(IDialogueInteractable interactable, DialoguePanel dialoguePanel, DialogueNodeProperties entryNode = null)
	{
		Interactable = interactable;
		if (entryNode != null || interactable.TryGetEntryPoint(out entryNode))
		{
			return PlaySpecificDialogueBranch(entryNode, dialoguePanel);
		}
		return false;
	}

	public bool PlaySpecificDialogueBranch(DialogueNodeProperties branch, DialoguePanel dialoguePanel)
	{
		if (PlayBranch(branch, dialoguePanel))
		{
			return true;
		}
		if (_currentNode != null)
		{
			IDialogueNode currentNode = _currentNode;
			currentNode.OnProgressConditionsMet = (Action)Delegate.Remove(currentNode.OnProgressConditionsMet, new Action(TriggerOnProgressConditionsMet));
			_currentNode.ExitNode(dialoguePanel, this);
		}
		_currentNode = null;
		return false;
	}

	public bool TryProgressToPlayerChoices(DialoguePanel dialoguePanel)
	{
		return TryProgressInternal(dialoguePanel, typeof(DialogueNodePlayerChoicesProperties));
	}

	private bool TryProgressInternal(DialoguePanel dialoguePanel, Type nodeTypeRestriction = null)
	{
		if (TryGetPlayableBranch(out var branchNodeProperties, nodeTypeRestriction))
		{
			return PlayBranch(branchNodeProperties, dialoguePanel);
		}
		return false;
	}

	private bool PlayBranch(DialogueNodeProperties branchNodeProperties, DialoguePanel dialoguePanel)
	{
		if (_currentNode != null)
		{
			IDialogueNode currentNode = _currentNode;
			currentNode.OnProgressConditionsMet = (Action)Delegate.Remove(currentNode.OnProgressConditionsMet, new Action(TriggerOnProgressConditionsMet));
			_currentNode.ExitNode(dialoguePanel, this);
		}
		_currentNode = DialogueNodeFactory.GetNode(branchNodeProperties);
		AcquireSpeakerOverride();
		_currentNode.EnterNode(dialoguePanel, this);
		if (!IsInRepeat && branchNodeProperties.ProgressDialogueConditions != null && branchNodeProperties.ProgressDialogueConditions.SkipNodeIfConditionsAlreadyMet && _currentNode.AreProgressConditionsMet())
		{
			return ProgressDialogue(dialoguePanel);
		}
		IDialogueNode currentNode2 = _currentNode;
		currentNode2.OnProgressConditionsMet = (Action)Delegate.Combine(currentNode2.OnProgressConditionsMet, new Action(TriggerOnProgressConditionsMet));
		return true;
	}

	public bool IsDialogueOver()
	{
		return _currentNode == null;
	}

	public bool IsNextNodePlayerChoices()
	{
		if (TryGetNextBranches(out var branches))
		{
			foreach (DialogueNodeProperties item in branches)
			{
				if (item is DialogueNodePlayerChoicesProperties)
				{
					return true;
				}
			}
		}
		return false;
	}

	private bool TryGetNextBranches(out IReadOnlyList<DialogueNodeProperties> branches)
	{
		branches = ((_currentNode == null) ? DialogueProperties.Branches : _currentNode.Branches);
		return branches != null;
	}

	private bool TryGetPlayableBranch(out DialogueNodeProperties branchNodeProperties, Type nodeTypeRestriction = null)
	{
		if (TryGetNextBranches(out var branches))
		{
			for (int num = branches.Count - 1; num >= 0; num--)
			{
				DialogueNodeProperties dialogueNodeProperties = branches[num];
				if ((nodeTypeRestriction == null || dialogueNodeProperties.GetType().IsAssignableFrom(nodeTypeRestriction)) && dialogueNodeProperties.AreConditionsMet())
				{
					branchNodeProperties = dialogueNodeProperties;
					return true;
				}
			}
		}
		branchNodeProperties = null;
		return false;
	}

	public void AcquireMainSpeaker(IDialogueInteractable interactable)
	{
		Interactable = null;
		if (interactable == null || !interactable.TryGetMainSpeaker(out _mainSpeaker))
		{
			DialogueContext.ActorType actorType = ((DialogueProperties.Speaker == DialogueContext.ActorType.None) ? DialogueContext.ActorType.FirstMate : DialogueProperties.Speaker);
			StoryManager.DialogueContext.TryGetActor(actorType, out _mainSpeaker);
		}
	}

	private void AcquireSpeakerOverride()
	{
		DialogueContext.ActorType actorType = ((_currentNode != null && _currentNode.DialoguePanelOptions != null) ? _currentNode.DialoguePanelOptions.SpeakerOverride : DialogueContext.ActorType.None);
		if (actorType == _currentSpeakerOverrideType)
		{
			return;
		}
		_speakerOverride = null;
		if (actorType != DialogueContext.ActorType.None && !TryGetActorDescriptor(actorType, out _speakerOverride))
		{
			Debug.LogException(new MissingReferenceException($"Could not find a speaker override of type {actorType} for current dialogue ({DialogueProperties})!"));
		}
		_currentSpeakerOverrideType = actorType;
		if (_mainSpeaker == null)
		{
			if (_speakerOverride != null)
			{
				_mainSpeaker = _speakerOverride;
				return;
			}
			Debug.LogException(new MissingReferenceException($"Could not find a speaker of type {DialogueProperties.Speaker} for current dialogue ({DialogueProperties})! Falling back to {DialogueContext.ActorType.FirstMate} instead."));
			_mainSpeaker = StoryManager.DialogueContext.GetActor(DialogueContext.ActorType.FirstMate);
		}
	}

	private bool TryGetActorDescriptor(DialogueContext.ActorType actorType, out AgentDescriptor actorDescriptor)
	{
		if (Interactable == null)
		{
			return StoryManager.DialogueContext.TryGetActor(actorType, out actorDescriptor);
		}
		return Interactable.TryGetActorDescriptor(actorType, out actorDescriptor);
	}

	private void TriggerOnProgressConditionsMet()
	{
		if (OnCanProgressDialogue != null)
		{
			OnCanProgressDialogue();
		}
	}

	string ILocalizationParamsManager.GetParameterValue(string Param)
	{
		switch (Param)
		{
		case "NAME":
		case "CURRENT_SPEAKER":
			if (CurrentSpeaker != null)
			{
				return CurrentSpeaker.Name;
			}
			break;
		case "MAIN_SPEAKER":
			if (MainSpeaker != null)
			{
				return MainSpeaker.Name;
			}
			break;
		}
		return null;
	}
}
