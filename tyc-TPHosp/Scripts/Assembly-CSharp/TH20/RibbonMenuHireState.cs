using System;
using System.Collections.Generic;
using TH20.UI;
using TMPro;
using UnityEngine;

namespace TH20
{
	public class RibbonMenuHireState : MustCallDestroy
	{
		[Serializable]
		public class Settings
		{
			[Header("Prefabs")]
			public GameObject RibbonHireRowPrefab;

			public GameObject ProfileScenePrefab;

			public AdvisorLighting ProfileSceneLighting;

			[Header("Localised Strings")]
			public LocalisedString DoctorsCategoryString;

			public LocalisedString NursesCategoryString;

			public LocalisedString AssistantsCategoryString;

			public LocalisedString JanitorsCategoryString;

			public LocalisedString AllCategoryString;

			[Header("Table Settings")]
			public RectTransform TableHeader;

			public List<Table.ColumnDefinition> ColumnDefinitions;

			public int RowHeight;

			[Header("Ribbon Bar")]
			public int BarWidth;

			public int BarLeftSectionWidth;

			public GameObject[] BarGameObjects;

			[Header("Ribbon Body")]
			public RibbonMenuBodyAnimator.Target BodyAnimatorTarget;

			public int BodyHeight;

			public int BodyBackgroundWidth;

			public int BodyScrollViewWidth;

			public GameObject[] BodyGameObjects;

			[Header("Tutorial")]
			public GameObject TutorialStaffTypeGameObject;

			public GameObject TutorialHireButtonGameObject;

			[Header("GUI Components")]
			public DynamicButton DoctorsButton;

			public DynamicButton NursesButton;

			public DynamicButton AssistantsButton;

			public DynamicButton JanitorsButton;

			public DynamicButton AllStaffButton;

			public DynamicButton HireButton;

			public DynamicButton RejectButton;

			[Header("Folder Tab Backgrounds")]
			public RectTransform DoctorsTabBackground;

			public RectTransform NursesTabBackground;

			public RectTransform AssistantsTabBackground;

			public RectTransform JanitorsTabBackground;

			public RectTransform AllStaffTabBackground;

			[Space]
			public TMP_Text CategoryText;

			[Header("Staff Counts")]
			public TMP_Text EmployedDoctorsCount;

			public TMP_Text EmployedNurseCount;

			public TMP_Text EmployedJanitorCount;

			public TMP_Text EmployedAssistantCount;

			public TMP_Text EmployeStaffCount;

			[Space]
			public TooltipSpawner EmployedDoctorsTooltip;

			public TooltipSpawner EmployedNurseTooltip;

			public TooltipSpawner EmployedJanitorTooltip;

			public TooltipSpawner EmployedAssistantTooltip;

			public TooltipSpawner EmployedStaffTooltip;

			[Space]
			public LocalisedString EmployedDoctorsTooltipText;

			public LocalisedString EmployedNurseTooltipText;

			public LocalisedString EmployedJanitorTooltipText;

			public LocalisedString EmployedAssistantTooltipText;

			public LocalisedString EmployedStaffTooltipText;

			[Space]
			public ButtonAnimator DoctorsButtonAnimator;

			public ButtonAnimator NursesButtonAnimator;

			public ButtonAnimator AssistantsButtonAnimator;

			public ButtonAnimator JanitorsButtonAnimator;

			public ButtonAnimator AllStaffButtonAnimator;

			public ButtonAnimator HireButtonAnimator;

			public ButtonAnimator RejectButtonAnimator;

			public Color AffordableFeeColor = Color.white;

			public Color UnaffordableFeeColor = Color.red;

			[Header("CV GUI Components")]
			public StarIcons CVStarIcons;

			public GameObject CVGameObject;

			public TMP_Text CVApplicantNameText;

			public TMP_Text CVApplicantTitleText;

			public TMP_Text CVApplicantTraitsText;

