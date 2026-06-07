using System.Collections.Generic;

public class RemoveAllJointsCommand : Command<ConstructionCommandFeedback>
{
	private CreationModel creationModel;

	private BlockModel blockModel;

	private List<FixedJointModel> fixedJointModels;

	private List<HingeJointModel> hingeJointModels;

	public RemoveAllJointsCommand(CreationModel creationModel, int blockModelId)
	{
		this.creationModel = creationModel;
		blockModel = creationModel.GetBlockModel(blockModelId);
		fixedJointModels = new List<FixedJointModel>();
		hingeJointModels = new List<HingeJointModel>();
		foreach (BlockBodyModel allBlockBodyModel in blockModel.GetAllBlockBodyModels())
		{
			fixedJointModels.AddRange(allBlockBodyModel.GetAllFixedJointModel());
			fixedJointModels.AddRange(allBlockBodyModel.GetAllOutsideFixedJointModel());
			hingeJointModels.AddRange(allBlockBodyModel.GetAllHingeJointModel());
			hingeJointModels.AddRange(allBlockBodyModel.GetAllOutsideHingeJointModel());
		}
	}

	public override ConstructionCommandFeedback Execute()
	{
		creationModel.RemoveAllJoints(blockModel.Id);
		creationModel.UpdateInterconnectedBlocks();
		return ConstructionCommandFeedback.Executed;
	}

	public override void Revert()
	{
		foreach (FixedJointModel fixedJointModel in fixedJointModels)
		{
			creationModel.FixedConnectTwoBlocks(fixedJointModel);
		}
		foreach (HingeJointModel hingeJointModel in hingeJointModels)
		{
			creationModel.HingeConnectTwoBlocks(hingeJointModel);
		}
		creationModel.UpdateInterconnectedBlocks();
	}
}
