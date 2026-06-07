public class WorkshopTrendsController : BaseController<WorkshopTrendsView, WorkshopTrendsModel>
{
	public WorkshopTrendsController(WorkshopTrendsView view, WorkshopTrendsModel model)
		: base(view, model, false)
	{
	}

	protected override void SyncViewWithModel()
	{
		model.SelectedIndex = model.SelectedIndex;
	}

	protected override void ModelChangeHandler(string eventName, params object[] data)
	{
		if (eventName == "WorkshopWeekModel.SelectedIndexChangedEvent")
		{
			WorkshopTrendsModel.ItemData configuration = (WorkshopTrendsModel.ItemData)data[0];
			if (configuration.itemId != 0L)
			{
				view.SetConfiguration(configuration);
				view.RefreshPages(model.SelectedIndex + 1, model.ItemCount);
			}
		}
	}

	protected override void ViewChangeHandler(string eventName, params object[] data)
	{
		if (!(eventName == "WorkshopTrendsView.PreviousPageButtonEvent"))
		{
			if (eventName == "WorkshopTrendsView.CloseEvent")
			{
				view.MainMenuView.SetWorkshopTrendsVisibility(isPanelVisible: false, isButtonVisible: true);
				GameManager.Instance.OptionsModel.IsWorkshopTrendsPanelVisible = false;
				GameManager.Instance.OptionsModel.SaveValuesOnDisk();
			}
		}
		else
		{
			int num = (int)data[0];
			if (model.SelectedIndex + num < model.ItemCount)
			{
				model.SelectedIndex += num;
			}
			else
			{
				model.SelectedIndex = 0;
			}
		}
	}
}
