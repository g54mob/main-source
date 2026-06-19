using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Steamworks;
using UnityEngine;

namespace TH20.ExtContent
{
	public class WorkshopContentCreationManager
	{
		public class WorkshopContentCreationConfig
		{
			public bool bInvokeSteamOverlayOnPublish = true;

			public bool bInvokeSteamOverlayAgreementPage;

			public long cMaximumPreviewImageFileSizeKB = 1024L;

			public long cMaximumPreviewImageFileSizeToleranceKB = 50L;

			public float previewImageDownscalingFactor = 0.1f;

			public int previewImageDownscalingMaxIterations = 32;

			public float previewImageDownscalingScaleFactorStart = 0.2f;

			public float previewImageDownscalingScaleFactorDecrMultiplier = 0.5f;

			public float previewImageDownscalingScaleFactorIncrAddition = 0.01f;

			public string steamOverlayWorkshopPageURL = "https://steamcommunity.com/workshop/browse/?appid=535930&browsesort=trend&section=readytouseitems";

			public string steamOverlayWorkshopPublishBaseURL = "steam://url/CommunityFilePage/";

			public string steamOverlayWorkshopAgreementURL = "https://steamcommunity.com/sharedfiles/workshoplegalagreement";

			public string steamOverlayWorkshopPageURLBrowser = "https://steamcommunity.com/workshop/browse/?appid=535930&browsesort=trend&section=readytouseitems";

			public string steamOverlayWorkshopPublishBaseURLBrowser = "https://steamcommunity.com/sharedfiles/filedetails/?id=";

			public string steamOverlayWorkshopAgreementURLBrowser = "https://steamcommunity.com/sharedfiles/workshoplegalagreement";

			public string[] workshopPreviewImageFileNames;
		}

		public delegate void OnPublishStartedCallback(string publishFolderSpec);

		public delegate void OnPublishCompleteCallback(bool bSuccess, bool bAborted, bool bNewItem, WorkshopItemMetaData workshopItemMetaData, string publishFolderSpec);

		public delegate void OnPublishPreUploadCallback(bool bSuccess, bool bNewItem, WorkshopItemMetaData workshopItemMetaData, string publishFolderSpec);

		public delegate void OnPublishPostUploadCallback(bool bSuccess, bool bNewItem, WorkshopItemMetaData workshopItemMetaData, string publishFolderSpec);

		private class ProcessValidWorkshopItemPreviewImageCoroutineRetParams
		{
			public string _validatedPreviewImageFileSpec;
		}

		private class ProcessIsScaledEncoodedTextureSizeValidRetParams
		{
			public bool _bErrorEncountered;

			public bool _bFileSizeValid;

			public bool _bFileSizeWithinTolerance;
		}

		public const float cUploadProgressReportPeriodSecs = 0.5f;

		public const string cWorkshopDefaultAssetsFolderName = "Workshop";

		public const string cWorkshopDefaultPreviewImagesFolderName = "DefaultPreviewImages";

		public const string cWorkshopDefaultPreviewImageFileName = "DefaultPreviewImage.png";

		public const string cWorkshopSourceParamsDatabaseFileName = "WorkshopSourceParamsDB.json";

		public const string cKey_SourceWorkshopPreviewFileSpec = "SourcePreviewFileSpec";

		private WorkshopContentCreationConfig _config;

		private ExtContentManager _extContentManager;

		private LocalSourceParamsDatabase _workshopSourceParamsDatabase;

		private MonoBehaviour _behaviourToRunCoroutinesOn;

		private Coroutine _publishCoroutine;

		private Coroutine _abortPublishDeleteItemCoroutine;

		private string _contentRootFolderSpec;

		private bool _lastQueriedPublishedFileIdValid;

		private bool _openSteamOverlayPending;

		private string _openSteamOverlayPendingURLSteam;

		private string _openSteamOverlayPendingURLBrowser;

		private string _currentlyPublishingPublishedFileIdStr;

		private bool _currentlyPublishingCreateNewReqd;

		private WorkshopItemMetaData _currentlyPublishingWorkshopItemMetaData;

		private string _currentlyPublishingPublishFolderSpec;

		private bool _bCurrentlyDeletingPublishedItem;

		public event OnPublishStartedCallback OnPublishStarted;

		public event OnPublishCompleteCallback OnPublishComplete;

		public event OnPublishPreUploadCallback OnPublishPreUpload;

		public event OnPublishPostUploadCallback OnPublishPostUpload;

		public WorkshopContentCreationManager(WorkshopContentCreationConfig config)
		{
			_config = config;
		}

		public void Init(ExtContentManager extContentManager)
		{
			_extContentManager = extContentManager;
			_behaviourToRunCoroutinesOn = _extContentManager.BehaviourToRunCoroutinesOn;
			_contentRootFolderSpec = _extContentManager.ContentSourceLocalMods.GetLocalModsFolderSpec();
			_workshopSourceParamsDatabase = new LocalSourceParamsDatabase();
			_workshopSourceParamsDatabase.Init(_contentRootFolderSpec, "WorkshopSourceParamsDB.json");
		}

