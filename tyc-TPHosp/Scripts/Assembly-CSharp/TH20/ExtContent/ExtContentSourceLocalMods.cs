#define LOG_LEVEL_VERBOSE
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Steamworks;
using TH20.Analytics;
using UnityEngine;

namespace TH20.ExtContent
{
	public class ExtContentSourceLocalMods : ExtContentSourceBase
	{
		public class LocalModsConfig
		{
			public bool bTest;
		}

		public delegate void OnGameItemPreProcessCallback(EContentType contenetType, GameItemBase gameItemBase);

		public const string cLocalModsFolderName = "LocalMods";

		public const string cLocalModsIconFilePrefix = "Icon-";

		public const int cMaxNumDuplicateFolders = 999;

		public const string cLocalModSourceMetaDataFileName = "LocalModSourceMetaData.json";

		public const string cLocalModsSourceParamsDatabaseFileName = "LocalModsSourceParamsDB.json";

		public const string cKey_SourceAssetBundleFileSpec = "SourceAssetBundleFileSpec";

		public const string cKey_SourceIconVariationIndex = "SourceIconVariationIndex";

		public const string cKey_SourceMainImageFileModTime = "SourceMainImageFileModTime";

		public const string cKey_SourceIconImageFileModTime = "SourceIconImageFileModTime";

		public const string cKey_SourceNumMusicPackFiles = "SourceNumMusicPackFiles";

		public const string cKey_SourceMusicPackFileSpec = "SourceMusicPackFileSpec";

		public const string cKey_SourceMusicPackArtistName = "SourceMusicPackArtistName";

		public const string cKey_SourceMusicPackTrackName = "SourceMusicPackTrackName";

		public const string cKey_SourceMusicPackArtistNameOriginal = "SourceMusicPackArtistNameOriginal";

		public const string cKey_SourceMusicPackTrackNameOriginal = "SourceMusicPackTrackNameOriginal";

		private LocalModsConfig _config;

		private ExtContentManager _extContentManager;

		private WorkshopContentCreationManager _workshopContentCreationManager;

		private LocalSourceParamsDatabase _localModsSourceParamsDatabase;

		private MonoBehaviour _behaviourToRunCoroutinesOn;

		private Coroutine _queryItemsCoroutine;

		private List<GameItemBase> _localModGameItems;

		private List<GameItemBase> _republishGameItems;

		private int _currentRepublishIndex;

		private WorkshopContentCreationManager.OnPublishCompleteCallback _onPublishCompleteUser;

		private bool _publishedItemDetailsUpdatePending;

		private bool _publishedItemDetailsUpdateInProgress;

		private List<WorkshopItemMetaData> _publishedItemDetailsUpdateMetaData;

		private List<string> _publishedItemDetailsUpdateMetaDataFileSpecs;

		private PublishedFileId_t[] _publishedItemDetailsUpdateIds;

		public LocalModsConfig Config => _config;

		public List<GameItemBase> GameItems => _localModGameItems;

		public event OnGameItemPreProcessCallback OnGameItemPreProcess;

		public ExtContentSourceLocalMods(LocalModsConfig config)
		{
			_config = config;
		}

		public void Init(ExtContentManager extContentManager)
		{
			_extContentManager = extContentManager;
			_workshopContentCreationManager = _extContentManager.WorkshopContentCreationManager;
			_behaviourToRunCoroutinesOn = _extContentManager.BehaviourToRunCoroutinesOn;
			_localModsSourceParamsDatabase = new LocalSourceParamsDatabase();
			_localModsSourceParamsDatabase.Init(GetLocalModsFolderSpec(), "LocalModsSourceParamsDB.json");
			EnsureLocalModsContentTypeFoldersExist(EContentType.Bundle);
			InitGameItems();
			_localModsSourceParamsDatabase.ValidateItems();
			SetCheckPublishedItemDetailsUpdatePending();
			_workshopContentCreationManager.OnPublishComplete += OnPublishComplete;
			_workshopContentCreationManager.OnPublishPreUpload += OnPublishPreUpload;
			_workshopContentCreationManager.OnPublishPostUpload += OnPublishPostUpload;
			base.OnGameItemCreated += OnGameItemCreatedFn;
		}

		public void DeInit()
		{
			_workshopContentCreationManager.OnPublishComplete -= OnPublishComplete;
			_workshopContentCreationManager.OnPublishPreUpload -= OnPublishPreUpload;
			_workshopContentCreationManager.OnPublishPostUpload -= OnPublishPostUpload;
			base.OnGameItemCreated -= OnGameItemCreatedFn;
			_localModsSourceParamsDatabase?.DeInit();
			_localModsSourceParamsDatabase = null;
			StopCoroutines();
			DeInitGameItems();
		}

		public override List<GameItemBase> GetAllGameItems(EContentType contentType = EContentType.None)
		{
			List<GameItemBase> list = new List<GameItemBase>();
			if (ExtContentType.IsValid(contentType))
			{
				foreach (GameItemBase localModGameItem in _localModGameItems)
				{
					if (localModGameItem.ContentType == contentType)
					{
						list.Add(localModGameItem);
					}
				}
			}
			else
			{
				list.AddRange(_localModGameItems);
			}
			return list;
		}

		public override List<GameItemBase> GetAllGameItemsRef()
		{
			return _localModGameItems;
		}

		public string GetLocalModsFolderSpec()
		{
			return ExtContentUtils.NormalisePathSpec(ExtContentUtils.GetPathSpec(Application.persistentDataPath, "LocalMods"));
		}

		public string GetLocalModsContentTypeFolderSpec(EContentType contentType)
		{
			return ExtContentUtils.GetPathSpec(GetLocalModsFolderSpec(), ExtContentType.ContentTypeToString(contentType));
		}

		public string GetLocalModsItemFolderSpec(string localModsReletiveFolder)
		{
			return ExtContentUtils.GetPathSpec(GetLocalModsFolderSpec(), localModsReletiveFolder);
		}

		public override string GetContentSourceIdentifier()
		{
			return "LocalMods";
		}

		public override string GetCommonPathSearchFolder()
		{
			return "LocalMods";
		}

		public string SanitizeTitle(string title)
		{
			return title.Trim();
		}

		public override bool IsCurrentlyUsingOnlineServices()
		{
			if (!base.IsCurrentlyUsingOnlineServices() && !_publishedItemDetailsUpdateInProgress)
			{
				return _queryItemsCoroutine != null;
			}
			return true;
		}

		private void StopCoroutines()
		{
			StopQueryItemsCoroutine();
		}

		private void StopQueryItemsCoroutine()
		{
			if (_queryItemsCoroutine != null)
			{
				_behaviourToRunCoroutinesOn.StopCoroutine(_queryItemsCoroutine);
				_queryItemsCoroutine = null;
			}
		}

		public void InvokeOnGameItemPreProcess(EContentType contentType, GameItemBase gameItemBase)
		{
			if (this.OnGameItemPreProcess != null)
			{
				this.OnGameItemPreProcess(contentType, gameItemBase);
			}
		}

		public GameItemPictureBase CreateItemPictureBase(EContentType contentType, string title, string description, string subTypeID, ExtContentImageSpec mainImageSpec, ExtContentImageSpec iconImageSpec, int iconVariationIndex, int price, int kudosh)
		{
			GameItemPictureBase gameItemPictureBase = null;
			ProcessItemPictureBase(contentType, ref gameItemPictureBase, bCreateNewItem: true, title, description, subTypeID, mainImageSpec, iconImageSpec, iconVariationIndex, price, kudosh);
			return gameItemPictureBase;
		}

		public bool UpdateItemPictureBase(EContentType contentType, GameItemPictureBase gameItemPictureBase, string title, string description, string subTypeID, ExtContentImageSpec mainImageSpec, ExtContentImageSpec iconImageSpec, int iconVariationIndex, int price, int kudosh)
		{
			bool result = false;
			if (gameItemPictureBase != null)
			{
				result = ProcessItemPictureBase(contentType, ref gameItemPictureBase, bCreateNewItem: false, title, description, subTypeID, mainImageSpec, iconImageSpec, iconVariationIndex, price, kudosh);
			}
			else
			{
				ExtContentMessages.LogError(string.Format(ExtContentMessages.GetMessageString(EMessageType.InvalidGameItemForUpdatingLocalMod), title));
			}
			return result;
		}

