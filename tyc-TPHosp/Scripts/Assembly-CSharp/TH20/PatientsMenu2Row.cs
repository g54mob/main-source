using I2.Loc;
using JetBrains.Annotations;
using TH20.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class PatientsMenu2Row : PatientsMenu2RowBase
	{
		[SerializeField]
		private DynamicButton _rowButton;

		[SerializeField]
		private ButtonAnimator _rowButtonAnimator;

		[Header("Name")]
		[SerializeField]
		private TMP_Text _text;

		[Header("Status")]
		[SerializeField]
		private Image _statusIcon;

		[SerializeField]
		private TooltipSpawner _statusIconTooltip;

		[SerializeField]
		private IntCellComparable _statusIntCellComparable;

		[Header("Diagnosis")]
		[SerializeField]
		private TMP_Text _illnessText;

		[SerializeField]
		private ProgressBarMaskable _diagnosisProgressBar;

		[SerializeField]
		private TooltipSpawner _diagnosisTooltip;

		[SerializeField]
		private TooltipSpawner _illnessTooltip;

		[Header("Happiness")]
		[SerializeField]
		private ProgressBarMaskable _happinessProgressBar;

		[SerializeField]
		private TooltipSpawner _happinessTooltip;

		[Header("Health")]
		[SerializeField]
		private ProgressBarMaskable _healthProgressBar;

		[SerializeField]
		private TooltipSpawner _healthTooltip;

		[Header("RowHighlight")]
		[SerializeField]
		protected Image _rowBackground;

		[SerializeField]
		protected Sprite _rowAlternateBackground;

		private Sprite _rowBackgroundSprite;

		public Patient Patient { get; private set; }

		public DynamicButton Button => _rowButton;

		public ButtonAnimator ButtonAnimator => _rowButtonAnimator;

		public void Setup(Patient patient)
		{
			if (Patient == patient)
			{
				return;
			}
			Patient = patient;
			_statusIcon.enabled = true;
			if (_statusIconTooltip != null)
			{
				if (Patient == null)
				{
					_statusIconTooltip.SetDataProvider(null);
				}
				else
				{
					_statusIconTooltip.SetDataProvider(delegate(Tooltip tooltip)
					{
						tooltip.Text = Patient.GetStatusText();
					});
				}
			}
			if (_diagnosisTooltip != null)
			{
				if (Patient == null)
				{
					_diagnosisTooltip.SetDataProvider(null);
				}
				else
				{
					_diagnosisTooltip.SetDataProvider(delegate(Tooltip tooltip)
					{
						tooltip.Text = string.Format(ScriptLocalization.Inspector.Stat_DiagnosisCertainty_CS, StringUtils.FormatPercentageValue(Patient.DiagnosisCertainty / 100f));
					});
				}
			}
			if (_illnessTooltip != null)
			{
				_illnessTooltip.SetShouldShowFunc(ShouldShowIllnessTooltip);
				_illnessTooltip.SetDataProvider(delegate(Tooltip tooltip)
				{
					tooltip.Text = string.Empty;
					if (ShouldShowIllnessTooltip())
					{
						IllnessDefinition illness = Patient.Illness;
						tooltip.Text = $"<b>{illness.Name.Translation}</b>\n{illness.Description.Translation}";
					}
				});
			}
			if (_happinessTooltip != null)
			{
				if (Patient == null)
				{
					_happinessTooltip.SetDataProvider(null);
				}
				else
				{
					_happinessTooltip.SetDataProvider(delegate(Tooltip tooltip)
					{
						tooltip.Text = string.Format(ScriptLocalization.Inspector.Stat_Happiness_CS, StringUtils.FormatPercentageValue((Patient.Happiness != null) ? (Patient.Happiness.Value() / 100f) : 0f));
					});
				}
			}
			if (_healthTooltip != null)
			{
				if (Patient == null)
				{
					_healthTooltip.SetDataProvider(null);
				}
				else
				{
					_healthTooltip.SetDataProvider(delegate(Tooltip tooltip)
					{
						tooltip.Text = string.Format(ScriptLocalization.Inspector.Stat_Health_CS, StringUtils.FormatPercentageValue((Patient.Health != null) ? (Patient.Health.Value() / 100f) : 0f));
					});
				}
			}
			if (Patient != null)
			{
				_rowButton.onPrimaryDown.AddListener(OnRowButtonClick);
			}
			else
			{
				_rowButton.onPrimaryDown.RemoveAllListeners();
			}
			Refresh(setInstant: true);
		}

		private bool ShouldShowIllnessTooltip()
		{
			bool result = false;
			if (Patient != null && Patient.Illness != null && (Patient.IsGoingForTreatment() || Patient.TreatmentOutcome != Treatment.Outcome.Unknown))
			{
				result = true;
			}
			return result;
		}

		public void Refresh(bool setInstant)
		{
			if (Patient == null)
			{
				return;
			}
			if (_text != null && _text.text != Patient.Name)
			{
				_text.text = Patient.Name;
			}
			Sprite statusSprite = Patient.GetStatusSprite();
			if (_statusIcon != null)
			{
				if (statusSprite == null)
				{
					Color color = _statusIcon.color;
					_statusIcon.color = new Color(color.r, color.g, color.b, 0f);
					_statusIntCellComparable.Value = Patient.GetStatusText().GetHashCode();
				}
				else
				{
					Color color2 = _statusIcon.color;
					_statusIcon.color = new Color(color2.r, color2.g, color2.b, 1f);
					if (_statusIcon.sprite != statusSprite)
					{
						_statusIcon.sprite = statusSprite;
						_statusIntCellComparable.Value = statusSprite.name.GetHashCode();
					}
				}
			}
			if (Patient.IsGoingForTreatment() || Patient.TreatmentOutcome != Treatment.Outcome.Unknown)
			{
				if (_illnessText != null && _illnessText.text != Patient.Illness.Name.Translation)
				{
					_illnessText.text = Patient.Illness.Name.Translation;
				}
				_diagnosisProgressBar.Progress = 1f;
				_diagnosisProgressBar.transform.localScale = new Vector3(1f, 0f, 0f);
			}
			else
			{
				if (_illnessText != null)
				{
					_illnessText.text = string.Empty;
				}
				_diagnosisProgressBar.transform.localScale = Vector3.one;
				if (setInstant)
				{
					_diagnosisProgressBar.Progress = Patient.DiagnosisCertainty / 100f;
				}
				else
				{
					_diagnosisProgressBar.SetProgressSmooth(Patient.DiagnosisCertainty / 100f);
				}
			}
			if (setInstant)
			{
				_happinessProgressBar.Progress = ((Patient.Happiness != null) ? (Patient.Happiness.Value() / 100f) : 0f);
				_healthProgressBar.Progress = Patient.Health.Value() / 100f;
			}
			else
			{
				_happinessProgressBar.SetProgressSmooth((Patient.Happiness != null) ? (Patient.Happiness.Value() / 100f) : 0f);
				_healthProgressBar.SetProgressSmooth(Patient.Health.Value() / 100f);
			}
		}

		protected virtual void OnRowButtonClick()
		{
			Patient.Level.BuildEvents.OnCursorSelectObject.InvokeSafe(Patient);
		}

		public virtual void SetRowBackground(int rowNum)
		{
			if ((bool)_rowBackground)
			{
				if (_rowBackgroundSprite == null)
				{
					_rowBackgroundSprite = _rowBackground.sprite;
				}
				_rowBackground.sprite = ((rowNum % 2 == 1) ? _rowAlternateBackground : _rowBackgroundSprite);
			}
		}

		protected void Update()
		{
			Refresh(setInstant: false);
		}
	}
}
