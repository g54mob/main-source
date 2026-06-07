using UnityEngine;

public class HingeJointModel : BaseModel
{
	public const string AddMotorJointEvent = "HingeJointModel.AddMotorJointEvent";

	public const string AddSteerableJointEvent = "HingeJointModel.AddSteerableJointEvent";

	public const string AddStepperJointEvent = "HingeJointModel.AddStepperJointEvent";

	public const string RemoveSpecializedJointsEvent = "HingeJointModel.RemoveSpecializedJointsEvent";

	public const string UpdateMotorJointEvent = "HingeJointModel.UpdateMotorJointEvent";

	public const string UpdateSteerableJointEvent = "HingeJointModel.UpdateSteerableJointEvent";

	public const string UpdateStepperJointEvent = "HingeJointModel.UpdateStepperJointEvent";

	public const string ConnectMotorToHingeJointEvent = "HingeJointModel.ConnectMotorToHingeJointEvent";

	public const string RemoveMotorFromHingeJointEvent = "HingeJointModel.RemoveMotorFromHingeJointEvent";

	public const string AnchorPointChangedEvent = "HingeJointModel.AnchorPointChangedEvent";

	private bool isThisAnchorPoint;

	private BlockBodyModel motorBlockBodyModel;

	public BlockBodyModel ParentBlockBodyModel { get; set; }

	public int Index { get; set; }

	public BlockBodyModel ConnectedBlockBodyModel { get; set; }

	public Vector3 Position { get; set; }

	public Vector3 AxisDirection { get; set; }

	public bool IsThisAnchorPoint
	{
		get
		{
			return isThisAnchorPoint;
		}
		set
		{
			isThisAnchorPoint = value;
			NotifyChange("HingeJointModel.AnchorPointChangedEvent", isThisAnchorPoint);
		}
	}

	public BlockBodyModel MotorBlockBodyModel
	{
		get
		{
			return motorBlockBodyModel;
		}
		set
		{
			motorBlockBodyModel = value;
			if (motorBlockBodyModel != null)
			{
				NotifyChange("HingeJointModel.ConnectMotorToHingeJointEvent", this, motorBlockBodyModel);
			}
			else
			{
				NotifyChange("HingeJointModel.RemoveMotorFromHingeJointEvent", this);
			}
		}
	}

	public MotorJointModel MotorJointModel { get; private set; }

	public SteerableJointModel SteerableJointModel { get; private set; }

	public StepperJointModel StepperJointModel { get; private set; }

	public HingeJointModel()
	{
		isThisAnchorPoint = false;
	}

	public void SetMotorJointModel(MotorJointModel motorJointModel)
	{
		if (MotorJointModel != null)
		{
			RemoveMotorJointModel();
		}
		MotorJointModel = motorJointModel;
		MotorJointModel.NotifyChangeEvent += MotorJointModelChangedHanlder;
		NotifyChange("HingeJointModel.AddMotorJointEvent", motorJointModel);
	}

	private void MotorJointModelChangedHanlder(string eventName, params object[] data)
	{
		if (eventName == "MotorJointModel.UpdateMotorJointEvent")
		{
			NotifyChange("HingeJointModel.UpdateMotorJointEvent", this);
		}
	}

	public void RemoveMotorJointModel()
	{
		if (MotorJointModel != null)
		{
			ParentBlockBodyModel.RemoveDefaultKeyIO(MotorJointModel.DefaultForward.Name);
			ParentBlockBodyModel.RemoveDefaultKeyIO(MotorJointModel.DefaultBackward.Name);
			ParentBlockBodyModel.RemoveDefaultKeyIO(MotorJointModel.DefaultBrake.Name);
			ParentBlockBodyModel.RemoveDefaultKeyIO(MotorJointModel.DefaultThrottleInput.Name);
			MotorJointModel.NotifyChangeEvent -= MotorJointModelChangedHanlder;
			MotorJointModel = null;
			NotifyChange("HingeJointModel.RemoveSpecializedJointsEvent", this);
		}
	}

