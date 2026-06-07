using UnityEngine;

public class UserLevelWorkshopState : State<GameManager>
{
	private UserLevelWorkshopController userLevelWorshopController;

	public static UserLevelWorkshopState Instance { get; }

	static UserLevelWorkshopState()
	{
		Instance = new UserLevelWorkshopState();
	}

	private UserLevelWorkshopState()
	{
	}

	public override void Start(GameManager gameManager)
	{
		userLevelWorshopController = gameManager.GUIManager.UserLevelWorkshopController;
	}

	public override void Enter(GameManager gameManager)
	{
		userLevelWorshopController.view.SetVisibility(isVisible: true);
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
		userLevelWorshopController.view.SetVisibility(isVisible: false);
	}
}
