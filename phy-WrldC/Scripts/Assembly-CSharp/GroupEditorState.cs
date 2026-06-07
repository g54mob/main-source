using System.Collections.Generic;
using UnityEngine;

public class GroupEditorState : State<GameManager>
{
	private ConstructionMouseOverEvents groupMouseOverEvents;

	private BlockHighlightsHandler blockHighlightsHandler;

	private TopButtonsView topButtonsView;

	private QuickInventoryView quickInventoryView;

	private ClipboardView clipboardView;

	private StepByStepView stepByStepView;

	private GameObject selectedPivotPointObject;

	private GameObject mouseOverBlockBodyObject;

	private GameManager gameManager;

	public static GroupEditorState Instance { get; }

	static GroupEditorState()
	{
		Instance = new GroupEditorState();
	}

	private GroupEditorState()
	{
	}

	public override void Start(GameManager gameManager)
	{
		this.gameManager = gameManager;
		topButtonsView = gameManager.GUIManager.TopButtonsView;
		quickInventoryView = gameManager.GUIManager.QuickInventoryView;
		clipboardView = gameManager.GUIManager.ClipboardView;
		stepByStepView = gameManager.GUIManager.StepByStepView;
		selectedPivotPointObject = Object.Instantiate(gameManager.connectorFixedPrefab);
		selectedPivotPointObject.SetActive(value: false);
		blockHighlightsHandler = new BlockHighlightsHandler(gameManager);
		groupMouseOverEvents = new ConstructionMouseOverEvents();
		groupMouseOverEvents.OnMouseEnterBlockBodyObject += delegate(GameObject blockObject)
		{
			blockHighlightsHandler.MouseEnterBlockBodyHandler(blockObject, isInterconnectedHighlights: true);
		};
		groupMouseOverEvents.OnMouseExitBlockBodyObject += blockHighlightsHandler.MouseExitBlockBodyHandler;
		groupMouseOverEvents.OnOverRestrictedZoneForBlock += () => topButtonsView.IsMouseOverUI || quickInventoryView.IsMouseOverUI || clipboardView.IsMouseOverUI || stepByStepView.IsMouseOverUI;
		groupMouseOverEvents.OnMouseEnterConnector += MouseEnterConnectorHandler;
		groupMouseOverEvents.OnMouseExitConnector += MouseExitConnectorHandler;
		groupMouseOverEvents.OnMouseOverBlockBodyObject += MouseOverBlockBodyObjectHandler;
		groupMouseOverEvents.OnMouseOverConnector += MouseOverConnectorHandler;
		groupMouseOverEvents.OnOverRestrictedZoneForLevel += () => topButtonsView.IsMouseOverUI || quickInventoryView.IsMouseOverUI || clipboardView.IsMouseOverUI || stepByStepView.IsMouseOverUI;
	}

	public override void Enter(GameManager gameManager)
	{
	}

	public override void Execute(GameManager gameManager)
	{
		if (!Input.GetKey(KeyCode.LeftShift))
		{
			gameManager.ChangeState(ConstructionState.Instance);
			return;
		}
		bool isTranslating = gameManager.CameraManager.OrbitCamera.IsTranslating;
		bool isRotating = gameManager.CameraManager.OrbitCamera.IsRotating;
		if (!isTranslating && !isRotating)
		{
			groupMouseOverEvents.Run();
		}
	}

	public override void Exit(GameManager gameManager)
	{
		groupMouseOverEvents.Stop();
		selectedPivotPointObject.SetActive(value: false);
	}

