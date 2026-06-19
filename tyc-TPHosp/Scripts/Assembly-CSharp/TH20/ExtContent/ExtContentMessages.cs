#define LOG_LEVEL_VERBOSE
using System;
using I2.Loc;
using UnityEngine;

namespace TH20.ExtContent
{
	public static class ExtContentMessages
	{
		private static MessageBox _messagBox;

		public static MessageBox MessageBox => _messagBox;

		public static void SetMessageBox(MessageBox messagBox)
		{
			_messagBox = messagBox;
		}

		public static void ShowMessageBoxOK(string titleStr, string bodyStr)
		{
			if (_messagBox != null)
			{
				_messagBox.SetUseNonFrostedPanelData(bUseNonFrostedPanelData: true);
				LogMessage(string.Format("Opened message box: Title: '{0}', Body: '{1}'", titleStr, bodyStr.Replace("\n", "")));
				_messagBox.Show(titleStr, bodyStr, ScriptLocalization.Menu_Messages.OK_Button_CS);
			}
		}

		public static void ShowErrorMessageBox(string titleStr, string bodyStr)
		{
			if (_messagBox != null)
			{
				_messagBox.SetUseNonFrostedPanelData(bUseNonFrostedPanelData: true);
				LogMessage(string.Format("Opened error message box: Title: '{0}', Body: '{1}'", titleStr, bodyStr.Replace("\n", "")));
				string bodyText = $"{bodyStr}\n\n{GetReferToLogFileMessage()}\n\n{GetReferToUGCDocsMessage()}";
				_messagBox.Show(titleStr, bodyText, ScriptLocalization.Menu_Messages.OK_Button_CS);
			}
		}

		public static void ShowPlayerGeneralErrorMessageBox()
		{
			string bodyStr = $"{GetMessageString(EMessageType.SomethingWentWrongBody)}\n\n{GetReferToLogFileMessage()}\n\n{GetReferToUGCDocsMessage()}";
			ShowMessageBoxOK(GetMessageString(EMessageType.SomethingWentWrongTitle), bodyStr);
		}

		public static void ShowOneOptionMessageBox(string titleText, string bodyText, string acknowledgeButtonText, string cancelButtonText, Action acknowledgeAction = null, Action cancelAction = null, bool option1ButtonsAutoHide = true)
		{
			if (_messagBox != null)
			{
				_messagBox.SetUseNonFrostedPanelData(bUseNonFrostedPanelData: true);
				_messagBox.ShowAsYesNo(titleText, bodyText, acknowledgeButtonText, cancelButtonText, acknowledgeAction, cancelAction, option1ButtonsAutoHide);
			}
		}

		public static void ShowTwoOptionMessageBox(string titleText, string bodyText, string button1Text, string button2Text, string cancelButtonText, Action button1Action = null, Action button2Action = null, Action cancelAction = null, bool option1ButtonsAutoHide = true, bool option2ButtonsAutoHide = true)
		{
			if (_messagBox != null)
			{
				_messagBox.SetUseNonFrostedPanelData(bUseNonFrostedPanelData: true);
				_messagBox.ShowAs2ChoiceAndCancel(titleText, bodyText, button1Text, button2Text, cancelButtonText, button1Action, button2Action, cancelAction, option1ButtonsAutoHide, option2ButtonsAutoHide);
			}
		}

