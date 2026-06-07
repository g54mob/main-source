using UnityEngine;

public class LevelEditorManualState : State<GameManager>
{
	private LEManualController leManualController;

	public static LevelEditorManualState Instance { get; }

	static LevelEditorManualState()
	{
		Instance = new LevelEditorManualState();
	}

	private LevelEditorManualState()
	{
	}

	public override void Start(GameManager gameManager)
	{
		leManualController = gameManager.GUIManager.LEManualController;
	}

	public override void Enter(GameManager gameManager)
	{
		leManualController.view.SetVisibility(isVisible: true);
		gameManager.LevelEditorManager.SetLockCamera(isLocked: true);
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
		leManualController.view.SetVisibility(isVisible: false);
		gameManager.LevelEditorManager.SetLockCamera(isLocked: false);
	}
}