		public void DeInit()
		{
			StopAllCoroutines();
			_workshopSourceParamsDatabase?.DeInit();
			_workshopSourceParamsDatabase = null;
		}

		public bool IsCurrentlyUsingOnlineServices()
		{
			if (_publishCoroutine == null)
			{
				return _abortPublishDeleteItemCoroutine != null;
			}
			return true;
		}

		public bool PublishGameItemToWorkshop(GameItemBase gameItemBase, string workshopItemTitle, string workshopItemDescription, string workshopItemPreviewImageFileSpec, EItemVisibility workshopItemVisibility, bool bForceCreateNewWorkshopItem)
		{
			bool result = false;
			if (gameItemBase != null && PublishFolderToWorkshop(gameItemBase.InstalledFolderPathSpec, workshopItemTitle, workshopItemDescription, workshopItemPreviewImageFileSpec, workshopItemVisibility, bForceCreateNewWorkshopItem))
			{
				result = true;
			}
			return result;
		}

		public bool PublishFolderToWorkshop(string folderSpec, string workshopItemTitle, string workshopItemDescription, string workshopItemPreviewImageFileSpec, EItemVisibility workshopItemVisibility, bool bForceCreateNewWorkshopItem)
		{
			bool result = true;
			string retPublishFolderSpec = string.Empty;
			if (DetermineValidPublishFolderSpec(folderSpec, ref retPublishFolderSpec) && StartPublishCoroutine(retPublishFolderSpec, workshopItemTitle, workshopItemDescription, workshopItemPreviewImageFileSpec, workshopItemVisibility, bForceCreateNewWorkshopItem))
			{
				result = true;
				ExtContentMessages.LogMessage(string.Format(ExtContentMessages.GetMessageString(EMessageType.SuccessfullyStartedWorkshopFolderPublish), workshopItemTitle, retPublishFolderSpec));
			}
			return result;
		}

		public bool AbortPublishFolderToWorkshop()
		{
			return AbortPublishFolderToWorkshopInternal();
		}

		public bool GetPublishedMetaDataForGameItem(GameItemBase gameItemBase, ref WorkshopItemMetaData retWorkshopMetaData, ref string retPublishFolderSpec)
		{
			bool result = false;
			if (DetermineValidPublishFolderSpec(gameItemBase.InstalledFolderPathSpec, ref retPublishFolderSpec) && WorkshopItemMetaData.DoesMetaDataFileExist(retPublishFolderSpec))
			{
				retWorkshopMetaData = new WorkshopItemMetaData();
				if (retWorkshopMetaData.ReadFromMetaDataFile(retPublishFolderSpec))
				{
					result = true;
				}
			}
			return result;
		}

		public bool ReadWritWorkshopSourceParamsDatabse(bool bWrite, string workshopPublicFolderSpec, ref string workshopItemPreviewImageFileSpec)
		{
			bool result = false;
			Dictionary<string, string> retItemSourceParamsDictionary = null;
			if (_workshopSourceParamsDatabase.Get(workshopPublicFolderSpec, ref retItemSourceParamsDictionary))
			{
				result = true;
				if (bWrite)
				{
					if (ExtContentUtils.SetDictionaryValue(retItemSourceParamsDictionary, "SourcePreviewFileSpec", workshopItemPreviewImageFileSpec))
					{
						_workshopSourceParamsDatabase.UpdateToFile();
					}
				}
				else
				{
					ExtContentUtils.GetDictionaryValue(retItemSourceParamsDictionary, "SourcePreviewFileSpec", ref workshopItemPreviewImageFileSpec);
				}
			}
			return result;
		}

		public string GetGameItemPublishedLogInfoString(GameItemBase gameItemBase, string publishRootFolderSpec)
		{
			bool flag = false;
			string text = string.Empty;
			if (gameItemBase != null)
			{
				string retPublishFolderSpec = string.Empty;
				if (DetermineValidPublishFolderSpec(gameItemBase.InstalledFolderPathSpec, ref retPublishFolderSpec))
				{
					flag = true;
					if (WorkshopItemMetaData.DoesMetaDataFileExist(retPublishFolderSpec))
					{
						string text2 = ExtContentUtils.MakePathSpecRelativeTo(retPublishFolderSpec, publishRootFolderSpec);
						WorkshopItemMetaData workshopItemMetaData = new WorkshopItemMetaData();
						text = ((!workshopItemMetaData.ReadFromMetaDataFile(retPublishFolderSpec)) ? string.Format(ExtContentUtils.HiliteParams("Error reading meta file '{0}'"), ExtContentUtils.MakePathSpecRelativeTo(WorkshopItemMetaData.GetMetaDataFileSpec(retPublishFolderSpec), publishRootFolderSpec)) : string.Format(ExtContentUtils.HiliteParams("'{0}' ({1}) {2} from '{3}'"), workshopItemMetaData.Title, "v" + $"{workshopItemMetaData.VersionNumberOnDisk}", workshopItemMetaData.PublishedFileId, text2));
					}
					else
					{
						text = string.Format(ExtContentUtils.HiliteParams("{0}"), "Not published");
					}
				}
			}
			if (!flag)
			{
				text = string.Format(ExtContentUtils.HiliteParams("{0}"), "Error obtaining info");
			}
			return "Published: " + text;
		}

