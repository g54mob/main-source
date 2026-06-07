public class ConnectBlocksCommand : Command<ConstructionCommandFeedback>
{
	private CreationModel creationModel;

	private BlockBodyModel firstBlockBodyModel;

	private BlockBodyModel secondBlockBodyModel;

	private FixedJointModel fixedJointModel;

	public ConnectBlocksCommand(CreationModel creationModel, int firstBlockId, int firstBlockBodyIndex, int secondBlockId, int secondBlockBodyIndex)
	{
		this.creationModel = creationModel;
		firstBlockBodyModel = creationModel.GetBlockModel(firstBlockId).GetBlockBodyModel(firstBlockBodyIndex);
		secondBlockBodyModel = creationModel.GetBlockModel(secondBlockId).GetBlockBodyModel(secondBlockBodyIndex);
	}

	public override ConstructionCommandFeedback Execute()
	{
		fixedJointModel = creationModel.FixedConnectTwoBlocks(firstBlockBodyModel, secondBlockBodyModel);
		creationModel.UpdateInterconnectedBlocksAfterJoint(firstBlockBodyModel.ParentBlockModel, secondBlockBodyModel.ParentBlockModel);
		return ConstructionCommandFeedback.Executed;
	}

	public override void Revert()
	{
		creationModel.RemoveFixedJoint(fixedJointModel);
		creationModel.UpdateInterconnectedBlocks();
	}
}
