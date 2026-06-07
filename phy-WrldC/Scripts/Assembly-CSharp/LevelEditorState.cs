using RLD;
using UnityEngine;

public class LevelEditorState : State<GameManager>
{
	private struct ObjectSelectedByHandData
	{
		public GameObject gameObject;

		public Bounds bounds;

		public int originalLayer;

		public Vector3 originalPosition;

		public Quaternion originalRotation;
	}

	private LevelEditorManager levelEditorManager;

	private LEQuickInventoryController leQuickInventoryController;

	private LEClipboardController leClipboardController;

	private GameObject levelObjectPlaceholder;

	private Bounds levelObjectPlaceholderBounds;

	private LevelEditorToolsModel levelEditorToolsModel;

	private MouseOverObjectEvents gizmosMouseOverLevelObject;

	private MouseOverObjectEvents itemMouseOverLevelObject;

	private MouseOverObjectEvents handMouseOverLevelObject;

	private MouseOverObjectEvents logicMouseOverLevelObject;

	private MouseOverObjectEvents plugMouseOverLevelObject;

	private MouseOverPlaneEvents itemMouseOverLevelPlane;

	private MouseOverPlaneEvents handMouseOverLevelPlane;

	private ObjectSelectedByHandData objectSelectedByHandData;

	private GameManager gameManager;

	private float newLevelObjectRotation;

	private float newLevelObjectHeight;

	private bool isExitingPlugMouseOver;

	private LineComponent logicLinePlacehoder;

	private LevelObjectView levelObjectViewSelectedByLogic;

	public static LevelEditorState Instance { get; }

	static LevelEditorState()
	{
		Instance = new LevelEditorState();
	}

	private LevelEditorState()
	{
	}

	public override void Start(GameManager gameManager)
	{
		this.gameManager = gameManager;
		leQuickInventoryController = gameManager.GUIManager.LEQuickInventoryController;
		leQuickInventoryController.model.NotifyChangeEvent += QuickInventoryModelHandler;
		leClipboardController = gameManager.GUIManager.LEClipboardController;
		leClipboardController.model.NotifyChangeEvent += ClipboardModelHandler;
		levelEditorToolsModel = gameManager.LevelEditorToolsModel;
		LETopButtonsView leTopButtonsView = gameManager.GUIManager.LETopButtonsView;
		LEPropertiesView lePropertiesView = gameManager.GUIManager.LEPropertiesView;
		InspectorView inspectorView = gameManager.GUIManager.InspectorView;
		gizmosMouseOverLevelObject = new MouseOverObjectEvents(LayerNames.LevelMask | LayerNames.LEPermanentMask | LayerNames.LEScalableMask | LayerNames.LEUnscalableMask, "LevelEditor");
		gizmosMouseOverLevelObject.OnMouseEnterObject += GizmosMouseEnterLevelObjectHandler;
		gizmosMouseOverLevelObject.OnMouseOverObject += GizmosMouseOverLevelObjectHandler;
		gizmosMouseOverLevelObject.OnMouseExitObject += GizmosMouseExitLevelObjectHandler;
		gizmosMouseOverLevelObject.OnOverRestrictedZone += LocalOnOverRestrictedZone;
		gizmosMouseOverLevelObject.OnStop += GizmosMouseOverLevelObjectStopHandler;
		itemMouseOverLevelObject = new MouseOverObjectEvents(LayerNames.LevelMask | LayerNames.LEPermanentMask | LayerNames.LEScalableMask | LayerNames.LEUnscalableMask, "LevelEditor");
		itemMouseOverLevelObject.OnMouseEnterObject += ItemMouseEnterLevelObjectHandler;
		itemMouseOverLevelObject.OnMouseOverObject += ItemMouseOverLevelObjectHandler;
		itemMouseOverLevelObject.OnMouseExitObject += ItemMouseExitLevelObjectHandler;
		itemMouseOverLevelObject.OnOverRestrictedZone += LocalOnOverRestrictedZone;
		itemMouseOverLevelObject.OnStop += ItemMouseOverLevelObjectStopHandler;
		handMouseOverLevelObject = new MouseOverObjectEvents(LayerNames.LevelMask | LayerNames.LEPermanentMask | LayerNames.LEScalableMask | LayerNames.LEUnscalableMask, "LevelEditor");
		handMouseOverLevelObject.OnMouseEnterObject += HandMouseEnterLevelObjectHandler;
		handMouseOverLevelObject.OnMouseOverObject += HandMouseOverLevelObjectHandler;
		handMouseOverLevelObject.OnMouseExitObject += HandMouseExitLevelObjectHandler;
		handMouseOverLevelObject.OnOverRestrictedZone += LocalOnOverRestrictedZone;
		handMouseOverLevelObject.OnStop += HandMouseOverLevelObjectStopHandler;
		logicMouseOverLevelObject = new MouseOverObjectEvents(LayerNames.LevelMask | LayerNames.LEPermanentMask | LayerNames.LEScalableMask | LayerNames.LEUnscalableMask, "LevelEditor");
		logicMouseOverLevelObject.OnMouseEnterObject += LogicMouseEnterLevelObjectHandler;
		logicMouseOverLevelObject.OnMouseOverObject += LogicMouseOverLevelObjectHandler;
		logicMouseOverLevelObject.OnMouseExitObject += LogicMouseExitLevelObjectHandler;
		logicMouseOverLevelObject.OnOverRestrictedZone += LocalOnOverRestrictedZone;
		logicMouseOverLevelObject.OnStop += LogicMouseOverLevelObjectStopHandler;
		plugMouseOverLevelObject = new MouseOverObjectEvents(LayerNames.LevelMask | LayerNames.LEPermanentMask | LayerNames.LEScalableMask | LayerNames.LEUnscalableMask, "LevelEditor");
		plugMouseOverLevelObject.OnMouseEnterObject += PlugMouseEnterLevelObjectHandler;
		plugMouseOverLevelObject.OnMouseOverObject += PlugMouseOverLevelObjectHandler;
		plugMouseOverLevelObject.OnMouseExitObject += PlugMouseExitLevelObjectHandler;
		plugMouseOverLevelObject.OnOverRestrictedZone += LocalOnOverRestrictedZone;
		plugMouseOverLevelObject.OnStop += PlugMouseOverLevelObjectStopHandler;
		itemMouseOverLevelPlane = new MouseOverPlaneEvents();
		itemMouseOverLevelPlane.OnMouseEnterPlane += ItemMouseEnterLevelPlaneHandler;
		itemMouseOverLevelPlane.OnMouseOverPlane += ItemMouseOverLevelPlaneHandler;
		itemMouseOverLevelPlane.OnMouseExitPlane += ItemMouseExitLevelPlaneHandler;
		itemMouseOverLevelPlane.OnOverRestrictedZone += LocalOnOverRestrictedZone;
		itemMouseOverLevelPlane.OnStop += ItemMouseOverLevelPlaneStopHandler;
		handMouseOverLevelPlane = new MouseOverPlaneEvents();
		handMouseOverLevelPlane.OnMouseOverPlane += HandMouseOverLevelPlaneHandler;
		handMouseOverLevelPlane.OnOverRestrictedZone += LocalOnOverRestrictedZone;
		handMouseOverLevelPlane.OnStop += HandMouseOverLevelPlaneStopHandler;
		newLevelObjectRotation = 0f;
		newLevelObjectHeight = 0f;
		bool LocalOnOverRestrictedZone()
		{
			if (!leQuickInventoryController.view.IsMouseOverUI && !leClipboardController.view.IsMouseOverUI && !leTopButtonsView.IsMouseOverUI && !lePropertiesView.IsMouseOverUI)
			{
				return inspectorView.IsMouseOverUI;
			}
			return true;
		}
	}

