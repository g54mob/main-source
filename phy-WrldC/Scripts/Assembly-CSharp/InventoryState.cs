using UnityEngine;

public class InventoryState : State<GameManager>
{
	private QuickInventoryController quickInventoryController;

	private InventoryController inventoryController;

	private InventoryView inventoryView;

	private bool shouldSaveXml;

	public static InventoryState Instance { get; }

	public bool IsExitStateLocked { get; set; }

	static InventoryState()
	{
		Instance = new InventoryState();
	}

	private InventoryState()
	{
	}

	public override void Start(GameManager GAME)
	{
		quickInventoryController = GAME.QuickInventoryController;
		inventoryController = GAME.GUIManager.InventoryController;
		inventoryView = GAME.GUIManager.InventoryView;
		GAME.MainQuickInventoryModel.NotifyChangeEvent += QuickInventoryModelHandler;
		GAME.QuickInventoryController.OnModelChanged += delegate(QuickInventoryModelBase<CreationModel> newModel, QuickInventoryModelBase<CreationModel> lastModel)
		{
			newModel.NotifyChangeEvent += QuickInventoryModelHandler;
			shouldSaveXml = true;
		};
	}

	public override void Enter(GameManager GAME)
	{
		GAME.CameraManager.SetLockMainCamera(isLocked: true);
		shouldSaveXml = false;
		quickInventoryController.view.SetEditable(isEditable: true);
		inventoryView.SetVisibility(isVisible: true);
		inventoryView.RefreshPages(inventoryController.model.SelectedCategoryIndex);
		inventoryController.model.SelectedItemIndex = inventoryController.model.SelectedItemIndex;
		IsExitStateLocked = false;
	}

	public override void Execute(GameManager GAME)
	{
		if (!IsExitStateLocked && (Input.GetKeyDown(KeyCode.I) || Input.GetKeyDown(KeyCode.Escape)))
		{
			GAME.ChangeState(ConstructionState.Instance);
		}
	}

	public override void Exit(GameManager GAME)
	{
		GAME.CameraManager.SetLockMainCamera(isLocked: false);
		if (shouldSaveXml && GAME.LevelType != GameManager.LevelTypeState.Tutorial)
		{
			QuickInventoryBuilder.SaveXml(GAME.MainQuickInventoryModel, PathNames.QuickInventory);
		}
		quickInventoryController.view.SetEditable(isEditable: false);
		inventoryView.SetVisibility(isVisible: false);
	}

	private void QuickInventoryModelHandler(string eventName, params object[] data)
	{
		switch (eventName)
		{
		case "QuickInventoryModelBase.AddTabEvent":
		case "QuickInventoryModelBase.AddItemEvent":
		case "QuickInventoryModelBase.InsertItemEvent":
		case "QuickInventoryModelBase.RemoveTabEvent":
		case "QuickInventoryModelBase.RemoveItemEvent":
		case "QuickInventoryModelBase.SwapTabEvent":
		case "QuickInventoryModelBase.SwapItemEvent":
			shouldSaveXml = true;
			break;
		}
	}
}
