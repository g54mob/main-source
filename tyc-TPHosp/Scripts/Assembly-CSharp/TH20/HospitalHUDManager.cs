using System;
using System.Collections.Generic;
using TH20.ExtContent;
using TH20.UI;
using UnityConsole;
using UnityEngine;

namespace TH20
{
	public class HospitalHUDManager : MustCallDestroy, IGameEventsBase
	{
		private Level _level;

		private App _app;

		private MenuBase[] _suspendedMenus;

		private static readonly string Click_OpenSubMenu_AudioEvent = "Click:OpenSubMenu";

		private static readonly string Click_CloseSubMenu_AudioEvent = "Click:CloseSubMenu";

		public Action<RibbonMenu.Mode> OnRibbonMenuEnterMode;

		public Action OnRibbonMenuClose;

		public Action OnOverviewMenuOpen;

		public Action OnOverviewMenuClose;

		public List<StaffDefinition.Type> LastSelectedHireStaffType = new List<StaffDefinition.Type> { StaffDefinition.Type.Doctor };

		private readonly List<HospitalPlotFootprintVisual> _hospitalPlotFootprints;

		private readonly List<HospitalPlotFootprintVisual> _ambulanceBayFootprints;

		public static bool DEBUG_UseOldInspectorMenu;

		private bool _ribbonMenuShowGridForItems;

		private const float DebugTimeBetweenMenuCloses = 5f;

		private float _debugTimeUntilNextMenuClose = 5f;

		private HospitalPlot _selectedFootprint;

		private HospitalPlot _highlightedFootprint;

		public bool ShowingPauseMenu => _level.HUD.FindMenu<PauseMenu>() != null;

		public HospitalHUDManager(App app, Level level)
		{
			HospitalHUDManager hospitalHUDManager = this;
			_app = app;
			_level = level;
			_hospitalPlotFootprints = new List<HospitalPlotFootprintVisual>();
			_ambulanceBayFootprints = new List<HospitalPlotFootprintVisual>();
			GameEventsRegistry.RegisterLevelEvent(this);
			Level level2 = _level;
			level2.PostConstruct = (Action)Delegate.Combine(level2.PostConstruct, (Action)delegate
			{
				hospitalHUDManager._level.HUD.CreateMenu<HubMenu>().Setup(level);
				hospitalHUDManager._level.HUD.CreateMenu<TimeAndStatsMenu>().Setup(level, level.TimelineManager, level.GameTime);
				hospitalHUDManager._level.HUD.CreateMenu<GeneralNotificationMenu>().Setup(level, hospitalHUDManager._app, level.ObjectiveEvents, level.InputManager);
				hospitalHUDManager._level.HUD.CreateMenu<MessagesMenu>().Setup(level, hospitalHUDManager._app, level.Notifications, level.ObjectiveEvents, level.InputManager);
				hospitalHUDManager._level.HUD.CreateMenu<SlideInNotificationMenu>().Setup(level);
				hospitalHUDManager._level.HUD.CreateMenu<InboxMenu>().Initialise(level);
				hospitalHUDManager._level.HUD.CreateMenu<InspectorMenu>().Initialise(level);
				hospitalHUDManager._level.HUD.CreateMenu<StaffCustomisationMenu>().Initialise(hospitalHUDManager._level);
				hospitalHUDManager._level.HUD.CreateMenu<RoomCustomisationMenu>().Initialise(hospitalHUDManager._level);
				HUDEvents hUDEvents = hospitalHUDManager._level.HUDEvents;
				hUDEvents.OnMenuClose = (Action<MenuBase>)Delegate.Combine(hUDEvents.OnMenuClose, new Action<MenuBase>(hospitalHUDManager.OnHUDMenuClose));
				LevelStatsDatabase levelStatsDatabase = hospitalHUDManager._level.LevelStatsDatabase;
				levelStatsDatabase.OnYearCompleted = (Action<LevelStatsDatabase.YearStats>)Delegate.Combine(levelStatsDatabase.OnYearCompleted, new Action<LevelStatsDatabase.YearStats>(hospitalHUDManager.OnYearCompleted));
				BuildEvents buildEvents = hospitalHUDManager._level.BuildEvents;
				buildEvents.OnRoomEditRoomObjectsState = (Action<Room>)Delegate.Combine(buildEvents.OnRoomEditRoomObjectsState, new Action<Room>(hospitalHUDManager.OnRoomEditRoomObjectsState));
				BuildEvents buildEvents2 = hospitalHUDManager._level.BuildEvents;
				buildEvents2.OnBeginNewRoom = (Action<RoomDefinition>)Delegate.Combine(buildEvents2.OnBeginNewRoom, new Action<RoomDefinition>(hospitalHUDManager.OnBeginNewRoom));
				BuildEvents buildEvents3 = hospitalHUDManager._level.BuildEvents;
				buildEvents3.OnRoomDeleted = (Action<Room>)Delegate.Combine(buildEvents3.OnRoomDeleted, new Action<Room>(hospitalHUDManager.OnRoomDeleted));
				BuildEvents buildEvents4 = hospitalHUDManager._level.BuildEvents;
				buildEvents4.OnCancelRoom = (Action)Delegate.Combine(buildEvents4.OnCancelRoom, new Action(hospitalHUDManager.OnCancelRoom));
				BuildEvents buildEvents5 = hospitalHUDManager._level.BuildEvents;
				buildEvents5.OnEnterEditFloorPlanState = (Action<Room, BlueprintFloorPlan, BlueprintFloorPlanVisual>)Delegate.Combine(buildEvents5.OnEnterEditFloorPlanState, new Action<Room, BlueprintFloorPlan, BlueprintFloorPlanVisual>(hospitalHUDManager.OnEnterEditFloorPlanState));
				BuildEvents buildEvents6 = hospitalHUDManager._level.BuildEvents;
				buildEvents6.OnCursorHoverStart = (Action<ICursorSelectable>)Delegate.Combine(buildEvents6.OnCursorHoverStart, new Action<ICursorSelectable>(hospitalHUDManager.OnCursorHoverStart));
				BuildEvents buildEvents7 = hospitalHUDManager._level.BuildEvents;
				buildEvents7.OnCursorHoverStop = (Action<ICursorSelectable>)Delegate.Combine(buildEvents7.OnCursorHoverStop, new Action<ICursorSelectable>(hospitalHUDManager.OnCursorHoverStop));
				BuildEvents buildEvents8 = hospitalHUDManager._level.BuildEvents;
				buildEvents8.OnCursorSelectObject = (Action<ICursorSelectable>)Delegate.Combine(buildEvents8.OnCursorSelectObject, new Action<ICursorSelectable>(hospitalHUDManager.OnCursorSelectObject));
				Radio radio = hospitalHUDManager._level.Radio;
				radio.OnSongStarted = (Action<RadioSong>)Delegate.Combine(radio.OnSongStarted, new Action<RadioSong>(hospitalHUDManager.ShowRadioSong));
				HospitalPlotFootprintVisual.Config hospitalPlotFootprintConfig = hospitalHUDManager._level.Config.GetHospitalPlotFootprintConfig();
				foreach (HospitalPlot hospitalPlot in hospitalHUDManager._level.WorldState.HospitalPlots)
				{
					if (hospitalPlot.Definition.BuiltRoomDefinition != null && hospitalPlot.Definition.BuiltRoomDefinition.Instance.IsAmbulanceBayOnly)
					{
						hospitalHUDManager._ambulanceBayFootprints.Add(new HospitalPlotFootprintVisual(hospitalPlotFootprintConfig, hospitalPlot));
					}
					if (hospitalPlot.HospitalMap != null)
					{
						hospitalHUDManager._hospitalPlotFootprints.Add(new HospitalPlotFootprintVisual(hospitalPlotFootprintConfig, hospitalPlot));
					}
				}
			});
			ConsoleCommandsDatabase.RegisterCommand("ShowYearlyReviewMenu", "Show Yearly Review Menu", "Show Yearly Review Menu", Debug_ShowYearlyReviewMenu);
			ConsoleCommandsDatabase.RegisterCommand("ShowOverview", "Show Yearly Review Menu", "Show Yearly Review Menu", Debug_ShowOverview);
			ConsoleCommandsDatabase.RegisterCommand("ShowYearEnd", "Shows year end with yearly(true), or monthly(false) stats", "Show Year End Screen [false|true]", Debug_ShowOverview);
			ConsoleCommandsDatabase.RegisterCommand("ShowInboxMenu", "Show inbox menu", "ToggleOldInspectorMenu", Debug_ShowInboxMenu);
			ConsoleCommandsDatabase.RegisterCommand("ToggleOldInspectorMenu", "Toggles between Inspector Menu modes", "ToggleOldInspectorMenu", Debug_ToggleOldInspectorMenu);
			ConsoleCommandsDatabase.RegisterSimpleCommand("CloseAllFullScreenOrPauseTimeMenus", "Closes all open menus that either pause time or are full screen", Debug_CloseAllFullScreenOrPauseTimeMenus);
		}

