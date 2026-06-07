using UnityEngine;

public class TopButtonsController : BaseController<TopButtonsView>
{
	private CreationInfosController creationInfosController;

	private LevelInfosController levelInfosController;

	private OptionsModel optionsModel;

	public TopButtonsController(TopButtonsView view)
		: base(view)
	{
		creationInfosController = new CreationInfosController(view.LevelCreationInfosView, null);
		levelInfosController = new LevelInfosController(view.LevelCreationInfosView, null);
		optionsModel = GameManager.Instance.OptionsModel;
		optionsModel.NotifyChangeEvent += OptionsModelChangeHandler;
		GameManager.Instance.AttackerCreationController.OnModelChanged += CreationInfosModelChangedHandler;
		GameManager.Instance.DefenderCreationController.OnModelChanged += CreationInfosModelChangedHandler;
		GameManager.Instance.AddListenerOnStateChanged(StateChangedHandler);
		GameManager.Instance.MainCreationsManager.OnCreationsLoadingStarted += delegate
		{
			GUIManager.Instance.SetMouseInteractive(isInteractive: false);
			Cursor.SetCursor(GameManager.Instance.LoadingCursor, Vector2.zero, CursorMode.Auto);
		};
		GameManager.Instance.MainCreationsManager.OnCreationsLoadingCompleted += delegate
		{
			GUIManager.Instance.SetMouseInteractive(isInteractive: true);
			if (!GUIManager.Instance.IsScreenFadedToBlack)
			{
				Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
			}
		};
		GameManager.Instance.AttackerCreationController.OnChangedBlocksCountEvent += ChangedBlocksCountHandler;
		GameManager.Instance.DefenderCreationController.OnChangedBlocksCountEvent += ChangedBlocksCountHandler;
		GameManager.Instance.LevelController.OnModelChanged += LevelControllerOnModelChangedHandler;
	}

	protected override void ViewChangeHandler(string eventName, params object[] data)
	{
		switch (eventName)
		{
		case "TopButtonsView.LevelEditorBackButtonEvent":
			GUIManager.Instance.MessageBoxController.SetModel(MessageBoxModelCollection.ReturnToLevelEditorFromConstructionMode);
			GameManager.Instance.SetSubState(MessageBoxState.Instance);
			break;
		case "TopButtonsView.MainMenuButtonEvent":
			if (GameManager.Instance.LevelController.model.Place != LevelModel.LevelPlace.Test)
			{
				GUIManager.Instance.MessageBoxController.SetModel(MessageBoxModelCollection.ReturnToMainMenu);
			}
			else
			{
				GUIManager.Instance.MessageBoxController.SetModel(MessageBoxModelCollection.ReturnToMainMenuFromLevelTest);
			}
			GameManager.Instance.SetSubState(MessageBoxState.Instance);
			break;
		case "TopButtonsView.LoadButtonEvent":
			GameManager.Instance.ChangeState(LoadCreationState.Instance);
			break;
		case "TopButtonsView.SaveButtonEvent":
			GameManager.Instance.ToSaveCreationModel = GameManager.Instance.MainCreationController.model;
			GameManager.Instance.ChangeState(SaveCreationState.Instance);
			break;
		case "TopButtonsView.ManualButtonEvent":
			GameManager.Instance.ChangeState(ManualState.Instance);
			break;
		case "TopButtonsView.PlayButtonEvent":
			GameManager.Instance.PlayLevel();
			break;
		case "TopButtonsView.ClearButtonEvent":
			GameManager.Instance.ClearMainCreation();
			break;
		case "TopButtonsView.ConstructionToggleEvent":
			if (GameManager.Instance.GetCurrentState() != ConstructionState.Instance)
			{
				GameManager.Instance.ChangeState(ConstructionState.Instance);
			}
			view.ShowToolsPanel(TopButtonsView.ToolsPanelEnum.Construction);
			break;
		case "TopButtonsView.HingeEditorToggleEvent":
			if (GameManager.Instance.GetCurrentState() != HingeEditorState.Instance)
			{
				GameManager.Instance.ChangeState(HingeEditorState.Instance);
			}
			view.ShowToolsPanel(TopButtonsView.ToolsPanelEnum.HingeEditor);
			break;
		case "TopButtonsView.PropertiesToggleEvent":
			if (GameManager.Instance.GetCurrentState() != ComponentPropertiesState.Instance)
			{
				GameManager.Instance.ChangeState(ComponentPropertiesState.Instance);
			}
			view.ShowToolsPanel(TopButtonsView.ToolsPanelEnum.Properties);
			break;
		case "TopButtonsView.JointEditorToggleEvent":
			if (GameManager.Instance.GetCurrentState() != JointEditorState.Instance)
			{
				GameManager.Instance.ChangeState(JointEditorState.Instance);
			}
			view.ShowToolsPanel(TopButtonsView.ToolsPanelEnum.JointEditor);
			break;
		case "TopButtonsView.LogicEditorToggleEvent":
			if (GameManager.Instance.GetCurrentState() != LogicEditorState.Instance)
			{
				GameManager.Instance.ChangeState(LogicEditorState.Instance);
			}
			view.ShowToolsPanel(TopButtonsView.ToolsPanelEnum.Logic);
			break;
		case "TopButtonsView.LevelCreationInfosToggleEvent":
		{
			bool flag = (bool)data[0];
			view.LevelCreationInfosView.ResetWindowPosition();
			view.LevelCreationInfosView.SetVisibility(flag);
			optionsModel.IsLevelCreationInfosWinVisible = flag;
			optionsModel.SaveValuesOnDisk();
			break;
		}
		case "TopButtonsView.LevelStatisticsButtonEvent":
			GameManager.Instance.ChangeState(LevelStatisticsState.Instance);
			break;
		case "TopButtonsView.CameraButtonEvent":
			GameManager.Instance.ResetCameraPosition();
			break;
		case "TopButtonsView.ResetButtonEvent":
			GameManager.Instance.LevelController.model.BestTime = float.PositiveInfinity;
			UserProfileModelBuilder.SaveXmlFile(GameManager.Instance.UserProfileModel, PathNames.UserProfileAES, isFileEncrypted: true);
			break;
		}
	}

