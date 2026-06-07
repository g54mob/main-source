using System;
using System.Collections.Generic;

public abstract class DialogueNode<PropertiesType> : IDialogueNode where PropertiesType : DialogueNodeProperties
{
	protected readonly PropertiesType _properties;

	private readonly DialogueProgressConditions _progressDialogueConditions;

	private DialoguePanel _dialoguePanel;

	public Action OnProgressConditionsMet { get; set; }

	public DialogueNodeProperties Properties => _properties;

	public virtual IReadOnlyList<DialogueNodeProperties> Branches => _properties.Branches;

	public DialoguePanelOptions DialoguePanelOptions => _properties.DialoguePanelOptions;

	protected DialogueNode(PropertiesType properties)
	{
		_properties = properties;
		_progressDialogueConditions = properties.ProgressDialogueConditions.Clone() as DialogueProgressConditions;
	}

	public virtual void EnterNode(DialoguePanel dialoguePanel, Dialogue dialogue)
	{
		_dialoguePanel = dialoguePanel;
		_progressDialogueConditions.OnNodeEnter();
		DialogueProgressConditions progressDialogueConditions = _progressDialogueConditions;
		progressDialogueConditions.OnConditionsMet = (Action)Delegate.Combine(progressDialogueConditions.OnConditionsMet, new Action(TriggerOnProgressConditionsMet));
		if (_progressDialogueConditions.AutoProgressOnConditionsMet)
		{
			DialogueProgressConditions progressDialogueConditions2 = _progressDialogueConditions;
			progressDialogueConditions2.OnConditionsMet = (Action)Delegate.Combine(progressDialogueConditions2.OnConditionsMet, new Action(ProgressDialogue));
		}
		_properties.TriggerStartDialogueEvents(dialogue);
	}

	public virtual void ExitNode(DialoguePanel dialoguePanel, Dialogue dialogue)
	{
		_progressDialogueConditions.OnNodeExit();
		DialogueProgressConditions progressDialogueConditions = _progressDialogueConditions;
		progressDialogueConditions.OnConditionsMet = (Action)Delegate.Remove(progressDialogueConditions.OnConditionsMet, new Action(TriggerOnProgressConditionsMet));
		DialogueProgressConditions progressDialogueConditions2 = _progressDialogueConditions;
		progressDialogueConditions2.OnConditionsMet = (Action)Delegate.Remove(progressDialogueConditions2.OnConditionsMet, new Action(ProgressDialogue));
		_properties.TriggerEndDialogueEvents(dialogue);
		_dialoguePanel = null;
	}

	public virtual bool CanExitNode(bool isInRepeat)
	{
		if (!isInRepeat && !_progressDialogueConditions.ManualInputIgnoresConditions)
		{
			return AreProgressConditionsMet();
		}
		return true;
	}

	public bool AreProgressConditionsMet()
	{
		if (_progressDialogueConditions != null)
		{
			return _progressDialogueConditions.AreConditionsMet();
		}
		return true;
	}

	protected void ProgressDialogue()
	{
		_dialoguePanel.ProgressDialogue();
	}

	private void TriggerOnProgressConditionsMet()
	{
		if (OnProgressConditionsMet != null)
		{
			OnProgressConditionsMet();
		}
	}
}
