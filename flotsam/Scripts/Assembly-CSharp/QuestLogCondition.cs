public class QuestLogCondition : SceneBehaviour
{
	private void Start()
	{
		OnQuestEvent();
		GameEventDispatcher.AddListener(GameEventType.QuestStarted, OnQuestEvent);
		GameEventDispatcher.AddListener(GameEventType.QuestUpdated, OnQuestEvent);
	}

	private void OnDestroy()
	{
		GameEventDispatcher.RemoveListener(GameEventType.QuestStarted, OnQuestEvent);
		GameEventDispatcher.RemoveListener(GameEventType.QuestUpdated, OnQuestEvent);
	}

	private void OnQuestEvent(GameEvent gameEvent = null)
	{
		base.gameObject.SetActive(GameManager.UIManager.CanDisplayPanel(PanelID.QuestLogPanel));
	}
}