			public TooltipSpawner CVApplicantTraitsTooltip;

			public TMP_Text CVApplicantLevelText;

			public ProgressBarMaskable CvApplicantLevelProgressBar;

			public TMP_Text CVApplicantHiringFeeText;

			public LocalisedString CVApplicantLevelString;
		}

		private Settings _settings;

		private readonly Level _level;

		private readonly List<JobApplicant> _applicants = new List<JobApplicant>(64);

		private readonly List<RibbonHireRow> _rows = new List<RibbonHireRow>(64);

		private readonly IRibbonMenuView _ribbonMenuView;

		private bool _enabled;

		private readonly GameObject _staffProfileScene;

		private List<StaffDefinition.Type> _currentStaffTypes;

		private RibbonHireRow _currentSelectedRow;

		private int _doctorCount;

		private int _nurseCount;

		private int _assistantCount;

		private int _janitorCount;

		public bool Enabled => _enabled;

		public RibbonMenuHireState(Level level, IRibbonMenuView ribbonMenuView, Settings settings)
		{
			_settings = settings;
			GameObject[] barGameObjects = _settings.BarGameObjects;
			for (int i = 0; i < barGameObjects.Length; i++)
			{
				barGameObjects[i].SetActive(value: false);
			}
			if (_settings.BodyGameObjects != null)
			{
				barGameObjects = _settings.BodyGameObjects;
				for (int i = 0; i < barGameObjects.Length; i++)
				{
					barGameObjects[i].SetActive(value: false);
				}
			}
			_staffProfileScene = UnityEngine.Object.Instantiate(_settings.ProfileScenePrefab);
			_level = level;
			_ribbonMenuView = ribbonMenuView;
			FinanceManager financeManager = _level.FinanceManager;
			financeManager.OnBalanceUpdated = (Action<int>)Delegate.Combine(financeManager.OnBalanceUpdated, new Action<int>(RefreshFeeAffordableColor));
			if (_settings.HireButton != null)
			{
				_settings.HireButton.onPrimaryDown.AddListener(delegate
				{
					if (!(_currentSelectedRow == null) && _currentSelectedRow.JobApplicant != null && _level.FinanceManager.CanAfford(_currentSelectedRow.JobApplicant.RecruitmentFee))
					{
						_level.HospitalHUDManager.TryHideRibbonMenu();
						_level.CharacterEvents.OnStaffHire.InvokeSafe(_currentSelectedRow.JobApplicant);
					}
				});
			}
			if (!(_settings.RejectButton != null))
			{
				return;
			}
			_settings.RejectButton.onPrimaryDown.AddListener(delegate
			{
				if (_currentSelectedRow != null && _currentSelectedRow.JobApplicant != null)
				{
					_level.JobApplicantManager.GetJobApplicantPool(_currentSelectedRow.JobApplicant.Definition._type).RemoveApplicant(_currentSelectedRow.JobApplicant);
					SetHireList(_currentStaffTypes);
				}
			});
		}

