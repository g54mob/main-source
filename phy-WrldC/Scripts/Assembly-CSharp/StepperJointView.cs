using UnityEngine;

public class StepperJointView
{
	public const string ComponentName = "StepperJoint";

	public JointSpring jointSpring;

	public float degreesPerSecond;

	public bool isClockwiseRotation;

	public bool shouldApplyJoint;

	public HingeJointView ParentHingeJointView { get; private set; }

	public LogicIO ForwardInput { get; set; }

	public LogicIO BackwardInput { get; set; }

	public LogicIO ThrottleInput { get; set; }

	public LogicIO StepSpeedInput { get; set; }

	public StepperJointView(HingeJointView parentHingeJointView)
	{
		ParentHingeJointView = parentHingeJointView;
		BlockBodyView parentBlockBodyView = parentHingeJointView.ParentBlockBodyView;
		string text = "stepper_forward";
		string text2 = "stepper_backward";
		string text3 = "stepper_throttle";
		string text4 = "stepper_speed";
		if (parentHingeJointView.Index > 0)
		{
			text = text + "-" + parentHingeJointView.Index;
			text2 = text2 + "-" + parentHingeJointView.Index;
			text3 = text3 + "-" + parentHingeJointView.Index;
			text4 = text4 + "-" + parentHingeJointView.Index;
		}
		ForwardInput = parentBlockBodyView.AddLogicIO(new LogicIO(text, LogicIODirection.Input, digitalSignal: false, LogicIOPlace.HingeJoint));
		BackwardInput = parentBlockBodyView.AddLogicIO(new LogicIO(text2, LogicIODirection.Input, digitalSignal: false, LogicIOPlace.HingeJoint));
		ThrottleInput = parentBlockBodyView.AddLogicIO(new LogicIO(text3, LogicIODirection.Input, 0f, LogicIOPlace.HingeJoint)
		{
			IsInputWithoutKey = true,
			ValueType = LogicIOValueType.Raw
		});
		StepSpeedInput = parentBlockBodyView.AddLogicIO(new LogicIO(text4, LogicIODirection.Input, 100f, LogicIOPlace.HingeJoint)
		{
			IsInputWithoutKey = true,
			ValueType = LogicIOValueType.Raw
		});
		ForwardInput.ParentHingeJointView = parentHingeJointView;
		BackwardInput.ParentHingeJointView = parentHingeJointView;
		ThrottleInput.ParentHingeJointView = parentHingeJointView;
		StepSpeedInput.ParentHingeJointView = parentHingeJointView;
	}
}
