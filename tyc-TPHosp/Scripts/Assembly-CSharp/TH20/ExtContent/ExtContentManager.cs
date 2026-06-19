using System;
using System.Collections.Generic;
using FullInspector;
using JetBrains.Annotations;
using TH20.Analytics;
using UnityEngine;

namespace TH20.ExtContent
{
	[DontSave]
	public class ExtContentManager : MustCallDestroy
	{
		[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
		public class ExtContentManagerConfig
		{
			public bool bEnabled = true;

			public SharedInstance<ExtContentConfig> ExtContentConfig;

			public SharedInstance<WorkshopContentCreationManager.WorkshopContentCreationConfig> WorkshopContentCreationManagerConfig;

			public SharedInstance<ExtContentSourceWorkshop.WorkshopConfig> ExtContentSourceWorkshopConfig;

			public SharedInstance<ExtContentSourceLocalMods.LocalModsConfig> ExtContentSourceLocalModsConfig;

			public SharedInstance<ExtContentManagerDebug.ExtContentDebugConfig> ExtContentManagerDebugConfig;

			public SharedInstance<ExtContentUIManager.ExtContentUIManagerConfig> ExtContentUIManagerConfig;

			public SharedInstance<ExtContentTextureUtils.ExtContentTexturesConfig> ExtContentTexturesConfig;
		}

		private readonly ExtContentManagerConfig _config;

		private readonly MessageBox _messageBox;

		private readonly MonoBehaviour _behaviourToRunCoroutinesOn;

		private App _app;

		private WorkshopContentCreationManager _workshopContentCreationManager;

		private ExtContentSourceWorkshop _contentSourceWorkshop;

		private ExtContentSourceLocalMods _contentSourceLocalMods;

		private ExtContentManagerDebug _extContentManagerDebug;

		private ExtContentUIManager _extContentUIManager;

		private AnalyticsManager _analyticsManager;

		public App App => _app;

		public ExtContentManagerConfig Config => _config;

		public WorkshopContentCreationManager WorkshopContentCreationManager => _workshopContentCreationManager;

		public ExtContentSourceWorkshop ContentSourceWorkshop => _contentSourceWorkshop;

		public ExtContentSourceLocalMods ContentSourceLocalMods => _contentSourceLocalMods;

		public ExtContentManagerDebug ExtContentManagerDebug => _extContentManagerDebug;

		public ExtContentUIManager ExtContentUIManager => _extContentUIManager;

		public AnalyticsManager AnalyticsManager => _analyticsManager;

		public MonoBehaviour BehaviourToRunCoroutinesOn => _behaviourToRunCoroutinesOn;

		public ExtContentManager(App app, ExtContentManagerConfig config, MonoBehaviour behaviourToRunCoroutinesOn, Transform uiParentTransform, AnalyticsManager analyticsManager, InputManager inputManager, MessageBox messageBox)
		{
			ExtContentUtils.ExtContentManager = this;
			_app = app;
			_config = config;
			_messageBox = messageBox;
			_behaviourToRunCoroutinesOn = behaviourToRunCoroutinesOn;
			_analyticsManager = analyticsManager;
			_workshopContentCreationManager = new WorkshopContentCreationManager(_config.WorkshopContentCreationManagerConfig.Instance);
			_contentSourceWorkshop = new ExtContentSourceWorkshop(_config.ExtContentSourceWorkshopConfig.Instance);
			_contentSourceLocalMods = new ExtContentSourceLocalMods(_config.ExtContentSourceLocalModsConfig.Instance);
			_extContentManagerDebug = new ExtContentManagerDebug(_config.ExtContentManagerDebugConfig.Instance);
			_extContentUIManager = new ExtContentUIManager(_config.ExtContentUIManagerConfig.Instance);
			_workshopContentCreationManager.Init(this);
			_contentSourceWorkshop.Init(this);
			_contentSourceLocalMods.Init(this);
			_extContentManagerDebug.Init(this, inputManager);
			_extContentUIManager.Init(this, inputManager, uiParentTransform);
			_contentSourceLocalMods.OnGameItemCreated += OnLocalModGameItemCreated;
			_contentSourceWorkshop.OnGameItemCreated += OnWorkshopGameItemCreated;
			_contentSourceLocalMods.OnGameItemUpdated += OnLocalModGameItemUpdated;
			_contentSourceWorkshop.OnGameItemUpdated += OnWorkshopGameItemUpdated;
			_contentSourceWorkshop.OnWorkshopInstalledItemCreated += OnWorkshopInstalledItemCreated;
			_contentSourceWorkshop.OnWorkshopInstalledItemUpdated += OnWorkshopInstalledItemUpdated;
			App app2 = _app;
			app2.OnLevelLoaded = (Action<Level, bool>)Delegate.Combine(app2.OnLevelLoaded, new Action<Level, bool>(OnLevelLoaded));
			ExtContentMessages.SetMessageBox(_messageBox);
		}

		public override void Destroy()
		{
			_contentSourceLocalMods.OnGameItemCreated -= OnLocalModGameItemCreated;
			_contentSourceWorkshop.OnGameItemCreated -= OnWorkshopGameItemCreated;
			_contentSourceLocalMods.OnGameItemUpdated -= OnLocalModGameItemUpdated;
			_contentSourceWorkshop.OnGameItemUpdated -= OnWorkshopGameItemUpdated;
			_contentSourceWorkshop.OnWorkshopInstalledItemCreated -= OnWorkshopInstalledItemCreated;
			_contentSourceWorkshop.OnWorkshopInstalledItemUpdated -= OnWorkshopInstalledItemUpdated;
			App app = _app;
			app.OnLevelLoaded = (Action<Level, bool>)Delegate.Remove(app.OnLevelLoaded, new Action<Level, bool>(OnLevelLoaded));
			_contentSourceWorkshop.DeInit();
			_contentSourceWorkshop = null;
			_contentSourceLocalMods.DeInit();
			_contentSourceLocalMods = null;
			_workshopContentCreationManager.DeInit();
			_workshopContentCreationManager = null;
			_extContentManagerDebug.DeInit();
			_extContentManagerDebug = null;
			_extContentUIManager.DeInit();
			_extContentUIManager = null;
			base.Destroy();
			ExtContentUtils.ExtContentManager = null;
		}

		public void Update()
		{
			_contentSourceWorkshop.Update();
			_contentSourceLocalMods.Update();
			_workshopContentCreationManager.Update();
			_extContentManagerDebug.Update();
			_extContentUIManager.Update();
		}

		public List<GameItemBase> GetAllGameItems(EContentType contentType = EContentType.None)
		{
			List<GameItemBase> list = new List<GameItemBase>();
			list.AddRange(_contentSourceWorkshop.GetAllGameItems(contentType));
			list.AddRange(_contentSourceLocalMods.GetAllGameItems(contentType));
			return list;
		}

		public List<GameItemBase> GetAllGameItemsSorted(EContentType contentType = EContentType.None)
		{
			List<GameItemBase> allGameItems = GetAllGameItems(contentType);
			GameItemUtils.SortMostRecent(allGameItems);
			return allGameItems;
		}

		public List<GameItemBase> GetAllGameItems(List<EContentType> contentTypes)
		{
			List<GameItemBase> list = new List<GameItemBase>();
			foreach (EContentType contentType in contentTypes)
			{
				list.AddRange(GetAllGameItems(contentType));
			}
			return list;
		}

		public List<GameItemBase> GetAllGameItemsSorted(List<EContentType> contentTypes)
		{
			List<GameItemBase> allGameItems = GetAllGameItems(contentTypes);
			GameItemUtils.SortMostRecent(allGameItems);
			return allGameItems;
		}

		public GameItemBase FindGameItemByContentID(string contentID)
		{
			GameItemBase result = null;
			switch (ExtContentSourceType.GetContentSourceTypeFromPrefix(contentID))
			{
			case EContentSourceType.Workshop:
				result = _contentSourceWorkshop.FindGameItemByID(contentID, bSilent: true);
				break;
			case EContentSourceType.LocalMods:
				result = _contentSourceLocalMods.FindGameItemByID(contentID, bSilent: true);
				break;
			}
			return result;
		}

		public GameItemCreditsScreen GetMostRecentCreditsScreenGameItem()
		{
			return GetMostRecentGameItem(EContentType.CreditsScreen) as GameItemCreditsScreen;
		}

		public GameObject GetCreditsScreenPrefabOverride(GameItemCreditsScreen gameItemCreditsScreen, GameObject existingCreditsScreenPrefab)
		{
			GameObject result = existingCreditsScreenPrefab;
			if (gameItemCreditsScreen != null)
			{
				GameItemDataBase gameItemDataBase = gameItemCreditsScreen.GetGameItemDataBase();
				if (gameItemDataBase != null)
				{
					result = gameItemDataBase.GetRootAssetGameObject();
				}
			}
			return result;
		}

		public GameItemBase GetMostRecentGameItem(EContentType contentType)
		{
			GameItemBase result = null;
			List<GameItemBase> allGameItemsSorted = GetAllGameItemsSorted(contentType);
			if (allGameItemsSorted.Count > 0)
			{
				result = allGameItemsSorted[0];
			}
			return result;
		}

		public bool IsCurrentlyUsingOnlineServices()
		{
			if (!_contentSourceLocalMods.IsCurrentlyUsingOnlineServices() && !_contentSourceWorkshop.IsCurrentlyUsingOnlineServices())
			{
				return _workshopContentCreationManager.IsCurrentlyUsingOnlineServices();
			}
			return true;
		}

		public bool PublishSandboxSave(string sandboxSaveFolderSpec, List<string> sandboxSaveFilenames, string sandboxSaveDisplayName, Texture2D texture2DThumbnail)
		{
			bool result = false;
			GameItemSandboxSave gameItemSandboxSave = _contentSourceLocalMods.CreateOrUpdateItemSandboxSave(sandboxSaveFolderSpec, sandboxSaveFilenames, sandboxSaveDisplayName, texture2DThumbnail);
			if (gameItemSandboxSave != null)
			{
				result = true;
				_extContentUIManager.WorkshopPublishUIScreen.Configure(gameItemSandboxSave);
				_extContentUIManager.WorkshopPublishUIScreen.Show();
			}
			return result;
		}

		private void LogGameItemCallbackRecievedMessage(string callbackFnName, string gameItemTypeStr, GameItemBase gameItemBase)
		{
			ExtContentMessages.LogDebug(string.Format(ExtContentUtils.HiliteParams("Received {0} callback for {1} game item of type '{2}' : '{3}'"), callbackFnName, gameItemTypeStr, ExtContentType.ContentTypeToString(gameItemBase.ContentType), gameItemBase.GetLogInfoStringWithPath()));
		}

		private void LogInstalledItemCallbackRecievedMessage(string callbackFnName, WorkshopInstalledItem workshopInstalledItem)
		{
			ExtContentMessages.LogDebug(string.Format(ExtContentUtils.HiliteParams("Received {0} callback for workshop installed item of type '{1}' : '{2}' - '{3}'"), callbackFnName, workshopInstalledItem.ContentTypeString, workshopInstalledItem.Title, workshopInstalledItem.ItemDetail.InstalledFolderPathSpec));
		}

		private void OnLocalModGameItemCreated(GameItemBase gameItemBase)
		{
			LogGameItemCallbackRecievedMessage("OnLocalModGameItemCreated", "local mod", gameItemBase);
		}

		private void OnLocalModGameItemUpdated(GameItemBase gameItemBase)
		{
			LogGameItemCallbackRecievedMessage("OnLocalModGameItemUpdated", "local mod", gameItemBase);
		}

		private void OnWorkshopGameItemCreated(GameItemBase gameItemBase)
		{
			LogGameItemCallbackRecievedMessage("OnWorkshopGameItemCreated", "workshop", gameItemBase);
		}

		private void OnWorkshopGameItemUpdated(GameItemBase gameItemBase)
		{
			LogGameItemCallbackRecievedMessage("OnWorkshopGameItemUpdated", "workshop", gameItemBase);
		}

		private void OnWorkshopInstalledItemCreated(WorkshopInstalledItem workshopInstalledItem)
		{
			LogInstalledItemCallbackRecievedMessage("OnWorkshopInstalledItemCreated", workshopInstalledItem);
		}

		private void OnWorkshopInstalledItemUpdated(WorkshopInstalledItem workshopInstalledItem)
		{
			LogInstalledItemCallbackRecievedMessage("OnWorkshopInstalledItemUpdated", workshopInstalledItem);
		}

		private void OnLevelLoaded(Level level, bool loadedFromSave)
		{
			ExtContentMessages.LogDebug($"Received OnLevelLoaded callback");
			List<GameItemBase> gameItems = GetAllGameItems();
			foreach (GameItemBase item in gameItems)
			{
				item.GetGameItemDataBase()?.OnLevelLoaded();
			}
			level.FloorVisualOverrideDefinitionUGCs.RemoveAll((FloorVisualOverrideDefinitionUGC x) => !gameItems.Exists((GameItemBase gameItem) => x.ContentID == gameItem.ContentID));
			level.WallVisualOverrideDefinitionUGCs.RemoveAll((WallVisualOverrideDefinitionUGC x) => !gameItems.Exists((GameItemBase gameItem) => x.ContentID == gameItem.ContentID));
			level.WorldState.AvailableRoomItems.RemoveAll((IRoomItemDefinition x) => x is RoomItemDefinitionUGC && !gameItems.Exists((GameItemBase gameItem) => ((RoomItemDefinitionUGC)x).ContentID == gameItem.ContentID));
		}
	}
}