	public void SetSteerableJointModel(SteerableJointModel steerableJointModel)
	{
		if (SteerableJointModel != null)
		{
			RemoveSteerableJointModel();
		}
		SteerableJointModel = steerableJointModel;
		SteerableJointModel.NotifyChangeEvent += SteerableJointModelChangedHanlder;
		NotifyChange("HingeJointModel.AddSteerableJointEvent", steerableJointModel);
	}

	private void SteerableJointModelChangedHanlder(string eventName, params object[] data)
	{
		if (eventName == "SteerableJointModel.UpdateSteerableJointEvent")
		{
			NotifyChange("HingeJointModel.UpdateSteerableJointEvent", this);
		}
	}

	public void RemoveSteerableJointModel()
	{
		if (SteerableJointModel != null)
		{
			ParentBlockBodyModel.RemoveDefaultKeyIO(SteerableJointModel.DefaultForward.Name);
			ParentBlockBodyModel.RemoveDefaultKeyIO(SteerableJointModel.DefaultBackward.Name);
			ParentBlockBodyModel.RemoveDefaultKeyIO(SteerableJointModel.DefaultPositionInput.Name);
			ParentBlockBodyModel.RemoveDefaultKeyIO(SteerableJointModel.DefaultPositionOutput.Name);
			SteerableJointModel.NotifyChangeEvent -= SteerableJointModelChangedHanlder;
			SteerableJointModel = null;
			NotifyChange("HingeJointModel.RemoveSpecializedJointsEvent", this);
		}
	}

	public void SetStepperJointModel(StepperJointModel stepperJointModel)
	{
		if (StepperJointModel != null)
		{
			RemoveStepperJointModel();
		}
		StepperJointModel = stepperJointModel;
		StepperJointModel.NotifyChangeEvent += StepperJointModelChangedHanlder;
		NotifyChange("HingeJointModel.AddStepperJointEvent", stepperJointModel);
	}

	private void StepperJointModelChangedHanlder(string eventName, params object[] data)
	{
		if (eventName == "StepperJointModel.UpdateStepperJointEvent")
		{
			NotifyChange("HingeJointModel.UpdateStepperJointEvent", this);
		}
	}

	public void RemoveStepperJointModel()
	{
		if (StepperJointModel != null)
		{
			ParentBlockBodyModel.RemoveDefaultKeyIO(StepperJointModel.DefaultForward.Name);
			ParentBlockBodyModel.RemoveDefaultKeyIO(StepperJointModel.DefaultBackward.Name);
			ParentBlockBodyModel.RemoveDefaultKeyIO(StepperJointModel.DefaultThrottleInput.Name);
			ParentBlockBodyModel.RemoveDefaultKeyIO(StepperJointModel.DefaultStepSpeedInput.Name);
			StepperJointModel.NotifyChangeEvent -= StepperJointModelChangedHanlder;
			StepperJointModel = null;
			NotifyChange("HingeJointModel.RemoveSpecializedJointsEvent", this);
		}
	}

	public void DetachHingeOnMotorBlock()
	{
		if (MotorBlockBodyModel != null)
		{
			ComponentModel componentModel = MotorBlockBodyModel.GetComponentModel(ComponentType.Motor);
			if (componentModel != null)
			{
				(componentModel.InternalProperties[MotorModel.Name] as MotorModel).RemoveHingeJointModel(this);
			}
		}
	}

	public bool CheckPhysicalPathBetweenMotor()
	{
		if (MotorBlockBodyModel == null)
		{
			return false;
		}
		BlockModel groupLeaderBlockModel = ParentBlockBodyModel.ParentBlockModel.GroupLeaderBlockModel;
		BlockModel groupLeaderBlockModel2 = MotorBlockBodyModel.ParentBlockModel.GroupLeaderBlockModel;
		return groupLeaderBlockModel == groupLeaderBlockModel2;
	}
}
