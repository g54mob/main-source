using MLCN_Localization;
using TMPro;
using UnityEngine;

public class FinanceFlavourSlot : MonoBehaviour
{
	[SerializeField]
	private TMP_Text labelTitle;

	[SerializeField]
	private TMP_Text labelValue;

	[SerializeField]
	private TMP_Text labelMarketValue;

	[SerializeField]
	private Color colorKnown = Color.white;

	[SerializeField]
	private Color colorUnknown = Color.gray;

	public string flavourName;

	public void Init(string flavourName, int value, int additionalValue, bool locked)
	{
		UpdateSlot(flavourName, value, additionalValue, locked);
	}

	public void UpdateSlot(string flavourName, int value, int additionalValue, bool locked)
	{
		this.flavourName = flavourName;
		if (locked)
		{
			labelTitle.text = LocalizationManager.GetLocalizedString("com_finance_label_unknown", LocalizationDataTable.Tables.ComputerElements);
			labelValue.text = "...";
			labelMarketValue.text = "";
			labelTitle.color = colorUnknown;
			labelValue.color = colorUnknown;
		}
		else
		{
			labelTitle.text = flavourName;
			labelValue.text = ((value >= 0) ? ("+" + value) : ("-" + value));
			labelMarketValue.text = ((additionalValue >= 0) ? ("+<color=#6BFFE3>" + additionalValue + "</color>") : ("-<color=#ffc880>" + additionalValue + "</color>"));
			labelTitle.color = colorKnown;
			labelValue.color = colorKnown;
		}
	}
}
