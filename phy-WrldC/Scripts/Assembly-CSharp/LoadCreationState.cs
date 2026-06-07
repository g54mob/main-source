using UnityEngine;

public class LoadCreationState : State<GameManager>
{
	private static readonly LoadCreationState instance;

	private LoadCreationView loadCreationView;

	public static LoadCreationState Instance => instance;

	static LoadCreationState()
	{
		instance = new LoadCreationState();
	}

	private LoadCreationState()
	{
	}

	public override void Start(GameManager GAME)
	{
		loadCreationView = GAME.GUIManager.LoadCreationView;
	}

	public override void Enter(GameManager GAME)
	{
		GAME.CameraManager.SetLockMainCamera(isLocked: true);
		loadCreationView.SetVisibility(isVisible: true);
		loadCreationView.RefreshPages();
	}

	public override void Execute(GameManager GAME)
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			GAME.ChangeState(ConstructionState.Instance);
		}
	}

	public override void Exit(GameManager GAME)
	{
		GAME.CameraManager.SetLockMainCamera(isLocked: false);
		loadCreationView.SetVisibility(isVisible: false);
	}
}
