using UnityEngine;

public class SaveLevelPartState : State<GameManager>
{
	private SaveLevelPartController saveLevelPartController;

	public CustomLevelObjectsModel ToSaveCustomLevelObjectsModel;

	public static SaveLevelPartState Instance { get; }

	static SaveLevelPartState()
	{
		Instance = new SaveLevelPartState();
	}

	private SaveLevelPartState()
	{
	}

	public override void Start(GameManager gameManager)
	{
		saveLevelPartController = gameManager.GUIManager.SaveLevelPartController;
	}

	public override void Enter(GameManager gameManager)
	{
		saveLevelPartController.view.SetVisibility(isVisible: true);
		saveLevelPartController.view.DrawCreationToSave(ToSaveCustomLevelObjectsModel);
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
		saveLevelPartController.view.SetVisibility(isVisible: false);
	}
}
