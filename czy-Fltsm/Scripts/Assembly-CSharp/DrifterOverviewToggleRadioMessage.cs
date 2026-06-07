using TMPro;
using UnityEngine;

public class DrifterOverviewToggleRadioMessage : SceneBehaviour
{
	[SerializeField]
	private TextMeshProUGUI _countText;

	private void Start()
	{
		GameEventDispatcher.AddListener(GameEventType.RadioMessageManagerStateUpdated, OnRadioMessageUpdated);
		GameEventDispatcher.AddListener(GameEventType.RadioMessageReceived, OnRadioMessageUpdated);
		GameEventDispatcher.AddListener(GameEventType.RadioMessageRead, OnRadioMessageUpdated);
		OnRadioMessageUpdated();
	}

	private void OnDestroy()
	{
		GameEventDispatcher.RemoveListener(GameEventType.RadioMessageManagerStateUpdated, OnRadioMessageUpdated);
		GameEventDispatcher.RemoveListener(GameEventType.RadioMessageReceived, OnRadioMessageUpdated);
		GameEventDispatcher.RemoveListener(GameEventType.RadioMessageRead, OnRadioMessageUpdated);
	}

	private void OnRadioMessageUpdated(GameEvent gameEvent = null)
	{
		base.gameObject.SetActive(GameManager.RadioMessagesManager.IsReceivingRadioSignals);
		_countText.gameObject.SetActive(value: false);
	}
}