		public string GetWorkshopDefaultAssetsFolderSpec()
		{
			return ExtContentUtils.GetPathSpec(Application.streamingAssetsPath, "Workshop");
		}

		public string GetWorkshopDefaulPreviewImagesFolderSpec()
		{
			return ExtContentUtils.GetPathSpec(GetWorkshopDefaultAssetsFolderSpec(), "DefaultPreviewImages");
		}

		public bool DetermineValidPublishFolderSpec(string installedFolderPathSpec, ref string retPublishFolderSpec)
		{
			bool result = false;
			installedFolderPathSpec = ExtContentUtils.NormalisePathSpec(installedFolderPathSpec);
			retPublishFolderSpec = string.Empty;
			if (!installedFolderPathSpec.IsNullOrEmpty())
			{
				if (Directory.Exists(installedFolderPathSpec))
				{
					retPublishFolderSpec = installedFolderPathSpec;
					string pathSpec = ExtContentUtils.GetPathSpec(_contentRootFolderSpec, ExtContentType.ContentTypeToString(EContentType.Bundle));
					pathSpec = ExtContentUtils.NormalisePathSpec(pathSpec);
					if (retPublishFolderSpec.StartsWith(pathSpec))
					{
						string rootFolderNameFromPathSpec = ExtContentUtils.GetRootFolderNameFromPathSpec(retPublishFolderSpec.Substring(pathSpec.Length));
						if (!rootFolderNameFromPathSpec.IsNullOrEmpty())
						{
							retPublishFolderSpec = ExtContentUtils.GetPathSpec(pathSpec, rootFolderNameFromPathSpec);
							retPublishFolderSpec = ExtContentUtils.NormalisePathSpec(retPublishFolderSpec);
						}
					}
					result = true;
				}
				else
				{
					ExtContentMessages.LogError(string.Format(ExtContentMessages.GetMessageString(EMessageType.FolderDoesNotExistGeneral), installedFolderPathSpec));
				}
			}
			else
			{
				ExtContentMessages.LogError(string.Format(ExtContentMessages.GetMessageString(EMessageType.FolderNameInvalidGeneral), installedFolderPathSpec));
			}
			return result;
		}

		private EContentType DeterminePublishFolderContentType(string publishFolderSpec)
		{
			EContentType result = EContentType.Bundle;
			GameItemMetaData gameItemMetaData = GameItemUtils.LoadGameItemMetaData(publishFolderSpec);
			if (gameItemMetaData != null)
			{
				EContentType retContentType = EContentType.None;
				if (GameItemUtils.GetGameItemMetaDataContentType(gameItemMetaData, ref retContentType))
				{
					result = retContentType;
				}
			}
			return result;
		}

		private List<string> DeterminePublishFolderSearchTags(string publishFolderSpec, List<string> gameItemMetaDataFileFolderSpecs)
		{
			List<string> list = new List<string>();
			if (gameItemMetaDataFileFolderSpecs.Count > 1)
			{
				list.Add(ExtContentType.ContentTypeToString(EContentType.Bundle));
			}
			foreach (string gameItemMetaDataFileFolderSpec in gameItemMetaDataFileFolderSpecs)
			{
				EContentType retContentType = EContentType.None;
				_ = string.Empty;
				GameItemMetaData gameItemMetaData = GameItemUtils.LoadGameItemMetaData(gameItemMetaDataFileFolderSpec);
				if (gameItemMetaData != null && GameItemUtils.GetGameItemMetaDataContentType(gameItemMetaData, ref retContentType))
				{
					list.AddUnique(ExtContentType.ContentTypeToString(retContentType));
				}
			}
			ExtContentMessages.LogDebug(string.Format("Found {0} game items content types under publish folder '{0}'", ExtContentUtils.Hilite(list.Count), ExtContentUtils.Hilite(publishFolderSpec)));
			return list;
		}

