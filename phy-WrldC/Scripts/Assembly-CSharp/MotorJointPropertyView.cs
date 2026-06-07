using UnityEngine;
using UnityEngine.UI;

public class MotorJointPropertyView : BaseGUIPanelView
{
	private readonly HingeEditorView hingeEditorView;

	private MotorJointModel selectedMotorJointModel;

	private readonly Toggle rotationDirectionToggle;

	private readonly KeyAssignment forwardKey;

	private readonly KeyAssignment backwardKey;

	private readonly KeyAssignment brakeKey;

	public MotorJointPropertyView(HingeEditorView hingeEditorView)
	{
		this.hingeEditorView = hingeEditorView;
		base.MainPanel = hingeEditorView.mainPanel.transform.FindChildRecursively("MotorJointPropertyPanel").gameObject;
		forwardKey = base.MainPanel.transform.FindComponent<KeyAssignment>("ForwardKeyAssignment", isRecursively: true);
		backwardKey = base.MainPanel.transform.FindComponent<KeyAssignment>("BackwardKeyAssignment", isRecursively: true);
		brakeKey = base.MainPanel.transform.FindComponent<KeyAssignment>("BrakeKeyAssignment", isRecursively: true);
		forwardKey.AddListener(ForwardKeyHandler);
		backwardKey.AddListener(BackwardKeyHandler);
		brakeKey.AddListener(BrakeKeyHandler);
		rotationDirectionToggle = base.MainPanel.transform.FindComponent<Toggle>("RotationDirectionToggle", isRecursively: true);
		rotationDirectionToggle.onValueChanged.AddListener(OnChangeRotationDirectionHandler);
	}

	public void UpdateMotorJointPanel(MotorJointModel motorJointModel)
	{
		selectedMotorJointModel = motorJointModel;
		forwardKey.IsAxisEnabled = !GameManager.Instance.OptionsModel.IsJoystickAxesDisabled;
		backwardKey.IsAxisEnabled = !GameManager.Instance.OptionsModel.IsJoystickAxesDisabled;
		brakeKey.IsAxisEnabled = !GameManager.Instance.OptionsModel.IsJoystickAxesDisabled;
		forwardKey.SetKey(selectedMotorJointModel.DefaultForward.KeyValue, selectedMotorJointModel.DefaultForward.AxisValue);
		backwardKey.SetKey(selectedMotorJointModel.DefaultBackward.KeyValue, selectedMotorJointModel.DefaultBackward.AxisValue);
		brakeKey.SetKey(selectedMotorJointModel.DefaultBrake.KeyValue, selectedMotorJointModel.DefaultBrake.AxisValue);
		forwardKey.IsKeyControlledByLogic = selectedMotorJointModel.DefaultForward.IsAttachedInWritableSocketIO();
		backwardKey.IsKeyControlledByLogic = selectedMotorJointModel.DefaultBackward.IsAttachedInWritableSocketIO();
		brakeKey.IsKeyControlledByLogic = selectedMotorJointModel.DefaultBrake.IsAttachedInWritableSocketIO();
		rotationDirectionToggle.SetValue(!selectedMotorJointModel.IsClockwiseRotation);
		string text = LanguagesManager.Instance.GetText("label.text.transmission.continuous", "Continuous Spin");
		hingeEditorView.HeaderHingeEditorView.SetTitleAndIcon(text, HeaderHingeEditorView.IconType.HingeJoint);
	}

	private void OnChangeRotationDirectionHandler(bool isInvertedDirection)
	{
		selectedMotorJointModel.IsClockwiseRotation = !isInvertedDirection;
		hingeEditorView.UpdateMotorHandler();
	}

	private void ForwardKeyHandler(KeyCode key, AxisCode axis)
	{
		selectedMotorJointModel.DefaultForward.KeyValue = key;
		selectedMotorJointModel.DefaultForward.AxisValue = axis;
		hingeEditorView.UpdateMotorHandler();
	}

	private void BackwardKeyHandler(KeyCode key, AxisCode axis)
	{
		selectedMotorJointModel.DefaultBackward.KeyValue = key;
		selectedMotorJointModel.DefaultBackward.AxisValue = axis;
		hingeEditorView.UpdateMotorHandler();
	}

	private void BrakeKeyHandler(KeyCode key, AxisCode axis)
	{
		selectedMotorJointModel.DefaultBrake.KeyValue = key;
		selectedMotorJointModel.DefaultBrake.AxisValue = axis;
		hingeEditorView.UpdateMotorHandler();
	}
}
