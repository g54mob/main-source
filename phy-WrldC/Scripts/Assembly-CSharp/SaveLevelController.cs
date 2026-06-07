using System.IO;
using UnityEngine;

public class SaveLevelController : BaseController<SaveLevelView>
{
	public SaveLevelController(SaveLevelView view)
		: base(view)
	{
	}

	protected override void ViewChangeHandler(string eventName, params object[] data)
	{
		if (!(eventName == "SaveLevelView.SaveButtonEvent"))
		{
			if (eventName == "SaveLevelView.CloseButtonEvent")
			{
				GameManager.Instance.ExitSubState();
			}
		}
		else
		{
			string name = (string)data[0];
			string description = (string)data[1];
			LevelEditorManager.Instance.CreateAllCustomLevelObjectsModel();
			SaveButtonHandler(name, description);
		}
	}

	private void SaveButtonHandler(string name, string description)
	{
		LevelModel clonedLevelModel = LevelModelBuilder.Clone(GameManager.Instance.LevelEditorManager.LevelModel);
		string text = name.ToLower();
		if (!Util.IsValidFileName(text))
		{
			string text2 = LanguagesManager.Instance.GetText("warning.text.save.invalid", "Name Invalid!");
			GUIManager.Instance.WarningTooltipPanel.ShowWarningText(text2, 20f, 0f);
			return;
		}
		clonedLevelModel.Id = text;
		clonedLevelModel.Name = name;
		clonedLevelModel.Description = description;
		clonedLevelModel.Place = LevelModel.LevelPlace.User;
		if (!Directory.Exists(PathNames.UserLevels))
		{
			Directory.CreateDirectory(PathNames.UserLevels);
		}
		if (File.Exists(PathNames.UserLevels + LevelModelBuilder.GetFileName(clonedLevelModel, isFileEncrypted: true, GameManager.LevelTypeState.User)))
		{
			string text3 = LanguagesManager.Instance.GetText("message.header.savelevel.overwrite", "Overwrite Level");
			string text4 = LanguagesManager.Instance.GetText("message.info.savelevel.overwrite", "Already exist a level with this name, should overwrite it?");
			GUIManager.Instance.ShowMessageBox(text3, text4, delegate
			{
				SaveOnDiskHandler(clonedLevelModel, PathNames.UserLevels, wasOverwritten: true);
			});
		}
		else
		{
			SaveOnDiskHandler(clonedLevelModel, PathNames.UserLevels, wasOverwritten: false);
		}
	}

	private void SaveOnDiskHandler(LevelModel levelModel, string directoryToSave, bool wasOverwritten)
	{
		LevelModelBuilder.SaveXml(levelModel, directoryToSave, isFileEncrypted: true, GameManager.LevelTypeState.User);
		LevelModel levelModel2 = GameManager.Instance.LevelEditorManager.LevelModel;
		levelModel2.Name = levelModel.Name;
		levelModel2.Description = levelModel.Description;
		GameManager.Instance.UserAndWorkshopLevelModelCollection.AddItem(levelModel, shouldOverride: true);
		GUIManager.Instance.LoadLevelView.RefreshOrderBy();
		if (wasOverwritten)
		{
			LevelStatus item = GameManager.Instance.UserProfileModel.UserLevelStatusList.GetItem(levelModel.Id);
			if (item != null)
			{
				GameManager.Instance.UserProfileModel.UserLevelStatusList.RemoveItem(item);
				UserProfileModelBuilder.SaveXmlFile(GameManager.Instance.UserProfileModel, PathNames.UserProfileAES, isFileEncrypted: true);
			}
		}
		string path = directoryToSave + "lvl_" + levelModel.Id + ".jpg";
		byte[] buffer = view.LevelTexture.EncodeToJPG(95);
		using (FileStream output = File.Open(path, FileMode.Create))
		{
			using (BinaryWriter binaryWriter = new BinaryWriter(output))
			{
				binaryWriter.Write(buffer);
			}
		}
		GameManager.Instance.UserAndWorkshopLevelThumbnailCollection.AddSprite("lvl_" + levelModel.Id, view.LevelSprite);
		GameManager.Instance.ExitAllSubStates();
	}
}
