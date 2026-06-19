using I2.Loc;
using JetBrains.Annotations;
using TH20.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class HoverMenuPatient : HoverMenuCharacter
	{
		private Patient _patient;

		[SerializeField]
		private TMP_Text _name;

		[SerializeField]
		private ProgressBarMaskable _diagnosisProgressBar;

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
		private ProgressBarMaskable _healthBar;

		[SerializeField]
		private ProgressBarMaskable _happinessBar;

		[SerializeField]
		private GameObject _queueInfo;

		[SerializeField]
		private TMP_Text _queuePositionText;

		[SerializeField]
		private Color _defaultIllnessColor;

		[SerializeField]
		private Color _curedIllnessStatusColor;

		[SerializeField]
		private Color _badIllnessStatusColor;

		[SerializeField]
		private Color _defaultTreatmentStatusColor;

		[SerializeField]
		private Color _curedTreatmentStatusColor;

		[SerializeField]
		private Color _badTreatmentStatusColor;

		public override void Setup(Character character, Level level)
		{
			base.Setup(character, level);
			_patient = (Patient)character;
			Update();
		}

		protected override void Update()
		{
			base.Update();
			_name.text = _patient.Name;
			_illnessText.text = _patient.Illness.Name.Translation;
			_diagnosisProgressBar.Progress = _patient.DiagnosisCertainty / 100f;
			_healthBar.Progress = _patient.Health.Value() / 100f;
			_happinessBar.Progress = ((_patient.Happiness != null) ? (_patient.Happiness.Value() / 100f) : 0f);
			if (_patient.TreatmentOutcome != Treatment.Outcome.Unknown)
			{
				_illnessText.gameObject.SetActive(value: true);
				_illnessStatusText.gameObject.SetActive(value: true);
				_diagnosisSection.gameObject.SetActive(value: false);
				if (_patient.TreatmentOutcome == Treatment.Outcome.Cured)
				{
					_illnessText.color = _curedIllnessStatusColor;
					_illnessStatusText.color = _curedTreatmentStatusColor;
					_illnessStatusText.text = ScriptLocalization.Menu.Hover_Patient_IllnessCured_CS;
				}
				else
				{
					_illnessText.color = _badIllnessStatusColor;
					_illnessStatusText.color = _badTreatmentStatusColor;
					_illnessStatusText.text = ScriptLocalization.Menu.Hover_Patient_IllnessTreatmentFailed_CS;
				}
			}
			else if (_patient.IsGoingForTreatment())
			{
				_illnessText.gameObject.SetActive(value: true);
				_illnessStatusText.gameObject.SetActive(value: true);
				_diagnosisSection.gameObject.SetActive(value: false);
				_illnessText.color = _defaultIllnessColor;
				_illnessStatusText.color = _defaultTreatmentStatusColor;
				_illnessStatusText.text = _patient.GetStatusText();
			}
			else
			{
				_illnessText.gameObject.SetActive(value: false);
				_illnessStatusText.gameObject.SetActive(value: true);
				_diagnosisSection.gameObject.SetActive(value: true);
				_illnessStatusText.color = _defaultTreatmentStatusColor;
				_illnessStatusText.text = _patient.GetStatusText();
			}
			Sprite statusSprite = _patient.GetStatusSprite();
			if (statusSprite != null)
			{
				_statusIcon.sprite = statusSprite;
				_statusIcon.gameObject.SetActive(value: true);
				_statusText.gameObject.SetActive(value: false);
			}
			else
			{
				_statusText.text = _patient.GetStatusText();
				_statusIcon.gameObject.SetActive(value: false);
				_statusText.gameObject.SetActive(value: true);
			}
			int queuePosition = _patient.GetQueuePosition();
			if (queuePosition == -1 && _patient.RoomCalledInto == null)
			{
				GameObjectUtils.SetActive(_queueInfo, isActive: false);
				return;
			}
			GameObjectUtils.SetActive(_queueInfo, isActive: true);
			_queuePositionText.text = ((queuePosition > -1) ? (queuePosition + 1).ToString() : StatusIconQueuePosition.GoingToRoomStatusIconString);
		}
	}
}
