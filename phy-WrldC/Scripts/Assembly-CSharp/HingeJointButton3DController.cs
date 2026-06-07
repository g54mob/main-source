using UnityEngine;

public class HingeJointButton3DController : BaseController<HingeJointButton3D, HingeJointModel>
{
	public HingeJointButton3DController(HingeJointButton3D view, HingeJointModel model)
		: base(view, model, false)
	{
	}

	protected override void SyncViewWithModel()
	{
		if (model.MotorBlockBodyModel != null)
		{
			Vector3 position = model.MotorBlockBodyModel.ParentBlockModel.Position;
			view.UpdateConnectedMotorLine(position);
			bool isTherePath = model.CheckPhysicalPathBetweenMotor();
			view.UpdateConnectionPathIndicator(isTherePath);
		}
		else
		{
			view.HideConnectedMotorLine();
			view.UpdateConnectionPathIndicator(isTherePath: false);
		}
		if (model.MotorJointModel != null)
		{
			view.UpdateMotorJointGizmos(model.MotorJointModel.IsClockwiseRotation);
		}
		else if (model.SteerableJointModel != null)
		{
			view.UpdateSteerableJointGizmos(model.SteerableJointModel.ForwardTarget, model.SteerableJointModel.BackwardTarget, model.SteerableJointModel.AngleOffset);
		}
		else if (model.StepperJointModel != null)
		{
			bool isClockwiseRotation = model.StepperJointModel.IsClockwiseRotation;
			float degreesPerSecond = model.StepperJointModel.DegreesPerSecond;
			view.UpdateStepperJointGizmos(isClockwiseRotation, degreesPerSecond);
		}
		else
		{
			view.HideSpecializedJointsGizmos();
		}
		ModelChangeHandler("HingeJointModel.AnchorPointChangedEvent", model.IsThisAnchorPoint);
	}

	protected override void ModelChangeHandler(string eventName, params object[] data)
	{
		switch (eventName)
		{
		case "HingeJointModel.AddMotorJointEvent":
		case "HingeJointModel.UpdateMotorJointEvent":
			if (model.MotorJointModel != null)
			{
				view.UpdateMotorJointGizmos(model.MotorJointModel.IsClockwiseRotation);
			}
			break;
		case "HingeJointModel.AddSteerableJointEvent":
		case "HingeJointModel.UpdateSteerableJointEvent":
			if (model.SteerableJointModel != null)
			{
				view.UpdateSteerableJointGizmos(model.SteerableJointModel.ForwardTarget, model.SteerableJointModel.BackwardTarget, model.SteerableJointModel.AngleOffset);
			}
			break;
		case "HingeJointModel.AddStepperJointEvent":
		case "HingeJointModel.UpdateStepperJointEvent":
			if (model.StepperJointModel != null)
			{
				bool isClockwiseRotation = model.StepperJointModel.IsClockwiseRotation;
				float degreesPerSecond = model.StepperJointModel.DegreesPerSecond;
				view.UpdateStepperJointGizmos(isClockwiseRotation, degreesPerSecond);
			}
			break;
		case "HingeJointModel.RemoveSpecializedJointsEvent":
			view.HideSpecializedJointsGizmos();
			break;
		case "HingeJointModel.ConnectMotorToHingeJointEvent":
		{
			Vector3 position = model.MotorBlockBodyModel.ParentBlockModel.Position;
			view.UpdateConnectedMotorLine(position);
			bool isTherePath = model.CheckPhysicalPathBetweenMotor();
			view.UpdateConnectionPathIndicator(isTherePath);
			break;
		}
		case "HingeJointModel.RemoveMotorFromHingeJointEvent":
			view.HideConnectedMotorLine();
			view.UpdateConnectionPathIndicator(isTherePath: false);
			break;
		case "HingeJointModel.AnchorPointChangedEvent":
		{
			bool flag = (bool)data[0];
			Vector3 blockPosition = (flag ? model.ParentBlockBodyModel.ParentBlockModel.Position : model.ConnectedBlockBodyModel.ParentBlockModel.Position);
			view.UpdateAnchorLinePosition(blockPosition);
			view.InvertRotationalIndicatorsLogic(flag);
			break;
		}
		}
	}

	protected override void ViewChangeHandler(string eventName, params object[] data)
	{
	}
}