		private bool ProcessItemPictureBase(EContentType contentType, ref GameItemPictureBase gameItemPictureBase, bool bCreateNewItem, string title, string description, string subTypeID, ExtContentImageSpec sourceMainImageSpec, ExtContentImageSpec sourceIconImageSpec, int iconVariationIndex, int price, int kudosh)
		{
			bool flag = false;
			InvokeOnGameItemPreProcess(contentType, gameItemPictureBase);
			title = SanitizeTitle(title);
			if (ValidateTitle(title, bCreateNewItem) && ValidateTextureFile(sourceMainImageSpec.FolderSpec, sourceMainImageSpec.FileName))
			{
				bool flag2 = !sourceIconImageSpec.FolderSpec.IsNullOrEmpty();
				if (ValidateOptionalSourceFileSpec(sourceIconImageSpec.FolderSpec, sourceIconImageSpec.FileName))
				{
					string reItemtLocalModsFolderSpec = string.Empty;
					if (bCreateNewItem)
					{
						GenerateAndCreateItemLocalModsFolder(contentType, title, ref reItemtLocalModsFolderSpec);
					}
					else if (gameItemPictureBase != null)
					{
						reItemtLocalModsFolderSpec = gameItemPictureBase.InstalledFolderPathSpec;
					}
					if (ValidateItemLocalModsFolderSpec(reItemtLocalModsFolderSpec))
					{
						ExtContentImageSpec extContentImageSpec = new ExtContentImageSpec(reItemtLocalModsFolderSpec, sourceMainImageSpec.FileName);
						ExtContentImageSpec extContentImageSpec2 = new ExtContentImageSpec(reItemtLocalModsFolderSpec, sourceIconImageSpec.FileName);
						extContentImageSpec.FileName = ExtContentTextureUtils.GetValidTargetTextureFileExtension(extContentImageSpec.FileName);
						bool flag3 = false;
						flag3 = !CreateLocalModMainTextureStagedCopy(sourceMainImageSpec, extContentImageSpec, contentType, subTypeID);
						if (!flag3)
						{
							ExtContentImageSpec extContentImageSpec3 = sourceIconImageSpec;
							if (!flag2)
							{
								extContentImageSpec3 = sourceMainImageSpec;
							}
							extContentImageSpec2.FileName = "Icon-" + extContentImageSpec3.FileName;
							extContentImageSpec2.FileName = ExtContentTextureUtils.GetValidTargetTextureFileExtension(extContentImageSpec2.FileName);
							flag3 = !CreateLocalModIconTextureStagedCopy(flag2, extContentImageSpec3, extContentImageSpec2, contentType, subTypeID, iconVariationIndex);
						}
						if (!flag3)
						{
							List<string> list = new List<string>();
							list.Add(extContentImageSpec.FileName);
							list.Add(extContentImageSpec2.FileName);
							List<string> list2 = new List<string>();
							list2.Add("json");
							ExtContentUtils.DeleteInvalidFiles(reItemtLocalModsFolderSpec, list, list2);
						}
						if (!flag3)
						{
							if (bCreateNewItem)
							{
								string gameItemInstalledFolderGUID = GameItemUtils.GetGameItemInstalledFolderGUID(EContentSourceType.LocalMods, reItemtLocalModsFolderSpec);
								switch (contentType)
								{
								case EContentType.Rug:
									gameItemPictureBase = (GameItemPictureBase)GameItemFactory.CreateRawGameItemRug(EContentSourceType.LocalMods, title, description, gameItemInstalledFolderGUID, reItemtLocalModsFolderSpec);
									break;
								case EContentType.Picture:
									gameItemPictureBase = (GameItemPictureBase)GameItemFactory.CreateRawGameItemPicture(EContentSourceType.LocalMods, title, description, gameItemInstalledFolderGUID, reItemtLocalModsFolderSpec);
									break;
								case EContentType.Floor:
									gameItemPictureBase = (GameItemPictureBase)GameItemFactory.CreateRawGameItemFloor(EContentSourceType.LocalMods, title, description, gameItemInstalledFolderGUID, reItemtLocalModsFolderSpec);
									break;
								case EContentType.Wall:
									gameItemPictureBase = (GameItemPictureBase)GameItemFactory.CreateRawGameItemWall(EContentSourceType.LocalMods, title, description, gameItemInstalledFolderGUID, reItemtLocalModsFolderSpec);
									break;
								}
								if (gameItemPictureBase != null)
								{
									AddLocalModGameItem(gameItemPictureBase);
								}
							}
							if (gameItemPictureBase != null)
							{
								gameItemPictureBase.Title = title;
								gameItemPictureBase.Description = description;
								gameItemPictureBase.SetData(subTypeID, extContentImageSpec.FileName, extContentImageSpec2.FileName, price, kudosh);
								if (gameItemPictureBase.UpdateMetaDataFile())
								{
									DateTime mainImageFileLastWriteTime = ExtContentUtils.cRefDateTime;
									DateTime iconImageFileLastWriteTime = ExtContentUtils.cRefDateTime;
									if (!sourceMainImageSpec.FileSpec.IsNullOrEmpty())
									{
										mainImageFileLastWriteTime = File.GetLastWriteTime(sourceMainImageSpec.FileSpec);
									}
									if (!sourceIconImageSpec.FileSpec.IsNullOrEmpty())
									{
										iconImageFileLastWriteTime = File.GetLastWriteTime(sourceIconImageSpec.FileSpec);
									}
									ReadWriteLocalModSourceMetaDataPictureBase(bWrite: true, reItemtLocalModsFolderSpec, ref sourceMainImageSpec, ref sourceIconImageSpec, ref mainImageFileLastWriteTime, ref iconImageFileLastWriteTime, ref iconVariationIndex);
									if (bCreateNewItem)
									{
										InvokeOnGameItemCreated(gameItemPictureBase);
									}
									else
									{
										InvokeOnGameItemUpdated(gameItemPictureBase);
									}
									flag = true;
									ExtContentMessages.LogMessage(string.Format(ExtContentMessages.GetMessageString(EMessageType.SuccessfullyCreatedLocalModItem, bHiliteParams: false), gameItemPictureBase.GetLogInfoStringInstalledPath()));
								}
							}
						}
					}
				}
			}
			if (!flag)
			{
				gameItemPictureBase = null;
			}
			return flag;
		}

		public bool ReadWriteLocalModSourceMetaDataPictureBase(bool bWrite, string itemLocalModsFolderSpec, ref ExtContentImageSpec sourceMainImageSpec, ref ExtContentImageSpec sourceIconImageSpec, ref DateTime mainImageFileLastWriteTime, ref DateTime iconImageFileLastWriteTime, ref int iconVariationIndex)
		{
			bool result = false;
			Dictionary<string, string> retItemSourceParamsDictionary = null;
			if (_localModsSourceParamsDatabase.Get(itemLocalModsFolderSpec, ref retItemSourceParamsDictionary))
			{
				result = true;
				if (sourceMainImageSpec == null)
				{
					sourceMainImageSpec = new ExtContentImageSpec();
				}
				if (sourceIconImageSpec == null)
				{
					sourceIconImageSpec = new ExtContentImageSpec();
				}
				bool flag = false;
				if (sourceMainImageSpec.ReadWriteMetaData(bWrite, "Main", retItemSourceParamsDictionary))
				{
					flag = true;
				}
				if (sourceIconImageSpec.ReadWriteMetaData(bWrite, "Icon", retItemSourceParamsDictionary))
				{
					flag = true;
				}
				string value = (bWrite ? ExtContentUtils.FileModTimeToString(mainImageFileLastWriteTime) : string.Empty);
				if (ExtContentUtils.ReadWriteDictionaryValue(bWrite, retItemSourceParamsDictionary, "SourceMainImageFileModTime", ref value))
				{
					flag = true;
				}
				string value2 = (bWrite ? ExtContentUtils.FileModTimeToString(iconImageFileLastWriteTime) : string.Empty);
				if (ExtContentUtils.ReadWriteDictionaryValue(bWrite, retItemSourceParamsDictionary, "SourceIconImageFileModTime", ref value2))
				{
					flag = true;
				}
				if (!bWrite)
				{
					mainImageFileLastWriteTime = ExtContentUtils.FileModTimeFromString(value);
					iconImageFileLastWriteTime = ExtContentUtils.FileModTimeFromString(value2);
				}
				if (ExtContentUtils.ReadWriteDictionaryValue(bWrite, retItemSourceParamsDictionary, "SourceIconVariationIndex", ref iconVariationIndex))
				{
					flag = true;
				}
				if (bWrite && flag)
				{
					_localModsSourceParamsDatabase.UpdateToFile();
				}
			}
			return result;
		}

