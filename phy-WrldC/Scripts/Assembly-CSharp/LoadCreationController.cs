using System.IO;

public class LoadCreationController : BaseController<LoadCreationView, SavedCreationsModel>
{
	public LoadCreationController(LoadCreationView view, SavedCreationsModel model)
		: base(view, model, false)
	{
	}

	protected override void SyncViewWithModel()
	{
		view.ClearAllSlots();
		int num = 0;
		int num2 = 0;
		for (int i = 0; i < model.CreationModelCount(); i++)
		{
			CreationModel creationModel = model.GetCreationModel(i);
			int num3 = 0;
			if (creationModel.Place == CreationModel.CreationPlace.User)
			{
				num3 = num++;
			}
			else if (creationModel.Place == CreationModel.CreationPlace.Workshop)
			{
				num3 = num2++;
			}
			ModelChangeHandler("SavedCreationsModel.AddCreation", creationModel, num3);
		}
		view.RefreshPages();
	}

	protected override void ModelChangeHandler(string eventName, params object[] data)
	{
		if (!(eventName == "SavedCreationsModel.AddCreation"))
		{
			if (eventName == "SavedCreationsModel.RemoveCreation")
			{
				int index = (int)data[0];
				view.RemoveCreationSlot(index);
			}
		}
		else
		{
			CreationModel creationModel = (CreationModel)data[0];
			int index = (int)data[1];
			view.AddCreation(creationModel, index);
		}
	}

	protected override void ViewChangeHandler(string eventName, params object[] data)
	{
		switch (eventName)
		{
		case "LoadCreationView.LoadButtonEvent":
		{
			CreationModel configuration = (CreationModel)data[0];
			GameManager.Instance.ConstructionCommandManager.ClearAllCommands();
			GameManager.Instance.MainCreationController.SetModel(CreationCloner.Clone(configuration));
			GameManager.Instance.ChangeState(ConstructionState.Instance);
			break;
		}
		case "LoadCreationView.DeleteButtonEvent":
		{
			CreationModel configuration = (CreationModel)data[0];
			model.RemoveCreation(configuration);
			File.Delete(configuration.FilePath);
			string path = PathNames.UserCreations + configuration.Id + ".wocmeta";
			if (File.Exists(path))
			{
				File.Delete(path);
			}
			break;
		}
		case "LoadCreationView.WorkshopButtonEvent":
		{
			CreationModel configuration = (CreationModel)data[0];
			GUIManager.Instance.CreationWorkshopView.SetConfiguration(configuration);
			GameManager.Instance.SetSubState(CreationWorkshopState.Instance);
			break;
		}
		case "LoadCreationView.CloseButtonEvent":
			GameManager.Instance.ChangeState(ConstructionState.Instance);
			break;
		}
	}
}
