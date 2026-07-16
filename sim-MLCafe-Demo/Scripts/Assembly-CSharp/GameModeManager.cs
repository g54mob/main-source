using System;
using UnityEngine;
using UnityEngine.Events;

public class GameModeManager : MonoBehaviour
{
	[SerializeField]
	private GameModeDataTable dataTable;

	[SerializeField]
	private int startGameModeFallback = 1;

	private int gameMode = -1;

	public static UnityEvent<int> OnChangeGameMode = new UnityEvent<int>();

	private static GameModeManager instance;

	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
			gameMode = startGameModeFallback;
			if (GameManager.selectedGameMode == -1)
			{
				GameManager.selectedGameMode = gameMode;
			}
		}
		else
		{
			UnityEngine.Object.Destroy(this);
		}
		SetCurrentGameMode(GameManager.selectedGameMode);
	}

	public static int GetCurrentGameMode()
	{
		return instance.gameMode;
	}

	public static void SetCurrentGameMode(int newMode)
	{
		if (!(instance == null))
		{
			instance.gameMode = newMode;
			OnChangeGameMode.Invoke(newMode);
		}
	}

	public static T GetGameModeValue<T>(string key)
	{
		if (instance == null)
		{
			return (T)Convert.ChangeType(1, typeof(float));
		}
		return instance.dataTable.GetGameModeKeyValue<T>(key, instance.gameMode);
	}
}
