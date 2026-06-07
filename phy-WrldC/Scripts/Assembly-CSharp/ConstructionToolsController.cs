public class ConstructionToolsController : BaseController<ConstructionToolsView, ConstructionToolsModel>
{
	private MassCenterController massCenterController;

	public ConstructionToolsController(ConstructionToolsView view, ConstructionToolsModel model)
		: base(view, model, false)
	{
		massCenterController = new MassCenterController(model, view, null);
		GameManager.Instance.AddListenerOnStateChanged(StateChangedHandler);
		GameManager.Instance.AttackerCreationController.OnModelChanged += CreationModelChangedHandler;
		GameManager.Instance.DefenderCreationController.OnModelChanged += CreationModelChangedHandler;
		GameManager.Instance.AttackerCreationController.OnSyncViewWithModelCompleted += delegate
		{
			CreationViewRebuilt();
		};
		GameManager.Instance.DefenderCreationController.OnSyncViewWithModelCompleted += delegate
		{
			CreationViewRebuilt();
		};
		GameManager.Instance.AttackerCreationController.OnChangedBlocksCountEvent += ChangedBlocksCountHandler;
		GameManager.Instance.DefenderCreationController.OnChangedBlocksCountEvent += ChangedBlocksCountHandler;
	}

	protected override void SyncViewWithModel()
	{
		ModelChangeHandler("ConstructionToolsModel.ConnectorGridSizeChangedEvent", model.ConnectorGridSize, 6);
		ModelChangeHandler("ConstructionToolsModel.MovingToolChangedEvent", model.IsMovingToolEnabled);
		ModelChangeHandler("ConstructionToolsModel.AutoFocusChangedEvent", model.IsAutoFocusActivated);
		ModelChangeHandler("ConstructionToolsModel.AutoConnectionsChangedEvent", model.IsAutoConnectionsActivated);
	}

	protected override void ModelChangeHandler(string eventName, params object[] data)
	{
		switch (eventName)
		{
		case "ConstructionToolsModel.UndoCommandEvent":
			GameManager.Instance.ConstructionCommandManager.RevertLastCommand();
			break;
		case "ConstructionToolsModel.RedoCommandEvent":
			GameManager.Instance.ConstructionCommandManager.ExecuteLastRevertedCommand();
			break;
		case "ConstructionToolsModel.ConnectorGridSizeChangedEvent":
		{
			int num3 = (int)data[0];
			int num4 = 6;
			view.SetGridSizeInteractivity(num3 > 1, num3 < num4, num3);
			GameManager.Instance.OptionsModel.ConnectorGridSize = num3;
			GameManager.Instance.OptionsModel.SaveValuesOnDisk();
			break;
		}
		case "ConstructionToolsModel.ConnectionTypeChangedEvent":
		{
			bool hingeConnectionToggleStatus = (bool)data[0];
			view.SetHingeConnectionToggleStatus(hingeConnectionToggleStatus);
			break;
		}
		case "ConstructionToolsModel.MovingToolChangedEvent":
		{
			bool flag5 = (bool)data[0];
			if (flag5)
			{
				if (GameManager.Instance.MainCreationsManager.MainCreationController.model.BlockModelCount <= 0)
				{
					model.IsMovingToolEnabled = false;
					break;
				}
				GameManager.Instance.ChangeState(CreationMovingState.Instance);
			}
			view.SetMoveToggleStatus(flag5);
			break;
		}
		case "ConstructionToolsModel.ConstructionCommandsChangedEvent":
		{
			int num = (int)data[0];
			int num2 = (int)data[1];
			view.SetUndoRedoInteractivity(num > 0, num2 > 0);
			break;
		}
		case "ConstructionToolsModel.GizmosVisibilityEvent":
		{
			bool flag4 = (bool)data[0];
			GameManager.Instance.MainCreationController.SetComponentGizmosVisibility(flag4);
			view.SetGizmosToggleStatus(flag4);
			break;
		}
		case "ConstructionToolsModel.MassCenterVisibilityEvent":
		{
			bool flag3 = (bool)data[0];
			view.SetMassCenterVisibility(flag3);
			if (flag3)
			{
				view.SetMassCenterPosition(GameManager.Instance.MainCreationController.view.GetMassCenter());
			}
			break;
		}
		case "ConstructionToolsModel.AutoFocusChangedEvent":
		{
			bool flag2 = (bool)data[0];
			view.SetAutoFocusToggleStatus(flag2);
			GameManager.Instance.OptionsModel.IsAutoFocusActivated = flag2;
			GameManager.Instance.OptionsModel.SaveValuesOnDisk();
			break;
		}
		case "ConstructionToolsModel.AutoConnectionsChangedEvent":
		{
			bool flag = (bool)data[0];
			view.SetAutoConnectionsToggleStatus(flag);
			GameManager.Instance.OptionsModel.IsAutoConnectionsActivated = flag;
			GameManager.Instance.OptionsModel.SaveValuesOnDisk();
			break;
		}
		}
	}

	protected override void ViewChangeHandler(string eventName, params object[] data)
	{
		switch (eventName)
		{
		case "ConstructionToolsView.UndoButtonEvent":
			model.UndoCommand();
			break;
		case "ConstructionToolsView.RedoButtonEvent":
			model.RedoCommand();
			break;
		case "ConstructionToolsView.GridDecreaseButtonEvent":
			model.ConnectorGridSize--;
			break;
		case "ConstructionToolsView.GridIncreaseButtonEvent":
			model.ConnectorGridSize++;
			break;
		case "ConstructionToolsView.InventoryButtonEvent":
			GameManager.Instance.ChangeState(InventoryState.Instance);
			break;
		case "ConstructionToolsView.BlockViewButtonEvent":
			GameManager.Instance.ChangeState(BlockVisualizationState.Instance);
			break;
		case "ConstructionToolsView.HingeConnectionEvent":
		{
			bool isAutoConnectionsActivated = (bool)data[0];
			model.IsHingeJointConnection = isAutoConnectionsActivated;
			break;
		}
		case "ConstructionToolsView.MoveButtonEvent":
		{
			bool isAutoConnectionsActivated = (bool)data[0];
			model.IsMovingToolEnabled = isAutoConnectionsActivated;
			break;
		}
		case "ConstructionToolsView.GizmosToggleEvent":
		{
			bool isAutoConnectionsActivated = (bool)data[0];
			model.IsGizmosVisible = isAutoConnectionsActivated;
			break;
		}
		case "ConstructionToolsView.MassCenterToggleEvent":
		{
			bool isAutoConnectionsActivated = (bool)data[0];
			model.IsMassCenterVisible = isAutoConnectionsActivated;
			break;
		}
		case "ConstructionToolsView.AutoFocusToggleEvent":
		{
			bool isAutoConnectionsActivated = (bool)data[0];
			model.IsAutoFocusActivated = isAutoConnectionsActivated;
			break;
		}
		case "ConstructionToolsView.AutoConnectionsToggleEvent":
		{
			bool isAutoConnectionsActivated = (bool)data[0];
			model.IsAutoConnectionsActivated = isAutoConnectionsActivated;
			break;
		}
		case "ConstructionToolsView.ClearButtonEvent":
			GameManager.Instance.ClearMainCreation();
			break;
		}
	}

	private void StateChangedHandler(State<GameManager> newState)
	{
		if (newState != ConstructionState.Instance)
		{
			model.IsMassCenterVisible = false;
		}
	}

	private void CreationModelChangedHandler(CreationModel creationModel, CreationModel lastCreationModel)
	{
		massCenterController.SetModel(GameManager.Instance.MainCreationController.model);
		model.IsMovingToolEnabled = false;
	}

	private void CreationViewRebuilt()
	{
		model.IsGizmosVisible = model.IsGizmosVisible;
	}

	private void ChangedBlocksCountHandler(int blocksCount)
	{
		if (blocksCount == 0)
		{
			view.SetMoveToggleStatus(isSelected: false);
		}
		view.SetMoveToggleInteractivity(blocksCount > 0);
	}
}
