using System.IO;
using Steamworks;

public class CreationWorkshopController : BaseWorkshopController<CreationModel>
{
	private CreationModel selectedCreationModel;

	private ulong workshopId;

	public CreationWorkshopController(CreationWorkshopView view)
		: base((BaseWorkshopView<CreationModel>)view)
	{
		uploadedTextId = "label.text.workshop.cp.status.uploaded";
		notItemTextId = "label.text.workshop.cp.status.notitem";
		notUploadedTextId = "label.text.workshop.cp.status.notuploaded";
		notUpgradedTextId = "label.text.workshop.cp.status.notupgraded";
		unsubscribedTextId = "label.text.workshop.cp.status.unsubscribed";
		notUnsubscribedTextId = "label.text.workshop.cp.status.notunsubscribed";
	}

	protected override void ViewChangeHandler(string eventName, params object[] data)
	{
		WOCMetaData wOCMetaData = null;
		switch (eventName)
		{
		case "BaseWorkshopView.ModelConfiguratedEvent":
		{
			CreationModel creationModel = data[0] as CreationModel;
			view.SetViewMode(BaseWorkshopView<CreationModel>.ViewMode.None);
			wOCMetaData = GetMetaDataFromCreationModel(creationModel);
			if (creationModel.Place == CreationModel.CreationPlace.User)
			{
				if (wOCMetaData == null)
				{
					view.SetViewMode(BaseWorkshopView<CreationModel>.ViewMode.Upload);
				}
				else if (ulong.TryParse(wOCMetaData.WorkshopId, out workshopId))
				{
					view.SetViewMode(BaseWorkshopView<CreationModel>.ViewMode.Upgrade);
				}
			}
			else if (creationModel.Place == CreationModel.CreationPlace.Workshop && wOCMetaData != null && ulong.TryParse(wOCMetaData.WorkshopId, out workshopId))
			{
				view.SetViewMode(BaseWorkshopView<CreationModel>.ViewMode.Unsubscribe);
			}
			selectedCreationModel = creationModel;
			break;
		}
		case "BaseWorkshopView.UploadItemEvent":
		case "BaseWorkshopView.UpgradeItemEvent":
		{
			CreationModel creationModel = data[0] as CreationModel;
			string name = creationModel.Name;
			string description = creationModel.Description;
			string filePath = creationModel.FilePath;
			string previewImagePath = PathNames.UserCreations + creationModel.Id + ".png";
			string text = PathNames.UserCreations + creationModel.Id + ".wocmeta";
			string[] contentFilesPath = new string[2] { filePath, text };
			string[] tags = new string[1] { "Contraption" };
			steamWorkshopEvents.SetContent(name, description, contentFilesPath, tags, previewImagePath);
			if (eventName == "BaseWorkshopView.UploadItemEvent")
			{
				steamWorkshopEvents.CreateNewItem();
			}
			else if (eventName == "BaseWorkshopView.UpgradeItemEvent")
			{
				steamWorkshopEvents.UpdateItem(workshopId);
			}
			string text2 = LanguagesManager.Instance.GetText("label.text.workshop.cp.status.uploading");
			view.SetWarningText(text2, yellowColor);
			view.SetUploadUpgradeButtonInteractivity(isInteractable: false);
			break;
		}
		case "BaseWorkshopView.UnsubscribItemEvent":
		{
			CreationModel creationModel = data[0] as CreationModel;
			wOCMetaData = GetMetaDataFromCreationModel(creationModel);
			if (wOCMetaData != null && ulong.TryParse(wOCMetaData.WorkshopId, out workshopId))
			{
				steamWorkshopEvents.UnsubscribeItem(workshopId);
				view.SetUnsubscribeButtonInteractivity(isInteractable: false);
			}
			break;
		}
		case "BaseWorkshopView.OpenItemPageEvent":
		{
			CreationModel creationModel = data[0] as CreationModel;
			wOCMetaData = GetMetaDataFromCreationModel(creationModel);
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
		wOCMetaData.LocalId = selectedCreationModel.Id;
		wOCMetaData.Type = WOCMetaData.FileType.Contraption;
		string directoryName = Path.GetDirectoryName(selectedCreationModel.FilePath);
		wOCMetaData.SaveToDisk(directoryName + "\\" + selectedCreationModel.Id + ".wocmeta");
	}

	private WOCMetaData GetMetaDataFromCreationModel(CreationModel creationModel)
	{
		string filePath = "";
		string directoryName = Path.GetDirectoryName(creationModel.FilePath);
		if (creationModel.Place == CreationModel.CreationPlace.User)
		{
			filePath = directoryName + "\\" + creationModel.Id + ".wocmeta";
		}
		else if (creationModel.Place == CreationModel.CreationPlace.Workshop)
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

	public void RemoveCreationThumbnailImage()
	{
		string path = PathNames.UserCreations + selectedCreationModel.Id + ".png";
		if (File.Exists(path))
		{
			File.Delete(path);
		}
	}

	protected override void OnUploadedItemHandler(ulong publishedFileId)
	{
		base.OnUploadedItemHandler(publishedFileId);
		SteamAchievementsManager.Instance.UnlockAchievement(SteamAchievementsManager.Achievement.CONTRAPTION_SENT_WORKSHOP);
	}
}
