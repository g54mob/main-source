using UnityEngine;

public class MergeCreationsCommand : Command<ConstructionCommandFeedback>
{
	protected CreationModel baseCreationModel;

	protected CreationModel toMergeCreationModel;

	public MergeCreationsCommand(MergeCreationsCommandData data)
	{
		baseCreationModel = data.BaseCreationModel;
		toMergeCreationModel = CreationCloner.Clone(data.ToMergeCreationModel);
		foreach (BlockModel item in toMergeCreationModel.GetAllBlockModel())
		{
			Vector3 position = data.ToMergeViewTransform.TransformPoint(item.Position);
			Quaternion quaternion = data.ToMergeViewTransform.rotation * item.Rotation;
			item.Position = data.BaseViewTransform.InverseTransformPoint(position);
			item.Rotation = Quaternion.Inverse(data.BaseViewTransform.rotation) * quaternion;
		}
	}

	public override ConstructionCommandFeedback Execute()
	{
		if (baseCreationModel.BrainBlockModel != null && toMergeCreationModel.BrainBlockModel != null)
		{
			return ConstructionCommandFeedback.MoreThanOneBrain;
		}
		toMergeCreationModel.ResetBlocksIds(baseCreationModel.GetHighestId() + 1);
		baseCreationModel.MergeCreationModel(toMergeCreationModel);
		return ConstructionCommandFeedback.Executed;
	}

	public override void Revert()
	{
		baseCreationModel.RemoveGroupBlockModels(toMergeCreationModel.GetAllBlockModel());
		foreach (Logic allLogic in toMergeCreationModel.LogicSystemModel.GetAllLogics())
		{
			baseCreationModel.LogicSystemModel.RemoveLogic(allLogic);
		}
	}
}