	public override void Enter(GameManager gameManager)
	{
		levelEditorManager = gameManager.LevelEditorManager;
		levelEditorManager.Initialize();
		levelEditorManager.LoadLevelModel();
		levelEditorManager.SetUICamera(GUIManager.Instance.UICamera);
		logicLinePlacehoder = Object.Instantiate(levelEditorManager.LogicLinePrefab).GetComponent<LineComponent>();
		logicLinePlacehoder.Initialize(levelEditorManager.transform.parent);
		logicLinePlacehoder.SetVisibility(isVisible: false);
		gameManager.GUIManager.LETopButtonsController.LevelEditorToolsController.Initialize();
		gameManager.GUIManager.LEPropertiesController.Initialize();
		gizmosMouseOverLevelObject.Camera = levelEditorManager.LevelEditorCamera;
		itemMouseOverLevelObject.Camera = levelEditorManager.LevelEditorCamera;
		handMouseOverLevelObject.Camera = levelEditorManager.LevelEditorCamera;
		logicMouseOverLevelObject.Camera = levelEditorManager.LevelEditorCamera;
		plugMouseOverLevelObject.Camera = levelEditorManager.LevelEditorCamera;
		itemMouseOverLevelPlane.Camera = levelEditorManager.LevelEditorCamera;
		handMouseOverLevelPlane.Camera = levelEditorManager.LevelEditorCamera;
		gameManager.CameraManager.OrbitCamera.gameObject.SetActive(value: false);
		gameManager.GUIManager.LETopButtonsView.SetVisibility(isVisible: true);
		gameManager.GUIManager.LETopButtonsView.SetLevelInfos(levelEditorManager.LevelModel);
		gameManager.GUIManager.LEQuickInventoryView.SetVisibility(isVisible: true);
		gameManager.VisualEffectsManager.DestroyAllEffects();
		leQuickInventoryController.view.SetEditable(isEditable: false);
		leQuickInventoryController.model.UnfocusSelectedItem();
		leClipboardController.SetAllTogglesOff();
		levelEditorToolsModel.FocusDefaultGizmosTool();
		AudioClip sandboxLevelClip = gameManager.GameStylesData.musicStylesData.sandboxLevelClip;
		gameManager.MusicManager.PlayMusic(sandboxLevelClip, gameManager.GameStylesData.volumeStylesData.musicVolume);
		isExitingPlugMouseOver = false;
	}

