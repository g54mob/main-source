using UnityEngine;

public class RadioSignalEffect : MonoBehaviour
{
	private Buildable _buildable;

	private void Awake()
	{
		_buildable = GetComponentInParent<Buildable>(includeInactive: true);
		if (_buildable == null)
		{
			base.gameObject.SetActive(value: false);
			return;
		}
		OnRadioMessageManagerStateUpdated();
		GameEventDispatcher.AddListener(GameEventType.RadioMessageManagerStateUpdated, OnRadioMessageManagerStateUpdated);
	}

	private void OnDestroy()
	{
		GameEventDispatcher.RemoveListener(GameEventType.RadioMessageManagerStateUpdated, OnRadioMessageManagerStateUpdated);
	}

	private void OnRadioMessageManagerStateUpdated(GameEvent gameEvent = null)
	{
		base.gameObject.SetActive((bool)_buildable && _buildable.BuildPhase == BuildPhase.Finished && GameManager.RadioMessagesManager.IsReceivingRadioSignals);
	}
}
