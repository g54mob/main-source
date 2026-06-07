using UnityEngine;

public class FixedMergeCreationsCommand : MergeCreationsCommand
{
	private BlockBodyModel firstBodyModel;

	private BlockBodyModel secondBodyModel;

	private FixedJointModel fixedJointModel;

	private bool isFullJoint;

	private Vector3 targetPosition;

	private Vector3 axisDirection;

	public FixedMergeCreationsCommand(MergeCreationsCommandData data, bool isWithFullInfo = false)
		: base(data)
	{
		firstBodyModel = toMergeCreationModel.GetSelectedBodyModel();
		secondBodyModel = baseCreationModel.GetBlockModel(data.SecondBlockId).GetBlockBodyModel(data.SecondBodyIndex);
		isFullJoint = isWithFullInfo;
		if (isFullJoint)
		{
			Vector3 referencePosition = data.BaseViewTransform.TransformPoint(firstBodyModel.ParentBlockModel.Position);
			Quaternion referenceRotation = data.BaseViewTransform.rotation * firstBodyModel.ParentBlockModel.Rotation;
			targetPosition = referencePosition.InverseTransformPoint(referenceRotation, data.TargetPosition);
			axisDirection = referenceRotation.InverseTransformDirection(data.AxisDirection);
		}
	}

	public override ConstructionCommandFeedback Execute()
	{
		ConstructionCommandFeedback constructionCommandFeedback = base.Execute();
		if (constructionCommandFeedback != ConstructionCommandFeedback.Executed)
		{
			return constructionCommandFeedback;
		}
		if (fixedJointModel == null)
		{
			if (isFullJoint)
			{
				fixedJointModel = baseCreationModel.FixedConnectTwoBlocks(firstBodyModel, secondBodyModel, targetPosition, axisDirection);
			}
			else
			{
				fixedJointModel = baseCreationModel.FixedConnectTwoBlocks(firstBodyModel, secondBodyModel);
			}
		}
		else
		{
			fixedJointModel = baseCreationModel.FixedConnectTwoBlocks(fixedJointModel);
		}
		baseCreationModel.UpdateInterconnectedBlocksAfterJoint(firstBodyModel.ParentBlockModel, secondBodyModel.ParentBlockModel);
		return constructionCommandFeedback;
	}

	public override void Revert()
	{
		baseCreationModel.RemoveFixedJoint(fixedJointModel);
		base.Revert();
		baseCreationModel.UpdateInterconnectedBlocks();
	}
}
