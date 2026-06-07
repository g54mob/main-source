public class CreationButtonsController : BaseController<CreationButtonsView, CreationModel>
{
	public enum ButtonTypeEnum
	{
		Component = 0,
		HingeJoint = 1,
		AllJoints = 2,
		LogicIO = 3
	}

	public ButtonTypeEnum ButtonType { get; private set; }

	public CreationButtonsController(CreationButtonsView view, CreationModel model, ButtonTypeEnum buttonType)
		: base(view, model, false)
	{
		ButtonType = buttonType;
	}

	protected override void SyncViewWithModel()
	{
		view.RecycleAllObjectsBeforeDestroying();
		view.transform.RemoveAllChildren();
		view.SetPositions(model.Position, model.Rotation);
		foreach (BlockModel item in model.GetAllBlockModel())
		{
			ModelChangeHandler("CreationModel.AddBlockEvent", item);
		}
	}

	protected override void ModelChangeHandler(string eventName, params object[] data)
	{
		if (!(eventName == "CreationModel.AddBlockEvent"))
		{
			if (!(eventName == "CreationModel.MergeCreationEvent"))
			{
				_ = eventName == "CreationModel.RemoveBlockEvent";
			}
			return;
		}
		BlockModel blockModel = (BlockModel)data[0];
		if (ButtonType == ButtonTypeEnum.Component)
		{
			view.AddComponentButton(blockModel);
		}
		else if (ButtonType == ButtonTypeEnum.HingeJoint)
		{
			view.AddHingeJointButton(blockModel);
			view.AddMotorBlockButton(blockModel);
		}
		else if (ButtonType == ButtonTypeEnum.AllJoints)
		{
			view.AddAllJointsButton(blockModel);
		}
		else if (ButtonType == ButtonTypeEnum.LogicIO)
		{
			view.AddLogicIOsButton(blockModel);
		}
	}

	protected override void ViewChangeHandler(string eventName, params object[] data)
	{
	}
}
