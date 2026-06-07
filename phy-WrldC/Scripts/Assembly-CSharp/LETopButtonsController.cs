using System.Linq;

public class LETopButtonsController : BaseController<LETopButtonsView>
{
	public LevelEditorToolsController LevelEditorToolsController { get; private set; }

	public LETopButtonsController(LETopButtonsView view)
		: base(view)
	{
		GameManager.Instance.UserAndWorkshopLevelModelCollection.NotifyChangeEvent += UserLevelModelCollectionNotifyChangeHandler;
		view.SetLoadButtonInteractivity(LevelEditorUtil.UserAndWorkshopLevelCounter(GameManager.Instance.UserAndWorkshopLevelModelCollection.GetAllItems().ToArray()) != 0);
		LevelEditorToolsController = new LevelEditorToolsController(new LevelEditorToolsView(view), GameManager.Instance.LevelEditorToolsModel);
		view.SetManualIndicatorPanelVisibility(GameManager.Instance.LEOptionsModel.IsManualIndicatorVisible);
	}

	protected override void ViewChangeHandler(string eventName, params object[] data)
	{
		switch (eventName)
		{
		case "LETopButtonsView.MainMenuButtonEvent":
			GUIManager.Instance.MessageBoxController.SetModel(MessageBoxModelCollection.ReturnToMainMenuFromLevelEditor);
			GameManager.Instance.SetSubState(MessageBoxState.Instance);
			break;
		case "LETopButtonsView.SaveButtonEvent":
			if (!LevelEditorManager.Instance.AreZonesInCollision())
			{
				GameManager.Instance.SetSubState(SaveLevelState.Instance);
			}
			break;
		case "LETopButtonsView.LoadButtonEvent":
			GameManager.Instance.GUIManager.LoadLevelView.SetPanelType(LoadLevelView.PanelType.Load);
			GameManager.Instance.SetSubState(UserLoadLevelState.Instance);
			break;
		case "LETopButtonsView.ManualButtonEvent":
			GameManager.Instance.SetSubState(LevelEditorManualState.Instance);
			break;
		case "LETopButtonsView.TestLevelButtonEvent":
			LevelEditorManager.Instance.TestLevel();
			break;
		case "LETopButtonsView.LevelInfosCloseButtonEvent":
			view.SetLevelInfosWindowVisibility(isVisible: false);
			view.SetLevelInfosToggleValue(isSelected: false);
			break;
		case "LETopButtonsView.LevelInfosToggleEvent":
		{
			bool levelInfosWindowVisibility = (bool)data[0];
			view.SetLevelInfosWindowVisibility(levelInfosWindowVisibility);
			break;
		}
		case "LETopButtonsView.ManualIndicatorCloseButtonEvent":
			view.SetManualIndicatorPanelVisibility(isVisible: false);
			GameManager.Instance.LEOptionsModel.IsManualIndicatorVisible = false;
			GameManager.Instance.LEOptionsModel.SaveValuesOnDisk();
			break;
		}
	}

	private void UserLevelModelCollectionNotifyChangeHandler(string eventName, params object[] data)
	{
		if (eventName == "GenericCollectionModel.CountChangedEvent")
		{
			_ = (int)data[0];
			view.SetLoadButtonInteractivity(LevelEditorUtil.UserAndWorkshopLevelCounter(GameManager.Instance.UserAndWorkshopLevelModelCollection.GetAllItems().ToArray()) != 0);
		}
	}
}
