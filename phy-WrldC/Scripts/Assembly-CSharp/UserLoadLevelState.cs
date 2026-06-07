using UnityEngine;

public class UserLoadLevelState : State<GameManager>
{
	private LoadLevelController loadLevelController;

	public static UserLoadLevelState Instance { get; }

	static UserLoadLevelState()
	{
		Instance = new UserLoadLevelState();
	}

	private UserLoadLevelState()
	{
	}

	public override void Start(GameManager gameManager)
	{
		loadLevelController = gameManager.GUIManager.LoadLevelController;
	}

	public override void Enter(GameManager gameManager)
	{
		loadLevelController.view.SetVisibility(isVisible: true);
		if (gameManager.LevelEditorManager != null)
		{
			gameManager.LevelEditorManager.SetLockCamera(isLocked: true);
		}
	}

	public override void Execute(GameManager gameManager)
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			gameManager.ExitSubState();
		}
	}

	public override void Exit(GameManager gameManager)
	{
		loadLevelController.view.SetVisibility(isVisible: false);
		if (gameManager.LevelEditorManager != null)
		{
			gameManager.LevelEditorManager.SetLockCamera(isLocked: false);
		}
	}
}