		public bool ReadWriteLocalModSourceMetaDataMusicPack(bool bWrite, string itemLocalModsFolderSpec, ref List<MusicPackSourceItem> musicPackSourceItems)
		{
			bool result = false;
			Dictionary<string, string> retItemSourceParamsDictionary = null;
			if (_localModsSourceParamsDatabase.Get(itemLocalModsFolderSpec, ref retItemSourceParamsDictionary))
			{
				result = true;
				if (bWrite)
				{
					bool flag = false;
					int count = musicPackSourceItems.Count;
					if (ExtContentUtils.SetDictionaryValue(retItemSourceParamsDictionary, "SourceNumMusicPackFiles", count.ToString()))
					{
						flag = true;
					}
					for (int i = 0; i < count; i++)
					{
						if (WriteLocalModSourceMetaDataMusicPackItemValue(retItemSourceParamsDictionary, "SourceMusicPackFileSpec", i, musicPackSourceItems[i].FileSpec))
						{
							flag = true;
						}
						if (WriteLocalModSourceMetaDataMusicPackItemValue(retItemSourceParamsDictionary, "SourceMusicPackArtistName", i, musicPackSourceItems[i].ArtistName))
						{
							flag = true;
						}
						if (WriteLocalModSourceMetaDataMusicPackItemValue(retItemSourceParamsDictionary, "SourceMusicPackTrackName", i, musicPackSourceItems[i].TrackName))
						{
							flag = true;
						}
						if (WriteLocalModSourceMetaDataMusicPackItemValue(retItemSourceParamsDictionary, "SourceMusicPackArtistNameOriginal", i, musicPackSourceItems[i].ArtistNameOriginal))
						{
							flag = true;
						}
						if (WriteLocalModSourceMetaDataMusicPackItemValue(retItemSourceParamsDictionary, "SourceMusicPackTrackNameOriginal", i, musicPackSourceItems[i].TrackNameOriginal))
						{
							flag = true;
						}
					}
					if (flag)
					{
						_localModsSourceParamsDatabase.UpdateToFile();
					}
				}
				else
				{
					if (musicPackSourceItems == null)
					{
						musicPackSourceItems = new List<MusicPackSourceItem>();
					}
					else
					{
						musicPackSourceItems.Clear();
					}
					int retValue = 0;
					ExtContentUtils.GetDictionaryValue(retItemSourceParamsDictionary, "SourceNumMusicPackFiles", ref retValue);
					for (int j = 0; j < retValue; j++)
					{
						string retValue2 = string.Empty;
						string retValue3 = string.Empty;
						string retValue4 = string.Empty;
						string retValue5 = string.Empty;
						string retValue6 = string.Empty;
						ReadLocalModSourceMetaDataMusicPackItemValue(retItemSourceParamsDictionary, "SourceMusicPackFileSpec", j, ref retValue2);
						ReadLocalModSourceMetaDataMusicPackItemValue(retItemSourceParamsDictionary, "SourceMusicPackArtistName", j, ref retValue3);
						ReadLocalModSourceMetaDataMusicPackItemValue(retItemSourceParamsDictionary, "SourceMusicPackTrackName", j, ref retValue4);
						ReadLocalModSourceMetaDataMusicPackItemValue(retItemSourceParamsDictionary, "SourceMusicPackArtistNameOriginal", j, ref retValue5);
						ReadLocalModSourceMetaDataMusicPackItemValue(retItemSourceParamsDictionary, "SourceMusicPackTrackNameOriginal", j, ref retValue6);
						if (!retValue2.IsNullOrEmpty())
						{
							MusicPackSourceItem musicPackSourceItem = new MusicPackSourceItem(retValue2, retValue3, retValue4, retValue5, retValue6);
							musicPackSourceItem.ArtistNameOriginal = retValue5;
							musicPackSourceItem.TrackNameOriginal = retValue6;
							musicPackSourceItems.Add(musicPackSourceItem);
						}
					}
				}
			}
			return result;
		}

		private bool WriteLocalModSourceMetaDataMusicPackItemValue(Dictionary<string, string> localModSourceMetaData, string keyBase, int itemIndex, string value)
		{
			bool result = false;
			string key = $"{keyBase}_{itemIndex}";
			if (localModSourceMetaData.ContainsKey(key))
			{
				localModSourceMetaData.Remove(key);
			}
			key = $"{itemIndex:0000}_{keyBase}";
			if (ExtContentUtils.SetDictionaryValue(localModSourceMetaData, key, value))
			{
				result = true;
			}
			return result;
		}

		private void ReadLocalModSourceMetaDataMusicPackItemValue(Dictionary<string, string> localModSourceMetaData, string keyBase, int itemIndex, ref string retValue)
		{
			string key = $"{itemIndex:0000}_{keyBase}";
			if (!localModSourceMetaData.ContainsKey(key))
			{
				key = $"{keyBase}_{itemIndex}";
			}
			ExtContentUtils.GetDictionaryValue(localModSourceMetaData, key, ref retValue);
		}

		public GameItemCreditsScreen CreateItemCreditsScreen(string title, string description, string sourceAssetBundleFileSpec, string rootAssetName)
		{
			GameItemCreditsScreen gameItemCreditsScreen = null;
			ProcessItemCreditsScreen(ref gameItemCreditsScreen, bCreateNewItem: true, title, description, sourceAssetBundleFileSpec, rootAssetName);
			return gameItemCreditsScreen;
		}

		public bool UpdateItemCreditsScreen(GameItemCreditsScreen gameItemCreditsScreen, string title, string description, string sourceAssetBundleFileSpec, string rootAssetName)
		{
			bool result = false;
			if (gameItemCreditsScreen != null)
			{
				result = ProcessItemCreditsScreen(ref gameItemCreditsScreen, bCreateNewItem: false, title, description, sourceAssetBundleFileSpec, rootAssetName);
			}
			else
			{
				ExtContentMessages.LogError(string.Format(ExtContentMessages.GetMessageString(EMessageType.InvalidGameItemForUpdatingLocalMod), title));
			}
			return result;
		}

		public bool ProcessItemCreditsScreen(ref GameItemCreditsScreen gameItemCreditsScreen, bool bCreateNewItem, string title, string description, string sourceAssetBundleFileSpec, string rootAssetName)
		{
			bool flag = false;
			InvokeOnGameItemPreProcess(EContentType.CreditsScreen, gameItemCreditsScreen);
			if (ValidateTitle(title, bCreateNewItem) && ValidateRootAssetName(rootAssetName))
			{
				string fileName = Path.GetFileName(sourceAssetBundleFileSpec);
				string directoryName = Path.GetDirectoryName(sourceAssetBundleFileSpec);
				string sourceFileName = fileName + ".manifest";
				string text = "UnityAssetBundle";
				string targetFileName = text + ".manifest";
				if (ValidateSourceFileSpec(directoryName, fileName))
				{
					string reItemtLocalModsFolderSpec = string.Empty;
					if (bCreateNewItem)
					{
						GenerateAndCreateItemLocalModsFolder(EContentType.CreditsScreen, title, ref reItemtLocalModsFolderSpec);
					}
					else if (gameItemCreditsScreen != null)
					{
						reItemtLocalModsFolderSpec = gameItemCreditsScreen.InstalledFolderPathSpec;
					}
					if (ValidateItemLocalModsFolderSpec(reItemtLocalModsFolderSpec))
					{
						bool flag2 = false;
						flag2 = !CopyLocalModDataFile(directoryName, fileName, reItemtLocalModsFolderSpec, text);
						if (!flag2)
						{
							flag2 = !CopyLocalModDataFile(directoryName, sourceFileName, reItemtLocalModsFolderSpec, targetFileName);
						}
						if (!flag2)
						{
							if (bCreateNewItem)
							{
								string gameItemInstalledFolderGUID = GameItemUtils.GetGameItemInstalledFolderGUID(EContentSourceType.LocalMods, reItemtLocalModsFolderSpec);
								gameItemCreditsScreen = (GameItemCreditsScreen)GameItemFactory.CreateRawGameItemCreditsScreen(EContentSourceType.LocalMods, title, description, gameItemInstalledFolderGUID, reItemtLocalModsFolderSpec);
								if (gameItemCreditsScreen != null)
								{
									AddLocalModGameItem(gameItemCreditsScreen);
								}
							}
							if (gameItemCreditsScreen != null)
							{
								gameItemCreditsScreen.Title = title;
								gameItemCreditsScreen.Description = description;
								gameItemCreditsScreen.SetData(text, rootAssetName);
								if (gameItemCreditsScreen.UpdateMetaDataFile())
								{
									ReadWriteLocalModSourceMetaDataCreditsScreen(bWrite: true, reItemtLocalModsFolderSpec, ref sourceAssetBundleFileSpec);
									if (bCreateNewItem)
									{
										InvokeOnGameItemCreated(gameItemCreditsScreen);
									}
									else
									{
										InvokeOnGameItemUpdated(gameItemCreditsScreen);
									}
									flag = true;
									ExtContentMessages.LogMessage(string.Format(ExtContentMessages.GetMessageString(EMessageType.SuccessfullyCreatedLocalModItem, bHiliteParams: false), gameItemCreditsScreen.GetLogInfoStringInstalledPath()));
								}
							}
						}
					}
				}
			}
			if (!flag)
			{
				gameItemCreditsScreen = null;
			}
			return flag;
		}

