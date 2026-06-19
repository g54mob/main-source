using System;
using System.Collections.Generic;
using I2.Loc;
using JetBrains.Annotations;
using TH20.UI;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class TrainingMenu : AnimatedMenuBase, IPointerDownHandler, IEventSystemHandler
	{
		[Serializable]
		[UsedImplicitly(ImplicitUseTargetFlags.Members)]
		public class PanelUIData
		{
			public Image Panel;
		}

		[Serializable]
		public class RoomUIData : PanelUIData
		{
			public TMP_Text NumAvailableRoomsText;

			public Button PrevButton;

			public Button NextButton;
		}

		[Serializable]
		public class CourseUIData : PanelUIData
		{
			public Image PanelBGSelected;

			public Image PanelBGNotSelected;

			public Localize Text;

			public TMP_Text NumAvailableText;

			public GameObject CoursesAvailableCountPanel;

			public Image Clickable1;

			public Image Clickable2;

			public Button PlusIcon;

			public Image Icon;

			public Button RemoveButton;

			public TooltipSpawner TooltipSpawner;
		}

		[Serializable]
		public class TrainerUIData : PanelUIData
		{
			public Image PanelBGSelected;

			public Image PanelBGNotSelected;

			public Localize Text;

			public TMP_Text TrainerNameText;

			public TMP_Text NumAvailableText;

			public GameObject TrainersAvailableCountPanel;

			public Image Clickable1;

			public Image Clickable2;

			public Button PlusIcon;

			public GameObject Mugshot;

			public RawImage MugshotImage;

			public Button RemoveButton;

			public TooltipSpawner TooltipSpawner;
		}

		[Serializable]
		public class TraineesUIData : PanelUIData
		{
			public TMP_Text Title;

			public TMP_Text Text;

			public TMP_Text NumAvailableText;

			public Table Table;

			public GameObject _staffRowPrefab;

			public GameObject _staffAddRowPrefab;
		}

		[Serializable]
		public class ListUIData : PanelUIData
		{
			public Localize Text;

			public Table Table;

			public GameObject _staffRowPrefab;

			public GameObject _qualificationRowPrefab;
		}

		[Serializable]
		public class InfoUIData : PanelUIData
		{
			public TMP_Text UpfrontCost;

			public TMP_Text TrainingCost;

			public TMP_Text EstimatedDuration;
		}

		[Serializable]
		public class OriginalConfig
		{
			public Staff Trainer;

			public Staff Trainee;

			public Room Room;
		}

		[SerializeField]
		private RoomUIData _roomUI;

		[SerializeField]
		private CourseUIData _courseUI;

		[SerializeField]
		private TrainerUIData _trainerUI;

		[SerializeField]
		private TraineesUIData _traineesUI;

		[SerializeField]
		private ListUIData _listUI;

		[SerializeField]
		private InfoUIData _infoUI;

		[SerializeField]
		private DynamicButton _buttonStart;

		[SerializeField]
		private ButtonAnimator _buttonStartAnimator;

		[SerializeField]
		private TMP_Text _buttonStartText;

		[SerializeField]
		private Image _buttonStartImage;

		[SerializeField]
		private DynamicButton _buttonReset;

		[SerializeField]
		private ButtonAnimator _buttonResetAnimator;

		[SerializeField]
		private TMP_Text _buttonResetText;

		[SerializeField]
		private TooltipSpawner _buttonStartTooltip;

		[SerializeField]
		private LocalisedString _roomLacksElectricityTooltip;

		private Level _level;

		private OriginalConfig _originalConfig;

		private Room _room;

		private QualificationDefinition _course;

		private Staff _trainer;

		private readonly List<Staff> _trainees = new List<Staff>();

		private bool _configDirty;

		private List<Staff> _allStaff = new List<Staff>();

		private readonly List<Room> _availableRooms = new List<Room>();

		private readonly List<QualificationDefinition> _availableCourses = new List<QualificationDefinition>();

		private readonly List<Staff> _availableTrainers = new List<Staff>();

		private readonly List<Staff> _availableTrainees = new List<Staff>();

		private List<GuestTrainer> _guestTrainers;

		private PanelUIData _selectedPanel;

		private CharacterMugShot _trainerMugshot;

		private bool _canAffordGuestTrainer;

		private readonly List<GameObject> _listRows = new List<GameObject>();

		private readonly List<GameObject> _selectedTraineeRows = new List<GameObject>();

		public void Setup(Level level, Staff trainer, Staff trainee, Room room)
		{
			_originalConfig = new OriginalConfig
			{
				Room = room,
				Trainer = trainer,
				Trainee = trainee
			};
			_level = level;
			_level.GameTime.IsPausedByMenu = true;
			_buttonReset.onPrimaryDown.AddListener(OnReset);
			_buttonStart.onPrimaryDown.AddListener(OnStart);
			if (_buttonStartTooltip != null)
			{
				_buttonStartTooltip.SetDataProvider(ButtonStartTooltipDataProvider);
			}
			_courseUI.RemoveButton.onClick.AddListener(ClearCourse);
			_courseUI.TooltipSpawner.SetDataProvider(CourseIconTooltipDataProvider);
			_courseUI.PlusIcon.onClick.AddListener(SelectCourseMode);
			_trainerUI.RemoveButton.onClick.AddListener(ClearTrainer);
			_trainerUI.TooltipSpawner.SetDataProvider(TrainerTooltipDataProvider);
			_trainerUI.PlusIcon.onClick.AddListener(SelectTrainerMode);
			_roomUI.PrevButton.onClick.AddListener(SelectPrevRoom);
			_roomUI.NextButton.onClick.AddListener(SelectNextRoom);
			HUDEvents hUDEvents = _level.HUDEvents;
			hUDEvents.OnMenuOpen = (Action<MenuBase>)Delegate.Combine(hUDEvents.OnMenuOpen, new Action<MenuBase>(OnMenuOpen));
			_level.HospitalHUDManager.HideRibbonMenu();
			_level.HospitalHUDManager.HideAllInfoMenus();
			HospitalHUDManager hospitalHUDManager = _level.HospitalHUDManager;
			hospitalHUDManager.OnRibbonMenuEnterMode = (Action<RibbonMenu.Mode>)Delegate.Combine(hospitalHUDManager.OnRibbonMenuEnterMode, new Action<RibbonMenu.Mode>(OnRibbonMenuEnterMode));
			Initialise(_originalConfig);
		}

		private void ButtonStartTooltipDataProvider(Tooltip tooltip)
		{
			if (_room != null && _course != null && _trainer != null && _trainees.Count != 0 && _canAffordGuestTrainer && !_room.CanBeOpened() && !_room.IsOpen)
			{
				tooltip.Text = _roomLacksElectricityTooltip.Translation;
			}
			else
			{
				tooltip.Text = string.Empty;
			}
		}

		private void Initialise(OriginalConfig originalConfig)
		{
			_course = null;
			_trainer = null;
			_trainees.Clear();
			_allStaff = new List<Staff>(_level.CharacterManager.StaffMembers);
			_allStaff.RemoveAll((Staff staff) => staff.HasBeenFired() || staff.HasResigned());
			CalculateAvailableRooms();
			if (originalConfig.Room != null)
			{
				SetRoom(originalConfig.Room);
			}
			else if (_availableRooms.Count != 0)
			{
				SetRoom(_availableRooms[0]);
			}
			if (originalConfig.Trainer != null)
			{
				SetTrainer(originalConfig.Trainer);
			}
			if (originalConfig.Trainee != null)
			{
				AddTrainee(originalConfig.Trainee);
			}
			CalculateAvailableCourses();
			CalculateAvailableTrainers();
			CalculateAvailableTrainees();
			_configDirty = false;
			UpdateOptionsUI();
			SelectCourseMode();
		}

		public override void OpenMenu()
		{
			base.OpenMenu();
			LocalizationManager.OnLocalizeEvent += OnLocalize;
			FinanceManager financeManager = base.HUD.Level.FinanceManager;
			financeManager.OnBalanceUpdated = (Action<int>)Delegate.Combine(financeManager.OnBalanceUpdated, new Action<int>(OnBalanceUpdated));
		}

		private void OnDestroy()
		{
			UnregisterEvents();
		}

		private void UnregisterEvents()
		{
			LocalizationManager.OnLocalizeEvent -= OnLocalize;
			FinanceManager financeManager = base.HUD.Level.FinanceManager;
			financeManager.OnBalanceUpdated = (Action<int>)Delegate.Remove(financeManager.OnBalanceUpdated, new Action<int>(OnBalanceUpdated));
		}

		private void OnLocalize()
		{
			RefreshSelectCoursesList();
			RefreshSelectTrainerList();
			RefreshSelectTraineesList();
		}

		private void OnBalanceUpdated(int newBalance)
		{
			if (CanAffordGuestTrainer() != _canAffordGuestTrainer)
			{
				UpdateOptionsUI();
			}
		}

		private void SelectCourseMode()
		{
			if (_selectedPanel != _courseUI)
			{
				SetPanelSelected(_courseUI);
				RefreshSelectCoursesList();
			}
		}

		private void SelectTrainerMode()
		{
			if (_selectedPanel != _trainerUI)
			{
				SetPanelSelected(_trainerUI);
				RefreshSelectTrainerList();
			}
		}

		private void SelectTraineesMode()
		{
			if (_selectedPanel != _traineesUI)
			{
				SetPanelSelected(_traineesUI);
				RefreshSelectTraineesList();
			}
		}

		private void SelectRoomMode()
		{
			if (_selectedPanel != _roomUI)
			{
				SetPanelSelected(_roomUI);
			}
		}

		private void CalculateAvailableRooms()
		{
			_availableRooms.Clear();
			foreach (Room allRoom in _level.WorldState.AllRooms)
			{
				RoomLogicTrainingRoom component = allRoom.GetComponent<RoomLogicTrainingRoom>();
				if (component != null && component.IsAvailable && allRoom.FloorPlan.MaxCapacity >= _trainees.Count)
				{
					_availableRooms.Add(allRoom);
				}
			}
		}

		private void CalculateAvailableCourses()
		{
			_availableCourses.Clear();
			if (_availableRooms.Count == 0)
			{
				return;
			}
			foreach (QualificationDefinition key in _level.JobApplicantManager.Qualifications.List.Keys)
			{
				bool flag = true;
				bool flag2 = true;
				if (_trainer != null && !_trainer.HasCompletedQualification(key))
				{
					flag = false;
				}
				foreach (Staff trainee in _trainees)
				{
					if (!key.ValidForExcludeIncomplete(trainee))
					{
						flag2 = false;
					}
				}
				if (!(flag && flag2))
				{
					continue;
				}
				foreach (Staff item in _allStaff)
				{
					if (item.IsReadyForTraining() && key.ValidForExcludeIncomplete(item))
					{
						_availableCourses.Add(key);
						break;
					}
				}
			}
		}

		private void CalculateAvailableTrainers()
		{
			_availableTrainers.Clear();
			if (_availableRooms.Count != 0)
			{
				foreach (Staff item in _allStaff)
				{
					if (!item.HasQualifications() || !item.IsReadyForTraining())
					{
						continue;
					}
					bool flag = false;
					bool flag2 = _course != null && item.HasCompletedQualification(_course);
					if (_course == null)
					{
						foreach (QualificationDefinition availableCourse in _availableCourses)
						{
							if (item.HasCompletedQualification(availableCourse))
							{
								flag = true;
							}
						}
					}
					if (flag2 || flag)
					{
						_availableTrainers.Add(item);
					}
				}
				if (_course != null)
				{
					foreach (GuestTrainer guestTrainer in _guestTrainers)
					{
						_availableTrainers.Add(guestTrainer);
					}
				}
				foreach (Staff trainee in _trainees)
				{
					_availableTrainers.Remove(trainee);
				}
			}
			if (!_availableTrainers.Contains(_trainer))
			{
				_trainer = null;
				UpdateOptionsUITrainerInfo();
			}
		}

		private void CalculateAvailableTrainees()
		{
			_availableTrainees.Clear();
			if (_availableRooms.Count == 0 || _trainees.Count >= _room.FloorPlan.MaxCapacity)
			{
				return;
			}
			foreach (Staff item in _allStaff)
			{
				if (!item.IsFullyTrained && item.IsReadyForTraining() && (_course == null || _course.ValidForExcludeIncomplete(item)))
				{
					_availableTrainees.Add(item);
				}
			}
			_availableTrainees.Remove(_trainer);
			foreach (Staff trainee in _trainees)
			{
				_availableTrainees.Remove(trainee);
			}
		}

		private void UpdateOptionsUI()
		{
			UpdateOptionsUIRoomInfo();
			UpdateOptionsUICourseInfo();
			UpdateOptionsUITrainerInfo();
			UpdateOptionsUITraineeInfo();
			UpdateOptionsUIInfo();
			bool flag = _room != null && _course != null && _trainer != null && _trainees.Count != 0 && _canAffordGuestTrainer && (_room.CanBeOpened() || _room.IsOpen);
			_buttonStart.interactable = flag;
			if (flag)
			{
				_buttonStartAnimator.CurrentState = ButtonAnimator.State.Selectable;
				_buttonStartText.alpha = 1f;
			}
			else
			{
				_buttonStartAnimator.CurrentState = ButtonAnimator.State.Unselectable;
				_buttonStartText.alpha = 0.5f;
			}
			if (!_configDirty)
			{
				_buttonResetAnimator.CurrentState = ButtonAnimator.State.Unselectable;
				_buttonReset.onPrimaryDown.RemoveListener(OnReset);
				_buttonReset.interactable = false;
				_buttonResetText.alpha = 0.5f;
			}
			else
			{
				_buttonResetAnimator.CurrentState = ButtonAnimator.State.Selectable;
				_buttonReset.onPrimaryDown.AddListener(OnReset);
				_buttonReset.interactable = true;
				_buttonResetText.alpha = 1f;
			}
		}

		private void UpdateOptionsUIRoomInfo()
		{
			int count = _availableRooms.Count;
			if (count > 0)
			{
				int num = -1;
				if (_room != null)
				{
					num = _availableRooms.IndexOf(_room);
				}
				if (num >= 0)
				{
					_roomUI.NumAvailableRoomsText.text = $"{num + 1} / {count}";
				}
				else
				{
					_roomUI.NumAvailableRoomsText.text = $"{count}";
				}
			}
			else
			{
				_roomUI.NumAvailableRoomsText.text = "0";
			}
			GameObjectUtils.SetInteractable(_roomUI.PrevButton, count > 0);
			GameObjectUtils.SetInteractable(_roomUI.NextButton, count > 0);
		}

		private void UpdateOptionsUICourseInfo()
		{
			bool flag = _course != null;
			_courseUI.PanelBGSelected.gameObject.SetActive(flag);
			_courseUI.PanelBGNotSelected.gameObject.SetActive(!flag);
			_courseUI.Text.gameObject.SetActive(value: true);
			if (!flag)
			{
				if (_availableCourses.Count > 0)
				{
					_courseUI.Text.SetTerm("Menu/Training/CoursesAvailable");
				}
				else
				{
					_courseUI.Text.SetTerm("Menu/Training/NoneAvailable");
				}
			}
			else
			{
				_courseUI.Text.SetTerm(_course.NameLocalised.Term);
			}
			_courseUI.CoursesAvailableCountPanel.SetActive(!flag);
			if (!flag)
			{
				_courseUI.NumAvailableText.text = $"{_availableCourses.Count}";
			}
			_courseUI.Clickable1.gameObject.SetActive(value: true);
			_courseUI.Clickable2.gameObject.SetActive(value: true);
			_courseUI.PlusIcon.gameObject.SetActive(!flag);
			_courseUI.Icon.gameObject.SetActive(flag);
			if (flag)
			{
				_courseUI.Icon.sprite = _course.Icon;
			}
			_courseUI.RemoveButton.gameObject.SetActive(flag);
		}

		private void UpdateOptionsUITrainerInfo()
		{
			bool flag = _trainer != null;
			_trainerUI.PanelBGSelected.gameObject.SetActive(flag);
			_trainerUI.PanelBGNotSelected.gameObject.SetActive(!flag);
			_trainerUI.Text.gameObject.SetActive(!flag);
			_trainerUI.TrainerNameText.gameObject.SetActive(flag);
			if (!flag)
			{
				if (_availableTrainers.Count > 0)
				{
					_trainerUI.Text.SetTerm("Menu/Training/TrainersAvailable");
				}
				else
				{
					_trainerUI.Text.SetTerm("Menu/Training/NoneAvailable");
				}
			}
			else
			{
				_trainerUI.TrainerNameText.text = _trainer.Name;
			}
			_trainerUI.TrainersAvailableCountPanel.SetActive(!flag);
			if (!flag)
			{
				_trainerUI.NumAvailableText.text = $"{_availableTrainers.Count}";
			}
			_trainerUI.Clickable1.gameObject.SetActive(value: true);
			_trainerUI.Clickable2.gameObject.SetActive(value: true);
			_trainerUI.PlusIcon.gameObject.SetActive(!flag);
			_trainerUI.Mugshot.SetActive(flag);
			if (flag)
			{
				_trainerUI.MugshotImage.texture = _trainerMugshot.Texture;
			}
			_trainerUI.RemoveButton.gameObject.SetActive(flag);
		}

		private void UpdateOptionsUITraineeInfo()
		{
			if (_availableRooms.Count > 0 && _room.FloorPlan.MaxCapacity > 0)
			{
				_traineesUI.NumAvailableText.text = $"{_trainees.Count} / {_room.FloorPlan.MaxCapacity}";
			}
			else
			{
				_traineesUI.NumAvailableText.text = "0";
			}
			RefreshOptionsTraineeList();
		}

		private bool CanAffordGuestTrainer()
		{
			bool result = true;
			if (_trainer != null && _course != null && _trainer is GuestTrainer guestTrainer)
			{
				GuestTrainerDefinition.Skill skill = guestTrainer.Definition.GetSkill(_course);
				int upfrontCost = skill.GetUpfrontCost(_trainer.Level);
				int num = skill.GetCostPerTrainee(_trainer.Level) * _trainees.Count;
				result = _level.FinanceManager.CanAfford(upfrontCost + num);
			}
			return result;
		}

		private void UpdateOptionsUIInfo()
		{
			_infoUI.EstimatedDuration.text = GameStringUtils.GetTrainingCourseDaysRemainingString(_course, _trainer, _trainees, _room);
			_canAffordGuestTrainer = true;
			if (!(_trainer is GuestTrainer guestTrainer))
			{
				GameObjectUtils.SetActive(_infoUI.UpfrontCost.gameObject, isActive: false);
				GameObjectUtils.SetActive(_infoUI.TrainingCost.gameObject, isActive: false);
				return;
			}
			GuestTrainerDefinition.Skill skill = guestTrainer.Definition.GetSkill(_course);
			int upfrontCost = skill.GetUpfrontCost(_trainer.Level);
			int costPerTrainee = skill.GetCostPerTrainee(_trainer.Level);
			int num = costPerTrainee * _trainees.Count;
			if (CanAffordGuestTrainer())
			{
				_infoUI.UpfrontCost.text = string.Format("{0}{2}{1}", ScriptLocalization.Menu_Training.TrainingGuestTrainerUpfrontCost_CS, StringUtils.FormatCurrency(upfrontCost), ScriptLocalization.Misc.ColonSeparator_CS);
				_infoUI.TrainingCost.text = string.Format("{0}{5}{1} x {2} {3} = {4}", ScriptLocalization.Menu_Training.TrainingGuestTrainerCompletionFees_CS, StringUtils.FormatCurrency(costPerTrainee), _trainees.Count, ScriptLocalization.Menu_Training.TrainingGuestTrainerTrainees_CS, StringUtils.FormatCurrency(num), ScriptLocalization.Misc.ColonSeparator_CS);
			}
			else
			{
				_canAffordGuestTrainer = false;
				_infoUI.UpfrontCost.text = string.Format("{0}{3}<color=red>{1} ({2})</color>", ScriptLocalization.Menu_Training.TrainingGuestTrainerUpfrontCost_CS, StringUtils.FormatCurrency(upfrontCost), ScriptLocalization.Menu_Training.TrainingGuestTrainerUnaffordable_CS, ScriptLocalization.Misc.ColonSeparator_CS);
				_infoUI.TrainingCost.text = string.Format("{0}{5}<color=red>{1} x {2} {3} = {4}</color>", ScriptLocalization.Menu_Training.TrainingGuestTrainerCompletionFees_CS, StringUtils.FormatCurrency(costPerTrainee), _trainees.Count, ScriptLocalization.Menu_Training.TrainingGuestTrainerTrainees_CS, StringUtils.FormatCurrency(num), ScriptLocalization.Misc.ColonSeparator_CS);
			}
			GameObjectUtils.SetActive(_infoUI.UpfrontCost.gameObject, isActive: true);
			GameObjectUtils.SetActive(_infoUI.TrainingCost.gameObject, isActive: true);
		}

		private bool IsPanelSelected(PanelUIData panel)
		{
			return _selectedPanel == panel;
		}

		private void SetPanelSelected(PanelUIData panel)
		{
			_selectedPanel = panel;
			UpdateOptionsUI();
		}

		private void SelectPrevRoom()
		{
			SelectRoomMode();
			if (_availableRooms.Count > 1)
			{
				int num = _availableRooms.IndexOf(_room) - 1;
				if (num == -1)
				{
					num = _availableRooms.Count - 1;
				}
				SetRoom(_availableRooms[num]);
				_configDirty = true;
			}
		}

		private void SelectNextRoom()
		{
			SelectRoomMode();
			if (_availableRooms.Count > 1)
			{
				int num = _availableRooms.IndexOf(_room) + 1;
				if (num == _availableRooms.Count)
				{
					num = 0;
				}
				SetRoom(_availableRooms[num]);
				_configDirty = true;
			}
		}

		private void OnStart()
		{
			_room.GetComponent<RoomLogicTrainingRoom>().StartTraining(_course, _trainer, _trainees);
			CloseMenu();
		}

		private void OnReset()
		{
			_level.GuestTrainers.ClearPool();
			ClearCourse();
			Initialise(_originalConfig);
		}

		public override void CloseMenu()
		{
			_buttonStart.interactable = false;
			_buttonStart.onPrimaryDown.RemoveListener(OnStart);
			_buttonReset.interactable = false;
			_level.GuestTrainers.ClearPool();
			_level.GameTime.IsPausedByMenu = false;
			UnregisterEvents();
			base.CloseMenu();
		}

		public override void Destroy()
		{
			DestroyTrainerMugshot();
			_courseUI.PlusIcon.onClick.RemoveListener(SelectCourseMode);
			_trainerUI.PlusIcon.onClick.RemoveListener(SelectTrainerMode);
			HUDEvents hUDEvents = _level.HUDEvents;
			hUDEvents.OnMenuOpen = (Action<MenuBase>)Delegate.Remove(hUDEvents.OnMenuOpen, new Action<MenuBase>(OnMenuOpen));
			HospitalHUDManager hospitalHUDManager = _level.HospitalHUDManager;
			hospitalHUDManager.OnRibbonMenuEnterMode = (Action<RibbonMenu.Mode>)Delegate.Remove(hospitalHUDManager.OnRibbonMenuEnterMode, new Action<RibbonMenu.Mode>(OnRibbonMenuEnterMode));
		}

		private void OnRibbonMenuEnterMode(RibbonMenu.Mode mode)
		{
			CloseMenu();
		}

		private void OnMenuOpen(MenuBase menuBase)
		{
			if (menuBase != this)
			{
				if (base.isActiveAndEnabled)
				{
					CloseMenu();
				}
				else
				{
					CloseMenuImmediately();
				}
			}
		}

		private void SetRoom(Room room)
		{
			_room = room;
			if (_room.GetCameraTrackObject() != null)
			{
				_level.CameraLogic.TrackObject(_room.GetCameraTrackObject().transform);
			}
			UpdateOptionsUI();
		}

		private void SetTrainer(Staff trainer)
		{
			_trainer = trainer;
			DestroyTrainerMugshot();
			if (_trainer != null)
			{
				Vector3 position = _trainer.Visual.HeadSocket.position;
				Quaternion rotation = _trainer.Visual.HeadSocket.rotation;
				_trainerMugshot = new CharacterMugShot(position, rotation, _trainer.Visual.ModuleInstances, 256, 256, trainer.Level.HUD.GetConfig().MugshotConfig);
			}
			CalculateAvailableCourses();
			CalculateAvailableTrainees();
			_configDirty = true;
			UpdateOptionsUI();
			RefreshSelectTrainerList();
		}

		private void ClearTrainer()
		{
			_trainer = null;
			CalculateAvailableCourses();
			CalculateAvailableTrainees();
			UpdateOptionsUI();
			RefreshSelectCoursesList();
			RefreshSelectTrainerList();
			RefreshSelectTraineesList();
			SelectTrainerMode();
		}

		private void DestroyTrainerMugshot()
		{
			if (_trainerMugshot != null)
			{
				_trainerMugshot.Destroy();
				_trainerMugshot = null;
			}
		}

		private void AddTrainee(Staff trainee)
		{
			_trainees.Add(trainee);
			CalculateAvailableRooms();
			CalculateAvailableCourses();
			CalculateAvailableTrainees();
			CalculateAvailableTrainers();
			_configDirty = true;
			UpdateOptionsUI();
			RefreshSelectCoursesList();
			RefreshSelectTrainerList();
			RefreshSelectTraineesList();
		}

		private void RemoveTrainee(Staff trainee)
		{
			_trainees.Remove(trainee);
			CalculateAvailableRooms();
			CalculateAvailableCourses();
			CalculateAvailableTrainees();
			CalculateAvailableTrainers();
			UpdateOptionsUI();
			RefreshSelectCoursesList();
			RefreshSelectTrainerList();
			RefreshSelectTraineesList();
			SelectTraineesMode();
		}

		private void SetCourse(QualificationDefinition qualification)
		{
			if (qualification != _course)
			{
				_course = qualification;
				_guestTrainers = _level.GuestTrainers.GetTrainers(_course);
				CalculateAvailableTrainers();
				CalculateAvailableTrainees();
				_configDirty = true;
				UpdateOptionsUI();
				RefreshSelectCoursesList();
			}
		}

		private void ClearCourse()
		{
			_course = null;
			if (_guestTrainers != null)
			{
				_guestTrainers.Clear();
			}
			CalculateAvailableTrainers();
			CalculateAvailableTrainees();
			if (_trainer is GuestTrainer)
			{
				ClearTrainer();
			}
			UpdateOptionsUI();
			RefreshSelectCoursesList();
			RefreshSelectTrainerList();
			RefreshSelectTraineesList();
			SelectCourseMode();
		}

		private void RefreshSelectCoursesList()
		{
			if (_selectedPanel != _courseUI)
			{
				return;
			}
			_listRows.ClearAndDestroy();
			_listUI.Text.SetTerm("Menu/Training/SelectACourse");
			foreach (QualificationDefinition availableCourse in _availableCourses)
			{
				GameObject gameObject = _listUI.Table.InstantiateAsRow(_listUI._qualificationRowPrefab);
				gameObject.GetComponent<TrainingMenuQualificationRow>().Setup(isSelected: availableCourse == _course, course: availableCourse, onClicked: SetCourse, allStaff: _allStaff);
				_listRows.Add(gameObject);
			}
		}

		private void RefreshSelectTrainerList()
		{
			if (_selectedPanel != _trainerUI)
			{
				return;
			}
			_listRows.ClearAndDestroy();
			_listUI.Text.SetTerm("Menu/Training/SelectATrainer");
			foreach (Staff availableTrainer in _availableTrainers)
			{
				GameObject gameObject = _listUI.Table.InstantiateAsRow(_listUI._staffRowPrefab);
				TrainingMenuStaffRow component = gameObject.GetComponent<TrainingMenuStaffRow>();
				bool isSelected = availableTrainer == _trainer;
				if (!(availableTrainer is GuestTrainer guestTrainer))
				{
					component.Setup(availableTrainer, SetTrainer, null, isSelected, -1, 0);
					component.AddTrainerTooltip(availableTrainer);
				}
				else
				{
					GuestTrainerDefinition.Skill skill = guestTrainer.Definition.GetSkill(_course);
					component.Setup(guestTrainer, SetTrainer, isSelected, skill, -1, 0);
					component.AddGuestTrainerTooltip(guestTrainer, skill);
				}
				_listRows.Add(gameObject);
			}
		}

		private void RefreshSelectTraineesList()
		{
			if (_selectedPanel != _traineesUI)
			{
				return;
			}
			_listRows.ClearAndDestroy();
			_listUI.Text.SetTerm("Menu/Training/SelectATrainee");
			_availableTrainees.RemoveAll((Staff staff) => staff == null || staff.HasBeenDestroyed() || _level.CharacterManager.IsPendingDestroy(staff));
			foreach (Staff availableTrainee in _availableTrainees)
			{
				GameObject gameObject = _listUI.Table.InstantiateAsRow(_listUI._staffRowPrefab);
				TrainingMenuStaffRow component = gameObject.GetComponent<TrainingMenuStaffRow>();
				component.Setup(availableTrainee, AddTrainee, null, isSelected: false, -1, 0);
				component.AddTraineeTooltip(availableTrainee);
				_listRows.Add(gameObject);
			}
		}

		private void RefreshOptionsTraineeList()
		{
			_selectedTraineeRows.ClearAndDestroy();
			if (_availableRooms.Count == 0)
			{
				return;
			}
			foreach (Staff trainee in _trainees)
			{
				GameObject gameObject = _traineesUI.Table.InstantiateAsRow(_traineesUI._staffRowPrefab);
				TrainingMenuStaffRow component = gameObject.GetComponent<TrainingMenuStaffRow>();
				component.Setup(trainee, delegate
				{
					SelectTraineesMode();
				}, RemoveTrainee, isSelected: false, -1, 0);
				component.AddTraineeTooltip(trainee);
				_selectedTraineeRows.Add(gameObject);
			}
			if (_room == null)
			{
				return;
			}
			int num = _room.FloorPlan.MaxCapacity - _trainees.Count;
			for (int num2 = 0; num2 < num; num2++)
			{
				GameObject gameObject2 = _traineesUI.Table.InstantiateAsRow(_traineesUI._staffAddRowPrefab);
				gameObject2.GetComponent<TrainingMenuStaffRow>().Setup(null, delegate
				{
					SelectTraineesMode();
				}, null, isSelected: false, num2, _availableTrainees.Count);
				_selectedTraineeRows.Add(gameObject2);
			}
		}

		public void OnPointerDown(PointerEventData eventData)
		{
			if (eventData.button == PointerEventData.InputButton.Left && eventData.pointerEnter != null)
			{
				if ((_courseUI.Clickable1 != null && _courseUI.Clickable1.transform.IsParent(eventData.pointerEnter.transform)) || (_courseUI.Clickable2 != null && _courseUI.Clickable2.transform.IsParent(eventData.pointerEnter.transform)) || (_courseUI.PlusIcon != null && _courseUI.PlusIcon.transform.IsParent(eventData.pointerEnter.transform)))
				{
					SelectCourseMode();
				}
				else if ((_trainerUI.Clickable1 != null && _trainerUI.Clickable1.transform.IsParent(eventData.pointerEnter.transform)) || (_trainerUI.Clickable2 != null && _trainerUI.Clickable2.transform.IsParent(eventData.pointerEnter.transform)) || (_trainerUI.PlusIcon != null && _trainerUI.PlusIcon.transform.IsParent(eventData.pointerEnter.transform)))
				{
					SelectTrainerMode();
				}
				else if (_traineesUI.Panel != null && _traineesUI.Panel.transform.IsParent(eventData.pointerEnter.transform))
				{
					SelectTraineesMode();
				}
				else if (_roomUI.Panel != null && _roomUI.Panel.transform.IsParent(eventData.pointerEnter.transform))
				{
					SelectRoomMode();
				}
			}
		}

		private void CourseIconTooltipDataProvider(Tooltip tooltip)
		{
			if (_course != null)
			{
				TooltipTrainingCourse tooltipTrainingCourse = tooltip as TooltipTrainingCourse;
				if (!(tooltipTrainingCourse != null))
				{
					return;
				}
				int num = 0;
				int num2 = 0;
				foreach (Staff item in _allStaff)
				{
					if (_course.ValidForExcludeIncomplete(item))
					{
						num++;
					}
					if (item.HasCompletedQualification(_course))
					{
						num2++;
					}
				}
				tooltipTrainingCourse.SetData(_course.NameLocalised.Translation, _course.GetTooltipText(), num2, num, _course.TrainingPoints);
			}
			else
			{
				tooltip.Text = string.Empty;
			}
		}

		private void TrainerTooltipDataProvider(Tooltip tooltip)
		{
			if (_trainer != null)
			{
				GuestTrainer guestTrainer = _trainer as GuestTrainer;
				string text = GameStringUtils.StaffTitle(_trainer);
				string newValue = StringUtils.FormatPercentageValue(_trainer.GetTrainingTeachingSpeed());
				string text2 = ScriptLocalization.Menu_Training.ToolTip_TrainerTeachingSpeed_CS.Replace("{[SPEED]}", newValue);
				if (guestTrainer == null)
				{
					tooltip.Text = $"{text}\n{text2}";
					return;
				}
				GuestTrainerDefinition.Skill skill = guestTrainer.Definition.GetSkill(_course);
				string guestTrainerCostText = GameStringUtils.GetGuestTrainerCostText(guestTrainer, skill);
				string text3 = ((guestTrainer.Definition.FlavourTrait.Term != null) ? guestTrainer.Definition.FlavourTrait.Translation : "...");
				tooltip.Text = $"{text}\n{text3}\n{text2}\n{guestTrainerCostText}";
			}
			else
			{
				tooltip.Text = string.Empty;
			}
		}
	}
}
