using System.Collections;
using UnityEngine;

public class MessageBoxState : State<GameManager>
{
	private MessageBoxController messageBoxController;

	private bool wasMainCameraLocked;

	private bool wasLevelEditorCameraLocked;

	private Coroutine autoConfirmCoroutine;

	public static MessageBoxState Instance { get; }

	static MessageBoxState()
	{
		Instance = new MessageBoxState();
	}

	private MessageBoxState()
	{
	}

	public override void Start(GameManager GAME)
	{
		messageBoxController = GUIManager.Instance.MessageBoxController;
	}

	public override void Enter(GameManager GAME)
	{
		wasMainCameraLocked = GAME.CameraManager.IsMainCameraLocked;
		GAME.CameraManager.SetLockMainCamera(isLocked: true);
		if (GAME.LevelEditorManager != null)
		{
			wasLevelEditorCameraLocked = GAME.LevelEditorManager.IsCameraLocked;
			GAME.LevelEditorManager.SetLockCamera(isLocked: true);
		}
		messageBoxController.view.SetVisibility(isVisible: true);
		if (messageBoxController.model.IsAutoConfirm)
		{
			autoConfirmCoroutine = messageBoxController.view.StartCoroutine(AutoConfirmAction(GAME));
		}
	}

	public override void Execute(GameManager GAME)
	{
		if (Input.GetKeyDown(KeyCode.Escape) && messageBoxController.model.IsCancelEnabled)
		{
			GAME.ExitSubState();
		}
	}

	public override void Exit(GameManager GAME)
	{
		messageBoxController.view.SetVisibility(isVisible: false);
		GAME.CameraManager.SetLockMainCamera(wasMainCameraLocked);
		if (GAME.LevelEditorManager != null)
		{
			GAME.LevelEditorManager.SetLockCamera(wasLevelEditorCameraLocked);
		}
		if (messageBoxController.model.IsAutoConfirm && autoConfirmCoroutine != null)
		{
			messageBoxController.view.StopCoroutine(autoConfirmCoroutine);
		}
	}

	private IEnumerator AutoConfirmAction(GameManager gameManager)
	{
		if (messageBoxController.model.AutoConfirmAction == null)
		{
			gameManager.ExitSubState();
			yield break;
		}
		while (messageBoxController.model.AutoConfirmAction().MoveNext())
		{
			yield return new WaitForEndOfFrame();
		}
		gameManager.ExitSubState();
	}
}
