using System;
using I2.Loc;
using JetBrains.Annotations;
using TH20.EventPlayableHospital;
using TH20.EventUnlockHospital;
using TH20.UI;
using TMPro;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseTargetFlags.Members)]
	public class HubMenuButtons : MonoBehaviour, TH20.EventPlayableHospital.Interface, IGameEventCallback, TH20.EventUnlockHospital.Interface
	{
		[Header("Hub Buttons")]
		[SerializeField]
		private DynamicButton _metaMapButton;

		[SerializeField]
		private TooltipSpawner _metaMapButtonTooltip;

		[SerializeField]
		private GameObject _newLevelsCountGameObject;

		[SerializeField]
		private TMP_Text _newLevelsCountText;

		[SerializeField]
		private DynamicButton _roomsButton;

		[SerializeField]
		private ButtonAnimator _roomsButtonAnimator;

		[SerializeField]
		private DynamicButton _itemsButton;

		[SerializeField]
		private ButtonAnimator _itemsButtonAnimator;

		[SerializeField]
		private DynamicButton _hireButton;

		[SerializeField]
		private ButtonAnimator _hireButtonAnimator;

		[SerializeField]
		private DynamicButton _optionsButton;

		[Header("Characters")]
		[SerializeField]
		private DynamicButton _patientsButton;

		[SerializeField]
		private DynamicButton _staffButton;

		[SerializeField]
		private DynamicButton _illnessesButton;

		[Header("Finance")]
		[SerializeField]
		private DynamicButton _businessOverviewMenu;

		[SerializeField]
		private DynamicButton _loansButton;

		[SerializeField]
		private DynamicButton _pricesButton;

		[Header("Tutorial")]
		[SerializeField]
		private GameObject _tutorialObject;

		[SerializeField]
		private GameObject _tutorialRoomCircle;

		[SerializeField]
		private GameObject _tutorialItemCircle;

		[SerializeField]
		private GameObject _tutorialHireCircle;

		private Level _level;

		[NonSerialized]
		private int _trackedStaffIndex = -1;

		[NonSerialized]
		public static readonly string Click_OpenSubMenu_AudioEvent = "Click:OpenSubMenu";

		[NonSerialized]
		public static readonly string Click_CloseSubMenu_AudioEvent = "Click:CloseSubMenu";

		public ButtonAnimator RoomsButtonAnimator => _roomsButtonAnimator;

		public ButtonAnimator ItemsButtonAnimator => _itemsButtonAnimator;

		public ButtonAnimator HireButtonAnimator => _hireButtonAnimator;

		public DynamicButton MetaMapButton => _metaMapButton;

		public void Setup(Level level)
		{
			_level = level;
			HospitalHUDManager hospitalHUDManager = _level.HospitalHUDManager;
			hospitalHUDManager.OnRibbonMenuEnterMode = (Action<RibbonMenu.Mode>)Delegate.Combine(hospitalHUDManager.OnRibbonMenuEnterMode, new Action<RibbonMenu.Mode>(OnRibbonMenuEnterMode));
			HospitalHUDManager hospitalHUDManager2 = _level.HospitalHUDManager;
			hospitalHUDManager2.OnRibbonMenuClose = (System.Action)Delegate.Combine(hospitalHUDManager2.OnRibbonMenuClose, new System.Action(OnRibbonMenuClose));
			MetagameMap metagameMap = _level.MetagameMap;
			metagameMap.OnOpen = (System.Action)Delegate.Combine(metagameMap.OnOpen, new System.Action(OnMetagameMapOpened));
			_level.Metagame.OnHospitalUnlocked.AddAndDontSave(this);
			_level.Metagame.OnHospitalBecamePlayable.AddAndDontSave(this);
			_metaMapButton.onPrimaryDown.AddListener(ClickMetagameButton);
			_roomsButton.onPrimaryDown.AddListener(ClickRoomsButton);
			_itemsButton.onPrimaryDown.AddListener(ClickItemsButton);
			_hireButton.onPrimaryDown.AddListener(ClickHireButton);
			_optionsButton.onPrimaryDown.AddListener(ClickOptionsButton);
			_patientsButton.onPrimaryDown.AddListener(ClickPatients);
			_staffButton.onPrimaryDown.AddListener(ClickStaff);
			_staffButton.onSecondaryDown.AddListener(ClickStaffAlternate);
			_illnessesButton.onPrimaryDown.AddListener(ClickIllnesses);
			_businessOverviewMenu.onPrimaryDown.AddListener(ClickBusinessOverview);
			_loansButton.onPrimaryDown.AddListener(ClickLoans);
			_pricesButton.onPrimaryDown.AddListener(ClickPrices);
			UpdateNewLevelCounter();
			if (level.App.GameMode is GameModeCareer)
			{
				_metaMapButtonTooltip.SetDataProvider(MapButtonTooltipData);
			}
			else if (level.App.GameMode is GameModeSandbox)
			{
				_metaMapButtonTooltip.SetDataProvider(MapButtonTooltipDataSandbox);
			}
			_level.HUD.CreateMenu<StaffMenu>().Initialise(_level);
			_level.HUD.CreateMenu<PricesMenu2>().Initialise(_level, _level.Config.GetPriceModifiablesConfig());
			_level.HUD.CreateMenu<LoanMenu>().Initialise(_level.LoanManager, _level.FinanceManager);
			_level.HUD.CreateMenu<PatientsMenu2>().Initialise(_level);
			_level.HUD.CreateMenu<IllnessesMenu2>().Initialise(_level);
		}

		public void UpdateHubMenuButtonStates(RibbonMenu.Mode mode)
		{
			_roomsButtonAnimator.CurrentState = ((mode == RibbonMenu.Mode.Rooms) ? ButtonAnimator.State.Selected : ButtonAnimator.State.Selectable);
			_itemsButtonAnimator.CurrentState = ((mode == RibbonMenu.Mode.Items) ? ButtonAnimator.State.Selected : ButtonAnimator.State.Selectable);
			_hireButtonAnimator.CurrentState = ((mode == RibbonMenu.Mode.Hire) ? ButtonAnimator.State.Selected : ButtonAnimator.State.Selectable);
		}

		private void MapButtonTooltipData(Tooltip tooltip)
		{
			int numLevelsNotPlayed = _level.Metagame.NumLevelsNotPlayed;
			string text = ((numLevelsNotPlayed == 0) ? ScriptLocalization.Tooltip.HubMenu_Map_CS : ScriptLocalization.Tooltip.HubMenu_MapNewLevels_CS);
			LocalisationParams.Set("COUNT", numLevelsNotPlayed);
			LocalisationParams.Localise(ref text);
			tooltip.Text = text;
		}

		private void MapButtonTooltipDataSandbox(Tooltip tooltip)
		{
			tooltip.Text = ScriptLocalization.Tooltip.HubMenu_Map_CS;
		}

		protected void OnDestroy()
		{
			MetagameMap metagameMap = _level.MetagameMap;
			metagameMap.OnOpen = (System.Action)Delegate.Remove(metagameMap.OnOpen, new System.Action(OnMetagameMapOpened));
			_level.Metagame.OnHospitalUnlocked.Remove(this);
			_level.Metagame.OnHospitalBecamePlayable.Remove(this);
			HospitalHUDManager hospitalHUDManager = _level.HospitalHUDManager;
			hospitalHUDManager.OnRibbonMenuEnterMode = (Action<RibbonMenu.Mode>)Delegate.Remove(hospitalHUDManager.OnRibbonMenuEnterMode, new Action<RibbonMenu.Mode>(OnRibbonMenuEnterMode));
			HospitalHUDManager hospitalHUDManager2 = _level.HospitalHUDManager;
			hospitalHUDManager2.OnRibbonMenuClose = (System.Action)Delegate.Remove(hospitalHUDManager2.OnRibbonMenuClose, new System.Action(OnRibbonMenuClose));
		}

		private void OnRibbonMenuClose()
		{
			OnRibbonMenuEnterMode(RibbonMenu.Mode.Null);
		}

		private void OnRibbonMenuEnterMode(RibbonMenu.Mode mode)
		{
			UpdateHubMenuButtonStates(mode);
		}

		private void ClickMetagameButton()
		{
			ProcessAwardsUponMatamapRequest();
			_level.MetagameMap.Open();
		}

		private void ProcessAwardsUponMatamapRequest()
		{
			OverviewMenu overviewMenu = _level.HUD.FindMenu<OverviewMenu>();
			if (overviewMenu != null)
			{
				overviewMenu.StopAwardsCeremony();
			}
		}

		private void OnMetagameMapOpened()
		{
			_level.CharacterEvents.OnStaffCancelPickup.InvokeSafe(param: false);
			_level.HospitalHUDManager.HideRibbonMenu();
		}

		private void ClickRoomsButton()
		{
			_level.HospitalHUDManager.ToggleRoomsList();
		}

		private void ClickItemsButton()
		{
			if (_level.BuildingLogic.CurrentState == BuildingLogic.State.Null)
			{
				_level.HospitalHUDManager.ToggleItemsList(RoomDefinition.Type.Hospital, null, playSFX: true);
			}
			else
			{
				_level.HospitalHUDManager.ToggleItemsList(_level.BuildingLogic.CurrentFloorPlan.Definition._type, _level.BuildingLogic.CurrentFloorPlan, playSFX: true);
			}
		}

		private void ClickHireButton()
		{
			_level.CharacterEvents.OnStaffCancelPickup.InvokeSafe(param: false);
			_level.HospitalHUDManager.ToggleHireList();
		}

		private void ClickOptionsButton()
		{
			_level.HospitalHUDManager.CloseAllMenusAllowingEscapeClose();
			_level.HospitalHUDManager.TogglePauseMenu();
			UpdateHubMenuButtonStates(RibbonMenu.Mode.Null);
		}

		private void ClickStaffPay()
		{
			_level.HospitalHUDManager.ToggleInfoMenu(delegate(StaffMenu menu)
			{
				menu.Setup(StaffMenu.ViewModes.ViewModePayReview);
			});
		}

		private void ClickStaffJobs()
		{
			_level.HospitalHUDManager.ToggleInfoMenu(delegate(StaffMenu menu)
			{
				menu.Setup(StaffMenu.ViewModes.ViewModeJobAssignment);
			});
		}

		private void ClickPrices()
		{
			_level.HospitalHUDManager.ToggleInfoMenu(delegate(PricesMenu2 menu)
			{
				menu.Setup();
			});
		}

		private void ClickBusinessOverview()
		{
			if (_level.HUD.FindMenu<OverviewMenu>() != null)
			{
				_level.HospitalHUDManager.HideOverviewMenu();
			}
			else
			{
				_level.HospitalHUDManager.ShowOverviewMenu(play_SFX: false, yearEnd: false);
			}
		}

		private void ClickLoans()
		{
			_level.HospitalHUDManager.ToggleInfoMenu(delegate(LoanMenu menu)
			{
				menu.Setup();
			});
		}

		private void ClickStaff()
		{
			_level.HospitalHUDManager.ToggleInfoMenu(delegate(StaffMenu menu)
			{
				menu.Setup(StaffMenu.ViewModes.ViewModeStaffList);
			});
		}

		private void ClickStaffAlternate()
		{
			if (_level.CharacterManager.StaffMembers.Count != 0)
			{
				_trackedStaffIndex++;
				if (_trackedStaffIndex >= _level.CharacterManager.StaffMembers.Count)
				{
					_trackedStaffIndex = 0;
				}
				Staff staff = _level.CharacterManager.StaffMembers[_trackedStaffIndex];
				_level.CameraLogic.TrackObject(staff.GameObject.transform);
				_level.BuildEvents.OnCursorSelectObject.InvokeSafe(staff);
			}
		}

		private void ClickPatients()
		{
			_level.HospitalHUDManager.ToggleInfoMenu(delegate(PatientsMenu2 menu2)
			{
				menu2.Setup();
			});
		}

		private void ClickIllnesses()
		{
			_level.HospitalHUDManager.ToggleInfoMenu(delegate(IllnessesMenu2 menu2)
			{
				menu2.Setup();
			});
		}

		public void ShowTutorialHighlight(bool roomCircle, bool itemsCircle, bool hireCircle)
		{
			GameObjectUtils.SetActive(_tutorialRoomCircle, roomCircle);
			GameObjectUtils.SetActive(_tutorialItemCircle, itemsCircle);
			GameObjectUtils.SetActive(_tutorialHireCircle, hireCircle);
			GameObjectUtils.SetActive(_tutorialObject, roomCircle || itemsCircle || hireCircle);
		}

		private void UpdateNewLevelCounter()
		{
			if (_level.IsSandbox())
			{
				GameObjectUtils.SetActive(_newLevelsCountGameObject, isActive: false);
				return;
			}
			int numLevelsNotPlayed = _level.Metagame.NumLevelsNotPlayed;
			_newLevelsCountText.text = numLevelsNotPlayed.ToString();
			GameObjectUtils.SetActive(_newLevelsCountGameObject, numLevelsNotPlayed != 0);
		}

		public void OnHospitalBecamePlayableEvent(LevelConfig level)
		{
			UpdateNewLevelCounter();
		}

		public void OnHospitalUnlockedEvent(LevelConfig level)
		{
			UpdateNewLevelCounter();
		}

		public void PressStaffButton()
		{
			_staffButton.onPrimaryDown.Invoke();
		}

		public void PressPatientButton()
		{
			_patientsButton.onPrimaryDown.Invoke();
		}

		public void PressIllnessButton()
		{
			_illnessesButton.onPrimaryDown.Invoke();
		}

		public void PressOverviewButton()
		{
			_businessOverviewMenu.onPrimaryDown.Invoke();
		}
	}
}