		public void VerifyEvents()
		{
			OnRibbonMenuEnterMode.VerifyIsNull();
			OnRibbonMenuClose.VerifyIsNull();
			OnOverviewMenuOpen.VerifyIsNull();
			OnOverviewMenuClose.VerifyIsNull();
		}

		public void ToggleItemsList(RoomDefinition.Type roomType, FloorPlan floorPlan, bool playSFX)
		{
			if (!DestroyRibbonMenuIfInMode(RibbonMenu.Mode.Items))
			{
				ShowItemsList(roomType, floorPlan, playSFX: true);
			}
		}

		public void ToggleRoomsList()
		{
			if (DestroyRibbonMenuIfInMode(RibbonMenu.Mode.Rooms))
			{
				return;
			}
			TryQuitEditRoomPrompt(delegate
			{
				if (_level.BuildingLogic.CurrentState != BuildingLogic.State.Null)
				{
					_level.BuildingLogic.TransitionToNullState(applyChanges: false);
				}
				FindOrCreateRibbonMenu().TransitionIntoRoomsList();
				AudioManager.Instance.Play(Click_OpenSubMenu_AudioEvent);
			});
		}

		public void ToggleHireList()
		{
			if (!DestroyRibbonMenuIfInMode(RibbonMenu.Mode.Hire))
			{
				RibbonMenu ribbonMenu = FindOrCreateRibbonMenu();
				TryQuitEditRoomPrompt(delegate
				{
					ribbonMenu.TransitionIntoHireList();
					AudioManager.Instance.Play(Click_OpenSubMenu_AudioEvent);
				});
			}
		}

		public void ShowRadioSong(RadioSong song)
		{
			FindOrCreateSlideInNotificationMenu().QueueRadioSong(song);
		}

