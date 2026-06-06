using System;
using System.Collections.Generic;

public interface IDialogueNode
{
	Action OnProgressConditionsMet { get; set; }

	DialogueNodeProperties Properties { get; }

	IReadOnlyList<DialogueNodeProperties> Branches { get; }

	DialoguePanelOptions DialoguePanelOptions { get; }

	void EnterNode(DialoguePanel dialoguePanel, Dialogue dialogue);

	void ExitNode(DialoguePanel dialoguePanel, Dialogue dialogue);

	bool CanExitNode(bool isInRepeat);

	bool AreProgressConditionsMet();
}
