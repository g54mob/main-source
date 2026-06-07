using System.Collections.Generic;
using System.Linq;
using RLD;
using UnityEngine;

public class LevelEditorEvents
{
	private Transform objectSpawnTransform;

	private List<LevelObjectView> selectedLevelObjectViews;

	private List<GameObject> selectedObjectsPermanentList = new List<GameObject>();

	private LevelEditorToolsController levelEditorToolsController;

	private LEQuickInventoryController leQuickInventoryController;

	private LEClipboardController leClipboardController;

	private InspectorView inspectorView;

	private HashSet<LevelObjectView> levelObjectViewsClipboard;

	public LevelEditorEvents(Transform objectSpawnTransform)
	{
		this.objectSpawnTransform = objectSpawnTransform;
		selectedLevelObjectViews = new List<LevelObjectView>();
		levelObjectViewsClipboard = new HashSet<LevelObjectView>();
		levelEditorToolsController = GUIManager.Instance.LETopButtonsController.LevelEditorToolsController;
		leQuickInventoryController = GUIManager.Instance.LEQuickInventoryController;
		leClipboardController = GUIManager.Instance.LEClipboardController;
		inspectorView = GUIManager.Instance.InspectorView;
		inspectorView.OnPickingUpOutputForInput += OnPickingUpOutputForInputHandler;
		MonoSingleton<RLDApp>.Get.Initialized += delegate
		{
			RLD.Singleton<ObjectSelectEntireHierarchy>.Get.SetActive(isActive: false);
		};
		MonoSingleton<RTObjectSelection>.Get.Changed += ObjectSelectionChangedHandler;
		MonoSingleton<RTObjectSelection>.Get.PreSelectCustomize += PreSelectCustomizeHandler;
		MonoSingleton<RTObjectSelection>.Get.PreDeselectCustomize += PreDeselectCustomizeHandler;
		MonoSingleton<RTObjectSelection>.Get.Rotated += RotatedHandler;
		Gizmo moveGizmo = MonoSingleton<RTObjectSelectionGizmos>.Get.GetGizmoById(ObjectSelectionGizmoId.MoveGizmo);
		moveGizmo.PostDragUpdate += MoveGizmoPostDragHandler;
		moveGizmo.PostDragEnd += MoveGizmoPostDragHandler;
		Gizmo rotationGizmo = MonoSingleton<RTObjectSelectionGizmos>.Get.GetGizmoById(ObjectSelectionGizmoId.RotationGizmo);
		rotationGizmo.PostDragUpdate += RotationGizmoPostDragHandler;
		rotationGizmo.PostDragEnd += RotationGizmoPostDragHandler;
		Gizmo scaleGizmo = MonoSingleton<RTObjectSelectionGizmos>.Get.GetGizmoById(ObjectSelectionGizmoId.ScaleGizmo);
		scaleGizmo.PostDragUpdate += ScaleGizmoPostDragHandler;
		scaleGizmo.PostDragEnd += ScaleGizmoPostDragHandler;
		Gizmo boxGizmo = MonoSingleton<RTObjectSelectionGizmos>.Get.GetGizmoById(ObjectSelectionGizmoId.BoxScaleGizmo);
		boxGizmo.PostDragUpdate += BoxGizmoPostDragHandler;
		boxGizmo.PostDragEnd += BoxGizmoPostDragHandler;
		Gizmo extrudeGizmo = MonoSingleton<RTObjectSelectionGizmos>.Get.GetGizmoById(ObjectSelectionGizmoId.ExtrudeGizmo);
		extrudeGizmo.ObjectExtrudeGizmo.ExtrudeUpdate += ExtrudeUpdateHandler;
		Gizmo universalGizmo = MonoSingleton<RTObjectSelectionGizmos>.Get.GetGizmoById(ObjectSelectionGizmoId.UniversalGizmo);
		universalGizmo.PostDragUpdate += UniversalGizmoPostDragHandler;
		GUIManager.Instance.InspectorView.OnTransformChanged += delegate
		{
			moveGizmo.ObjectTransformGizmo.RefreshPositionAndRotation();
			rotationGizmo.ObjectTransformGizmo.RefreshPositionAndRotation();
			scaleGizmo.ObjectTransformGizmo.RefreshPositionAndRotation();
			boxGizmo.BoxGizmo.FitBoxToTargetHierarchy();
			extrudeGizmo.ObjectExtrudeGizmo.FitBoxToTargets();
			universalGizmo.ObjectTransformGizmo.RefreshPositionAndRotation();
		};
		MonoSingleton<RTObjectSelection>.Get.Enabled += ObjectSelectionEnabledHandler;
		MonoSingleton<RTObjectSelection>.Get.Disabled += ObjectSelectionDisabledHandler;
		MonoSingleton<RTObjectSelection>.Get.Deleted += ObjectSelectionDeleteHandler;
		MonoSingleton<RTObjectSelection>.Get.Duplicated += ObjectSelectionDuplicatedHandler;
		MonoSingleton<RTObjectSelection>.Get.ManipSessionBegin += ObjectSelectionManipSessionBeginEndHandler;
		MonoSingleton<RTObjectSelection>.Get.ManipSessionEnd += ObjectSelectionManipSessionBeginEndHandler;
		MonoSingleton<RTUndoRedo>.Get.UndoStart += UndoStartHandler;
		MonoSingleton<RTUndoRedo>.Get.RedoStart += RedoStartHandler;
		MonoSingleton<RTUndoRedo>.Get.RedoEnd += UndoRedoEndHandler;
		MonoSingleton<RTUndoRedo>.Get.UndoEnd += UndoRedoEndHandler;
		MonoSingleton<RTGizmosEngine>.Get.GetSceneGizmoByCamera(LevelEditorManager.Instance.LevelEditorCamera).OwnerGizmo.SetEnabled(enabled: false);
		leQuickInventoryController.OnSelectedSlotEvent += QuickInventoryOrClipboardFocusedHandler;
		leClipboardController.OnSelectedSlotEvent += QuickInventoryOrClipboardFocusedHandler;
		levelEditorToolsController.OnLevelEditorGizmoToolSelected += delegate
		{
			GUIManager.Instance.LEQuickInventoryController.model.UnfocusSelectedItem();
			GUIManager.Instance.LEClipboardController.model.UnfocusSlot();
			GUIManager.Instance.LEClipboardController.SetAllTogglesOff();
			MonoSingleton<RTObjectSelection>.Get.SetEnabled(isEnabled: true);
		};
		levelEditorToolsController.OnLevelEditorHandToolSelected += delegate
		{
			GUIManager.Instance.LEQuickInventoryController.model.UnfocusSelectedItem();
			GUIManager.Instance.LEClipboardController.model.UnfocusSlot();
			GUIManager.Instance.LEClipboardController.SetAllTogglesOff();
			GUIManager.Instance.InspectorView.SetVisibility(isVisible: false);
			MonoSingleton<RTObjectSelection>.Get.ClearSelection(allowUndoRedo: true);
			MonoSingleton<RTObjectSelection>.Get.SetEnabled(isEnabled: false);
		};
		levelEditorToolsController.OnLevelEditorLogicToolSelected += delegate
		{
			GUIManager.Instance.LEQuickInventoryController.model.UnfocusSelectedItem();
			GUIManager.Instance.LEClipboardController.model.UnfocusSlot();
			GUIManager.Instance.LEClipboardController.SetAllTogglesOff();
			GUIManager.Instance.InspectorView.SetVisibility(isVisible: false);
			MonoSingleton<RTObjectSelection>.Get.ClearSelection(allowUndoRedo: true);
			MonoSingleton<RTObjectSelection>.Get.SetEnabled(isEnabled: false);
		};
		void QuickInventoryOrClipboardFocusedHandler()
		{
			levelEditorToolsController.model.UnfocusLogicOrHandOrGizmoTool();
			levelEditorToolsController.model.IsPickingUpOutputForInput = false;
			GUIManager.Instance.InspectorView.SetVisibility(isVisible: false);
			MonoSingleton<RTObjectSelection>.Get.ClearSelection(allowUndoRedo: true);
			MonoSingleton<RTObjectSelection>.Get.SetEnabled(isEnabled: false);
		}
	}

