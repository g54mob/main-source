public class DialogueNodePanel : DialogueNode<DialogueNodePanelProperties>
{
	public DialogueNodePanel(DialogueNodePanelProperties properties)
		: base(properties)
	{
	}

	public override void EnterNode(DialoguePanel dialoguePanel, Dialogue dialogue)
	{
		base.EnterNode(dialoguePanel, dialogue);
		if (_properties.HideDialoguePanel && !_properties.ProgressDialogueImmediately && dialoguePanel.IsOpen())
		{
			dialoguePanel.Close();
		}
		switch (_properties.Action)
		{
		case DialogueNodePanelProperties.PanelAction.Open:
			GameManager.UIManager.DisplayPanel(_properties.PanelID);
			if (_properties.ProgressDialogueImmediately)
			{
				ProgressDialogue();
			}
			else
			{
				GameEventDispatcher.AddListener(GameEventType.PanelClosed, OnPanelClosed);
			}
			break;
		case DialogueNodePanelProperties.PanelAction.Close:
			GameManager.UIManager.ClosePanel(_properties.PanelID);
			ProgressDialogue();
			break;
		}
	}

	private void OnPanelClosed(GameEvent gameEvent)
	{
		if (gameEvent is PanelEvent panelEvent && panelEvent.ID == _properties.PanelID && panelEvent.EventType == GameEventType.PanelClosed)
		{
			GameEventDispatcher.RemoveListener(GameEventType.PanelClosed, OnPanelClosed);
			ProgressDialogue();
		}
	}
}
