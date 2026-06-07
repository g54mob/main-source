using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Tooltip))]
public class ZeroSpeedInteractable : UIInteractable
{
	[SerializeField]
	[Tooltip("Image that indicates if zero speed is enabled or not.")]
	private Image _indicator;

	private bool _enabled;

	protected override void Awake()
	{
		base.Awake();
		_indicator.gameObject.SetActive(_enabled);
		GameEventDispatcher.AddListener(GameEventType.GameSpeedChange, OnGameSpeedChange);
	}

	protected override void OnDestroy()
	{
		base.OnDestroy();
		GameEventDispatcher.RemoveListener(GameEventType.GameSpeedChange, OnGameSpeedChange);
	}

	public override void Interact()
	{
		base.Interact();
		GameSpeedManager.ToggleGameSpeedZero();
	}

	private void OnGameSpeedChange(GameEvent gameEvent)
	{
		_enabled = GameSpeedManager.GameSpeed == GameSpeed.Zero;
		_indicator.gameObject.SetActive(_enabled);
	}
}
