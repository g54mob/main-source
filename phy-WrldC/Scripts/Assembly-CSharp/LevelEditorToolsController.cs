using System;
using RLD;

public class LevelEditorToolsController : BaseController<LevelEditorToolsView, LevelEditorToolsModel>
{
	public event Action OnLevelEditorGizmoToolSelected;

	public event Action OnLevelEditorHandToolSelected;

	public event Action OnLevelEditorLogicToolSelected;

	public LevelEditorToolsController(LevelEditorToolsView view, LevelEditorToolsModel model)
		: base(view, model, false)
	{
	}

	public void Initialize()
	{
		Gizmo gizmoById = MonoSingleton<RTObjectSelectionGizmos>.Get.GetGizmoById(ObjectSelectionGizmoId.MoveGizmo);
		Gizmo gizmoById2 = MonoSingleton<RTObjectSelectionGizmos>.Get.GetGizmoById(ObjectSelectionGizmoId.RotationGizmo);
		Gizmo gizmoById3 = MonoSingleton<RTObjectSelectionGizmos>.Get.GetGizmoById(ObjectSelectionGizmoId.ScaleGizmo);
		Gizmo gizmoById4 = MonoSingleton<RTObjectSelectionGizmos>.Get.GetGizmoById(ObjectSelectionGizmoId.BoxScaleGizmo);
		Gizmo gizmoById5 = MonoSingleton<RTObjectSelectionGizmos>.Get.GetGizmoById(ObjectSelectionGizmoId.ExtrudeGizmo);
		Gizmo gizmoById6 = MonoSingleton<RTObjectSelectionGizmos>.Get.GetGizmoById(ObjectSelectionGizmoId.UniversalGizmo);
		gizmoById.PostEnabled += delegate
		{
			view.SetMoveToggleStatus(isSelected: true);
		};
		gizmoById2.PostEnabled += delegate
		{
			view.SetRotateToggleStatus(isSelected: true);
		};
		gizmoById3.PostEnabled += delegate
		{
			view.SetScaleToggleStatus(isSelected: true);
		};
		gizmoById4.PostEnabled += delegate
		{
			view.SetBoxToggleStatus(isSelected: true);
		};
		gizmoById5.PostEnabled += delegate
		{
			view.SetExtrudeToggleStatus(isSelected: true);
		};
		gizmoById6.PostEnabled += delegate
		{
			view.SetUniversalToggleStatus(isSelected: true);
		};
		ModelChangeHandler("LevelEditorToolsModel.MoveSnapStepChangedEvent");
		ModelChangeHandler("LevelEditorToolsModel.RotationSnapStepChangedEvent");
		ModelChangeHandler("LevelEditorToolsModel.ScaleSnapStepChangedEvent");
		ModelChangeHandler("LevelEditorToolsModel.IsGridVisibledEvent");
		view.SetUndoInterativity(isInteractable: false);
		view.SetRedoInterativity(isInteractable: false);
		MonoSingleton<RTUndoRedo>.Get.OnStackChanged += delegate(int undoCount, int redoCount)
		{
			view.SetUndoInterativity(undoCount > 0);
			view.SetRedoInterativity(redoCount > 0);
		};
	}

	protected override void SyncViewWithModel()
	{
		ModelChangeHandler("LevelEditorToolsModel.SnappingTypeEvent");
		ModelChangeHandler("LevelEditorToolsModel.SnapStepEvent");
		ModelChangeHandler("LevelEditorToolsModel.IsSnappingOnEvent");
		view.SetAutosFocusToggleStatus(GameManager.Instance.LEOptionsModel.IsAutoFocusActivated);
	}

