using System;

public class DialogueNodeDialogPopUp : DialogueNode<DialogueNodeDialogPopUpProperties>
{
	public DialogueNodeDialogPopUp(DialogueNodeDialogPopUpProperties properties)
		: base(properties)
	{
	}

	public override void EnterNode(DialoguePanel dialoguePanel, Dialogue dialogue)
	{
		base.EnterNode(dialoguePanel, dialogue);
		if (_properties.HideDialoguePanel && dialoguePanel.IsOpen())
		{
			dialoguePanel.Close();
		}
		if (_properties.IsInputDialog ? PopUpDialog.Instance.TryPopUpInput(_properties.PopUpProperties) : PopUpDialog.Instance.TryOpenPopUpDialog(_properties.PopUpProperties))
		{
			PopUpDialog instance = PopUpDialog.Instance;
			instance.OnPopUpClosed = (Action)Delegate.Combine(instance.OnPopUpClosed, new Action(OnPopUpClosed));
			return;
		}
		throw new NotImplementedException($"Failed to open popup {_properties.PopUpProperties} for some reason :(");
	}

	private void OnPopUpClosed()
	{
		PopUpDialog instance = PopUpDialog.Instance;
		instance.OnPopUpClosed = (Action)Delegate.Remove(instance.OnPopUpClosed, new Action(OnPopUpClosed));
		ProgressDialogue();
	}
}