		public bool ReadWriteLocalModSourceMetaDataCreditsScreen(bool bWrite, string itemLocalModsFolderSpec, ref string sourceAssetBundleFileSpec)
		{
			bool result = false;
			Dictionary<string, string> retItemSourceParamsDictionary = null;
			if (_localModsSourceParamsDatabase.Get(itemLocalModsFolderSpec, ref retItemSourceParamsDictionary))
			{
				result = true;
				if (bWrite)
				{
					bool flag = false;
					if (ExtContentUtils.SetDictionaryValue(retItemSourceParamsDictionary, "SourceAssetBundleFileSpec", sourceAssetBundleFileSpec))
					{
						flag = true;
					}
					if (flag)
					{
						_localModsSourceParamsDatabase.UpdateToFile();
					}
				}
				else
				{
					ExtContentUtils.GetDictionaryValue(retItemSourceParamsDictionary, "SourceAssetBundleFileSpec", ref sourceAssetBundleFileSpec);
				}
			}
			return result;
		}

		public GameItemSandboxSave CreateOrUpdateItemSandboxSave(string sandboxSaveFolderSpec, List<string> sandboxSaveFilenames, string sandboxSaveDisplayName, Texture2D texture2DPreviewIcon)
		{
			GameItemSandboxSave retGameItemSandboxSave = null;
			ProcessItemSandboxSave(ref retGameItemSandboxSave, sandboxSaveFolderSpec, sandboxSaveFilenames, sandboxSaveDisplayName, texture2DPreviewIcon);
			return retGameItemSandboxSave;
		}

		private bool ProcessItemSandboxSave(ref GameItemSandboxSave retGameItemSandboxSave, string sandboxSaveFolderSpec, List<string> sandboxSaveFilenames, string sandboxSaveDisplayName, Texture2D texture2DPreviewIcon)
		{
			bool result = false;
			InvokeOnGameItemPreProcess(EContentType.SandboxSave, retGameItemSandboxSave);
			if (ValidateFolderSpec(sandboxSaveFolderSpec))
			{
				bool flag = true;
				foreach (string sandboxSaveFilename in sandboxSaveFilenames)
				{
					if (!ValidateSourceFileSpec(sandboxSaveFolderSpec, sandboxSaveFilename))
					{
						flag = false;
						ExtContentMessages.LogError(string.Format(ExtContentMessages.GetMessageString(EMessageType.InvalidFileGeneral), sandboxSaveFolderSpec, sandboxSaveFilename));
					}
				}
				if (flag)
				{
					string fileName = Path.GetFileName(sandboxSaveFolderSpec);
					string description = fileName;
					if (!fileName.IsNullOrEmpty())
					{
						string baseLocalModFolderSpec = GetBaseLocalModFolderSpec(EContentType.SandboxSave, fileName);
						EnsureItemLocalModsFolderExists(EContentType.SandboxSave, fileName, baseLocalModFolderSpec);
						bool flag2 = true;
						foreach (string sandboxSaveFilename2 in sandboxSaveFilenames)
						{
							if (!CopyLocalModDataFile(sandboxSaveFolderSpec, sandboxSaveFilename2, baseLocalModFolderSpec, sandboxSaveFilename2))
							{
								flag2 = false;
								break;
							}
						}
						if (flag2 && texture2DPreviewIcon != null)
						{
							string pathSpec = ExtContentUtils.GetPathSpec(baseLocalModFolderSpec, "PreviewIcon.png");
							bool flag3 = true;
							Texture2D texture2D = ExtContentTextureUtils.CreateUncompressedTexture2D(texture2DPreviewIcon);
							if (texture2D != null && ExtContentTextureUtils.SaveTexture2D(texture2D, pathSpec))
							{
								flag3 = false;
							}
							if (flag3)
							{
								flag2 = false;
								ExtContentMessages.LogError(string.Format(ExtContentMessages.GetMessageString(EMessageType.ErrorCreatingSandboxSavePreviewIcon), pathSpec));
							}
						}
						if (flag2)
						{
							bool flag4 = false;
							retGameItemSandboxSave = (GameItemSandboxSave)FindGameItemByInstalledPath(baseLocalModFolderSpec, bSilent: true);
							if (retGameItemSandboxSave == null)
							{
								string gameItemInstalledFolderGUID = GameItemUtils.GetGameItemInstalledFolderGUID(EContentSourceType.LocalMods, baseLocalModFolderSpec);
								retGameItemSandboxSave = (GameItemSandboxSave)GameItemFactory.CreateRawGameItemSandboxSave(EContentSourceType.LocalMods, fileName, description, gameItemInstalledFolderGUID, baseLocalModFolderSpec);
								if (retGameItemSandboxSave != null)
								{
									flag4 = true;
									AddLocalModGameItem(retGameItemSandboxSave);
								}
							}
							if (retGameItemSandboxSave != null)
							{
								retGameItemSandboxSave.Title = fileName;
								retGameItemSandboxSave.Description = description;
								retGameItemSandboxSave.SetData(sandboxSaveDisplayName);
								if (retGameItemSandboxSave.UpdateMetaDataFile())
								{
									if (flag4)
									{
										InvokeOnGameItemCreated(retGameItemSandboxSave);
									}
									else
									{
										InvokeOnGameItemUpdated(retGameItemSandboxSave);
									}
									result = true;
									ExtContentMessages.LogMessage(string.Format(ExtContentMessages.GetMessageString(EMessageType.SuccessfullyCreatedLocalModItem, bHiliteParams: false), retGameItemSandboxSave.GetLogInfoStringInstalledPath()));
								}
							}
						}
					}
					else
					{
						ExtContentMessages.LogError(string.Format(ExtContentMessages.GetMessageString(EMessageType.ErrorObtainingSandboxSaveTitle), sandboxSaveFolderSpec));
					}
				}
			}
			return result;
		}

		public GameItemMusicPack CreateItemMusicPack(string title, string description, List<MusicPackSourceItem> musicPackSourceItems)
		{
			GameItemMusicPack gameItemMusicPack = null;
			ProcessItemMusicPack(ref gameItemMusicPack, bCreateNewItem: true, title, description, musicPackSourceItems);
			return gameItemMusicPack;
		}

		public bool UpdateItemMusicPack(GameItemMusicPack gameItemMusicPack, string title, string description, List<MusicPackSourceItem> musicPackSourceItems)
		{
			bool result = false;
			if (gameItemMusicPack != null)
			{
				result = ProcessItemMusicPack(ref gameItemMusicPack, bCreateNewItem: false, title, description, musicPackSourceItems);
			}
			else
			{
				ExtContentMessages.LogError(string.Format(ExtContentMessages.GetMessageString(EMessageType.InvalidGameItemForUpdatingLocalMod), title));
			}
			return result;
		}

