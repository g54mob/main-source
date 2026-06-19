using System;
using System.Collections.Generic;
using System.Globalization;
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
	public class HospitalEventLogMenuRow : MonoBehaviour
	{
		[Serializable]
		private struct ReputationIndicatorThresholdItem
		{
			public float inputThresholdValue;

			public Image repArrowsImage;
		}

		[InspectorMargin(8)]
		[InspectorHeader("General")]
		[SerializeField]
		private TMP_Text _textDate;

		[SerializeField]
		private GameDateCellComparable _gameDateCellComparable;

		[SerializeField]
		private Image _iconEvent;

		[SerializeField]
		private TooltipSpawner _iconTooltip;

		[SerializeField]
		private TMP_Text _textDescription;

		[SerializeField]
		private TMP_Text _textMoney;

		[SerializeField]
		private TMP_Text _textDiagnosis;

		[SerializeField]
		private GameObject _textMoneyPanel;

		[SerializeField]
		private GameObject _textDiagnosisPanel;

		[SerializeField]
		private Image _iconDiagnosis;

		[SerializeField]
		private Image _rowBGImage;

		[SerializeField]
		private Color _rowColour1 = Color.white;

		[SerializeField]
		private Color _rowColour2 = Color.black;

		[InspectorMargin(8)]
		[InspectorHeader("Reputation")]
		[SerializeField]
		private GameObject _repArrowsPanel;

		[SerializeField]
		private Sprite _repArrowsImageLeftBG;

		[SerializeField]
		private Sprite _repArrowsImageRightBG;

		[SerializeField]
		private Sprite _repArrowsImageLeftActive;

		[SerializeField]
		private Sprite _repArrowsImageRightActive;

		[InspectorMargin(8)]
		[InspectorHeader("Reputation Thresholds")]
		[SerializeField]
		private bool _showRepValues;

		[SerializeField]
		private bool _showRepIndicators = true;

		[SerializeField]
		private TMP_Text _repValuesText;

		[SerializeField]
		private TooltipSpawner _reputationTooltip;

		[SerializeField]
		private List<ReputationIndicatorThresholdItem> _thresholdData = new List<ReputationIndicatorThresholdItem>();

		[InspectorMargin(8)]
		[InspectorHeader("Progress Bars")]
		[SerializeField]
		private ProgressBarMaskable _illnessDifficulty;

		[SerializeField]
		private ProgressBarMaskable _diagnosisCertainty;

		[SerializeField]
		private ProgressBarMaskable _staffSkill;

		[SerializeField]
		private ProgressBarMaskable _upgrades;

		[SerializeField]
		private TooltipSpawner _illnessDifficultyTooltip;

		[SerializeField]
		private TooltipSpawner _diagnosisCertaintyTooltip;

		[SerializeField]
		private TooltipSpawner _staffSkillTooltip;

		[SerializeField]
		private TooltipSpawner _upgradesTooltip;

		private Level _level;

		private string _cachedTooltipReputationValueString;

		private float _cachedTooltipIllnessDifficultyValue;

		private float _cachedTooltipDiagnosisCertaintyValue;

		private float _cachedTooltipStaffSkillValue;

		private float _cachedTooltipUpgradesValue;

		public void Initialise(Level level, HospitalEvent hospitalEvent, int rowIndex, bool generateTestData)
		{
			SetupRowBG(rowIndex);
			_cachedTooltipIllnessDifficultyValue = -1f;
			_cachedTooltipDiagnosisCertaintyValue = -1f;
			_cachedTooltipStaffSkillValue = -1f;
			_cachedTooltipUpgradesValue = -1f;
			_gameDateCellComparable.Value = hospitalEvent.Date;
			_textDate.text = hospitalEvent.GetDateString();
			_iconEvent.sprite = hospitalEvent.GetEventIcon();
			_textDescription.text = hospitalEvent.GetDescription();
			_iconTooltip.SetDataProvider(delegate(Tooltip tooltip)
			{
				tooltip.Text = hospitalEvent.GetIconTooltip();
			});
			IHospitalEventFinance hospitalEventFinance = hospitalEvent as IHospitalEventFinance;
			bool flag = hospitalEventFinance?.IsFinanceValueValid() ?? false;
			if (flag)
			{
				_textMoney.text = StringUtils.FormatCurrency(hospitalEventFinance.GetFinanceValue());
			}
			else
			{
				_textMoney.text = "";
			}
			if (_textMoneyPanel != null)
			{
				_textMoneyPanel.SetActive(flag);
			}
			IHospitalEventReputation hospitalEventReputation = hospitalEvent as IHospitalEventReputation;
			bool flag2 = false;
			float num = 0f;
			if (hospitalEventReputation != null && hospitalEventReputation.GetReputationValue().CompareTo(0f) != 0)
			{
				flag2 = true;
				num = hospitalEventReputation.GetReputationValue();
			}
			UpdateReputationIndicators(flag2, num);
			_cachedTooltipReputationValueString = StringUtils.FormatFloat(num, prefixPlus: true);
			IHospitalEventDiagnosis hospitalEventDiagnosis = hospitalEvent as IHospitalEventDiagnosis;
			IHospitalEventTreatment hospitalEventTreatment = hospitalEvent as IHospitalEventTreatment;
			if (hospitalEventDiagnosis != null)
			{
				Sprite diagnosisSprite = hospitalEventDiagnosis.GetDiagnosisSprite();
				if (diagnosisSprite != null)
				{
					_iconDiagnosis.sprite = diagnosisSprite;
				}
				else
				{
					_textDiagnosis.text = StringUtils.FormatPercentageValue(hospitalEventDiagnosis.GetDiagnosisValue() / 100f, prefixPlus: true);
				}
				GameObjectUtils.SetActive(_textDiagnosisPanel, diagnosisSprite == null);
				GameObjectUtils.SetActive(_iconDiagnosis.gameObject, diagnosisSprite != null);
			}
			else if (hospitalEventTreatment != null)
			{
				Sprite treatmentSprite = hospitalEventTreatment.GetTreatmentSprite();
				TreatmentCalculationBreakdown treatmenBreakdown = hospitalEventTreatment.GetTreatmenBreakdown();
				if (treatmentSprite != null)
				{
					_iconDiagnosis.sprite = treatmentSprite;
				}
				_illnessDifficulty.Progress = treatmenBreakdown.IllnessDifficulty / 100f;
				_diagnosisCertainty.Progress = treatmenBreakdown.DiagnosisCertainty / 100f;
				_staffSkill.Progress = treatmenBreakdown.StaffSkillPercent;
				_upgrades.Progress = treatmenBreakdown.RoomModifiersPercent;
				_cachedTooltipIllnessDifficultyValue = _illnessDifficulty.Progress;
				_cachedTooltipDiagnosisCertaintyValue = _diagnosisCertainty.Progress;
				_cachedTooltipStaffSkillValue = _staffSkill.Progress;
				_cachedTooltipUpgradesValue = _upgrades.Progress;
				GameObjectUtils.SetActive(_textDiagnosisPanel, isActive: false);
				GameObjectUtils.SetActive(_iconDiagnosis.gameObject, treatmentSprite != null);
			}
			else
			{
				GameObjectUtils.SetActive(_textDiagnosisPanel, isActive: false);
				GameObjectUtils.SetActive(_iconDiagnosis.gameObject, isActive: false);
			}
			GameObjectUtils.SetActive(_illnessDifficulty.gameObject, hospitalEventTreatment != null);
			GameObjectUtils.SetActive(_diagnosisCertainty.gameObject, hospitalEventTreatment != null);
			GameObjectUtils.SetActive(_staffSkill.gameObject, hospitalEventTreatment != null);
			GameObjectUtils.SetActive(_upgrades.gameObject, hospitalEventTreatment != null);
			if (_reputationTooltip != null)
			{
				if (flag2)
				{
					_reputationTooltip.SetDataProvider(delegate(Tooltip tooltip)
					{
						tooltip.Text = string.Format(ScriptLocalization.HospitalEvent.HospitalReputation_CS, _cachedTooltipReputationValueString);
					});
				}
				else
				{
					_reputationTooltip.enabled = false;
				}
			}
			if (_illnessDifficultyTooltip != null && _cachedTooltipIllnessDifficultyValue >= 0f)
			{
				_illnessDifficultyTooltip.SetDataProvider(delegate(Tooltip tooltip)
				{
					tooltip.Text = string.Format(ScriptLocalization.HospitalEvent.IllnessDifficulty_CS, StringUtils.FormatPercentageValue(_cachedTooltipIllnessDifficultyValue));
				});
			}
			if (_diagnosisCertaintyTooltip != null && _cachedTooltipDiagnosisCertaintyValue >= 0f)
			{
				_diagnosisCertaintyTooltip.SetDataProvider(delegate(Tooltip tooltip)
				{
					tooltip.Text = string.Format(ScriptLocalization.HospitalEvent.DiagnosisCertainty_CS, StringUtils.FormatPercentageValue(_cachedTooltipDiagnosisCertaintyValue));
				});
			}
			if (_staffSkillTooltip != null && _cachedTooltipStaffSkillValue >= 0f)
			{
				_staffSkillTooltip.SetDataProvider(delegate(Tooltip tooltip)
				{
					tooltip.Text = string.Format(ScriptLocalization.HospitalEvent.StaffSkill_CS, StringUtils.FormatPercentageValue(_cachedTooltipStaffSkillValue));
				});
			}
			if (_upgradesTooltip != null && _cachedTooltipUpgradesValue >= 0f)
			{
				_upgradesTooltip.SetDataProvider(delegate(Tooltip tooltip)
				{
					tooltip.Text = string.Format(ScriptLocalization.HospitalEvent.Upgrades_CS, StringUtils.FormatPercentageValue(_cachedTooltipUpgradesValue));
				});
			}
		}

		public void SetRowIndex(int rowIndex)
		{
			SetupRowBG(rowIndex);
		}

		private void SetupRowBG(int rowIndex)
		{
			if (_rowBGImage != null)
			{
				_rowBGImage.color = (((rowIndex & 1) == 0) ? _rowColour1 : _rowColour2);
			}
		}

		private void UpdateReputationIndicators(bool showRep, float reputationValue)
		{
			bool flag = showRep && _showRepIndicators && _thresholdData.Count > 0;
			bool flag2 = false;
			if (_repArrowsPanel != null)
			{
				_repArrowsPanel.SetActive(flag);
			}
			if (_repValuesText != null)
			{
				_repValuesText.gameObject.SetActive(flag2);
			}
			if (flag)
			{
				float num = Mathf.Abs(reputationValue);
				int count = _thresholdData.Count;
				int num2 = count;
				for (int i = 0; i < count - 1; i++)
				{
					if (num < _thresholdData[i].inputThresholdValue)
					{
						num2 = i + 1;
						break;
					}
				}
				bool flag3 = reputationValue >= 0f;
				Sprite sprite = (flag3 ? _repArrowsImageRightBG : _repArrowsImageLeftBG);
				Sprite sprite2 = (flag3 ? _repArrowsImageRightActive : _repArrowsImageLeftActive);
				for (int j = 0; j < count; j++)
				{
					int index = (flag3 ? j : (count - j - 1));
					if (_thresholdData[index].repArrowsImage != null)
					{
						Sprite overrideSprite = ((j >= num2) ? sprite : sprite2);
						_thresholdData[index].repArrowsImage.overrideSprite = overrideSprite;
					}
				}
			}
			if (flag2)
			{
				_repValuesText.text = reputationValue.ToString(CultureInfo.InvariantCulture);
			}
		}
	}
}
