using System;
using UnityEngine;

namespace TH20.ExtContent
{
	[DontSave]
	public class ExtContentUIManager
	{
		public class UIManagerPictureBaseConfig
		{
			public int ItemCostDefault;

			public int ItemCostMin;

			public int ItemCostMax;

			public int ItemKudoshDefault;

			public int ItemKudoshMin;

			public int ItemKudoshMax;
		}

		public class ExtContentUIManagerConfig
		{
			public GameObject GameItemUIScreenPrefab;

			public GameObject WorkshopPublishUIScreenPrefab;
		}

		public delegate void OnGameItemEditMenusRestoredCallback();

		public delegate void OnAllExtContentUIScreensClosedCallback();

		public const float cFireRebuildMenuDelegatesDelayTime = 0f;

		public const float cUpdateInputItemsPendingDelayTime = 0.33f;

		private ExtContentUIManagerConfig _config;

		private ExtContentManager _extContentManager;

		private ExtContentSourceLocalMods _contentSourceLocalMods;

		private WorkshopContentCreationManager _workshopContentCreationManager;

		private InputManager _inputManager;

		private Transform _uiParentTransform;

		private ExtContentGameItemUIScreen _gameItemUIScreen;

		private WorkshopPublishUIScreen _workshopPublishUIScreen;

		private bool _bFireRebuildRoomItemsMenuDelegatePending;

		private float _fireRebuildRoomItemsMenuDelegatePendingTimer;

		private float _updateInputItemsPendingTimer;

		private bool _bUpdateHUDItemsPending;

		private bool _bUpdateInputItemsPending;

		private bool _bSetUIScreenOpenPending;

		public ExtContentUIManagerConfig Config => _config;

		public ExtContentManager ExtContentManager => _extContentManager;

		public ExtContentGameItemUIScreen GameItemUIScreen => GetGameItemUIScreen();

		public WorkshopPublishUIScreen WorkshopPublishUIScreen => GetWorkshopPublishUIScreen();

		public event OnGameItemEditMenusRestoredCallback OnGameItemEditMenusRestored;

		public event OnAllExtContentUIScreensClosedCallback OnAllExtContentUIScreensClosed;

		public ExtContentUIManager(ExtContentUIManagerConfig config)
		{
			_config = config;
		}

		public void Init(ExtContentManager extContentManager, InputManager inputManager, Transform uiParentTransform)
		{
			_extContentManager = extContentManager;
			_uiParentTransform = uiParentTransform;
			_inputManager = inputManager;
			_contentSourceLocalMods = _extContentManager.ContentSourceLocalMods;
			_workshopContentCreationManager = _extContentManager.WorkshopContentCreationManager;
			App app = _extContentManager.App;
			app.OnLevelLoadStarting = (Action)Delegate.Combine(app.OnLevelLoadStarting, new Action(OnLevelLoadStarting));
			ExtContentMessages.LogDebug($"[#WINDOWMODE]: ExtContentUIManager.Init(): ScreenMode:'{Screen.fullScreenMode.ToString()}'");
		}

		public void DeInit()
		{
			App app = _extContentManager.App;
			app.OnLevelLoadStarting = (Action)Delegate.Remove(app.OnLevelLoadStarting, new Action(OnLevelLoadStarting));
			_gameItemUIScreen = null;
			_workshopPublishUIScreen = null;
		}

		public bool AreAnyUIScreensShown()
		{
			if (!GameItemUIScreen.IsShown)
			{
				return WorkshopPublishUIScreen.IsShown;
			}
			return true;
		}

		public void Update()
		{
			ProcessInputs();
			ProcessPendingHideScreenItems();
			ProcessFireRebuildRoomItemsMenuDelegatePending();
		}

		public void ProcessPendingHideScreenItems()
		{
			ProcessUpdateHUDItemsPending();
			ProcessUpdateInputItemsPending();
		}

		public void SetUIScreenOpenPending()
		{
			_bSetUIScreenOpenPending = true;
		}