	public void Run()
	{
		if (inspectorView.IsAnyInputFieldFocused || GameManager.Instance.GUIManager.LEPropertiesView.IsAnyInputFieldFocused)
		{
			SetGizmoToolsHotkeysActive(isActive: false);
			return;
		}
		SetGizmoToolsHotkeysActive(isActive: true);
		if (MonoSingleton<RTObjectSelection>.Get.IsGrabSessionActive || MonoSingleton<RTObjectSelection>.Get.IsObject2ObjectSnapSessionActive || MonoSingleton<RTObjectSelection>.Get.IsGridSnapSessionActive)
		{
			GUIManager.Instance.InspectorView.UpdatePositionValues();
			GUIManager.Instance.InspectorView.UpdateRotationValues();
			GUIManager.Instance.InspectorView.UpdateScaleValues();
		}
		if ((!MonoSingleton<RTObjectSelection>.Get.IsEnabled || MonoSingleton<RTObjectSelection>.Get.NumSelectedObjects == 0) && !IsCameraMoving())
		{
			bool flag = (levelEditorToolsController.model.IsHandToolEnabled && levelEditorToolsController.model.IsHandToolHoldingObject) || leQuickInventoryController.model.IsSelectedItemFocused || leClipboardController.model.IsItemFocused;
			if (Input.GetKeyDown(KeyCode.W))
			{
				levelEditorToolsController.SetWorkGizmoAndVisibility(ObjectSelectionGizmoId.MoveGizmo);
			}
			if (Input.GetKeyDown(KeyCode.E) && !flag)
			{
				levelEditorToolsController.SetWorkGizmoAndVisibility(ObjectSelectionGizmoId.RotationGizmo);
			}
			if (Input.GetKeyDown(KeyCode.R))
			{
				levelEditorToolsController.SetWorkGizmoAndVisibility(ObjectSelectionGizmoId.ScaleGizmo);
			}
			if (Input.GetKeyDown(KeyCode.T))
			{
				levelEditorToolsController.SetWorkGizmoAndVisibility(ObjectSelectionGizmoId.BoxScaleGizmo);
			}
			if (Input.GetKeyDown(KeyCode.Q) && !flag)
			{
				levelEditorToolsController.SetWorkGizmoAndVisibility(ObjectSelectionGizmoId.ExtrudeGizmo);
			}
			if (Input.GetKeyDown(KeyCode.U))
			{
				levelEditorToolsController.SetWorkGizmoAndVisibility(ObjectSelectionGizmoId.UniversalGizmo);
			}
		}
		if (Input.GetKeyDown(KeyCode.H))
		{
			levelEditorToolsController.model.FocusHandTool();
		}
		if (MonoSingleton<RTObjectSelectionGizmos>.Get.Hotkeys.ToggleTransformSpace.IsActiveInFrame())
		{
			levelEditorToolsController.InvertTransformSpaceToggle();
		}
		if (!Input.GetKey(KeyCode.LeftControl) || !Input.GetKeyDown(KeyCode.C) || !MonoSingleton<RTObjectSelection>.Get.IsEnabled)
		{
			return;
		}
		levelObjectViewsClipboard.Clear();
		foreach (GameObject selectedObject in MonoSingleton<RTObjectSelection>.Get.SelectedObjects)
		{
			LevelObjectView componentInParent = selectedObject.GetComponentInParent<LevelObjectView>();
			if (!(componentInParent == null) && (componentInParent.LevelObjectType == LevelObjectType.Structure || componentInParent.LevelObjectType == LevelObjectType.Dynamic || componentInParent.LevelObjectType == LevelObjectType.Active))
			{
				levelObjectViewsClipboard.Add(componentInParent);
			}
		}
		if (levelObjectViewsClipboard.Count > 0)
		{
			CustomLevelObjectsModel itemModel = LevelEditorManager.CreateCustomLevelObjectModel(levelObjectViewsClipboard.ToArray());
			GUIManager.Instance.LEClipboardController.model.AddItemModel(itemModel);
			GUIManager.Instance.LEClipboardController.model.FocusSlot();
		}
	}

