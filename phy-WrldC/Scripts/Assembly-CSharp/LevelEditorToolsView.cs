using UnityEngine.UI;

public class LevelEditorToolsView : BaseGUIPanelView
{
	public const string UndoButtonEvent = "LevelEditorToolsView.UndoButtonEvent";

	public const string RedoButtonEvent = "LevelEditorToolsView.RedoButtonEvent";

	public const string LogicToggleEvent = "LevelEditorToolsView.LogicToggleEvent";

	public const string HandToggleEvent = "LevelEditorToolsView.HandToggleEvent";

	public const string MoveToggleEvent = "LevelEditorToolsView.MoveToggleEvent";

	public const string RotateToggleEvent = "LevelEditorToolsView.RotateToggleEvent";

	public const string ScaleToggleEvent = "LevelEditorToolsView.ScaleToggleEvent";

	public const string BoxToggleEvent = "LevelEditorToolsView.BoxToggleEvent";

	public const string ExtrudeToggleEvent = "LevelEditorToolsView.ExtrudeToggleEvent";

	public const string UniversalToggleEvent = "LevelEditorToolsView.UniversalToggleEvent";

	public const string InventoryButtonEvent = "LevelEditorToolsView.InventoryButtonEvent";

	public const string TransformSpaceToggleEvent = "LevelEditorToolsView.TransformSpaceToggleEvent";

	public const string GridVisibilityToggleEvent = "LevelEditorToolsView.GridVisibilityToggleEvent";

	public const string SnappingOnToggleEvent = "LevelEditorToolsView.SnappingOnToggleEvent";

	public const string SurfaceSnappingToggleEvent = "LevelEditorToolsView.SurfaceSnappingToggleEvent";

	public const string GridSnappingToggleEvent = "LevelEditorToolsView.GridSnappingToggleEvent";

	public const string AutoFocusToggleEvent = "LevelEditorToolsView.AutoFocusToggleEvent";

	public const string LevelPropertiesToggleEvent = "LevelEditorToolsView.LevelPropertiesToggleEvent";

	public const string ClearButtonEvent = "LevelEditorToolsView.ClearButtonEvent";

	private Button undoButton;

	private Button redoButton;

	private ToggleGroup gizmosToolsToggleGroup;

	private Toggle logicToggle;

	private Toggle handToggle;

	private Toggle moveToggle;

	private Toggle rotateToggle;

	private Toggle scaleToggle;

	private Toggle boxToggle;

	private Toggle extrudeToggle;

	private Toggle universalToggle;

	private Button inventoryButton;

	private Toggle transformSpaceToggle;

	private Toggle gridVisibilityToggle;

	private Toggle snappingOnToggle;

	private Toggle surfaceSnappingToggle;

	private Toggle gridSnappingToggle;

	private Toggle autoFocusToggle;

	private Toggle levelPropertiesToggle;

	private Button clearButton;

