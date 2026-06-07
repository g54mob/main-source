using UnityEngine;

public class LeaderboardsWindowState : State<GameManager>
{
	private LeaderboardsWindowController leaderboardsWindowController;

	public static LeaderboardsWindowState Instance { get; }

	public LevelModel CustomTargetLevelModel { get; set; }

	static LeaderboardsWindowState()
	{
		Instance = new LeaderboardsWindowState();
	}

	private LeaderboardsWindowState()
	{
	}

	public override void Start(GameManager gameManager)
	{
		leaderboardsWindowController = gameManager.GUIManager.LeaderboardsWindowController;
	}

	public override void Enter(GameManager gameManager)
	{
		leaderboardsWindowController.view.SetVisibility(isVisible: true);
		leaderboardsWindowController.SetModel(CustomTargetLevelModel ?? gameManager.LevelController.model);
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
		leaderboardsWindowController.view.SetVisibility(isVisible: false);
		CustomTargetLevelModel = null;
	}
}
