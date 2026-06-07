public class RemoveFixedJointCommand : Command<ConstructionCommandFeedback>
{
	private CreationModel creationModel;

	private FixedJointModel fixedJointModel;

	public RemoveFixedJointCommand(CreationModel creationModel, FixedJointModel fixedJointModel)
	{
		this.creationModel = creationModel;
		this.fixedJointModel = fixedJointModel;
	}

	public override ConstructionCommandFeedback Execute()
	{
		creationModel.RemoveFixedJoint(fixedJointModel);
		creationModel.UpdateInterconnectedBlocks();
		return ConstructionCommandFeedback.Executed;
	}

	public override void Revert()
	{
		fixedJointModel = creationModel.FixedConnectTwoBlocks(fixedJointModel);
		BlockBodyModel parentBlockBodyModel = fixedJointModel.ParentBlockBodyModel;
		BlockBodyModel connectedBlockBodyModel = fixedJointModel.ConnectedBlockBodyModel;
		creationModel.UpdateInterconnectedBlocksAfterJoint(parentBlockBodyModel.ParentBlockModel, connectedBlockBodyModel.ParentBlockModel);
	}
}
