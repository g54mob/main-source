using MLCN_Localization;
using TMPro;
using UnityEngine;

public class FinanceOrderSlot : MonoBehaviour
{
	[SerializeField]
	private TMP_Text labelTitle;

	[SerializeField]
	private TMP_Text labelValue;

	[SerializeField]
	private TMP_Text labelNumber;

	private PlacedOrder order;

	private GameTime orderTime;

	public void Init(PlacedOrder order, GameTime time, int number)
	{
		this.order = order;
		orderTime = time;
		labelNumber.text = "#" + number;
		labelValue.text = "-" + order.totalPrice;
		UpdateNameLocalization();
	}

	public void UpdateNameLocalization()
	{
		string text = LocalizationManager.GetLocalizedString("com_finance_order", LocalizationDataTable.Tables.ComputerElements) + " - " + orderTime.GetTimeFormatted();
		labelTitle.text = text;
	}
}