		public void OnUIScreenShownStatusChange()
		{
			App app = ExtContentUtils.ExtContentManager.App;
			bool flag = AreAnyUIScreensShown();
			SetUpdateHUDItemsPending(flag);
			SetUpdateInputItemsPending(flag);
			if (app.Level != null && app.Level.HospitalHUDManager != null)
			{
				if (flag)
				{
					app.Level.HospitalHUDManager.SuspendAllMenus();
				}
				else
				{
					app.Level.HospitalHUDManager.ResumeSuspendedMenus();
					if (IsRoomItemsMenuActive())
					{
						SetFireRebuildRoomItemsMenuDelegatePending();
					}
				}
			}
			Transform transform = _uiParentTransform;
			if (flag)
			{
				HUD currentHUD = GetCurrentHUD();
				if (currentHUD != null)
				{
					transform = currentHUD.GetDrawOrderedMenuTransformForSlot(MenuBase.EDrawOrderSlot.Default);
				}
			}
			if (transform != null)
			{
				ExtContentGameItemUIScreen gameItemUIScreen = GetGameItemUIScreen();
				if (gameItemUIScreen.IsShown)
				{
					Transform transform2 = gameItemUIScreen.gameObject.transform;
					if (gameItemUIScreen.InvokingSiblingUITransform == null)
					{
						if (transform2.parent != transform)
						{
							transform2.SetParent(transform);
							transform2.SetAsLastSibling();
						}
					}
					else
					{
						transform2.SetParent(gameItemUIScreen.InvokingSiblingUITransform.parent);
						transform2.SetSiblingIndex(gameItemUIScreen.InvokingSiblingUITransform.GetSiblingIndex() + 1);
					}
				}
				WorkshopPublishUIScreen workshopPublishUIScreen = GetWorkshopPublishUIScreen();
				if (workshopPublishUIScreen.IsShown)
				{
					Transform transform2 = workshopPublishUIScreen.gameObject.transform;
					if (workshopPublishUIScreen.InvokingSiblingUITransform == null)
					{
						if (transform2.parent != transform)
						{
							transform2.SetParent(transform);
							transform2.SetAsLastSibling();
						}
					}
					else
					{
						transform2.SetParent(workshopPublishUIScreen.InvokingSiblingUITransform.parent);
						transform2.SetSiblingIndex(workshopPublishUIScreen.InvokingSiblingUITransform.GetSiblingIndex() + 1);
					}
				}
			}
			if (!flag && !_bSetUIScreenOpenPending && this.OnAllExtContentUIScreensClosed != null)
			{
				this.OnAllExtContentUIScreensClosed();
			}
			if (flag)
			{
				_bSetUIScreenOpenPending = false;
			}
		}

		private HUD GetCurrentHUD()
		{
			HUD result = null;
			App app = ExtContentUtils.ExtContentManager.App;
			if (app.Level != null && app.Level.HUD != null && !app.MetagameMap.IsVisible)
			{
				result = app.Level.HUD;
			}
			else if (app.MetagameMap != null && app.MetagameMap.HUD != null)
			{
				result = app.MetagameMap.HUD;
			}
			return result;
		}

		private void SetUpdateHUDItemsPending(bool bProcessImmediately = false)
		{
			_bUpdateHUDItemsPending = true;
			if (bProcessImmediately)
			{
				ProcessUpdateHUDItemsPending();
			}
		}

		private void ProcessUpdateHUDItemsPending()
		{
			if (_bUpdateHUDItemsPending)
			{
				_bUpdateHUDItemsPending = false;
				App app = ExtContentUtils.ExtContentManager.App;
				bool flag = AreAnyUIScreensShown();
				if (app.Level != null)
				{
					app.Level.GameTime.IsPausedByMenu = flag;
				}
				GetCurrentHUD()?.AmendExternalFullScreenMenuInstanceCount(flag ? 1 : (-1));
			}
		}

		private void SetUpdateInputItemsPending(bool bProcessImmediately = false)
		{
			if (!bProcessImmediately)
			{
				_bUpdateInputItemsPending = true;
				_updateInputItemsPendingTimer = 0.33f;
			}
			else
			{
				_bUpdateInputItemsPending = false;
				UpdateInputItems();
			}
		}

		private void ProcessUpdateInputItemsPending()
		{
			if (_bUpdateInputItemsPending)
			{
				_updateInputItemsPendingTimer -= Time.unscaledDeltaTime;
				if (_updateInputItemsPendingTimer <= 0f)
				{
					_bUpdateInputItemsPending = false;
					UpdateInputItems();
				}
			}
		}

