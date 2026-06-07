using UltimateReplay;
using UnityEngine;

public class LevelCompletedState : State<GameManager>
{
	private LevelCompletedController levelCompletedController;

	private LevelCompletedView levelCompletedView;

	public static LevelCompletedState Instance { get; }

	static LevelCompletedState()
	{
		Instance = new LevelCompletedState();
	}

	private LevelCompletedState()
	{
	}

	public override void Start(GameManager GAME)
	{
		levelCompletedController = GAME.GUIManager.LevelCompletedController;
		levelCompletedView = GAME.GUIManager.LevelCompletedView;
	}

	public override void Enter(GameManager GAME)
	{
		GAME.GUIManager.LevelCompletedController.SetModel(GAME.LevelController.model);
		levelCompletedView.SetVisibility(isVisible: true);
	}

	public override void EnterFromSubState(GameManager gameManager)
	{
		base.EnterFromSubState(gameManager);
		levelCompletedView.SetVisibility(isVisible: true);
		gameManager.AudioEffectsManager.UnPauseAudioSourcesInUse();
	}

	public override void Execute(GameManager GAME)
	{
		bool flag = Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.R);
		if (Input.GetKeyDown(KeyCode.Escape) || flag)
		{
			if (Input.GetKeyDown(KeyCode.Escape))
			{
				GAME.RestoresCreationsAndLevel();
				GAME.ChangeState(ConstructionState.Instance);
			}
			else
			{
				GAME.ResetLevel();
			}
		}
	}

	public override void Exit(GameManager GAME)
	{
		ReplayManager.StopRecording();
		levelCompletedView.SetVisibility(isVisible: false);
	}

	public override void ExitToSubState(GameManager gameManager)
	{
		base.ExitToSubState(gameManager);
		ReplayManager.StopRecording();
		levelCompletedView.SetVisibility(isVisible: false);
		gameManager.AudioEffectsManager.PauseAudioSourcesInUse();
	}
}
