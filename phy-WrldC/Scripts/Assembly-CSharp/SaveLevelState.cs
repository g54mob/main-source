using System.Collections;
using UnityEngine;

public class SaveLevelState : State<GameManager>
{
	private SaveLevelController saveLevelController;

	public static SaveLevelState Instance { get; }

	static SaveLevelState()
	{
		Instance = new SaveLevelState();
	}

	private SaveLevelState()
	{
	}

	public override void Start(GameManager gameManager)
	{
		saveLevelController = gameManager.GUIManager.SaveLevelController;
	}

	public override void Enter(GameManager gameManager)
	{
		GameManager.Instance.StartCoroutine(CreateLevelImage());
		saveLevelController.view.SetLevelModelConfigurations(gameManager.LevelEditorManager.LevelModel);
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
		saveLevelController.view.SetVisibility(isVisible: false);
		gameManager.LevelEditorManager.SetLockCamera(isLocked: false);
	}

	private IEnumerator CreateLevelImage()
	{
		LevelEditorManager.Instance.ThumbnailCamera.gameObject.SetActive(value: true);
		yield return new WaitForEndOfFrame();
		saveLevelController.view.CreateLevelImage();
		LevelEditorManager.Instance.ThumbnailCamera.gameObject.SetActive(value: false);
		saveLevelController.view.SetVisibility(isVisible: true);
	}
}
