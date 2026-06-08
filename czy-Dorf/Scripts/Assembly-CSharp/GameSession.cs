using System;
using Dorfromantik;
using UnityEngine;

public class GameSession : OverwritingSingleton<GameSession>
{
	[SerializeField]
	private GameMode gameMode;

	private GameModePreset _003CPreset_003Ek__BackingField;

	public GameMode GameMode => gameMode;

	public GameModePreset Preset
	{
		get
		{
			return _003CPreset_003Ek__BackingField;
		}
		private set
		{
			_003CPreset_003Ek__BackingField = value;
		}
	}

	public event Action OnWorldWasSetup;

	public event Action OnGameModeSet;

	public void BroadcastWorldWasSetup()
	{
		PlayerPrefsAccessor.SetInt("LastPlayedGameMode", (int)gameMode.id);
		this.OnWorldWasSetup?.Invoke();
	}

	public void SetGameMode(GameMode targetGameMode)
	{
		gameMode = targetGameMode;
		PlayerPrefsAccessor.SetInt("LastPlayedGameMode", (int)gameMode.id);
		this.OnGameModeSet?.Invoke();
	}
}