		public void TransitionInto()
		{
			if (!Enabled)
			{
				if (_level.BuildingLogic.CurrentState != BuildingLogic.State.Null)
				{
					_level.BuildingLogic.TransitionToNullState(applyChanges: false);
				}
				_ribbonMenuView.TransitionBody(ref _settings.BodyAnimatorTarget, _settings.BodyGameObjects);
				_ribbonMenuView.SetStaffTypeButtonsActive(active: true);
				_ribbonMenuView.SetTableHeadersActive(active: true);
				_ribbonMenuView.SetTableRowFilter(null);
				_ribbonMenuView.SetTableColumnHeaders(_settings.TableHeader);
				_ribbonMenuView.SetTableColumnDefinitions(_settings.ColumnDefinitions);
				_ribbonMenuView.SetTableRowHeight(_settings.RowHeight);
				_ribbonMenuView.SetTableDirtyLayout();
				_settings.DoctorsButton.onPrimaryDown.AddListener(delegate
				{
					SetHireList(default(StaffDefinition.Type));
				});
				_settings.NursesButton.onPrimaryDown.AddListener(delegate
				{
					SetHireList(StaffDefinition.Type.Nurse);
				});
				_settings.AssistantsButton.onPrimaryDown.AddListener(delegate
				{
					SetHireList(StaffDefinition.Type.Assistant);
				});
				_settings.JanitorsButton.onPrimaryDown.AddListener(delegate
				{
					SetHireList(StaffDefinition.Type.Janitor);
				});
				_settings.AllStaffButton.onPrimaryDown.AddListener(delegate
				{
					SetHireList(StaffDefinition.Type.Doctor, StaffDefinition.Type.Nurse, StaffDefinition.Type.Assistant, StaffDefinition.Type.Janitor);
				});
				RefreshEmploymentCount();
				CharacterEvents characterEvents = _level.CharacterEvents;
				characterEvents.OnStaffResigned = (Action<Staff>)Delegate.Combine(characterEvents.OnStaffResigned, new Action<Staff>(OnStaffResigned));
				CharacterEvents characterEvents2 = _level.CharacterEvents;
				characterEvents2.OnStaffFired = (Action<Staff>)Delegate.Combine(characterEvents2.OnStaffFired, new Action<Staff>(OnStaffFired));
				JobApplicantManager jobApplicantManager = _level.JobApplicantManager;
				jobApplicantManager.OnJobApplicantAdded = (Action<JobApplicantPool, JobApplicant>)Delegate.Combine(jobApplicantManager.OnJobApplicantAdded, new Action<JobApplicantPool, JobApplicant>(OnJobApplicantChanged));
				JobApplicantManager jobApplicantManager2 = _level.JobApplicantManager;
				jobApplicantManager2.OnJobApplicantRemoved = (Action<JobApplicantPool, JobApplicant>)Delegate.Combine(jobApplicantManager2.OnJobApplicantRemoved, new Action<JobApplicantPool, JobApplicant>(OnJobApplicantChanged));
				FinanceManager financeManager = _level.FinanceManager;
				financeManager.OnBalanceUpdated = (Action<int>)Delegate.Combine(financeManager.OnBalanceUpdated, new Action<int>(OnBalanceUpdated));
				SetHireList(_level.HospitalHUDManager.LastSelectedHireStaffType);
				_enabled = true;
			}
		}

		public void TransitionOut()
		{
			if (Enabled)
			{
				UnregisterEvents();
				_enabled = false;
			}
		}

		private void UnregisterEvents()
		{
			CharacterEvents characterEvents = _level.CharacterEvents;
			characterEvents.OnStaffResigned = (Action<Staff>)Delegate.Remove(characterEvents.OnStaffResigned, new Action<Staff>(OnStaffResigned));
			CharacterEvents characterEvents2 = _level.CharacterEvents;
			characterEvents2.OnStaffFired = (Action<Staff>)Delegate.Remove(characterEvents2.OnStaffFired, new Action<Staff>(OnStaffFired));
			JobApplicantManager jobApplicantManager = _level.JobApplicantManager;
			jobApplicantManager.OnJobApplicantAdded = (Action<JobApplicantPool, JobApplicant>)Delegate.Remove(jobApplicantManager.OnJobApplicantAdded, new Action<JobApplicantPool, JobApplicant>(OnJobApplicantChanged));
			JobApplicantManager jobApplicantManager2 = _level.JobApplicantManager;
			jobApplicantManager2.OnJobApplicantRemoved = (Action<JobApplicantPool, JobApplicant>)Delegate.Remove(jobApplicantManager2.OnJobApplicantRemoved, new Action<JobApplicantPool, JobApplicant>(OnJobApplicantChanged));
			FinanceManager financeManager = _level.FinanceManager;
			financeManager.OnBalanceUpdated = (Action<int>)Delegate.Remove(financeManager.OnBalanceUpdated, new Action<int>(OnBalanceUpdated));
		}