	private void OnPickingUpOutputForInputHandler()
	{
		levelEditorToolsController.model.IsPickingUpOutputForInput = true;
	}

	public void SetToolsActivation(bool isActive)
	{
		if (!leQuickInventoryController.model.IsSelectedItemFocused && !leClipboardController.model.IsItemFocused && !levelEditorToolsController.model.IsHandToolEnabled)
		{
			MonoSingleton<RTObjectSelection>.Get.SetEnabled(isActive);
		}
	}

	public bool IsCameraMoving()
	{
		if (!MonoSingleton<RTFocusCamera>.Get.Hotkeys.LookAround.IsActive() && !MonoSingleton<RTFocusCamera>.Get.Hotkeys.Orbit.IsActive())
		{
			return LevelEditorManager.Instance.OrbitCamera.IsRotating;
		}
		return true;
	}

	private void ExtrudeUpdateHandler(List<GameObject> clones)
	{
		for (int i = 0; i < clones.Count; i++)
		{
			LevelObjectView component = clones[i].GetComponent<LevelObjectView>();
			if (!(component == null))
			{
				if (component.LevelObjectType == LevelObjectType.StartZone || component.LevelObjectType == LevelObjectType.EndZone)
				{
					Object.Destroy(component.gameObject);
				}
				else
				{
					clones[i].layer = ((component.LevelObjectType == LevelObjectType.Structure) ? LayerNames.LEScalable : LayerNames.LEUnscalable);
				}
			}
		}
	}

