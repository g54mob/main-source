using UnityEngine;

public class StepperJointModel : BaseModel
{
	public const string UpdateStepperJointEvent = "StepperJointModel.UpdateStepperJointEvent";

	public const string ForwardKey = "stepper_forward";

	public const string BackwardKey = "stepper_backward";

	public const string ThrottleInput = "stepper_throttle";

	public const string StepSpeedInput = "stepper_speed";

	private float degreesPerSecond;

	private bool isClockwiseRotation;

	public HingeJointModel ParentHingeJointModel { get; private set; }

	public DefaultKeyIO DefaultForward { get; private set; }

	public DefaultKeyIO DefaultBackward { get; private set; }

	public DefaultKeyIO DefaultThrottleInput { get; private set; }

	public DefaultKeyIO DefaultStepSpeedInput { get; private set; }

	public float DegreesPerSecond
	{
		get
		{
			return degreesPerSecond;
		}
		set
		{
			degreesPerSecond = value;
			NotifyChange("StepperJointModel.UpdateStepperJointEvent", this);
		}
	}

	public bool IsClockwiseRotation
	{
		get
		{
			return isClockwiseRotation;
		}
		set
		{
			isClockwiseRotation = value;
			NotifyChange("StepperJointModel.UpdateStepperJointEvent", this);
		}
	}

	public StepperJointModel(HingeJointModel parentHingeJointModel)
	{
		ParentHingeJointModel = parentHingeJointModel;
		BlockBodyModel parentBlockBodyModel = parentHingeJointModel.ParentBlockBodyModel;
		string text = "stepper_forward";
		string text2 = "stepper_backward";
		string text3 = "stepper_throttle";
		string text4 = "stepper_speed";
		if (parentHingeJointModel.Index > 0)
		{
			text = text + "-" + parentHingeJointModel.Index;
			text2 = text2 + "-" + parentHingeJointModel.Index;
			text3 = text3 + "-" + parentHingeJointModel.Index;
			text4 = text4 + "-" + parentHingeJointModel.Index;
		}
		DefaultForward = parentBlockBodyModel.AddDefaultKeyIO(new DefaultKeyIO(text, KeyCode.UpArrow, DefaultKeyIOPlace.HingeJoint));
		DefaultBackward = parentBlockBodyModel.AddDefaultKeyIO(new DefaultKeyIO(text2, KeyCode.DownArrow, DefaultKeyIOPlace.HingeJoint));
		DefaultThrottleInput = parentBlockBodyModel.AddDefaultKeyIO(new DefaultKeyIO(text3, KeyCode.None, DefaultKeyIOPlace.HingeJoint, isAxisSensitive: false, DefaultKeyIODirection.Input, isInputWithoutKey: true));
		DefaultStepSpeedInput = parentBlockBodyModel.AddDefaultKeyIO(new DefaultKeyIO(text4, KeyCode.None, DefaultKeyIOPlace.HingeJoint, isAxisSensitive: false, DefaultKeyIODirection.Input, isInputWithoutKey: true));
		DegreesPerSecond = 100f;
		IsClockwiseRotation = false;
	}
}
