public class RemoveHingeJointCommand : Command<ConstructionCommandFeedback>
{
	private CreationModel creationModel;

	private HingeJointModel hingeJointModel;

	public RemoveHingeJointCommand(CreationModel creationModel, HingeJointModel hingeJointModel)
	{
		this.creationModel = creationModel;
		this.hingeJointModel = hingeJointModel;
	}

	public override ConstructionCommandFeedback Execute()
	{
		creationModel.RemoveHingeJoint(hingeJointModel);
		creationModel.UpdateInterconnectedBlocks();
		return ConstructionCommandFeedback.Executed;
	}

	public override void Revert()
	{
		hingeJointModel = creationModel.HingeConnectTwoBlocks(hingeJointModel);
		BlockBodyModel parentBlockBodyModel = hingeJointModel.ParentBlockBodyModel;
		BlockBodyModel connectedBlockBodyModel = hingeJointModel.ConnectedBlockBodyModel;
		creationModel.UpdateInterconnectedBlocksAfterJoint(parentBlockBodyModel.ParentBlockModel, connectedBlockBodyModel.ParentBlockModel);
	}
}