	private void ObjectSelectionChangedHandler(ObjectSelectionChangedEventArgs args)
	{
		selectedLevelObjectViews.Clear();
		List<GameObject> selectedObjects = MonoSingleton<RTObjectSelection>.Get.SelectedObjects;
		for (int i = 0; i < selectedObjects.Count; i++)
		{
			LevelObjectView component = selectedObjects[i].GetComponent<LevelObjectView>();
			if (component != null)
			{
				component.SetOutline(isEnabled: true, i % 3);
				selectedLevelObjectViews.Add(component);
			}
			selectedObjectsPermanentList.Add(selectedObjects[i]);
		}
		if (selectedLevelObjectViews.Count == 1)
		{
			GUIManager.Instance.InspectorView.SetLevelObjectView(selectedLevelObjectViews[0]);
		}
		GUIManager.Instance.InspectorView.SetVisibility(selectedLevelObjectViews.Count == 1);
		if (args.NumObjectsSelected > 0)
		{
			_ = GameManager.Instance;
		}
		List<GameObject> list = new List<GameObject>();
		selectedObjectsPermanentList.RemoveAll((GameObject item) => item == null);
		for (int num = 0; num < selectedObjectsPermanentList.Count; num++)
		{
			bool flag = false;
			for (int num2 = 0; num2 < selectedObjects.Count; num2++)
			{
				if (selectedObjectsPermanentList[num] == selectedObjects[num2])
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				selectedObjectsPermanentList[num]?.GetComponent<LevelObjectView>()?.SetOutline(isEnabled: false);
				list.Add(selectedObjectsPermanentList[num]);
			}
		}
		for (int num3 = 0; num3 < list.Count; num3++)
		{
			selectedObjectsPermanentList.Remove(list[num3]);
		}
	}

	private void PreSelectCustomizeHandler(ObjectPreSelectCustomizeInfo customizeInfo, List<GameObject> toBeSelected)
	{
		var (toBeSelected2, toBeIgnored) = GetLevelObjectViewSelections(toBeSelected);
		customizeInfo.SelectThese(toBeSelected2);
		customizeInfo.IgnoreThese(toBeIgnored);
	}

	private void PreDeselectCustomizeHandler(ObjectPreDeselectCustomizeInfo customizeInfo, List<GameObject> toBeDeselected)
	{
		var (toBeDeselected2, toBeIgnored) = GetLevelObjectViewSelections(toBeDeselected);
		customizeInfo.DeselectThese(toBeDeselected2);
		customizeInfo.IgnoreThese(toBeIgnored);
	}

