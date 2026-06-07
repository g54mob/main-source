using UnityEngine;

public class LevelEditorInventoryState : State<GameManager>
{
	private LEQuickInventoryController quickInventoryController;

	private LEInventoryController leInventoryController;

	private bool shouldSaveXml;

	public static LevelEditorInventoryState Instance { get; }

	public bool IsExitStateLocked { get; set; }

	static LevelEditorInventoryState()
	{
		Instance = new LevelEditorInventoryState();
	}

	private LevelEditorInventoryState()
	{
	}

	public override void Start(GameManager gameManager)
	{
		quickInventoryController = gameManager.GUIManager.LEQuickInventoryController;
		leInventoryController = gameManager.GUIManager.LEInventoryController;
		quickInventoryController.model.NotifyChangeEvent += QuickInventoryModelHandler;
		quickInventoryController.OnModelChanged += delegate(QuickInventoryModelBase<CustomLevelObjectsModel> newModel, QuickInventoryModelBase<CustomLevelObjectsModel> lastModel)
		{
			newModel.NotifyChangeEvent += QuickInventoryModelHandler;
			shouldSaveXml = true;
		};
	}

	public override void Enter(GameManager gameManager)
	{
		shouldSaveXml = false;
		quickInventoryController.view.SetEditable(isEditable: true);
		leInventoryController.view.SetVisibility(isVisible: true);
		leInventoryController.view.RefreshPages(leInventoryController.model.SelectedCategoryIndex);
		leInventoryController.model.SelectedItemIndex = leInventoryController.model.SelectedItemIndex;
		gameManager.LevelEditorManager.SetLockCamera(isLocked: true);
		IsExitStateLocked = false;
	}

	public override void Execute(GameManager gameManager)
	{
		if (!IsExitStateLocked && (Input.GetKeyDown(KeyCode.I) || Input.GetKeyDown(KeyCode.Escape)))
		{
			gameManager.ExitSubState();
		}
	}

	public override void Exit(GameManager gameManager)
	{
		if (shouldSaveXml)
		{
			LEQuickInventoryBuilder.SaveXml(gameManager.LEQuickInventoryModel, PathNames.LEQuickInventory);
		}
		quickInventoryController.view.SetEditable(isEditable: false);
		leInventoryController.view.SetVisibility(isVisible: false);
		gameManager.LevelEditorManager.SetLockCamera(isLocked: false);
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
