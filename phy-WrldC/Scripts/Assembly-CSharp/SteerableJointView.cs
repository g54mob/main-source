using UnityEngine;

public class SteerableJointView
{
	public const string ComponentName = "SteerableJoint";

	public JointSpring jointSpring;

	public float forwardTarget;

	public float backwardTarget;

	public bool isForwardActivated;

	public bool isBackwardActivated;

	public bool isForwardKeyPressedDown;

	public bool isBackwardKeyPressedDown;

	public float targetPosition;

	public float movementSpeed;

	public float currentVelocity;

	public HingeJointView ParentHingeJointView { get; private set; }

	public LogicIO ForwardInput { get; set; }

	public LogicIO BackwardInput { get; set; }

	public LogicIO PositionInput { get; set; }

	public LogicIO PositionOutput { get; set; }

	public bool IsToggleActivationType { get; set; }

	public SteerableJointView(HingeJointView parentHingeJointView)
	{
		ParentHingeJointView = parentHingeJointView;
		BlockBodyView parentBlockBodyView = parentHingeJointView.ParentBlockBodyView;
		string text = "steerj_forward";
		string text2 = "steerj_backward";
		string text3 = "steerj_position_in";
		string text4 = "steerj_position_out";
		if (parentHingeJointView.Index > 0)
		{
			text = text + "-" + parentHingeJointView.Index;
			text2 = text2 + "-" + parentHingeJointView.Index;
			text3 = text3 + "-" + parentHingeJointView.Index;
			text4 = text4 + "-" + parentHingeJointView.Index;
		}
		ForwardInput = parentBlockBodyView.AddLogicIO(new LogicIO(text, LogicIODirection.Input, 0f, LogicIOPlace.HingeJoint));
		BackwardInput = parentBlockBodyView.AddLogicIO(new LogicIO(text2, LogicIODirection.Input, 0f, LogicIOPlace.HingeJoint));
		PositionInput = parentBlockBodyView.AddLogicIO(new LogicIO(text3, LogicIODirection.Input, 0.5f, LogicIOPlace.HingeJoint)
		{
			IsInputWithoutKey = true
		});
		PositionOutput = parentBlockBodyView.AddLogicIO(new LogicIO(text4, LogicIODirection.Output, 0.5f, LogicIOPlace.HingeJoint));
		ForwardInput.ParentHingeJointView = parentHingeJointView;
		BackwardInput.ParentHingeJointView = parentHingeJointView;
		PositionInput.ParentHingeJointView = parentHingeJointView;
		PositionOutput.ParentHingeJointView = parentHingeJointView;
	}
}
