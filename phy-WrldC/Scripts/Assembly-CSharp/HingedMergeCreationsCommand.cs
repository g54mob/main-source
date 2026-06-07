using UnityEngine;

public class HingedMergeCreationsCommand : MergeCreationsCommand
{
	private BlockBodyModel firstBodyModel;

	private BlockBodyModel secondBodyModel;

	private HingeJointModel hingeJointModel;

	private Vector3 targetPosition;

	private Vector3 axisDirection;

	public HingedMergeCreationsCommand(MergeCreationsCommandData data)
		: base(data)
	{
		firstBodyModel = toMergeCreationModel.GetSelectedBodyModel();
		secondBodyModel = baseCreationModel.GetBlockModel(data.SecondBlockId).GetBlockBodyModel(data.SecondBodyIndex);
		Vector3 referencePosition = data.BaseViewTransform.TransformPoint(firstBodyModel.ParentBlockModel.Position);
		Quaternion referenceRotation = data.BaseViewTransform.rotation * firstBodyModel.ParentBlockModel.Rotation;
		targetPosition = referencePosition.InverseTransformPoint(referenceRotation, data.TargetPosition);
		axisDirection = referenceRotation.InverseTransformDirection(data.AxisDirection);
		hingeJointModel = null;
	}

	public override ConstructionCommandFeedback Execute()
	{
		ConstructionCommandFeedback constructionCommandFeedback = base.Execute();
		if (constructionCommandFeedback != ConstructionCommandFeedback.Executed)
		{
			return constructionCommandFeedback;
		}
		if (hingeJointModel == null)
		{
			hingeJointModel = baseCreationModel.HingeConnectTwoBlocks(firstBodyModel, secondBodyModel, targetPosition, axisDirection);
		}
		else
		{
			hingeJointModel = baseCreationModel.HingeConnectTwoBlocks(hingeJointModel);
		}
		baseCreationModel.UpdateInterconnectedBlocksAfterJoint(firstBodyModel.ParentBlockModel, secondBodyModel.ParentBlockModel);
		return constructionCommandFeedback;
	}

	public override void Revert()
	{
		baseCreationModel.RemoveHingeJoint(hingeJointModel);
		base.Revert();
		baseCreationModel.UpdateInterconnectedBlocks();
	}
}
