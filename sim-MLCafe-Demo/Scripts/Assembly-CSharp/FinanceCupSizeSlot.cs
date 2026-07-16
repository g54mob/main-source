using MLCN_Localization;
using TMPro;
using UnityEngine;

public class FinanceCupSizeSlot : MonoBehaviour
{
	[SerializeField]
	private TMP_Text labelTitle;

	[SerializeField]
	private TMP_Text labelValue;

	[SerializeField]
	private Color colorKnown = Color.white;

	[SerializeField]
	private Color colorUnknown = Color.gray;

	public void Init(string flavourName, float value, bool locked)
	{
		if (locked)
		{
			labelTitle.text = LocalizationManager.GetLocalizedString("com_finance_label_unknown", LocalizationDataTable.Tables.ComputerElements);
			labelValue.text = "...";
			labelTitle.color = colorUnknown;
			labelValue.color = colorUnknown;
		}
		else
		{
			labelTitle.text = flavourName;
			labelValue.text = "x" + value;
			labelTitle.color = colorKnown;
			labelValue.color = colorKnown;
		}
	}

	public void UpdateSlot()
	{
	}
}
