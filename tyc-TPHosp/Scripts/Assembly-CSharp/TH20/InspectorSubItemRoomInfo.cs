using System;
using System.Collections.Generic;
using I2.Loc;
using JetBrains.Annotations;
using TH20.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class InspectorSubItemRoomInfo : InspectorSubItem
	{
		[Serializable]
		[UsedImplicitly(ImplicitUseTargetFlags.Members)]
		private struct InfoRow
		{
			public TMP_Text Text;

			public GameObject Icon;

			public Image Image;

			public void Set(bool active, string text, Sprite icon, Color? color = null)
			{
				Text.text = text;
				if (icon != null)
				{
					Image.sprite = icon;
					Image.color = Color.white;
				}
				else
				{
					Image.color = Color.clear;
				}
				if (color.HasValue)
				{
					Text.color = color.Value;
				}
				GameObjectUtils.SetActive(Icon, active);
				GameObjectUtils.SetActive(Text.gameObject, active);
			}
		}

		[Serializable]
		[UsedImplicitly(ImplicitUseTargetFlags.Members)]
		private struct TrainingPanel
		{
			public GameObject PanelRoot;

			public InfoRow Course;

			public InfoRow Trainer;
		}

		[Serializable]
		[UsedImplicitly(ImplicitUseTargetFlags.Members)]
		private struct StaffListPanel
		{
			public GameObject PanelRoot;

			public GameObject ListRoot;

			public GameObject ElementPrefab;
		}

		[SerializeField]
		private GameObject _queuePanel;

		[SerializeField]
		private InfoRow _queueLengthText;

		[SerializeField]
		private InfoRow _itemRequiredText;

		[SerializeField]
		private Color _queueLengthColor;

		[SerializeField]
		private Color _queueLengthDisabled;

		[SerializeField]
		private TrainingPanel _trainingPanel;

		[SerializeField]
		private StaffListPanel _staffListPanel;

		[SerializeField]
		private TMP_Text _roomValueText;

		[SerializeField]
		private TMP_Text _patientsProcessedText;

		[SerializeField]
		private TMP_Text _totalRevenueText;

		[SerializeField]
		private ProgressBarMaskable _prestigeBar;

		[SerializeField]
		private TMP_Text _prestigeLevelText;

		[SerializeField]
		private ProgressBarMaskable _attractivenessBar;

		[SerializeField]
		private TooltipSpawner _attractivenessTooltip;

		[SerializeField]
		private ProgressBarMaskable _temperatureBar;

		[SerializeField]
		private TooltipSpawner _temperatureTooltip;

		[SerializeField]
		private ProgressBarMaskable _hygieneBar;

		[SerializeField]
		private TooltipSpawner _hygieneTooltip;

		[SerializeField]
		private GameObject _whoCanUseGameObject;

		[SerializeField]
		private DynamicButton _maleButton;

		[SerializeField]
		private DynamicButton _femaleButton;

		[SerializeField]
		private DynamicButton _staffButton;

		[SerializeField]
		private DynamicButton _patientsButton;

		[SerializeField]
		private DynamicButton _doctorButton;

		[SerializeField]
		private DynamicButton _nurseButton;

		[SerializeField]
		private DynamicButton _janitorButton;

		[SerializeField]
		private DynamicButton _assistantButton;

		[SerializeField]
		private GameObject _extraStaffRoot;

		[SerializeField]
		private TMP_Text _extraStaffCountText;

		[SerializeField]
		private DynamicButton _extraStaffAddButton;

		[SerializeField]
		private DynamicButton _extraStaffRemoveButton;

		[SerializeField]
		private GameObject _useTypeRoot;

		[SerializeField]
		private DynamicButton _useDiagnosisButton;

		[SerializeField]
		private DynamicButton _useTreatmentButton;

		[SerializeField]
		private Color _useTypeButtonDisabledColor = Color.gray;

		[SerializeField]
		private GameObject _useEraRoot;

		[SerializeField]
		private DynamicButton _useEraPrehistoryButton;

		[SerializeField]
		private DynamicButton _useEraMedievalButton;

		[SerializeField]
		private DynamicButton _useEraPresentButton;

		[SerializeField]
		private Color _useEraButtonDisabledColor = Color.gray;

		private Room _room;

		private RoomExtraStaffJobsComponent _extraStaffComponent;

		private List<Job> _jobs = new List<Job>();

		public void Setup(Room room)
		{
			_room = room;
			GetJobList();
			WhoCanUseRoom.GroupDefinition[] definition = _room.WhoCanUse.Definition;
			bool flag = definition != null && definition.Length != 0;
			GameObjectUtils.SetActive(_whoCanUseGameObject, flag);
			_attractivenessTooltip.SetDataProvider(OnAttractivenessTooltip);
			_temperatureTooltip.SetDataProvider(OnTemperatureTooltip);
			_hygieneTooltip.SetDataProvider(OnHygieneTooltip);
			if (flag)
			{
				GameObjectUtils.SetActive(_maleButton.gameObject, isActive: false);
				GameObjectUtils.SetActive(_femaleButton.gameObject, isActive: false);
				GameObjectUtils.SetActive(_staffButton.gameObject, isActive: false);
				GameObjectUtils.SetActive(_patientsButton.gameObject, isActive: false);
				GameObjectUtils.SetActive(_doctorButton.gameObject, isActive: false);
				GameObjectUtils.SetActive(_nurseButton.gameObject, isActive: false);
				GameObjectUtils.SetActive(_janitorButton.gameObject, isActive: false);
				GameObjectUtils.SetActive(_assistantButton.gameObject, isActive: false);
				for (int i = 0; i < definition.Length; i++)
				{
					WhoCanUseRoom.GroupDefinition groupDefinition = definition[i];
					for (int j = 0; j < groupDefinition.Members.Length; j++)
					{
						DynamicButton dynamicButton = _room.WhoCanUse.GetMember(i, j) switch
						{
							WhoCanUseRoom.MemberType.Male => _maleButton, 
							WhoCanUseRoom.MemberType.Female => _femaleButton, 
							WhoCanUseRoom.MemberType.Staff => _staffButton, 
							WhoCanUseRoom.MemberType.Patients => _patientsButton, 
							WhoCanUseRoom.MemberType.Doctors => _doctorButton, 
							WhoCanUseRoom.MemberType.Nurses => _nurseButton, 
							WhoCanUseRoom.MemberType.Janitors => _janitorButton, 
							WhoCanUseRoom.MemberType.Assistants => _assistantButton, 
							_ => throw new ArgumentOutOfRangeException(), 
						};
						GameObjectUtils.SetActive(dynamicButton.gameObject, isActive: true);
						bool flag2 = _room.WhoCanUse.IsMember(i, j);
						dynamicButton.image.color = (flag2 ? Color.white : Color.gray);
						int localGroupIndex = i;
						int localMemberIndex = j;
						DynamicButton localButton = dynamicButton;
						dynamicButton.onPrimaryDown.RemoveAllListeners();
						dynamicButton.onPrimaryDown.AddListener(delegate
						{
							bool flag3 = _room.WhoCanUse.ToggleMember(localGroupIndex, localMemberIndex);
							localButton.image.color = (flag3 ? Color.white : Color.gray);
						});
					}
				}
			}
			GameObjectUtils.SetActive(_queuePanel, _room.Definition._canManageQueue);
			SetTrainingInfo();
			RefreshStaffList();
			_extraStaffAddButton.onPrimaryDown.RemoveAllListeners();
			_extraStaffRemoveButton.onPrimaryDown.RemoveAllListeners();
			_extraStaffComponent = _room.GetComponent<RoomExtraStaffJobsComponent>();
			if (_extraStaffComponent != null)
			{
				_extraStaffAddButton.onPrimaryDown.AddListener(delegate
				{
					_extraStaffComponent.AddJob();
					GetJobList();
				});
				_extraStaffRemoveButton.onPrimaryDown.AddListener(delegate
				{
					_extraStaffComponent.RemoveJob();
					GetJobList();
				});
				_extraStaffCountText.text = _extraStaffComponent.NumExtraStaff.ToString();
				GameObjectUtils.SetActive(_extraStaffRoot, isActive: true);
			}
			else
			{
				GameObjectUtils.SetActive(_extraStaffRoot, isActive: false);
			}
			_useDiagnosisButton.onPrimaryDown.RemoveAllListeners();
			_useTreatmentButton.onPrimaryDown.RemoveAllListeners();
			RoomUseTypeComponent useTypeComponent = _room.GetComponent<RoomUseTypeComponent>();
			if (useTypeComponent != null)
			{
				RefreshUseTypeButtonState(useTypeComponent);
				_useDiagnosisButton.onPrimaryDown.AddListener(delegate
				{
					RoomUseTypeComponent roomUseTypeComponent = useTypeComponent;
					roomUseTypeComponent.Diagnosis = !roomUseTypeComponent.Diagnosis;
					RefreshUseTypeButtonState(useTypeComponent);
				});
				_useTreatmentButton.onPrimaryDown.AddListener(delegate
				{
					RoomUseTypeComponent roomUseTypeComponent = useTypeComponent;
					roomUseTypeComponent.Treatment = !roomUseTypeComponent.Treatment;
					RefreshUseTypeButtonState(useTypeComponent);
				});
				GameObjectUtils.SetActive(_useTypeRoot, isActive: true);
			}
			else
			{
				GameObjectUtils.SetActive(_useTypeRoot, isActive: false);
			}
			_useEraPrehistoryButton.onPrimaryDown.RemoveAllListeners();
			_useEraMedievalButton.onPrimaryDown.RemoveAllListeners();
			_useEraPresentButton.onPrimaryDown.RemoveAllListeners();
			RoomUseEraComponent useEraComponent = _room.GetComponent<RoomUseEraComponent>();
			if (useEraComponent != null)
			{
				RefreshUseEraButtonState(useEraComponent);
				_useEraPrehistoryButton.onPrimaryDown.AddListener(delegate
				{
					RoomUseEraComponent roomUseEraComponent = useEraComponent;
					roomUseEraComponent.EraPrehistory = !roomUseEraComponent.EraPrehistory;
					RefreshUseEraButtonState(useEraComponent);
				});
				_useEraMedievalButton.onPrimaryDown.AddListener(delegate
				{
					RoomUseEraComponent roomUseEraComponent = useEraComponent;
					roomUseEraComponent.EraMedieval = !roomUseEraComponent.EraMedieval;
					RefreshUseEraButtonState(useEraComponent);
				});
				_useEraPresentButton.onPrimaryDown.AddListener(delegate
				{
					RoomUseEraComponent roomUseEraComponent = useEraComponent;
					roomUseEraComponent.EraPresent = !roomUseEraComponent.EraPresent;
					RefreshUseEraButtonState(useEraComponent);
				});
				GameObjectUtils.SetActive(_useEraRoot, isActive: true);
			}
			else
			{
				GameObjectUtils.SetActive(_useEraRoot, isActive: false);
			}
		}

		private void RefreshUseTypeButtonState(RoomUseTypeComponent useTypeComponent)
		{
			_useDiagnosisButton.image.color = (useTypeComponent.Diagnosis ? Color.white : _useTypeButtonDisabledColor);
			_useTreatmentButton.image.color = (useTypeComponent.Treatment ? Color.white : _useTypeButtonDisabledColor);
		}

		private void RefreshUseEraButtonState(RoomUseEraComponent useEraComponent)
		{
			_useEraPrehistoryButton.image.color = (useEraComponent.EraPrehistory ? Color.white : _useEraButtonDisabledColor);
			_useEraMedievalButton.image.color = (useEraComponent.EraMedieval ? Color.white : _useEraButtonDisabledColor);
			_useEraPresentButton.image.color = (useEraComponent.EraPresent ? Color.white : _useEraButtonDisabledColor);
		}

		private void SetTrainingInfo()
		{
			RoomLogicTrainingRoom component = _room.GetComponent<RoomLogicTrainingRoom>();
			if (component != null)
			{
				if (component.Qualification != null)
				{
					string text = ScriptLocalization.Inspector_Room_Training.AssignedCourse_CS.Replace("{[QUALIFICATION]}", component.Qualification.NameLocalised.Translation);
					_trainingPanel.Course.Set(active: true, text, component.Qualification.Icon, Color.white);
					if (component.Teacher != null)
					{
						string text2 = ScriptLocalization.Inspector_Room_Training.AssignedTrainer_CS.Replace("{[STAFF]}", component.Teacher.Name);
						_trainingPanel.Trainer.Set(active: true, text2, component.Teacher.Definition._icon);
					}
					else
					{
						_trainingPanel.Trainer.Set(active: false, null, null);
					}
				}
				else
				{
					_trainingPanel.Course.Set(active: true, ScriptLocalization.Inspector_Room_Training.NoAssignedCourse_CS, null, Color.grey);
					_trainingPanel.Trainer.Set(active: false, null, null);
				}
			}
			GameObjectUtils.SetActive(_trainingPanel.PanelRoot, component != null);
		}

		private void Update()
		{
			if (_room != null)
			{
				_attractivenessBar.Progress = GetAverageRoomAttractiveness();
				_hygieneBar.Progress = GetAverageRoomHygiene();
				_temperatureBar.Progress = GetAverageRoomTemperature();
				WhoCanUseRoom.GroupDefinition[] definition = _room.WhoCanUse.Definition;
				bool flag = definition != null && definition.Length != 0;
				string text = ScriptLocalization.Menu.Hover_Room_QueueLength_CS.Replace("{[LENGTH]}", _room.QueueLength.ToString());
				_queueLengthText.Set(!flag, text, null, (_room.Queue.Count > 0) ? _queueLengthColor : _queueLengthDisabled);
				SetTrainingInfo();
				RefreshStaffList();
				string requiredItemString = GetRequiredItemString();
				Sprite requiredItemIcon = GetRequiredItemIcon();
				_itemRequiredText.Set(requiredItemString != null, requiredItemString, requiredItemIcon);
				RoomPrestige roomPrestige = GameAlgorithms.CalculateRoomPrestige(_room.FloorPlan);
				_prestigeLevelText.text = $"{ScriptLocalization.Menu_TimeAndStats.PrestigeLevel_CS} {roomPrestige.Level}";
				_prestigeBar.Progress = roomPrestige.Progress;
				int num = GameAlgorithms.CalculateSellCostOfRoom(_room.FloorPlan);
				_roomValueText.text = string.Format("{0}{2}{1}", ScriptLocalization.Inspector_Room.RoomValue_CS, StringUtils.FormatCurrency(num), ScriptLocalization.Misc.ColonSeparator_CS);
				_totalRevenueText.text = string.Format("{0}{2}{1}", ScriptLocalization.Inspector_Room.TotalRevenue_CS, StringUtils.FormatCurrency(_room.TotalRevenue), ScriptLocalization.Misc.ColonSeparator_CS);
				GameObjectUtils.SetActive(_totalRevenueText.gameObject, _room.Definition._showTotalRevenueInGUI);
				bool flag2 = _room.Definition._showUnitsProcessedInGUI && _room.Definition._unitsProcessedStringInGUI.Term != null;
				if (flag2)
				{
					_patientsProcessedText.text = string.Format("{0}{2}{1}", _room.Definition._unitsProcessedStringInGUI.Translation, StringUtils.FormatNumber(_room.UnitsProcessed), ScriptLocalization.Misc.ColonSeparator_CS);
				}
				GameObjectUtils.SetActive(_patientsProcessedText.gameObject, flag2);
				if (_extraStaffComponent != null)
				{
					_extraStaffCountText.text = _extraStaffComponent.NumExtraStaff.ToString();
				}
			}
		}

		private void GetJobList()
		{
			_jobs.Clear();
			_room.Level.StaffWorkScheduler.GatherJobRoomsInRoom(ref _jobs, _room);
		}

		private void RefreshStaffList()
		{
			RoomLogicTrainingRoom component = _room.GetComponent<RoomLogicTrainingRoom>();
			if (component != null)
			{
				if (component.Qualification != null)
				{
					RefreshTraineeList(component.Pupils);
				}
				GameObjectUtils.SetActive(_staffListPanel.PanelRoot, component.Qualification != null);
			}
			else
			{
				RefreshJobsList();
				GameObjectUtils.SetActive(_staffListPanel.PanelRoot, _jobs.Count != 0);
			}
		}

		private void RefreshTraineeList(List<Staff> trainees)
		{
			Transform transform = _staffListPanel.ListRoot.transform;
			GameObjectUtils.DestroyChildren(transform.gameObject);
			foreach (Staff staff in trainees)
			{
				InspectorStaffInfoRow component = UnityEngine.Object.Instantiate(_staffListPanel.ElementPrefab, transform).GetComponent<InspectorStaffInfoRow>();
				if (!(component != null))
				{
					continue;
				}
				component.Setup(staff.Definition._icon, staff.Name, delegate
				{
					if (staff.GetComponent<StaffPickedUpState>() == null)
					{
						staff.Level.CameraLogic.TrackObject(staff.GameObject.transform);
					}
					else
					{
						staff.Level.CameraLogic.TrackObject(null);
					}
				});
			}
		}

		private void RefreshJobsList()
		{
			Transform transform = _staffListPanel.ListRoot.transform;
			bool flag = _room.AllJobsAreOptional();
			for (int i = 0; i < _jobs.Count; i++)
			{
				Job job = _jobs[i];
				Staff assignedStaff = job.GetStaff();
				StaffRequired staffRequired = job.StaffRequired();
				Sprite icon = staffRequired.Definition._icon;
				bool flag2 = _room.IsOptionalStaffRequired(staffRequired);
				if (flag && i == 0)
				{
					flag2 = false;
				}
				string text = ((assignedStaff == null) ? string.Format("{0}{2}{1}", GetRequiredStaffString(staffRequired), flag2 ? ScriptLocalization.Inspector_Room.Optional_CS : ScriptLocalization.Inspector_Room.Required_CS, ScriptLocalization.Misc.ColonSeparator_CS) : string.Format("{0}{2}{1}", GameStringUtils.GetStaffTypeTextLoc(staffRequired.Definition._type), assignedStaff.NameWithTitle, ScriptLocalization.Misc.ColonSeparator_CS));
				GameObject gameObject = ((i >= transform.childCount) ? UnityEngine.Object.Instantiate(_staffListPanel.ElementPrefab, transform) : transform.GetChild(i).gameObject);
				InspectorStaffInfoRow component = gameObject.GetComponent<InspectorStaffInfoRow>();
				if (!(component != null))
				{
					continue;
				}
				component.Setup(icon, text, delegate
				{
					if (assignedStaff != null)
					{
						if (assignedStaff.GetComponent<StaffPickedUpState>() == null)
						{
							assignedStaff.Level.CameraLogic.TrackObject(assignedStaff.GameObject.transform);
						}
						else
						{
							assignedStaff.Level.CameraLogic.TrackObject(null);
						}
					}
				});
			}
			for (int num = _jobs.Count; num < transform.childCount; num++)
			{
				UnityEngine.Object.Destroy(transform.GetChild(num).gameObject);
			}
		}

		private string GetRequiredStaffString(StaffRequired required)
		{
			if (required.QualificationInstance == null)
			{
				return required.Definition._type switch
				{
					StaffDefinition.Type.Doctor => ScriptLocalization.Menu_Ribbon_Menu.RibbonMenu_RequiredDoctor_CS, 
					StaffDefinition.Type.Nurse => ScriptLocalization.Menu_Ribbon_Menu.RibbonMenu_RequiredNurse_CS, 
					StaffDefinition.Type.Assistant => ScriptLocalization.Menu_Ribbon_Menu.RibbonMenu_RequiredAssistant_CS, 
					StaffDefinition.Type.Janitor => ScriptLocalization.Menu_Ribbon_Menu.RibbonMenu_RequiredJanitor_CS, 
					_ => throw new ArgumentOutOfRangeException(), 
				};
			}
			return (required.Definition._type switch
			{
				StaffDefinition.Type.Doctor => ScriptLocalization.Menu_Ribbon_Menu.RibbonMenu_RequiredDoctor_Qualification_CS, 
				StaffDefinition.Type.Nurse => ScriptLocalization.Menu_Ribbon_Menu.RibbonMenu_RequiredNurse_Qualification_CS, 
				StaffDefinition.Type.Assistant => ScriptLocalization.Menu_Ribbon_Menu.RibbonMenu_RequiredAssistant_Qualification_CS, 
				StaffDefinition.Type.Janitor => ScriptLocalization.Menu_Ribbon_Menu.RibbonMenu_RequiredJanitor_Qualification_CS, 
				_ => throw new ArgumentOutOfRangeException(), 
			}).Replace("{[QUALIFICATION]}", required.QualificationInstance.NameLocalised.Translation);
		}

		private string GetRequiredItemString()
		{
			if (_room.GetMissingRequiredItem(out var missing))
			{
				if (ShouldShowAmendedRequiredItemString())
				{
					return $"{missing.GetLocalisedName()} - {ScriptLocalization.Inspector_Room.Required_CS.ToLower()}";
				}
				return $"{missing.GetLocalisedName()} {ScriptLocalization.Inspector_Room.Required_CS}";
			}
			return null;
		}

		private bool ShouldShowAmendedRequiredItemString()
		{
			bool result = false;
			switch (LocalizationManager.CurrentLanguageCode)
			{
			case "fr":
			case "it":
			case "de":
			case "es":
			case "pl":
				result = true;
				break;
			}
			return result;
		}

		private Sprite GetRequiredItemIcon()
		{
			if (!_room.GetMissingRequiredItem(out var missing))
			{
				return null;
			}
			return missing.GetIcon();
		}

		private float GetAverageRoomAttractiveness()
		{
			return _room.Level.WorldState.HospitalAttributeMaps[1].CalculateAverageValue(_room.FloorPlan, -1f, 1f);
		}

		private float GetAverageRoomHygiene()
		{
			return _room.Level.WorldState.HospitalAttributeMaps[2].CalculateAverageValue(_room.FloorPlan, -1f, 1f);
		}

		private float GetAverageRoomTemperature()
		{
			return _room.Level.WorldState.HospitalAttributeMaps[0].CalculateAverageValue(_room.FloorPlan, -1f, 1f);
		}

		private void OnHygieneTooltip(Tooltip tooltip)
		{
			tooltip.Text = string.Format(ScriptLocalization.Inspector.Stat_Hygiene_CS, StringUtils.FormatPercentageValue(GetAverageRoomHygiene()));
		}

		private void OnTemperatureTooltip(Tooltip tooltip)
		{
			tooltip.Text = GameStringUtils.GetTemperatureDescription(GetAverageRoomTemperature() * 2f - 1f);
		}

		private void OnAttractivenessTooltip(Tooltip tooltip)
		{
			tooltip.Text = string.Format(ScriptLocalization.Inspector.Stat_RoomAttractiveness_CS, StringUtils.FormatPercentageValue(GetAverageRoomAttractiveness()));
		}
	}
}
