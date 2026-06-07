public class LevelEditorToolsModel : BaseModel
{
	public enum SnappingType
	{
		Surface = 0,
		Grid = 1
	}

	public const string SnappingTypeEvent = "LevelEditorToolsModel.SnappingTypeEvent";

	public const string HandSnapStepChangedEvent = "LevelEditorToolsModel.SnapStepEvent";

	public const string MoveSnapStepChangedEvent = "LevelEditorToolsModel.MoveSnapStepChangedEvent";

	public const string RotationSnapStepChangedEvent = "LevelEditorToolsModel.RotationSnapStepChangedEvent";

	public const string ScaleSnapStepChangedEvent = "LevelEditorToolsModel.ScaleSnapStepChangedEvent";

	public const string IsGridVisibledEvent = "LevelEditorToolsModel.IsGridVisibledEvent";

	public const string IsSnappingOnEvent = "LevelEditorToolsModel.IsSnappingOnEvent";

	public const string FocusDefaultGizmosToolEvent = "LevelEditorToolsModel.FocusDefaultGizmosToolEvent";

	public const string FocusLogicToolEvent = "LevelEditorToolsModel.FocusLogicToolEvent";

	public const string FocusHandToolEvent = "LevelEditorToolsModel.FocusHandToolEvent";

	public const string UnfocusLogicOrHandOrGizmoToolEvent = "LevelEditorToolsModel.UnfocusHandOrGizmoToolEvent";

	public const string IsPickingUpOutputForInputEvent = "LevelEditorToolsModel.IsPickingUpOutputForInputEvent";

	private SnappingType snappingTypeValue;

	private float handSnapStep;

	private float moveSnapStep;

	private float rotationSnapStep;

	private float scaleSnapStep;

	private bool isGridVisible;

	private bool isSnappingOn;

	private bool isPickingUpOutputForInput;

	public SnappingType SnappingTypeValue
	{
		get
		{
			return snappingTypeValue;
		}
		set
		{
			snappingTypeValue = value;
			NotifyChange("LevelEditorToolsModel.SnappingTypeEvent");
		}
	}

	public float HandSnapStep
	{
		get
		{
			return handSnapStep;
		}
		set
		{
			handSnapStep = value;
			NotifyChange("LevelEditorToolsModel.SnapStepEvent");
		}
	}

	public float MoveSnapStep
	{
		get
		{
			return moveSnapStep;
		}
		set
		{
			moveSnapStep = value;
			NotifyChange("LevelEditorToolsModel.MoveSnapStepChangedEvent");
		}
	}

	public float RotationSnapStep
	{
		get
		{
			return rotationSnapStep;
		}
		set
		{
			rotationSnapStep = value;
			NotifyChange("LevelEditorToolsModel.RotationSnapStepChangedEvent");
		}
	}

	public float ScaleSnapStep
	{
		get
		{
			return scaleSnapStep;
		}
		set
		{
			scaleSnapStep = value;
			NotifyChange("LevelEditorToolsModel.ScaleSnapStepChangedEvent");
		}
	}

	public bool IsGridVisible
	{
		get
		{
			return isGridVisible;
		}
		set
		{
			isGridVisible = value;
			NotifyChange("LevelEditorToolsModel.IsGridVisibledEvent");
		}
	}

	public bool IsSnappingOn
	{
		get
		{
			return isSnappingOn;
		}
		set
		{
			isSnappingOn = value;
			NotifyChange("LevelEditorToolsModel.IsSnappingOnEvent");
		}
	}

	public bool IsLogicToolEnabled { get; set; }

	public bool IsHandToolEnabled { get; set; }

	public bool IsHandToolHoldingObject { get; set; }

	public bool IsPickingUpOutputForInput
	{
		get
		{
			return isPickingUpOutputForInput;
		}
		set
		{
			isPickingUpOutputForInput = value;
			NotifyChange("LevelEditorToolsModel.IsPickingUpOutputForInputEvent");
		}
	}

	public LevelEditorToolsModel()
	{
		snappingTypeValue = SnappingType.Surface;
		handSnapStep = 0.5f;
		moveSnapStep = 0.5f;
		rotationSnapStep = 15f;
		scaleSnapStep = 0.5f;
		isGridVisible = false;
		isSnappingOn = true;
		IsHandToolEnabled = false;
		IsHandToolHoldingObject = false;
		isPickingUpOutputForInput = false;
	}

	public void FocusDefaultGizmosTool()
	{
		NotifyChange("LevelEditorToolsModel.FocusDefaultGizmosToolEvent");
	}

	public void FocusLogicTool()
	{
		if (!IsLogicToolEnabled)
		{
			IsLogicToolEnabled = true;
			NotifyChange("LevelEditorToolsModel.FocusLogicToolEvent");
		}
	}

	public void FocusHandTool()
	{
		if (!IsHandToolEnabled)
		{
			IsHandToolEnabled = true;
			NotifyChange("LevelEditorToolsModel.FocusHandToolEvent");
		}
	}

	public void UnfocusLogicOrHandOrGizmoTool()
	{
		IsLogicToolEnabled = false;
		IsHandToolEnabled = false;
		IsHandToolHoldingObject = false;
		NotifyChange("LevelEditorToolsModel.UnfocusHandOrGizmoToolEvent");
	}
}
