using UnityEngine;

public class GameStateManager : MonoBehaviour
{
	public enum CharacterState
	{
		DisableInput = -1,
		CharacterMode = 0,
		NPCDialogSequence = 1,
		CharacterRemoveMode = 2,
		Locked = 3,
		BuildingMode = 4,
		MenuOpen = 5,
		ShopMode = 6
	}

	public enum GameState
	{
		TitleScreen = -1,
		GameRunning = 0,
		GamePaused = 1,
		Transition = 2,
		Lock = 3
	}

	[SerializeField]
	private GameState startGameState;

	[SerializeField]
	private CharacterState startCharacterState;

	private CharacterState currentCharacterState;

	private CharacterState previousCharacterState;

	private GameState currentGameState;

	private GameState previousGameState;

	private static GameStateManager instance;

	public void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		else
		{
			Object.Destroy(this);
		}
		Object.DontDestroyOnLoad(instance);
		currentGameState = startGameState;
		currentCharacterState = startCharacterState;
	}

	public static bool IsValidated()
	{
		return instance != null;
	}

	public static GameState GetCurrentGameState()
	{
		return instance.currentGameState;
	}

	public static CharacterState GetCurrentCharacterState()
	{
		return instance.currentCharacterState;
	}

	public static GameState GetPreviousGameState()
	{
		return instance.previousGameState;
	}

	public static CharacterState GetPreviousCharacterState()
	{
		return instance.previousCharacterState;
	}

	public static bool ValidateGameState(GameState gameState)
	{
		return gameState == GetCurrentGameState();
	}

	public static bool ValidateCharacterState(CharacterState characterState)
	{
		return characterState == GetCurrentCharacterState();
	}

	public static bool ValidateAnyCharacterState(CharacterState[] states)
	{
		for (int i = 0; i < states.Length; i++)
		{
			if (states[i] == GetCurrentCharacterState())
			{
				return true;
			}
		}
		return false;
	}

	public static void ChangeGameState(GameState newState)
	{
		instance.previousGameState = instance.currentGameState;
		instance.currentGameState = newState;
		InputManager.SwitchInputState(newState);
	}

	public static void ChangeCharacterState(CharacterState newState)
	{
		instance.previousCharacterState = instance.currentCharacterState;
		instance.currentCharacterState = newState;
		InputManager.SwitchInputState(instance.currentGameState);
		if (newState == CharacterState.MenuOpen || newState == CharacterState.ShopMode)
		{
			SoundManager.PlaySoundOnce("ui_menu_open");
		}
	}
}
