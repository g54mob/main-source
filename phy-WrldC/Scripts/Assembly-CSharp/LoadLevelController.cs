using System.IO;

public class LoadLevelController : BaseController<LoadLevelView, GenericCollectionModel<LevelModel>>
{
	public LoadLevelController(LoadLevelView view, GenericCollectionModel<LevelModel> model)
		: base(view, model, false)
	{
	}

	protected override void SyncViewWithModel()
	{
		view.ClearAllSlots();
		foreach (LevelModel allItem in model.GetAllItems())
		{
			ModelChangeHandler("GenericCollectionModel.AddItemEvent", allItem);
		}
		view.RefreshPages();
	}

	protected override void ModelChangeHandler(string eventName, params object[] data)
	{
		switch (eventName)
		{
		case "GenericCollectionModel.AddItemEvent":
		{
			LevelModel levelModel = data[0] as LevelModel;
			view.AddUserLevelSlot(levelModel);
			break;
		}
		case "GenericCollectionModel.OverrideItemEvent":
		{
			LevelModel levelModel = data[0] as LevelModel;
			view.RemoveUserLoadLevelSlot(levelModel.Id);
			view.AddUserLevelSlot(levelModel);
			break;
		}
		case "GenericCollectionModel.RemoveItemEvent":
		{
			string levelModelId = data[0] as string;
			view.RemoveUserLoadLevelSlot(levelModelId);
			break;
		}
		}
	}

	protected override void ViewChangeHandler(string eventName, params object[] data)
	{
		LevelModel levelModel;
		switch (eventName)
		{
		case "LoadLevelView.PlayLevelEvent":
			levelModel = data[0] as LevelModel;
			if (levelModel.Place == LevelModel.LevelPlace.Workshop)
			{
				GameManager.Instance.LevelType = GameManager.LevelTypeState.Workshop;
			}
			else
			{
				GameManager.Instance.LevelType = GameManager.LevelTypeState.User;
			}
			GameManager.Instance.GameMode = GameManager.GameModeState.Attacker;
			GUIManager.Instance.FadeInToBlackAndExecuteAction(delegate
			{
				GameManager.Instance.LoadLevelAndChangeState(levelModel, StartLevelState.Instance);
			}, levelModel);
			break;
		case "LoadLevelView.LoadLevelEvent":
		{
			levelModel = data[0] as LevelModel;
			LevelModel levelModel2 = LevelModelBuilder.Clone(levelModel);
			levelModel2.Place = LevelModel.LevelPlace.Test;
			LevelEditorManager.Instance.LoadLevelModel(levelModel2);
			GameManager.Instance.ExitSubState();
			break;
		}
		case "LoadLevelView.WorkshopLevelEvent":
			levelModel = data[0] as LevelModel;
			_ = levelModel.Place;
			_ = 6;
			GUIManager.Instance.UserLevelWorkshopView.SetConfiguration(levelModel);
			GameManager.Instance.SetSubState(UserLevelWorkshopState.Instance);
			break;
		case "LoadLevelView.OpenLevelEvent":
		{
			levelModel = data[0] as LevelModel;
			LevelModel levelModel2 = LevelModelBuilder.Clone(levelModel);
			levelModel2.Place = LevelModel.LevelPlace.Test;
			if (view.IsNewTabSelected())
			{
				levelModel2.Name = LanguagesManager.Instance.GetText("label.text.leveleditor.level_name", "Level Name");
				levelModel2.Description = LanguagesManager.Instance.GetText("label.text.leveleditor.level_description", "Level Description");
			}
			GameManager.Instance.CurrentCustomLevelModel = levelModel2;
			GUIManager.Instance.FadeInToBlackAndExecuteAction(delegate
			{
				GameManager.Instance.LoadLevelEditorAndChangeState(LevelEditorState.Instance);
			});
			break;
		}
		case "LoadLevelView.BackButtonEvent":
			GameManager.Instance.ExitSubState();
			break;
		case "LoadLevelView.DeleteButtonEvent":
			levelModel = data[0] as LevelModel;
			GUIManager.Instance.ShowMessageBox(LanguagesManager.Instance.GetText("message.header.loadlevel.delete", "Level Delete"), LanguagesManager.Instance.GetText("message.info.loadlevel.delete", "Are you sure you want to remove this level?"), delegate
			{
				model.RemoveItem(levelModel);
				if (levelModel.LevelStatus != null)
				{
					GameManager.Instance.UserProfileModel.UserLevelStatusList.RemoveItem(levelModel.LevelStatus);
					UserProfileModelBuilder.SaveXmlFile(GameManager.Instance.UserProfileModel, PathNames.UserProfileAES, isFileEncrypted: true);
				}
				File.Delete(levelModel.FilePath);
				GameManager.Instance.UserAndWorkshopLevelThumbnailCollection.RemoveSprite("lvl_" + levelModel.Id);
				string path = PathNames.UserLevels + "lvl_" + levelModel.Id + ".png";
				if (File.Exists(path))
				{
					File.Delete(path);
				}
				string path2 = PathNames.UserLevels + "lvl_" + levelModel.Id + ".jpg";
				if (File.Exists(path2))
				{
					File.Delete(path2);
				}
				string path3 = PathNames.UserLevels + "lvl_" + levelModel.Id + ".wocmeta";
				if (File.Exists(path3))
				{
					File.Delete(path3);
				}
			});
			break;
		}
	}
}
