using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class DailyReportDataUI : MonoBehaviour
{
	[SerializeField]
	[FormerlySerializedAs("_lostText")]
	private TextMeshProUGUI _consumedField;

	[SerializeField]
	private TextMeshProUGUI _ingredientsField;

	[SerializeField]
	[FormerlySerializedAs("_gainedText")]
	private TextMeshProUGUI _craftedField;

	[SerializeField]
	private FloatStringTransformer _stringTransformer;

	[Header("Gained")]
	[SerializeField]
	private Image _gainedImage;

	[SerializeField]
	[FormerlySerializedAs("_netText")]
	private TextMeshProUGUI _dailyGainField;

	[SerializeField]
	private Color _negativeGains = Color.red;

	[SerializeField]
	private Color _positiveGains = Color.green;

	public void UpdateReport(DailyReportTableData report)
	{
		_craftedField.text = _stringTransformer.ReturnString(report.Gained);
		_ingredientsField.text = _stringTransformer.ReturnString(report.Ingredients);
		_consumedField.text = _stringTransformer.ReturnString(report.Lost);
		float num = report.Gained - report.Ingredients - report.Lost;
		_dailyGainField.text = _stringTransformer.ReturnString(num);
		if (num >= 0f)
		{
			_gainedImage.color = _positiveGains;
		}
		else
		{
			_gainedImage.color = _negativeGains;
		}
	}
}
