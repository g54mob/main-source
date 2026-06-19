using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	public class InspectorCharacterLogRow : MonoBehaviour
	{
		[SerializeField]
		private TMP_Text _text;

		[SerializeField]
		private Image _icon;

		[SerializeField]
		private Image _backing;

		public void Setup(HospitalEvent hospitalEvent, Color backingColor, Color dateColor)
		{
			_backing.color = backingColor;
			if (hospitalEvent == null)
			{
				_icon.overrideSprite = null;
				_text.text = string.Empty;
				return;
			}
			_icon.overrideSprite = hospitalEvent.GetEventIcon();
			string text = $"<color=#{ColorUtility.ToHtmlStringRGB(dateColor)}>{hospitalEvent.GetDateString()}:</color> {hospitalEvent.GetDescription()}";
			if (hospitalEvent is IHospitalEventFinance hospitalEventFinance && hospitalEventFinance.IsFinanceValueValid())
			{
				text += $" ({StringUtils.FormatCurrency(hospitalEventFinance.GetFinanceValue())})";
			}
			if (hospitalEvent is IHospitalEventReputation hospitalEventReputation)
			{
				text += $" ({StringUtils.FormatReputationValue((int)hospitalEventReputation.GetReputationValue())})";
			}
			if (hospitalEvent is IHospitalEventDiagnosis hospitalEventDiagnosis)
			{
				text += $" ({StringUtils.FormatPercentageValue(hospitalEventDiagnosis.GetDiagnosisValue() / 100f, prefixPlus: true)})";
			}
			_text.text = text;
		}
	}
}