	private (HashSet<GameObject>, HashSet<GameObject>) GetLevelObjectViewSelections(List<GameObject> toBeAnalyzed)
	{
		HashSet<GameObject> hashSet = new HashSet<GameObject>();
		HashSet<GameObject> hashSet2 = new HashSet<GameObject>();
		for (int i = 0; i < toBeAnalyzed.Count; i++)
		{
			LevelObjectView componentInParent = toBeAnalyzed[i].GetComponentInParent<LevelObjectView>();
			if (componentInParent != null)
			{
				hashSet.Add(componentInParent.gameObject);
				MeshRenderer[] allMeshRenderer = componentInParent.GetAllMeshRenderer();
				for (int j = 0; j < allMeshRenderer.Length; j++)
				{
					hashSet.Add(allMeshRenderer[j].gameObject);
				}
			}
			else
			{
				hashSet2.Add(toBeAnalyzed[i]);
			}
		}
		return (hashSet, hashSet2);
	}

	private void ObjectSelectionEnabledHandler()
	{
		List<GameObject> selectedObjects = MonoSingleton<RTObjectSelection>.Get.SelectedObjects;
		for (int i = 0; i < selectedObjects.Count; i++)
		{
			selectedObjects[i]?.GetComponent<LevelObjectView>()?.SetOutline(isEnabled: true, i % 3);
		}
	}

	private void ObjectSelectionDisabledHandler()
	{
		List<GameObject> selectedObjects = MonoSingleton<RTObjectSelection>.Get.SelectedObjects;
		for (int i = 0; i < selectedObjects.Count; i++)
		{
			selectedObjects[i]?.GetComponent<LevelObjectView>()?.SetOutline(isEnabled: false);
		}
	}

	private void ObjectSelectionDeleteHandler()
	{
		GameManager instance = GameManager.Instance;
		instance.UIAudioEffectsManager.PlayAudio(instance.GameStylesData.blockRemovedClip, instance.GameStylesData.volumeStylesData.uiVolume);
	}

	private void ObjectSelectionDuplicatedHandler(ObjectSelectionDuplicationResult result)
	{
		GameManager instance = GameManager.Instance;
		instance.UIAudioEffectsManager.PlayAudio(instance.GameStylesData.blockSelected, instance.GameStylesData.volumeStylesData.uiVolume);
	}

	private void ObjectSelectionManipSessionBeginEndHandler(ObjectSelectionManipSession session)
	{
		GameManager instance = GameManager.Instance;
		instance.UIAudioEffectsManager.PlayAudio(instance.GameStylesData.blockSelected, instance.GameStylesData.volumeStylesData.uiVolume);
	}

	private void MoveGizmoPostDragHandler(Gizmo gizmo, int handleId)
	{
		GUIManager.Instance.InspectorView.UpdatePositionValues();
	}

	private void RotationGizmoPostDragHandler(Gizmo gizmo, int handleId)
	{
		GUIManager.Instance.InspectorView.UpdateRotationValues();
	}

	private void ScaleGizmoPostDragHandler(Gizmo gizmo, int handleId)
	{
		GUIManager.Instance.InspectorView.UpdateScaleValues();
	}

	private void BoxGizmoPostDragHandler(Gizmo gizmo, int handleId)
	{
		GUIManager.Instance.InspectorView.UpdatePositionValues();
		GUIManager.Instance.InspectorView.UpdateScaleValues();
	}

	private void UniversalGizmoPostDragHandler(Gizmo gizmo, int handleId)
	{
		GUIManager.Instance.InspectorView.UpdatePositionValues();
		GUIManager.Instance.InspectorView.UpdateRotationValues();
		GUIManager.Instance.InspectorView.UpdateScaleValues();
	}

	private void RotatedHandler()
	{
		GUIManager.Instance.InspectorView.UpdateRotationValues();
	}

