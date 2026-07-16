using System;
using Lexone.UnityTwitchChat;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public enum PlayMode
	{
		TitleScreen = 0,
		Game = 1
	}

	public PlayMode startPlayMode;

	[SerializeField]
	private string musicTitleScreen;

	[SerializeField]
	private string musicDefaultInGame;

	private static GameManager instance;

	public static UnityEvent OnStartGame = new UnityEvent();

	public static UnityEvent OnNewGame = new UnityEvent();

	public static int selectedGameMode = -1;

	public void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		else
		{
			UnityEngine.Object.Destroy(this);
		}
		UnityEngine.Object.DontDestroyOnLoad(instance);
	}

	public void Start()
	{
		SceneManager.sceneLoaded += OpenScene;
		GameStateManager.ChangeCharacterState(GameStateManager.CharacterState.MenuOpen);
		MouseCursorInteraction.UpdateCursorState();
		PlayMode playMode = startPlayMode;
		if (playMode != PlayMode.TitleScreen && playMode == PlayMode.Game)
		{
			SetGameScreen();
		}
	}

	private void OpenScene(Scene arg0, LoadSceneMode arg1)
	{
		EnterScene();
	}

	public static void StartNewGame(int mode)
	{
		GameStateManager.ChangeCharacterState(GameStateManager.CharacterState.DisableInput);
		MouseCursorInteraction.UpdateCursorState();
		selectedGameMode = mode;
		TransitionToScene(1);
		new GameObject("GameDataHandler").AddComponent<GameDataSceneHandler>().WriteData("");
		OnStartGame.Invoke();
	}

	public static void StartLastGame()
	{
		SaveFileMeta meta = DataPersistenceManager.LoadSaveFileMeta();
		GameDataPreview gameDataPreview = meta.files.Find((GameDataPreview x) => x.fileName == meta.lastPlayedFile);
		if (DataPersistenceManager.IsGameVersionCompatible(gameDataPreview.version))
		{
			StartExistingGame(meta.lastPlayedFile, gameDataPreview.gamemode);
		}
	}

	public static void StartExistingGame(string saveFile, int mode)
	{
		GameStateManager.ChangeCharacterState(GameStateManager.CharacterState.DisableInput);
		MouseCursorInteraction.UpdateCursorState();
		new GameObject("GameDataHandler").AddComponent<GameDataSceneHandler>().WriteData(saveFile);
		selectedGameMode = mode;
		TransitionToScene(1);
		OnStartGame.Invoke();
	}

	private static void TransitionToScene(int scene = -1)
	{
		if (scene == -1)
		{
			TransitionManager.TriggerState("FadeToBlack");
			return;
		}
		FadeToBlackTransitionState triggerStateByType = TransitionManager.GetTriggerStateByType<FadeToBlackTransitionState>();
		if (triggerStateByType != null)
		{
			triggerStateByType.onFadeFinished = (Action)Delegate.Combine(triggerStateByType.onFadeFinished, (Action)delegate
			{
				instance.ExitAndLoadScene(scene);
			});
			TransitionManager.TriggerState("FadeToBlack");
		}
	}

	private void ExitAndLoadScene(int scene)
	{
		SceneManager.LoadScene(scene);
		GameStateManager.ChangeGameState(GameStateManager.GameState.GameRunning);
		GameStateManager.ChangeCharacterState(GameStateManager.CharacterState.CharacterMode);
		MouseCursorInteraction.UpdateCursorState();
		TransitionManager.ShowBlend();
		SoundManager.ChangeMusic(instance.musicDefaultInGame);
	}

	private void EnterScene()
	{
		TransitionToScene();
		GameModeManager.SetCurrentGameMode(selectedGameMode);
		MouseCursorInteraction.UpdateCursorState();
	}

	public static void ReturnToMenu()
	{
		GameStateManager.ChangeGameState(GameStateManager.GameState.TitleScreen);
		GameStateManager.ChangeCharacterState(GameStateManager.CharacterState.DisableInput);
		MouseCursorInteraction.UpdateCursorState();
		PopupMessageManager.HideAll();
		Action onFadeFinished = delegate
		{
			SceneManager.LoadScene(0);
			SoundManager.ChangeMusic(instance.musicTitleScreen);
			TweenerManager.TweenTimeAction("UpdateGameState", 1f, delegate
			{
				GameStateManager.ChangeCharacterState(GameStateManager.CharacterState.MenuOpen);
				MouseCursorInteraction.UpdateCursorState();
			});
		};
		FadeToTitleScreenTransitionState triggerStateByType = TransitionManager.GetTriggerStateByType<FadeToTitleScreenTransitionState>();
		if (triggerStateByType != null)
		{
			triggerStateByType.onFadeFinished = onFadeFinished;
			TransitionManager.TriggerState("FadeToTitleScreen");
		}
		IRC.Instance.Disconnect();
	}

	public static void SetGameScreen()
	{
		GameStateManager.ChangeGameState(GameStateManager.GameState.GameRunning);
		GameStateManager.ChangeCharacterState(GameStateManager.CharacterState.CharacterMode);
		MouseCursorInteraction.UpdateCursorState();
		CameraManager.SetPlayerCameraActive();
		OnStartGame.Invoke();
	}
}
