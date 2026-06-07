using System.IO;

public class SaveLevelPartController : BaseController<SaveLevelPartView>
{
	public SaveLevelPartController(SaveLevelPartView view)
		: base(view)
	{
	}

	protected override void ViewChangeHandler(string eventName, params object[] data)
	{
		if (!(eventName == "SaveLevelPartView.SaveButtonEvent"))
		{
			if (eventName == "SaveLevelPartView.CloseButtonEvent")
			{
				GameManager.Instance.ExitSubState();
			}
		}
		else
		{
			CustomLevelObjectsModel customLevelObjectsModel = data[0] as CustomLevelObjectsModel;
			string name = (string)data[1];
			string description = (string)data[2];
			SaveButtonHandler(customLevelObjectsModel, name, description);
		}
	}

	private void SaveButtonHandler(CustomLevelObjectsModel customLevelObjectsModel, string name, string description)
	{
		if (!Util.IsValidFileName(name))
		{
			string text = LanguagesManager.Instance.GetText("warning.text.save.invalid", "Name Invalid!");
			GUIManager.Instance.WarningTooltipPanel.ShowWarningText(text, 20f, 0f);
			return;
		}
		string id = "u_" + name;
		CustomLevelObjectsModel clonedCustomLevelObjectsModel = LevelModelBuilder.Clone(customLevelObjectsModel);
		clonedCustomLevelObjectsModel.Id = id;
		clonedCustomLevelObjectsModel.Name = name;
		clonedCustomLevelObjectsModel.Description = description;
		clonedCustomLevelObjectsModel.Origin = CustomLevelObjectsModel.OriginEnum.UserPart;
		string pathToSave = PathNames.UserLevelParts + name + ".xml";
		if (File.Exists(pathToSave))
		{
			string text2 = LanguagesManager.Instance.GetText("message.header.le_save_part.overwrite", "Overwrite Level Part");
			string text3 = LanguagesManager.Instance.GetText("message.info.le_save_part.overwrite", "Already exist a level part with this name, should overwrite it?");
			GUIManager.Instance.ShowMessageBox(text2, text3, delegate
			{
				SaveOnDiskHandler(clonedCustomLevelObjectsModel, pathToSave, wasOverwritten: true);
			});
		}
		else
		{
			SaveOnDiskHandler(clonedCustomLevelObjectsModel, pathToSave, wasOverwritten: false);
		}
	}

	private void SaveOnDiskHandler(CustomLevelObjectsModel customLevelObjectsModel, string pathToSave, bool wasOverwritten)
	{
		customLevelObjectsModel.FilePath = pathToSave;
		LevelModelBuilder.SaveCustomLevelObjectsXml(customLevelObjectsModel, pathToSave);
		if (wasOverwritten)
		{
			GameManager.Instance.LECategoriesModel.RemoveItemByFilePath("User", pathToSave);
		}
		GameManager.Instance.LECategoriesModel.AddCategory("User", customLevelObjectsModel);
		GameManager.Instance.ExitSubState();
	}
}
