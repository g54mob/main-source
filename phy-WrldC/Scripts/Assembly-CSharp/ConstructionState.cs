using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ConstructionState : State<GameManager>
{
	private CreationModel placeholderCreationModel;

	private GameObject placeholderCreationObject;

	private GameObject placeholderConnectorObject;

	private MeshRenderer placeholderConnectorMeshRenderer;

	private PlaceholderCreation placeholderCreation;

	private CreationController placeholderCreationController;

	private Vector3 placeholderRealPosition;

	private Quaternion placeholderRealRotation;

	private Tweener placeholderPositionTweener;

	private Tweener placeholderRotationTweener;

	private bool shouldSetPlaceholderRealPosition;

	private Ruler ruler;

	private GameObject blockShadowObject;

	private float blockRotation;

	private bool isMultiConnectionsActive;

	private float newBlockHeightPosition;

	private QuickInventoryController quickInventoryController;

	private bool isQuickInventorySelected;

	private TopButtonsView topButtonsView;

	private ClipboardView clipboardView;

	private StepByStepView stepByStepView;

	private ConstructionToolsModel constructionToolsModel;

	private GameObject connectorFixedPrefab;

	private GameObject connectorHingePrefab;

	private ConstructionMouseOverEvents constructionMouseOverEvents;

	private MouseDragAndDropEvents mouseDragAndDropEvents;

	private BlockHighlightsHandler blockHighlightsHandler;

	private MultiConnectionsHandler multiConnectionsHandler;

	private bool isTwoPointBlock;

	private bool isFirstPointPicked;

	private AddTwoPointCommandData addTwoPointCommandData;

	private Vector3 firstPointPosition;

	private Quaternion firstPointRotation;

	private GameObject blockBodyObject;

	private TwoPointBlock twoPointBlock;

	private Command<ConstructionCommandFeedback> mergeCreationsCommand;

	private bool isAutoConnectionsActivated;

	public static ConstructionState Instance { get; }

	static ConstructionState()
	{
		Instance = new ConstructionState();
	}

	private ConstructionState()
	{
	}

	public override void Start(GameManager GAME)
	{
		clipboardView = GAME.GUIManager.ClipboardView;
		topButtonsView = GAME.GUIManager.TopButtonsView;
		stepByStepView = GAME.GUIManager.StepByStepView;
		quickInventoryController = GAME.QuickInventoryController;
		constructionToolsModel = GAME.ConstructionToolsModel;
		connectorFixedPrefab = GAME.connectorFixedPrefab;
		connectorHingePrefab = GAME.connectorHingePrefab;
		blockHighlightsHandler = new BlockHighlightsHandler(GAME);
		constructionMouseOverEvents = new ConstructionMouseOverEvents();
		constructionMouseOverEvents.OnMouseEnterBlockBodyObject += delegate(GameObject blockObject)
		{
			blockHighlightsHandler.MouseEnterBlockBodyHandler(blockObject);
		};
		constructionMouseOverEvents.OnMouseExitBlockBodyObject += blockHighlightsHandler.MouseExitBlockBodyHandler;
		constructionMouseOverEvents.OnMouseExitBlockBodyObject += delegate
		{
			MouseExitBlockHandler();
		};
		constructionMouseOverEvents.OnOverRestrictedZoneForBlock += () => topButtonsView.IsMouseOverUI || quickInventoryController.view.IsMouseOverUI || clipboardView.IsMouseOverUI || stepByStepView.IsMouseOverUI;
		constructionMouseOverEvents.OnMouseEnterConnector += delegate
		{
			MouseEnterConnectorHandler();
		};
		constructionMouseOverEvents.OnMouseExitConnector += MouseExitConnectorHandler;
		constructionMouseOverEvents.OnMouseEnterLevelObject += delegate
		{
			MouseEnterLevelObjectHandler(GAME);
		};
		constructionMouseOverEvents.OnMouseExitLevelObject += delegate
		{
			MouseExitLevelObjectHandler();
		};
		constructionMouseOverEvents.OnOverRestrictedZoneForLevel += () => topButtonsView.IsMouseOverUI || quickInventoryController.view.IsMouseOverUI || clipboardView.IsMouseOverUI || stepByStepView.IsMouseOverUI;
		constructionMouseOverEvents.OnMouseOverLevelObject += delegate(GameObject level, Vector3 point, Vector3 normal)
		{
			MouseOverLevelObjectHandler(GAME, point, normal);
		};
		constructionMouseOverEvents.OnMouseOverBlockBodyObject += delegate(GameObject block)
		{
			MouseOverBlockHandler(GAME, block);
		};
		constructionMouseOverEvents.OnMouseOverConnector += delegate(GameObject block, Vector3 pos, Quaternion rot, Vector3 normal)
		{
			MouseOverConnectorHandler(GAME, block, pos, rot, normal);
		};
		multiConnectionsHandler = new MultiConnectionsHandler(GAME);
		mouseDragAndDropEvents = new MouseDragAndDropEvents(LayerNames.BlockMask);
		mouseDragAndDropEvents.OnMouseStartDrag += delegate
		{
			MultiConnectionsActivedHandler();
		};
		mouseDragAndDropEvents.OnMouseStartDrag += multiConnectionsHandler.MouseStartDragHandler;
		mouseDragAndDropEvents.OnMouseDragging += multiConnectionsHandler.MouseDraggingHandler;
		mouseDragAndDropEvents.OnMouseValidDrop += multiConnectionsHandler.MouseValidDropHandler;
		mouseDragAndDropEvents.OnMouseEndDrop += multiConnectionsHandler.MouseEndDropHandler;
		mouseDragAndDropEvents.OnOverRestrictedZone += () => topButtonsView.IsMouseOverUI || quickInventoryController.view.IsMouseOverUI || clipboardView.IsMouseOverUI || stepByStepView.IsMouseOverUI;
		multiConnectionsHandler.OnCanConnectBlocks += CanConnectBlocksHandler;
		multiConnectionsHandler.OnRemoveConnectionBlocksEvent += RemoveConnectionBlocksHandler;
		multiConnectionsHandler.OnCannotConnectBlocks += CannotConnectBlocksHandler;
		isMultiConnectionsActive = false;
		isAutoConnectionsActivated = false;
		isTwoPointBlock = false;
		isFirstPointPicked = false;
		addTwoPointCommandData = default(AddTwoPointCommandData);
		newBlockHeightPosition = 0f;
		blockRotation = 0f;
		GameObject gameObject = UnityEngine.Object.Instantiate(GAME.rulerPrefab);
		gameObject.SetActive(value: false);
		ruler = gameObject.GetComponent<Ruler>();
		ruler.SetMainCamera(GAME.CameraManager.CamerasTransform);
		blockShadowObject = UnityEngine.Object.Instantiate(GAME.blockShadowPrefab);
		blockShadowObject.SetActive(value: false);
		quickInventoryController.model.NotifyChangeEvent += QuickInventoryModelHandler;
		GAME.ClipboardModel.NotifyChangeEvent += ClipboardModelHandler;
		placeholderCreationModel = quickInventoryController.model.GetSelectedItem();
		placeholderCreationController = CreationControllerBuilder.BuildPlaceholderController(placeholderCreationModel);
		isQuickInventorySelected = true;
		GAME.CameraManager.OrbitCamera.TargetMaskLayers = LayerNames.BlockMask;
		constructionToolsModel.NotifyChangeEvent += ConstructionTooslModelChangeHandler;
		GAME.ConstructionCommandManager.NotifyChangeEvent += ConstructionCommandManagerChangeHandler;
		GAME.MainCreationsManager.AttackerCreationController.OnChangedBlocksCountEvent += ChangedBlocksCountHandler;
		quickInventoryController.view.SetEditable(isEditable: false);
		quickInventoryController.OnModelChanged += delegate(QuickInventoryModelBase<CreationModel> model, QuickInventoryModelBase<CreationModel> lastModel)
		{
			if (lastModel != null)
			{
				lastModel.NotifyChangeEvent -= QuickInventoryModelHandler;
			}
			model.NotifyChangeEvent += QuickInventoryModelHandler;
			quickInventoryController.view.SetEditable(isEditable: false);
		};
		if (GAME.MainCreationController.model.BlockModelCount == 0)
		{
			newBlockHeightPosition = 1f;
		}
		placeholderRealPosition = GAME.MainCreationController.view.GetCreationBoundsCenter();
		placeholderRealRotation = GAME.MainCreationController.view.transform.rotation;
		GAME.CheatModel.NotifyChangeEvent += delegate(string eventName, object[] data)
		{
			if (eventName == "CheatModel.DelimitationZoneChangedEvent")
			{
				RemakePlaceholderCreation();
			}
		};
	}

	public override void Enter(GameManager GAME)
	{
		isFirstPointPicked = false;
		RemakePlaceholderCreation();
		GAME.CameraManager.RestoresMainCamera();
		GAME.LevelManager.SetLevelMode(isEditing: true);
		LevelUtil.SetLevelMusic(GAME.LevelController.model);
		topButtonsView.SetLevelEditorBackButtonVisibility(GAME.LevelType == GameManager.LevelTypeState.Test);
	}

	public override void Execute(GameManager GAME)
	{
		if (!GAME.MainCreationsManager.IsCreationsLoaded || GAME.GUIManager.TopButtonsView.QuickKeysController.IsKeyboardInUse)
		{
			return;
		}
		if (Input.GetKeyDown(KeyCode.LeftShift))
		{
			GameManager.Instance.ChangeState(GroupEditorState.Instance);
		}
		if (!isTwoPointBlock && isFirstPointPicked)
		{
			isFirstPointPicked = false;
		}
		if (!mouseDragAndDropEvents.Run())
		{
			if (!isMultiConnectionsActive)
			{
				RunConnection(GAME);
			}
			else
			{
				constructionMouseOverEvents.Stop();
				isMultiConnectionsActive = false;
			}
		}
		ChangeConnectorGridSize(GAME);
		ChangeSelectedCreation();
		UndoRedoCommands();
		bool flag = false;
		if (Input.GetKeyDown(KeyCode.C) && !Input.GetKey(KeyCode.LeftControl))
		{
			constructionToolsModel.IsHingeJointConnection = true;
			flag = true;
		}
		else if (Input.GetKeyUp(KeyCode.C) && !Input.GetKey(KeyCode.LeftControl))
		{
			constructionToolsModel.IsHingeJointConnection = false;
			flag = true;
		}
		if (Input.GetKeyDown(KeyCode.Space))
		{
			GAME.ResetCameraPosition();
		}
		if (Input.GetKeyDown(KeyCode.P))
		{
			GAME.PlayLevel();
		}
		if (Input.GetKeyDown(KeyCode.V))
		{
			GAME.ChangeState(BlockVisualizationState.Instance);
			flag = true;
		}
		if (Input.GetKeyDown(KeyCode.I))
		{
			GAME.ChangeState(InventoryState.Instance);
			flag = true;
		}
		Input.GetKeyDown(KeyCode.L);
		if (Input.GetKeyDown(KeyCode.M))
		{
			constructionToolsModel.IsMovingToolEnabled = true;
			flag = true;
		}
		if (flag)
		{
			GAME.UIAudioEffectsManager.PlayAudio(GAME.GameStylesData.toolKeyPressedClip, GAME.GameStylesData.volumeStylesData.uiVolume);
		}
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (isTwoPointBlock && isFirstPointPicked)
			{
				RemakePlaceholderCreation();
				constructionMouseOverEvents.Stop();
				return;
			}
			mouseDragAndDropEvents.Stop();
			MessageBoxModel model = ((GAME.LevelType != GameManager.LevelTypeState.Test) ? MessageBoxModelCollection.ReturnToMainMenu : MessageBoxModelCollection.ReturnToLevelEditorFromConstructionMode);
			GUIManager.Instance.MessageBoxController.SetModel(model);
			GAME.SetSubState(MessageBoxState.Instance);
		}
	}

	public override void Exit(GameManager GAME)
	{
		HidePlaceholderCreation();
		mouseDragAndDropEvents.Stop();
		constructionMouseOverEvents.Stop();
		isTwoPointBlock = false;
	}

	private void QuickInventoryModelHandler(string eventName, params object[] data)
	{
		if ((GameManager.Instance.GetCurrentState() == this || GameManager.Instance.GetCurrentState() == InventoryState.Instance) && (eventName == "QuickInventoryModelBase.SelectedTabIndexEvent" || eventName == "QuickInventoryModelBase.SelectedItemIndexEvent"))
		{
			if (GameManager.Instance.WhereIsPlaceholderCreation == GameManager.WhereIsPlaceholderCreationEnum.Clipboard)
			{
				GameManager.Instance.WhereIsPlaceholderCreation = GameManager.WhereIsPlaceholderCreationEnum.QuickInventory;
				GameManager.Instance.ClipboardModel.UnfocusSlot();
				isQuickInventorySelected = true;
			}
			RemakePlaceholderCreation();
			constructionMouseOverEvents.Stop();
		}
	}

	private void ClipboardModelHandler(string eventName, params object[] data)
	{
		if ((GameManager.Instance.GetCurrentState() == this || GameManager.Instance.GetCurrentState() == GroupEditorState.Instance) && eventName == "ClipboardModelBase.FocusSlotEvent")
		{
			if (GameManager.Instance.WhereIsPlaceholderCreation == GameManager.WhereIsPlaceholderCreationEnum.QuickInventory)
			{
				GameManager.Instance.WhereIsPlaceholderCreation = GameManager.WhereIsPlaceholderCreationEnum.Clipboard;
				quickInventoryController.model.UnfocusSelectedItem();
				isQuickInventorySelected = false;
			}
			RemakePlaceholderCreation();
			constructionMouseOverEvents.Stop();
		}
	}

	private void ConstructionTooslModelChangeHandler(string eventName, object[] data)
	{
		if (GameManager.Instance.GetCurrentState() != this)
		{
			return;
		}
		switch (eventName)
		{
		case "ConstructionToolsModel.UndoCommandEvent":
		case "ConstructionToolsModel.RedoCommandEvent":
			if (isTwoPointBlock)
			{
				isFirstPointPicked = false;
				RemakePlaceholderCreation();
			}
			break;
		case "ConstructionToolsModel.ConnectorGridSizeChangedEvent":
			blockHighlightsHandler.RedrawBlockConnectorsGrid();
			break;
		case "ConstructionToolsModel.ConnectionTypeChangedEvent":
			ChangePlaceholderCreationConnectionType();
			UpdateAutoConnectionsStatus();
			break;
		case "ConstructionToolsModel.AutoConnectionsChangedEvent":
			UpdateAutoConnectionsStatus();
			break;
		}
	}

	private void ConstructionCommandManagerChangeHandler(string eventName, object[] data)
	{
		if (GameManager.Instance.GetCurrentState() == this && eventName == "ConstructionCommandsModel.WarningMessageEvent")
		{
			string text = (string)data[0];
			GUIManager.Instance.WarningTooltipPanel.ShowWarningText(text, 40f, 0f);
		}
	}

	private void ChangedBlocksCountHandler(int blocksCount)
	{
		if (blocksCount == 0)
		{
			newBlockHeightPosition = 1f;
		}
		else
		{
			newBlockHeightPosition = 0f;
		}
	}

	private void RunConnection(GameManager GAME)
	{
		bool isTranslating = GAME.CameraManager.OrbitCamera.IsTranslating;
		bool isRotating = GAME.CameraManager.OrbitCamera.IsRotating;
		if (!isTranslating && !isRotating)
		{
			constructionMouseOverEvents.Run();
		}
	}

	private void MouseEnterLevelObjectHandler(GameManager GAME)
	{
		if (GAME.MainCreationController.view.BlockViewsCount() == 0)
		{
			UnhidePlaceholderCreation();
			placeholderConnectorMeshRenderer.enabled = false;
		}
		else
		{
			ruler.gameObject.SetActive(value: false);
			blockShadowObject.SetActive(value: false);
			HidePlaceholderCreation();
		}
	}

	private void MouseExitLevelObjectHandler()
	{
		HidePlaceholderCreation();
	}

	private void MouseOverLevelObjectHandler(GameManager GAME, Vector3 raycastHitPoint, Vector3 raycastHitNormal)
	{
		if (GAME.MainCreationController.model.BlockModelCount != 0)
		{
			return;
		}
		SetPlaceholderPosition(raycastHitPoint, Quaternion.FromToRotation(Vector3.forward, raycastHitNormal), isSmoothChangePosition: false);
		bool flag = placeholderCreation.IsColliding();
		if (newBlockHeightPosition > 0f)
		{
			if (flag)
			{
				ruler.SetColor(new Color(1f, 0f, 0f, 0.5f));
			}
			else
			{
				ruler.SetColor(new Color(0f, 1f, 0f, 0.5f));
			}
			ruler.ScaleBetweenTwoPoints.StartPosition = raycastHitPoint;
			ruler.ScaleBetweenTwoPoints.EndPosition = placeholderConnectorObject.transform.position;
			ruler.ScaleBetweenTwoPoints.UpdateScale();
			ruler.gameObject.SetActive(value: true);
		}
		else
		{
			ruler.gameObject.SetActive(value: false);
			blockShadowObject.SetActive(value: false);
		}
		if (!flag)
		{
			if (GAME.CameraManager.OrbitCamera.IsKeyboardVerticalTranslationActive)
			{
				GAME.CameraManager.OrbitCamera.SetKeyboardVerticalTranslationActive(isActive: false);
			}
			if (Input.GetKeyUp(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.B))
			{
				if (!isTwoPointBlock)
				{
					MergeCreationsCommandData data = new MergeCreationsCommandData
					{
						BaseCreationModel = GAME.MainCreationController.model,
						ToMergeCreationModel = placeholderCreationModel,
						BaseViewTransform = GAME.MainCreationController.view.transform,
						ToMergeViewTransform = placeholderCreationController.view.transform
					};
					GAME.ConstructionCommandManager.ExecuteNewCommand(new MergeCreationsCommand(data));
					constructionMouseOverEvents.Stop();
					GAME.UIAudioEffectsManager.PlayAudio(GAME.GameStylesData.blockFreePlacedClip, GAME.GameStylesData.volumeStylesData.uiVolume);
				}
				else
				{
					string text = LanguagesManager.Instance.GetText("warning.text.block.notextendable", "The first block can't be the extendable bar!");
					GUIManager.Instance.WarningTooltipPanel.ShowWarningText(text, 40f, 0f);
				}
			}
		}
		else
		{
			if (Input.GetKeyUp(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.B))
			{
				string text2 = LanguagesManager.Instance.GetText("warning.text.block.outside", "Can't place a block outside of the delimitation zone!");
				GUIManager.Instance.WarningTooltipPanel.ShowWarningText(text2, 40f, 0f);
			}
			if (!GAME.CameraManager.OrbitCamera.IsKeyboardVerticalTranslationActive)
			{
				GAME.CameraManager.OrbitCamera.SetKeyboardVerticalTranslationActive(isActive: true);
			}
		}
	}

	private void MouseExitBlockHandler()
	{
		HidePlaceholderCreation();
	}

	private void MouseOverBlockHandler(GameManager GAME, GameObject mouseOverBlockBodyObject)
	{
		bool key = Input.GetKey(KeyCode.LeftAlt);
		bool flag = key && Input.GetKeyDown(KeyCode.X);
		bool flag2 = (!key && Input.GetKeyDown(KeyCode.X)) || Input.GetKeyDown(KeyCode.Backspace) || Input.GetKeyDown(KeyCode.Delete);
		bool flag3 = Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.C);
		if (!(flag || flag2 || flag3))
		{
			return;
		}
		constructionMouseOverEvents.Stop();
		BlockBodyView blockBodyView = mouseOverBlockBodyObject.GetBlockBodyView();
		if (flag)
		{
			RemoveAllJointsCommand command = new RemoveAllJointsCommand(GAME.MainCreationController.model, blockBodyView.ParentBlockView.Id);
			GAME.ConstructionCommandManager.ExecuteNewCommand(command);
			GAME.UIAudioEffectsManager.PlayAudio(GAME.GameStylesData.blockRemovedClip, GAME.GameStylesData.volumeStylesData.uiVolume);
		}
		if (flag2)
		{
			GAME.ConstructionCommandManager.ExecuteNewCommand(new RemoveBlockCommand(GAME.MainCreationController.model, blockBodyView.ParentBlockView.Id));
			ResetPlaceholderCreation();
			if (isTwoPointBlock)
			{
				isFirstPointPicked = false;
				RemakePlaceholderCreation();
			}
			GAME.UIAudioEffectsManager.PlayAudio(GAME.GameStylesData.blockRemovedClip, GAME.GameStylesData.volumeStylesData.uiVolume);
		}
		if (!flag3)
		{
			return;
		}
		CreationModel creationModel = CreationModelBuilder.BuildCreationModelFromSchematic(blockBodyView.ParentBlockView.Schematic);
		BlockModel blockModel = GAME.MainCreationController.model.GetBlockModel(blockBodyView.ParentBlockView.Id);
		BlockModel blockModel2 = creationModel.GetBlockModel(0);
		foreach (BlockBodyModel allBlockBodyModel in blockModel.GetAllBlockBodyModels())
		{
			BlockBodyModel blockBodyModel = blockModel2.GetBlockBodyModel(allBlockBodyModel.Index);
			blockBodyModel.CopyAllDefaultKeyIOs(allBlockBodyModel);
			blockBodyModel.CopyAllOverridableProperties(allBlockBodyModel);
		}
		GAME.ClipboardModel.AddItemModel(creationModel);
		GAME.ClipboardModel.SelectedSlotIndex = 0;
		GAME.ClipboardModel.FocusSlot();
	}

	private void MouseEnterConnectorHandler()
	{
		UnhidePlaceholderCreation();
		GameManager.Instance.CameraManager.OrbitCamera.SetKeyboardVerticalTranslationActive(isActive: false);
	}

	private void MouseExitConnectorHandler()
	{
		HidePlaceholderCreation();
		GameManager.Instance.CameraManager.OrbitCamera.SetKeyboardVerticalTranslationActive(isActive: true);
		GameManager.Instance.CameraManager.OrbitCamera.SetZoomActive(value: true);
	}

	private void MouseOverConnectorHandler(GameManager GAME, GameObject mouseOverBlockBodyObject, Vector3 connectorPosition, Quaternion connectorRotation, Vector3 raycastHitNormal)
	{
		SetPlaceholderPosition(connectorPosition, connectorRotation, isSmoothChangePosition: true);
		bool flag = placeholderCreation.IsColliding();
		if (GAME.CheatModel.IsWithoutDelimitationZone)
		{
			flag = placeholderCreation.IsBlockColliding() || placeholderCreation.IsLevelObjectColliding();
		}
		if (newBlockHeightPosition > 0f)
		{
			if (flag)
			{
				ruler.SetColor(new Color(1f, 0f, 0f, 0.5f));
			}
			else
			{
				ruler.SetColor(new Color(0f, 1f, 0f, 0.5f));
			}
			ruler.ScaleBetweenTwoPoints.StartPosition = connectorPosition;
			ruler.ScaleBetweenTwoPoints.EndPosition = placeholderConnectorObject.transform.position;
			ruler.ScaleBetweenTwoPoints.UpdateScale();
			ruler.gameObject.SetActive(value: true);
			placeholderConnectorMeshRenderer.enabled = false;
		}
		else
		{
			ruler.gameObject.SetActive(value: false);
			placeholderConnectorMeshRenderer.enabled = true;
		}
		bool flag2 = false;
		if (isTwoPointBlock && isFirstPointPicked)
		{
			if (blockBodyObject == null)
			{
				BlockBodyView blockBodyView = placeholderCreationController.view.GetBlockView(0).GetBlockBodyView(0);
				blockBodyObject = blockBodyView.gameObject;
				twoPointBlock = blockBodyObject.GetComponent<TwoPointBlock>();
				if (twoPointBlock == null)
				{
					twoPointBlock = blockBodyObject.AddComponent<TwoPointBlock>();
				}
				twoPointBlock.ParentBlockBodyView = blockBodyView;
				twoPointBlock.Place = TwoPointBlock.PlaceEnum.PlaceholderModel;
			}
			twoPointBlock.endPointPosition = blockBodyObject.transform.InverseTransformPoint(firstPointPosition);
			twoPointBlock.endPointRotation = Quaternion.Inverse(blockBodyObject.transform.rotation) * firstPointRotation;
			twoPointBlock.MakeMesh();
			placeholderCreation.RefreshForTwoPointBlock(twoPointBlock.endPointPosition, twoPointBlock.endPointRotation);
			if (twoPointBlock.transform.position == firstPointPosition)
			{
				flag2 = true;
			}
		}
		if (!flag && !flag2)
		{
			bool num = !isAutoConnectionsActivated && Input.GetKeyUp(KeyCode.Mouse0) && newBlockHeightPosition == 0f;
			bool flag3 = isAutoConnectionsActivated && Input.GetKeyUp(KeyCode.Mouse0) && newBlockHeightPosition == 0f;
			bool flag4 = (Input.GetKeyDown(KeyCode.B) && !isTwoPointBlock) || (Input.GetKeyUp(KeyCode.Mouse0) && newBlockHeightPosition > 0f);
			if (num || flag3 || flag4)
			{
				placeholderPositionTweener?.Kill();
				placeholderRotationTweener?.Kill();
				placeholderConnectorObject.transform.position = placeholderRealPosition;
				placeholderConnectorObject.transform.rotation = placeholderRealRotation;
			}
			if (num)
			{
				BlockBodyView component;
				if (isTwoPointBlock && isFirstPointPicked)
				{
					addTwoPointCommandData.BaseCreationModel = GAME.MainCreationController.model;
					addTwoPointCommandData.BaseViewTransform = GAME.MainCreationController.view.transform;
					addTwoPointCommandData.EndPointPosition = placeholderCreationObject.transform.position;
					addTwoPointCommandData.EndPointRotation = placeholderCreationObject.transform.rotation;
					component = mouseOverBlockBodyObject.GetComponent<BlockBodyView>();
					addTwoPointCommandData.SecondBlockId = component.ParentBlockView.Id;
					addTwoPointCommandData.SecondBodyIndex = component.Index;
					addTwoPointCommandData.IsHingeJoint = constructionToolsModel.IsHingeJointConnection;
					addTwoPointCommandData.TargetPosition = placeholderConnectorObject.transform.position;
					addTwoPointCommandData.AxisDirection = placeholderConnectorObject.transform.forward;
					ConstructionCommandFeedback num2 = GAME.ConstructionCommandManager.ExecuteNewCommand(new AddTwoPointBlockCommand(mergeCreationsCommand, addTwoPointCommandData));
					RemakePlaceholderCreation();
					isFirstPointPicked = false;
					if (num2 == ConstructionCommandFeedback.Executed)
					{
						if (!addTwoPointCommandData.IsHingeJoint)
						{
							GAME.UIAudioEffectsManager.PlayAudio(GAME.GameStylesData.blockFixPlacedClip, GAME.GameStylesData.volumeStylesData.uiVolume);
						}
						else
						{
							GAME.UIAudioEffectsManager.PlayAudio(GAME.GameStylesData.blockHingePlacedClip, GAME.GameStylesData.volumeStylesData.uiVolume);
						}
					}
					return;
				}
				component = mouseOverBlockBodyObject.GetBlockBodyView();
				MergeCreationsCommandData data = new MergeCreationsCommandData
				{
					BaseCreationModel = GAME.MainCreationController.model,
					ToMergeCreationModel = placeholderCreationModel,
					BaseViewTransform = GAME.MainCreationController.view.transform,
					ToMergeViewTransform = placeholderCreationController.view.transform,
					SecondBlockId = component.ParentBlockView.Id,
					SecondBodyIndex = component.Index,
					TargetPosition = placeholderConnectorObject.transform.position,
					AxisDirection = placeholderConnectorObject.transform.forward
				};
				if (!constructionToolsModel.IsHingeJointConnection)
				{
					mergeCreationsCommand = new FixedMergeCreationsCommand(data, isWithFullInfo: true);
				}
				else
				{
					mergeCreationsCommand = new HingedMergeCreationsCommand(data);
				}
				if (isTwoPointBlock && !isFirstPointPicked)
				{
					firstPointPosition = placeholderCreationObject.transform.position;
					firstPointRotation = placeholderCreationObject.transform.rotation;
					isFirstPointPicked = true;
					blockBodyObject = null;
					if (mergeCreationsCommand is FixedMergeCreationsCommand)
					{
						GAME.UIAudioEffectsManager.PlayAudio(GAME.GameStylesData.blockFixPlacedClip, GAME.GameStylesData.volumeStylesData.uiVolume);
					}
					else
					{
						GAME.UIAudioEffectsManager.PlayAudio(GAME.GameStylesData.blockHingePlacedClip, GAME.GameStylesData.volumeStylesData.uiVolume);
					}
				}
				else if (GAME.ConstructionCommandManager.ExecuteNewCommand(mergeCreationsCommand) == ConstructionCommandFeedback.Executed)
				{
					if (mergeCreationsCommand is FixedMergeCreationsCommand)
					{
						GAME.UIAudioEffectsManager.PlayAudio(GAME.GameStylesData.blockFixPlacedClip, GAME.GameStylesData.volumeStylesData.uiVolume);
					}
					else
					{
						GAME.UIAudioEffectsManager.PlayAudio(GAME.GameStylesData.blockHingePlacedClip, GAME.GameStylesData.volumeStylesData.uiVolume);
					}
					if (constructionToolsModel.IsAutoFocusActivated)
					{
						GAME.CameraManager.OrbitCamera.SetTargetPosition(placeholderCreationController.view.GetCreationBoundsCenter());
					}
				}
			}
			if (flag3)
			{
				BlockBodyView component = mouseOverBlockBodyObject.GetBlockBodyView();
				MergeCreationsCommandData data2 = new MergeCreationsCommandData
				{
					BaseCreationModel = GAME.MainCreationController.model,
					ToMergeCreationModel = placeholderCreationModel,
					BaseViewTransform = GAME.MainCreationController.view.transform,
					ToMergeViewTransform = placeholderCreationController.view.transform,
					SecondBlockId = component.ParentBlockView.Id,
					SecondBodyIndex = component.Index,
					TargetPosition = placeholderConnectorObject.transform.position,
					AxisDirection = placeholderConnectorObject.transform.forward
				};
				Dictionary<BlockBodyView, List<BlockBodyView>> dictionary = new Dictionary<BlockBodyView, List<BlockBodyView>>();
				BlockView blockView = placeholderCreationController.view.GetBlockView(0);
				foreach (BlockBodyView allBlockBodyView in blockView.GetAllBlockBodyViews())
				{
					GameObject gameObject = BlockBodyViewBuilder.CreateLargeBlockBodyCollider(allBlockBodyView);
					Vector3 position = gameObject.transform.position;
					Collider[] components = gameObject.GetComponents<Collider>();
					Mesh mesh = allBlockBodyView.GetComponent<MeshFilter>().mesh;
					Vector3 center = gameObject.transform.TransformPoint(mesh.bounds.center);
					Vector3 halfExtents = mesh.bounds.size * 0.525f;
					Quaternion rotation = gameObject.transform.rotation;
					Collider[] array = Physics.OverlapBox(center, halfExtents, rotation, LayerNames.BlockMask);
					foreach (Collider collider in array)
					{
						BlockBodyView blockBodyView2 = collider.gameObject.GetBlockBodyView();
						if (collider.gameObject == allBlockBodyView.gameObject || blockBodyView2.ParentBlockView == blockView || component == blockBodyView2)
						{
							continue;
						}
						gameObject.transform.position = position;
						Vector3 position2 = Vector3.MoveTowards(gameObject.transform.position, blockBodyView2.gameObject.transform.position, 0.01f);
						gameObject.transform.position = position2;
						Collider[] array2 = components;
						foreach (Collider colliderB in array2)
						{
							if (Physics.ComputePenetration(collider, blockBodyView2.transform.position, blockBodyView2.transform.rotation, colliderB, gameObject.transform.position, gameObject.transform.rotation, out var _, out var _))
							{
								if (!dictionary.ContainsKey(allBlockBodyView))
								{
									dictionary.Add(allBlockBodyView, new List<BlockBodyView>());
								}
								if (!dictionary[allBlockBodyView].Contains(blockBodyView2))
								{
									dictionary[allBlockBodyView].Add(blockBodyView2);
								}
								break;
							}
						}
					}
					UnityEngine.Object.Destroy(gameObject);
				}
				if (GAME.ConstructionCommandManager.ExecuteNewCommand(new AutoFixedMergeCreationsCommand(data2, dictionary)) == ConstructionCommandFeedback.Executed)
				{
					GAME.UIAudioEffectsManager.PlayAudio(GAME.GameStylesData.blockFixPlacedClip, GAME.GameStylesData.volumeStylesData.uiVolume);
					if (constructionToolsModel.IsAutoFocusActivated)
					{
						GAME.CameraManager.OrbitCamera.SetTargetPosition(placeholderCreationController.view.GetCreationBoundsCenter());
					}
				}
				foreach (BlockBodyView key in dictionary.Keys)
				{
					Debug.Log(key.ParentBlockView.name + " [" + key.Index + "]  auto connect to:");
					foreach (BlockBodyView item in dictionary[key])
					{
						Debug.Log("\t -> " + item.ParentBlockView.name + " [" + item.Index + "] ");
					}
				}
			}
			if (!flag4)
			{
				return;
			}
			MergeCreationsCommandData data3 = new MergeCreationsCommandData
			{
				BaseCreationModel = GAME.MainCreationController.model,
				ToMergeCreationModel = placeholderCreationModel,
				BaseViewTransform = GAME.MainCreationController.view.transform,
				ToMergeViewTransform = placeholderCreationController.view.transform
			};
			if (GAME.ConstructionCommandManager.ExecuteNewCommand(new MergeCreationsCommand(data3)) == ConstructionCommandFeedback.Executed)
			{
				GAME.UIAudioEffectsManager.PlayAudio(GAME.GameStylesData.blockFreePlacedClip, GAME.GameStylesData.volumeStylesData.uiVolume);
				if (constructionToolsModel.IsAutoFocusActivated)
				{
					GAME.CameraManager.OrbitCamera.SetTargetPosition(placeholderCreationController.view.GetCreationBoundsCenter());
				}
			}
		}
		else if (Input.GetKeyUp(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.B))
		{
			string text = LanguagesManager.Instance.GetText("warning.text.block.collision", "Can't place a block in collision!");
			if (flag2)
			{
				text = LanguagesManager.Instance.GetText("warning.text.block.position", "Can't place the other part in the same position!");
			}
			GUIManager.Instance.WarningTooltipPanel.ShowWarningText(text, 40f, 0f);
		}
	}

	private void MultiConnectionsActivedHandler()
	{
		isMultiConnectionsActive = true;
		HidePlaceholderCreation();
		constructionMouseOverEvents.Stop();
	}

	private void CanConnectBlocksHandler(BlockBodyView firstBlockBodyView, BlockBodyView secondBlockBodyView)
	{
		int id = firstBlockBodyView.ParentBlockView.Id;
		int index = firstBlockBodyView.Index;
		int id2 = secondBlockBodyView.ParentBlockView.Id;
		int index2 = secondBlockBodyView.Index;
		GameManager.Instance.ConstructionCommandManager.ExecuteNewCommand(new ConnectBlocksCommand(GameManager.Instance.MainCreationController.model, id, index, id2, index2));
		GameManager.Instance.UIAudioEffectsManager.PlayAudio(GameManager.Instance.GameStylesData.blockFixPlacedClip, GameManager.Instance.GameStylesData.volumeStylesData.uiVolume);
	}

	private void RemoveConnectionBlocksHandler(BlockBodyView firstBlockBodyView, BlockBodyView secondBlockBodyView)
	{
		int id = firstBlockBodyView.ParentBlockView.Id;
		int index = firstBlockBodyView.Index;
		int id2 = secondBlockBodyView.ParentBlockView.Id;
		int index2 = secondBlockBodyView.Index;
		CreationModel model = GameManager.Instance.MainCreationController.model;
		BlockBodyModel blockBodyModel = model.GetBlockBodyModel(id, index);
		BlockBodyModel blockBodyModel2 = model.GetBlockBodyModel(id2, index2);
		bool wasJointFound = false;
		FixedJointModel toRemoveFixedJointModel = null;
		HingeJointModel toRemoveHingeJointModel = null;
		Action<ICollection<FixedJointModel>, BlockBodyModel> action = delegate(ICollection<FixedJointModel> allFixedJoints, BlockBodyModel bodyModel)
		{
			foreach (FixedJointModel allFixedJoint in allFixedJoints)
			{
				if (allFixedJoint.ConnectedBlockBodyModel == bodyModel)
				{
					toRemoveFixedJointModel = allFixedJoint;
					wasJointFound = true;
					break;
				}
			}
		};
		Action<ICollection<HingeJointModel>, BlockBodyModel> action2 = delegate(ICollection<HingeJointModel> allHingeJoints, BlockBodyModel bodyModel)
		{
			foreach (HingeJointModel allHingeJoint in allHingeJoints)
			{
				if (allHingeJoint.ConnectedBlockBodyModel == bodyModel)
				{
					toRemoveHingeJointModel = allHingeJoint;
					wasJointFound = true;
					break;
				}
			}
		};
		if (!wasJointFound)
		{
			action(blockBodyModel.GetAllFixedJointModel(), blockBodyModel2);
		}
		if (!wasJointFound)
		{
			action(blockBodyModel2.GetAllFixedJointModel(), blockBodyModel);
		}
		if (!wasJointFound)
		{
			action2(blockBodyModel.GetAllHingeJointModel(), blockBodyModel2);
		}
		if (!wasJointFound)
		{
			action2(blockBodyModel2.GetAllHingeJointModel(), blockBodyModel);
		}
		if (wasJointFound)
		{
			if (toRemoveFixedJointModel != null)
			{
				RemoveFixedJointCommand command = new RemoveFixedJointCommand(model, toRemoveFixedJointModel);
				GameManager.Instance.ConstructionCommandManager.ExecuteNewCommand(command);
			}
			else if (toRemoveHingeJointModel != null)
			{
				RemoveHingeJointCommand command2 = new RemoveHingeJointCommand(model, toRemoveHingeJointModel);
				GameManager.Instance.ConstructionCommandManager.ExecuteNewCommand(command2);
			}
			GameManager.Instance.UIAudioEffectsManager.PlayAudio(GameManager.Instance.GameStylesData.blockRemovedClip, GameManager.Instance.GameStylesData.volumeStylesData.uiVolume);
		}
	}

	private void CannotConnectBlocksHandler(BlockBodyView firstBlockBodyView, BlockBodyView secondBlockBodyView, MultiConnectionsHandler.WhyCannotConnect whyCannotConnect)
	{
		if (whyCannotConnect == MultiConnectionsHandler.WhyCannotConnect.NotTouching)
		{
			string text = LanguagesManager.Instance.GetText("warning.text.block.notclose", "The blocks must be close to connect them!");
			GUIManager.Instance.WarningTooltipPanel.ShowWarningText(text, 40f, 0f);
		}
	}

	private void OnCreationPositionChanged(Vector3 newPosition, Quaternion newRotation)
	{
		GameManager.Instance.ConstructionCommandManager.ExecuteNewCommand(new NewPositionCommand(GameManager.Instance.MainCreationController.model, newPosition, newRotation));
	}

	private void HidePlaceholderCreation()
	{
		if (placeholderConnectorObject.activeSelf)
		{
			placeholderConnectorObject.SetActive(value: false);
		}
		if (ruler.gameObject.activeSelf)
		{
			ruler.gameObject.SetActive(value: false);
		}
		ResetPlaceholderCreation();
	}

	private void UnhidePlaceholderCreation()
	{
		if (!placeholderConnectorObject.activeSelf)
		{
			placeholderConnectorObject.SetActive(value: true);
			shouldSetPlaceholderRealPosition = true;
		}
	}

	private void RemakePlaceholderCreation()
	{
		if (placeholderConnectorObject != null)
		{
			placeholderCreationController.view.transform.SetParent(null);
			UnityEngine.Object.Destroy(placeholderConnectorObject);
		}
		GameObject connectorModelPrefab = (constructionToolsModel.IsHingeJointConnection ? connectorHingePrefab : connectorFixedPrefab);
		placeholderCreationModel = GameManager.Instance.GetSelectedPlaceholderCreation();
		placeholderCreationController.SetModel(placeholderCreationModel);
		placeholderCreationObject = placeholderCreationController.view.gameObject;
		placeholderConnectorObject = CreationUtil.AddConnector(placeholderCreationController, connectorModelPrefab);
		placeholderConnectorMeshRenderer = placeholderConnectorObject.GetComponent<MeshRenderer>();
		placeholderCreation = placeholderCreationObject.GetComponent<PlaceholderCreation>();
		placeholderCreation.Populate();
		isTwoPointBlock = placeholderCreationModel.IsTwoPointBlock();
		if (isTwoPointBlock)
		{
			isFirstPointPicked = false;
		}
		GameManager.Instance.ConstructionToolsModel.IsHingeJointConnection = placeholderCreationModel.BlockModelCount == 1 && placeholderCreationModel.GetBlockModel(0).Schematic.Type == "locomotion";
		UpdateAutoConnectionsStatus();
		GameManager.Instance.SelectedCreationModel = placeholderCreationModel;
		placeholderConnectorObject.transform.position = placeholderRealPosition;
		placeholderConnectorObject.transform.rotation = placeholderRealRotation;
		if (GameManager.Instance.CheatModel.IsWithoutDelimitationZone)
		{
			placeholderCreation.SetCheckForDelimitationZone(shouldCheckForDelimitationZone: false);
		}
		HidePlaceholderCreation();
	}

	private void ChangePlaceholderCreationConnectionType()
	{
		if (!(placeholderConnectorObject == null))
		{
			Mesh sharedMesh;
			Material sharedMaterial;
			if (constructionToolsModel.IsHingeJointConnection)
			{
				sharedMesh = connectorHingePrefab.GetComponent<MeshFilter>().sharedMesh;
				sharedMaterial = connectorHingePrefab.GetComponent<MeshRenderer>().sharedMaterial;
			}
			else
			{
				sharedMesh = connectorFixedPrefab.GetComponent<MeshFilter>().sharedMesh;
				sharedMaterial = connectorFixedPrefab.GetComponent<MeshRenderer>().sharedMaterial;
			}
			placeholderConnectorObject.GetComponent<MeshFilter>().mesh = sharedMesh;
			placeholderConnectorObject.GetComponent<MeshRenderer>().sharedMaterial = sharedMaterial;
		}
	}

	private void ResetPlaceholderCreation()
	{
		if (placeholderCreation != null)
		{
			placeholderCreation.ResetStatus();
		}
	}

	private void SetPlaceholderPosition(Vector3 position, Quaternion orientation, bool isSmoothChangePosition)
	{
		UpdateBlockRotation();
		UpdateBlockHightPosition();
		placeholderRealPosition = position + orientation * (Vector3.forward * newBlockHeightPosition);
		placeholderRealRotation = Quaternion.Euler(orientation.eulerAngles.x, orientation.eulerAngles.y, orientation.eulerAngles.z + blockRotation);
		placeholderConnectorObject.transform.position = placeholderRealPosition;
		placeholderConnectorObject.transform.rotation = placeholderRealRotation;
	}

	private void UpdateAutoConnectionsStatus()
	{
		isAutoConnectionsActivated = GameManager.Instance.ConstructionToolsModel.IsAutoConnectionsActivated && placeholderCreationModel.BlockModelCount == 1 && !GameManager.Instance.ConstructionToolsModel.IsHingeJointConnection && !isTwoPointBlock;
	}

	private void UpdateBlockRotation()
	{
		bool keyDown = Input.GetKeyDown(KeyCode.E);
		bool keyDown2 = Input.GetKeyDown(KeyCode.Q);
		if (keyDown || keyDown2)
		{
			float num = 0f;
			if (keyDown)
			{
				num = 22.5f;
			}
			else if (keyDown2)
			{
				num = -22.5f;
			}
			blockRotation += num;
			blockRotation = ((blockRotation >= 360f || blockRotation <= -360f) ? 0f : blockRotation);
			GameManager.Instance.UIAudioEffectsManager.PlayAudio(GameManager.Instance.GameStylesData.toolKeyPressedClip, GameManager.Instance.GameStylesData.volumeStylesData.uiVolume);
		}
	}

	private void UpdateBlockHightPosition()
	{
		if (isTwoPointBlock)
		{
			newBlockHeightPosition = 0f;
		}
		else if (Input.GetKey(KeyCode.LeftAlt))
		{
			float axis = Input.GetAxis("Mouse ScrollWheel");
			if (axis != 0f)
			{
				float num = 0f;
				if (axis < 0f)
				{
					num = -0.25f;
				}
				else if (axis > 0f)
				{
					num = 0.25f;
				}
				newBlockHeightPosition += num;
				if (newBlockHeightPosition >= 0f && newBlockHeightPosition <= 5f)
				{
					GameManager.Instance.UIAudioEffectsManager.PlayAudio(GameManager.Instance.GameStylesData.blockHeightChangedClip, GameManager.Instance.GameStylesData.volumeStylesData.uiVolume * 0.5f);
				}
				newBlockHeightPosition = Mathf.Clamp(newBlockHeightPosition, 0f, 5f);
			}
			GameManager.Instance.CameraManager.OrbitCamera.SetZoomActive(value: false);
		}
		else
		{
			GameManager.Instance.CameraManager.OrbitCamera.SetZoomActive(value: true);
		}
	}

	private void UndoRedoCommands()
	{
		if (Input.GetKey(KeyCode.LeftControl) && (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Y)))
		{
			constructionMouseOverEvents.Stop();
			if (Input.GetKeyDown(KeyCode.Z))
			{
				constructionToolsModel.UndoCommand();
			}
			if (Input.GetKeyDown(KeyCode.Y))
			{
				constructionToolsModel.RedoCommand();
			}
			GameManager.Instance.UIAudioEffectsManager.PlayAudio(GameManager.Instance.GameStylesData.toolKeyPressedClip, GameManager.Instance.GameStylesData.volumeStylesData.uiVolume);
		}
	}

	private void ChangeConnectorGridSize(GameManager GAME)
	{
		if (Input.GetKeyDown(KeyCode.Equals) || Input.GetKeyDown(KeyCode.Minus))
		{
			if (Input.GetKeyDown(KeyCode.Equals))
			{
				constructionToolsModel.ConnectorGridSize++;
			}
			if (Input.GetKeyDown(KeyCode.Minus))
			{
				constructionToolsModel.ConnectorGridSize--;
			}
			GAME.UIAudioEffectsManager.PlayAudio(GAME.GameStylesData.toolKeyPressedClip, GAME.GameStylesData.volumeStylesData.uiVolume);
		}
	}

	private void ChangeSelectedCreation()
	{
		int num = -1;
		bool key = Input.GetKey(KeyCode.LeftControl);
		if (Input.GetKeyDown(KeyCode.Alpha1))
		{
			num = 0;
		}
		else if (Input.GetKeyDown(KeyCode.Alpha2))
		{
			num = 1;
		}
		else if (Input.GetKeyDown(KeyCode.Alpha3))
		{
			num = 2;
		}
		else if (Input.GetKeyDown(KeyCode.Alpha4))
		{
			num = 3;
		}
		else if (Input.GetKeyDown(KeyCode.Alpha5))
		{
			num = 4;
		}
		else if (Input.GetKeyDown(KeyCode.Alpha6))
		{
			num = 5;
		}
		else if (Input.GetKeyDown(KeyCode.Alpha7))
		{
			num = 6;
		}
		else if (Input.GetKeyDown(KeyCode.Alpha8))
		{
			num = 7;
		}
		else if (Input.GetKeyDown(KeyCode.Alpha9))
		{
			num = 8;
		}
		else if (Input.GetKeyDown(KeyCode.Alpha0))
		{
			num = 9;
		}
		if (num < 0)
		{
			return;
		}
		QuickInventoryModel quickInventoryModel = quickInventoryController.model as QuickInventoryModel;
		if (key)
		{
			if (num > quickInventoryModel.TabCount() - 1)
			{
				num = quickInventoryModel.TabCount() - 1;
			}
			if (num != quickInventoryModel.SelectedTabIndex || !isQuickInventorySelected)
			{
				quickInventoryModel.SelectedTabIndex = num;
			}
		}
		else
		{
			if (num > quickInventoryModel.ItemCount(quickInventoryModel.SelectedTabIndex) - 1)
			{
				num = quickInventoryModel.ItemCount(quickInventoryModel.SelectedTabIndex) - 1;
			}
			if (num != quickInventoryModel.SelectedItemIndex || !isQuickInventorySelected)
			{
				quickInventoryModel.SelectedItemIndex = num;
			}
		}
	}
}
