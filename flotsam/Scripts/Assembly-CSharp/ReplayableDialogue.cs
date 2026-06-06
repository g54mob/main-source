using System;

public class ReplayableDialogue : IDialogueInteractable
{
	[Serializable]
	public class PersistentData
	{
		private int _dialoguePropertiesId;

		private ushort _entryNodeBranchId;

		private ushort _mainSpeakerId;

		private bool _isRadioMessage;

		private PersistentData(ReplayableDialogue replayableDialogue)
		{
			_dialoguePropertiesId = replayableDialogue._dialogueProperties.GetPersistentIndex();
			_entryNodeBranchId = (ushort)((replayableDialogue._entryNodeBranch != null) ? replayableDialogue._entryNodeBranch.UniqueID : 0);
			_mainSpeakerId = (ushort)((replayableDialogue._mainSpeaker != null) ? replayableDialogue._mainSpeaker.UniqueID : 0);
			_isRadioMessage = replayableDialogue.IsRadioMessage;
		}

		public static PersistentData Get(ReplayableDialogue replayableDialogue)
		{
			if (replayableDialogue != null && replayableDialogue._dialogueProperties.TryGetPersistentIndex(out var _))
			{
				return new PersistentData(replayableDialogue);
			}
			return null;
		}

		public void Restore(ReplayableDialogue replayableDialogue)
		{
			if (_dialoguePropertiesId >= 0 && GameManager.PersistenceManager.TryReturnPropertiesReference<DialogueTreeProperties>(_dialoguePropertiesId, out var reference))
			{
				replayableDialogue._dialogueProperties = reference;
				replayableDialogue._entryNodeBranch = reference.ReturnBranch(_entryNodeBranchId);
				if (replayableDialogue._entryNodeBranch != null)
				{
					replayableDialogue._entryNode = replayableDialogue._entryNodeBranch.EntryNode;
				}
				if (ActorDescriptor.TryGet<AgentDescriptor>(out var actorDescriptor, _mainSpeakerId))
				{
					replayableDialogue._mainSpeaker = actorDescriptor;
				}
				replayableDialogue.IsRadioMessage = _isRadioMessage;
				replayableDialogue.IsReplayable = replayableDialogue.IsNodeReplayable(replayableDialogue._entryNode);
			}
		}
	}

	private DialogueTreeProperties _dialogueProperties;

	private DialogueNodeProperties _entryNode;

	private DialogueBranch _entryNodeBranch;

	private AgentDescriptor _mainSpeaker;

	private IDialogueInteractable _interactable;

	public DialogueTreeProperties DialogueProperties => _dialogueProperties;

	public bool IsRadioMessage { get; private set; }

	public bool IsReplayable { get; private set; }

	public void Start(IDialogueInteractable interactable, bool isRadioMessage = false)
	{
		_dialogueProperties = interactable.DialogueProperties;
		_interactable = interactable;
		_interactable.TryGetEntryPoint(out _entryNode);
		_interactable.TryGetMainSpeaker(out _mainSpeaker);
		IsRadioMessage = isRadioMessage;
		Start();
	}

	public void Start(DialogueTreeProperties dialogueProperties, DialogueNodeProperties entryPoint = null)
	{
		_dialogueProperties = dialogueProperties;
		_interactable = null;
		_entryNode = entryPoint;
		_mainSpeaker = null;
		IsRadioMessage = false;
		if ((bool)_entryNode)
		{
			_dialogueProperties.ReturnBranch(_entryNode);
		}
		Start();
	}

	public void RememberBranchForReplay(DialogueNodeProperties branch, IDialogueInteractable interactable, bool isRadioMessage = false)
	{
		_entryNode = branch;
		_dialogueProperties = interactable.DialogueProperties;
		_interactable = interactable;
		_interactable.TryGetEntryPoint(out _entryNode);
		_interactable.TryGetMainSpeaker(out _mainSpeaker);
		_entryNodeBranch = _dialogueProperties.ReturnBranch(_entryNode);
		IsRadioMessage = isRadioMessage;
		IsReplayable = IsNodeReplayable(_entryNode);
	}

	public void Replay()
	{
		if (IsReplayable)
		{
			_interactable = null;
			DialogueGameEvent.DispatchDialogueStartRequest(this, _entryNode, isRepeat: true, IsRadioMessage);
		}
	}

	private void Start()
	{
		_entryNodeBranch = _dialogueProperties.ReturnBranch(_entryNode);
		IsReplayable = IsNodeReplayable(_entryNode);
		DialogueGameEvent.DispatchDialogueStartRequest(_interactable ?? this, _entryNode, IsRadioMessage);
	}

	public void OnDialogueResponse(DialogueResponseType response, Dialogue dialogue)
	{
		_interactable?.OnDialogueResponse(response, dialogue);
	}

	public bool TryGetEntryPoint(out DialogueNodeProperties entryPoint)
	{
		entryPoint = _entryNode;
		return entryPoint != null;
	}

	public bool TryGetMainSpeaker(out AgentDescriptor mainSpeaker)
	{
		mainSpeaker = _mainSpeaker;
		return mainSpeaker != null;
	}

	private bool IsNodeReplayable(DialogueNodeProperties dialogueNode)
	{
		if (dialogueNode == null || !(dialogueNode is DialogueNodeSentenceProperties))
		{
			return false;
		}
		foreach (DialogueNodeProperties branch in dialogueNode.Branches)
		{
			if (!IsNodeReplayable(branch))
			{
				return false;
			}
		}
		return true;
	}
}
