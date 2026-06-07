using UltimateReplay;

public class ActionModeController : BaseController<ActionModeView>
{
	private LevelModel levelModel;

	public ActionModeController(ActionModeView view)
		: base(view)
	{
		bool isKeyListWinVisible = GameManager.Instance.OptionsModel.IsKeyListWinVisible;
		view.SetKeyListToggleValue(isKeyListWinVisible);
		view.CreationKeyListView.SetVisibility(isKeyListWinVisible);
		bool isKeyListWinCompact = GameManager.Instance.OptionsModel.IsKeyListWinCompact;
		view.CreationKeyListView.SetKeyListCompactStatus(isKeyListWinCompact);
		view.CreationKeyListView.SetKeyListCompactToggleValue(isKeyListWinCompact);
		GameManager.Instance.LevelController.OnModelChanged += LevelModelChangedHandler;
	}

	private void LevelModelChangedHandler(LevelModel currentModel, LevelModel lastModel)
	{
		if (lastModel != null)
		{
			lastModel.NotifyChangeEvent -= LevelModelNotifyChangeEvent;
		}
		currentModel.NotifyChangeEvent += LevelModelNotifyChangeEvent;
		levelModel = currentModel;
	}

	private void LevelModelNotifyChangeEvent(string eventName, params object[] data)
	{
		if (eventName == "LevelModel.CollectablesCountChangedEvent")
		{
			view.SetCollectablesCount(levelModel.GoldCollectableCounter, levelModel.GoldCollectableTotal, levelModel.SilverCollectableCounter, levelModel.SilverCollectableTotal);
		}
	}

	protected override void ViewChangeHandler(string eventName, params object[] data)
	{
		switch (eventName)
		{
		case "ActionModeView.KeyListVisibilityToggleEvent":
		{
			bool flag2 = (bool)data[0];
			view.CreationKeyListView.SetVisibility(flag2);
			GameManager.Instance.OptionsModel.IsKeyListWinVisible = flag2;
			GameManager.Instance.OptionsModel.SaveValuesOnDisk();
			break;
		}
		case "ActionModeView.KeyListCompactToggleEvent":
		{
			bool flag = (bool)data[0];
			view.CreationKeyListView.SetKeyListCompactStatus(flag);
			GameManager.Instance.OptionsModel.IsKeyListWinCompact = flag;
			GameManager.Instance.OptionsModel.SaveValuesOnDisk();
			break;
		}
		case "ActionModeView.CameraResetEvent":
			GameManager.Instance.CameraManager.FocusMainCameraOnBrainBlock(GameManager.Instance.MainCreationController);
			break;
		case "ActionModeView.LevelResetEvent":
			ReplayManager.StopRecording();
			GameManager.Instance.ResetLevel();
			break;
		}
	}
}
