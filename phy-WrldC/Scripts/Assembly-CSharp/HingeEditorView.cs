using UnityEngine;

public class HingeEditorView : BaseGUIView
{
	public const string AddMotorJointEvent = "HingeEditorView.AddMotorJointEvent";

	public const string AddSteerableJointEvent = "HingeEditorView.AddSteerableJointEvent";

	public const string AddStepperJointEvent = "HingeEditorView.AddStepperJointEvent";

	public const string RemoveSpecializedJointsEvent = "HingeEditorView.RemoveSpecializedJointsEvent";

	public const string UpdateMotorJointEvent = "HingeEditorView.UpdateMotorJointEvent";

	public const string UpdateSteerableJointEvent = "HingeEditorView.UpdateSteerableJointEvent";

	public const string UpdateStepperJointEvent = "HingeEditorView.UpdateStepperJointEvent";

	public const string ConnectMotorToHingeJointEvent = "HingeEditorView.ConnectMotorToHingeJointEvent";

	public const string RemoveMotorFromHingeJointEvent = "HingeEditorView.RemoveMotorFromHingeJointEvent";

	public const string RemoveAllHingeJointsFromMotor = "HingeEditorView.RemoveAllHingeJointsFromMotor";

	public const string ChangeAnchorPointEvent = "HingeEditorView.ChangeAnchorPointEvent";

	public const string CloseWindowEvent = "HingeEditorView.CloseWindowEvent";

	private GameObject hingeWindowPanel;

	private HingeJointButton3D selectedHingeJointButton;

	private BlockBodyModelButton3D selectedMotorBlockButton;

	private HingeJointPropertyView hingeJointPropertyView;

	private MotorBlockPropertyView motorBlockPropertyView;

	private Button3D currentButton3D;

	public HeaderHingeEditorView HeaderHingeEditorView { get; private set; }

	public override void Initialize()
	{
		hingeWindowPanel = mainPanel.transform.Find("HingeWindowPanel").gameObject;
		HeaderHingeEditorView = new HeaderHingeEditorView(this);
		hingeJointPropertyView = new HingeJointPropertyView(this);
		motorBlockPropertyView = new MotorBlockPropertyView(this);
		Util.AddMouseOverUIEvents(hingeWindowPanel, base.OnMouseOverUIHandler);
		hingeWindowPanel.SetActive(value: false);
	}

	public void OnButton3DDeselectedHandler()
	{
		base.IsMouseOverUI = false;
		currentButton3D = null;
		selectedHingeJointButton = null;
		selectedMotorBlockButton = null;
		hingeWindowPanel.SetActive(value: false);
	}

	public void OnButton3DSelectedHandler(Button3D button3D)
	{
		hingeWindowPanel.SetActive(value: true);
		if (button3D is HingeJointButton3D)
		{
			selectedHingeJointButton = button3D as HingeJointButton3D;
			hingeJointPropertyView.SetVisibility(isVisible: true);
			motorBlockPropertyView.SetVisibility(isVisible: false);
			hingeJointPropertyView.UpdateHingeJointPropertyPanel(selectedHingeJointButton.HingeJointModel);
			if (button3D != currentButton3D)
			{
				GameManager.Instance.UIAudioEffectsManager.PlayAudio(GameManager.Instance.GameStylesData.hingeJointSelectedClip, GameManager.Instance.GameStylesData.volumeStylesData.uiVolume);
			}
		}
		else if (button3D is BlockBodyModelButton3D)
		{
			selectedMotorBlockButton = button3D as BlockBodyModelButton3D;
			hingeJointPropertyView.SetVisibility(isVisible: false);
			motorBlockPropertyView.SetVisibility(isVisible: true);
			motorBlockPropertyView.UpdateMotorBlockPanel(selectedMotorBlockButton.BlockBodyModel);
			if (button3D != currentButton3D)
			{
				GameManager.Instance.UIAudioEffectsManager.PlayAudio(GameManager.Instance.GameStylesData.motorBlockSelectedClip, GameManager.Instance.GameStylesData.volumeStylesData.uiVolume);
			}
		}
		currentButton3D = button3D;
	}

	public void RefreshPanels()
	{
		if (currentButton3D != null)
		{
			OnButton3DSelectedHandler(currentButton3D);
		}
	}

	public void CanConnectMotorToHingeJointHandler(HingeJointModel hingeJointModel, BlockBodyModel motorBlockBodyModel)
	{
		GameManager.Instance.UIAudioEffectsManager.PlayAudio(GameManager.Instance.GameStylesData.connectionMadeClip, GameManager.Instance.GameStylesData.volumeStylesData.uiVolume);
		NotifyChange("HingeEditorView.ConnectMotorToHingeJointEvent", hingeJointModel, motorBlockBodyModel);
	}

	public void DisconnectMotorFromHingeJointHandler(HingeJointModel hingeJointModel)
	{
		NotifyChange("HingeEditorView.RemoveMotorFromHingeJointEvent", hingeJointModel, false);
	}

	public void AddMotorButtonHandler()
	{
		NotifyChange("HingeEditorView.AddMotorJointEvent", selectedHingeJointButton.HingeJointModel);
	}

	public void AddSteerableButtonHandler()
	{
		NotifyChange("HingeEditorView.AddSteerableJointEvent", selectedHingeJointButton.HingeJointModel);
	}

	public void AddStepperButtonHandler()
	{
		NotifyChange("HingeEditorView.AddStepperJointEvent", selectedHingeJointButton.HingeJointModel);
	}

	public void RemoveButtonHandler()
	{
		NotifyChange("HingeEditorView.RemoveSpecializedJointsEvent", selectedHingeJointButton.HingeJointModel);
	}

	public void UpdateMotorHandler()
	{
		NotifyChange("HingeEditorView.UpdateMotorJointEvent", selectedHingeJointButton.HingeJointModel);
	}

	public void UpdateSteerableHandler()
	{
		NotifyChange("HingeEditorView.UpdateSteerableJointEvent", selectedHingeJointButton.HingeJointModel);
	}

	public void UpdateStepperHandler()
	{
		NotifyChange("HingeEditorView.UpdateStepperJointEvent", selectedHingeJointButton.HingeJointModel);
	}

	public void RemoveMotorFromHingeJointHandler()
	{
		NotifyChange("HingeEditorView.RemoveMotorFromHingeJointEvent", selectedHingeJointButton.HingeJointModel, true);
	}

	public void RemoveAllHingeJointsFromMotorHandler()
	{
		NotifyChange("HingeEditorView.RemoveAllHingeJointsFromMotor", selectedMotorBlockButton.BlockBodyModel);
	}

	public void ChangeAnchorPointHandler(bool isHingeJointAnchorPoint)
	{
		NotifyChange("HingeEditorView.ChangeAnchorPointEvent", selectedHingeJointButton.HingeJointModel, isHingeJointAnchorPoint);
	}

	public void CloseWindowHanlder()
	{
		NotifyChange("HingeEditorView.CloseWindowEvent");
	}
}