	private void UndoStartHandler(IUndoRedoAction action)
	{
		UndoRedoStartHandler();
		if (action is PostObjectSelectionChangedAction && (action as PostObjectSelectionChangedAction).PreChangeSnapshot.NumObjects > 0 && !MonoSingleton<RTObjectSelection>.Get.IsEnabled)
		{
			levelEditorToolsController.model.FocusDefaultGizmosTool();
		}
	}

	private void RedoStartHandler(IUndoRedoAction action)
	{
		UndoRedoStartHandler();
		if (action is PostObjectSelectionChangedAction && (action as PostObjectSelectionChangedAction).PostChangeSnapshot.NumObjects > 0 && !MonoSingleton<RTObjectSelection>.Get.IsEnabled)
		{
			levelEditorToolsController.model.FocusDefaultGizmosTool();
		}
	}

	private void UndoRedoStartHandler()
	{
		if (levelEditorToolsController.model.IsHandToolHoldingObject)
		{
			LevelEditorState.Instance.RestoreObjectPickupByHand();
		}
		if (levelEditorToolsController.model.IsPickingUpOutputForInput)
		{
			levelEditorToolsController.model.IsPickingUpOutputForInput = false;
		}
	}

	private void UndoRedoEndHandler(IUndoRedoAction action)
	{
		if (MonoSingleton<RTObjectSelection>.Get.IsEnabled && MonoSingleton<RTObjectSelection>.Get.NumSelectedObjects > 0 && !GUIManager.Instance.InspectorView.IsVisible)
		{
			Debug.Log("Inspector Not Visible!");
		}
		if (GUIManager.Instance.InspectorView.IsVisible)
		{
			GUIManager.Instance.InspectorView.RefreshPanelData();
		}
	}

	private void SetGizmoToolsHotkeysActive(bool isActive)
	{
		if (MonoSingleton<RTObjectSelectionGizmos>.Get.Hotkeys.ActivateMoveGizmo.IsEnabled != isActive)
		{
			MonoSingleton<RTObjectSelectionGizmos>.Get.Hotkeys.ActivateBoxScaleGizmo.IsEnabled = isActive;
			MonoSingleton<RTObjectSelectionGizmos>.Get.Hotkeys.ActivateExtrudeGizmo.IsEnabled = isActive;
			MonoSingleton<RTObjectSelectionGizmos>.Get.Hotkeys.ActivateMoveGizmo.IsEnabled = isActive;
			MonoSingleton<RTObjectSelectionGizmos>.Get.Hotkeys.ActivateRotationGizmo.IsEnabled = isActive;
			MonoSingleton<RTObjectSelectionGizmos>.Get.Hotkeys.ActivateScaleGizmo.IsEnabled = isActive;
			MonoSingleton<RTObjectSelectionGizmos>.Get.Hotkeys.ActivateUniversalGizmo.IsEnabled = isActive;
			MonoSingleton<RTObjectSelectionGizmos>.Get.Hotkeys.ToggleTransformSpace.IsEnabled = isActive;
			MonoSingleton<RTObjectSelection>.Get.Hotkeys.DeleteSelected.IsEnabled = isActive;
			MonoSingleton<RTObjectSelection>.Get.GrabHotkeys.ToggleGrab.IsEnabled = isActive;
			MonoSingleton<RTObjectSelection>.Get.Object2ObjectSnapHotkeys.ToggleSnap.IsEnabled = isActive;
			MonoSingleton<RTObjectSelection>.Get.GridSnapHotkeys.BeginGridSnap.IsEnabled = isActive;
			MonoSingleton<RTObjectSelection>.Get.RotationHotkeys.RotateAroundX.IsEnabled = isActive;
			MonoSingleton<RTObjectSelection>.Get.RotationHotkeys.RotateAroundY.IsEnabled = isActive;
			MonoSingleton<RTObjectSelection>.Get.RotationHotkeys.RotateAroundZ.IsEnabled = isActive;
			MonoSingleton<RTObjectSelection>.Get.RotationHotkeys.SetRotationToIdentity.IsEnabled = isActive;
		}
	}
}
