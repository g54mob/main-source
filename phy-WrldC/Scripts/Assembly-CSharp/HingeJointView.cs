using UnityEngine;

public class HingeJointView
{
	public BlockBodyView ParentBlockBodyView { get; set; }

	public int Index { get; set; }

	public HingeJoint HingeJoint { get; set; }

	public BlockBodyView ConnectedBlockBodyView { get; set; }

	public BlockBodyView MotorBodyBlockView { get; set; }

	public MotorJointView MotorJointView { get; private set; }

	public SteerableJointView SteerableJointView { get; private set; }

	public StepperJointView StepperJointView { get; private set; }

	public void SetMotorJointView(MotorJointView motorJointView)
	{
		if (MotorJointView != null)
		{
			RemoveMotorJointView();
		}
		MotorJointView = motorJointView;
	}

	public void RemoveMotorJointView()
	{
		if (MotorJointView != null)
		{
			ParentBlockBodyView.RemoveLogicIO(MotorJointView.ForwardInput);
			ParentBlockBodyView.RemoveLogicIO(MotorJointView.BackwardInput);
			ParentBlockBodyView.RemoveLogicIO(MotorJointView.BrakeInput);
			ParentBlockBodyView.RemoveLogicIO(MotorJointView.ThrottleInput);
			MotorJointView = null;
		}
	}

	public void SetSteerableJointView(SteerableJointView steerableJointView)
	{
		if (SteerableJointView != null)
		{
			RemoveSteerableJointView();
		}
		SteerableJointView = steerableJointView;
	}

	public void RemoveSteerableJointView()
	{
		if (SteerableJointView != null)
		{
			ParentBlockBodyView.RemoveLogicIO(SteerableJointView.ForwardInput);
			ParentBlockBodyView.RemoveLogicIO(SteerableJointView.BackwardInput);
			ParentBlockBodyView.RemoveLogicIO(SteerableJointView.PositionInput);
			ParentBlockBodyView.RemoveLogicIO(SteerableJointView.PositionOutput);
			SteerableJointView = null;
		}
	}

	public void SetStepperJointView(StepperJointView stepperJointView)
	{
		if (StepperJointView != null)
		{
			RemoveStepperJointView();
		}
		StepperJointView = stepperJointView;
	}

	public void RemoveStepperJointView()
	{
		if (StepperJointView != null)
		{
			ParentBlockBodyView.RemoveLogicIO(StepperJointView.ForwardInput);
			ParentBlockBodyView.RemoveLogicIO(StepperJointView.BackwardInput);
			ParentBlockBodyView.RemoveLogicIO(StepperJointView.ThrottleInput);
			ParentBlockBodyView.RemoveLogicIO(StepperJointView.StepSpeedInput);
			StepperJointView = null;
		}
	}

	public void RemoveSpecializedJointViews()
	{
		RemoveMotorJointView();
		RemoveSteerableJointView();
		RemoveStepperJointView();
	}
}