		private IEnumerator ProcessValidWorkshopItemPreviewImageCoroutine(ProcessValidWorkshopItemPreviewImageCoroutineRetParams retParams, string imageFileSpec, string publishFolderSpec, EContentType contentType, uint lastgGneratedSourceImageFileHash)
		{
			retParams._validatedPreviewImageFileSpec = string.Empty;
			string retFileSpec = ExtContentUtils.NormalisePathSpec(imageFileSpec);
			bool bUseDefault = true;
			bool bGroomFileUsed = false;
			string groomedFileSpec = ExtContentUtils.GetPathSpec(publishFolderSpec, "WorkshopPreviewIcon.png");
			if (IsValidImageFileForPreviewForSelection(retFileSpec) && DoesPreviewImageFileExistForPublication(retFileSpec))
			{
				if (!IsPreviewImageFileSizeValidForPublication(retFileSpec))
				{
					bool flag = true;
					if (File.Exists(groomedFileSpec) && IsPreviewImageFileSizeValidForPublication(groomedFileSpec))
					{
						uint pathSpecHash = ExtContentUtils.GetPathSpecHash2(retFileSpec);
						if (lastgGneratedSourceImageFileHash == pathSpecHash)
						{
							DateTime lastWriteTime = File.GetLastWriteTime(retFileSpec);
							if (File.GetLastWriteTime(groomedFileSpec) > lastWriteTime)
							{
								flag = false;
								bGroomFileUsed = true;
							}
						}
					}
					if (flag)
					{
						bool bGroomedOK = false;
						Texture2D sourceTexture2D = ExtContentTextureUtils.LoadTexture2D(retFileSpec);
						if (sourceTexture2D != null)
						{
							FileInfo fileInfo = new FileInfo(retFileSpec);
							long originalFileSize = fileInfo.Length;
							bool flag2 = false;
							bool flag3 = false;
							int iterationCount = 0;
							float currScalingFactorIncr = 0.5f;
							float currScalingFactor = currScalingFactorIncr;
							bool flag4 = false;
							for (; iterationCount < _config.previewImageDownscalingMaxIterations; iterationCount++)
							{
								if (flag2)
								{
									break;
								}
								if (flag4)
								{
									break;
								}
								ProcessIsScaledEncoodedTextureSizeValidRetParams retParamsFileSize = new ProcessIsScaledEncoodedTextureSizeValidRetParams();
								yield return ProcessIsScaledEncoodedTextureSizeValid(retParamsFileSize, sourceTexture2D, currScalingFactor, iterationCount, groomedFileSpec, originalFileSize);
								flag3 = retParamsFileSize._bFileSizeValid;
								flag2 = retParamsFileSize._bErrorEncountered;
								flag4 = retParamsFileSize._bFileSizeWithinTolerance;
								if (!flag2 && !flag4)
								{
									currScalingFactorIncr *= 0.5f;
									currScalingFactor += (flag3 ? currScalingFactorIncr : (0f - currScalingFactorIncr));
								}
							}
							if (!flag2 && flag3)
							{
								ExtContentTextureUtils.ScaleTexture2DCoroutineRetParams retParamsScaleTexture = new ExtContentTextureUtils.ScaleTexture2DCoroutineRetParams();
								yield return ExtContentTextureUtils.ScaleTexture2DCoroutine(retParamsScaleTexture, sourceTexture2D, currScalingFactor);
								flag2 = !retParamsScaleTexture._bUpdatedOK;
								Texture2D updateTexture = retParamsScaleTexture._updateTexture;
								if (!flag2 && ExtContentTextureUtils.SaveTexture2D(updateTexture, groomedFileSpec))
								{
									bGroomedOK = true;
								}
							}
						}
						if (bGroomedOK)
						{
							bUseDefault = false;
							bGroomFileUsed = true;
							retFileSpec = groomedFileSpec;
						}
					}
					else
					{
						bUseDefault = false;
						retFileSpec = groomedFileSpec;
					}
				}
				else
				{
					bUseDefault = false;
				}
			}
			if (bUseDefault)
			{
				retFileSpec = GetDefaultPreviewImageFileSpec(contentType);
			}
			if (!bGroomFileUsed && File.Exists(groomedFileSpec))
			{
				ExtContentUtils.DeleteFile(groomedFileSpec);
			}
			retParams._validatedPreviewImageFileSpec = retFileSpec;
			yield return null;
		}

		private IEnumerator ProcessIsScaledEncoodedTextureSizeValid(ProcessIsScaledEncoodedTextureSizeValidRetParams retParams, Texture2D sourceTexture2D, float scalingFactor, int reportIteration, string reportTextureFileSpec, long reportOriginalFileSize)
		{
			retParams._bErrorEncountered = true;
			retParams._bFileSizeValid = false;
			retParams._bFileSizeWithinTolerance = false;
			ExtContentTextureUtils.ScaleTexture2DCoroutineRetParams retParamsScaleTexture = new ExtContentTextureUtils.ScaleTexture2DCoroutineRetParams();
			yield return ExtContentTextureUtils.ScaleTexture2DCoroutine(retParamsScaleTexture, sourceTexture2D, scalingFactor);
			retParams._bErrorEncountered = !retParamsScaleTexture._bUpdatedOK;
			Texture2D scaledTexture2D = retParamsScaleTexture._updateTexture;
			if (!retParams._bErrorEncountered)
			{
				yield return null;
				long num = ExtContentTextureUtils.GetTexture2DFileSize(scaledTexture2D);
				if (num > 0)
				{
					long num2 = _config.cMaximumPreviewImageFileSizeKB * 1024;
					long num3 = (_config.cMaximumPreviewImageFileSizeKB - _config.cMaximumPreviewImageFileSizeToleranceKB) * 1024;
					retParams._bFileSizeValid = num < num2;
					retParams._bFileSizeWithinTolerance = num >= num3 && num < num2;
					ExtContentMessages.LogDebug(string.Format("[#PREVIMG] Downscaling preview image file: iter:{0}, old (size(KB)/scale): {1}({2}%), new {3}({4}%), targetSz(KB):{5}, NewValid:{6}, WithinTolerance:{7}, File:'{8}'", reportIteration + 1, reportOriginalFileSize / 1024, 100, num / 1024, (int)(scalingFactor * 100f), _config.cMaximumPreviewImageFileSizeKB, retParams._bFileSizeValid ? "Y" : "N", retParams._bFileSizeWithinTolerance ? "Y" : "N", reportTextureFileSpec));
				}
			}
			yield return null;
		}