		private void RefreshEmploymentCount()
		{
			_assistantCount = 0;
			_doctorCount = 0;
			_janitorCount = 0;
			_nurseCount = 0;
			foreach (Staff staffMember in _level.CharacterManager.StaffMembers)
			{
				if (staffMember.CurrentMode != Staff.Mode.Resigned && staffMember.CurrentMode != Staff.Mode.Fired)
				{
					switch (staffMember.Definition._type)
					{
					case StaffDefinition.Type.Assistant:
						_assistantCount++;
						break;
					case StaffDefinition.Type.Doctor:
						_doctorCount++;
						break;
					case StaffDefinition.Type.Janitor:
						_janitorCount++;
						break;
					case StaffDefinition.Type.Nurse:
						_nurseCount++;
						break;
					}
				}
			}
			_settings.EmployedDoctorsCount.text = _doctorCount.ToString("0");
			_settings.EmployedAssistantCount.text = _assistantCount.ToString("0");
			_settings.EmployedJanitorCount.text = _janitorCount.ToString("0");
			_settings.EmployedNurseCount.text = _nurseCount.ToString("0");
			int allStaffCount = _doctorCount + _assistantCount + _janitorCount + _nurseCount;
			_settings.EmployeStaffCount.text = allStaffCount.ToString("0");
			_settings.EmployedDoctorsTooltip.SetDataProvider(delegate(Tooltip tooltip)
			{
				tooltip.Text = FormatStaffCountTooltip(_settings.EmployedDoctorsTooltipText.Translation, _doctorCount, StaffDefinition.Type.Doctor);
			});
			_settings.EmployedNurseTooltip.SetDataProvider(delegate(Tooltip tooltip)
			{
				tooltip.Text = FormatStaffCountTooltip(_settings.EmployedNurseTooltipText.Translation, _nurseCount, StaffDefinition.Type.Nurse);
			});
			_settings.EmployedAssistantTooltip.SetDataProvider(delegate(Tooltip tooltip)
			{
				tooltip.Text = FormatStaffCountTooltip(_settings.EmployedAssistantTooltipText.Translation, _assistantCount, StaffDefinition.Type.Assistant);
			});
			_settings.EmployedJanitorTooltip.SetDataProvider(delegate(Tooltip tooltip)
			{
				tooltip.Text = FormatStaffCountTooltip(_settings.EmployedJanitorTooltipText.Translation, _janitorCount, StaffDefinition.Type.Janitor);
			});
			_settings.EmployedStaffTooltip.SetDataProvider(delegate(Tooltip tooltip)
			{
				tooltip.Text = FormatStaffCountTooltip(_settings.EmployedStaffTooltipText.Translation, allStaffCount, StaffDefinition.Type.None);
			});
		}

		private string FormatStaffCountTooltip(string text, int employedCount, StaffDefinition.Type staffType)
		{
			int num;
			if (staffType != StaffDefinition.Type.None)
			{
				num = _level.JobApplicantManager.GetJobApplicantPool(staffType).Applicants.Count;
			}
			else
			{
				num = _level.JobApplicantManager.GetJobApplicantPool(StaffDefinition.Type.Doctor).Applicants.Count;
				num += _level.JobApplicantManager.GetJobApplicantPool(StaffDefinition.Type.Nurse).Applicants.Count;
				num += _level.JobApplicantManager.GetJobApplicantPool(StaffDefinition.Type.Assistant).Applicants.Count;
				num += _level.JobApplicantManager.GetJobApplicantPool(StaffDefinition.Type.Janitor).Applicants.Count;
			}
			return text.Replace("\\n", "\n").Replace("{[APPLICANTS]}", num.ToString("0")).Replace("{[EMPLOYED]}", employedCount.ToString("0"));
		}

