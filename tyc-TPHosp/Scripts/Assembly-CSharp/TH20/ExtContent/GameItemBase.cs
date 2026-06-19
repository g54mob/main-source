namespace TH20.ExtContent
{
	public class GameItemBase
	{
		public class GameItemBaseConfig
		{
			public string _itemConfigTag;

			public string _itemAnalyticsName;

			public LocalisedString _itemDisplayName;
		}

		public const string cKey_Title = "Title";

		public const string cKey_Description = "Description";

		public const string cKey_ContentID = "ContentID";

		public const string cKey_DisplayName = "DisplayName";

		public const string cKey_ContentType = "ContentType";

		public const string cKey_LastUpdatedTimeStamp = "LastUpdatedTimeStamp";

		private string _title;

		private string _description;

		private string _contentID;

		private string _displayName;

		private EContentType _contentType;

		private EContentSourceType _contentSource;

		private string _installedFolderPathSpec;

		private uint _installedFolderPathSpecHash;

		private long _lastUpdatedTimeStamp;

		private GameItemMetaData _gameItemMetaData;

		private bool _bOnDataUpdatedPending;

		private WorkshopItemMetaData _publishedWorkshopMeteData;

		public string Title
		{
			get
			{
				return _title;
			}
			set
			{
				_title = value;
			}
		}

		public string Description
		{
			get
			{
				return _description;
			}
			set
			{
				_description = value;
			}
		}

		public string ContentID => _contentID;

		public string DisplayName
		{
			get
			{
				return GetDisplayNameInternal();
			}
			set
			{
				_displayName = value;
			}
		}

		public EContentType ContentType => _contentType;

		public EContentSourceType ContentSource => _contentSource;

		public string InstalledFolderPathSpec => _installedFolderPathSpec;

		public uint InstalledFolderPathSpecHash => _installedFolderPathSpecHash;

		public long LastUpdatedTimeStamp
		{
			get
			{
				return _lastUpdatedTimeStamp;
			}
			set
			{
				_lastUpdatedTimeStamp = value;
			}
		}

		public GameItemMetaData GameItemMetaData => _gameItemMetaData;

		public WorkshopItemMetaData PublishedWorkshopMetaData
		{
			get
			{
				return _publishedWorkshopMeteData;
			}
			set
			{
				_publishedWorkshopMeteData = value;
			}
		}

		public virtual void Init(EContentType contentType, EContentSourceType contentSource, string title, string description, string contentID, string installedFolderPathSpec)
		{
			_contentType = contentType;
			_contentSource = contentSource;
			_title = title;
			_description = description;
			_contentID = contentID;
			UpdateContentIDSourcePrefix();
			SetInstalledFolderPathSpec(installedFolderPathSpec);
			_gameItemMetaData = new GameItemMetaData(_installedFolderPathSpec);
		}

		public virtual void DeInit()
		{
		}

		private void SetInstalledFolderPathSpec(string installedFolderPathSpec)
		{
			_installedFolderPathSpec = installedFolderPathSpec;
			_installedFolderPathSpec = ExtContentUtils.NormalisePathSpec(_installedFolderPathSpec);
			_installedFolderPathSpecHash = ExtContentUtils.GetPathSpecHash2(_installedFolderPathSpec);
		}

		public void SetLastUpdateTimeToNow()
		{
			_lastUpdatedTimeStamp = ExtContentUtils.GetCurrentTimeStamp();
		}

		public virtual bool UpdateMetaDataFile(bool bSetLastUpdateTimeToNow = true)
		{
			if (bSetLastUpdateTimeToNow)
			{
				SetLastUpdateTimeToNow();
			}
			UpdateMetaData();
			return _gameItemMetaData.WriteMetaDataFile();
		}

		public virtual bool SetAndUpdateFromMetaData(GameItemMetaData metaData, bool bDeferDataUpdate)
		{
			_gameItemMetaData = metaData;
			bool num = UpdateFromMetaData();
			if (num)
			{
				SetOnDataUpdatedPending();
				if (!bDeferDataUpdate)
				{
					ProcessOnDataUpdatedPending();
				}
			}
			return num;
		}

		public void SetOnDataUpdatedPending()
		{
			_bOnDataUpdatedPending = true;
		}

		public void ProcessOnDataUpdatedPending()
		{
			if (_bOnDataUpdatedPending)
			{
				_bOnDataUpdatedPending = false;
				OnDataUpdated();
			}
		}

		public virtual void UpdateMetaData()
		{
			GameItemMetaData.Clear();
			GameItemMetaData.Add("Title", _title);
			GameItemMetaData.Add("Description", _description);
			GameItemMetaData.Add("ContentID", _contentID);
			GameItemMetaData.Add("ContentType", ExtContentType.ContentTypeToString(_contentType));
			GameItemMetaData.Add("LastUpdatedTimeStamp", $"{_lastUpdatedTimeStamp}");
			GameItemMetaData.Add("DisplayName", _displayName);
		}

		protected virtual bool UpdateFromMetaData()
		{
			bool result = GameItemMetaData.Get("Title", ref _title) && GameItemMetaData.Get("Description", ref _description) && GameItemMetaData.Get("ContentID", ref _contentID) && GameItemMetaData.Get("LastUpdatedTimeStamp", ref _lastUpdatedTimeStamp);
			GameItemMetaData.Get("DisplayName", ref _displayName);
			UpdateContentIDSourcePrefix();
			return result;
		}

		public bool IsWithinBundle()
		{
			bool result = false;
			if (_publishedWorkshopMeteData != null && _publishedWorkshopMeteData.ContentType == EContentType.Bundle)
			{
				result = true;
			}
			return result;
		}

		public bool GetBundleInfo(ref string bundleName, ref string bundlePublishedFileId)
		{
			bool result = false;
			bundleName = string.Empty;
			bundlePublishedFileId = string.Empty;
			if (IsWithinBundle())
			{
				result = true;
				bundleName = _publishedWorkshopMeteData.Title;
				bundlePublishedFileId = _publishedWorkshopMeteData.PublishedFileId;
			}
			return result;
		}

		public virtual bool ValidateReadyForDelete(bool bSilent = false)
		{
			return false;
		}

		public virtual bool ValidateReadyForPublish(bool bSilent = false)
		{
			return true;
		}

		public virtual void OnDataUpdated()
		{
		}

		private void UpdateContentIDSourcePrefix()
		{
			ExtContentSourceType.EnsureValidSourceTypePrefix(_contentSource, ref _contentID);
		}

		public virtual bool ValidateContentID()
		{
			bool result = false;
			UpdateContentIDSourcePrefix();
			string gameItemInstalledFolderGUID = GameItemUtils.GetGameItemInstalledFolderGUID(_contentSource, _installedFolderPathSpec);
			if (_contentID != gameItemInstalledFolderGUID)
			{
				string contentID = _contentID;
				_contentID = gameItemInstalledFolderGUID;
				GetGameItemDataBase()?.SetContentID(gameItemInstalledFolderGUID);
				UpdateMetaDataFile();
				result = true;
				ExtContentMessages.LogDebug(string.Format(ExtContentUtils.HiliteParams("Invalid Content ID for item '{0}' installed at '{1}' changed from '{2}' to '{3}'"), _title, _installedFolderPathSpec, contentID, _contentID));
			}
			return result;
		}

		public virtual string GetLogInfoString()
		{
			return string.Format(ExtContentUtils.HiliteParams("T:'{0}', CT:{1}, S:{2}, ID:{3}, Tm:{4}"), _title, ExtContentType.ContentTypeToString(_contentType), ExtContentSourceType.ContentSourceTypeToString(_contentSource), _contentID, ExtContentUtils.GetTimeStampDisplayString(_lastUpdatedTimeStamp));
		}

		public virtual string GetLogInfoStringInstalledPath()
		{
			return $"I:'{ExtContentUtils.Hilite(_installedFolderPathSpec)}'";
		}

		public virtual string GetLogInfoStringWithPath()
		{
			return GetLogInfoString() + ", " + GetLogInfoStringInstalledPath();
		}

		public virtual GameItemDataBase GetGameItemDataBase()
		{
			return null;
		}

		private string GetDisplayNameInternal()
		{
			if (_displayName.IsNullOrEmpty() || _displayName.Length <= 0)
			{
				return _title;
			}
			return _displayName;
		}
	}
}
