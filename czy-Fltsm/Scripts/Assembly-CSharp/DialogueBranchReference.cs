using System;
using UnityEngine;

[Serializable]
public struct DialogueBranchReference
{
	public DialogueTreeProperties Dialogue;

	public DialogueBranchType Branch;

	[SerializeField]
	private DialogueNodeProperties _reference;

	public readonly bool TryGetReference(out DialogueNodeProperties reference, DialogueTreeProperties dialogueTreeProperties = null)
	{
		reference = null;
		dialogueTreeProperties = (dialogueTreeProperties ? dialogueTreeProperties : Dialogue);
		if (Branch == DialogueBranchType.None)
		{
			return false;
		}
		if (Branch == DialogueBranchType.Reference)
		{
			reference = _reference;
		}
		else if ((bool)dialogueTreeProperties)
		{
			reference = dialogueTreeProperties.ReturnBranchEntryNode(Branch);
		}
		return true;
	}

	public readonly bool ValidateReference(DialogueTreeProperties dialogueProperties = null)
	{
		if (Branch == DialogueBranchType.Reference)
		{
			return _reference;
		}
		if ((bool)dialogueProperties)
		{
			return dialogueProperties.ReturnBranchEntryNode(Branch);
		}
		if ((bool)Dialogue)
		{
			return Dialogue.ReturnBranchEntryNode(Branch);
		}
		return false;
	}
}