		private void OnBalanceUpdated(int newBalance)
		{
			foreach (RibbonHireRow row in _rows)
			{
				if (row.JobApplicant != null)
				{
					row.SetCanHire(newBalance >= row.JobApplicant.RecruitmentFee);
				}
			}
		}

		private void OnJobApplicantChanged(JobApplicantPool pool, JobApplicant applicant)
		{
			if (_currentStaffTypes.Contains(applicant.Definition._type))
			{
				SetHireList(_currentStaffTypes);
			}
		}

		private void OnStaffResigned(Staff staff)
		{
			switch (staff.Definition._type)
			{
			case StaffDefinition.Type.Assistant:
				_assistantCount--;
				_settings.EmployedAssistantCount.text = _assistantCount.ToString("0");
				break;
			case StaffDefinition.Type.Doctor:
				_doctorCount--;
				_settings.EmployedDoctorsCount.text = _doctorCount.ToString("0");
				break;
			case StaffDefinition.Type.Janitor:
				_janitorCount--;
				_settings.EmployedJanitorCount.text = _janitorCount.ToString("0");
				break;
			case StaffDefinition.Type.Nurse:
				_nurseCount--;
				_settings.EmployedNurseCount.text = _nurseCount.ToString("0");
				break;
			}
			_settings.EmployeStaffCount.text = (_doctorCount + _assistantCount + _janitorCount + _nurseCount).ToString("0");
		}

		private void OnStaffFired(Staff staff)
		{
			switch (staff.Definition._type)
			{
			case StaffDefinition.Type.Assistant:
				_assistantCount--;
				_settings.EmployedAssistantCount.text = _assistantCount.ToString("0");
				break;
			case StaffDefinition.Type.Doctor:
				_doctorCount--;
				_settings.EmployedDoctorsCount.text = _doctorCount.ToString("0");
				break;
			case StaffDefinition.Type.Janitor:
				_janitorCount--;
				_settings.EmployedJanitorCount.text = _janitorCount.ToString("0");
				break;
			case StaffDefinition.Type.Nurse:
				_nurseCount--;
				_settings.EmployedNurseCount.text = _nurseCount.ToString("0");
				break;
			}
			_settings.EmployeStaffCount.text = (_doctorCount + _assistantCount + _janitorCount + _nurseCount).ToString("0");
		}

		private void SetHireList(params StaffDefinition.Type[] staffTypes)
		{
			SetHireList(new List<StaffDefinition.Type>(staffTypes));
		}

