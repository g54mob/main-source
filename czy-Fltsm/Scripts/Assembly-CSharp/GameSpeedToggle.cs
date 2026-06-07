using UnityEngine;

[RequireComponent(typeof(Tooltip))]
public class GameSpeedToggle : UIInteractableToggle
{
	[Header("GameSpeed")]
	[SerializeField]
	private GameSpeed _gameSpeed = GameSpeed.One;

	protected override void Awake()
	{
		base.Awake();
		GameEventDispatcher.AddListener(GameEventType.GameSpeedChange, OnGameSpeedChange);
	}

	protected override void OnDestroy()
	{
		base.OnDestroy();
		GameEventDispatcher.RemoveListener(GameEventType.GameSpeedChange, OnGameSpeedChange);
	}

	public void SetGameSpeed(bool enabled)
	{
		if (!enabled)
		{
			if (GameSpeedManager.GameSpeed == GameSpeed.Zero && GameSpeedManager.ZeroedGameSpeed == _gameSpeed)
			{
				GameSpeedManager.ToggleGameSpeedZero();
			}
		}
		else if (_gameSpeed == GameSpeed.Zero)
		{
			GameSpeedManager.ToggleGameSpeedZero();
		}
		else
		{
			GameSpeedManager.SetGameSpeed(_gameSpeed);
		}
	}

	public override void Toggle()
	{
		Toggle(toggled: true);
	}

	public override void Toggle(bool toggled, bool sendEvent = false)
	{
		base.Toggle(toggled);
		SetGameSpeed(toggled);
	}

	private void OnGameSpeedChange(GameEvent gameEvent)
	{
		if (gameEvent is GameSpeedChangedEvent { GameSpeed: not GameSpeed.Paused } gameSpeedChangedEvent)
		{
			base.Toggle(gameSpeedChangedEvent.GameSpeed == _gameSpeed || gameSpeedChangedEvent.ZeroedGameSpeed == _gameSpeed);
		}
	}
}
