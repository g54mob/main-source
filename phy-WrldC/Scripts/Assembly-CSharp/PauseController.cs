public class PauseController : BaseController<PauseView>
{
	public PauseController(PauseView view)
		: base(view)
	{
	}

	protected override void ViewChangeHandler(string eventName, params object[] data)
	{
		switch (eventName)
		{
		case "PauseView.RetryButtonEvent":
			GameManager.Instance.ResetLevel();
			break;
		case "PauseView.MenuButtonEvent":
			GUIManager.Instance.FadeInToBlackAndExecuteAction(delegate
			{
				GameManager.Instance.CameraManager.RestoresMainCamera();
				GameManager.Instance.ClearAllCreations();
				GameManager.Instance.UnloadCurrentLevel();
				GameManager.Instance.ChangeState(MenuState.Instance);
			});
			break;
		case "PauseView.BuildButtonEvent":
			GameManager.Instance.RestoresCreationsAndLevel();
			GameManager.Instance.ChangeState(ConstructionState.Instance);
			break;
		case "PauseView.ReplayButtonEvent":
			GameManager.Instance.SetSubState(ReplayState.Instance);
			break;
		case "PauseView.BackButtonEvent":
			GameManager.Instance.ExitSubState();
			break;
		case "PauseView.EditorButtonEvent":
			GUIManager.Instance.FadeInToBlackAndExecuteAction(delegate
			{
				GameManager.Instance.ClearAllCreations();
				GameManager.Instance.UnloadCurrentLevel();
				GameManager.Instance.LoadLevelEditorAndChangeState(LevelEditorState.Instance);
			});
			break;
		}
	}
}
