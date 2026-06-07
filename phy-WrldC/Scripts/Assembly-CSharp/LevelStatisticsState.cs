using UnityEngine;

public class LevelStatisticsState : State<GameManager>
{
	private LevelStatisticsController levelStatisticsController;

	public static LevelStatisticsState Instance { get; }

	static LevelStatisticsState()
	{
		Instance = new LevelStatisticsState();
	}

	private LevelStatisticsState()
	{
	}

	public override void Start(GameManager gameManager)
	{
		levelStatisticsController = gameManager.GUIManager.LevelStatisticsController;
	}

	public override void Enter(GameManager gameManager)
	{
		gameManager.CameraManager.SetLockMainCamera(isLocked: true);
		levelStatisticsController.view.SetVisibility(isVisible: true);
		levelStatisticsController.SetModel(gameManager.LevelController.model);
	}

	public override void Execute(GameManager gameManager)
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			gameManager.ChangeState(ConstructionState.Instance);
		}
	}

	public override void Exit(GameManager gameManager)
	{
		gameManager.CameraManager.SetLockMainCamera(isLocked: false);
		levelStatisticsController.view.SetVisibility(isVisible: false);
	}
}
