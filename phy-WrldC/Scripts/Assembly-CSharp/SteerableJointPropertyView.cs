using UnityEngine;
using UnityEngine.UI;

public class SteerableJointPropertyView : BaseGUIPanelView
{
	private readonly HingeEditorView hingeEditorView;

	private SteerableJointModel selectedSteerableJointModel;

	private readonly KeyAssignment forwardKey;

	private readonly KeyAssignment backwardKey;

	private readonly Toggle toggleActivationTypeToggle;

	private readonly SliderManager forwardTargetSlider;

	private readonly SliderManager backwardTargetSlider;

	private readonly SliderManager angleOffsetSlider;

	public SteerableJointPropertyView(HingeEditorView hingeEditorView)
	{
		this.hingeEditorView = hingeEditorView;
		base.MainPanel = hingeEditorView.mainPanel.transform.FindChildRecursively("SteerableJointPropertyPanel").gameObject;
		forwardKey = base.MainPanel.transform.FindComponent<KeyAssignment>("ForwardKeyAssignment", isRecursively: true);
		backwardKey = base.MainPanel.transform.FindComponent<KeyAssignment>("BackwardKeyAssignment", isRecursively: true);
		forwardKey.AddListener(ForwardKeyHandler);
		backwardKey.AddListener(BackwardKeyHandler);
		toggleActivationTypeToggle = base.MainPanel.transform.FindComponent<Toggle>("ToggleActivationTypeToggle", isRecursively: true);
		toggleActivationTypeToggle.onValueChanged.AddListener(ToggleActivationTypeHandler);
		forwardTargetSlider = base.MainPanel.transform.FindComponent<SliderManager>("ForwardTargetSlider", isRecursively: true);
		forwardTargetSlider.ConfigureProperties(30f, 0f, 180f, 5f, "{0} deg");
		forwardTargetSlider.OnValueChangedEvent += delegate(float value)
		{
			ForwardTargetEditedHandler(value);
		};
		backwardTargetSlider = base.MainPanel.transform.FindComponent<SliderManager>("BackwardTargetSlider", isRecursively: true);
		backwardTargetSlider.ConfigureProperties(30f, 0f, 180f, 5f, "{0} deg");
		backwardTargetSlider.OnValueChangedEvent += delegate(float value)
		{
			BackwardTargetEditedHandler(value);
		};
		angleOffsetSlider = base.MainPanel.transform.FindComponent<SliderManager>("AngleOffsetSlider", isRecursively: true);
		angleOffsetSlider.ConfigureProperties(0f, -180f, 180f, 5f, "{0} deg");
		angleOffsetSlider.OnValueChangedEvent += delegate(float value)
		{
			AngleOffsetEditedHandler(value);
		};
	}

	public void UpdateSteerableJointPanel(SteerableJointModel steerableModel)
	{
		selectedSteerableJointModel = steerableModel;
		forwardKey.IsAxisEnabled = !GameManager.Instance.OptionsModel.IsJoystickAxesDisabled;
		backwardKey.IsAxisEnabled = !GameManager.Instance.OptionsModel.IsJoystickAxesDisabled;
		forwardKey.SetKey(selectedSteerableJointModel.DefaultForward.KeyValue, selectedSteerableJointModel.DefaultForward.AxisValue);
		backwardKey.SetKey(selectedSteerableJointModel.DefaultBackward.KeyValue, selectedSteerableJointModel.DefaultBackward.AxisValue);
		forwardKey.IsKeyControlledByLogic = selectedSteerableJointModel.DefaultForward.IsAttachedInWritableSocketIO();
		backwardKey.IsKeyControlledByLogic = selectedSteerableJointModel.DefaultBackward.IsAttachedInWritableSocketIO();
		toggleActivationTypeToggle.SetValue(steerableModel.IsToggleActivationType);
		forwardTargetSlider.SetCurrentValue(steerableModel.ForwardTarget);
		backwardTargetSlider.SetCurrentValue(steerableModel.BackwardTarget);
		angleOffsetSlider.SetCurrentValue(steerableModel.AngleOffset);
		string text = LanguagesManager.Instance.GetText("label.text.transmission.steerable", "Steerable Spin");
		hingeEditorView.HeaderHingeEditorView.SetTitleAndIcon(text, HeaderHingeEditorView.IconType.HingeJoint);
	}

	private void ForwardTargetEditedHandler(float value)
	{
		selectedSteerableJointModel.ForwardTarget = Mathf.Abs(value);
		hingeEditorView.UpdateSteerableHandler();
	}

	private void BackwardTargetEditedHandler(float value)
	{
		selectedSteerableJointModel.BackwardTarget = Mathf.Abs(value);
		hingeEditorView.UpdateSteerableHandler();
	}

	public void AngleOffsetEditedHandler(float value)
	{
		selectedSteerableJointModel.AngleOffset = value;
		hingeEditorView.UpdateSteerableHandler();
	}

	private void ForwardKeyHandler(KeyCode key, AxisCode axis)
	{
		selectedSteerableJointModel.DefaultForward.KeyValue = key;
		selectedSteerableJointModel.DefaultForward.AxisValue = axis;
		hingeEditorView.UpdateSteerableHandler();
	}

	private void BackwardKeyHandler(KeyCode key, AxisCode axis)
	{
		selectedSteerableJointModel.DefaultBackward.KeyValue = key;
		selectedSteerableJointModel.DefaultBackward.AxisValue = axis;
		hingeEditorView.UpdateSteerableHandler();
	}

	private void ToggleActivationTypeHandler(bool isOn)
	{
		selectedSteerableJointModel.IsToggleActivationType = isOn;
		hingeEditorView.UpdateSteerableHandler();
	}
}
