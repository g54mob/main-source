using UnityEngine;
using UnityEngine.UI;

public class HingeJointPropertyView : BaseGUIPanelView
{
	private GameObject removeButtonPanel;

	private GameObject hingeButtonsPanel;

	private Button removeButton;

	private Button addMotorButton;

	private Button addSteerableButton;

	private Button addStepperButton;

	private Toggle changeAnchorPointToggle;

	private MotorBlockInfoView motorBlockInfoView;

	private MotorJointPropertyView motorJointPropertyView;

	private SteerableJointPropertyView steerableJointPropertyView;

	private StepperJointPropertyView stepperJointPropertyView;

	private HingeEditorView hingeEditorView;

	public HingeJointPropertyView(HingeEditorView hingeEditorView)
	{
		this.hingeEditorView = hingeEditorView;
		base.MainPanel = hingeEditorView.mainPanel.transform.FindChildRecursively("HingeJointPropertyPanel").gameObject;
		motorBlockInfoView = new MotorBlockInfoView(hingeEditorView);
		motorJointPropertyView = new MotorJointPropertyView(hingeEditorView);
		steerableJointPropertyView = new SteerableJointPropertyView(hingeEditorView);
		stepperJointPropertyView = new StepperJointPropertyView(hingeEditorView);
		removeButtonPanel = base.MainPanel.transform.Find("RemoveButtonPanel").gameObject;
		hingeButtonsPanel = base.MainPanel.transform.Find("HingeButtonsPanel").gameObject;
		addMotorButton = hingeButtonsPanel.transform.FindComponent<Button>("AddMotorButton", isRecursively: true);
		addSteerableButton = hingeButtonsPanel.transform.FindComponent<Button>("AddSteerableButton", isRecursively: true);
		addStepperButton = hingeButtonsPanel.transform.FindComponent<Button>("AddStepperButton", isRecursively: true);
		removeButton = removeButtonPanel.transform.FindComponent<Button>("RemoveButton", isRecursively: true);
		changeAnchorPointToggle = base.MainPanel.transform.FindComponent<Toggle>("ChangeAnchorPointToggle", isRecursively: true);
		removeButton.onClick.AddListener(hingeEditorView.RemoveButtonHandler);
		addMotorButton.onClick.AddListener(hingeEditorView.AddMotorButtonHandler);
		addSteerableButton.onClick.AddListener(hingeEditorView.AddSteerableButtonHandler);
		addStepperButton.onClick.AddListener(hingeEditorView.AddStepperButtonHandler);
		changeAnchorPointToggle.onValueChanged.AddListener(hingeEditorView.ChangeAnchorPointHandler);
	}

	public void UpdateHingeJointPropertyPanel(HingeJointModel hingeJointModel)
	{
		changeAnchorPointToggle.SetValue(hingeJointModel.IsThisAnchorPoint);
		motorBlockInfoView.UpdateMotorBlockInfoPanel(hingeJointModel);
		if (hingeJointModel.MotorJointModel != null)
		{
			steerableJointPropertyView.SetVisibility(isVisible: false);
			stepperJointPropertyView.SetVisibility(isVisible: false);
			motorJointPropertyView.SetVisibility(isVisible: true);
			motorJointPropertyView.UpdateMotorJointPanel(hingeJointModel.MotorJointModel);
			removeButtonPanel.SetActive(value: true);
			hingeButtonsPanel.SetActive(value: false);
		}
		else if (hingeJointModel.SteerableJointModel != null)
		{
			steerableJointPropertyView.SetVisibility(isVisible: true);
			stepperJointPropertyView.SetVisibility(isVisible: false);
			motorJointPropertyView.SetVisibility(isVisible: false);
			steerableJointPropertyView.UpdateSteerableJointPanel(hingeJointModel.SteerableJointModel);
			removeButtonPanel.SetActive(value: true);
			hingeButtonsPanel.SetActive(value: false);
		}
		else if (hingeJointModel.StepperJointModel != null)
		{
			steerableJointPropertyView.SetVisibility(isVisible: false);
			stepperJointPropertyView.SetVisibility(isVisible: true);
			motorJointPropertyView.SetVisibility(isVisible: false);
			stepperJointPropertyView.UpdateStepperJointPanel(hingeJointModel.StepperJointModel);
			removeButtonPanel.SetActive(value: true);
			hingeButtonsPanel.SetActive(value: false);
		}
		else
		{
			string text = LanguagesManager.Instance.GetText("label.text.transmission.freespin", "Free Spin");
			hingeEditorView.HeaderHingeEditorView.SetTitleAndIcon(text, HeaderHingeEditorView.IconType.HingeJoint);
			steerableJointPropertyView.SetVisibility(isVisible: false);
			stepperJointPropertyView.SetVisibility(isVisible: false);
			motorJointPropertyView.SetVisibility(isVisible: false);
			removeButtonPanel.SetActive(value: false);
			hingeButtonsPanel.SetActive(value: true);
		}
	}
}