		public bool ProcessItemMusicPack(ref GameItemMusicPack gameItemMusicPack, bool bCreateNewItem, string title, string description, List<MusicPackSourceItem> musicPackSourceItems)
		{
			bool flag = false;
			InvokeOnGameItemPreProcess(EContentType.MusicPack, gameItemMusicPack);
			title = SanitizeTitle(title);
			if (ValidateTitle(title, bCreateNewItem))
			{
				bool flag2 = true;
				foreach (MusicPackSourceItem musicPackSourceItem in musicPackSourceItems)
				{
					if (!ValidateSourceFileSpec(musicPackSourceItem.FileSpec))
					{
						flag2 = false;
						ExtContentMessages.LogError(string.Format(ExtContentMessages.GetMessageString(EMessageType.InvalidFileSpecGeneral), musicPackSourceItem.FileSpec));
					}
				}
				if (flag2)
				{
					string reItemtLocalModsFolderSpec = string.Empty;
					if (bCreateNewItem)
					{
						GenerateAndCreateItemLocalModsFolder(EContentType.MusicPack, title, ref reItemtLocalModsFolderSpec);
					}
					else if (gameItemMusicPack != null)
					{
						reItemtLocalModsFolderSpec = gameItemMusicPack.InstalledFolderPathSpec;
					}
					if (ValidateItemLocalModsFolderSpec(reItemtLocalModsFolderSpec))
					{
						EnsureItemLocalModsFolderExists(EContentType.MusicPack, title, reItemtLocalModsFolderSpec);
						bool flag3 = true;
						foreach (MusicPackSourceItem musicPackSourceItem2 in musicPackSourceItems)
						{
							string directoryName = Path.GetDirectoryName(musicPackSourceItem2.FileSpec);
							string fileName = Path.GetFileName(musicPackSourceItem2.FileSpec);
							if (!CopyLocalModDataFile(directoryName, fileName, reItemtLocalModsFolderSpec, fileName))
							{
								flag3 = false;
								break;
							}
						}
						if (flag3)
						{
							List<string> list = new List<string>();
							foreach (MusicPackSourceItem musicPackSourceItem3 in musicPackSourceItems)
							{
								list.Add(Path.GetFileName(musicPackSourceItem3.FileSpec));
							}
							List<string> list2 = new List<string>();
							list2.Add("json");
							ExtContentUtils.DeleteInvalidFiles(reItemtLocalModsFolderSpec, list, list2);
						}
						if (flag3)
						{
							if (bCreateNewItem)
							{
								string gameItemInstalledFolderGUID = GameItemUtils.GetGameItemInstalledFolderGUID(EContentSourceType.LocalMods, reItemtLocalModsFolderSpec);
								gameItemMusicPack = (GameItemMusicPack)GameItemFactory.CreateRawGameItemMusicPack(EContentSourceType.LocalMods, title, description, gameItemInstalledFolderGUID, reItemtLocalModsFolderSpec);
								if (gameItemMusicPack != null)
								{
									AddLocalModGameItem(gameItemMusicPack);
								}
							}
							if (gameItemMusicPack != null)
							{
								gameItemMusicPack.Title = title;
								gameItemMusicPack.Description = description;
								gameItemMusicPack.SetData(musicPackSourceItems);
								if (gameItemMusicPack.UpdateMetaDataFile())
								{
									ReadWriteLocalModSourceMetaDataMusicPack(bWrite: true, reItemtLocalModsFolderSpec, ref musicPackSourceItems);
									if (bCreateNewItem)
									{
										InvokeOnGameItemCreated(gameItemMusicPack);
									}
									else
									{
										InvokeOnGameItemUpdated(gameItemMusicPack);
									}
									flag = true;
									ExtContentMessages.LogMessage(string.Format(ExtContentMessages.GetMessageString(EMessageType.SuccessfullyCreatedLocalModItem, bHiliteParams: false), gameItemMusicPack.GetLogInfoStringInstalledPath()));
								}
							}
						}
					}
				}
			}
			if (!flag)
			{
				gameItemMusicPack = null;
			}
			return flag;
		}

		public bool DeleteLocalModGameItem(GameItemBase gameItemBase)
		{
			bool result = false;
			if (gameItemBase != null && gameItemBase.ValidateReadyForDelete())
			{
				result = true;
				string installedFolderPathSpec = gameItemBase.InstalledFolderPathSpec;
				_localModGameItems.Remove(gameItemBase);
				gameItemBase.DeInit();
				InvokeOnGameItemDeleted(gameItemBase);
				ExtContentUtils.DeleteFolder(installedFolderPathSpec);
			}
			return result;
		}

		public bool PublishLocalModGameItemToWorkshop(GameItemBase gameItem, string workshopItemTitle, string workshopItemDescription, string workshopItemPreviewImageFileSpec, EItemVisibility workshopItemVisibility, bool bForceCreateNewWorkshopItem, WorkshopContentCreationManager.OnPublishCompleteCallback OnPublishComplete = null)
		{
			bool result = false;
			if (CheckGameItemIsLocalModGameItem(gameItem))
			{
				_onPublishCompleteUser = OnPublishComplete;
				result = _workshopContentCreationManager.PublishGameItemToWorkshop(gameItem, workshopItemTitle, workshopItemDescription, workshopItemPreviewImageFileSpec, workshopItemVisibility, bForceCreateNewWorkshopItem);
			}
			return result;
		}

		public bool AbortPublishFolderToWorkshop()
		{
			return _workshopContentCreationManager.AbortPublishFolderToWorkshop();
		}

		private void OnGameItemCreatedFn(GameItemBase gameItemBase)
		{
			SendAnalyticsEventLocalModItemCreated(gameItemBase);
		}

		private void OnPublishComplete(bool bSuccess, bool bAborted, bool bNewItem, WorkshopItemMetaData workshopItemMetaData, string publishFolderSpec)
		{
			if (bSuccess)
			{
				UpdateGameItemsPublishedDataRefsByFolder(workshopItemMetaData, publishFolderSpec);
				if (bNewItem)
				{
					SendAnalyticsEventLocalModItemFirstPublished(workshopItemMetaData);
				}
			}
			if (_onPublishCompleteUser != null)
			{
				_onPublishCompleteUser(bSuccess, bAborted, bNewItem, workshopItemMetaData, publishFolderSpec);
				_onPublishCompleteUser = null;
			}
			if (bSuccess)
			{
				_extContentManager.ContentSourceWorkshop.SetCheckDownloadQueryPending(bSet: true, bQueryAllSubscribedToItems: true, WorkshopUtils.PublishedFileIdFromString(workshopItemMetaData.PublishedFileId));
			}
		}

		private void OnPublishPreUpload(bool bSuccess, bool bNewItem, WorkshopItemMetaData workshopItemMetaData, string publishFolderSpec)
		{
		}

		private void OnPublishPostUpload(bool bSuccess, bool bNewItem, WorkshopItemMetaData workshopItemMetaData, string publishFolderSpec)
		{
			if (!bSuccess)
			{
				ExtContentMessages.ShowPlayerGeneralErrorMessageBox();
			}
		}

		private void SendAnalyticsEventLocalModItemCreated(GameItemBase gameItemBase)
		{
			if (_extContentManager.AnalyticsManager == null)
			{
				return;
			}
			string value = string.Empty;
			if (gameItemBase is GameItemPictureBase gameItemPictureBase)
			{
				GameItemPictureBase.GameItemPictureBaseConfig pictureBaseConfigForContentTypeAndTag = ExtContentUtils.GetPictureBaseConfigForContentTypeAndTag(gameItemBase.ContentType, gameItemPictureBase.ItemSubTypeID);
				if (pictureBaseConfigForContentTypeAndTag != null)
				{
					value = pictureBaseConfigForContentTypeAndTag._itemAnalyticsName;
				}
			}
			Logging.Info(LogChannels.Analytics, $"Sending UGC analytics: Local mod item created: ContentID: '{gameItemBase.ContentID}'");
			GameEvent gameEvent = new GameEvent(_extContentManager.AnalyticsManager.Config.UGCLocalModCreatedInfo).AddParam("contentid", gameItemBase.ContentID).AddParam("contenttype", ExtContentType.ContentTypeToString(gameItemBase.ContentType)).AddParam("subtype", value);
			_extContentManager.AnalyticsManager.RecordEvent(gameEvent);
		}

		private void SendAnalyticsEventLocalModItemFirstPublished(WorkshopItemMetaData workshopItemMetaData)
		{
			if (workshopItemMetaData != null && _extContentManager.AnalyticsManager != null)
			{
				Logging.Info(LogChannels.Analytics, $"Sending UGC analytics: Local mod item first published to workshop: PublishedFileId: '{workshopItemMetaData.PublishedFileId}'");
				string value = string.Empty;
				GameItemPictureBase.GameItemPictureBaseConfig pictureBaseConfigForContentTypeAndTag = ExtContentUtils.GetPictureBaseConfigForContentTypeAndTag(workshopItemMetaData.FirstItemContentType, workshopItemMetaData.FirstItemContentSubType);
				if (pictureBaseConfigForContentTypeAndTag != null)
				{
					value = pictureBaseConfigForContentTypeAndTag._itemAnalyticsName;
				}
				GameEvent gameEvent = new GameEvent(_extContentManager.AnalyticsManager.Config.UGCLocalModPublishedInfo).AddParam("publishedfileid", workshopItemMetaData.PublishedFileId).AddParam("contenttype", workshopItemMetaData.ContentType).AddParam("numgameitems", workshopItemMetaData.NumGameItems)
					.AddParam("firstitemcontenttype", workshopItemMetaData.FirstItemContentType)
					.AddParam("firstitemsubtype", value);
				_extContentManager.AnalyticsManager.RecordEvent(gameEvent);
			}
		}

		public bool CheckGameItemIsLocalModGameItem(GameItemBase gameItem)
		{
			bool result = false;
			if (gameItem != null)
			{
				if (_localModGameItems.Contains(gameItem))
				{
					result = true;
				}
				else
				{
					ExtContentMessages.LogError(string.Format(ExtContentMessages.GetMessageString(EMessageType.GameItemIsNotALocalMod, bHiliteParams: false), gameItem.GetLogInfoStringInstalledPath()));
				}
			}
			else
			{
				ExtContentMessages.LogError(string.Format(ExtContentMessages.GetMessageString(EMessageType.InvalidGameItemForUpdatingLocalMod), string.Empty));
			}
			return result;
		}