	public LevelEditorToolsView(LETopButtonsView leTopButtonsView)
	{
		base.MainPanel = leTopButtonsView.mainPanel.transform.FindChildRecursively("LevelEditorToolsPanel").gameObject;
		undoButton = base.MainPanel.transform.FindComponent<Button>("UndoButton", isRecursively: true);
		redoButton = base.MainPanel.transform.FindComponent<Button>("RedoButton", isRecursively: true);
		gizmosToolsToggleGroup = base.MainPanel.transform.FindComponent<ToggleGroup>("GizmosTools", isRecursively: true);
		logicToggle = base.MainPanel.transform.FindComponent<Toggle>("LogicToggle", isRecursively: true);
		handToggle = base.MainPanel.transform.FindComponent<Toggle>("HandToggle", isRecursively: true);
		moveToggle = base.MainPanel.transform.FindComponent<Toggle>("MoveToggle", isRecursively: true);
		rotateToggle = base.MainPanel.transform.FindComponent<Toggle>("RotateToggle", isRecursively: true);
		scaleToggle = base.MainPanel.transform.FindComponent<Toggle>("ScaleToggle", isRecursively: true);
		boxToggle = base.MainPanel.transform.FindComponent<Toggle>("BoxToggle", isRecursively: true);
		extrudeToggle = base.MainPanel.transform.FindComponent<Toggle>("ExtrudeToggle", isRecursively: true);
		universalToggle = base.MainPanel.transform.FindComponent<Toggle>("UniversalToggle", isRecursively: true);
		inventoryButton = base.MainPanel.transform.FindComponent<Button>("InventoryButton", isRecursively: true);
		transformSpaceToggle = base.MainPanel.transform.FindComponent<Toggle>("TransformSpaceToggle", isRecursively: true);
		gridVisibilityToggle = base.MainPanel.transform.FindComponent<Toggle>("GridVisibilityToggle", isRecursively: true);
		snappingOnToggle = base.MainPanel.transform.FindComponent<Toggle>("SnappingOnToggle", isRecursively: true);
		surfaceSnappingToggle = base.MainPanel.transform.FindComponent<Toggle>("SurfaceSnappingToggle", isRecursively: true);
		gridSnappingToggle = base.MainPanel.transform.FindComponent<Toggle>("GridSnappingToggle", isRecursively: true);
		autoFocusToggle = base.MainPanel.transform.FindComponent<Toggle>("AutoFocusToggle", isRecursively: true);
		levelPropertiesToggle = base.MainPanel.transform.FindComponent<Toggle>("LevelPropertiesToggle", isRecursively: true);
		clearButton = base.MainPanel.transform.FindComponent<Button>("ClearButton", isRecursively: true);
		undoButton.onClick.AddListener(delegate
		{
			NotifyChange("LevelEditorToolsView.UndoButtonEvent");
		});
		redoButton.onClick.AddListener(delegate
		{
			NotifyChange("LevelEditorToolsView.RedoButtonEvent");
		});
		logicToggle.onValueChanged.AddListener(delegate(bool isOn)
		{
			if (isOn)
			{
				NotifyChange("LevelEditorToolsView.LogicToggleEvent");
			}
		});
		handToggle.onValueChanged.AddListener(delegate(bool isOn)
		{
			if (isOn)
			{
				NotifyChange("LevelEditorToolsView.HandToggleEvent");
			}
		});
		moveToggle.onValueChanged.AddListener(delegate(bool isOn)
		{
			if (isOn)
			{
				NotifyChange("LevelEditorToolsView.MoveToggleEvent");
			}
		});
		rotateToggle.onValueChanged.AddListener(delegate(bool isOn)
		{
			if (isOn)
			{
				NotifyChange("LevelEditorToolsView.RotateToggleEvent");
			}
		});
		scaleToggle.onValueChanged.AddListener(delegate(bool isOn)
		{
			if (isOn)
			{
				NotifyChange("LevelEditorToolsView.ScaleToggleEvent");
			}
		});
		boxToggle.onValueChanged.AddListener(delegate(bool isOn)
		{
			if (isOn)
			{
				NotifyChange("LevelEditorToolsView.BoxToggleEvent");
			}
		});
		extrudeToggle.onValueChanged.AddListener(delegate(bool isOn)
		{
			if (isOn)
			{
				NotifyChange("LevelEditorToolsView.ExtrudeToggleEvent");
			}
		});
		universalToggle.onValueChanged.AddListener(delegate(bool isOn)
		{
			if (isOn)
			{
				NotifyChange("LevelEditorToolsView.UniversalToggleEvent");
			}
		});
		inventoryButton.onClick.AddListener(delegate
		{
			NotifyChange("LevelEditorToolsView.InventoryButtonEvent");
		});
		transformSpaceToggle.onValueChanged.AddListener(delegate(bool isOn)
		{
			NotifyChange("LevelEditorToolsView.TransformSpaceToggleEvent", isOn);
		});
		gridVisibilityToggle.onValueChanged.AddListener(delegate(bool isOn)
		{
			NotifyChange("LevelEditorToolsView.GridVisibilityToggleEvent", isOn);
		});
		snappingOnToggle.onValueChanged.AddListener(delegate(bool isOn)
		{
			NotifyChange("LevelEditorToolsView.SnappingOnToggleEvent", isOn);
		});
		surfaceSnappingToggle.onValueChanged.AddListener(delegate(bool isOn)
		{
			if (isOn)
			{
				NotifyChange("LevelEditorToolsView.SurfaceSnappingToggleEvent");
			}
		});
		gridSnappingToggle.onValueChanged.AddListener(delegate(bool isOn)
		{
			if (isOn)
			{
				NotifyChange("LevelEditorToolsView.GridSnappingToggleEvent");
			}
		});
		autoFocusToggle.onValueChanged.AddListener(delegate(bool isOn)
		{
			NotifyChange("LevelEditorToolsView.AutoFocusToggleEvent", isOn);
		});
		levelPropertiesToggle.onValueChanged.AddListener(delegate(bool isOn)
		{
			NotifyChange("LevelEditorToolsView.LevelPropertiesToggleEvent", isOn);
		});
		clearButton.onClick.AddListener(delegate
		{
			string text = LanguagesManager.Instance.GetText("message.header.leveleditor.tools.clear", "Clear All Level Objects");
			string text2 = LanguagesManager.Instance.GetText("message.info.leveleditor.tools.clear", "Clear all level objects?");
			GUIManager.Instance.ShowMessageBox(text, text2, delegate
			{
				NotifyChange("LevelEditorToolsView.ClearButtonEvent");
			});
		});
	}