	public override void EnterFromSubState(GameManager gameManager)
	{
		base.EnterFromSubState(gameManager);
		gameManager.GUIManager.LETopButtonsView.SetLevelInfos(levelEditorManager.LevelModel);
		LevelEditorManager.Instance.SetToolsActivation(isActive: true);
	}

	public override void Execute(GameManager gameManager)
	{
		levelEditorManager.RunLevelEditorEvents();
		bool flag = leQuickInventoryController.model.IsSelectedItemFocused || leClipboardController.model.IsItemFocused;
		if (flag || levelEditorToolsModel.IsHandToolEnabled)
		{
			if (levelEditorToolsModel.SnappingTypeValue == LevelEditorToolsModel.SnappingType.Surface)
			{
				if (flag)
				{
					StopMouseEvents(gizmos: true, itemSurface: false, handSurface: true, itemPlane: true, handPlane: true, logic: true);
					itemMouseOverLevelObject.Run();
				}
				else if (levelEditorToolsModel.IsHandToolEnabled)
				{
					StopMouseEvents(gizmos: true, itemSurface: true, handSurface: false, itemPlane: true, handPlane: true, logic: true);
					handMouseOverLevelObject.Run();
				}
			}
			else if (levelEditorToolsModel.SnappingTypeValue == LevelEditorToolsModel.SnappingType.Grid)
			{
				if (flag)
				{
					StopMouseEvents(gizmos: true, itemSurface: true, handSurface: true, itemPlane: false, handPlane: true, logic: true);
					if (0f - MonoSingleton<RTSceneGrid>.Get.Settings.YOffset != itemMouseOverLevelPlane.Plane.distance)
					{
						itemMouseOverLevelPlane.Plane = new Plane(Vector3.up, 0f - MonoSingleton<RTSceneGrid>.Get.Settings.YOffset);
					}
					itemMouseOverLevelPlane.Run();
				}
				else if (levelEditorToolsModel.IsHandToolEnabled)
				{
					StopMouseEvents(gizmos: true, itemSurface: true, handSurface: false, itemPlane: true, handPlane: false, logic: true);
					if (0f - MonoSingleton<RTSceneGrid>.Get.Settings.YOffset != handMouseOverLevelPlane.Plane.distance)
					{
						handMouseOverLevelPlane.Plane = new Plane(Vector3.up, 0f - MonoSingleton<RTSceneGrid>.Get.Settings.YOffset);
					}
					handMouseOverLevelObject.Run();
					handMouseOverLevelPlane.Run();
				}
			}
		}
		else if (levelEditorToolsModel.IsLogicToolEnabled)
		{
			StopMouseEvents(gizmos: true, itemSurface: true, handSurface: true, itemPlane: true, handPlane: true);
			logicMouseOverLevelObject.Run();
		}
		else if (!levelEditorToolsModel.IsPickingUpOutputForInput)
		{
			StopMouseEvents(gizmos: false, itemSurface: true, handSurface: true, itemPlane: true, handPlane: true, logic: true);
			gizmosMouseOverLevelObject.Run();
		}
		else
		{
			StopMouseEvents(gizmos: true, itemSurface: true, handSurface: true, itemPlane: true, handPlane: true, logic: true);
		}
		if (levelEditorToolsModel.IsPickingUpOutputForInput)
		{
			if (isExitingPlugMouseOver)
			{
				levelEditorToolsModel.IsPickingUpOutputForInput = false;
				plugMouseOverLevelObject.Stop();
				isExitingPlugMouseOver = false;
			}
			else
			{
				plugMouseOverLevelObject.Run();
				Ray ray = levelEditorManager.LevelEditorCamera.ScreenPointToRay(Input.mousePosition);
				int layerMask = LayerNames.LEPermanentMask | LayerNames.LEScalableMask | LayerNames.LEUnscalableMask | LayerNames.LevelMask;
				if (Physics.Raycast(ray, out var hitInfo, 100f, layerMask))
				{
					Vector3 center = GUIManager.Instance.InspectorView.GetSelectedLevelObjectView().GetAllMeshRenderersCombinedBounds().center;
					logicLinePlacehoder.SetVisibility(isVisible: true);
					logicLinePlacehoder.SetPositions(center, hitInfo.point);
				}
				else
				{
					logicLinePlacehoder.SetVisibility(isVisible: false);
				}
			}
		}
		else
		{
			logicLinePlacehoder.SetVisibility(isVisible: false);
		}
		if (!gameManager.GUIManager.InspectorView.IsAnyInputFieldFocused && !gameManager.GUIManager.LEPropertiesView.IsAnyInputFieldFocused)
		{
			ChangeSelectedLevelObject();
		}
		if (Input.GetKeyDown(KeyCode.I) && MonoSingleton<RTObjectSelection>.Get.SelectedObjects.Count == 0)
		{
			gameManager.SetSubState(LevelEditorInventoryState.Instance);
		}
		if (Input.GetKeyDown(KeyCode.P))
		{
			levelEditorManager.TestLevel();
		}
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			bool flag2 = false;
			if (MonoSingleton<RTObjectSelection>.Get.SelectedObjects.Count > 0)
			{
				levelEditorManager.ClearObjectsSelection();
				flag2 = true;
			}
			if (levelEditorToolsModel.IsPickingUpOutputForInput)
			{
				levelEditorToolsModel.IsPickingUpOutputForInput = false;
				flag2 = true;
			}
			if (RestoreObjectPickupByHand())
			{
				flag2 = true;
			}
			if (!flag2)
			{
				GUIManager.Instance.MessageBoxController.SetModel(MessageBoxModelCollection.ReturnToMainMenuFromLevelEditor);
				gameManager.SetSubState(MessageBoxState.Instance);
			}
		}
	}

	public override void Exit(GameManager gameManager)
	{
		gizmosMouseOverLevelObject.Stop();
		itemMouseOverLevelObject.Stop();
		handMouseOverLevelObject.Stop();
		logicMouseOverLevelObject.Stop();
		plugMouseOverLevelObject.Stop();
		itemMouseOverLevelPlane.Stop();
		handMouseOverLevelPlane.Stop();
		gameManager.GUIManager.LETopButtonsView.SetVisibility(isVisible: false);
		gameManager.GUIManager.LEPropertiesView.SetVisibility(isVisible: false);
		gameManager.GUIManager.InspectorView.SetVisibility(isVisible: false);
		gameManager.GUIManager.LEQuickInventoryView.SetVisibility(isVisible: false);
		gameManager.GUIManager.LEClipboardView.SetVisibility(isVisible: false);
		LevelEditorManager.Instance.SetToolsActivation(isActive: false);
		gameManager.UnloadLevelEditor();
	}

	public override void ExitToSubState(GameManager gameManager)
	{
		base.ExitToSubState(gameManager);
		gizmosMouseOverLevelObject.Stop();
		itemMouseOverLevelObject.Stop();
		handMouseOverLevelObject.Stop();
		logicMouseOverLevelObject.Stop();
		plugMouseOverLevelObject.Stop();
		itemMouseOverLevelPlane.Stop();
		handMouseOverLevelPlane.Stop();
		LevelEditorManager.Instance.SetToolsActivation(isActive: false);
	}

	private void GizmosMouseEnterLevelObjectHandler(RaycastHit objectRaycastHit)
	{
	}

	private void ItemMouseEnterLevelObjectHandler(RaycastHit objectRaycastHit)
	{
		UnhideLevelObjectPlaceholder();
	}

	private void HandMouseEnterLevelObjectHandler(RaycastHit objectRaycastHit)
	{
		if (objectSelectedByHandData.gameObject == null && !levelEditorManager.IsCameraMoving())
		{
			SetLevelObjectViewOutline(objectRaycastHit.collider.gameObject, isOn: true);
		}
	}

	private void LogicMouseEnterLevelObjectHandler(RaycastHit objectRaycastHit)
	{
		if (!levelEditorToolsModel.IsPickingUpOutputForInput)
		{
			LevelObjectView componentInParent = objectRaycastHit.collider.gameObject.GetComponentInParent<LevelObjectView>();
			if (componentInParent != null && componentInParent.LogicType == LevelObjectLogicType.Input)
			{
				componentInParent.SetOutline(isEnabled: true);
			}
		}
	}

	private void PlugMouseEnterLevelObjectHandler(RaycastHit objectRaycastHit)
	{
		LevelObjectView componentInParent = objectRaycastHit.collider.gameObject.GetComponentInParent<LevelObjectView>();
		if (componentInParent != null && componentInParent.LogicType == LevelObjectLogicType.Output)
		{
			componentInParent.SetOutline(isEnabled: true);
		}
	}

	private void GizmosMouseOverLevelObjectHandler(RaycastHit objectRaycastHit)
	{
		if (levelEditorManager.IsGizmoToolsBeingDragged() || levelEditorManager.IsCameraMoving())
		{
			if (!levelEditorManager.IsLevelObjectSelectedByGizmoTools(objectRaycastHit.collider.gameObject))
			{
				SetLevelObjectViewOutline(objectRaycastHit.collider.gameObject, isOn: false);
			}
		}
		else
		{
			SetLevelObjectViewOutline(objectRaycastHit.collider.gameObject, isOn: true);
		}
	}

	private void ItemMouseOverLevelObjectHandler(RaycastHit objectRaycastHit)
	{
		GameObject gameObject = levelObjectPlaceholder;
		Bounds levelObjectBounds = levelObjectPlaceholderBounds;
		float handSnapStep = levelEditorToolsModel.HandSnapStep;
		float snapStep = (levelEditorToolsModel.IsSnappingOn ? handSnapStep : (-1f));
		if (gameObject != null && !levelEditorManager.IsCameraMoving())
		{
			SnapLevelObjectToPoint(gameObject, levelObjectBounds, objectRaycastHit.point, objectRaycastHit.normal, snapStep);
		}
		if (Input.GetKeyUp(KeyCode.Mouse0))
		{
			CreateNewLevelObjectFromPlaceholder();
		}
	}

	private void HandMouseOverLevelObjectHandler(RaycastHit objectRaycastHit)
	{
		GameObject gameObject = objectSelectedByHandData.gameObject;
		Bounds bounds = objectSelectedByHandData.bounds;
		float handSnapStep = levelEditorToolsModel.HandSnapStep;
		float snapStep = (levelEditorToolsModel.IsSnappingOn ? handSnapStep : (-1f));
		if (gameObject != null && levelEditorToolsModel.SnappingTypeValue != LevelEditorToolsModel.SnappingType.Grid && !levelEditorManager.IsCameraMoving())
		{
			SnapLevelObjectToPoint(gameObject, bounds, objectRaycastHit.point, objectRaycastHit.normal, snapStep);
		}
		if (!Input.GetKeyUp(KeyCode.Mouse0))
		{
			return;
		}
		if (objectSelectedByHandData.gameObject != null)
		{
			objectSelectedByHandData.gameObject.SetLayersRecursively(objectSelectedByHandData.originalLayer, "LevelEditor");
			levelEditorToolsModel.IsHandToolHoldingObject = false;
			gameManager.UIAudioEffectsManager.PlayAudio(gameManager.GameStylesData.blockFixPlacedClip, gameManager.GameStylesData.volumeStylesData.uiVolume);
			new HandToolPositionChangedAction(objectSelectedByHandData.gameObject.transform, objectSelectedByHandData.originalPosition, objectSelectedByHandData.originalRotation, objectSelectedByHandData.gameObject.transform.position, objectSelectedByHandData.gameObject.transform.rotation).Execute();
			objectSelectedByHandData.gameObject = null;
			return;
		}
		LevelObjectView levelObjectView = objectRaycastHit.collider.gameObject.GetComponent<LevelObjectView>();
		if (levelObjectView == null)
		{
			levelObjectView = objectRaycastHit.collider.gameObject.GetComponentInParent<LevelObjectView>();
		}
		GameObject gameObject2 = levelObjectView.gameObject;
		if (gameObject2 != null && (gameObject2.layer == LayerNames.LEPermanent || gameObject2.layer == LayerNames.LEScalable || gameObject2.layer == LayerNames.LEUnscalable))
		{
			objectSelectedByHandData.originalPosition = gameObject2.transform.position;
			objectSelectedByHandData.originalRotation = gameObject2.transform.rotation;
			gameObject2.transform.SetPositionAndRotation(Vector3.zero, Quaternion.identity);
			objectSelectedByHandData.gameObject = gameObject2;
			objectSelectedByHandData.bounds = levelObjectView.GetAllMeshRenderersCombinedBounds();
			objectSelectedByHandData.originalLayer = gameObject2.layer;
			objectSelectedByHandData.gameObject.SetLayersRecursively(LayerNames.PlaceholderCreation, "LevelEditor");
			gameObject2.transform.SetPositionAndRotation(objectSelectedByHandData.originalPosition, objectSelectedByHandData.originalRotation);
			levelEditorToolsModel.IsHandToolHoldingObject = true;
			gameManager.UIAudioEffectsManager.PlayAudio(gameManager.GameStylesData.blockRemovedClip, gameManager.GameStylesData.volumeStylesData.uiVolume);
			newLevelObjectRotation = 0f;
			newLevelObjectHeight = 0f;
		}
	}

	private void LogicMouseOverLevelObjectHandler(RaycastHit objectRaycastHit)
	{
		if (levelEditorToolsModel.IsPickingUpOutputForInput)
		{
			return;
		}
		LevelObjectView componentInParent = objectRaycastHit.collider.gameObject.GetComponentInParent<LevelObjectView>();
		if (componentInParent == null || componentInParent.LogicType != LevelObjectLogicType.Input)
		{
			if (Input.GetKeyUp(KeyCode.Mouse0))
			{
				if (levelObjectViewSelectedByLogic != null)
				{
					levelObjectViewSelectedByLogic.SetOutline(isEnabled: false);
					gameManager.GUIManager.InspectorView.SetVisibility(isVisible: false);
				}
				levelObjectViewSelectedByLogic = null;
			}
		}
		else if (Input.GetKeyUp(KeyCode.Mouse0))
		{
			if (levelObjectViewSelectedByLogic != null && levelObjectViewSelectedByLogic != componentInParent)
			{
				levelObjectViewSelectedByLogic.SetOutline(isEnabled: false);
			}
			levelObjectViewSelectedByLogic = componentInParent;
			gameManager.GUIManager.InspectorView.SetVisibility(isVisible: true);
			gameManager.GUIManager.InspectorView.SetLevelObjectView(componentInParent, shouldOnlyShowLogicPanel: true);
		}
	}

	private void PlugMouseOverLevelObjectHandler(RaycastHit objectRaycastHit)
	{
		LevelObjectView componentInParent = objectRaycastHit.collider.gameObject.GetComponentInParent<LevelObjectView>();
		if (componentInParent == null || componentInParent.LogicType != LevelObjectLogicType.Output)
		{
			if (Input.GetKeyUp(KeyCode.Mouse0))
			{
				isExitingPlugMouseOver = true;
			}
		}
		else if (Input.GetKeyUp(KeyCode.Mouse0))
		{
			LevelObjectView levelObjectViewOutput = GUIManager.Instance.InspectorView.GetSelectedLevelObjectView().LevelObjectViewOutput;
			GUIManager.Instance.InspectorView.SetLogicOutputForInput(componentInParent);
			gameManager.UIAudioEffectsManager.PlayAudio(GameManager.Instance.GameStylesData.connectionMadeClip, GameManager.Instance.GameStylesData.volumeStylesData.uiVolume);
			isExitingPlugMouseOver = true;
			new LevelObjectLogicPlugedAction(GUIManager.Instance.InspectorView.GetSelectedLevelObjectView(), componentInParent, levelObjectViewOutput).Execute();
		}
	}

	private void GizmosMouseExitLevelObjectHandler(GameObject levelObject)
	{
		if (!levelEditorManager.IsLevelObjectSelectedByGizmoTools(levelObject))
		{
			SetLevelObjectViewOutline(levelObject, isOn: false);
		}
	}

	private void ItemMouseExitLevelObjectHandler(GameObject levelObject)
	{
		HideLevelObjectPlaceholder();
	}

	private void HandMouseExitLevelObjectHandler(GameObject levelObject)
	{
		SetLevelObjectViewOutline(levelObject, isOn: false);
	}

	private void LogicMouseExitLevelObjectHandler(GameObject levelObject)
	{
		if (!levelEditorToolsModel.IsPickingUpOutputForInput && levelObject.GetComponentInParent<LevelObjectView>() != levelObjectViewSelectedByLogic)
		{
			SetLevelObjectViewOutline(levelObject, isOn: false);
		}
	}

	private void PlugMouseExitLevelObjectHandler(GameObject levelObject)
	{
		if (levelEditorToolsModel.IsLogicToolEnabled)
		{
			LevelObjectView componentInParent = levelObject.GetComponentInParent<LevelObjectView>();
			if (componentInParent != null && componentInParent == levelObjectViewSelectedByLogic)
			{
				return;
			}
		}
		SetLevelObjectViewOutline(levelObject, isOn: false);
	}

	private void GizmosMouseOverLevelObjectStopHandler()
	{
	}

	private void ItemMouseOverLevelObjectStopHandler()
	{
		HideLevelObjectPlaceholder();
	}

	private void HandMouseOverLevelObjectStopHandler()
	{
		RestoreObjectPickupByHand();
	}

	private void LogicMouseOverLevelObjectStopHandler()
	{
		if (!levelEditorManager.IsGizmoToolsEnabledAndObjectsSelected())
		{
			gameManager.GUIManager.InspectorView.SetVisibility(isVisible: false);
		}
		if (levelObjectViewSelectedByLogic != null)
		{
			levelObjectViewSelectedByLogic.SetOutline(isEnabled: false);
		}
		levelObjectViewSelectedByLogic = null;
	}

	private void PlugMouseOverLevelObjectStopHandler()
	{
		logicLinePlacehoder.SetVisibility(isVisible: false);
		levelEditorToolsModel.IsPickingUpOutputForInput = false;
	}

	private void ItemMouseEnterLevelPlaneHandler(Vector3 hitPoint)
	{
		UnhideLevelObjectPlaceholder();
	}

	private void HandMouseEnterLevelPlaneHandler(Vector3 hitPoint)
	{
	}

	private void ItemMouseOverLevelPlaneHandler(Vector3 hitPoint)
	{
		float handSnapStep = levelEditorToolsModel.HandSnapStep;
		float snapStep = (levelEditorToolsModel.IsSnappingOn ? handSnapStep : (-1f));
		if (!levelEditorManager.IsCameraMoving())
		{
			SnapLevelObjectToPoint(levelObjectPlaceholder, levelObjectPlaceholderBounds, hitPoint, Vector3.up, snapStep);
		}
		if (Input.GetKeyUp(KeyCode.Mouse0))
		{
			CreateNewLevelObjectFromPlaceholder();
		}
	}

	private void HandMouseOverLevelPlaneHandler(Vector3 hitPoint)
	{
		GameObject gameObject = objectSelectedByHandData.gameObject;
		Bounds bounds = objectSelectedByHandData.bounds;
		float handSnapStep = levelEditorToolsModel.HandSnapStep;
		float snapStep = (levelEditorToolsModel.IsSnappingOn ? handSnapStep : (-1f));
		if (gameObject != null && !levelEditorManager.IsCameraMoving())
		{
			SnapLevelObjectToPoint(gameObject, bounds, hitPoint, Vector3.up, snapStep);
		}
	}

	private void ItemMouseExitLevelPlaneHandler()
	{
		HideLevelObjectPlaceholder();
	}

	private void HandMouseExitLevelPlaneHandler()
	{
	}

	private void ItemMouseOverLevelPlaneStopHandler()
	{
		HideLevelObjectPlaceholder();
	}

	private void HandMouseOverLevelPlaneStopHandler()
	{
		RestoreObjectPickupByHand();
	}

	public bool RestoreObjectPickupByHand()
	{
		if (objectSelectedByHandData.gameObject != null)
		{
			objectSelectedByHandData.gameObject.transform.position = objectSelectedByHandData.originalPosition;
			objectSelectedByHandData.gameObject.transform.rotation = objectSelectedByHandData.originalRotation;
			objectSelectedByHandData.gameObject.SetLayersRecursively(objectSelectedByHandData.originalLayer);
			objectSelectedByHandData.gameObject = null;
			levelEditorToolsModel.IsHandToolHoldingObject = false;
			return true;
		}
		return false;
	}

	private void SnapLevelObjectToPoint(GameObject levelObject, Bounds levelObjectBounds, Vector3 point, Vector3 normal, float snapStep = 0.5f)
	{
		bool num = snapStep > 0f;
		Vector3 position = point;
		if (num)
		{
			float x = (float)Mathf.RoundToInt(point.x / snapStep) * snapStep;
			float y = (float)Mathf.RoundToInt(point.y / snapStep) * snapStep;
			float z = (float)Mathf.RoundToInt(point.z / snapStep) * snapStep;
			position = new Vector3(x, y, z);
		}
		levelObject.transform.position = position;
		levelObject.transform.rotation = Quaternion.FromToRotation(Vector3.up, normal);
		if (num)
		{
			Vector3 vector = levelObject.transform.InverseTransformPoint(point);
			float y2 = levelObject.transform.localScale.y;
			levelObject.transform.Translate(0f, vector.y * y2, 0f, Space.Self);
		}
		float x2 = levelObjectBounds.center.x;
		float num2 = levelObjectBounds.center.y - levelObjectBounds.extents.y;
		float z2 = levelObjectBounds.center.z;
		levelObject.transform.Translate(0f - x2, 0f - num2, 0f - z2, Space.Self);
		UpdateLevelObjectRotation();
		UpdateLevelObjectHeight();
		Vector3 vector2 = levelObject.transform.localRotation * levelObjectBounds.center;
		levelObject.transform.Translate(0f, newLevelObjectHeight, 0f, Space.Self);
		levelObject.transform.RotateAround(levelObject.transform.position + vector2, levelObject.transform.up, newLevelObjectRotation);
	}

	private void CreateNewLevelObjectFromPlaceholder()
	{
		CustomLevelObjectsModel customLevelObjectsModel = leQuickInventoryController.model.GetSelectedItem();
		if (leClipboardController.model.IsItemFocused)
		{
			customLevelObjectsModel = leClipboardController.model.GetItemModel();
		}
		GameObject gameObject = new GameObject("NewCustomObjectsTemp");
		LevelObjectView[] array = LevelEditorManager.CreateMultableLevelObjectViews(customLevelObjectsModel, gameObject.transform);
		gameObject.transform.position = levelObjectPlaceholder.transform.position;
		gameObject.transform.rotation = levelObjectPlaceholder.transform.rotation;
		Bounds allMeshRenderersCombinedBounds = array[0].GetAllMeshRenderersCombinedBounds();
		for (int i = 0; i < array.Length; i++)
		{
			array[i].transform.SetParent(LevelEditorManager.Instance.LevelEditorObjectsFolder, worldPositionStays: true);
			if (i > 0)
			{
				allMeshRenderersCombinedBounds.Encapsulate(array[i].GetAllMeshRenderersCombinedBounds());
			}
		}
		if (gameManager.LEOptionsModel.IsAutoFocusActivated)
		{
			levelEditorManager.SetCameraFocus(allMeshRenderersCombinedBounds.center);
		}
		Object.Destroy(gameObject);
		gameManager.UIAudioEffectsManager.PlayAudio(gameManager.GameStylesData.blockFixPlacedClip, gameManager.GameStylesData.volumeStylesData.uiVolume);
		new AddNewLevelObjectsAction(array).Execute();
	}

	private void QuickInventoryModelHandler(string eventName, params object[] data)
	{
		if (GameManager.Instance.GetCurrentState() != this)
		{
			return;
		}
		switch (eventName)
		{
		case "QuickInventoryModelBase.SelectedTabIndexEvent":
		case "QuickInventoryModelBase.SelectedItemIndexEvent":
			if (leClipboardController.model.IsItemFocused)
			{
				leClipboardController.model.UnfocusSlot();
			}
			RemakeLevelObjectPlaceholder();
			itemMouseOverLevelObject.Stop();
			itemMouseOverLevelPlane.Stop();
			break;
		case "QuickInventoryModelBase.UnfocusSelectedItemEvent":
			itemMouseOverLevelObject.Stop();
			itemMouseOverLevelPlane.Stop();
			HideLevelObjectPlaceholder();
			break;
		}
	}

	private void ClipboardModelHandler(string eventName, params object[] data)
	{
		if (GameManager.Instance.GetCurrentState() != this)
		{
			return;
		}
		if (!(eventName == "ClipboardModelBase.FocusSlotEvent"))
		{
			if (eventName == "ClipboardModelBase.UnfocusSlotEvent")
			{
				itemMouseOverLevelObject.Stop();
				itemMouseOverLevelPlane.Stop();
				HideLevelObjectPlaceholder();
			}
			return;
		}
		if (leQuickInventoryController.model.IsSelectedItemFocused)
		{
			leQuickInventoryController.model.UnfocusSelectedItem();
		}
		RemakeLevelObjectPlaceholder();
		itemMouseOverLevelObject.Stop();
		itemMouseOverLevelPlane.Stop();
	}

	private void HideLevelObjectPlaceholder()
	{
		if (levelObjectPlaceholder != null && levelObjectPlaceholder.activeSelf)
		{
			levelObjectPlaceholder.SetActive(value: false);
		}
	}

	private void UnhideLevelObjectPlaceholder()
	{
		if (levelObjectPlaceholder != null && !levelObjectPlaceholder.activeSelf)
		{
			levelObjectPlaceholder.SetActive(value: true);
		}
	}

	private void RemakeLevelObjectPlaceholder()
	{
		if (levelObjectPlaceholder != null)
		{
			Object.Destroy(levelObjectPlaceholder);
		}
		CustomLevelObjectsModel customLevelObjectsModel = leQuickInventoryController.model.GetSelectedItem();
		if (leClipboardController.model.IsItemFocused)
		{
			customLevelObjectsModel = leClipboardController.model.GetItemModel();
		}
		levelObjectPlaceholder = new GameObject("LevelObjectPlaceholder");
		LevelObjectView[] array = LevelEditorManager.CreateMultableLevelObjectViews(customLevelObjectsModel, levelObjectPlaceholder.transform);
		levelObjectPlaceholderBounds = array[0].GetAllMeshRenderersCombinedBounds();
		for (int i = 0; i < array.Length; i++)
		{
			array[i].gameObject.SetLayersRecursively(LayerNames.PlaceholderCreation);
			array[i].TurnObjectTransparent();
			levelObjectPlaceholderBounds.Encapsulate(array[i].GetAllMeshRenderersCombinedBounds());
		}
		HideLevelObjectPlaceholder();
		newLevelObjectRotation = 0f;
		newLevelObjectHeight = 0f;
	}

	private void StopMouseEvents(bool gizmos = false, bool itemSurface = false, bool handSurface = false, bool itemPlane = false, bool handPlane = false, bool logic = false)
	{
		if (gizmos && gizmosMouseOverLevelObject.IsRunning)
		{
			gizmosMouseOverLevelObject.Stop();
		}
		if (itemSurface && itemMouseOverLevelObject.IsRunning)
		{
			itemMouseOverLevelObject.Stop();
		}
		if (handSurface && handMouseOverLevelObject.IsRunning)
		{
			handMouseOverLevelObject.Stop();
		}
		if (itemPlane && itemMouseOverLevelPlane.IsRunning)
		{
			itemMouseOverLevelPlane.Stop();
		}
		if (handPlane && handMouseOverLevelPlane.IsRunning)
		{
			handMouseOverLevelPlane.Stop();
		}
		if (logic && logicMouseOverLevelObject.IsRunning)
		{
			logicMouseOverLevelObject.Stop();
		}
	}

	private void UpdateLevelObjectRotation()
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
			newLevelObjectRotation += num;
			newLevelObjectRotation = ((newLevelObjectRotation >= 360f || newLevelObjectRotation <= -360f) ? 0f : newLevelObjectRotation);
			GameManager.Instance.UIAudioEffectsManager.PlayAudio(GameManager.Instance.GameStylesData.toolKeyPressedClip, GameManager.Instance.GameStylesData.volumeStylesData.uiVolume);
		}
	}

	private void UpdateLevelObjectHeight()
	{
		if (Input.GetKey(KeyCode.LeftAlt))
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
				newLevelObjectHeight += num;
				if (newLevelObjectHeight >= -5f && newLevelObjectHeight <= 5f)
				{
					GameManager.Instance.UIAudioEffectsManager.PlayAudio(GameManager.Instance.GameStylesData.blockHeightChangedClip, GameManager.Instance.GameStylesData.volumeStylesData.uiVolume * 0.5f);
				}
				newLevelObjectHeight = Mathf.Clamp(newLevelObjectHeight, -5f, 5f);
			}
			levelEditorManager.OrbitCamera.SetZoomActive(value: false);
		}
		else
		{
			levelEditorManager.OrbitCamera.SetZoomActive(value: true);
		}
	}

	private void SetLevelObjectViewOutline(GameObject levelObject, bool isOn)
	{
		levelObject.GetComponentInParent<LevelObjectView>()?.SetOutline(isOn);
	}

	private void ChangeSelectedLevelObject()
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
		LEQuickInventoryModel lEQuickInventoryModel = leQuickInventoryController.model as LEQuickInventoryModel;
		if (key)
		{
			if (num > lEQuickInventoryModel.TabCount() - 1)
			{
				num = lEQuickInventoryModel.TabCount() - 1;
			}
			if (num != lEQuickInventoryModel.SelectedTabIndex || !lEQuickInventoryModel.IsSelectedItemFocused)
			{
				lEQuickInventoryModel.SelectedTabIndex = num;
			}
		}
		else
		{
			if (num > lEQuickInventoryModel.ItemCount(lEQuickInventoryModel.SelectedTabIndex) - 1)
			{
				num = lEQuickInventoryModel.ItemCount(lEQuickInventoryModel.SelectedTabIndex) - 1;
			}
			if (num != lEQuickInventoryModel.SelectedItemIndex || !lEQuickInventoryModel.IsSelectedItemFocused)
			{
				lEQuickInventoryModel.SelectedItemIndex = num;
			}
		}
	}
}