		private void SetHireList(List<StaffDefinition.Type> staffTypes)
		{
			_ribbonMenuView.EnableTable();
			_settings.CVGameObject.SetActive(value: false);
			_currentStaffTypes = staffTypes;
			JobApplicant jobApplicant = ((_currentSelectedRow != null) ? _currentSelectedRow.JobApplicant : null);
			_currentSelectedRow = null;
			if (_currentStaffTypes.Count == 1)
			{
				_settings.DoctorsTabBackground.gameObject.SetActive(value: false);
				_settings.NursesTabBackground.gameObject.SetActive(value: false);
				_settings.AssistantsTabBackground.gameObject.SetActive(value: false);
				_settings.JanitorsTabBackground.gameObject.SetActive(value: false);
				_settings.AllStaffTabBackground.gameObject.SetActive(value: false);
				_settings.DoctorsButtonAnimator.CurrentState = (_currentStaffTypes.Contains(StaffDefinition.Type.Doctor) ? ButtonAnimator.State.Selected : ButtonAnimator.State.Selectable);
				_settings.NursesButtonAnimator.CurrentState = (_currentStaffTypes.Contains(StaffDefinition.Type.Nurse) ? ButtonAnimator.State.Selected : ButtonAnimator.State.Selectable);
				_settings.AssistantsButtonAnimator.CurrentState = (_currentStaffTypes.Contains(StaffDefinition.Type.Assistant) ? ButtonAnimator.State.Selected : ButtonAnimator.State.Selectable);
				_settings.JanitorsButtonAnimator.CurrentState = (_currentStaffTypes.Contains(StaffDefinition.Type.Janitor) ? ButtonAnimator.State.Selected : ButtonAnimator.State.Selectable);
				_settings.AllStaffButtonAnimator.CurrentState = ButtonAnimator.State.Selectable;
				switch (_currentStaffTypes[0])
				{
				case StaffDefinition.Type.Doctor:
					_settings.DoctorsTabBackground.gameObject.SetActive(value: true);
					_settings.CategoryText.text = _settings.DoctorsCategoryString.Translation;
					break;
				case StaffDefinition.Type.Nurse:
					_settings.NursesTabBackground.gameObject.SetActive(value: true);
					_settings.CategoryText.text = _settings.NursesCategoryString.Translation;
					break;
				case StaffDefinition.Type.Assistant:
					_settings.AssistantsTabBackground.gameObject.SetActive(value: true);
					_settings.CategoryText.text = _settings.AssistantsCategoryString.Translation;
					break;
				case StaffDefinition.Type.Janitor:
					_settings.JanitorsTabBackground.gameObject.SetActive(value: true);
					_settings.CategoryText.text = _settings.JanitorsCategoryString.Translation;
					break;
				}
			}
			else
			{
				_settings.DoctorsTabBackground.gameObject.SetActive(value: false);
				_settings.NursesTabBackground.gameObject.SetActive(value: false);
				_settings.AssistantsTabBackground.gameObject.SetActive(value: false);
				_settings.JanitorsTabBackground.gameObject.SetActive(value: false);
				_settings.AllStaffTabBackground.gameObject.SetActive(value: true);
				_settings.DoctorsButtonAnimator.CurrentState = ButtonAnimator.State.Selectable;
				_settings.NursesButtonAnimator.CurrentState = ButtonAnimator.State.Selectable;
				_settings.AssistantsButtonAnimator.CurrentState = ButtonAnimator.State.Selectable;
				_settings.JanitorsButtonAnimator.CurrentState = ButtonAnimator.State.Selectable;
				_settings.AllStaffButtonAnimator.CurrentState = ButtonAnimator.State.Selected;
				_settings.CategoryText.text = _settings.AllCategoryString.Translation;
			}
			_ribbonMenuView.DestroyAllListItems();
			_applicants.Clear();
			foreach (StaffDefinition.Type currentStaffType in _currentStaffTypes)
			{
				_applicants.AddRange(_level.JobApplicantManager.GetJobApplicantPool(currentStaffType).Applicants);
			}
			_rows.Clear();
			for (int i = 0; i < _applicants.Count; i++)
			{
				JobApplicant applicant = _applicants[i];
				GameObject gameObject = _ribbonMenuView.InstantiateAsRowInTable(_settings.RibbonHireRowPrefab);
				RibbonHireRow ribbonHireRow = gameObject.GetComponent<RibbonHireRow>();
				ribbonHireRow.SetupAsJobApplicant(applicant, _level.HUD.GetConfig().MugshotConfig, _level);
				ribbonHireRow.Button.onPrimaryDown.AddListener(delegate
				{
					TrySelectItem(ribbonHireRow);
				});
				if (ribbonHireRow.HireButton != null)
				{
					ribbonHireRow.HireButton.onPrimaryDown.AddListener(delegate
					{
						if (applicant != null)
						{
							_level.HospitalHUDManager.TryHideRibbonMenu();
							_level.CharacterEvents.OnStaffHire.InvokeSafe(applicant);
						}
					});
				}
				if (ribbonHireRow.RejectButton != null)
				{
					ribbonHireRow.RejectButton.onPrimaryDown.AddListener(delegate
					{
						if (applicant != null)
						{
							_level.JobApplicantManager.GetJobApplicantPool(applicant.Definition._type).RemoveApplicant(applicant);
							SetHireList(_currentStaffTypes);
						}
					});
				}
				ribbonHireRow.SetCanHire(_level.FinanceManager.Balance >= applicant.RecruitmentFee);
				_rows.Add(ribbonHireRow);
			}
			if (jobApplicant != null)
			{
				foreach (RibbonHireRow row in _rows)
				{
					if (row.JobApplicant == jobApplicant)
					{
						SetSelectedRow(row);
						break;
					}
				}
			}
			if (_currentSelectedRow == null)
			{
				SetSelectedRow(null);
			}
			if (_currentStaffTypes.Count == 1)
			{
				JobApplicantPool jobApplicantPool = _level.JobApplicantManager.GetJobApplicantPool(_currentStaffTypes[0]);
				int num = jobApplicantPool.MaximumSize() - _applicants.Count;
				for (int num2 = 0; num2 < num; num2++)
				{
					RibbonHireRow component = _ribbonMenuView.InstantiateAsRowInTable(_settings.RibbonHireRowPrefab).GetComponent<RibbonHireRow>();
					if (num2 == 0)
					{
						component.SetupAsPendingApplicant(jobApplicantPool);
					}
					else
					{
						component.SetupAsPendingApplicant(null);
					}
				}
				int num3 = jobApplicantPool.MaximumSize();
				if (num3 < jobApplicantPool.MaximumSizePossible())
				{
					RibbonHireRow component2 = _ribbonMenuView.InstantiateAsRowInTable(_settings.RibbonHireRowPrefab).GetComponent<RibbonHireRow>();
					component2.SetupAsLockedEntry(_level.PrestigeTracker, jobApplicantPool.GetSlotUnlockLevel(num3));
					_rows.Add(component2);
				}
			}
			_ribbonMenuView.ResortTable();
			_level.HospitalHUDManager.LastSelectedHireStaffType = _currentStaffTypes;
		}

