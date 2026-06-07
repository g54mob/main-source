using UnityEngine;

public class MotorJointView
{
	public const string ComponentName = "MotorJoint";

	public JointMotor hingeMotor;

	public float currentForce;

	public HingeJointView ParentHingeJointView { get; private set; }

	public LogicIO ForwardInput { get; set; }

	public LogicIO BackwardInput { get; set; }

	public LogicIO BrakeInput { get; set; }

	public LogicIO ThrottleInput { get; set; }

	public bool IsClockwiseRotation { get; set; }

	public Wheel Wheel { get; set; }

	public MotorJointView(HingeJointView parentHingeJointView)
	{
		ParentHingeJointView = parentHingeJointView;
		BlockBodyView parentBlockBodyView = parentHingeJointView.ParentBlockBodyView;
		string text = "motorj_forward";
		string text2 = "motorj_backward";
		string text3 = "motorj_brake";
		string text4 = "motorj_throttle_in";
		if (parentHingeJointView.Index > 0)
		{
			text = text + "-" + parentHingeJointView.Index;
			text2 = text2 + "-" + parentHingeJointView.Index;
			text3 = text3 + "-" + parentHingeJointView.Index;
			text4 = text4 + "-" + parentHingeJointView.Index;
		}
		ForwardInput = parentBlockBodyView.AddLogicIO(new LogicIO(text, LogicIODirection.Input, 0f, LogicIOPlace.HingeJoint));
		BackwardInput = parentBlockBodyView.AddLogicIO(new LogicIO(text2, LogicIODirection.Input, 0f, LogicIOPlace.HingeJoint));
		BrakeInput = parentBlockBodyView.AddLogicIO(new LogicIO(text3, LogicIODirection.Input, digitalSignal: false, LogicIOPlace.HingeJoint));
		ThrottleInput = parentBlockBodyView.AddLogicIO(new LogicIO(text4, LogicIODirection.Input, 0f, LogicIOPlace.HingeJoint)
		{
			IsInputWithoutKey = true,
			ValueType = LogicIOValueType.Raw
		});
		ForwardInput.ParentHingeJointView = parentHingeJointView;
		BackwardInput.ParentHingeJointView = parentHingeJointView;
		BrakeInput.ParentHingeJointView = parentHingeJointView;
		ThrottleInput.ParentHingeJointView = parentHingeJointView;
	}
}