	private void OptionsModelChangeHandler(string eventName, params object[] data)
	{
		if (eventName == "OptionsModel.ValuesChangedEvent")
		{
			view.LevelCreationInfosView.SetVisibility(optionsModel.IsLevelCreationInfosWinVisible);
			view.SetLevelCreationInfosToggleStatus(optionsModel.IsLevelCreationInfosWinVisible);
		}
	}

	private void CreationInfosModelChangedHandler(CreationModel creationModel, CreationModel lastCreationModel)
	{
		creationInfosController.SetModel(GameManager.Instance.MainCreationController.model);
	}

	private void StateChangedHandler(State<GameManager> newState)
	{
		if (newState == ConstructionState.Instance)
		{
			view.SetConstructionToggleStatus(isSelected: true);
			view.ShowToolsPanel(TopButtonsView.ToolsPanelEnum.Construction);
		}
		else if (newState == HingeEditorState.Instance)
		{
			view.SetHingeEditorToggleStatus(isSelected: true);
			view.ShowToolsPanel(TopButtonsView.ToolsPanelEnum.HingeEditor);
		}
		else if (newState == ComponentPropertiesState.Instance)
		{
			view.SetPropertiesToggleStatus(isSelected: true);
			view.ShowToolsPanel(TopButtonsView.ToolsPanelEnum.Properties);
		}
		else if (newState == LogicEditorState.Instance)
		{
			view.SetLogicEditorToggleStatus(isSelected: true);
			view.ShowToolsPanel(TopButtonsView.ToolsPanelEnum.Logic);
		}
	}

	private void ChangedBlocksCountHandler(int blocksCount)
	{
		view.SetSaveButtonInteractivity(blocksCount > 0);
	}

	private void LevelControllerOnModelChangedHandler(LevelModel levelModel, LevelModel lastLevelModel)
	{
		levelInfosController.SetModel(levelModel);
	}
}
