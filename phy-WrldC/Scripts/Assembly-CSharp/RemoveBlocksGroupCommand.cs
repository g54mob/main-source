using System.Collections.Generic;

public class RemoveBlocksGroupCommand : Command<ConstructionCommandFeedback>
{
	private CreationModel creationModel;

	private List<BlockModel> removedBlockModels;

	public RemoveBlocksGroupCommand(CreationModel creationModel, int[] blockModelIds)
	{
		this.creationModel = creationModel;
		removedBlockModels = new List<BlockModel>();
		foreach (int id in blockModelIds)
		{
			removedBlockModels.Add(creationModel.GetBlockModel(id));
		}
	}

	public override ConstructionCommandFeedback Execute()
	{
		creationModel.RemoveGroupBlockModels(removedBlockModels);
		return ConstructionCommandFeedback.Executed;
	}

	public override void Revert()
	{
		creationModel.ReAddBlockModel(removedBlockModels);
		creationModel.UpdateInterconnectedBlocks();
	}
}