		private void TrySelectItem(RibbonHireRow ribbonHireRow)
		{
			_ribbonMenuView.PlaySelectItemSFX();
			if (!(_currentSelectedRow == ribbonHireRow))
			{
				SetSelectedRow(ribbonHireRow);
			}
		}

		private void SetSelectedRow(RibbonHireRow row)
		{
			RibbonHireRow currentSelectedRow = _currentSelectedRow;
			_currentSelectedRow = row;
			RefreshRowMode(currentSelectedRow);
			RefreshRowMode(_currentSelectedRow);
			bool flag = row != null && row.JobApplicant != null;
			if (_settings.HireButton != null)
			{
				_settings.HireButton.interactable = flag;
				_settings.HireButtonAnimator.CurrentState = ((!flag) ? ButtonAnimator.State.Unselectable : ButtonAnimator.State.Selectable);
			}
			if (_settings.RejectButton != null)
			{
				_settings.RejectButton.interactable = flag;
				_settings.RejectButtonAnimator.CurrentState = ((!flag) ? ButtonAnimator.State.Unselectable : ButtonAnimator.State.Selectable);
			}
			if (_currentSelectedRow != null)
			{
				JobApplicant applicant = _currentSelectedRow.JobApplicant;
				_settings.CVGameObject.SetActive(value: true);
				_settings.CVApplicantNameText.text = applicant.Name.GetCharacterName();
				_settings.CVStarIcons.SetLevel(applicant.Rank, readyForPromotion: false, applicant.Experience / applicant.RankDefinition.MaximumXP);
				_settings.CVApplicantTitleText.text = applicant.RankDefinition.GetTitleLocalised(applicant.Sex).Translation;
				_settings.CVApplicantTraitsText.text = applicant.Traits.GetDescription(applicant.Sex);
				_settings.CVApplicantTraitsTooltip.SetDataProvider(delegate(Tooltip tooltip)
				{
					tooltip.Text = applicant.Traits.GetTooltipText(applicant.Sex);
				});
				_settings.CVApplicantLevelText.text = _settings.CVApplicantLevelString.Translation.Replace("{[LEVEL]}", (applicant.Rank + 1).ToString());
				_settings.CvApplicantLevelProgressBar.Progress = applicant.Experience / applicant.RankDefinition.MaximumXP;
				_settings.CVApplicantHiringFeeText.text = StringUtils.FormatCurrencyWithoutSymbol(applicant.RecruitmentFee);
				RefreshFeeAffordableColor(_level.FinanceManager.Balance);
				_staffProfileScene.GetComponent<StaffProfileScene>().SetCharacter(applicant.Definition, applicant.CharModuleAssets, applicant.Sex, _settings.ProfileSceneLighting, _level.CharacterManager.GetDefaultSaffCustomisationOption(applicant.Definition._type));
			}
			else
			{
				_settings.CVGameObject.SetActive(value: false);
			}
		}