		public string GetValidWorkshopItemPreviewImageFileSpec(string imageFileSpec, EContentType contentType)
		{
			string text = ExtContentUtils.NormalisePathSpec(imageFileSpec);
			if (!IsValidImageFileForPreviewForSelection(text))
			{
				text = GetDefaultPreviewImageFileSpec(contentType);
			}
			return text;
		}

		public string GetDefaultPreviewImageFileSpec(EContentType contentType)
		{
			_ = string.Empty;
			string workshopDefaulPreviewImagesFolderSpec = GetWorkshopDefaulPreviewImagesFolderSpec();
			string fileName = "DefaultPreviewImage.png";
			if (ExtContentType.IsValid(contentType) && _config.workshopPreviewImageFileNames != null && _config.workshopPreviewImageFileNames.Length > (int)contentType && !_config.workshopPreviewImageFileNames[(int)contentType].IsNullOrEmpty())
			{
				fileName = _config.workshopPreviewImageFileNames[(int)contentType];
			}
			return ExtContentUtils.NormalisePathSpec(ExtContentUtils.GetPathSpec(workshopDefaulPreviewImagesFolderSpec, fileName));
		}

		private bool IsValidImageFileForPreviewForSelection(string imageFileSpec)
		{
			bool result = false;
			if (!imageFileSpec.IsNullOrEmpty() && File.Exists(imageFileSpec))
			{
				result = true;
			}
			return result;
		}

		private bool IsPreviewImageFileSpecValidForPublication(string imageFileSpec)
		{
			if (DoesPreviewImageFileExistForPublication(imageFileSpec))
			{
				return IsPreviewImageFileSizeValidForPublication(imageFileSpec);
			}
			return false;
		}

		private bool DoesPreviewImageFileExistForPublication(string imageFileSpec)
		{
			bool result = false;
			if (!imageFileSpec.IsNullOrEmpty() && File.Exists(imageFileSpec))
			{
				result = true;
			}
			return result;
		}

		private bool IsPreviewImageFileSizeValidForPublication(string imageFileSpec)
		{
			bool result = false;
			FileInfo fileInfo = new FileInfo(imageFileSpec);
			if (fileInfo.Length > 0 && fileInfo.Length < _config.cMaximumPreviewImageFileSizeKB * 1024)
			{
				result = true;
			}
			return result;
		}

		private void StopAllCoroutines()
		{
			if (_publishCoroutine != null)
			{
				_behaviourToRunCoroutinesOn.StopCoroutine(_publishCoroutine);
				_publishCoroutine = null;
			}
			if (_abortPublishDeleteItemCoroutine != null)
			{
				_behaviourToRunCoroutinesOn.StopCoroutine(_abortPublishDeleteItemCoroutine);
				_abortPublishDeleteItemCoroutine = null;
			}
		}

		private bool StartPublishCoroutine(string publishFolderSpec, string workshopItemTitle, string workshopItemDescription, string workshopItemPreviewImageFileSpec, EItemVisibility workshopItemVisibility, bool bForceCreateNewWorkshopItem)
		{
			bool result = false;
			if (_publishCoroutine == null)
			{
				_publishCoroutine = _behaviourToRunCoroutinesOn.StartCoroutine(PublishCoroutine(publishFolderSpec, workshopItemTitle, workshopItemDescription, workshopItemPreviewImageFileSpec, workshopItemVisibility, bForceCreateNewWorkshopItem));
				result = true;
			}
			else
			{
				ExtContentMessages.LogError(string.Format(ExtContentMessages.GetMessageString(EMessageType.WorkshopPublishOperationAlreadyInProgress)));
			}
			return result;
		}

