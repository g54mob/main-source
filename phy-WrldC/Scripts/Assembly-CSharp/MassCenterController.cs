public class MassCenterController : BaseController<ConstructionToolsView, CreationModel>
{
	private ConstructionToolsModel constructionToolsModel;

	public MassCenterController(ConstructionToolsModel constructionToolsModel, ConstructionToolsView view, CreationModel model)
		: base(view, model, false)
	{
		this.constructionToolsModel = constructionToolsModel;
	}

	protected override void SyncViewWithModel()
	{
		if (constructionToolsModel.IsMassCenterVisible)
		{
			view.SetMassCenterPosition(GameManager.Instance.MainCreationController.view.GetMassCenter());
		}
	}

	protected override void ModelChangeHandler(string eventName, params object[] data)
	{
		switch (eventName)
		{
		case "CreationModel.AddBlockEvent":
		case "CreationModel.MergeCreationEvent":
		case "CreationModel.RemoveBlockEvent":
			if (constructionToolsModel.IsMassCenterVisible)
			{
				view.SetMassCenterPosition(GameManager.Instance.MainCreationController.view.GetMassCenter());
			}
			break;
		}
	}

	protected override void ViewChangeHandler(string eventName, params object[] data)
	{
	}
}
