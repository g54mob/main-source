public class CreationInfosController : BaseController<LevelCreationInfosView, CreationModel>
{
	public CreationInfosController(LevelCreationInfosView view, CreationModel model)
		: base(view, model, false)
	{
	}

	protected override void SyncViewWithModel()
	{
		view.SetCreationInfosValues(model.BlockModelCount, model.TotalCost(), model.TotalWeight());
	}

	protected override void ModelChangeHandler(string eventName, params object[] data)
	{
		switch (eventName)
		{
		case "CreationModel.AddBlockEvent":
		case "CreationModel.MergeCreationEvent":
		case "CreationModel.RemoveBlockEvent":
			view.SetCreationInfosValues(model.BlockModelCount, model.TotalCost(), model.TotalWeight());
			break;
		}
	}

	protected override void ViewChangeHandler(string eventName, params object[] data)
	{
		_ = eventName == "LevelCreationInfosView.CloseEvent";
	}
}