		private void RefreshFeeAffordableColor(int newBalance)
		{
			if (_currentSelectedRow == null)
			{
				return;
			}
			JobApplicant jobApplicant = _currentSelectedRow.JobApplicant;
			if (jobApplicant != null)
			{
				bool flag = _level.FinanceManager.CanAfford(jobApplicant.RecruitmentFee);
				_settings.CVApplicantHiringFeeText.color = (flag ? _settings.AffordableFeeColor : _settings.UnaffordableFeeColor);
				if (_settings.HireButtonAnimator != null)
				{
					_settings.HireButtonAnimator.CurrentState = ((!flag) ? ButtonAnimator.State.Unselectable : ButtonAnimator.State.Selectable);
				}
			}
		}

		private void RefreshRowMode(RibbonHireRow row)
		{
			if (!(row == null))
			{
				if (_currentSelectedRow == row)
				{
					row.ButtonAnimator.CurrentState = ButtonAnimator.State.Selected;
				}
				else
				{
					row.ButtonAnimator.CurrentState = ButtonAnimator.State.Selectable;
				}
			}
		}

		public void ShowTutorialStaffTypeHighlight(bool show, StaffDefinition.Type staffType)
		{
			GameObjectUtils.SetActive(_settings.TutorialStaffTypeGameObject, show);
			if (show)
			{
				switch (staffType)
				{
				case StaffDefinition.Type.Doctor:
					_settings.TutorialStaffTypeGameObject.transform.position = _settings.DoctorsButtonAnimator.Button.transform.position;
					break;
				case StaffDefinition.Type.Nurse:
					_settings.TutorialStaffTypeGameObject.transform.position = _settings.NursesButtonAnimator.Button.transform.position;
					break;
				case StaffDefinition.Type.Janitor:
					_settings.TutorialStaffTypeGameObject.transform.position = _settings.JanitorsButtonAnimator.Button.transform.position;
					break;
				case StaffDefinition.Type.Assistant:
					_settings.TutorialStaffTypeGameObject.transform.position = _settings.AssistantsButtonAnimator.Button.transform.position;
					break;
				}
			}
		}

		public void ShowTutorialHireButton(bool show)
		{
			GameObjectUtils.SetActive(_settings.TutorialHireButtonGameObject, show);
		}

		public override void Destroy()
		{
			CharacterEvents characterEvents = _level.CharacterEvents;
			characterEvents.OnStaffResigned = (Action<Staff>)Delegate.Remove(characterEvents.OnStaffResigned, new Action<Staff>(OnStaffResigned));
			FinanceManager financeManager = _level.FinanceManager;
			financeManager.OnBalanceUpdated = (Action<int>)Delegate.Remove(financeManager.OnBalanceUpdated, new Action<int>(RefreshFeeAffordableColor));
			UnityEngine.Object.Destroy(_staffProfileScene);
			if (Enabled)
			{
				UnregisterEvents();
			}
			base.Destroy();
		}
	}
}
