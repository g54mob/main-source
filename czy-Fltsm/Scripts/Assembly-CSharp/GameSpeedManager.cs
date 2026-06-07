using System;
using UnityEngine;

public static class GameSpeedManager
{
	public const float FIXED_DELTA_TIME = 0.033f;

	private static GameSpeed _pausedGameSpeed = GameSpeed.One;

	private static GameplaySettings.GameSpeedSettings _gameSpeedSettings;

	private static float _waterTimeScale = 1f;

	private static bool _sendGameSpeedChangedEvent;

	public static GameSpeed GameSpeed { get; private set; } = GameSpeed.One;

	public static GameSpeed ZeroedGameSpeed { get; private set; } = GameSpeed.One;

	public static float UnscaledDeltaTime => Time.unscaledDeltaTime;

	public static float PausableUnscaledDeltaTime
	{
		get
		{
			if (GameSpeed != GameSpeed.Paused)
			{
				return Time.unscaledDeltaTime;
			}
			return 0f;
		}
	}

	public static float FixedScaledDeltaTime => Mathf.Max(Time.fixedDeltaTime, 0.033f);

	public static float WaterDeltaTime => Time.unscaledDeltaTime * _waterTimeScale;

	public static void Reset()
	{
		_pausedGameSpeed = GameSpeed.One;
		SetGameSpeedAndTimeScale(GameSpeed.One);
	}

	public static void Pause()
	{
		if (GameSpeed == GameSpeed.Paused)
		{
			Debug.LogWarning("Unable to pause, GameSpeed.Paused is already set.");
			return;
		}
		_pausedGameSpeed = GameSpeed;
		SetGameSpeedAndTimeScale(GameSpeed.Paused);
	}

	public static void Unpause()
	{
		if (GameSpeed == GameSpeed.Paused)
		{
			SetGameSpeedAndTimeScale(_pausedGameSpeed);
		}
		else
		{
			Debug.LogWarning("Unable to unpause, GameSpeed.Paused it not set.");
		}
	}

	public static void ToggleGameSpeedZero()
	{
		if (GameSpeed != GameSpeed.Paused)
		{
			if (GameSpeed == GameSpeed.Zero)
			{
				SetGameSpeedAndTimeScale(ZeroedGameSpeed);
			}
			else
			{
				SetGameSpeedAndTimeScale(GameSpeed.Zero);
			}
			_sendGameSpeedChangedEvent = true;
		}
	}

	public static void SetGameSpeed(GameSpeed gameSpeedToSet, bool sendEvent = true)
	{
		switch (gameSpeedToSet)
		{
		case GameSpeed.Paused:
			Debug.LogException(new NotSupportedException($"GameSpeedManager.SetGameSpeed no longer supports setting {gameSpeedToSet}, use GameSpeedManager.Pause/Unpause instead."));
			return;
		case GameSpeed.Zero:
			Debug.LogException(new NotSupportedException($"GameSpeedManager.SetGameSpeed no longer supports setting {gameSpeedToSet}, use GameSpeedManager.ToggleGameSpeedZero instead."));
			return;
		}
		if (GameSpeed == GameSpeed.Paused)
		{
			Debug.LogWarning("Setting the GameSpeed while the game is paused is not supported!");
			return;
		}
		SetGameSpeedAndTimeScale(gameSpeedToSet);
		_sendGameSpeedChangedEvent = sendEvent;
	}

	private static void SetGameSpeedAndTimeScale(GameSpeed gameSpeedToSet)
	{
		GameSpeed = gameSpeedToSet;
		_gameSpeedSettings = GameplaySettings.GetGameSpeedSettings(gameSpeedToSet);
		GameSpeed gameSpeed = GameSpeed;
		if ((uint)(gameSpeed - -1) <= 1u)
		{
			Time.timeScale = 0f;
			_waterTimeScale = 0f;
			Time.fixedDeltaTime = 0.033f;
			Physics2D.simulationMode = SimulationMode2D.Script;
			return;
		}
		ZeroedGameSpeed = GameSpeed;
		if (_gameSpeedSettings == null)
		{
			Time.timeScale = 0f;
			_waterTimeScale = 0f;
		}
		else
		{
			Time.timeScale = _gameSpeedSettings.GameplayTimeScale;
			_waterTimeScale = _gameSpeedSettings.WaterTimeScale;
		}
		Time.fixedDeltaTime = 0.033f * Time.timeScale;
		Physics2D.simulationMode = SimulationMode2D.FixedUpdate;
	}

	public static void DispatchChangedEvent()
	{
		if (_sendGameSpeedChangedEvent)
		{
			_sendGameSpeedChangedEvent = false;
			GameSpeedChangedEvent.Dispatch(GameSpeed, ZeroedGameSpeed);
			if (_gameSpeedSettings != null)
			{
				AudioManager.PlayOneShot(_gameSpeedSettings.SelectedEvent);
			}
		}
	}
}
