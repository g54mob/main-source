using System.Collections.Generic;
using UnityEngine;

public abstract class DialogueNodeProperties : ScriptableObject, IDialogueTreeNodeViewable
{
	[SerializeField]
	[Tooltip("Order of branches in this list serves as reverse-priority (index 1 is higher priority than index 0)")]
	private List<DialogueNodeProperties> _branches = new List<DialogueNodeProperties>();

	[SerializeField]
	protected string _name = string.Empty;

	[Header("Responses")]
	[SerializeField]
	private DialogueResponseType _startDialogueResponse;

	[SerializeField]
	private DialogueResponseType _endDialogueResponse;

	[Header("[DEPRECATED] Tutorial")]
	[SerializeReference]
	[SubclassSelector]
	private List<IDialogueCondition> _conditions = new List<IDialogueCondition>();

	[SerializeReference]
	[SubclassSelector]
	[Tooltip("Events to trigger when displaying this sentence")]
	private List<IDialogueEvent> _startDialogueEvents = new List<IDialogueEvent>();

	[SerializeReference]
	[SubclassSelector]
	[Tooltip("Events to trigger when closing this sentence")]
	private List<IDialogueEvent> _endDialogueEvents = new List<IDialogueEvent>();

	[SerializeField]
	[Tooltip("Conditions for the dialogue to be able to progress")]
	private DialogueProgressConditions _progressDialogueConditions = new DialogueProgressConditions();

	[SerializeField]
	private DialoguePanelOptions _dialoguePanelOptions = new DialoguePanelOptions();

	[SerializeField]
	[HideInInspector]
	private string _guid = string.Empty;

	[SerializeField]
	[HideInInspector]
	private Vector2 _position = Vector2.zero;

	Object IDialogueTreeNodeViewable.SerializeTarget => this;

	public string Name => _name;

	public IReadOnlyList<DialogueNodeProperties> Branches => _branches;

	public string Guid => _guid;

	public Vector2 Position => _position;

	public IReadOnlyList<IDialogueCondition> Conditions => _conditions;

	public DialogueProgressConditions ProgressDialogueConditions => _progressDialogueConditions;

	public DialoguePanelOptions DialoguePanelOptions => _dialoguePanelOptions;

	protected abstract string DefaultNodeName { get; }

	public bool AreConditionsMet()
	{
		if (_conditions == null)
		{
			return true;
		}
		foreach (IDialogueCondition condition in _conditions)
		{
			if (!condition.IsMet())
			{
				return false;
			}
		}
		return true;
	}

	public void TriggerStartDialogueEvents(Dialogue dialogue)
	{
		if (dialogue.Interactable != null && _startDialogueResponse != DialogueResponseType.None)
		{
			dialogue.Interactable.OnDialogueResponse(_startDialogueResponse, dialogue);
		}
		TriggerDialogueEvents(_startDialogueEvents, dialogue);
	}

	public void TriggerEndDialogueEvents(Dialogue dialogue)
	{
		if (dialogue.Interactable != null && _endDialogueResponse != DialogueResponseType.None)
		{
			dialogue.Interactable.OnDialogueResponse(_endDialogueResponse, dialogue);
		}
		TriggerDialogueEvents(_endDialogueEvents, dialogue);
	}

	private void TriggerDialogueEvents(List<IDialogueEvent> events, Dialogue dialogue)
	{
		if (events == null)
		{
			return;
		}
		foreach (IDialogueEvent @event in events)
		{
			if (@event != null && (!dialogue.IsInRepeat || @event.ShouldTriggerOnDialogueRepeat))
			{
				@event.TriggerEvent(dialogue);
			}
		}
	}
}