	protected override void ModelChangeHandler(string eventName, params object[] data)
	{
		switch (eventName)
		{
		case "LevelEditorToolsModel.SnappingTypeEvent":
			if (model.SnappingTypeValue == LevelEditorToolsModel.SnappingType.Surface)
			{
				view.SetSurfaceSnappingToggleStatus(isSelected: true);
			}
			else
			{
				view.SetGridSnappingToggleStatus(isSelected: true);
			}
			break;
		case "LevelEditorToolsModel.MoveSnapStepChangedEvent":
			MonoSingleton<RTObjectSelectionGizmos>.Get.MoveGizmoSettings3D.SetXSnapStep(model.MoveSnapStep);
			MonoSingleton<RTObjectSelectionGizmos>.Get.MoveGizmoSettings3D.SetYSnapStep(model.MoveSnapStep);
			MonoSingleton<RTObjectSelectionGizmos>.Get.MoveGizmoSettings3D.SetZSnapStep(model.MoveSnapStep);
			MonoSingleton<RTObjectSelectionGizmos>.Get.MoveGizmoSettings2D.SetXSnapStep(model.MoveSnapStep);
			MonoSingleton<RTObjectSelectionGizmos>.Get.MoveGizmoSettings2D.SetYSnapStep(model.MoveSnapStep);
			MonoSingleton<RTObjectSelectionGizmos>.Get.UniversalGizmoSettings3D.SetMvXSnapStep(model.MoveSnapStep);
			MonoSingleton<RTObjectSelectionGizmos>.Get.UniversalGizmoSettings3D.SetMvYSnapStep(model.MoveSnapStep);
			MonoSingleton<RTObjectSelectionGizmos>.Get.UniversalGizmoSettings3D.SetMvZSnapStep(model.MoveSnapStep);
			MonoSingleton<RTObjectSelectionGizmos>.Get.UniversalGizmoSettings2D.SetMvXSnapStep(model.MoveSnapStep);
			MonoSingleton<RTObjectSelectionGizmos>.Get.UniversalGizmoSettings2D.SetMvYSnapStep(model.MoveSnapStep);
			break;
		case "LevelEditorToolsModel.RotationSnapStepChangedEvent":
			MonoSingleton<RTObjectSelectionGizmos>.Get.RotationGizmoSettings3D.SetAxisSnapStep(0, model.RotationSnapStep);
			MonoSingleton<RTObjectSelectionGizmos>.Get.RotationGizmoSettings3D.SetAxisSnapStep(1, model.RotationSnapStep);
			MonoSingleton<RTObjectSelectionGizmos>.Get.RotationGizmoSettings3D.SetAxisSnapStep(2, model.RotationSnapStep);
			MonoSingleton<RTObjectSelectionGizmos>.Get.UniversalGizmoSettings3D.SetRtAxisSnapStep(0, model.RotationSnapStep);
			MonoSingleton<RTObjectSelectionGizmos>.Get.UniversalGizmoSettings3D.SetRtAxisSnapStep(1, model.RotationSnapStep);
			MonoSingleton<RTObjectSelectionGizmos>.Get.UniversalGizmoSettings3D.SetRtAxisSnapStep(2, model.RotationSnapStep);
			break;
		case "LevelEditorToolsModel.ScaleSnapStepChangedEvent":
			MonoSingleton<RTObjectSelectionGizmos>.Get.ScaleGizmoSettings3D.SetXSnapStep(model.ScaleSnapStep);
			MonoSingleton<RTObjectSelectionGizmos>.Get.ScaleGizmoSettings3D.SetYSnapStep(model.ScaleSnapStep);
			MonoSingleton<RTObjectSelectionGizmos>.Get.ScaleGizmoSettings3D.SetZSnapStep(model.ScaleSnapStep);
			MonoSingleton<RTObjectSelectionGizmos>.Get.ScaleGizmoSettings3D.SetXYSnapStep(model.ScaleSnapStep);
			MonoSingleton<RTObjectSelectionGizmos>.Get.ScaleGizmoSettings3D.SetYZSnapStep(model.ScaleSnapStep);
			MonoSingleton<RTObjectSelectionGizmos>.Get.ScaleGizmoSettings3D.SetZXSnapStep(model.ScaleSnapStep);
			MonoSingleton<RTObjectSelectionGizmos>.Get.ScaleGizmoSettings3D.SetUniformScaleSnapStep(model.ScaleSnapStep);
			MonoSingleton<RTObjectSelectionGizmos>.Get.BoxScaleGizmoSettings3D.SetXSnapStep(model.ScaleSnapStep);
			MonoSingleton<RTObjectSelectionGizmos>.Get.BoxScaleGizmoSettings3D.SetYSnapStep(model.ScaleSnapStep);
			MonoSingleton<RTObjectSelectionGizmos>.Get.BoxScaleGizmoSettings3D.SetZSnapStep(model.ScaleSnapStep);
			MonoSingleton<RTObjectSelectionGizmos>.Get.UniversalGizmoSettings3D.SetScXSnapStep(model.ScaleSnapStep);
			MonoSingleton<RTObjectSelectionGizmos>.Get.UniversalGizmoSettings3D.SetScYSnapStep(model.ScaleSnapStep);
			MonoSingleton<RTObjectSelectionGizmos>.Get.UniversalGizmoSettings3D.SetScZSnapStep(model.ScaleSnapStep);
			MonoSingleton<RTObjectSelectionGizmos>.Get.UniversalGizmoSettings3D.SetScXYSnapStep(model.ScaleSnapStep);
			MonoSingleton<RTObjectSelectionGizmos>.Get.UniversalGizmoSettings3D.SetScYZSnapStep(model.ScaleSnapStep);
			MonoSingleton<RTObjectSelectionGizmos>.Get.UniversalGizmoSettings3D.SetScZXSnapStep(model.ScaleSnapStep);
			MonoSingleton<RTObjectSelectionGizmos>.Get.UniversalGizmoSettings3D.SetScUniformScaleSnapStep(model.ScaleSnapStep);
			break;
		case "LevelEditorToolsModel.IsGridVisibledEvent":
			MonoSingleton<RTSceneGrid>.Get.Settings.IsVisible = model.IsGridVisible;
			MonoSingleton<RTSceneGrid>.Get.Settings.YOffset = 0f;
			view.SetGridVisibilityToggleStatus(model.IsGridVisible);
			break;
		case "LevelEditorToolsModel.IsSnappingOnEvent":
			view.SetSnappingOnToggleStatus(model.IsSnappingOn);
			break;
		case "LevelEditorToolsModel.FocusDefaultGizmosToolEvent":
			SetWorkGizmoAndVisibility(ObjectSelectionGizmoId.MoveGizmo);
			break;
		case "LevelEditorToolsModel.FocusLogicToolEvent":
			model.IsHandToolEnabled = false;
			model.IsHandToolHoldingObject = false;
			model.IsPickingUpOutputForInput = false;
			view.SetLogicToggleStatus(isSelected: true);
			this.OnLevelEditorLogicToolSelected?.Invoke();
			break;
		case "LevelEditorToolsModel.FocusHandToolEvent":
			model.IsLogicToolEnabled = false;
			model.IsPickingUpOutputForInput = false;
			view.SetHandToggleStatus(isSelected: true);
			this.OnLevelEditorHandToolSelected?.Invoke();
			break;
		case "LevelEditorToolsModel.UnfocusHandOrGizmoToolEvent":
			view.UnfocusSelectedGizmoTool();
			break;
		case "LevelEditorToolsModel.IsPickingUpOutputForInputEvent":
			if (!model.IsLogicToolEnabled)
			{
				MonoSingleton<RTObjectSelection>.Get.SetEnabled(!model.IsPickingUpOutputForInput);
			}
			break;
		}
		switch (eventName)
		{
		case "LevelEditorToolsModel.SnappingTypeEvent":
		case "LevelEditorToolsModel.SnapStepEvent":
		case "LevelEditorToolsModel.MoveSnapStepChangedEvent":
		case "LevelEditorToolsModel.RotationSnapStepChangedEvent":
		case "LevelEditorToolsModel.ScaleSnapStepChangedEvent":
		case "LevelEditorToolsModel.IsGridVisibledEvent":
		case "LevelEditorToolsModel.IsSnappingOnEvent":
			GameManager.Instance.LEOptionsModel.SnappingType = model.SnappingTypeValue;
			GameManager.Instance.LEOptionsModel.HandSnapStep = model.HandSnapStep;
			GameManager.Instance.LEOptionsModel.MoveSnapStep = model.MoveSnapStep;
			GameManager.Instance.LEOptionsModel.RotationSnapStep = model.RotationSnapStep;
			GameManager.Instance.LEOptionsModel.ScaleSnapStep = model.ScaleSnapStep;
			GameManager.Instance.LEOptionsModel.IsGridVisible = model.IsGridVisible;
			GameManager.Instance.LEOptionsModel.IsSnappingOn = model.IsSnappingOn;
			GameManager.Instance.LEOptionsModel.SaveValuesOnDisk();
			break;
		}
	}