		private SlideInNotificationMenu FindOrCreateSlideInNotificationMenu()
		{
			SlideInNotificationMenu slideInNotificationMenu = _level.HUD.FindMenu<SlideInNotificationMenu>();
			if (slideInNotificationMenu == null)
			{
				PrepareCursorForMenus();
				HideAllInfoMenus();
				slideInNotificationMenu = _level.HUD.CreateMenu<SlideInNotificationMenu>();
				slideInNotificationMenu.Setup(_level);
			}
			return slideInNotificationMenu;
		}

		public void ShowItemsList(RoomDefinition.Type roomType, FloorPlan floorPlan, bool playSFX)
		{
			bool decorationOnly = !(floorPlan is BlueprintFloorPlan);
			FindOrCreateRibbonMenu().TransitionIntoItemsList(roomType, floorPlan, decorationOnly);
			if (playSFX)
			{
				AudioManager.Instance.Play(Click_OpenSubMenu_AudioEvent);
			}
		}

		private RibbonMenu FindOrCreateRibbonMenu()
		{
			RibbonMenu ribbonMenu = _level.HUD.FindMenu<RibbonMenu>();
			if (ribbonMenu == null)
			{
				PrepareCursorForMenus();
				HideAllInfoMenus();
				ribbonMenu = _level.HUD.CreateMenu<RibbonMenu>();
				RibbonMenu ribbonMenu2 = ribbonMenu;
				ribbonMenu2.OnEnterMode = (Action<RibbonMenu.Mode>)Delegate.Combine(ribbonMenu2.OnEnterMode, new Action<RibbonMenu.Mode>(OnRibbonMenuEnterMode.InvokeSafe<RibbonMenu.Mode>));
				ribbonMenu.Setup(_level);
				ribbonMenu.ShowGridForItems = _ribbonMenuShowGridForItems;
			}
			return ribbonMenu;
		}

		private bool DestroyRibbonMenuIfInMode(RibbonMenu.Mode mode)
		{
			RibbonMenu ribbonMenu = _level.HUD.FindMenu<RibbonMenu>();
			if (ribbonMenu != null && ribbonMenu.CurrentMode == mode)
			{
				return TryHideRibbonMenu();
			}
			return false;
		}

		public void HideItemsList()
		{
			DestroyRibbonMenuIfInMode(RibbonMenu.Mode.Items);
		}

		public bool TryShowBuildBar()
		{
			RibbonMenu ribbonMenu = _level.HUD.FindMenu<RibbonMenu>();
			if (ribbonMenu == null)
			{
				return false;
			}
			ribbonMenu.ExpandBuildBar();
			return true;
		}

		public void HideRoomsList()
		{
			DestroyRibbonMenuIfInMode(RibbonMenu.Mode.Rooms);
		}

		public void HideHireMenu()
		{
			DestroyRibbonMenuIfInMode(RibbonMenu.Mode.Hire);
		}

		public bool HideRibbonMenuBuildBar()
		{
			RibbonMenu ribbonMenu = _level.HUD.FindMenu<RibbonMenu>();
			if (ribbonMenu == null)
			{
				return false;
			}
			ribbonMenu.ShrinkBuildBar();
			return true;
		}

		public bool TryHideRibbonMenu()
		{
			RibbonMenu ribbonMenu = _level.HUD.FindMenu<RibbonMenu>();
			if (ribbonMenu == null)
			{
				return false;
			}
			return TryQuitEditRoomPrompt(delegate
			{
				HideRibbonMenuInternal(ribbonMenu);
			});
		}

		public void HideRibbonMenu()
		{
			RibbonMenu ribbonMenu = _level.HUD.FindMenu<RibbonMenu>();
			if (ribbonMenu != null)
			{
				HideRibbonMenuInternal(ribbonMenu);
			}
		}

		public void InitializeForRoomCopy(RoomDefinition.Type roomType, FloorPlan floorPlan, bool playSFX)
		{
			ShowItemsList(roomType, floorPlan, playSFX);
			TryShowBuildBar();
			RibbonMenu ribbonMenu = _level.HUD.FindMenu<RibbonMenu>();
			if (ribbonMenu != null)
			{
				ribbonMenu.InitializeForRoomCopy();
			}
		}

		private void HideRibbonMenuInternal(RibbonMenu ribbonMenu)
		{
			if (!ribbonMenu.IsClosed() && !ribbonMenu.IsClosing())
			{
				_ribbonMenuShowGridForItems = ribbonMenu.ShowGridForItems;
				ribbonMenu.CloseMenu();
				_level.CursorManager.PopMode<CursorRoomItem>();
				_level.CursorManager.PopMode<CursorRoomMove>();
				_level.CursorManager.PopMode<CursorRoomBuild>();
				if (_level.BuildingLogic.CurrentState == BuildingLogic.State.EditRoomBlueprint || _level.BuildingLogic.CurrentState == BuildingLogic.State.NewRoom)
				{
					_level.BuildingLogic.TransitionToNullState(applyChanges: false);
				}
				OnRibbonMenuClose.InvokeSafe();
			}
		}

		private void OnYearCompleted(LevelStatsDatabase.YearStats yearStats)
		{
			if (DebugVars.AllowYearlyReview.Value)
			{
				AdvisorMenu advisorMenu = _level.HUD.FindMenu<AdvisorMenu>();
				if (advisorMenu != null && advisorMenu.IsShowingMessage)
				{
					advisorMenu.HideAdvisorMessage();
					advisorMenu.OnAdvisorMessageFinished = (Action)Delegate.Remove(advisorMenu.OnAdvisorMessageFinished, new Action(ShowYearlyReviewMenu));
					advisorMenu.OnAdvisorMessageFinished = (Action)Delegate.Combine(advisorMenu.OnAdvisorMessageFinished, new Action(ShowYearlyReviewMenu));
				}
				else
				{
					ShowYearlyReviewMenu();
				}
			}
		}

