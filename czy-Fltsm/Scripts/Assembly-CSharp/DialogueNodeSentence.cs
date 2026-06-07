public class DialogueNodeSentence : DialogueNode<DialogueNodeSentenceProperties>
{
	public DialogueNodeSentence(DialogueNodeSentenceProperties properties)
		: base(properties)
	{
	}

	public override void EnterNode(DialoguePanel dialoguePanel, Dialogue dialogue)
	{
		base.EnterNode(dialoguePanel, dialogue);
		if (!dialoguePanel.IsOpen())
		{
			DialogueGameEvent.DispatchDialogueResumeRequest(dialogue);
		}
		dialoguePanel.SetDialogueText(_properties.Text);
	}
}
