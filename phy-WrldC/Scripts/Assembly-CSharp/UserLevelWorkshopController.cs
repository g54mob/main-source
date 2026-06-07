using System.IO;
using Steamworks;

public class UserLevelWorkshopController : BaseWorkshopController<LevelModel>
{
	private LevelModel selectedLevelModel;

	private ulong workshopId;

	public UserLevelWorkshopController(UserLevelWorkshopView view)
		: base((BaseWorkshopView<LevelModel>)view)
	{
		uploadedTextId = "label.text.workshop.le.status.uploaded";
		notItemTextId = "label.text.workshop.le.status.notitem";
		notUploadedTextId = "label.text.workshop.le.status.notuploaded";
		notUpgradedTextId = "label.text.workshop.le.status.notupgraded";
		unsubscribedTextId = "label.text.workshop.le.status.unsubscribed";
		notUnsubscribedTextId = "label.text.workshop.le.status.notunsubscribed";
	}

	protected override void ViewChangeHandler(string eventName, params object[] data)
	{
		WOCMetaData wOCMetaData = null;
		switch (eventName)
		{
		case "BaseWorkshopView.ModelConfiguratedEvent":
		{
			LevelModel levelModel = data[0] as LevelModel;
			view.SetViewMode(BaseWorkshopView<LevelModel>.ViewMode.None);
			wOCMetaData = GetMetaDataFromLevelModel(levelModel);
			if (levelModel.Place == LevelModel.LevelPlace.User)
			{
				if (wOCMetaData == null)
				{
					view.SetViewMode(BaseWorkshopView<LevelModel>.ViewMode.Upload);
				}
				else if (ulong.TryParse(wOCMetaData.WorkshopId, out workshopId))
				{
					view.SetViewMode(BaseWorkshopView<LevelModel>.ViewMode.Upgrade);
				}
			}
			else if (levelModel.Place == LevelModel.LevelPlace.Workshop && wOCMetaData != null && ulong.TryParse(wOCMetaData.WorkshopId, out workshopId))
			{
				view.SetViewMode(BaseWorkshopView<LevelModel>.ViewMode.Unsubscribe);
			}
			selectedLevelModel = levelModel;
			break;
		}
		case "BaseWorkshopView.UploadItemEvent":
		case "BaseWorkshopView.UpgradeItemEvent":
		{
			LevelModel levelModel = data[0] as LevelModel;
			string name = levelModel.Name;
			string description = levelModel.Description;
			string filePath = levelModel.FilePath;
			string text = PathNames.UserLevels + "lvl_" + levelModel.Id + ".jpg";
			string text2 = PathNames.UserLevels + "lvl_" + levelModel.Id + ".wocmeta";
			string[] contentFilesPath = new string[3] { filePath, text, text2 };
			string[] tags = new string[1] { "Level" };
			steamWorkshopEvents.SetContent(name, description, contentFilesPath, tags, text);
			if (eventName == "BaseWorkshopView.UploadItemEvent")
			{
				steamWorkshopEvents.CreateNewItem();
			}
			else if (eventName == "BaseWorkshopView.UpgradeItemEvent")
			{
				steamWorkshopEvents.UpdateItem(workshopId);
			}
			string text3 = LanguagesManager.Instance.GetText("label.text.workshop.le.status.uploading");
			view.SetWarningText(text3, yellowColor);
			view.SetUploadUpgradeButtonInteractivity(isInteractable: false);
			break;
		}
		case "BaseWorkshopView.UnsubscribItemEvent":
		{
			LevelModel levelModel = data[0] as LevelModel;
			wOCMetaData = GetMetaDataFromLevelModel(levelModel);
			if (wOCMetaData != null && ulong.TryParse(wOCMetaData.WorkshopId, out workshopId))
			{
				steamWorkshopEvents.UnsubscribeItem(workshopId);
				view.SetUnsubscribeButtonInteractivity(isInteractable: false);
			}
			break;
		}
		case "BaseWorkshopView.OpenItemPageEvent":
		{
			LevelModel levelModel = data[0] as LevelModel;
			wOCMetaData = GetMetaDataFromLevelModel(levelModel);
			if (wOCMetaData != null && ulong.TryParse(wOCMetaData.WorkshopId, out workshopId))
			{
				SteamFriends.ActivateGameOverlayToWebPage("https://steamcommunity.com/workshop/filedetails/?id=" + workshopId);
			}
			break;
		}
		case "BaseWorkshopView.BackButtonEvent":
			GameManager.Instance.ExitSubState();
			break;
		}
	}

	protected override void OnFinishedCreateItemHandler(ulong publishedFileId)
	{
		WOCMetaData wOCMetaData = new WOCMetaData();
		wOCMetaData.WorkshopId = publishedFileId.ToString();
		wOCMetaData.LocalId = selectedLevelModel.Id;
		wOCMetaData.Type = WOCMetaData.FileType.Level;
		string directoryName = Path.GetDirectoryName(selectedLevelModel.FilePath);
		wOCMetaData.SaveToDisk(directoryName + "\\lvl_" + selectedLevelModel.Id + ".wocmeta");
	}

	private WOCMetaData GetMetaDataFromLevelModel(LevelModel levelModel)
	{
		string filePath = "";
		string directoryName = Path.GetDirectoryName(levelModel.FilePath);
		if (levelModel.Place == LevelModel.LevelPlace.User)
		{
			filePath = directoryName + "\\lvl_" + levelModel.Id + ".wocmeta";
		}
		else if (levelModel.Place == LevelModel.LevelPlace.Workshop)
		{
			string[] files = Directory.GetFiles(directoryName, "*.wocmeta", SearchOption.TopDirectoryOnly);
			if (files.Length == 0)
			{
				return null;
			}
			filePath = files[0];
		}
		return WOCMetaData.LoadFromDisk(filePath);
	}

	protected override void OnUploadedItemHandler(ulong publishedFileId)
	{
		base.OnUploadedItemHandler(publishedFileId);
		SteamAchievementsManager.Instance.UnlockAchievement(SteamAchievementsManager.Achievement.LEVEL_SENT_WORKSHOP);
	}
}