	public void UnfocusSelectedGizmoTool()
	{
		gizmosToolsToggleGroup.SetAllTogglesOff();
	}

	public void SetLogicToggleStatus(bool isSelected)
	{
		if (logicToggle.isOn != isSelected)
		{
			logicToggle.SetValue(isSelected);
		}
	}

	public void SetHandToggleStatus(bool isSelected)
	{
		if (handToggle.isOn != isSelected)
		{
			handToggle.SetValue(isSelected);
		}
	}

	public void SetMoveToggleStatus(bool isSelected)
	{
		if (moveToggle.isOn != isSelected)
		{
			moveToggle.SetValue(isSelected);
		}
	}

	public void SetRotateToggleStatus(bool isSelected)
	{
		if (rotateToggle.isOn != isSelected)
		{
			rotateToggle.SetValue(isSelected);
		}
	}

	public void SetScaleToggleStatus(bool isSelected)
	{
		if (scaleToggle.isOn != isSelected)
		{
			scaleToggle.SetValue(isSelected);
		}
	}

	public void SetBoxToggleStatus(bool isSelected)
	{
		if (boxToggle.isOn != isSelected)
		{
			boxToggle.SetValue(isSelected);
		}
	}

	public void SetExtrudeToggleStatus(bool isSelected)
	{
		if (extrudeToggle.isOn != isSelected)
		{
			extrudeToggle.SetValue(isSelected);
		}
	}

	public void SetUniversalToggleStatus(bool isSelected)
	{
		if (universalToggle.isOn != isSelected)
		{
			universalToggle.SetValue(isSelected);
		}
	}

	public void SetTransformSpaceToggleStatus(bool isSelected)
	{
		if (transformSpaceToggle.isOn != isSelected)
		{
			transformSpaceToggle.SetValue(isSelected);
		}
	}

	public void SetGridVisibilityToggleStatus(bool isSelected)
	{
		if (gridVisibilityToggle.isOn != isSelected)
		{
			gridVisibilityToggle.SetValue(isSelected);
		}
	}

	public void SetSurfaceSnappingToggleStatus(bool isSelected)
	{
		if (surfaceSnappingToggle.isOn != isSelected)
		{
			surfaceSnappingToggle.SetValue(isSelected);
		}
	}

	public void SetGridSnappingToggleStatus(bool isSelected)
	{
		if (gridSnappingToggle.isOn != isSelected)
		{
			gridSnappingToggle.SetValue(isSelected);
		}
	}

	public void SetSnappingOnToggleStatus(bool isSelected)
	{
		if (snappingOnToggle.isOn != isSelected)
		{
			snappingOnToggle.SetValue(isSelected);
		}
	}

	public void SetAutosFocusToggleStatus(bool isSelected)
	{
		if (autoFocusToggle.isOn != isSelected)
		{
			autoFocusToggle.SetValue(isSelected);
		}
	}

	public void SetLevelPropertiesToggleValue(bool isSelected)
	{
		if (levelPropertiesToggle.isOn != isSelected)
		{
			levelPropertiesToggle.SetValue(isSelected);
		}
	}

	public void InvertTransformSpaceToggleStatus()
	{
		transformSpaceToggle.SetValue(!transformSpaceToggle.isOn);
	}

	public void SetUndoInterativity(bool isInteractable)
	{
		if (undoButton.interactable != isInteractable)
		{
			undoButton.interactable = isInteractable;
		}
	}

	public void SetRedoInterativity(bool isInteractable)
	{
		if (redoButton.interactable != isInteractable)
		{
			redoButton.interactable = isInteractable;
		}
	}
}
