public class RemoveBlockCommand : Command<ConstructionCommandFeedback>
{
	private CreationModel creationModel;

	private BlockModel removedBlockModel;

	public RemoveBlockCommand(CreationModel creationModel, int blockId)
	{
		this.creationModel = creationModel;
		removedBlockModel = creationModel.GetBlockModel(blockId);
	}

	public override ConstructionCommandFeedback Execute()
	{
		creationModel.RemoveBlockModel(removedBlockModel.Id);
		creationModel.UpdateInterconnectedBlocks();
		return ConstructionCommandFeedback.Executed;
	}

	public override void Revert()
	{
		creationModel.ReAddBlockModel(removedBlockModel);
		creationModel.UpdateInterconnectedBlocks();
	}
}