		public bool GetPublishBundleGameItemsMetaDataForGameItemByTitle(string localModGameItemTitle, ref List<GameItemMetaData> retBundleGameItemsMetaData)
		{
			bool result = false;
			GameItemBase gameItemBase = FindGameItemByTitle(localModGameItemTitle);
			if (gameItemBase != null)
			{
				result = GetPublishBundleGameItemsMetaDataForGameItem(gameItemBase, ref retBundleGameItemsMetaData);
			}
			return result;
		}

		public bool GetGameItemPublishBundleData(GameItemBase gameItemBase, ref string retPublishFolderSpec, ref EContentType retWorkshopItemContentType, ref WorkshopItemMetaData retWorkshopMetaData, ref List<GameItemMetaData> retBundleGameItemsMetaData)
		{
			bool result = false;
			if (_workshopContentCreationManager.DetermineValidPublishFolderSpec(gameItemBase.InstalledFolderPathSpec, ref retPublishFolderSpec))
			{
				result = true;
				if (WorkshopItemMetaData.DoesMetaDataFileExist(retPublishFolderSpec))
				{
					retWorkshopMetaData = new WorkshopItemMetaData();
					retWorkshopMetaData.ReadFromMetaDataFile(retPublishFolderSpec);
				}
				retWorkshopItemContentType = EContentType.Bundle;
				if (retWorkshopMetaData == null)
				{
					GameItemMetaData gameItemMetaData = GameItemUtils.LoadGameItemMetaData(retPublishFolderSpec);
					if (gameItemMetaData != null)
					{
						EContentType retContentType = EContentType.None;
						if (GameItemUtils.GetGameItemMetaDataContentType(gameItemMetaData, ref retContentType))
						{
							retWorkshopItemContentType = retContentType;
						}
					}
				}
				else
				{
					retWorkshopItemContentType = retWorkshopMetaData.ContentType;
				}
				GameItemUtils.ScanFoldersForGameItemMetaData(retPublishFolderSpec, ref retBundleGameItemsMetaData);
			}
			return result;
		}

		public bool GetPublishBundleGameItemsMetaDataForGameItem(GameItemBase gameItemBase, ref List<GameItemMetaData> retBundleGameItemsMetaData)
		{
			bool result = false;
			WorkshopItemMetaData retWorkshopMetaData = null;
			string retPublishFolderSpec = string.Empty;
			if (_workshopContentCreationManager.GetPublishedMetaDataForGameItem(gameItemBase, ref retWorkshopMetaData, ref retPublishFolderSpec) && GameItemUtils.ScanFoldersForGameItemMetaData(retPublishFolderSpec, ref retBundleGameItemsMetaData))
			{
				result = true;
			}
			return result;
		}

		private bool UpdateGameItemsPublishedDataRefs()
		{
			bool result = true;
			foreach (GameItemBase localModGameItem in _localModGameItems)
			{
				if (localModGameItem.PublishedWorkshopMetaData != null)
				{
					continue;
				}
				WorkshopItemMetaData retWorkshopMetaData = null;
				string retPublishFolderSpec = string.Empty;
				_workshopContentCreationManager.GetPublishedMetaDataForGameItem(localModGameItem, ref retWorkshopMetaData, ref retPublishFolderSpec);
				if (retWorkshopMetaData != null)
				{
					localModGameItem.PublishedWorkshopMetaData = retWorkshopMetaData;
					if (localModGameItem.InstalledFolderPathSpec != retPublishFolderSpec)
					{
						localModGameItem.PublishedWorkshopMetaData = retWorkshopMetaData;
						UpdateGameItemsPublishedDataRefsByFolder(retWorkshopMetaData, retPublishFolderSpec);
					}
					else
					{
						localModGameItem.PublishedWorkshopMetaData = retWorkshopMetaData;
					}
				}
			}
			return result;
		}

		private bool UpdateGameItemsPublishedDataRefsByFolder(WorkshopItemMetaData workshopMetaData, string publishFolderSpec)
		{
			bool result = true;
			foreach (GameItemBase localModGameItem in _localModGameItems)
			{
				if (localModGameItem.InstalledFolderPathSpec.StartsWith(publishFolderSpec))
				{
					localModGameItem.PublishedWorkshopMetaData = workshopMetaData;
				}
			}
			return result;
		}

		public bool RepublishGameItem(GameItemBase gameItemBase, WorkshopContentCreationManager.OnPublishCompleteCallback OnRepublishComplete = null)
		{
			bool result = false;
			if (gameItemBase != null)
			{
				WorkshopItemMetaData retWorkshopMetaData = null;
				string retPublishFolderSpec = string.Empty;
				if (_workshopContentCreationManager.GetPublishedMetaDataForGameItem(gameItemBase, ref retWorkshopMetaData, ref retPublishFolderSpec))
				{
					_onPublishCompleteUser = OnRepublishComplete;
					if (_workshopContentCreationManager.PublishGameItemToWorkshop(gameItemBase, retWorkshopMetaData.Title, retWorkshopMetaData.Description, ExtContentUtils.NormalisePathSpec(ExtContentUtils.GetPathSpec(retPublishFolderSpec, retWorkshopMetaData.PreviewFileName)), retWorkshopMetaData.Visibility, bForceCreateNewWorkshopItem: false))
					{
						result = true;
					}
				}
			}
			return result;
		}

		public void RepublishAllLocalMods()
		{
			RepublishGameItemsStart(GetAllGameItems());
		}

		public bool TouchAllLocalMods()
		{
			bool result = true;
			foreach (GameItemBase localModGameItem in _localModGameItems)
			{
				if (!localModGameItem.UpdateMetaDataFile())
				{
					result = false;
				}
			}
			return result;
		}

		private void RepublishGameItemsStart(List<GameItemBase> republishGameItems)
		{
			_republishGameItems = republishGameItems;
			_currentRepublishIndex = 0;
			RepublishGameItemsProcessCurrent();
		}

		private void RepublishGameItemsProcessCurrent()
		{
			if (!RepublishGameItem(_republishGameItems[_currentRepublishIndex], OnRepublishComplete))
			{
				RepublishGameItemsSetNext();
			}
		}

		private void OnRepublishComplete(bool bSuccess, bool bAborted, bool bNewItem, WorkshopItemMetaData workshopItemMetaData, string publishFolderSpec)
		{
			RepublishGameItemsSetNext();
		}

		private void RepublishGameItemsSetNext()
		{
			_currentRepublishIndex++;
			if (_currentRepublishIndex < _republishGameItems.Count)
			{
				RepublishGameItemsProcessCurrent();
			}
			else
			{
				RepublishGameItemsEnd();
			}
		}

		private void RepublishGameItemsEnd()
		{
			_republishGameItems.Clear();
			_republishGameItems = null;
		}

		private bool ValidateItemLocalModsFolderSpec(string folderSpec)
		{
			bool flag = false;
			if (!folderSpec.IsNullOrEmpty() && Directory.Exists(folderSpec))
			{
				flag = true;
			}
			if (!flag)
			{
				ExtContentMessages.LogError(string.Format(ExtContentMessages.GetMessageString(EMessageType.LocalModItemInstalledFolderInvalid), folderSpec));
			}
			return flag;
		}

		private bool ValidateFolderSpec(string folderSpec)
		{
			bool flag = false;
			if (!folderSpec.IsNullOrEmpty() && Directory.Exists(folderSpec))
			{
				flag = true;
			}
			if (!flag)
			{
				ExtContentMessages.LogError(string.Format(ExtContentMessages.GetMessageString(EMessageType.InvalidFolderGeneral), folderSpec));
			}
			return flag;
		}

		private bool ValidateTitle(string title, bool bMustBeUnique = false)
		{
			bool result = false;
			if (!title.IsNullOrEmpty())
			{
				if (bMustBeUnique)
				{
					string text = title.ToLower();
					bool flag = true;
					foreach (GameItemBase item in GetAllGameItemsRef())
					{
						if (text == item.Title.ToLower())
						{
							flag = false;
							break;
						}
					}
					if (flag)
					{
						result = true;
					}
					else
					{
						ExtContentMessages.LogError(string.Format(ExtContentMessages.GetMessageString(EMessageType.LocalModGameItemTitleNotUnique), title));
					}
				}
				else
				{
					result = true;
				}
			}
			else
			{
				ExtContentMessages.LogError(string.Format(ExtContentMessages.GetMessageString(EMessageType.InvalidGameItemTitle), title));
			}
			return result;
		}

		private bool ValidateRootAssetName(string rootAssetName)
		{
			bool result = false;
			if (!rootAssetName.IsNullOrEmpty())
			{
				result = true;
			}
			else
			{
				ExtContentMessages.LogError(string.Format(ExtContentMessages.GetMessageString(EMessageType.InvalidGameItemRootAssetName), rootAssetName));
			}
			return result;
		}

