using PajamaLlama.Utilities;

public class DialogueNodeEmpty : DialogueNode<DialogueNodeEmptyProperties>
{
	public DialogueNodeEmpty(DialogueNodeEmptyProperties properties)
		: base(properties)
	{
	}

	public override void EnterNode(DialoguePanel dialoguePanel, Dialogue dialogue)
	{
		base.EnterNode(dialoguePanel, dialogue);
		if (_properties.HideDialoguePanel)
		{
			if (dialoguePanel.IsOpen())
			{
				dialoguePanel.Close();
			}
		}
		else if (_properties.ProgressDialogue)
		{
			FinalUpdate.RegisterOneShot(base.ProgressDialogue);
		}
	}
}
