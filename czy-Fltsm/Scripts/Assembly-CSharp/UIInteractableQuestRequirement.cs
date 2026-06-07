public class UIInteractableQuestRequirement : UIInteractableRequirementBase
{
	private void OnEnable()
	{
		GameEventDispatcher.AddListener(GameEventType.QuestStarted, OnQuestEvent);
		GameEventDispatcher.AddListener(GameEventType.QuestUpdated, OnQuestEvent);
		OnQuestEvent();
	}

	private void OnDisable()
	{
		GameEventDispatcher.RemoveListener(GameEventType.QuestStarted, OnQuestEvent);
		GameEventDispatcher.RemoveListener(GameEventType.QuestUpdated, OnQuestEvent);
	}

	private void OnQuestEvent(GameEvent gameEvent = null)
	{
		base.IsMet = ReturnIsMet();
		if (base.IsMet)
		{
			OnDisable();
		}
	}

	public override bool ReturnIsMet()
	{
		return GameManager.UIManager.CanDisplayPanel(PanelID.QuestLogPanel);
	}
}