		private bool ValidateSourceFileSpec(string sourceFileSpec)
		{
			return ValidateSourceFileSpec(Path.GetDirectoryName(sourceFileSpec), Path.GetFileName(sourceFileSpec));
		}

		private bool ValidateSourceFileSpec(string sourceFolder, string sourceFileName)
		{
			bool result = false;
			if (!sourceFolder.IsNullOrEmpty())
			{
				if (!sourceFileName.IsNullOrEmpty())
				{
					string pathSpec = ExtContentUtils.GetPathSpec(sourceFolder, sourceFileName);
					if (File.Exists(pathSpec))
					{
						result = true;
					}
					else
					{
						ExtContentMessages.LogError(string.Format(ExtContentMessages.GetMessageString(EMessageType.LocalModItemSourceFileNotExist), pathSpec));
					}
				}
				else
				{
					ExtContentMessages.LogError(string.Format(ExtContentMessages.GetMessageString(EMessageType.LocalModItemSourceFileNameInvalid), sourceFileName));
				}
			}
			else
			{
				ExtContentMessages.LogError(string.Format(ExtContentMessages.GetMessageString(EMessageType.LocalModItemSourceFolderInvalid), sourceFolder));
			}
			return result;
		}

		private bool ValidateOptionalSourceFileSpec(string sourceFolder, string sourceFileName)
		{
			bool result = false;
			if (!sourceFolder.IsNullOrEmpty() || !sourceFileName.IsNullOrEmpty())
			{
				string pathSpec = ExtContentUtils.GetPathSpec(sourceFolder, sourceFileName);
				if (File.Exists(pathSpec))
				{
					result = true;
				}
				else
				{
					ExtContentMessages.LogError(string.Format(ExtContentMessages.GetMessageString(EMessageType.LocalModItemSourceFileNotExist), pathSpec));
				}
			}
			else
			{
				result = true;
			}
			return result;
		}

		private bool ValidateTextureFile(string textureFileFolder, string textureFileName)
		{
			bool result = false;
			if (ValidateSourceFileSpec(textureFileFolder, textureFileName) && ExtContentTextureUtils.ValidateTextureFileSpecForLoading(ExtContentUtils.GetPathSpec(textureFileFolder, textureFileName)))
			{
				result = true;
			}
			return result;
		}

		private bool GenerateAndCreateItemLocalModsFolder(EContentType contentType, string title, ref string reItemtLocalModsFolderSpec)
		{
			bool result = false;
			if (ValidateTitle(title) && EnsureLocalModsContentTypeFoldersExist(contentType) && GenerateValidLocalModFolderSpec(contentType, title, ref reItemtLocalModsFolderSpec) && ExtContentUtils.CreateFolder(reItemtLocalModsFolderSpec))
			{
				result = true;
			}
			return result;
		}

		private bool EnsureItemLocalModsFolderExists(EContentType contentType, string title, string itemtLocalModsFolderSpec)
		{
			bool result = false;
			if (EnsureLocalModsContentTypeFoldersExist(contentType) && !Directory.Exists(itemtLocalModsFolderSpec) && ExtContentUtils.CreateFolder(itemtLocalModsFolderSpec))
			{
				result = true;
			}
			return result;
		}

		private bool EnsureLocalModsContentTypeFoldersExist(EContentType contentType)
		{
			bool result = false;
			if (ExtContentType.IsValid(contentType))
			{
				string localModsFolderSpec = GetLocalModsFolderSpec();
				bool flag = false;
				if (!Directory.Exists(localModsFolderSpec) && !ExtContentUtils.CreateFolder(localModsFolderSpec))
				{
					flag = true;
				}
				string fileName = ExtContentType.ContentTypeToString(contentType);
				string pathSpec = ExtContentUtils.GetPathSpec(localModsFolderSpec, fileName);
				if (!flag && !Directory.Exists(pathSpec) && !ExtContentUtils.CreateFolder(pathSpec))
				{
					flag = true;
				}
				if (!flag)
				{
					result = true;
				}
			}
			else
			{
				ExtContentMessages.LogError(string.Format(ExtContentMessages.GetMessageString(EMessageType.LocalModsFolderInvalidContentType), ExtContentType.ContentTypeToString(contentType)));
			}
			return result;
		}

		public string GetBaseLocalModFolderSpec(EContentType contentType, string title)
		{
			string empty = string.Empty;
			string localModsContentTypeFolderSpec = GetLocalModsContentTypeFolderSpec(contentType);
			empty = ExtContentUtils.SanitizeFileOrFolderName(title);
			return ExtContentUtils.GetPathSpec(localModsContentTypeFolderSpec, empty);
		}

		public bool GenerateValidLocalModFolderSpec(EContentType contentType, string title, ref string retFolderSpec)
		{
			bool result = false;
			retFolderSpec = string.Empty;
			string baseLocalModFolderSpec = GetBaseLocalModFolderSpec(contentType, title);
			string text = baseLocalModFolderSpec;
			bool flag = false;
			if (Directory.Exists(text))
			{
				for (int i = 0; i < 999; i++)
				{
					text = $"{baseLocalModFolderSpec}-{i + 1}";
					if (!Directory.Exists(text))
					{
						flag = true;
						break;
					}
				}
			}
			else
			{
				flag = true;
			}
			if (flag)
			{
				result = true;
				retFolderSpec = text;
			}
			return result;
		}

		private bool CopyLocalModDataFile(string sourceFolder, string sourceFileName, string targetItemLocalModsFolderSpec, string targetFileName)
		{
			bool result = false;
			string pathSpec = ExtContentUtils.GetPathSpec(sourceFolder, sourceFileName);
			string pathSpec2 = ExtContentUtils.GetPathSpec(targetItemLocalModsFolderSpec, targetFileName);
			if (File.Exists(pathSpec))
			{
				if (pathSpec2 != pathSpec)
				{
					try
					{
						File.Copy(pathSpec, pathSpec2, overwrite: true);
						result = true;
						ExtContentMessages.LogMessage(string.Format(ExtContentMessages.GetMessageString(EMessageType.SuccessfullyCopiedLocalModFile), pathSpec, pathSpec2));
					}
					catch (Exception ex)
					{
						ExtContentMessages.LogError(string.Format(ExtContentMessages.GetMessageString(EMessageType.ErrorCopyingLocalModsFile), pathSpec, pathSpec2, ex.ToString()));
					}
				}
				else
				{
					result = true;
				}
			}
			else
			{
				ExtContentMessages.LogError(string.Format(ExtContentMessages.GetMessageString(EMessageType.LocalModCopySourceFileDoesNotExist), pathSpec));
			}
			return result;
		}

		private bool CreateLocalModMainTextureStagedCopy(ExtContentImageSpec sourceImageSpec, ExtContentImageSpec targetImageSpec, EContentType contentType, string subTypeID)
		{
			bool result = false;
			GameItemPictureBase.GameItemPictureBaseConfig pictureBaseConfigForContentType = ExtContentUtils.GetPictureBaseConfigForContentType(contentType, subTypeID);
			if (pictureBaseConfigForContentType != null)
			{
				result = ExtContentTextureUtils.CopyTextureFileSelection(sourceImageSpec, targetImageSpec, IconGenData.GetImageBGColour(pictureBaseConfigForContentType._iconGenData), ExtContentUtils.TexturesConfig.MaxStagedMainTextureDimension);
			}
			return result;
		}

		private bool CreateLocalModIconTextureStagedCopy(bool bIconOverrideSpecified, ExtContentImageSpec sourceImageSpec, ExtContentImageSpec targetImageSpec, EContentType contentType, string subTypeID, int iconVariationIndex)
		{
			bool result = false;
			GameItemPictureBase.GameItemPictureBaseConfig pictureBaseConfigForContentType = ExtContentUtils.GetPictureBaseConfigForContentType(contentType, subTypeID);
			if (pictureBaseConfigForContentType != null)
			{
				IconGenParams variationIconGenParams = IconGenData.GetVariationIconGenParams(pictureBaseConfigForContentType._iconGenData, iconVariationIndex);
				if (variationIconGenParams != null)
				{
					result = ExtContentTextureUtils.CopyTextureFileSelectionCompositeIcon(bIconOverrideSpecified, sourceImageSpec, targetImageSpec, variationIconGenParams, IconGenData.GetImageBGColour(pictureBaseConfigForContentType._iconGenData), ExtContentUtils.TexturesConfig.MaxStagedIconTextureDimension);
				}
			}
			return result;
		}

		private void AddLocalModGameItem(GameItemBase gameItem)
		{
			_localModGameItems.Add(gameItem);
		}