		private IEnumerator PublishCoroutine(string publishFolderSpec, string workshopItemTitle, string workshopItemDescription, string workshopItemSourcePreviewImageFileSpec, EItemVisibility workshopItemVisibility, bool bForceCreateNewWorkshopItem)
		{
			bool bPublishSuccessful = false;
			bool bErrorEncountered = false;
			bool bUserNeedsToAcceptWorkshopLegalAgreement = false;
			bool bInvokePublishedItemSteamOverlay = false;
			_currentlyPublishingPublishedFileIdStr = string.Empty;
			_currentlyPublishingCreateNewReqd = false;
			_currentlyPublishingWorkshopItemMetaData = null;
			_currentlyPublishingPublishFolderSpec = publishFolderSpec;
			WorkshopUtils.ResetLastSteamResult();
			if (this.OnPublishStarted != null)
			{
				this.OnPublishStarted(publishFolderSpec);
			}
			ReadWritWorkshopSourceParamsDatabse(bWrite: true, publishFolderSpec, ref workshopItemSourcePreviewImageFileSpec);
			yield return 0.1f;
			bool flag = WorkshopItemMetaData.DoesMetaDataFileExist(publishFolderSpec);
			_currentlyPublishingWorkshopItemMetaData = new WorkshopItemMetaData();
			if (!bForceCreateNewWorkshopItem && flag && !_currentlyPublishingWorkshopItemMetaData.ReadFromMetaDataFile(publishFolderSpec))
			{
				bErrorEncountered = true;
			}
			if (!bErrorEncountered && !ValidateGameItemsInFolderReadyForPublish(publishFolderSpec))
			{
				bErrorEncountered = true;
			}
			_currentlyPublishingCreateNewReqd = false;
			if (!bErrorEncountered)
			{
				_currentlyPublishingCreateNewReqd = bForceCreateNewWorkshopItem || !flag;
				if (!_currentlyPublishingCreateNewReqd)
				{
					yield return QueryPublishedFileIdValidCoroutine(WorkshopUtils.PublishedFileIdFromString(_currentlyPublishingWorkshopItemMetaData.PublishedFileId));
					if (!_lastQueriedPublishedFileIdValid)
					{
						_currentlyPublishingCreateNewReqd = true;
						ExtContentMessages.LogDebug(string.Format(ExtContentUtils.HiliteParams("Existing published file id '{0}' not found. Flagging to create new"), _currentlyPublishingWorkshopItemMetaData.PublishedFileId));
					}
				}
				if (_currentlyPublishingCreateNewReqd)
				{
					bErrorEncountered = !WorkshopUtils.ValidateItemCreationParams(workshopItemTitle, workshopItemDescription, publishFolderSpec);
					if (!bErrorEncountered)
					{
						WaitForCallResult<CreateItemResult_t> createResult = WorkshopUtils.StartItemCreate();
						yield return createResult.WaitForResult();
						bErrorEncountered = !WorkshopUtils.ValidateItemCreateResult(createResult.Result, workshopItemTitle);
						if (!bErrorEncountered)
						{
							PublishedFileId_t nPublishedFileId = createResult.Result.m_nPublishedFileId;
							_currentlyPublishingPublishedFileIdStr = nPublishedFileId.ToString();
							ExtContentMessages.LogDebug(string.Format(ExtContentMessages.GetMessageString(EMessageType.SuccessfullyCreatedWorkshopItem), workshopItemTitle, nPublishedFileId.ToString()));
							_currentlyPublishingWorkshopItemMetaData.VersionNumberOnDisk = 0;
							_currentlyPublishingWorkshopItemMetaData.PublishedFileId = nPublishedFileId.ToString();
							_currentlyPublishingWorkshopItemMetaData.ContentType = DeterminePublishFolderContentType(publishFolderSpec);
						}
					}
				}
				if (!bErrorEncountered)
				{
					_currentlyPublishingWorkshopItemMetaData.VersionNumberOnDisk++;
					string workshopItemTypeName = ExtContentType.ContentTypeToString(_currentlyPublishingWorkshopItemMetaData.ContentType);
					ProcessValidWorkshopItemPreviewImageCoroutineRetParams retParams = new ProcessValidWorkshopItemPreviewImageCoroutineRetParams();
					yield return ProcessValidWorkshopItemPreviewImageCoroutine(retParams, workshopItemSourcePreviewImageFileSpec, publishFolderSpec, _currentlyPublishingWorkshopItemMetaData.ContentType, _currentlyPublishingWorkshopItemMetaData.SourcePreviewFileSpecHash);
					string validatedPreviewImageFileSpec = retParams._validatedPreviewImageFileSpec;
					if (WorkshopUtils.ValidateItemUpdateParams(workshopItemTitle, workshopItemTypeName, workshopItemDescription, _currentlyPublishingWorkshopItemMetaData.VersionNumberOnDisk, validatedPreviewImageFileSpec, publishFolderSpec))
					{
						bErrorEncountered = true;
						List<string> targetGameItemMetaDataFileSpecs = new List<string>();
						if (GameItemUtils.ScanFoldersForGameItemMetaDataFileFolderSpecs(publishFolderSpec, ref targetGameItemMetaDataFileSpecs) && targetGameItemMetaDataFileSpecs.Count > 0)
						{
							bErrorEncountered = false;
						}
						if (!bErrorEncountered)
						{
							_currentlyPublishingWorkshopItemMetaData.Title = workshopItemTitle;
							_currentlyPublishingWorkshopItemMetaData.Description = workshopItemDescription;
							_currentlyPublishingWorkshopItemMetaData.PreviewFileName = Path.GetFileName(validatedPreviewImageFileSpec);
							_currentlyPublishingWorkshopItemMetaData.SourcePreviewFileSpecHash = ExtContentUtils.GetPathSpecHash2(workshopItemSourcePreviewImageFileSpec);
							_currentlyPublishingWorkshopItemMetaData.Visibility = workshopItemVisibility;
							_currentlyPublishingWorkshopItemMetaData.GameItemUpdateTime = ExtContentUtils.GetCurrentTimeStamp();
							EContentType retContentType = EContentType.None;
							string retContentSubType = string.Empty;
							bErrorEncountered = true;
							GameItemMetaData gameItemMetaData = GameItemUtils.LoadGameItemMetaData(targetGameItemMetaDataFileSpecs[0]);
							if (gameItemMetaData != null && GameItemUtils.GetGameItemMetaDataContentTypes(gameItemMetaData, ref retContentType, ref retContentSubType))
							{
								bErrorEncountered = false;
							}
							if (!bErrorEncountered)
							{
								_currentlyPublishingWorkshopItemMetaData.FirstItemContentType = retContentType;
								_currentlyPublishingWorkshopItemMetaData.FirstItemContentSubType = retContentSubType;
								_currentlyPublishingWorkshopItemMetaData.NumGameItems = targetGameItemMetaDataFileSpecs.Count;
								bErrorEncountered = !_currentlyPublishingWorkshopItemMetaData.WriteToMetaDataFile(publishFolderSpec);
							}
						}
						if (!bErrorEncountered)
						{
							if (this.OnPublishPreUpload != null)
							{
								this.OnPublishPreUpload(bSuccess: true, _currentlyPublishingCreateNewReqd, _currentlyPublishingWorkshopItemMetaData, publishFolderSpec);
							}
							PublishedFileId_t publishedFileId = WorkshopUtils.PublishedFileIdFromString(_currentlyPublishingWorkshopItemMetaData.PublishedFileId);
							List<string> workshopItemSearchTags = DeterminePublishFolderSearchTags(publishFolderSpec, targetGameItemMetaDataFileSpecs);
							UGCUpdateHandle_t hUGCUpdate;
							WaitForCallResult<SubmitItemUpdateResult_t> updateResult = WorkshopUtils.StartItemUpdate(out hUGCUpdate, publishedFileId, workshopItemTitle, workshopItemTypeName, workshopItemDescription, validatedPreviewImageFileSpec, workshopItemVisibility, _currentlyPublishingWorkshopItemMetaData.VersionNumberOnDisk, workshopItemSearchTags, publishFolderSpec, _currentlyPublishingCreateNewReqd);
							int bytesProcessed = 0;
							int bytesTotal = 0;
							float logTimer = 0f;
							float logTimerDuration = 0.5f;
							while (!WorkshopUtils.LogItemUploadStatus(hUGCUpdate, ref logTimer, logTimerDuration, ref bytesProcessed, ref bytesTotal))
							{
								yield return null;
							}
							yield return updateResult.WaitForResult();
							bErrorEncountered = !WorkshopUtils.ValidateItemUpdateResult(updateResult.Result, workshopItemTitle, workshopItemTypeName, publishFolderSpec, publishedFileId.ToString());
							if (bErrorEncountered && _currentlyPublishingCreateNewReqd)
							{
								yield return DeletePublishedItemCoroutine(publishedFileId);
							}
							if (this.OnPublishPostUpload != null)
							{
								this.OnPublishPostUpload(!bErrorEncountered, _currentlyPublishingCreateNewReqd, _currentlyPublishingWorkshopItemMetaData, publishFolderSpec);
							}
							if (!bErrorEncountered)
							{
								bPublishSuccessful = true;
								bInvokePublishedItemSteamOverlay = true;
								ExtContentMessages.LogMessage(string.Format(ExtContentMessages.GetMessageString(EMessageType.SuccessfullyPublishedWorkshopItem), _currentlyPublishingCreateNewReqd ? "new" : "existing", workshopItemTitle, "v" + $"{_currentlyPublishingWorkshopItemMetaData.VersionNumberOnDisk}", publishedFileId.ToString(), workshopItemTypeName, publishFolderSpec, $"{bytesTotal / 1024}KB"));
								if (updateResult.Result.m_bUserNeedsToAcceptWorkshopLegalAgreement)
								{
									bUserNeedsToAcceptWorkshopLegalAgreement = true;
								}
							}
						}
					}
				}
			}
			WorkshopUtils.OnFinishedItemCreate();
			WorkshopUtils.OnFinishedItemUpdate();
			_publishCoroutine = null;
			if (this.OnPublishComplete != null)
			{
				this.OnPublishComplete(bPublishSuccessful, bAborted: false, _currentlyPublishingCreateNewReqd, _currentlyPublishingWorkshopItemMetaData, publishFolderSpec);
			}
			ExtContentMessages.LogDebug(string.Format(ExtContentUtils.HiliteParams("Finished publishing. Steam Overlay: Agreement: {0}/{1}. Published: {2}/{3}"), bUserNeedsToAcceptWorkshopLegalAgreement ? "Y" : "N", _config.bInvokeSteamOverlayAgreementPage ? "Y" : "N", bInvokePublishedItemSteamOverlay ? "Y" : "N", _config.bInvokeSteamOverlayOnPublish ? "Y" : "N"));
			if (bUserNeedsToAcceptWorkshopLegalAgreement && _config.bInvokeSteamOverlayAgreementPage)
			{
				SetOpenSteamOverlayPending(_config.steamOverlayWorkshopAgreementURL, _config.steamOverlayWorkshopAgreementURLBrowser);
			}
			else if (bInvokePublishedItemSteamOverlay && _config.bInvokeSteamOverlayOnPublish)
			{
				SetOpenSteamOverlayPending(_config.steamOverlayWorkshopPublishBaseURL + _currentlyPublishingWorkshopItemMetaData.PublishedFileId.ToString(), _config.steamOverlayWorkshopPublishBaseURLBrowser + _currentlyPublishingWorkshopItemMetaData.PublishedFileId.ToString());
			}
			_currentlyPublishingWorkshopItemMetaData = null;
		}

