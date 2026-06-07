using UnityEngine;
using UnityEngine.UI;

public class StepperJointPropertyView : BaseGUIPanelView
{
	private readonly HingeEditorView hingeEditorView;

	private StepperJointModel selectedStepperJointModel;

	private readonly KeyAssignment forwardKey;

	private readonly KeyAssignment backwardKey;

	private readonly Toggle rotationDirectionToggle;

	private readonly SliderManager stepperSpeedSlider;

	public StepperJointPropertyView(HingeEditorView hingeEditorView)
	{
		this.hingeEditorView = hingeEditorView;
		base.MainPanel = hingeEditorView.mainPanel.transform.FindChildRecursively("StepperJointPropertyPanel").gameObject;
		forwardKey = base.MainPanel.transform.FindComponent<KeyAssignment>("ForwardKeyAssignment", isRecursively: true);
		backwardKey = base.MainPanel.transform.FindComponent<KeyAssignment>("BackwardKeyAssignment", isRecursively: true);
		rotationDirectionToggle = base.MainPanel.transform.FindComponent<Toggle>("RotationDirectionToggle", isRecursively: true);
		rotationDirectionToggle.onValueChanged.AddListener(OnChangeRotationDirectionHandler);
		stepperSpeedSlider = base.MainPanel.transform.FindComponent<SliderManager>("StepperSpeedSlider", isRecursively: true);
		stepperSpeedSlider.ConfigureProperties(100f, 5f, 360f, 5f, "{0:0} (deg/s)");
		stepperSpeedSlider.OnValueChangedEvent += delegate(float value)
		{
			StepperSpeedEditedHandler(value);
		};
		forwardKey.AddListener(ForwardKeyHandler);
		backwardKey.AddListener(BackwardKeyHandler);
	}

	public void UpdateStepperJointPanel(StepperJointModel stepperModel)
	{
		selectedStepperJointModel = stepperModel;
		forwardKey.IsAxisEnabled = !GameManager.Instance.OptionsModel.IsJoystickAxesDisabled;
		backwardKey.IsAxisEnabled = !GameManager.Instance.OptionsModel.IsJoystickAxesDisabled;
		forwardKey.SetKey(selectedStepperJointModel.DefaultForward.KeyValue, selectedStepperJointModel.DefaultForward.AxisValue);
		backwardKey.SetKey(selectedStepperJointModel.DefaultBackward.KeyValue, selectedStepperJointModel.DefaultBackward.AxisValue);
		forwardKey.IsKeyControlledByLogic = selectedStepperJointModel.DefaultForward.IsAttachedInWritableSocketIO();
		backwardKey.IsKeyControlledByLogic = selectedStepperJointModel.DefaultBackward.IsAttachedInWritableSocketIO();
		rotationDirectionToggle.SetValue(stepperModel.IsClockwiseRotation);
		stepperSpeedSlider.SetCurrentValue(stepperModel.DegreesPerSecond);
		string text = LanguagesManager.Instance.GetText("label.text.transmission.stepper", "Stepper Spin");
		hingeEditorView.HeaderHingeEditorView.SetTitleAndIcon(text, HeaderHingeEditorView.IconType.HingeJoint);
	}

	private void StepperSpeedEditedHandler(float value)
	{
		selectedStepperJointModel.DegreesPerSecond = Mathf.Abs(value);
		hingeEditorView.UpdateStepperHandler();
	}

	private void ForwardKeyHandler(KeyCode key, AxisCode axis)
	{
		selectedStepperJointModel.DefaultForward.KeyValue = key;
		selectedStepperJointModel.DefaultForward.AxisValue = axis;
		hingeEditorView.UpdateStepperHandler();
	}

	private void BackwardKeyHandler(KeyCode key, AxisCode axis)
	{
		selectedStepperJointModel.DefaultBackward.KeyValue = key;
		selectedStepperJointModel.DefaultBackward.AxisValue = axis;
		hingeEditorView.UpdateStepperHandler();
	}

	private void OnChangeRotationDirectionHandler(bool isInvertedDirection)
	{
		selectedStepperJointModel.IsClockwiseRotation = isInvertedDirection;
		hingeEditorView.UpdateStepperHandler();
	}
}