	protected override void ViewChangeHandler(string eventName, params object[] data)
	{
		switch (eventName)
		{
		case "LevelEditorToolsView.UndoButtonEvent":
			MonoSingleton<RTUndoRedo>.Get.Undo();
			break;
		case "LevelEditorToolsView.RedoButtonEvent":
			MonoSingleton<RTUndoRedo>.Get.Redo();
			break;
		case "LevelEditorToolsView.LogicToggleEvent":
			model.FocusLogicTool();
			break;
		case "LevelEditorToolsView.HandToggleEvent":
			model.FocusHandTool();
			break;
		case "LevelEditorToolsView.MoveToggleEvent":
			SetWorkGizmoAndVisibility(ObjectSelectionGizmoId.MoveGizmo);
			break;
		case "LevelEditorToolsView.RotateToggleEvent":
			SetWorkGizmoAndVisibility(ObjectSelectionGizmoId.RotationGizmo);
			break;
		case "LevelEditorToolsView.ScaleToggleEvent":
			SetWorkGizmoAndVisibility(ObjectSelectionGizmoId.ScaleGizmo);
			break;
		case "LevelEditorToolsView.BoxToggleEvent":
			SetWorkGizmoAndVisibility(ObjectSelectionGizmoId.BoxScaleGizmo);
			break;
		case "LevelEditorToolsView.ExtrudeToggleEvent":
			SetWorkGizmoAndVisibility(ObjectSelectionGizmoId.ExtrudeGizmo);
			break;
		case "LevelEditorToolsView.UniversalToggleEvent":
			SetWorkGizmoAndVisibility(ObjectSelectionGizmoId.UniversalGizmo);
			break;
		case "LevelEditorToolsView.InventoryButtonEvent":
			GameManager.Instance.SetSubState(LevelEditorInventoryState.Instance);
			break;
		case "LevelEditorToolsView.TransformSpaceToggleEvent":
		{
			bool flag = (bool)data[0];
			MonoSingleton<RTObjectSelectionGizmos>.Get.SetTransformSpace((!flag) ? GizmoSpace.Local : GizmoSpace.Global);
			break;
		}
		case "LevelEditorToolsView.GridVisibilityToggleEvent":
		{
			bool isGridVisible = (bool)data[0];
			model.IsGridVisible = isGridVisible;
			break;
		}
		case "LevelEditorToolsView.SnappingOnToggleEvent":
		{
			bool isSnappingOn = (bool)data[0];
			model.IsSnappingOn = isSnappingOn;
			break;
		}
		case "LevelEditorToolsView.SurfaceSnappingToggleEvent":
			model.SnappingTypeValue = LevelEditorToolsModel.SnappingType.Surface;
			break;
		case "LevelEditorToolsView.GridSnappingToggleEvent":
			model.SnappingTypeValue = LevelEditorToolsModel.SnappingType.Grid;
			break;
		case "LevelEditorToolsView.AutoFocusToggleEvent":
		{
			bool visibility = (bool)data[0];
			GameManager.Instance.LEOptionsModel.IsAutoFocusActivated = visibility;
			GameManager.Instance.LEOptionsModel.SaveValuesOnDisk();
			break;
		}
		case "LevelEditorToolsView.LevelPropertiesToggleEvent":
		{
			bool visibility = (bool)data[0];
			GameManager.Instance.GUIManager.LEPropertiesView.SetVisibility(visibility);
			break;
		}
		case "LevelEditorToolsView.ClearButtonEvent":
			LevelEditorManager.Instance.ClearObjectsSelection();
			MonoSingleton<RTUndoRedo>.Get.ClearActions();
			LevelEditorManager.Instance.ClearLevelCustomObjects();
			break;
		}
	}

