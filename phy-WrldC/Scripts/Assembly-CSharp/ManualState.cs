using UnityEngine;

public class ManualState : State<GameManager>
{
	private ManualController manualController;

	public static ManualState Instance { get; }

	static ManualState()
	{
		Instance = new ManualState();
	}

	private ManualState()
	{
	}

	public override void Start(GameManager gameManager)
	{
		manualController = gameManager.GUIManager.ManualController;
	}

	public override void Enter(GameManager gameManager)
	{
		gameManager.CameraManager.SetLockMainCamera(isLocked: true);
		manualController.view.SetVisibility(isVisible: true);
	}

	public override void Execute(GameManager gameManager)
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			gameManager.RevertToPreviousState();
		}
	}

	public override void Exit(GameManager gameManager)
	{
		gameManager.CameraManager.SetLockMainCamera(isLocked: false);
		manualController.view.SetVisibility(isVisible: false);
	}
}