		private void ShowYearlyReviewMenu()
		{
			AdvisorMenu advisorMenu = _level.HUD.FindMenu<AdvisorMenu>();
			if (advisorMenu != null)
			{
				advisorMenu.OnAdvisorMessageFinished = (Action)Delegate.Remove(advisorMenu.OnAdvisorMessageFinished, new Action(ShowYearlyReviewMenu));
			}
			_level.HUD.CreateMenu<ViewYearlyReviewMenu>().Setup(_level, delegate
			{
				TryQuitEditRoomPrompt(delegate
				{
					HideRibbonMenu();
					ShowOverviewMenu(play_SFX: false, yearEnd: true);
				});
			});
		}

		public T OpenInfoMenu<T>() where T : MenuBase
		{
			T val = _level.HUD.FindMenu<T>();
			if (val == null)
			{
				PrepareForCreatingLeftSideMenu();
				return _level.HUD.CreateMenu<T>();
			}
			return val;
		}

		public void ToggleInfoMenu<T>(Action<T> created) where T : MenuBase
		{
			T menu = _level.HUD.FindMenu<T>();
			if (menu == null)
			{
				return;
			}
			if (menu.IsClosing() || menu.IsClosed())
			{
				TryQuitEditRoomPrompt(delegate
				{
					PrepareForCreatingLeftSideMenu();
					menu.OpenMenu();
					AudioManager.Instance.Play(Click_OpenSubMenu_AudioEvent);
					created.InvokeSafe(menu);
				});
			}
			else
			{
				menu.CloseMenu();
				AudioManager.Instance.Play(Click_CloseSubMenu_AudioEvent);
				_level.DataViewManager.DisableOverlay(setByPlayer: true);
			}
		}

		private void HideInfoMenu<T>() where T : MenuBase
		{
			T val = _level.HUD.FindMenu<T>();
			if (!(val == null) && !val.IsClosing() && !val.IsClosed())
			{
				val.CloseMenu();
			}
		}

		private void PrepareCursorForMenus()
		{
			_level.CharacterEvents.OnStaffCancelPickup.InvokeSafe(param: false);
		}

		public void HideAllInfoMenus()
		{
			SlideInNotificationMenu slideInNotificationMenu = _level.HUD.FindMenu<SlideInNotificationMenu>();
			if (slideInNotificationMenu != null)
			{
				slideInNotificationMenu.HideNotifications();
			}
			HideInfoMenu<HospitalValueMenu>();
			HideInfoMenu<HospitalValueMenu>();
			HideInfoMenu<HospitalReputationMenu>();
			HideInfoMenu<StaffMenu>();
			HideInfoMenu<PatientsMenu2>();
			HideInfoMenu<IllnessesMenu2>();
			HideInfoMenu<LoanMenu>();
			HideInfoMenu<PricesMenu2>();
			HideInfoMenu<InboxMenu>();
			HideInfoMenu<StaffCustomisationMenu>();
			HideInfoMenu<RoomCustomisationMenu>();
		}

		private void PrepareForCreatingLeftSideMenu()
		{
			PrepareCursorForMenus();
			HideItemsList();
			HideRoomsList();
			HideHireMenu();
			HideAllInfoMenus();
		}

		private void CleanupMenusAfterBuilding()
		{
		}

		public void SuspendAllMenus()
		{
			_suspendedMenus = _level.HUD.FindAllMenus<MenuBase>(includeInactive: false);
			if (_suspendedMenus == null)
			{
				return;
			}
			MenuBase[] suspendedMenus = _suspendedMenus;
			foreach (MenuBase menuBase in suspendedMenus)
			{
				if (!(menuBase is InWorldMenuBase) && !menuBase.IsClosing() && !menuBase.IsClosed())
				{
					menuBase.SetVisible(visible: false);
				}
			}
		}

		public void ResumeSuspendedMenus()
		{
			if (_suspendedMenus == null)
			{
				return;
			}
			MenuBase[] suspendedMenus = _suspendedMenus;
			foreach (MenuBase menuBase in suspendedMenus)
			{
				if ((bool)menuBase && !(menuBase is InWorldMenuBase) && !menuBase.IsClosing() && !menuBase.IsClosed())
				{
					menuBase.SetVisible(visible: true);
				}
			}
			_suspendedMenus = null;
		}

		public void TryOpenMenu(Action responseDelegate)
		{
			TryQuitEditRoomPrompt(delegate
			{
				HideRibbonMenu();
				responseDelegate();
			});
		}

