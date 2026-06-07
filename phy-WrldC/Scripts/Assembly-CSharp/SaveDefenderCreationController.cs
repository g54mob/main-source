using System.IO;

public class SaveDefenderCreationController : BaseController<SaveDefenderCreationView, LevelModel>
{
	public SaveDefenderCreationController(SaveDefenderCreationView view, LevelModel model)
		: base(view, model, false)
	{
	}

	protected override void SyncViewWithModel()
	{
		view.SetNameText(model.Name);
		view.SetDescriptionText(model.Description);
	}

	protected override void ModelChangeHandler(string eventName, params object[] data)
	{
	}

	protected override void ViewChangeHandler(string eventName, params object[] data)
	{
		switch (eventName)
		{
		case "SaveDefenderCreationView.SaveEvent":
		case "SaveDefenderCreationView.SaveAsNewEvent":
		{
			string name = (string)data[0];
			string description = (string)data[1];
			LevelModel levelModel = GameManager.Instance.LevelController.model;
			if (eventName == "SaveDefenderCreationView.SaveEvent")
			{
				if (File.Exists(levelModel.FilePath))
				{
					File.Delete(levelModel.FilePath);
				}
				levelModel.Name = name;
				levelModel.Description = description;
				levelModel.BestTime = float.PositiveInfinity;
				levelModel.DefenderCreationModel = GameManager.Instance.MainCreationController.model;
				LevelModelBuilder.SaveXml(levelModel, PathNames.UserLevels);
				GameManager.Instance.UserProfileModel.UserLevelStatusList.RemoveItem(levelModel.LevelStatus);
				UserProfileModelBuilder.SaveXmlFile(GameManager.Instance.UserProfileModel, PathNames.UserProfileAES, isFileEncrypted: true);
			}
			else if (eventName == "SaveDefenderCreationView.SaveAsNewEvent")
			{
				LevelModel levelModel2 = LevelModelBuilder.Clone(levelModel, shouldGiveNewId: true);
				levelModel2.Name = name;
				levelModel2.Description = description;
				levelModel2.BestTime = float.PositiveInfinity;
				levelModel2.DefenderCreationModel = GameManager.Instance.MainCreationController.model;
				LevelModelBuilder.SaveXml(levelModel2, PathNames.UserLevels);
				GameManager.Instance.DefenderLevelModelCollection.AddItem(levelModel2);
				GameManager.Instance.LevelController.SetModel(levelModel2);
			}
			GameManager.Instance.RevertToPreviousState();
			break;
		}
		case "SaveDefenderCreationView.CloseEvent":
			GameManager.Instance.RevertToPreviousState();
			break;
		}
	}
}
