using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DayEndRowUI : MonoBehaviour
{
	[Header("UI References")]
	[SerializeField]
	private TMP_Text valueText;

	[Header("Economy Types (Birden fazla eklenebilir)")]
	[Tooltip("Bu satirin toplayacagi EconomyType'lar. Birden fazla secilirse hepsi toplanir.")]
	[SerializeField]
	private List<EconomyType> economyTypes = new List<EconomyType>();

	[Header("Display Settings")]
	[SerializeField]
	private bool showPlusSign = true;

	[SerializeField]
	private string prefix = "$";

	[SerializeField]
	private string suffix = "";

	[SerializeField]
	private bool useSuffix;

	[SerializeField]
	private Color positiveColor = new Color(0.2f, 0.8f, 0.2f);

	[SerializeField]
	private Color negativeColor = new Color(0.9f, 0.3f, 0.3f);

	[SerializeField]
	private Color zeroColor = Color.white;

	public void UpdateFromMoneyData(Dictionary<EconomyType, int> incomeByType, Dictionary<EconomyType, int> expenseByType)
	{
		int num = 0;
		foreach (EconomyType economyType in economyTypes)
		{
			if (incomeByType != null && incomeByType.TryGetValue(economyType, out var value))
			{
				num += value;
			}
			if (expenseByType != null && expenseByType.TryGetValue(economyType, out var value2))
			{
				num -= value2;
			}
		}
		DisplayValue(num);
	}

	public void UpdateFromXPData(Dictionary<EconomyType, int> xpByType)
	{
		int num = 0;
		foreach (EconomyType economyType in economyTypes)
		{
			if (xpByType != null && xpByType.TryGetValue(economyType, out var value))
			{
				num += value;
			}
		}
		DisplayValue(num);
	}

	public void SetValue(int value)
	{
		DisplayValue(value);
	}

	public void SetCustomText(string text)
	{
		if (valueText != null)
		{
			valueText.text = text;
			valueText.color = zeroColor;
		}
	}

	public void SetCustomText(string text, Color color)
	{
		if (valueText != null)
		{
			valueText.text = text;
			valueText.color = color;
		}
	}

	private void DisplayValue(int value)
	{
		if (valueText == null)
		{
			return;
		}
		string arg = "";
		Color color = zeroColor;
		if (value > 0)
		{
			if (showPlusSign)
			{
				arg = "+";
			}
			color = positiveColor;
		}
		else if (value < 0)
		{
			arg = "-";
			value = Mathf.Abs(value);
			color = negativeColor;
		}
		if (useSuffix)
		{
			valueText.text = $"{arg}{value:N0}{suffix}";
		}
		else
		{
			valueText.text = $"{arg}{prefix}{value:N0}";
		}
		valueText.color = color;
	}
}