		public static string GetMessageString(EMessageType messageType, bool bHiliteParams = true)
		{
			string text = string.Empty;
			switch (messageType)
			{
			case EMessageType.SuccessfullyCreatedWorkshopItem:
				text = "Successfully created workshop item '{0}' with PublishedFileId: {1}";
				break;
			case EMessageType.InvalidWorkshopItemCreationParameters:
				text = "Invalid workshop item creation parameters";
				break;
			case EMessageType.InvalidWorkshopItemUpdateParameters:
				text = "Invalid workshop item update parameters. Requires title, description and folder path";
				break;
			case EMessageType.InvalidWorkshopItemUpdateRootAssetName:
				text = "Invalid workshop item update root asset name parameter.";
				break;
			case EMessageType.SuccessfullyUploadedNewWorkshopItem:
				text = "Successfully uploaded workshop item '{0}' ({1}) with id {2} of type '{3}'from path '{4}'. Size: {5}";
				break;
			case EMessageType.SuccessfullyUploadedExistingWorkshopItem:
				text = "Successfully uploaded workshop item '{0}' ({1}) with id {2} from path '{3}'. Size: {4}";
				break;
			case EMessageType.SuccessfullyPublishedWorkshopItem:
				text = "Successfully published {0} workshop item '{1}' ({2}) with id {3} of type '{4}' from path '{5}'. Size: {6}";
				break;
			case EMessageType.CreateWorkshopItemError:
				text = "Error creating workshop item title '{0}'";
				break;
			case EMessageType.UploadWorkshopItemError:
				text = "Error uploading workshop item '{0}' with id {1} of type '{2}' from path '{3}'";
				break;
			case EMessageType.WorkshopItemInvalidContentType:
				text = "Invalid content type '{0}' for Workshop item '{1}'";
				break;
			case EMessageType.WorkshopItemUpdateDataFolderNotFound:
				text = "Could not find workshop item update data folder '{0}' for item '{1}'";
				break;
			case EMessageType.QueryWorkshopItemDetailFailed:
				text = "Workshop item query detail failed for item index {0}";
				break;
			case EMessageType.QueryWorkshopItemUnknownType:
				text = "Workshop query item id {0} has invalid content type '{1}'. This can happen when a subscribed to workshop item has been deleted on the steam workshop page without unsubscribing from first";
				break;
			case EMessageType.QueryWorkshopPageItemDetailFailed:
				text = "Workshop item query detail failed. Page {0}, Item {1} of {2} page items, {3} total items";
				break;
			case EMessageType.ErrorQueryingItemsPage:
				text = "Error querying ({0}) page {1} of all workshop items";
				break;
			case EMessageType.QueryWorkshopItemsDetailFailed:
				text = "Workshop items query detail failed";
				break;
			case EMessageType.WorkshopQueryItemsNumDetailsMismatch:
				text = "Workshop queried items details count mismatch. {0} / {1}";
				break;
			case EMessageType.WorkshopSubscribedItemsDetailsQueryError:
				text = "Workshop subscribed item query detail failed. Page {0}, Item {1} of {2} page items, {3} total items";
				break;
			case EMessageType.WorkshopZeroGetSubscribedItems:
				text = "Failed to obtain subscribed to workshop items";
				break;
			case EMessageType.ErrorObtainingWorkshopItemInstallInfo:
				text = "Error obtaining workshop item installed info for item id {0}";
				break;
			case EMessageType.SuccessfullyDeletedWorkshopItem:
				text = "Successfully deleted workshop item with with item id {0}";
				break;
			case EMessageType.ErrorDeletingWorkshopItem:
				text = "Error deleting workshop item with with item id {0}";
				break;
			case EMessageType.SuccessfullySubscribedToWorkshopItem:
				text = "Successfully subscribed to workshop item with item id {0}";
				break;
			case EMessageType.SuccessfullyUnsubscribedFromWorkshopItem:
				text = "Successfully unsubscribed from workshop item with item id {0}";
				break;
			case EMessageType.ErrorSubscribingToWorkshopItem:
				text = "Error subscribing to workshop item with item id {0}";
				break;
			case EMessageType.ErrorUnsubscribingFromWorkshopItem:
				text = "Error unsubscribing from workshop item with item id {0}";
				break;
			case EMessageType.ItemInstallFolderDoesNotExist:
				text = "Item id '{0}' install folder does not exist '{1}'";
				break;
			case EMessageType.ErrorLoadingAssetBundle:
				text = "Error loading asset bundle for item id '{0}' with file spec '{1}'";
				break;
			case EMessageType.SuccessfullyLoadedAssetBundle:
				text = "Successfully loaded asset bundle for item id '{0}' with file spec '{1}'";
				break;
			case EMessageType.NoInstalledItemsOfTypeFound:
				text = "Found no installed items of content type '{0}'";
				break;
			case EMessageType.ItemNotFullyInstalled:
				text = "Installed item '{0}' ({1}) of type '{2}' requires updating";
				break;
			case EMessageType.ErrorLoadingRootAsset:
				text = "Error loading root asset for item id '{0}' with root asset name '{1}'";
				break;
			case EMessageType.SuccessfullyLoadedRootAsset:
				text = "Successfully loaded root asset for item id '{0}' with root asset name '{1}'";
				break;
			case EMessageType.MissingRootAssetName:
				text = "Missing root asset name for item id '{0}'";
				break;
			case EMessageType.FailedToStartWorkshopItemDownload:
				text = "Failed to start download for Workshop item id {0}'. Invalid id or user not logged into Steam";
				break;
			case EMessageType.ErrorDownloadingWorkshopItem:
				text = "Error downloading Workshop item id {0}'";
				break;
			case EMessageType.ItemsDownloadCheckAlreadyInProgress:
				text = "Already currently checking for items needing updates";
				break;
			case EMessageType.SuccessfullyWroteWorkshopMetaDataFile:
				text = "Successfully wrote workshop item meta data file '{0}' (version {1})";
				break;
			case EMessageType.SuccessfullyWroteJSONFile:
				text = "Successfully wrote JSON file '{0}' with {1} values";
				break;
			case EMessageType.WorkshopMetaDataFileWriteErrorWriteException:
				text = "Workshop meta data file write exception '{1}' whilst writing file '{0}'";
				break;
			case EMessageType.JSONFileWriteErrorWriteException:
				text = "JSON file write exception '{1}' whilst writing file '{0}'";
				break;
			case EMessageType.WorkshopMetaDataFileWriteErrorGeneratedEmptyJSON:
				text = "Error generating valid Workshop meta data file JSON string";
				break;
			case EMessageType.JSONFileWriteErrorGeneratedEmptyJSON:
				text = "Error generating valid JSON file string";
				break;
			case EMessageType.WorkshopMetaDataFileWriteErrorGeneral:
				text = "Error writing Workshop meta data file with version {0} in folder '{1}'";
				break;
			case EMessageType.JSONFileWriteErrorGeneral:
				text = "Error writing json file '{1}' in folder '{0}' with {2} data values";
				break;
			case EMessageType.SuccessfullyReadMetaDataFile:
				text = "Successfully read workshop meta data file '{0}' (version {1})";
				break;
			case EMessageType.SuccessfullyReadJSONFile:
				text = "Successfully read workshop JSON file '{0}' with {1} data items";
				break;
			case EMessageType.WorkshopMetaDataFileReadErrorExtractingValues:
				text = "Error extracting valid values from read Workshop meta data file JSON data within file '{0}'";
				break;
			case EMessageType.WorkshopMetaDataFileReadErrorParsingJSON:
				text = "Error parsing Workshop meta data file JSON items. Read {0} items but expecting {1} within file '{2}'";
				break;
			case EMessageType.WorkshopMetaDataFileReadErrorReadingJSON:
				text = "Error reading JSON data from Workshop meta data file '{0}'";
				break;
			case EMessageType.JSONFileReadErrorReadingJSON:
				text = "Error reading JSON data from JSON file '{0}'";
				break;
			case EMessageType.WorkshopMetaDataFileReadErrorReadException:
				text = "Workshop meta data file read exception '{1}' whilst reading file '{0}'";
				break;
			case EMessageType.JSONFileReadErrorReadException:
				text = "JSON file read exception '{1}' whilst reading file '{0}'";
				break;
			case EMessageType.JSONFileDeleteErrorException:
				text = "JSON file delete exception '{1}' whilst deleting file '{0}'";
				break;
			case EMessageType.WorkshopMetaDataFileReadErrorInvalidFileSize:
				text = "Workshop meta data file invalid file size. Read {1} bytes (should be between {2} and {3}) within file '{0}'";
				break;
			case EMessageType.JSONFileReadErrorInvalidFileSize:
				text = "JSON file invalid file size. Read {1} bytes (should be between {2} and {3}) within file '{0}'";
				break;
			case EMessageType.WorkshopMetaDataFileReadErrorInvalidFolder:
				text = "Invalid folder name given for Workshop meta data file read";
				break;
			case EMessageType.JSONFileReadErrorInvalidFolder:
				text = "Invalid folder name given for JSON file read";
				break;
			case EMessageType.JSONFileDoesNotExist:
				text = "Error reading non existent JSON file '{0}'";
				break;
			case EMessageType.ErrorObtainingAssetBundleRootAssetName:
				text = "Error obtaining root asset name for asset bundle '{0}'";
				break;
			case EMessageType.SucessfullyAddedRoomItemToList:
				text = "Successfully added RoomItem '{0}' ({1}) - '{2}' to rooms list";
				break;
			case EMessageType.ErrorCreatingFolder:
				text = "Folder creation exception '{1}' whilst creating folder '{0}'";
				break;
			case EMessageType.SuccessfullyCreatedFolder:
				text = "Successfully created folder '{0}'";
				break;
			case EMessageType.ErrorCopyingLocalModsFile:
				text = "Copy file exception '{2}' whilst copying local mods file '{0}' to '{1}'";
				break;
			case EMessageType.SuccessfullyCreatedLocalModItem:
				text = "Successfully created / updated local mod item: {0}";
				break;
			case EMessageType.SuccessfullyCopiedLocalModFile:
				text = "Successfully copied local mod file from '{0}' to '{1}'";
				break;
			case EMessageType.SuccessfullyStartedWorkshopFolderPublish:
				text = "Successfully started workshop publish of item '{0}' from folder '{1}'";
				break;
			case EMessageType.FailedToFindGameItem:
				text = "Failed to find {0} game item using id type {1} and itemID '{2}'";
				break;
			case EMessageType.FailedToFindGameItemByID:
				text = "Failed to find {0} game item with content id '{1}'";
				break;
			case EMessageType.FailedToFindGameItemByTitle:
				text = "Failed to find {0} game item with title '{1}'";
				break;
			case EMessageType.FailedToFindGameItemByInstalledPath:
				text = "Failed to find {0} game item with installed path '{1}'";
				break;
			case EMessageType.InvalidGameItemForUpdatingLocalMod:
				text = "Invalid game item encountered attempting to update local mod '{0}'";
				break;
			case EMessageType.GameItemIsNotALocalMod:
				text = "Game item is not expected local mod item: '{0}'";
				break;
			case EMessageType.LocalModGameItemTitleNotUnique:
				text = "Local mod game item title '{0}' must be unique";
				break;
			case EMessageType.InvalidGameItemTitle:
				text = "Invalid game item title '{0}'";
				break;
			case EMessageType.InvalidGameItemRootAssetName:
				text = "Invalid game item root asset name '{0}'";
				break;
			case EMessageType.LocalModItemSourceFileNotExist:
				text = "Local mod item source file does not exist '{0}'";
				break;
			case EMessageType.LocalModItemSourceFolderInvalid:
				text = "Invalid local mod source folder name '{0}'";
				break;
			case EMessageType.LocalModItemInstalledFolderInvalid:
				text = "Invalid local mod installed folder name '{0}'";
				break;
			case EMessageType.LocalModItemSourceFileNameInvalid:
				text = "Invalid local mod source folder name '{0}'";
				break;
			case EMessageType.LocalModsFolderInvalidContentType:
				text = "Invalid content type '{0}' for local mods folder creation";
				break;
			case EMessageType.LocalModCopySourceFileDoesNotExist:
				text = "Source file for local mods copt does not exist '{0}'";
				break;
			case EMessageType.ExpectedGameItemContentTypeMismatch:
				text = "Game item creation content type mismatch. Expected '{0}' but found '{1}'";
				break;
			case EMessageType.InvalidGameItemMetaDataContentType:
				text = "Read invalid game item meta data content type '{0}'";
				break;
			case EMessageType.FolderDoesNotExistGeneral:
				text = "Folder does not exist '{0}'";
				break;
			case EMessageType.FolderNameInvalidGeneral:
				text = "Encountered invalid folder name '{0}'";
				break;
			case EMessageType.WorkshopPublishOperationAlreadyInProgress:
				text = "Error. Workshop publish operation is already in progress";
				break;
			case EMessageType.WorkshopPreviewImageFileDoesNotExist:
				text = "Workshop preview image file does not exist '{0}'";
				break;
			case EMessageType.SourceParamsDBJSONFileDoesNotExist:
				text = "Missing source params database JSON file '{0}'";
				break;
			case EMessageType.SourceParamsDatabaseJSONReadException:
				text = "Source params database JSON file read exception '{1}' whilst reading file '{0}'";
				break;
			case EMessageType.SourceParamsDatabaseErrorReadingJSON:
				text = "Source params database JSON file read error '{0}'";
				break;
			case EMessageType.SuccessfullyReadSourceParamsJSONFile:
				text = "Successfully read local mods source params database JSON file '{0}' with {1} data items";
				break;
			case EMessageType.InvalidSourceParamsDatabaseItemFound:
				text = "Removing invalid local mods source params database item '{0}'";
				break;
			case EMessageType.InvalidSourceParamsItemsFoundUpdatingFile:
				text = "Invalid items found, updating source params database JSON file '{0}' with {1} values";
				break;
			case EMessageType.ErrorObtainingSourceParamsDatabaseItem:
				text = "Error obtaining local mods source params database item '{0}'";
				break;
			case EMessageType.SuccessfullyDeletedFile:
				text = "Successfully deleted file '{0}'";
				break;
			case EMessageType.ErrorDeletingFile:
				text = "Error deleting file '{0}'. Exception: '{1}'";
				break;
			case EMessageType.FileToDeleteDoesNotExist:
				text = "File to delete does not exist '{0}'";
				break;
			case EMessageType.SuccessfullyDeletedFolder:
				text = "Successfully deleted folder '{0}'";
				break;
			case EMessageType.ErrorDeletingFolder:
				text = "Error deleting folder '{0}'. Exception: '{1}'";
				break;
			case EMessageType.FolderToDeleteDoesNotExist:
				text = "folder to delete does not exist '{0}'";
				break;
			case EMessageType.ExternalContentValidation:
				text = "External content validation";
				break;
			case EMessageType.AmendedLocalModItemContentIDs:
				text = "Found and resolved {0} invalid local mod item content IDs";
				break;
			case EMessageType.ErrorReadingImageFileGeneral:
				text = "Error reading image file '{0}'. Error: '{1}'";
				break;
			case EMessageType.ErrorWritingImageFileGeneral:
				text = "Error writing image file '{0}'. Error: '{1}'";
				break;
			case EMessageType.InvalidSourceImageFileSize:
				text = "Invalid source image file size of {1} bytes (should be between {2} and {3}) within file '{0}'";
				break;
			case EMessageType.UnsupportedImageFileType:
				text = "Unsupported image file type for file'{0}'";
				break;
			case EMessageType.InvalidFolderGeneral:
				text = "Folder name invalid or deos not exist '{0}'";
				break;
			case EMessageType.InvalidFileGeneral:
				text = "File invalid or deos not exist '{1}' within folder '{0}'";
				break;
			case EMessageType.InvalidFileSpecGeneral:
				text = "File invalid or does not exist '{0}'";
				break;
			case EMessageType.ErrorObtainingSandboxSaveTitle:
				text = "Error obtaining sandbox save title from path '{0}'";
				break;
			case EMessageType.ErrorObtainingMusicPackTitle:
				text = "Error obtaining music pack title from path '{0}'";
				break;
			case EMessageType.GameItemPassedPrePublishValidation:
				text = "Pre-publish validation socceeded for local mod item '{0}' in '{1}'";
				break;
			case EMessageType.GameItemFailedPrePublishValidation:
				text = "Pre-publish validation failed for local mod item '{0}' in '{1}'";
				break;
			case EMessageType.GameItemUICreateCreditsScreen:
				text = "Create a credits screen";
				break;
			case EMessageType.GameItemUIUpdateCreditsScreen:
				text = "Update a credits screen";
				break;
			case EMessageType.GameItemUICreateSandboxSave:
				text = "Create a sandbox save";
				break;
			case EMessageType.GameItemUIUpdateSandboxSave:
				text = "Update a sandbox save";
				break;
			case EMessageType.ErrorCreatingSandboxSavePreviewIcon:
				text = "Error creating sandbox save preview icon '{0}'";
				break;
			}
			switch (messageType)
			{
			case EMessageType.DynamicPlaylistResetMessageTitle:
				text = ScriptLocalization.Menu_UGC_MusicPack_Messages.ResetMusicListTitle_CS;
				break;
			case EMessageType.DynamicPlaylistResetMessageBody:
				text = ScriptLocalization.Menu_UGC_MusicPack_Messages.ResetMusicListBody_CS;
				break;
			case EMessageType.DynamicPlaylistAtLeastOneTrackMessageTitle:
				text = ScriptLocalization.Menu_UGC_MusicPack_Messages.AtLeastOneTrackTitle_CS;
				break;
			case EMessageType.DynamicPlaylistAtLeastOneTrackMessageBody:
				text = ScriptLocalization.Menu_UGC_MusicPack_Messages.AtLeastOneTrackBody_CS;
				break;
			case EMessageType.WorkshopItemsUpdateReceivedNotificationTitle:
				text = ScriptLocalization.Menu_Messages_UGC.WorkshopItemUpdatesReceived_Title_CS;
				break;
			case EMessageType.WorkshopItemsUpdateReceivedNotificationBody:
				text = ScriptLocalization.Menu_Messages_UGC.WorkshopItemUpdatesReceived_Body_CS;
				break;
			case EMessageType.WorkshopItemsExternalDataModifiedNotificationTitle:
				text = ScriptLocalization.Menu_Messages_UGC.WorkshopDataUpdatesReceived_Title_CS;
				break;
			case EMessageType.WorkshopItemsExternalDataModifiedNotificationBody:
				text = ScriptLocalization.Menu_Messages_UGC.WorkshopDataUpdatesReceived_Body_CS;
				break;
			case EMessageType.GameItemDeleteFailedMessageTitle:
				text = ScriptLocalization.Menu_Messages_UGC.DeleteFailed_Title_CS;
				break;
			case EMessageType.GameItemDeleteFailedMessageBody:
				text = ScriptLocalization.Menu_Messages_UGC.DeleteFailed_Body_CS;
				break;
			case EMessageType.LocalModAlreadyExistsMessageTitle:
				text = ScriptLocalization.Menu_Messages_UGC.InvalidTitle_Title_CS;
				break;
			case EMessageType.LocalModAlreadyExistsMessageBody:
				text = ScriptLocalization.Menu_Messages_UGC.InvalidTitle_Body_CS;
				break;
			case EMessageType.TitleContainsSpecialCharactersTitle:
				text = ScriptLocalization.Menu_Messages_UGC.InvalidTitle_Title_CS;
				break;
			case EMessageType.TitleContainsSpecialCharactersBody:
				text = ScriptLocalization.Menu_Messages_UGC.NoSpecialCharacters_Body_CS;
				break;
			case EMessageType.SomethingWentWrongTitle:
				text = ScriptLocalization.Menu_Messages_UGC.SomeThingWentWrong_Title_CS;
				break;
			case EMessageType.SomethingWentWrongBody:
				text = ScriptLocalization.Menu_Messages_UGC.SomeThingWentWrong_Body_CS;
				break;
			case EMessageType.WorkshopPublishErrorMessageTitle:
				text = ScriptLocalization.Menu_Messages_UGC.WorkshopPublishError_Title_CS;
				break;
			case EMessageType.WorkshopPublishErrorMessageBody:
				text = ScriptLocalization.Menu_Messages_UGC.WorkshopPublishError_Body_CS;
				break;
			case EMessageType.WorkshopPublishAbortMessageTitle:
				text = ScriptLocalization.Menu_UGC_MusicPack_Messages.WorkshopPublishFailedTitle_CS;
				break;
			case EMessageType.WorkshopPublishAbortMessageBody:
				text = ScriptLocalization.Menu_UGC_MusicPack_Messages.WorkshopPublishFailedBody_CS;
				break;
			case EMessageType.SteamWorkshopFeaturesErrorMessageTitle:
				text = ScriptLocalization.Menu_Messages_UGC.SteamWorkshopError_Title_CS;
				break;
			case EMessageType.SteamWorkshopFeaturesErrorMessageBody:
				text = ScriptLocalization.Menu_Messages_UGC.SteamWorkshopError_Body_CS;
				break;
			case EMessageType.GameItemUICreateAnItem:
				text = ScriptLocalization.Menu_UGC_Items.Title_Item_Create_CS;
				break;
			case EMessageType.GameItemUIUpdateAnItem:
				text = ScriptLocalization.Menu_UGC_Items.Title_Item_Update_CS;
				break;
			case EMessageType.GameItemUICreateRug:
				text = ScriptLocalization.Menu_UGC_Items.Title_Rug_Create_CS;
				break;
			case EMessageType.GameItemUICreatePicture:
				text = ScriptLocalization.Menu_UGC_Items.Title_Picture_Create_CS;
				break;
			case EMessageType.GameItemUICreateFloor:
				text = ScriptLocalization.Menu_UGC_RoomCustomisation.Title_Floor_Create_CS;
				break;
			case EMessageType.GameItemUICreateWall:
				text = ScriptLocalization.Menu_UGC_RoomCustomisation.Title_Wall_Create_CS;
				break;
			case EMessageType.GameItemUICreateMusicPack:
				text = ScriptLocalization.Menu_UGC_Items.Title_MusicPack_Create_CS;
				break;
			case EMessageType.GameItemUIUpdateRug:
				text = ScriptLocalization.Menu_UGC_Items.Title_Rug_Update_CS;
				break;
			case EMessageType.GameItemUIUpdatePicture:
				text = ScriptLocalization.Menu_UGC_Items.Title_Picture_Update_CS;
				break;
			case EMessageType.GameItemUIUpdateFloor:
				text = ScriptLocalization.Menu_UGC_RoomCustomisation.Title_Floor_Update_CS;
				break;
			case EMessageType.GameItemUIUpdateWall:
				text = ScriptLocalization.Menu_UGC_RoomCustomisation.Title_Wall_Update_CS;
				break;
			case EMessageType.GameItemUIUpdateMusicPack:
				text = ScriptLocalization.Menu_UGC_Items.Title_MusicPack_Update_CS;
				break;
			case EMessageType.GameItemDeleteConfirmTitle:
				text = ScriptLocalization.Menu_Messages_UGC.DeleteLocalMod_Title_CS;
				break;
			case EMessageType.GameItemDeleteConfirmBody:
				text = ScriptLocalization.Menu_Messages_UGC.DeleteLocalMod_Body_CS;
				break;
			case EMessageType.ThisWillDeleteGameItemInstances:
				text = ScriptLocalization.Menu_Messages_UGC.DeleteInstances_CS;
				break;
			case EMessageType.FileBrowserImageFilesLabel:
				text = ScriptLocalization.Menu_UGC_ImageBrowser.ImageFiles_CS;
				break;
			case EMessageType.FileBrowserMusicFilesLabel:
				text = ScriptLocalization.Menu_UGC_ImageBrowser.MusicFiles_CS;
				break;
			case EMessageType.FileBrowserSelectPreviewImage:
				text = ScriptLocalization.Menu_UGC_ImageBrowser.SelectPreviewImage_CS;
				break;
			case EMessageType.ReferToLogFileAtLocation:
				text = ScriptLocalization.Menu_Messages_UGC.LogFileLocation_CS;
				break;
			case EMessageType.ReferToUGCDocumentation:
				text = ScriptLocalization.Menu_Messages_UGC.UGCDocumentationLink_CS;
				break;
			case EMessageType.PublishScreenThisPackContains:
				text = ScriptLocalization.Menu_UGC_Publish.PackContents_CS;
				break;
			case EMessageType.GameItemUIButtonCreate:
				text = ScriptLocalization.Menu_UGC.Button_Create_CS;
				break;
			case EMessageType.GameItemUIButtonUpdate:
				text = ScriptLocalization.Menu_UGC.Button_Update_CS;
				break;
			case EMessageType.PublishItemUIButtonCreate:
				text = ScriptLocalization.Menu_UGC_Publish.Button_Create_CS;
				break;
			case EMessageType.PublishItemUIButtonUpdate:
				text = ScriptLocalization.Menu_UGC_Publish.Button_Update_CS;
				break;
			case EMessageType.ImageFileFailedToLoadMessageBoxTitle:
				text = ScriptLocalization.Menu_Messages_UGC.ImageLoadFailed_Title_CS;
				break;
			case EMessageType.ImageFileFailedToLoadMessageBoxBody:
				text = ScriptLocalization.Menu_Messages_UGC.ImageLoadFailed_Body_CS;
				break;
			case EMessageType.MaxNumMusicPackItemsAddedTitle:
				text = ScriptLocalization.Menu_UGC_MusicPack_Messages.MusicPackItemsLimitTitle_CS;
				break;
			case EMessageType.MaxNumMusicPackItemsAddedBody:
				text = ScriptLocalization.Menu_UGC_MusicPack_Messages.MusicPackItemsLimitBody_CS;
				break;
			case EMessageType.DuplicateMusicPackItemsEncounteredTitle:
				text = ScriptLocalization.Menu_UGC_MusicPack_Messages.DuplicateMusicPackItemsTitle_CS;
				break;
			case EMessageType.DuplicateMusicPackItemsEncounteredBody:
				text = ScriptLocalization.Menu_UGC_MusicPack_Messages.DuplicateMusicPackItemsBody_CS;
				break;
			}
			if (text.IsNullOrEmpty())
			{
				text = $"Unknown message: '{messageType.ToString()}'";
			}
			if (bHiliteParams)
			{
				text = ExtContentUtils.HiliteParams(text);
			}
			return text;
		}

		public static string GetReferToLogFileMessage()
		{
			string pathSpec = ExtContentUtils.GetPathSpec(Application.persistentDataPath, "Logs");
			pathSpec = ExtContentUtils.NormalisePathSpec(pathSpec);
			return string.Format(GetMessageString(EMessageType.ReferToLogFileAtLocation), pathSpec);
		}

		public static string GetReferToUGCDocsMessage()
		{
			return GetMessageString(EMessageType.ReferToUGCDocumentation);
		}

		public static void LogError(string errorStr)
		{
			string message = errorStr;
			if (WorkshopUtils.IsLastSteamResultError())
			{
				message = $"{errorStr}. Steam error {WorkshopUtils.GetLastSteamResultErrorCodeString()}";
			}
			Logging.Warning(LogChannels.ExternalContent, message);
		}

		public static void LogMessage(string msgStr)
		{
			Logging.Info(LogChannels.ExternalContent, msgStr);
		}

		public static void LogDebug(string msgStr)
		{
			Logging.Info(LogChannels.ExternalContent, msgStr);
		}
	}
}
