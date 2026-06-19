using System;
using System.Collections.Generic;
using Steamworks;

namespace TH20.ExtContent
{
	public class WorkshopItemDetail
	{
		private string _title;

		private string _description;

		private PublishedFileId_t _publishedFileId;

		private EContentType _contentType;

		private int _versionNumberOnline;

		private EItemVisibility _visibility;

		private Dictionary<string, string> _tags;

		private bool _installedInfoValid;

		private string _installedFolderPathSpec;

		private long _lastFolderUpdateTime;

		private long _sizeOnDisk;

		private bool _needsUpdate;

		private long _bytesDownloaded;

		private long _bytesToDownload;

		private WorkshopItemMetaData _itemMetaData;

		public string Title => _title;

		public string Description => _description;

		public PublishedFileId_t PublishedFileId => _publishedFileId;

		public EItemVisibility Visibility => _visibility;

		public Dictionary<string, string> Tags => _tags;

		public int VersionNumberOnline => _versionNumberOnline;

		public EContentType ContentType => _contentType;

		public string ContentTypeString => ExtContentType.ContentTypeToString(_contentType);

		public bool InstalledInfoValid => _installedInfoValid;

		public bool NeedsUpdate => _needsUpdate;

		public string InstalledFolderPathSpec => _installedFolderPathSpec;

		public long LastFolderUpdateTime => _lastFolderUpdateTime;

		public long SizeOnDisk => _sizeOnDisk;

		public long BytesDownloaded => _bytesDownloaded;

		public long BytesToDownload => _bytesToDownload;

		public WorkshopItemMetaData WorkshopMetaData => _itemMetaData;

		public WorkshopItemDetail(string title, string description, PublishedFileId_t publishedFileId, EItemVisibility visibility, Dictionary<string, string> tags)
		{
			_title = title;
			_description = description;
			_publishedFileId = publishedFileId;
			_visibility = visibility;
			_tags = tags;
			_itemMetaData = new WorkshopItemMetaData();
			_contentType = ExtContentType.StringToContentType(GetTagValue("ContentType"));
			_versionNumberOnline = 0;
			string tagValue = GetTagValue("AssetVersion");
			if (!tagValue.IsNullOrEmpty())
			{
				_versionNumberOnline = Convert.ToInt32(tagValue);
			}
		}

		public void SetInstalledInfo(string installedFolderPathSpec, long lastFolderUpdateTime, long sizeOnDisk)
		{
			_installedInfoValid = true;
			_installedFolderPathSpec = installedFolderPathSpec;
			_lastFolderUpdateTime = lastFolderUpdateTime;
			_sizeOnDisk = sizeOnDisk;
		}

		public void SetNeedsUpdateInfo(long bytesDownloaded, long bytesToDownload)
		{
			_needsUpdate = true;
			_bytesDownloaded = bytesDownloaded;
			_bytesToDownload = bytesToDownload;
		}

		public bool IsFullyInstalled()
		{
			if (WorkshopUtils.IsWorkshopItemInFullyInstalledState(_publishedFileId))
			{
				return DoOnlineAndOnDiskVersionNumbersMatch();
			}
			return false;
		}

		public bool DoesItemNeedUpdating()
		{
			if (!WorkshopUtils.IsWorkshopItemInNeedsUpdateState(_publishedFileId))
			{
				return !DoOnlineAndOnDiskVersionNumbersMatch();
			}
			return true;
		}

		public int GetVersionNumberOnDisk()
		{
			int result = 0;
			if (CheckReadInstalledItemMetaDataFile())
			{
				result = _itemMetaData.VersionNumberOnDisk;
			}
			return result;
		}

		public long GetGameItemUpdateTime()
		{
			long result = 0L;
			if (CheckReadInstalledItemMetaDataFile())
			{
				result = _itemMetaData.GameItemUpdateTime;
			}
			return result;
		}

		public bool DoesExternallyModifiableDataDiffer(WorkshopItemDetail otherItemDetail)
		{
			return DoesExternallyModifiableDataDiffer(otherItemDetail.Title, otherItemDetail.Description, otherItemDetail.Visibility);
		}

		public bool DoesExternallyModifiableDataDiffer(string otherTitle, string otherDescription, EItemVisibility otherVisibility)
		{
			if (!(Title != otherTitle) && !(Description != otherDescription))
			{
				return Visibility != otherVisibility;
			}
			return true;
		}

		public bool DoOnlineAndOnDiskVersionNumbersMatch()
		{
			bool result = false;
			if (CheckReadInstalledItemMetaDataFile())
			{
				result = _itemMetaData.VersionNumberOnDisk == _versionNumberOnline;
			}
			return result;
		}

		public bool CheckReadInstalledItemMetaDataFile()
		{
			if (_installedInfoValid && !_itemMetaData.IsValid())
			{
				_itemMetaData.ReadFromMetaDataFile(_installedFolderPathSpec);
			}
			return _itemMetaData.IsValid();
		}

		public int GetNextVersionNumberOnline()
		{
			return _versionNumberOnline + 1;
		}

		public string GetTagValue(string key)
		{
			return ExtContentUtils.GetTagValue(_tags, key);
		}

		public string GetLogInfoString()
		{
			string itemStateString = WorkshopUtils.GetItemStateString(WorkshopUtils.GetWorkshopItemState(_publishedFileId));
			string text = "---";
			string text2 = "---";
			if (_needsUpdate)
			{
				text = $"{_bytesDownloaded / 1024}KB";
				text2 = $"{_bytesToDownload / 1024}KB";
			}
			string text3 = "---";
			string text4 = "---";
			string text5 = "---";
			if (_installedInfoValid)
			{
				text3 = $"{_sizeOnDisk / 1024}KB";
				text4 = $"{_lastFolderUpdateTime}";
				string installedFolderPathSpec = _installedFolderPathSpec;
				string pathSpecToNamedFolder = ExtContentUtils.GetPathSpecToNamedFolder(installedFolderPathSpec, WorkshopUtils.GetAppIdStr());
				text5 = ExtContentUtils.MakePathSpecRelativeTo(installedFolderPathSpec, pathSpecToNamedFolder);
			}
			string text6 = $"v{_versionNumberOnline}";
			string text7 = string.Format("v{0}", CheckReadInstalledItemMetaDataFile() ? $"{_itemMetaData.VersionNumberOnDisk}" : "-");
			return string.Format(ExtContentUtils.HiliteParams("PFID:{0}, {1} (OL:{2}/OD:{3}), T:{4}, S:{5}, Tag:{6}, D/L:{7}/{8}, Inst: Sz:{9}, Tm:{10}, I:'{11}'"), PublishedFileId, _title, text6, text7, ContentTypeString, itemStateString, _tags.Count, text, text2, text3, text4, text5);
		}
	}
}