		private bool AbortPublishFolderToWorkshopInternal()
		{
			bool result = false;
			if (_publishCoroutine != null && !_bCurrentlyDeletingPublishedItem)
			{
				StopAllCoroutines();
				if (_currentlyPublishingCreateNewReqd && !_currentlyPublishingPublishedFileIdStr.IsNullOrEmpty())
				{
					_abortPublishDeleteItemCoroutine = _behaviourToRunCoroutinesOn.StartCoroutine(DeletePublishedItemCoroutine(WorkshopUtils.PublishedFileIdFromString(_currentlyPublishingPublishedFileIdStr)));
				}
				result = true;
			}
			this.OnPublishComplete(bSuccess: false, bAborted: true, _currentlyPublishingCreateNewReqd, _currentlyPublishingWorkshopItemMetaData, _currentlyPublishingPublishFolderSpec);
			return result;
		}

		private IEnumerator DeletePublishedItemCoroutine(PublishedFileId_t publishedFileId)
		{
			_bCurrentlyDeletingPublishedItem = true;
			WorkshopUtils.ResetLastSteamResult();
			SteamAPICall_t callback = SteamUGC.DeleteItem(publishedFileId);
			WaitForCallResult<DeleteItemResult_t> callResultDeleteItem = new WaitForCallResult<DeleteItemResult_t>(callback);
			yield return callResultDeleteItem.WaitForResult();
			WorkshopUtils.SetLastSteamResult(callResultDeleteItem.Result.m_eResult);
			if (callResultDeleteItem.Result.m_eResult == EResult.k_EResultOK)
			{
				ExtContentMessages.LogMessage(string.Format(ExtContentMessages.GetMessageString(EMessageType.SuccessfullyDeletedWorkshopItem), publishedFileId.ToString()));
			}
			else
			{
				ExtContentMessages.LogError(string.Format(ExtContentMessages.GetMessageString(EMessageType.ErrorDeletingWorkshopItem), publishedFileId.ToString()));
			}
			_bCurrentlyDeletingPublishedItem = false;
			_abortPublishDeleteItemCoroutine = null;
		}

