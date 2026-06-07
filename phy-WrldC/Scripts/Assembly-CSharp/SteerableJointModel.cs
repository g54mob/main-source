using UnityEngine;

public class SteerableJointModel : BaseModel
{
	public const string UpdateSteerableJointEvent = "SteerableJointModel.UpdateSteerableJointEvent";

	public const string ForwardKey = "steerj_forward";

	public const string BackwardKey = "steerj_backward";

	public const string PositionInput = "steerj_position_in";

	public const string PositionOuput = "steerj_position_out";

	private float forwardTarget;

	private float backwardTargert;

	private float angleOffset;

	public HingeJointModel ParentHingeJointModel { get; private set; }

	public DefaultKeyIO DefaultForward { get; private set; }

	public DefaultKeyIO DefaultBackward { get; private set; }

	public DefaultKeyIO DefaultPositionInput { get; private set; }

	public DefaultKeyIO DefaultPositionOutput { get; private set; }

	public bool IsToggleActivationType { get; set; }

	public float ForwardTarget
	{
		get
		{
			return forwardTarget;
		}
		set
		{
			forwardTarget = value;
			NotifyChange("SteerableJointModel.UpdateSteerableJointEvent", this);
		}
	}

	public float BackwardTarget
	{
		get
		{
			return backwardTargert;
		}
		set
		{
			backwardTargert = value;
			NotifyChange("SteerableJointModel.UpdateSteerableJointEvent", this);
		}
	}

	public float AngleOffset
	{
		get
		{
			return angleOffset;
		}
		set
		{
			angleOffset = value;
			NotifyChange("SteerableJointModel.UpdateSteerableJointEvent", this);
		}
	}

	public SteerableJointModel(HingeJointModel parentHingeJointModel)
	{
		ParentHingeJointModel = parentHingeJointModel;
		BlockBodyModel parentBlockBodyModel = parentHingeJointModel.ParentBlockBodyModel;
		string text = "steerj_forward";
		string text2 = "steerj_backward";
		string text3 = "steerj_position_in";
		string text4 = "steerj_position_out";
		if (parentHingeJointModel.Index > 0)
		{
			text = text + "-" + parentHingeJointModel.Index;
			text2 = text2 + "-" + parentHingeJointModel.Index;
			text3 = text3 + "-" + parentHingeJointModel.Index;
			text4 = text4 + "-" + parentHingeJointModel.Index;
		}
		DefaultForward = parentBlockBodyModel.AddDefaultKeyIO(new DefaultKeyIO(text, KeyCode.UpArrow, DefaultKeyIOPlace.HingeJoint, isAxisSensitive: true));
		DefaultBackward = parentBlockBodyModel.AddDefaultKeyIO(new DefaultKeyIO(text2, KeyCode.DownArrow, DefaultKeyIOPlace.HingeJoint, isAxisSensitive: true));
		DefaultPositionInput = parentBlockBodyModel.AddDefaultKeyIO(new DefaultKeyIO(text3, KeyCode.None, DefaultKeyIOPlace.HingeJoint, isAxisSensitive: false, DefaultKeyIODirection.Input, isInputWithoutKey: true));
		DefaultPositionOutput = parentBlockBodyModel.AddDefaultKeyIO(new DefaultKeyIO(text4, KeyCode.None, DefaultKeyIOPlace.HingeJoint, isAxisSensitive: false, DefaultKeyIODirection.Output));
		IsToggleActivationType = false;
		ForwardTarget = 30f;
		BackwardTarget = 30f;
		AngleOffset = 0f;
	}
}
