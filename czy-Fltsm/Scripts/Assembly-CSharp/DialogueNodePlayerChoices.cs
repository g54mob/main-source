using System.Collections.Generic;

public class DialogueNodePlayerChoices : DialogueNode<DialogueNodePlayerChoicesProperties>
{
	private int _playerChoiceIndex = -1;

	public override IReadOnlyList<DialogueNodeProperties> Branches
	{
		get
		{
			if (_playerChoiceIndex != -1)
			{
				return new List<DialogueNodeProperties>(1) { _properties.Choices[_playerChoiceIndex].Branch };
			}
			return _properties.Branches;
		}
	}

	public DialogueNodePlayerChoices(DialogueNodePlayerChoicesProperties properties)
		: base(properties)
	{
	}

	public override void EnterNode(DialoguePanel dialoguePanel, Dialogue dialogue)
	{
		base.EnterNode(dialoguePanel, dialogue);
		dialoguePanel.DisplayPlayerChoiceButtons(_properties.Choices, this);
	}

	public override void ExitNode(DialoguePanel dialoguePanel, Dialogue dialogue)
	{
		base.ExitNode(dialoguePanel, dialogue);
		_playerChoiceIndex = -1;
		dialoguePanel.ClearPlayerChoiceButtons();
	}

	public void Choose(int choiceIndex)
	{
		_playerChoiceIndex = choiceIndex;
		ProgressDialogue();
	}

	public override bool CanExitNode(bool isInRepeat)
	{
		if (_playerChoiceIndex != -1)
		{
			return base.CanExitNode(isInRepeat);
		}
		return false;
	}
}
