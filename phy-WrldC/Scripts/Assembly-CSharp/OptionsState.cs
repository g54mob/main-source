using UnityEngine;

public class OptionsState : State<GameManager>
{
	private OptionsController optionsController;

	public static OptionsState Instance { get; }

	static OptionsState()
	{
		Instance = new OptionsState();
	}

	private OptionsState()
	{
	}

	public override void Start(GameManager gameManager)
	{
		optionsController = GUIManager.Instance.OptionsController;
	}

	public override void Enter(GameManager gameManager)
	{
		optionsController.view.SetVisibility(isVisible: true);
		optionsController.view.SelectFirstTab();
		optionsController.RebuildView();
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
		optionsController.view.SetVisibility(isVisible: false);
	}
}