		private bool TryQuitEditRoomPrompt(Action responseDelegate)
		{
			NotificationMessages.Definition cancelDefinition = _level.Notifications.MessageDefinitions._cancelRoomMessage;
			if (!_level.Notifications.IsMessageTypePopupOpen(cancelDefinition))
			{
				if (_level.HUD.FindMenu<RibbonMenu>() != null)
				{
					bool num = _level.BuildingLogic.CurrentState == BuildingLogic.State.Null;
					bool flag = _level.BuildingLogic.CurrentState == BuildingLogic.State.EditRoomObjects;
					bool flag2 = false;
					if (_level.BuildingLogic.CurrentBlueprintFloorPlan != null)
					{
						flag2 = _level.BuildingLogic.CurrentBlueprintFloorPlan.HasAnyTiles();
					}
					if (!num && !flag && flag2)
					{
						List<RoomItem> invalidItems = new List<RoomItem>();
						NotificationMessages.Definition sellDefinition = _level.Notifications.MessageDefinitions._sellInvalidItemsMessage.Instance;
						_level.BuildingLogic.GetInvalidItemsOnRoomEditCancel(ref invalidItems);
						if (invalidItems.Count != 0)
						{
							int invalidItemsCost = 0;
							foreach (RoomItem item in invalidItems)
							{
								invalidItemsCost += item.SellValue();
							}
							RoomItemAlgorithms.ShowSellItems(invalidItems);
							NotificationDynamicMessage message = new NotificationDynamicMessage(cancelDefinition, delegate(int response)
							{
								if (response == 0)
								{
									foreach (RoomItem item2 in invalidItems)
									{
										if (item2.Cost != 0)
										{
											_level.BuildEvents.OnRoomItemSold.InvokeSafe(item2);
											_level.BuildEvents.OnRoomItemDestroy.InvokeSafe(item2);
										}
									}
									if (_level.BuildingLogic.CurrentState != BuildingLogic.State.Null)
									{
										_level.BuildingLogic.TransitionToNullState(applyChanges: false);
									}
									_level.CursorManager.PopMode<CursorRoomItem>();
									_level.CursorManager.PopMode<CursorRoomBuild>();
									responseDelegate();
								}
								else
								{
									RoomItemAlgorithms.HideSellItems(invalidItems);
								}
							}, _level)
							{
								FuncGetMessage = () => string.Concat(cancelDefinition.LocalisedText.Translation + "\n\n", LocalisedString.Replace(sellDefinition.LocalisedText.Translation, new SubPair[2]
								{
									new SubPair("{[COUNT]}", invalidItems.Count),
									new SubPair("{[COST]}", StringUtils.FormatCurrency(invalidItemsCost))
								}))
							};
							_level.Notifications.OpenPopup(message);
						}
						else
						{
							NotificationGenericDecision message2 = new NotificationGenericDecision(cancelDefinition, delegate(int response)
							{
								if (response == 0)
								{
									if (_level.BuildingLogic.CurrentState != BuildingLogic.State.Null)
									{
										_level.BuildingLogic.TransitionToNullState(applyChanges: false);
									}
									_level.CursorManager.PopMode<CursorRoomItem>();
									_level.CursorManager.PopMode<CursorRoomBuild>();
									responseDelegate();
								}
							}, _level);
							_level.Notifications.OpenPopup(message2);
						}
						return true;
					}
				}
				if (_level.BuildingLogic.CurrentState != BuildingLogic.State.Null)
				{
					_level.BuildingLogic.TransitionToNullState(applyChanges: false);
				}
				responseDelegate();
			}
			return false;
		}

		public void TogglePauseMenu()
		{
			Transform[] componentsInChildren = _level.HUD.MenusTransform.GetComponentsInChildren<Transform>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				_ = componentsInChildren[i];
			}
			if (!_level.HUD.AreAnyMenusPreventingOpenPauseMenu() && !_level.Notifications.IsMessageOpen && !_app.PreferencesScreen.isActiveAndEnabled)
			{
				PauseMenu pauseMenu = _level.HUD.FindMenu<PauseMenu>();
				if (pauseMenu == null)
				{
					pauseMenu = _level.HUD.CreateMenu<PauseMenu>();
					pauseMenu.Setup(_app, _level.GameTime, _level);
					pauseMenu.gameObject.transform.SetAsLastSibling();
				}
				else
				{
					pauseMenu.CloseMenu();
				}
			}
		}

		public void CloseAllMenusAllowingEscapeClose()
		{
			_level.HUD.CloseAllMenusAllowingEscapeClose();
		}

		private OverviewMenu FindOrCreateOverviewMenu(bool yearEnd)
		{
			OverviewMenu overviewMenu = _level.HUD.FindMenu<OverviewMenu>();
			if (overviewMenu == null)
			{
				PrepareCursorForMenus();
				HideAllInfoMenus();
				SuspendAllMenus();
				overviewMenu = _level.HUD.CreateMenu<OverviewMenu>();
				overviewMenu.Setup(_level, yearEnd);
			}
			return overviewMenu;
		}

		public void ShowOverviewMenu(bool play_SFX, bool yearEnd)
		{
			FindOrCreateOverviewMenu(yearEnd).HushLittleCompilerDontYouCry();
			OnOverviewMenuOpen.InvokeSafe();
			if (play_SFX)
			{
				AudioManager.Instance.Play(Click_OpenSubMenu_AudioEvent);
			}
		}

		public bool HideOverviewMenu()
		{
			OverviewMenu overviewMenu = _level.HUD.FindMenu<OverviewMenu>();
			if (overviewMenu == null)
			{
				return false;
			}
			HideOverviewMenuInternal(overviewMenu);
			ResumeSuspendedMenus();
			return true;
		}

		private void HideOverviewMenuInternal(OverviewMenu overview_menu)
		{
			overview_menu.CloseMenu();
			OnOverviewMenuClose.InvokeSafe();
		}

