using UnityEngine;

public class SaveCreationState : State<GameManager>
{
	private SaveAttackerCreationController saveAttackerCreationController;

	private SaveDefenderCreationController saveDefenderCreationController;

	public static SaveCreationState Instance { get; }

	static SaveCreationState()
	{
		Instance = new SaveCreationState();
	}

	private SaveCreationState()
	{
	}

	public override void Start(GameManager GAME)
	{
		saveAttackerCreationController = GAME.GUIManager.SaveAttackerCreationController;
		saveDefenderCreationController = GAME.GUIManager.SaveDefenderCreationController;
	}

	public override void Enter(GameManager GAME)
	{
		GAME.CameraManager.SetLockMainCamera(isLocked: true);
		if (GAME.GameMode == GameManager.GameModeState.Attacker)
		{
			saveAttackerCreationController.view.SetVisibility(isVisible: true);
			saveAttackerCreationController.view.DrawCreationToSave(CreationCloner.Clone(GAME.ToSaveCreationModel));
		}
		else if (GAME.GameMode == GameManager.GameModeState.Defender)
		{
			saveDefenderCreationController.SetModel(GAME.LevelController.model);
			saveDefenderCreationController.view.SetVisibility(isVisible: true);
		}
	}

	public override void Execute(GameManager GAME)
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			GAME.RevertToPreviousState();
		}
	}

	public override void Exit(GameManager GAME)
	{
		GAME.CameraManager.SetLockMainCamera(isLocked: false);
		saveAttackerCreationController.view.SetVisibility(isVisible: false);
		saveDefenderCreationController.view.SetVisibility(isVisible: false);
	}
}
