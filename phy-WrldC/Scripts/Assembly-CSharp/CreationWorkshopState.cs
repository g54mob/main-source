using UnityEngine;

public class CreationWorkshopState : State<GameManager>
{
	private CreationWorkshopController creationWorkshopController;

	public static CreationWorkshopState Instance { get; }

	static CreationWorkshopState()
	{
		Instance = new CreationWorkshopState();
	}

	private CreationWorkshopState()
	{
	}

	public override void Start(GameManager gameManager)
	{
		creationWorkshopController = gameManager.GUIManager.CreationWorkshopController;
	}

	public override void Enter(GameManager gameManager)
	{
		creationWorkshopController.view.SetVisibility(isVisible: true);
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
		creationWorkshopController.RemoveCreationThumbnailImage();
		creationWorkshopController.view.SetVisibility(isVisible: false);
	}
}
