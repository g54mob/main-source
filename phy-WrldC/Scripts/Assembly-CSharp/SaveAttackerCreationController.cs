using System.IO;

public class SaveAttackerCreationController : BaseController<SaveAttackerCreationView>
{
	public SaveAttackerCreationController(SaveAttackerCreationView view)
		: base(view)
	{
	}

	protected override void ViewChangeHandler(string eventName, params object[] data)
	{
		if (!(eventName == "SaveAttackerCreationView.SaveButtonEvent"))
		{
			if (eventName == "SaveAttackerCreationView.CloseButtonEvent")
			{
				GameManager.Instance.ChangeState(ConstructionState.Instance);
			}
		}
		else
		{
			string name = (string)data[0];
			string description = (string)data[1];
			bool isPart = (bool)data[2];
			bool isDev = (bool)data[3];
			SaveButtonHandler(name, description, isPart, isDev);
		}
	}

	private void SaveButtonHandler(string name, string description, bool isPart, bool isDev)
	{
		CreationModel toSaveCreationModel = GameManager.Instance.ToSaveCreationModel;
		if (!Util.IsValidFileName(name))
		{
			string text = LanguagesManager.Instance.GetText("warning.text.save.invalid", "Name Invalid!");
			GUIManager.Instance.WarningTooltipPanel.ShowWarningText(text, 20f, 0f);
			return;
		}
		if (isPart && toSaveCreationModel.BlockModelCount > 30)
		{
			string text2 = LanguagesManager.Instance.GetText("warning.text.save.limit", "Blocks Limit!");
			GUIManager.Instance.WarningTooltipPanel.ShowWarningText(text2, 20f, 0f);
			return;
		}
		string text3 = ((isPart && !isDev) ? ("u_" + name.ToLower()) : name.ToLower());
		CreationModel clonedCreationModel = CreationCloner.Clone(toSaveCreationModel);
		clonedCreationModel.Id = text3;
		clonedCreationModel.Name = name;
		clonedCreationModel.Description = description;
		clonedCreationModel.Place = CreationModel.CreationPlace.User;
		string pathToSave;
		if (isPart)
		{
			if (isDev)
			{
				pathToSave = PathNames.DevParts + text3 + ".sav";
			}
			else
			{
				pathToSave = PathNames.UserParts + text3 + ".sav";
			}
		}
		else
		{
			pathToSave = PathNames.UserCreations + text3 + ".sav";
		}
		if (File.Exists(pathToSave))
		{
			string text4 = LanguagesManager.Instance.GetText("message.header.save.overwrite", "Overwrite Creation");
			string text5 = LanguagesManager.Instance.GetText("message.info.save.overwrite", "Already exist a creation with this name, should overwrite it?");
			GUIManager.Instance.ShowMessageBox(text4, text5, delegate
			{
				SaveOnDiskHandler(clonedCreationModel, pathToSave, isPart && !isDev, wasOverwritten: true);
			});
		}
		else
		{
			SaveOnDiskHandler(clonedCreationModel, pathToSave, isPart && !isDev, wasOverwritten: false);
		}
	}

	private void SaveOnDiskHandler(CreationModel creationModel, string pathToSave, bool isUserPart, bool wasOverwritten)
	{
		creationModel.FilePath = pathToSave;
		CreationModelBuilder.SaveXml(creationModel, pathToSave, isFileEncrypted: true);
		if (isUserPart)
		{
			if (wasOverwritten)
			{
				GameManager.Instance.CategoriesModel.RemoveItemByFilePath("User", pathToSave);
			}
			creationModel.IsDeletable = true;
			GameManager.Instance.CategoriesModel.AddCategory("User", creationModel);
		}
		else
		{
			if (wasOverwritten)
			{
				GameManager.Instance.SavedCreationsModel.RemoveCreationByFilePath(pathToSave);
			}
			GameManager.Instance.SavedCreationsModel.AddCreation(creationModel);
			GUIManager.Instance.LoadCreationView.RefreshOrderBy();
		}
		view.ClearToggles();
		if (GameManager.Instance.ToSaveCreationModel == GameManager.Instance.MainCreationController.model)
		{
			CreationModel model = GameManager.Instance.MainCreationController.model;
			model.Name = creationModel.Name;
			model.Description = creationModel.Description;
		}
		GameManager.Instance.ChangeState(ConstructionState.Instance);
	}
}