		private void UpdateInputItems()
		{
			bool flag = AreAnyUIScreensShown();
			_inputManager.Enabled = !flag;
		}

		private RibbonMenu GetRibbonMenu()
		{
			RibbonMenu result = null;
			App app = ExtContentUtils.ExtContentManager.App;
			if (app.Level != null && app.Level.HUD != null)
			{
				result = app.Level.HUD.FindMenu<RibbonMenu>();
			}
			return result;
		}

		private RibbonMenuItemsState GetRibbonMenuItemsState()
		{
			RibbonMenuItemsState result = null;
			RibbonMenu ribbonMenu = GetRibbonMenu();
			if (ribbonMenu != null)
			{
				result = ribbonMenu.RibbonMenuItemsState;
			}
			return result;
		}

		private bool IsRoomItemsMenuActive()
		{
			bool result = false;
			RibbonMenu ribbonMenu = GetRibbonMenu();
			if (ribbonMenu != null && ribbonMenu.CurrentMode == RibbonMenu.Mode.Items)
			{
				result = true;
			}
			return result;
		}

		private void SetFireRebuildRoomItemsMenuDelegatePending(bool bSet = true)
		{
			_bFireRebuildRoomItemsMenuDelegatePending = bSet;
			_fireRebuildRoomItemsMenuDelegatePendingTimer = 0f;
		}

		private void ProcessFireRebuildRoomItemsMenuDelegatePending()
		{
			if (_bFireRebuildRoomItemsMenuDelegatePending)
			{
				bool flag = false;
				_fireRebuildRoomItemsMenuDelegatePendingTimer -= Time.unscaledDeltaTime;
				if (_fireRebuildRoomItemsMenuDelegatePendingTimer <= 0f)
				{
					flag = true;
				}
				if (flag)
				{
					GetRibbonMenuItemsState()?.OnGameItemEditMenusRestored();
					_bFireRebuildRoomItemsMenuDelegatePending = false;
				}
			}
		}

		private void FireRebuildMenusDelegates()
		{
			if (this.OnGameItemEditMenusRestored != null)
			{
				this.OnGameItemEditMenusRestored();
			}
		}

		private ExtContentGameItemUIScreen GetGameItemUIScreen()
		{
			if (_gameItemUIScreen == null)
			{
				_gameItemUIScreen = UnityEngine.Object.Instantiate(_config.GameItemUIScreenPrefab, _uiParentTransform, worldPositionStays: false).GetComponent<ExtContentGameItemUIScreen>();
				SetUIGameObjectBeforeMessageBox(_gameItemUIScreen.gameObject);
				_gameItemUIScreen.Setup(this, _uiParentTransform, _contentSourceLocalMods);
			}
			return _gameItemUIScreen;
		}

		private WorkshopPublishUIScreen GetWorkshopPublishUIScreen()
		{
			if (_workshopPublishUIScreen == null)
			{
				_workshopPublishUIScreen = UnityEngine.Object.Instantiate(_config.WorkshopPublishUIScreenPrefab, _uiParentTransform, worldPositionStays: false).GetComponent<WorkshopPublishUIScreen>();
				SetUIGameObjectBeforeMessageBox(_workshopPublishUIScreen.gameObject);
				_workshopPublishUIScreen.Setup(this, _uiParentTransform, _contentSourceLocalMods, _workshopContentCreationManager);
			}
			return _workshopPublishUIScreen;
		}

		private void SetUIGameObjectBeforeMessageBox(GameObject uiGameObject)
		{
			int i = 0;
			for (int childCount = _uiParentTransform.childCount; i < childCount; i++)
			{
				if (_uiParentTransform.GetChild(i).gameObject.GetComponent<MessageBox>() != null)
				{
					uiGameObject.transform.SetSiblingIndex(i);
					break;
				}
			}
		}

		private void OnLevelLoadStarting()
		{
			CloseAllUIScreens();
		}

		private void CloseAllUIScreens()
		{
			if (GameItemUIScreen.IsShown)
			{
				GameItemUIScreen.Hide();
			}
			if (WorkshopPublishUIScreen.IsShown)
			{
				WorkshopPublishUIScreen.Hide();
			}
		}

		private void ProcessInputs()
		{
		}
	}
}