		public void Update()
		{
			if (_level.InputManager.GetButtonDown(9))
			{
				TryHideRibbonMenu();
			}
			if (DebugVars.PeriodicallyCloseAllFullScreenOrPauseTimeMenus.Value)
			{
				_debugTimeUntilNextMenuClose -= Time.unscaledDeltaTime;
				if (_debugTimeUntilNextMenuClose <= 0f)
				{
					_debugTimeUntilNextMenuClose = 5f;
					Debug_CloseAllFullScreenOrPauseTimeMenus();
				}
			}
			UpdateFootprints();
			if (!ShowingPauseMenu)
			{
				UpdateKeyboardShortcuts();
			}
			else
			{
				ExtContentUtils.CheckShowGameItemDevInfoPanelInput();
			}
		}

		private void UpdateFootprints()
		{
			HospitalPlot selectedPlot = ((_selectedFootprint != null) ? _selectedFootprint : _highlightedFootprint);
			if (_highlightedFootprint?.Definition.BuiltRoomDefinition == null || !_highlightedFootprint.Definition.BuiltRoomDefinition.Instance.IsAmbulanceBayOnly)
			{
				foreach (HospitalPlotFootprintVisual hospitalPlotFootprint in _hospitalPlotFootprints)
				{
					hospitalPlotFootprint.Update(selectedPlot, highlightingAmbulanceBay: false);
				}
			}
			foreach (HospitalPlotFootprintVisual ambulanceBayFootprint in _ambulanceBayFootprints)
			{
				ambulanceBayFootprint.Update(selectedPlot, highlightingAmbulanceBay: true);
			}
		}

		private void UpdateKeyboardShortcuts()
		{
			OverviewMenu overviewMenu = _level.HUD.FindMenu<OverviewMenu>();
			if (overviewMenu != null && !overviewMenu.IsClosed())
			{
				OverviewMenu.Mode currentMode = overviewMenu.CurrentMode;
				if (_level.InputManager.GetButtonDown(57))
				{
					if (currentMode == OverviewMenu.Mode.Finance)
					{
						overviewMenu.CloseMenu();
					}
					else
					{
						overviewMenu.PressTabButton(OverviewMenu.Mode.Finance);
					}
				}
				if (_level.InputManager.GetButtonDown(59))
				{
					if (currentMode == OverviewMenu.Mode.Staff)
					{
						overviewMenu.CloseMenu();
					}
					else
					{
						overviewMenu.PressTabButton(OverviewMenu.Mode.Staff);
					}
				}
				if (_level.InputManager.GetButtonDown(60))
				{
					if (currentMode == OverviewMenu.Mode.Patients)
					{
						overviewMenu.CloseMenu();
					}
					else
					{
						overviewMenu.PressTabButton(OverviewMenu.Mode.Patients);
					}
				}
				return;
			}
			HubMenu hubMenu = _level.HUD.FindMenu<HubMenu>();
			if (_level.InputManager.GetButtonDown(55))
			{
				StaffMenu staffMenu = _level.HUD.FindMenu<StaffMenu>();
				if (staffMenu == null || staffMenu.IsClosed() || staffMenu.IsClosing())
				{
					hubMenu.PressStaffButton();
				}
				else
				{
					int num = (int)(staffMenu.ViewMode + 1);
					if (num > 3)
					{
						staffMenu.CloseMenu();
					}
					else
					{
						staffMenu.SetViewMode((StaffMenu.ViewModes)num);
					}
				}
			}
			if (_level.InputManager.GetButtonDown(56))
			{
				hubMenu.PressPatientButton();
			}
			if (_level.InputManager.GetButtonDown(58))
			{
				hubMenu.PressIllnessButton();
			}
			if (_level.InputManager.GetButtonDown(57))
			{
				hubMenu.PressOverviewButton();
				FindOrCreateOverviewMenu(yearEnd: false).PressTabButton(OverviewMenu.Mode.Finance);
			}
			if (_level.InputManager.GetButtonDown(60))
			{
				hubMenu.PressOverviewButton();
				FindOrCreateOverviewMenu(yearEnd: false).PressTabButton(OverviewMenu.Mode.Patients);
			}
			if (_level.InputManager.GetButtonDown(59))
			{
				hubMenu.PressOverviewButton();
				FindOrCreateOverviewMenu(yearEnd: false).PressTabButton(OverviewMenu.Mode.Staff);
			}
			if (_level.InputManager.GetButtonDown(61))
			{
				_level.DataViewManager.ToggleMode(DataViewManager.Mode.HospitalAttractiveness, setByPlayer: true);
			}
			if (_level.InputManager.GetButtonDown(65))
			{
				_level.DataViewManager.ToggleMode(DataViewManager.Mode.HospitalTemperature, setByPlayer: true);
			}
			if (_level.InputManager.GetButtonDown(64))
			{
				_level.DataViewManager.ToggleMode(DataViewManager.Mode.HospitalHygiene, setByPlayer: true);
			}
			if (_level.InputManager.GetButtonDown(63))
			{
				_level.DataViewManager.ToggleMode(DataViewManager.Mode.PatientHealth, setByPlayer: true);
			}
			if (_level.InputManager.GetButtonDown(62))
			{
				_level.DataViewManager.ToggleMode(DataViewManager.Mode.PatientHappiness, setByPlayer: true);
			}
			if (_level.InputManager.GetButtonDown(66))
			{
				_level.DataViewManager.ToggleMode(DataViewManager.Mode.StaffHappiness, setByPlayer: true);
			}
			if (_level.InputManager.GetButtonDown(68))
			{
				_level.DataViewManager.ToggleMode(DataViewManager.Mode.CharacterThirst, setByPlayer: true);
			}
			if (_level.InputManager.GetButtonDown(69))
			{
				_level.DataViewManager.ToggleMode(DataViewManager.Mode.CharacterHunger, setByPlayer: true);
			}
			if (_level.InputManager.GetButtonDown(70))
			{
				_level.DataViewManager.ToggleMode(DataViewManager.Mode.StaffEnergy, setByPlayer: true);
			}
			if (_level.InputManager.GetButtonDown(71))
			{
				_level.DataViewManager.ToggleMode(DataViewManager.Mode.CharacterToilet, setByPlayer: true);
			}
			if (_level.InputManager.GetButtonDown(72))
			{
				_level.DataViewManager.ToggleMode(DataViewManager.Mode.CharacterBoredom, setByPlayer: true);
			}
			if (_level.InputManager.GetButtonDown(73))
			{
				_level.DataViewManager.ToggleMode(DataViewManager.Mode.ObjectMaintenance, setByPlayer: true);
			}
		}

