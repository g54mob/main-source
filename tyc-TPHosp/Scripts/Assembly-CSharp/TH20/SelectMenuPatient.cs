using I2.Loc;
using JetBrains.Annotations;
using TH20.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class SelectMenuPatient : SelectMenuCharacter
	{
		[SerializeField]
		private DynamicButton _sendHomeButton;

		[SerializeField]
		private DynamicButton _openMessageButton;

		[SerializeField]
		private DynamicButton _queueUpButton;

		[SerializeField]
		private DynamicButton _queueDownButton;

		[SerializeField]
		private DynamicButton _vaccinateButton;

		[SerializeField]
		private TMP_Text _name;

		[SerializeField]
		private ProgressBar _diagnosisProgressBar;

		[SerializeField]
		private GameObject _diagnosisSection;

		[SerializeField]
		private TMP_Text _illnessStatusText;

		[SerializeField]
		private TMP_Text _illnessText;

		[SerializeField]
		private TMP_Text _statusText;

		[SerializeField]
		private Image _statusIcon;

		[SerializeField]
		private ProgressBar _healthBar;

		[SerializeField]
		private ProgressBar _happinessBar;

		[SerializeField]
		private ProgressBar _boredomBar;

		[SerializeField]
		private ProgressBar _hungerBar;

		[SerializeField]
		private ProgressBar _thirstBar;

		[SerializeField]
		private ProgressBar _toiletBar;

		[SerializeField]
		private ProgressBar _temperatureBar;

		[SerializeField]
		private ProgressBar _attractivenessBar;

		[SerializeField]
		private ProgressBar _hygieneBar;

		[SerializeField]
		private GameObject _queueInfo;

		[SerializeField]
		private TMP_Text _queuePositionText;

		[SerializeField]
		private TMP_Text _statusEffectText;

		[SerializeField]
		private TooltipSpawner _statusEffectTooltip;

		private Patient _patient;

		private NotificationMessage _patientMessage;

		public override void Setup(Character character, Level level)
		{
			base.Setup(character, level);
			_patient = (Patient)character;
			_name.text = _patient.Name;
			_illnessText.text = _patient.Illness.Name.Translation;
			_sendHomeButton.onPrimaryDown.AddListener(SendHomeButton);
			_openMessageButton.onPrimaryDown.AddListener(OpenMessage);
			_queueUpButton.onPrimaryDown.AddListener(delegate
			{
				ChangeQueuePositionButton(-1);
			});
			_queueDownButton.onPrimaryDown.AddListener(delegate
			{
				ChangeQueuePositionButton(1);
			});
			_vaccinateButton.onPrimaryDown.AddListener(delegate
			{
				VaccinateCharacter(_patient);
			});
			if (_patient.ModifiersComponent != null)
			{
				_statusEffectTooltip.SetDataProvider(delegate(Tooltip tooltip)
				{
					tooltip.Text = _patient.ModifiersComponent.GetTooltipText(_patient.Gender);
				});
			}
		}

		protected override void Update()
		{
			base.Update();
			_patientMessage = base.Level.Notifications.GetMessageFor(_character);
			GameObjectUtils.SetActive(_openMessageButton.gameObject, _patientMessage != null);
			GameObjectUtils.SetInteractable(_sendHomeButton, !_patient.IsLeavingHospital() && _patient.InteractionInterruptable);
			_diagnosisProgressBar.Progress = _patient.DiagnosisCertainty / 100f;
			_healthBar.Progress = _patient.Health.Value() / 100f;
			_happinessBar.Progress = ((_patient.Happiness != null) ? (_patient.Happiness.Value() / 100f) : 0f);
			_happinessBar.SetColorFromGradient(Color.red, new Color(1f, 1f, 0f), Color.green);
			CharacterAttributes characterAttributes = _patient.GetCharacterAttributes();
			_boredomBar.Progress = 1f - characterAttributes.GetAttribute(CharacterAttributes.Type.Boredom).Value() / 100f;
			_boredomBar.SetColorFromGradient(Color.red, new Color(1f, 1f, 0f), Color.green);
			_hungerBar.Progress = 1f - characterAttributes.GetAttribute(CharacterAttributes.Type.Hunger).Value() / 100f;
			_hungerBar.SetColorFromGradient(Color.red, new Color(1f, 1f, 0f), Color.green);
			_thirstBar.Progress = 1f - characterAttributes.GetAttribute(CharacterAttributes.Type.Thirst).Value() / 100f;
			_thirstBar.SetColorFromGradient(Color.red, new Color(1f, 1f, 0f), Color.green);
			_toiletBar.Progress = characterAttributes.GetAttribute(CharacterAttributes.Type.Toilet).Value() / 100f;
			_toiletBar.SetColorFromGradient(Color.green, new Color(1f, 1f, 0f), Color.red);
			_attractivenessBar.Progress = MathUtils.ProportionThroughRange(_patient.AttractivenessValue, -1f, 1f);
			_attractivenessBar.SetColorFromGradient(Color.red, new Color(1f, 1f, 0f), Color.green);
			_temperatureBar.Progress = MathUtils.ProportionThroughRange(_patient.TemperatureValue, -1f, 1f);
			_temperatureBar.SetColorFromGradient(Color.blue, Color.white, Color.red);
			_hygieneBar.Progress = characterAttributes.GetAttribute(CharacterAttributes.Type.Hygiene).Value() / 100f;
			_hygieneBar.SetColorFromGradient(Color.red, new Color(1f, 1f, 0f), Color.green);
			if (_patient.TreatmentOutcome != Treatment.Outcome.Unknown)
			{
				GameObjectUtils.SetActive(_illnessText.gameObject, isActive: true);
				GameObjectUtils.SetActive(_illnessStatusText.gameObject, isActive: true);
				GameObjectUtils.SetActive(_diagnosisSection.gameObject, isActive: false);
				if (_patient.TreatmentOutcome == Treatment.Outcome.Cured)
				{
					_illnessText.color = new Color(0.7f, 1f, 0.7f);
					_illnessStatusText.color = new Color(0.7f, 1f, 0.7f);
					_illnessStatusText.text = ScriptLocalization.Menu.Hover_Patient_IllnessCured_CS;
				}
				else
				{
					_illnessText.color = new Color(1f, 0.7f, 0.7f);
					_illnessStatusText.color = new Color(1f, 0.7f, 0.7f);
					_illnessStatusText.text = ScriptLocalization.Menu.Hover_Patient_IllnessTreatmentFailed_CS;
				}
			}
			else if (_patient.IsGoingForTreatment())
			{
				GameObjectUtils.SetActive(_illnessText.gameObject, isActive: true);
				GameObjectUtils.SetActive(_illnessStatusText.gameObject, isActive: true);
				GameObjectUtils.SetActive(_diagnosisSection.gameObject, isActive: false);
				_illnessText.color = new Color(1f, 0.7f, 0.7f);
				_patient.Illness.GetTreatmentChanceOfSuccessRange(_patient, out var chanceMin, out var chanceMax);
				string select_Patient_ChanceOfCuring_CS = ScriptLocalization.Menu.Select_Patient_ChanceOfCuring_CS;
				select_Patient_ChanceOfCuring_CS = select_Patient_ChanceOfCuring_CS.Replace("{[MIN]}", Mathf.RoundToInt(chanceMin).ToString());
				select_Patient_ChanceOfCuring_CS = select_Patient_ChanceOfCuring_CS.Replace("{[MAX]}", Mathf.RoundToInt(chanceMax).ToString());
				_illnessStatusText.text = select_Patient_ChanceOfCuring_CS;
				_illnessStatusText.color = Color.blue;
			}
			else
			{
				GameObjectUtils.SetActive(_illnessText.gameObject, isActive: false);
				GameObjectUtils.SetActive(_illnessStatusText.gameObject, isActive: true);
				GameObjectUtils.SetActive(_diagnosisSection.gameObject, isActive: true);
				_illnessStatusText.color = new Color(0.8f, 0.8f, 0.8f);
				_illnessStatusText.text = _patient.GetStatusText();
			}
			Sprite statusSprite = _patient.GetStatusSprite();
			if (statusSprite != null)
			{
				_statusIcon.sprite = statusSprite;
				GameObjectUtils.SetActive(_statusIcon.gameObject, isActive: true);
				GameObjectUtils.SetActive(_statusText.gameObject, isActive: false);
			}
			else
			{
				_statusText.text = _patient.GetStatusText();
				GameObjectUtils.SetActive(_statusIcon.gameObject, isActive: false);
				GameObjectUtils.SetActive(_statusText.gameObject, isActive: true);
			}
			int queuePosition = _patient.GetQueuePosition();
			if (queuePosition == -1)
			{
				GameObjectUtils.SetActive(_queueInfo, isActive: false);
				GameObjectUtils.SetActive(_queueUpButton.gameObject, isActive: false);
				GameObjectUtils.SetActive(_queueDownButton.gameObject, isActive: false);
			}
			else
			{
				GameObjectUtils.SetActive(_queueInfo, isActive: true);
				GameObjectUtils.SetActive(_queueUpButton.gameObject, isActive: true);
				GameObjectUtils.SetActive(_queueDownButton.gameObject, isActive: true);
				_queuePositionText.text = (queuePosition + 1).ToString();
			}
			UpdateVaccinationButton(_vaccinateButton.gameObject, _patient);
			if (_patient.ModifiersComponent != null)
			{
				_statusEffectText.text = _patient.ModifiersComponent.GetHUDString(_patient.Gender);
			}
		}

		private void SendHomeButton()
		{
			_patient.SendHome();
			CloseMenu();
		}

		private void OpenMessage()
		{
			if (_patientMessage != null)
			{
				base.Level.Notifications.Open(_patientMessage);
				CloseMenu();
			}
		}

		private void ChangeQueuePositionButton(int change)
		{
			Room queuingAtRoom = _patient.QueuingAtRoom;
			if (queuingAtRoom != null)
			{
				int num = queuingAtRoom.PositionInQueue(_patient) + change;
				if (num >= 0 && num < queuingAtRoom.QueueLength)
				{
					queuingAtRoom.AddToQueue(_patient, num);
				}
			}
		}
	}
}