		private void InitGameItems()
		{
			DeInitGameItems();
			_localModGameItems = new List<GameItemBase>();
			GameItemUtils.ScanFoldersForGameItems(EContentSourceType.LocalMods, GetLocalModsFolderSpec(), ref _localModGameItems);
			UpdateGameItemsPublishedDataRefs();
			ValidateAllLocalModGameItemContentIDs();
			foreach (GameItemBase localModGameItem in _localModGameItems)
			{
				localModGameItem.ProcessOnDataUpdatedPending();
			}
			LogGameItems();
		}

		private void DeInitGameItems()
		{
			if (_localModGameItems == null)
			{
				return;
			}
			foreach (GameItemBase localModGameItem in _localModGameItems)
			{
				localModGameItem.DeInit();
			}
			_localModGameItems.Clear();
			_localModGameItems = null;
		}

		public void RefreshGameItems()
		{
			DeInitGameItems();
			InitGameItems();
		}

		public void Update()
		{
			ProcessCheckPublishedItemDetailsUpdatePending();
		}

		public bool ValidateAllLocalModGameItemContentIDs(bool bSilent = false)
		{
			bool result = false;
			int num = 0;
			int num2 = 0;
			foreach (GameItemBase localModGameItem in _localModGameItems)
			{
				string contentID = localModGameItem.ContentID;
				if (localModGameItem.ValidateContentID())
				{
					num++;
					if (CopyGameItemLocalSourceParamsDBData(localModGameItem, contentID))
					{
						num2++;
					}
				}
			}
			if (num2 > 0)
			{
				_localModsSourceParamsDatabase.UpdateToFile();
			}
			if (num > 0 && !bSilent)
			{
				ExtContentMessages.LogMessage($"{ExtContentMessages.GetMessageString(EMessageType.ExternalContentValidation)}: {string.Format(ExtContentMessages.GetMessageString(EMessageType.AmendedLocalModItemContentIDs), num)}");
			}
			return result;
		}

		private void SetCheckPublishedItemDetailsUpdatePending(bool bSet = true)
		{
			_publishedItemDetailsUpdatePending = bSet && WorkshopUtils.AreSteamWorkshopFeaturesAvailable();
		}

		private void ProcessCheckPublishedItemDetailsUpdatePending()
		{
			if (_publishedItemDetailsUpdatePending && CheckPublishedItemDetailsUpdate())
			{
				_publishedItemDetailsUpdatePending = false;
			}
		}

		private bool CheckPublishedItemDetailsUpdate()
		{
			bool result = false;
			if (WorkshopUtils.AreSteamWorkshopFeaturesAvailable() && !_extContentManager.IsCurrentlyUsingOnlineServices())
			{
				result = true;
				List<string> targetFileSpecs = null;
				if (ExtContentUtils.ScanFoldersForFileSpecs(GetLocalModsFolderSpec(), "WorkshopMetaData.json", ref targetFileSpecs) && targetFileSpecs.Count > 0)
				{
					_publishedItemDetailsUpdateMetaData = new List<WorkshopItemMetaData>();
					_publishedItemDetailsUpdateMetaDataFileSpecs = new List<string>();
					foreach (string item in targetFileSpecs)
					{
						bool flag = false;
						WorkshopItemMetaData workshopItemMetaData = new WorkshopItemMetaData();
						if (workshopItemMetaData.ReadFromMetaDataFile(Path.GetDirectoryName(item)) && !workshopItemMetaData.PublishedFileId.IsNullOrEmpty())
						{
							flag = true;
							_publishedItemDetailsUpdateMetaData.Add(workshopItemMetaData);
							_publishedItemDetailsUpdateMetaDataFileSpecs.Add(item);
						}
						if (!flag)
						{
							ExtContentMessages.LogDebug(string.Format(ExtContentUtils.HiliteParams("Published Item not addded for detail update query in folder '{0}'"), item));
						}
					}
					if (_publishedItemDetailsUpdateMetaData.Count > 0)
					{
						_publishedItemDetailsUpdateIds = new PublishedFileId_t[_publishedItemDetailsUpdateMetaData.Count];
						int i = 0;
						for (int count = _publishedItemDetailsUpdateMetaData.Count; i < count; i++)
						{
							_publishedItemDetailsUpdateIds[i] = WorkshopUtils.PublishedFileIdFromString(_publishedItemDetailsUpdateMetaData[i].PublishedFileId);
						}
						_queryItemsCoroutine = _behaviourToRunCoroutinesOn.StartCoroutine(PublishedItemDetailsUpdateQueryCoroutine());
					}
				}
			}
			return result;
		}

		private IEnumerator PublishedItemDetailsUpdateQueryCoroutine()
		{
			_publishedItemDetailsUpdateInProgress = true;
			WorkshopUtils.ResetLastSteamResult();
			uint numSubscribedToItems = (uint)_publishedItemDetailsUpdateIds.Length;
			int numItemsUpdated = 0;
			int numItemUpdateErrors = 0;
			if (numSubscribedToItems != 0)
			{
				WaitForCallResult<SteamUGCQueryCompleted_t> queryResult = WorkshopUtils.StartPublishedItemsQuery(numSubscribedToItems, _publishedItemDetailsUpdateIds);
				yield return queryResult.WaitForResult();
				if (WorkshopUtils.ValidateItemsQueryResult(queryResult.Result, numSubscribedToItems))
				{
					List<WorkshopItemDetail> workshopItemsDetails = null;
					if (WorkshopUtils.CreateItemDetailsFromQueryResult(queryResult.Result, ref workshopItemsDetails))
					{
						foreach (WorkshopItemDetail item in workshopItemsDetails)
						{
							int num = -1;
							int i = 0;
							for (int num2 = _publishedItemDetailsUpdateIds.Length; i < num2; i++)
							{
								if (_publishedItemDetailsUpdateIds[i] == item.PublishedFileId)
								{
									num = i;
									break;
								}
							}
							if (num < 0)
							{
								continue;
							}
							WorkshopItemMetaData workshopItemMetaData = _publishedItemDetailsUpdateMetaData[num];
							string directoryName = Path.GetDirectoryName(_publishedItemDetailsUpdateMetaDataFileSpecs[num]);
							if (item.PublishedFileId.ToString() == workshopItemMetaData.PublishedFileId && item.DoesExternallyModifiableDataDiffer(workshopItemMetaData.Title, workshopItemMetaData.Description, workshopItemMetaData.Visibility))
							{
								workshopItemMetaData.Title = item.Title;
								workshopItemMetaData.Description = item.Description;
								workshopItemMetaData.Visibility = item.Visibility;
								if (workshopItemMetaData.WriteToMetaDataFile(directoryName))
								{
									numItemsUpdated++;
								}
								else
								{
									numItemUpdateErrors++;
								}
							}
						}
					}
				}
			}
			ExtContentMessages.LogDebug(string.Format(ExtContentUtils.HiliteParams("Finished Published Item Details Update Query. {0} items checked, {1} items updated, {2} item errors"), (int)numSubscribedToItems, numItemsUpdated, numItemUpdateErrors));
			WorkshopUtils.OnFinishedItemsQuery((int)numSubscribedToItems);
			_publishedItemDetailsUpdateInProgress = false;
			_queryItemsCoroutine = null;
			WorkshopUtils.ResetLastSteamResult();
		}

		private bool CopyGameItemLocalSourceParamsDBData(GameItemBase gameItem, string prevContentID)
		{
			bool result = false;
			if (gameItem != null)
			{
				foreach (KeyValuePair<string, Dictionary<string, string>> item in _localModsSourceParamsDatabase.Database)
				{
					string key = item.Key;
					if (!(GameItemUtils.GetGameItemInstalledFolderGUID(EContentSourceType.LocalMods, key) == prevContentID))
					{
						continue;
					}
					Dictionary<string, string> retItemSourceParamsDictionary = null;
					if (!_localModsSourceParamsDatabase.Get(key, ref retItemSourceParamsDictionary))
					{
						continue;
					}
					Dictionary<string, string> retItemSourceParamsDictionary2 = null;
					if (!_localModsSourceParamsDatabase.Get(gameItem.InstalledFolderPathSpec, ref retItemSourceParamsDictionary2))
					{
						continue;
					}
					result = true;
					foreach (KeyValuePair<string, string> item2 in retItemSourceParamsDictionary)
					{
						retItemSourceParamsDictionary2.Add(item2.Key, item2.Value);
					}
					break;
				}
			}
			return result;
		}

		public override string GetGameItemSourceSpecificLogInfoString(GameItemBase gameItem)
		{
			return _workshopContentCreationManager.GetGameItemPublishedLogInfoString(gameItem, GetLocalModsFolderSpec() + "/");
		}
	}
}