		public override void Destroy()
		{
			_level.HUD.DestroyMenu<InspectorMenu>();
			_level.HUD.DestroyMenu<InboxMenu>();
			AdvisorMenu advisorMenu = _level.HUD.FindMenu<AdvisorMenu>();
			if (advisorMenu != null)
			{
				advisorMenu.OnAdvisorMessageFinished = (Action)Delegate.Remove(advisorMenu.OnAdvisorMessageFinished, new Action(ShowYearlyReviewMenu));
			}
			Radio radio = _level.Radio;
			radio.OnSongStarted = (Action<RadioSong>)Delegate.Remove(radio.OnSongStarted, new Action<RadioSong>(ShowRadioSong));
			LevelStatsDatabase levelStatsDatabase = _level.LevelStatsDatabase;
			levelStatsDatabase.OnYearCompleted = (Action<LevelStatsDatabase.YearStats>)Delegate.Remove(levelStatsDatabase.OnYearCompleted, new Action<LevelStatsDatabase.YearStats>(OnYearCompleted));
			BuildEvents buildEvents = _level.BuildEvents;
			buildEvents.OnRoomEditRoomObjectsState = (Action<Room>)Delegate.Remove(buildEvents.OnRoomEditRoomObjectsState, new Action<Room>(OnRoomEditRoomObjectsState));
			BuildEvents buildEvents2 = _level.BuildEvents;
			buildEvents2.OnBeginNewRoom = (Action<RoomDefinition>)Delegate.Remove(buildEvents2.OnBeginNewRoom, new Action<RoomDefinition>(OnBeginNewRoom));
			BuildEvents buildEvents3 = _level.BuildEvents;
			buildEvents3.OnRoomDeleted = (Action<Room>)Delegate.Remove(buildEvents3.OnRoomDeleted, new Action<Room>(OnRoomDeleted));
			BuildEvents buildEvents4 = _level.BuildEvents;
			buildEvents4.OnCancelRoom = (Action)Delegate.Remove(buildEvents4.OnCancelRoom, new Action(OnCancelRoom));
			BuildEvents buildEvents5 = _level.BuildEvents;
			buildEvents5.OnEnterEditFloorPlanState = (Action<Room, BlueprintFloorPlan, BlueprintFloorPlanVisual>)Delegate.Remove(buildEvents5.OnEnterEditFloorPlanState, new Action<Room, BlueprintFloorPlan, BlueprintFloorPlanVisual>(OnEnterEditFloorPlanState));
			BuildEvents buildEvents6 = _level.BuildEvents;
			buildEvents6.OnCursorHoverStart = (Action<ICursorSelectable>)Delegate.Remove(buildEvents6.OnCursorHoverStart, new Action<ICursorSelectable>(OnCursorHoverStart));
			BuildEvents buildEvents7 = _level.BuildEvents;
			buildEvents7.OnCursorHoverStop = (Action<ICursorSelectable>)Delegate.Remove(buildEvents7.OnCursorHoverStop, new Action<ICursorSelectable>(OnCursorHoverStop));
			BuildEvents buildEvents8 = _level.BuildEvents;
			buildEvents8.OnCursorSelectObject = (Action<ICursorSelectable>)Delegate.Remove(buildEvents8.OnCursorSelectObject, new Action<ICursorSelectable>(OnCursorSelectObject));
			HUDEvents hUDEvents = _level.HUDEvents;
			hUDEvents.OnMenuClose = (Action<MenuBase>)Delegate.Remove(hUDEvents.OnMenuClose, new Action<MenuBase>(OnHUDMenuClose));
			ConsoleCommandsDatabase.UnRegisterCommand("ShowYearlyReviewMenu");
			ConsoleCommandsDatabase.UnRegisterCommand("ShowOverview");
			ConsoleCommandsDatabase.UnRegisterCommand("ShowYearEnd");
			ConsoleCommandsDatabase.UnRegisterCommand("ToggleOldInspectorMenu");
			_hospitalPlotFootprints.ClearAndCallDestroy();
			base.Destroy();
		}

		public void ShowHospitalFootprint(HospitalPlot plotToShow)
		{
			_selectedFootprint = plotToShow;
		}

		private void OnCursorHoverStart(ICursorSelectable cursorSelectable)
		{
			if (cursorSelectable is Room room && (room.Definition.IsHospitalUnbuilt || room.Definition.IsAmbulanceBayOnly))
			{
				_highlightedFootprint = room.FloorPlan.HospitalMap.Plot;
			}
		}