	private void MouseOverBlockBodyObjectHandler(GameObject blockBodyObject)
	{
		bool keyDown = Input.GetKeyDown(KeyCode.C);
		bool keyDown2 = Input.GetKeyDown(KeyCode.X);
		bool keyDown3 = Input.GetKeyDown(KeyCode.M);
		if (!(keyDown || keyDown2 || keyDown3))
		{
			return;
		}
		BlockView blockView = blockBodyObject.GetBlockView();
		if (!(blockView == null))
		{
			if (keyDown)
			{
				CreationModel itemModel = BuildCreationModelFromGroup(blockView.GetAllInterconnectedBlocks());
				gameManager.ClipboardModel.AddItemModel(itemModel);
				gameManager.ClipboardModel.SelectedSlotIndex = 0;
				gameManager.ClipboardModel.FocusSlot();
				gameManager.ChangeState(ConstructionState.Instance);
			}
			if (keyDown2)
			{
				RemoveAllInterconnectedBlocks(blockView.GetAllInterconnectedBlocks());
				gameManager.UIAudioEffectsManager.PlayAudio(gameManager.GameStylesData.blockRemovedClip, gameManager.GameStylesData.volumeStylesData.uiVolume);
				gameManager.ChangeState(ConstructionState.Instance);
			}
			if (keyDown3)
			{
				CreationModel itemModel2 = BuildCreationModelFromGroup(blockView.GetAllInterconnectedBlocks());
				gameManager.ClipboardModel.AddItemModel(itemModel2);
				gameManager.ClipboardModel.SelectedSlotIndex = 0;
				gameManager.ClipboardModel.FocusSlot();
				RemoveAllInterconnectedBlocks(blockView.GetAllInterconnectedBlocks());
				gameManager.UIAudioEffectsManager.PlayAudio(gameManager.GameStylesData.blockRemovedClip, gameManager.GameStylesData.volumeStylesData.uiVolume);
				gameManager.ChangeState(ConstructionState.Instance);
			}
		}
	}

	private void MouseEnterConnectorHandler(GameObject mouseOverBlockBodyObject, Vector3 connectorPosition, Quaternion connectorRotation, Vector3 raycastHitNormal)
	{
		selectedPivotPointObject.SetActive(value: true);
		this.mouseOverBlockBodyObject = mouseOverBlockBodyObject;
	}

	private void MouseOverConnectorHandler(GameObject mouseOverBlockBodyObject, Vector3 connectorPosition, Quaternion connectorRotation, Vector3 raycastHitNormal)
	{
		selectedPivotPointObject.transform.SetPositionAndRotation(connectorPosition, connectorRotation);
	}

	private void MouseExitConnectorHandler()
	{
		selectedPivotPointObject.SetActive(value: false);
		mouseOverBlockBodyObject = null;
	}

	private CreationModel BuildCreationModelFromGroup(ICollection<BlockView> blockViews)
	{
		CreationModel clonedCreationModel = CreationCloner.Clone(gameManager.MainCreationController.model, shouldIncludeLogicSystem: false);
		List<int> list = new List<int>();
		foreach (BlockView blockView in blockViews)
		{
			list.Add(blockView.Id);
		}
		List<int> list2 = new List<int>();
		foreach (BlockModel item in clonedCreationModel.GetAllBlockModel())
		{
			if (!list.Contains(item.Id))
			{
				list2.Add(item.Id);
			}
		}
		list2.ForEach(delegate(int blockModelId)
		{
			clonedCreationModel.RemoveBlockModel(blockModelId);
		});
		if (selectedPivotPointObject.activeInHierarchy && mouseOverBlockBodyObject != null)
		{
			CreationUtil.SetPivotPoint(clonedCreationModel, mouseOverBlockBodyObject, selectedPivotPointObject);
		}
		clonedCreationModel.ResetBlocksIds();
		clonedCreationModel.Name = "";
		clonedCreationModel.Description = "";
		return clonedCreationModel;
	}

	private void RemoveAllInterconnectedBlocks(ICollection<BlockView> blockViews)
	{
		List<int> list = new List<int>();
		foreach (BlockView blockView in blockViews)
		{
			list.Add(blockView.Id);
		}
		RemoveBlocksGroupCommand command = new RemoveBlocksGroupCommand(gameManager.MainCreationController.model, list.ToArray());
		gameManager.ConstructionCommandManager.ExecuteNewCommand(command);
	}
}