		private IEnumerator QueryPublishedFileIdValidCoroutine(PublishedFileId_t publishedFileId)
		{
			_lastQueriedPublishedFileIdValid = false;
			WaitForCallResult<SteamUGCQueryCompleted_t> queryResult = WorkshopUtils.StartPublishedItemsQuery(1u, new PublishedFileId_t[1] { publishedFileId });
			yield return queryResult.WaitForResult();
			if (WorkshopUtils.ValidateItemsQueryResult(queryResult.Result, 1u) && SteamUGC.GetQueryUGCResult(queryResult.Result.m_handle, 0u, out var pDetails) && pDetails.m_eResult == EResult.k_EResultOK)
			{
				_lastQueriedPublishedFileIdValid = true;
			}
		}

		public bool ValidateGameItemsInFolderReadyForPublish(string publishFolderSpec)
		{
			bool result = true;
			List<GameItemBase> targetGameItemsList = new List<GameItemBase>();
			GameItemUtils.ScanFoldersForGameItems(EContentSourceType.LocalMods, publishFolderSpec, ref targetGameItemsList);
			foreach (GameItemBase item in targetGameItemsList)
			{
				if (!item.ValidateReadyForPublish())
				{
					result = false;
					ExtContentMessages.LogError(string.Format(ExtContentMessages.GetMessageString(EMessageType.GameItemFailedPrePublishValidation), item.Title, item.InstalledFolderPathSpec));
				}
				else
				{
					ExtContentMessages.LogDebug(string.Format(ExtContentMessages.GetMessageString(EMessageType.GameItemPassedPrePublishValidation), item.Title, item.InstalledFolderPathSpec));
				}
			}
			return result;
		}

		public void Update()
		{
			ProcessOpenSteamOverlayPending();
		}

		private void SetOpenSteamOverlayPending(string urlStringSteam, string urlStringBrowser)
		{
			_openSteamOverlayPending = true;
			_openSteamOverlayPendingURLSteam = urlStringSteam;
			_openSteamOverlayPendingURLBrowser = urlStringBrowser;
		}

		private void ProcessOpenSteamOverlayPending()
		{
			if (_openSteamOverlayPending)
			{
				_openSteamOverlayPending = false;
				WorkshopUtils.OpenSteamOverlay(_openSteamOverlayPendingURLSteam, _openSteamOverlayPendingURLBrowser);
			}
		}
	}
}