		private void OnCursorHoverStop(ICursorSelectable cursorSelectable)
		{
			if (cursorSelectable is Room room && (room.Definition.IsHospitalUnbuilt || room.Definition.IsAmbulanceBayOnly) && _highlightedFootprint == room.FloorPlan.HospitalMap.Plot)
			{
				_highlightedFootprint = null;
			}
		}

		private void OnCursorSelectObject(ICursorSelectable selectable)
		{
			if (DEBUG_UseOldInspectorMenu)
			{
				return;
			}
			InspectorMenu inspectorMenu = _level.HUD.FindMenu<InspectorMenu>();
			if (inspectorMenu == null)
			{
				return;
			}
			if (selectable == null)
			{
				inspectorMenu.CloseAndRestoreGeneralNotifications();
				return;
			}
			Room room = selectable as Room;
			Character character = selectable as Character;
			RoomItem roomItem = selectable as RoomItem;
			if (roomItem != null && roomItem.Definition.ItemType == RoomItemDefinition.Type.Door)
			{
				room = roomItem.OwningRoom;
			}
			if (room != null && room.Definition.IsAmbulanceBayOnly && roomItem == null)
			{
				_level.HospitalHUDManager.ToggleItemsList(RoomDefinition.Type.AmbulanceBay, room.FloorPlan, playSFX: true);
			}
			if (!InspectorMenu.ShouldShowInspector(room) && !InspectorMenu.ShouldShowInspector(character, _level.CharacterManager))
			{
				inspectorMenu.CloseAndRestoreGeneralNotifications();
				return;
			}
			if (!inspectorMenu.IsOpen)
			{
				GeneralNotificationMenu generalNotificationMenu = _level.HUD.FindMenu<GeneralNotificationMenu>(includeInactive: false);
				if (generalNotificationMenu != null)
				{
					generalNotificationMenu.SuspendMenu();
					ElectricityMenu componentInChildren = generalNotificationMenu.GetComponentInChildren<ElectricityMenu>();
					if (componentInChildren != null)
					{
						componentInChildren.Suspend();
					}
				}
			}
			inspectorMenu.OpenMenu();
			if (room != null)
			{
				bool selectQueueTab = roomItem != null;
				inspectorMenu.Inspect(room, selectQueueTab);
			}
			else
			{
				inspectorMenu.Inspect(character);
			}
		}

		private void OnEnterEditFloorPlanState(Room roomBeingEdited, BlueprintFloorPlan floorPlan, BlueprintFloorPlanVisual floorPlanVisual)
		{
			if (floorPlan != _level.BuildingLogic.CurrentBlueprintFloorPlan)
			{
				HideRoomsList();
			}
			ShowItemsList(roomBeingEdited.Definition._type, floorPlan, playSFX: false);
			TryShowBuildBar();
		}

		private void OnRoomEditRoomObjectsState(Room room)
		{
			HideRoomsList();
			ShowItemsList(room.Definition._type, room.FloorPlan, playSFX: false);
		}

		private void OnBeginNewRoom(RoomDefinition roomDefinition)
		{
			TryShowBuildBar();
		}

		private void OnCancelRoom()
		{
			CleanupMenusAfterBuilding();
		}

		private void OnRoomDeleted(Room room)
		{
			if (!room.Definition.IsHospitalOrBay && !room.Definition.IsHospitalUnbuilt)
			{
				CleanupMenusAfterBuilding();
			}
		}

		private void OnHUDMenuClose(MenuBase menu)
		{
			if (_suspendedMenus == null)
			{
				return;
			}
			for (int i = 0; i < _suspendedMenus.Length; i++)
			{
				if (_suspendedMenus[i] == menu)
				{
					_suspendedMenus[i] = null;
				}
			}
		}

		private ConsoleCommandResult Debug_ShowYearlyReviewMenu(string[] argd)
		{
			ShowYearlyReviewMenu();
			return ConsoleCommandResult.Succeeded();
		}

		private ConsoleCommandResult Debug_ShowOverview(string[] args)
		{
			if (_level.HUD.FindMenu<OverviewMenu>(includeInactive: false) == null)
			{
				bool result = false;
				if (args.Length != 0)
				{
					bool.TryParse(args[0], out result);
				}
				ShowOverviewMenu(play_SFX: false, result);
				return ConsoleCommandResult.Succeeded();
			}
			return ConsoleCommandResult.Failed("Menu already open");
		}

		private ConsoleCommandResult Debug_ShowInboxMenu(string[] args)
		{
			InboxMenu inboxMenu = _level.HUD.FindMenu<InboxMenu>();
			if (inboxMenu != null)
			{
				if (inboxMenu.IsClosed() || inboxMenu.IsClosing())
				{
					inboxMenu.OpenMenu();
					inboxMenu.Setup(InboxMenu.Mode.Inbox);
				}
				else
				{
					inboxMenu.CloseMenu();
				}
				return ConsoleCommandResult.Succeeded();
			}
			return ConsoleCommandResult.Failed("Can't find Inbox Menu");
		}

		private ConsoleCommandResult Debug_ToggleOldInspectorMenu(string[] args)
		{
			DEBUG_UseOldInspectorMenu = !DEBUG_UseOldInspectorMenu;
			return ConsoleCommandResult.Succeeded(DEBUG_UseOldInspectorMenu ? "Old Inspector Menu is now Active" : "Old Inspector Menu is now Inactive");
		}

		private void Debug_CloseAllFullScreenOrPauseTimeMenus()
		{
			_level.Notifications.CloseCurrentOpenMessage();
			_level.HUD.Debug_CloseAllFullScreenOrPauseTimeMenus();
		}
	}
}
