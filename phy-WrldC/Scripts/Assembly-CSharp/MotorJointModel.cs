using UnityEngine;

public class MotorJointModel : BaseModel
{
	public const string UpdateMotorJointEvent = "MotorJointModel.UpdateMotorJointEvent";

	public const string ForwardKey = "motorj_forward";

	public const string BackwardKey = "motorj_backward";

	public const string BrakeKey = "motorj_brake";

	public const string ThrottleInput = "motorj_throttle_in";

	private bool isClockwiseRotation;

	public HingeJointModel ParentHingeJointModel { get; private set; }

	public DefaultKeyIO DefaultForward { get; private set; }

	public DefaultKeyIO DefaultBackward { get; private set; }

	public DefaultKeyIO DefaultBrake { get; private set; }

	public DefaultKeyIO DefaultThrottleInput { get; private set; }

	public bool IsClockwiseRotation
	{
		get
		{
			return isClockwiseRotation;
		}
		set
		{
			isClockwiseRotation = value;
			NotifyChange("MotorJointModel.UpdateMotorJointEvent", this);
		}
	}

	public MotorJointModel(HingeJointModel parentHingeJointModel)
	{
		ParentHingeJointModel = parentHingeJointModel;
		BlockBodyModel parentBlockBodyModel = parentHingeJointModel.ParentBlockBodyModel;
		string text = "motorj_forward";
		string text2 = "motorj_backward";
		string text3 = "motorj_brake";
		string text4 = "motorj_throttle_in";
		if (parentHingeJointModel.Index > 0)
		{
			text = text + "-" + parentHingeJointModel.Index;
			text2 = text2 + "-" + parentHingeJointModel.Index;
			text3 = text3 + "-" + parentHingeJointModel.Index;
			text4 = text4 + "-" + parentHingeJointModel.Index;
		}
		DefaultForward = parentBlockBodyModel.AddDefaultKeyIO(new DefaultKeyIO(text, KeyCode.UpArrow, DefaultKeyIOPlace.HingeJoint, isAxisSensitive: true));
		DefaultBackward = parentBlockBodyModel.AddDefaultKeyIO(new DefaultKeyIO(text2, KeyCode.DownArrow, DefaultKeyIOPlace.HingeJoint, isAxisSensitive: true));
		DefaultBrake = parentBlockBodyModel.AddDefaultKeyIO(new DefaultKeyIO(text3, KeyCode.X, DefaultKeyIOPlace.HingeJoint));
		DefaultThrottleInput = parentBlockBodyModel.AddDefaultKeyIO(new DefaultKeyIO(text4, KeyCode.None, DefaultKeyIOPlace.HingeJoint, isAxisSensitive: false, DefaultKeyIODirection.Input, isInputWithoutKey: true));
		IsClockwiseRotation = true;
	}
}
