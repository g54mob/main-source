public class DialogueGameEvent : GameEvent, IPanelContext
{
	public DialogueTreeProperties DialogueProperties { get; private set; }

	public IDialogueInteractable DialogueInteractable { get; private set; }

	public DialogueNodeProperties SpecificBranchEntryNode { get; private set; }

	public float Delay { get; private set; }

	public bool IsNewDialogue { get; private set; }

	public bool IsRepeat { get; private set; }

	public bool IsRadioMessage { get; private set; }

	public bool IsToBeContinued { get; private set; }

	public bool Queue
	{
		get
		{
			if (DialogueInteractable != null)
			{
				return DialogueInteractable.Queue;
			}
			return true;
		}
	}

	PanelID IPanelContext.PanelID => PanelID.DialoguePanel;

	private DialogueGameEvent()
		: base(GameEventType.None)
	{
	}

	public static void DispatchDialogueStartRequest(IDialogueInteractable dialogueInteractable, DialogueNodeProperties specificBranchEntryNode = null, bool isRepeat = false, bool isRadioMessage = false)
	{
		GetInstance(GameEventType.DialogueStartRequest, dialogueInteractable.DialogueProperties, dialogueInteractable, specificBranchEntryNode, dialogueInteractable.Delay, isRepeat, isNewDialogue: true, isRadioMessage).Dispatch();
	}

	public static void DispatchDialogueStartRequest(DialogueTreeProperties dialogueProperties, DialogueNodeProperties specificBranchEntryNode = null, float delay = 0f, bool isRepeat = false, bool isRadioMessage = false)
	{
		GetInstance(GameEventType.DialogueStartRequest, dialogueProperties, null, specificBranchEntryNode, delay, isRepeat, isNewDialogue: true, isRadioMessage).Dispatch();
	}

	public static void DispatchDialogueResumeRequest(Dialogue dialogue, float delay = 0f)
	{
		GetInstance(GameEventType.DialogueStartRequest, dialogue.DialogueProperties, null, null, delay, isRepeat: false, isNewDialogue: false).Dispatch();
	}

	public static void DispatchBranchConditionsTriggered(DialogueNodeProperties specificBranchEntryNode)
	{
		GetInstance(GameEventType.DialogueBranchConditionsTriggered, null, null, specificBranchEntryNode).Dispatch();
	}

	public static void DispatchDialogueEnded(DialogueTreeProperties dialogueProperties, bool isToBeContinued)
	{
		DialogueGameEvent instance = GetInstance(GameEventType.DialogueEnded, dialogueProperties);
		instance.IsToBeContinued = isToBeContinued;
		instance.Dispatch();
	}

	private static DialogueGameEvent GetInstance(GameEventType eventType, DialogueTreeProperties dialogueProperties = null, IDialogueInteractable dialogueInteractable = null, DialogueNodeProperties specificBranchEntryNode = null, float delay = 0f, bool isRepeat = false, bool isNewDialogue = true, bool isRadioMessage = false)
	{
		return new DialogueGameEvent
		{
			EventType = eventType,
			DialogueProperties = dialogueProperties,
			DialogueInteractable = dialogueInteractable,
			SpecificBranchEntryNode = specificBranchEntryNode,
			Delay = delay,
			IsRepeat = isRepeat,
			IsNewDialogue = isNewDialogue,
			IsRadioMessage = isRadioMessage
		};
	}
}
