using System;
using FullInspector;
using I2.Loc;
using JetBrains.Annotations;
using TH20.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class InspectorSubItemPatientInfo : InspectorSubItem
	{
		[Serializable]
		[UsedImplicitly(ImplicitUseTargetFlags.Members)]
		public struct BreakdownInfo
		{
			public ProgressBarMaskable Progress;

			public GameObject UnknownText;

			public TooltipSpawner Tooltip;

			public void SetProgress(bool known, float value)
			{
				Progress.Progress = value / 100f;
				GameObjectUtils.SetActive(Progress.gameObject, known);
				GameObjectUtils.SetActive(UnknownText.gameObject, !known);
			}
		}

		[SerializeField]
		private InspectorRoomQueueRow _patientShortInfo;

		[SerializeField]
		private Image _statusImage;

		[SerializeField]
		private Image _statusImageBlank;

		[SerializeField]
		private TMP_Text _statusText;

		[SerializeField]
		private TMP_Text _subStatusText;

		[SerializeField]
		private Button _appointmentButton;

		[SerializeField]
		private Image _appointmentImageBlank;

		[SerializeField]
		private Image _appointmentImage;

		[SerializeField]
		private TMP_Text _appointmentText;

		[SerializeField]
		private GameObject _queuePositionContainer;

		[SerializeField]
		private TMP_Text _queuePositionText;

		[SerializeField]
		private ButtonAnimator _queuePositionLeftButton;

		[SerializeField]
		private ButtonAnimator _queuePositionRightButton;

		[SerializeField]
		private TMP_Text _queueStatusLabelText;

		[SerializeField]
		private TMP_Text _queueStatusLabelTextLong;

		[SerializeField]
		private TMP_Text _feelingsText;

		[SerializeField]
		private TooltipSpawner _feelingsTooltip;

		[SerializeField]
		private TMP_Text _durationText;

		[InspectorHeader("Treatment Breakdown")]
		[SerializeField]
		private GameObject _treatmentBreakdownRoot;

		[SerializeField]
		private TMP_Text _treatmentChanceText;

		[SerializeField]
		private BreakdownInfo _illnessDifficulty;

		[SerializeField]
		private BreakdownInfo _diagnosisCertainty;

		[SerializeField]
		private BreakdownInfo _staffSkill;

		[SerializeField]
		private BreakdownInfo _upgrades;

		private Patient _patient;

		private TreatmentCalculationBreakdown _treatmentBreakdown;

		private Room _appointmentRoom;

		private RoomItem _appointmentRoomItem;

		public void Setup(Patient patient)
		{
			_patient = patient;
			if (_patient.ModifiersComponent != null)
			{
				_feelingsTooltip.SetDataProvider(delegate(Tooltip tooltip)
				{
					tooltip.Text = _patient.ModifiersComponent.GetTooltipText(_patient.Gender);
				});
			}
			_illnessDifficulty.Tooltip.SetDataProvider(OnIllnessDifficultyTooltip);
			_diagnosisCertainty.Tooltip.SetDataProvider(OnDiagnosisCertaintyTooltip);
			_staffSkill.Tooltip.SetDataProvider(OnStaffSkillTooltip);
			_upgrades.Tooltip.SetDataProvider(OnUpgradesTooltip);
			_appointmentButton.onClick.AddListener(SelectAppointmentRoom);
		}

		private void Start()
		{
			_queuePositionLeftButton.Button.onPrimaryDown.AddListener(OnQueueMoveLeft);
			_queuePositionRightButton.Button.onPrimaryDown.AddListener(OnQueueMoveRight);
		}

		public void OnDestroy()
		{
			_queuePositionLeftButton.Button.onPrimaryDown.RemoveListener(OnQueueMoveLeft);
			_queuePositionRightButton.Button.onPrimaryDown.RemoveListener(OnQueueMoveRight);
		}

		private void Update()
		{
			if (_patient == null)
			{
				return;
			}
			_patientShortInfo.Setup(null, _patient, null);
			Sprite statusSprite = _patient.GetStatusSprite();
			if (statusSprite != null)
			{
				_statusImage.overrideSprite = statusSprite;
				GameObjectUtils.SetActive(_statusImage.gameObject, isActive: true);
				GameObjectUtils.SetActive(_statusImageBlank.gameObject, isActive: false);
			}
			else
			{
				GameObjectUtils.SetActive(_statusImage.gameObject, isActive: false);
				GameObjectUtils.SetActive(_statusImageBlank.gameObject, isActive: true);
			}
			_statusText.text = _patient.GetStatusText();
			UpdateQueueInfo();
			if (_patient.ModifiersComponent != null)
			{
				_feelingsText.text = _patient.ModifiersComponent.GetHUDString(_patient.Gender);
			}
			int daysInHospital = _patient.DaysInHospital;
			string newValue = _patient.DaysInHospital.ToString();
			_durationText.text = GameStringUtils.GetDaysString(_patient.DaysInHospital);
			string text = string.Empty;
			if (!_patient.IsDying())
			{
				RoomDefinition.Type wasWaitingForRoom = _patient.WasWaitingForRoom;
				WaitForRoomToBeBuiltComponent component = _patient.GetComponent<WaitForRoomToBeBuiltComponent>();
				bool flag = _patient.Happiness != null && _patient.Happiness.Value() < GameAlgorithms.Config.PatientLowHappiness;
				CharacterHappinessComponent component2 = _patient.GetComponent<CharacterHappinessComponent>();
				string text2 = ((component2 != null) ? GameStringUtils.MakeStringFromList(component2.GetTopComplaints(3)) : string.Empty);
				string translationPlural = LocalisedString.GetTranslationPlural("Menu/Inspector/Patient/DaysSinceArrival_CS", daysInHospital);
				translationPlural = translationPlural.Replace("{[DAYS]}", newValue);
				if (_patient.CurrentMode == Patient.Mode.RageQuit)
				{
					if (flag)
					{
						text = ScriptLocalization.Menu_Inspector_Patient.HappinessReachedZero_CS;
						if (!string.IsNullOrEmpty(text2))
						{
							text += string.Format("\n{0}{2}{1}", ScriptLocalization.Menu_Inspector_Patient.TopComplaints_CS, text2, ScriptLocalization.Misc.ColonSeparator_CS);
						}
					}
					else if (wasWaitingForRoom != RoomDefinition.Type.Invalid)
					{
						if (_patient.WaitingForFurtherDiagnosis)
						{
							text = ScriptLocalization.Menu_Inspector.GaveUpWaitingForFurtherDiagnosis_CS;
						}
						else
						{
							RoomDefinition definitionFromType = RoomAlgorithms.GetDefinitionFromType(_patient.Level, wasWaitingForRoom);
							if (definitionFromType != null)
							{
								text = LocalisedString.Replace(ScriptLocalization.Menu_Inspector_Patient.GaveUpWaiting_CS, "{[ROOM]}", definitionFromType.GetLocalisedName());
							}
						}
					}
					text += $"\n{translationPlural}";
				}
				else if (flag)
				{
					text = ScriptLocalization.Menu_Inspector_Patient.WillLeaveSoon_CS;
					if (!string.IsNullOrEmpty(text2))
					{
						text += string.Format("\n{0}{2}{1}", ScriptLocalization.Menu_Inspector_Patient.TopComplaints_CS, text2, ScriptLocalization.Misc.ColonSeparator_CS);
					}
					text += $"\n{translationPlural}";
				}
				else if (component != null)
				{
					text = ScriptLocalization.Menu_Inspector_Patient.WillingToWait_CS.Replace("{[SECONDS]}", $"{(int)component.Time}");
				}
				else
				{
					StatusIcon.Type statusIcon = _patient.GetStatusIcon();
					if (statusIcon != StatusIcon.Type.Invalid && _patient.Level != null && _patient.Level.StatusIconManager != null)
					{
						StatusIcon statusIcon2 = _patient.Level.StatusIconManager.GetStatusIcon(statusIcon);
						if (statusIcon2 != null)
						{
							_statusImage.overrideSprite = statusIcon2.Icon;
							LocalisedString genderLocalisedString = LocalisedString.GetGenderLocalisedString(statusIcon2.Description, _patient);
							_statusText.text = genderLocalisedString.Translation;
							GameObjectUtils.SetActive(_statusImage.gameObject, isActive: true);
							GameObjectUtils.SetActive(_statusImageBlank.gameObject, isActive: false);
						}
					}
				}
			}
			_subStatusText.text = text;
			GameObjectUtils.SetActive(_subStatusText.gameObject, !string.IsNullOrEmpty(text));
			UpdateTreatmentBreakdown();
		}

		private void UpdateQueueInfo()
		{
			Sprite sprite = null;
			string text = string.Empty;
			Room queuingAtRoom = _patient.QueuingAtRoom;
			Room roomCalledInto = _patient.RoomCalledInto;
			Room goingToRoom = _patient.GoingToRoom;
			CharacterCheckInComponent component = _patient.GetComponent<CharacterCheckInComponent>();
			RoomItemReceptionComponent roomItemReceptionComponent = component?.Reception;
			int num = component?.GetQueuePosition() ?? _patient.GetQueuePosition();
			bool flag = roomItemReceptionComponent != null;
			Room room = null;
			if (num >= 0 || roomCalledInto != null || goingToRoom != null)
			{
				if (goingToRoom != null)
				{
					room = goingToRoom;
					sprite = goingToRoom.Definition._icon;
					text = goingToRoom.Definition.GetLocalisedName();
				}
				else if (roomCalledInto != null)
				{
					room = roomCalledInto;
					sprite = roomCalledInto.Definition._icon;
					text = roomCalledInto.Definition.GetLocalisedName();
				}
				else if (roomItemReceptionComponent != null)
				{
					sprite = roomItemReceptionComponent.Item.Icon;
					text = roomItemReceptionComponent.Item.LocalisedName;
				}
				else if (queuingAtRoom != null)
				{
					room = queuingAtRoom;
					sprite = queuingAtRoom.Definition._icon;
					text = queuingAtRoom.Definition.GetLocalisedName();
				}
			}
			bool num2 = text.IsNullOrEmpty();
			if (num2)
			{
				text = ((_patient.Gender == Character.Sex.Male) ? ScriptLocalization.Challenges.RewardsNone_CS : ScriptLocalization.Challenges.RewardsNone_F_CS);
			}
			_appointmentText.text = string.Format("{0}{2}{1}", ScriptLocalization.Menu_Inspector_Patient.Appointment_CS, text, ScriptLocalization.Misc.ColonSeparator_CS);
			_appointmentImage.overrideSprite = sprite;
			GameObjectUtils.SetActive(_appointmentImage.gameObject, sprite != null);
			GameObjectUtils.SetActive(_appointmentImageBlank.gameObject, sprite == null);
			_appointmentRoom = room;
			_appointmentRoomItem = roomItemReceptionComponent?.Item;
			bool flag2 = _patient.ReasonUsingRoom == ReasonUseRoom.Treatment && _patient.RoomUsing != null && _patient.RoomUsing == room && !_patient.RoomUsing.Definition.IsHospitalOrBay;
			bool flag3 = _patient.ReasonUsingRoom == ReasonUseRoom.Diagnosis && _patient.RoomUsing != null && _patient.RoomUsing == room && !_patient.RoomUsing.Definition.IsHospitalOrBay;
			bool flag4 = _patient.IsWaitingForRoom();
			bool flag5 = num >= 0;
			string text2;
			if (num2)
			{
				flag5 = false;
				text2 = string.Empty;
			}
			else if (roomCalledInto != null && roomCalledInto == room)
			{
				flag5 = false;
				text2 = ScriptLocalization.Inspector.PatientStatusCalledIntoRoom_CS;
			}
			else if (flag2 && !flag)
			{
				flag5 = false;
				text2 = ScriptLocalization.Inspector.PatientStatusTreatmentInProgress_CS;
			}
			else if (flag3 && !flag)
			{
				flag5 = false;
				text2 = ScriptLocalization.Inspector.PatientStatusDiagnosisInProgress_CS;
			}
			else if (num < 0)
			{
				text2 = ((!flag4) ? string.Empty : ScriptLocalization.Inspector.PatientStatusWaiting_CS);
			}
			else
			{
				bool flag6 = false;
				if (room != null)
				{
					if (!RoomAlgorithms.IsCharacterWithinDistanceOfQueuePosition(_patient, room, GameAlgorithms.Config.GoingToQueueDistance))
					{
						flag6 = true;
					}
				}
				else if (roomItemReceptionComponent != null && roomItemReceptionComponent.Item != null)
				{
					float num3 = MathUtils.Square(GameAlgorithms.Config.GoingToQueueDistance);
					if (_patient.Position.SquareDistance2D(roomItemReceptionComponent.Item.WorldPosition) >= num3)
					{
						flag6 = true;
					}
				}
				text2 = ((!flag6) ? ScriptLocalization.Inspector.PatientStatusQueuing_CS : ScriptLocalization.Inspector.PatientStatusGoingToQueue_CS);
			}
			if (flag5)
			{
				_queueStatusLabelText.text = text2;
				_queueStatusLabelTextLong.text = string.Empty;
			}
			else
			{
				_queueStatusLabelText.text = string.Empty;
				_queueStatusLabelTextLong.text = text2;
			}
			ShowPositionIndicatorPanel(flag5, num);
		}

		private void ShowPositionIndicatorPanel(bool bShow, int queuePosition = -1)
		{
			bool flag = bShow && queuePosition >= 0;
			_queuePositionContainer.SetActive(flag);
			if (flag)
			{
				_queuePositionLeftButton.CurrentState = ButtonAnimator.State.Selectable;
				_queuePositionRightButton.CurrentState = ButtonAnimator.State.Selectable;
				_queuePositionText.text = (queuePosition + 1).ToString();
			}
			else
			{
				_queuePositionLeftButton.CurrentState = ButtonAnimator.State.Unselectable;
				_queuePositionRightButton.CurrentState = ButtonAnimator.State.Unselectable;
				_queuePositionText.text = string.Empty;
			}
		}

		private void OnQueueMoveLeft()
		{
			ChangeQueuePositionButton(-1);
		}

		private void OnQueueMoveRight()
		{
			ChangeQueuePositionButton(1);
		}

		private void ChangeQueuePositionButton(int change)
		{
			Room queuingAtRoom = _patient.QueuingAtRoom;
			RoomItemReceptionComponent roomItemReceptionComponent = _patient.GetComponent<CharacterCheckInComponent>()?.Reception;
			if (roomItemReceptionComponent != null)
			{
				int num = roomItemReceptionComponent.GetQueuePosition(_patient) + change;
				if (num >= 0 && num < roomItemReceptionComponent.QueueLength)
				{
					roomItemReceptionComponent.ChangeQueuePosition(_patient, num);
				}
			}
			else if (queuingAtRoom != null)
			{
				int num2 = queuingAtRoom.Queue.IndexOf(_patient) + change;
				if (num2 >= 0 && num2 < queuingAtRoom.QueueLength)
				{
					queuingAtRoom.AddToQueue(_patient, num2);
				}
			}
		}

		private void UpdateTreatmentBreakdown()
		{
			if (_patient.CurrentMode == Patient.Mode.RageQuit || _patient.CurrentMode == Patient.Mode.SentHome)
			{
				GameObjectUtils.SetActive(_treatmentBreakdownRoot, isActive: false);
			}
			else if (_patient.TreatmentOutcome != Treatment.Outcome.Unknown)
			{
				string chanceOfSuccess_CS = ScriptLocalization.Menu_Inspector_Patient.ChanceOfSuccess_CS;
				_treatmentBreakdown = _patient.TreatmentOutcomeBreakdown;
				_treatmentChanceText.text = LocalisedString.Replace(chanceOfSuccess_CS, "{[VALUE]}", StringUtils.FormatPercentageValue(_treatmentBreakdown.ChanceOfSuccess / 100f));
				_illnessDifficulty.SetProgress(known: true, _treatmentBreakdown.IllnessDifficulty);
				_diagnosisCertainty.SetProgress(known: true, _treatmentBreakdown.DiagnosisCertainty);
				_staffSkill.SetProgress(known: true, _treatmentBreakdown.StaffSkillPercent * 100f);
				_upgrades.SetProgress(known: true, _treatmentBreakdown.RoomModifiersPercent * 100f);
				GameObjectUtils.SetActive(_treatmentBreakdownRoot, isActive: true);
			}
			else if (_patient.IsGoingForTreatment())
			{
				Room room = null;
				if (_patient.IsInTreatmentRoom())
				{
					room = _patient.RoomUsing;
				}
				else if (_patient.QueuingAtRoom != null)
				{
					room = _patient.QueuingAtRoom;
				}
				else if (_patient.GoingToRoom != null)
				{
					room = _patient.GoingToRoom;
				}
				Staff staff = GameAlgorithms.FindStaffLikelyToSeePatient(room);
				_treatmentBreakdown = GameAlgorithms.CalculateEstimatedTreatmentOutcome(_patient, staff, room);
				bool flag = _treatmentBreakdown.ChanceOfSuccess - _treatmentBreakdown.MinChanceOfSuccess > 0.01f;
				string term = ((staff != null && room != null && !flag) ? ScriptLocalization.Menu_Inspector_Patient.EstimatedChanceValue_CS : ScriptLocalization.Menu_Inspector_Patient.EstimatedChanceMinMax_CS);
				term = ((!flag) ? LocalisedString.Replace(term, new SubPair[3]
				{
					new SubPair("{[VALUE]}", StringUtils.FormatPercentageValue(_treatmentBreakdown.ChanceOfSuccess / 100f)),
					new SubPair("{[MIN]}", StringUtils.FormatPercentageValue(_treatmentBreakdown.MinTreatmentEffectiveness / 100f)),
					new SubPair("{[MAX]}", StringUtils.FormatPercentageValue(_treatmentBreakdown.MaxTreatmentEffectiveness / 100f))
				}) : LocalisedString.Replace(term, new SubPair[3]
				{
					new SubPair("{[VALUE]}", StringUtils.FormatPercentageValue(_treatmentBreakdown.ChanceOfSuccess / 100f)),
					new SubPair("{[MIN]}", StringUtils.FormatPercentageValue(_treatmentBreakdown.MinChanceOfSuccess / 100f)),
					new SubPair("{[MAX]}", StringUtils.FormatPercentageValue(_treatmentBreakdown.ChanceOfSuccess / 100f))
				}));
				_treatmentChanceText.text = term;
				_illnessDifficulty.SetProgress(room != null, _treatmentBreakdown.IllnessDifficulty);
				_diagnosisCertainty.SetProgress(known: true, _treatmentBreakdown.DiagnosisCertainty);
				_staffSkill.SetProgress(staff != null, _treatmentBreakdown.StaffSkillPercent * 100f);
				_upgrades.SetProgress(room != null, _treatmentBreakdown.RoomModifiersPercent * 100f);
				GameObjectUtils.SetActive(_treatmentBreakdownRoot, isActive: true);
			}
			else
			{
				GameObjectUtils.SetActive(_treatmentBreakdownRoot, isActive: false);
			}
		}

		private void OnIllnessDifficultyTooltip(Tooltip tooltip)
		{
			string replace = StringUtils.FormatPercentageValue(_treatmentBreakdown.IllnessDifficulty / 100f);
			tooltip.Text = LocalisedString.Replace(ScriptLocalization.Inspector.Stat_IllnessDifficulty_CS, "{[VALUE]}", replace);
		}

		private void OnDiagnosisCertaintyTooltip(Tooltip tooltip)
		{
			tooltip.Text = string.Format(ScriptLocalization.Inspector.Stat_DiagnosisCertainty_CS, StringUtils.FormatPercentageValue(_treatmentBreakdown.DiagnosisCertainty / 100f));
		}

		private void OnStaffSkillTooltip(Tooltip tooltip)
		{
			string replace = StringUtils.FormatPercentageValue(_treatmentBreakdown.StaffSkillPercent);
			tooltip.Text = LocalisedString.Replace(ScriptLocalization.Inspector.Stat_StaffSkill_CS, "{[VALUE]}", replace);
		}

		private void OnUpgradesTooltip(Tooltip tooltip)
		{
			string replace = StringUtils.FormatPercentageValue(_treatmentBreakdown.RoomModifiersPercent);
			tooltip.Text = LocalisedString.Replace(ScriptLocalization.Inspector.Stat_Upgrades_CS, "{[VALUE]}", replace);
		}

		private void SelectAppointmentRoom()
		{
			GameObject gameObject = null;
			if (_appointmentRoom != null)
			{
				gameObject = _appointmentRoom.GetCameraTrackObject();
			}
			else if (_appointmentRoomItem != null)
			{
				gameObject = _appointmentRoomItem.GetCameraTrackObject();
			}
			if (gameObject != null)
			{
				_patient.Level.CameraLogic.TrackObject(gameObject.transform);
			}
		}
	}
}