	public void SetWorkGizmoAndVisibility(int gizmoId)
	{
		model.IsLogicToolEnabled = false;
		model.IsHandToolEnabled = false;
		model.IsHandToolHoldingObject = false;
		model.IsPickingUpOutputForInput = false;
		MonoSingleton<RTObjectSelectionGizmos>.Get.SetWorkGizmo(gizmoId);
		MonoSingleton<RTObjectSelectionGizmos>.Get.WorkGizmo.SetEnabled(MonoSingleton<RTObjectSelection>.Get.NumSelectedObjects != 0);
		if (!MonoSingleton<RTObjectSelectionGizmos>.Get.WorkGizmo.IsEnabled)
		{
			if (gizmoId == ObjectSelectionGizmoId.MoveGizmo)
			{
				view.SetMoveToggleStatus(isSelected: true);
			}
			else if (gizmoId == ObjectSelectionGizmoId.RotationGizmo)
			{
				view.SetRotateToggleStatus(isSelected: true);
			}
			else if (gizmoId == ObjectSelectionGizmoId.ScaleGizmo)
			{
				view.SetScaleToggleStatus(isSelected: true);
			}
			else if (gizmoId == ObjectSelectionGizmoId.BoxScaleGizmo)
			{
				view.SetBoxToggleStatus(isSelected: true);
			}
			else if (gizmoId == ObjectSelectionGizmoId.ExtrudeGizmo)
			{
				view.SetExtrudeToggleStatus(isSelected: true);
			}
			else if (gizmoId == ObjectSelectionGizmoId.UniversalGizmo)
			{
				view.SetUniversalToggleStatus(isSelected: true);
			}
		}
		this.OnLevelEditorGizmoToolSelected?.Invoke();
	}

	public void InvertTransformSpaceToggle()
	{
		view.InvertTransformSpaceToggleStatus();
	}
}
