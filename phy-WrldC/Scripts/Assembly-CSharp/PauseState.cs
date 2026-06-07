using UltimateReplay;
using UnityEngine;

public class PauseState : State<GameManager>
{
	private PauseController pauseController;

	public static PauseState Instance { get; }

	static PauseState()
	{
		Instance = new PauseState();
	}

	private PauseState()
	{
	}

	public override void Start(GameManager gameManager)
	{
		pauseController = gameManager.GUIManager.PauseController;
	}

	public override void Enter(GameManager gameManager)
	{
		Time.timeScale = 0f;
		gameManager.LevelController.view.IsLevelPaused = true;
		gameManager.AudioEffectsManager.PauseAudioSourcesInUse();
		gameManager.MainCreationController.view.IsPlayable = false;
		pauseController.view.SetEditorButtonVisibility(gameManager.LevelController.model.Place == LevelModel.LevelPlace.Test);
		pauseController.view.SetVisibility(isVisible: true);
	}

	public override void EnterFromSubState(GameManager gameManager)
	{
		base.EnterFromSubState(gameManager);
		Time.timeScale = 0f;
		gameManager.MainCreationController.view.IsPlayable = false;
		pauseController.view.SetVisibility(isVisible: true);
	}

	public override void Execute(GameManager gameManager)
	{
		bool flag = Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.R);
		if (Input.GetKeyDown(KeyCode.Escape) || flag)
		{
			if (Input.GetKeyDown(KeyCode.Escape))
			{
				gameManager.ExitSubState();
				return;
			}
			ReplayManager.StopRecording();
			gameManager.ResetLevel();
		}
	}

	public override void Exit(GameManager gameManager)
	{
		pauseController.view.SetVisibility(isVisible: false);
		Time.timeScale = 1f;
		if (gameManager.LevelController.view != null)
		{
			gameManager.LevelController.view.IsLevelPaused = false;
		}
		gameManager.AudioEffectsManager.UnPauseAudioSourcesInUse();
		gameManager.MainCreationController.view.IsPlayable = true;
	}

	public override void ExitToSubState(GameManager gameManager)
	{
		base.ExitToSubState(gameManager);
		Time.timeScale = 1f;
		gameManager.MainCreationController.view.IsPlayable = true;
		pauseController.view.SetVisibility(isVisible: false);
	}
}
