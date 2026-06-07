using UnityEngine;

public class AddTwoPointBlockCommand : Command<ConstructionCommandFeedback>
{
	private Command<ConstructionCommandFeedback> mergeCreationsCommand;

	private CreationModel baseCreationModel;

	private Vector3 basePosition;

	private Quaternion baseRotation;

	private Vector3 endPointPosition;

	private Quaternion endPointRotation;

	private bool isHingeJoint;

	private Vector3 targetPosition;

	private Vector3 axisDirection;

	private BlockBodyModel twoPointBodyModel;

	private BlockBodyModel secondConnectedBodyModel;

	private FixedJointModel fixedJointModel;

	private HingeJointModel hingeJointModel;

	public AddTwoPointBlockCommand(Command<ConstructionCommandFeedback> mergeCreationsCommand, AddTwoPointCommandData data)
	{
		this.mergeCreationsCommand = mergeCreationsCommand;
		baseCreationModel = data.BaseCreationModel;
		basePosition = data.BaseViewTransform.position;
		baseRotation = data.BaseViewTransform.rotation;
		endPointPosition = data.EndPointPosition;
		endPointRotation = data.EndPointRotation;
		isHingeJoint = data.IsHingeJoint;
		targetPosition = data.TargetPosition;
		axisDirection = data.AxisDirection;
		twoPointBodyModel = null;
		secondConnectedBodyModel = baseCreationModel.GetBlockModel(data.SecondBlockId).GetBlockBodyModel(data.SecondBodyIndex);
	}

	public override ConstructionCommandFeedback Execute()
	{
		ConstructionCommandFeedback constructionCommandFeedback = mergeCreationsCommand.Execute();
		if (constructionCommandFeedback != ConstructionCommandFeedback.Executed)
		{
			return constructionCommandFeedback;
		}
		if (twoPointBodyModel == null)
		{
			twoPointBodyModel = baseCreationModel.GetLastAddedBlockModel().GetBlockBodyModel(0);
			Vector3 referencePosition = basePosition.TransformPoint(baseRotation, twoPointBodyModel.ParentBlockModel.Position);
			Quaternion quaternion = baseRotation * twoPointBodyModel.ParentBlockModel.Rotation;
			targetPosition = referencePosition.InverseTransformPoint(quaternion, targetPosition);
			axisDirection = quaternion.InverseTransformDirection(axisDirection);
			endPointPosition = referencePosition.InverseTransformPoint(quaternion, endPointPosition);
			endPointRotation = Quaternion.Inverse(quaternion) * endPointRotation;
		}
		baseCreationModel.AddTwoPointBlock(twoPointBodyModel.ParentBlockModel.Id, twoPointBodyModel.Index, endPointPosition, endPointRotation);
		BlockBodyModel blockBodyModel = twoPointBodyModel;
		if (twoPointBodyModel.BodySchematic.TwoPointProperties.GetProperty("type") == "TwoBody")
		{
			blockBodyModel = twoPointBodyModel.ParentBlockModel.GetBlockBodyModel(1);
		}
		if (!isHingeJoint)
		{
			fixedJointModel = baseCreationModel.FixedConnectTwoBlocks(blockBodyModel, secondConnectedBodyModel, targetPosition, axisDirection);
		}
		else
		{
			hingeJointModel = baseCreationModel.HingeConnectTwoBlocks(blockBodyModel, secondConnectedBodyModel, targetPosition, axisDirection);
		}
		baseCreationModel.UpdateInterconnectedBlocksAfterJoint(twoPointBodyModel.ParentBlockModel, secondConnectedBodyModel.ParentBlockModel);
		return constructionCommandFeedback;
	}

	public override void Revert()
	{
		if (!isHingeJoint)
		{
			baseCreationModel.RemoveFixedJoint(fixedJointModel);
		}
		else
		{
			baseCreationModel.RemoveHingeJoint(hingeJointModel);
		}
		twoPointBodyModel.TwoPointBlockModel = null;
		mergeCreationsCommand.Revert();
	}
}
