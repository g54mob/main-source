using TMPro;
using UnityEngine;

public class ContractStatItemUI : MonoBehaviour
{
	[Header("UI Elements")]
	[Tooltip("Stat değeri")]
	[SerializeField]
	private TextMeshProUGUI valueText;

	[Header("Colors")]
	[Tooltip("Pozitif değer rengi (bonus)")]
	[SerializeField]
	private Color positiveColor = new Color(0.2f, 0.8f, 0.2f);

	[Tooltip("Negatif değer rengi (ceza)")]
	[SerializeField]
	private Color negativeColor = new Color(0.8f, 0.2f, 0.2f);

	[Tooltip("Nötr değer rengi")]
	[SerializeField]
	private Color neutralColor = Color.white;

	public void Initialize(int value, bool showSign = true)
	{
		if (valueText == null)
		{
			return;
		}
		if (showSign)
		{
			if (value > 0)
			{
				valueText.text = $"+${value:N0}";
				valueText.color = positiveColor;
			}
			else if (value < 0)
			{
				valueText.text = $"-${Mathf.Abs(value):N0}";
				valueText.color = negativeColor;
			}
			else
			{
				valueText.text = "$0";
				valueText.color = neutralColor;
			}
		}
		else
		{
			valueText.text = $"${value:N0}";
			valueText.color = neutralColor;
		}
	}
}
