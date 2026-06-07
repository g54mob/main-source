using System.Collections.Generic;

public class AutoFixedMergeCreationsCommand : FixedMergeCreationsCommand
{
	private Dictionary<BlockBodyModel, List<BlockBodyModel>> connectionsMap;

	private List<FixedJointModel> fixedJointModels;

	public AutoFixedMergeCreationsCommand(MergeCreationsCommandData data, Dictionary<BlockBodyView, List<BlockBodyView>> connectionsMap)
		: base(data, isWithFullInfo: true)
	{
		this.connectionsMap = new Dictionary<BlockBodyModel, List<BlockBodyModel>>();
		foreach (BlockBodyView key in connectionsMap.Keys)
		{
			BlockBodyModel blockBodyModel = toMergeCreationModel.GetBlockBodyModel(key.ParentBlockView.Id, key.Index);
			this.connectionsMap.Add(blockBodyModel, new List<BlockBodyModel>());
			foreach (BlockBodyView item in connectionsMap[key])
			{
				this.connectionsMap[blockBodyModel].Add(baseCreationModel.GetBlockBodyModel(item.ParentBlockView.Id, item.Index));
			}
		}
		fixedJointModels = new List<FixedJointModel>();
	}

	public override ConstructionCommandFeedback Execute()
	{
		ConstructionCommandFeedback constructionCommandFeedback = base.Execute();
		if (constructionCommandFeedback != ConstructionCommandFeedback.Executed)
		{
			return constructionCommandFeedback;
		}
		if (fixedJointModels.Count == 0)
		{
			foreach (BlockBodyModel key in connectionsMap.Keys)
			{
				foreach (BlockBodyModel item in connectionsMap[key])
				{
					fixedJointModels.Add(baseCreationModel.FixedConnectTwoBlocks(key, item));
					baseCreationModel.UpdateInterconnectedBlocksAfterJoint(key.ParentBlockModel, item.ParentBlockModel);
				}
			}
		}
		else
		{
			foreach (FixedJointModel fixedJointModel in fixedJointModels)
			{
				baseCreationModel.FixedConnectTwoBlocks(fixedJointModel);
				BlockBodyModel parentBlockBodyModel = fixedJointModel.ParentBlockBodyModel;
				BlockBodyModel connectedBlockBodyModel = fixedJointModel.ConnectedBlockBodyModel;
				baseCreationModel.UpdateInterconnectedBlocksAfterJoint(parentBlockBodyModel.ParentBlockModel, connectedBlockBodyModel.ParentBlockModel);
			}
		}
		return constructionCommandFeedback;
	}

	public override void Revert()
	{
		foreach (FixedJointModel fixedJointModel in fixedJointModels)
		{
			baseCreationModel.RemoveFixedJoint(fixedJointModel);
		}
		base.Revert();
	}
}
