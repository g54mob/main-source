using TMPro;
using UnityEngine;

namespace Restory.UI.Views.DayEndWindow
{
	public class GUI_DayEndWindowStatsView : MonoBehaviour
	{
		[SerializeField]
		private TMP_Text currentDayNumberText;

		[SerializeField]
		private GUI_RepairOrdersView repairedWorkOrders;

		[SerializeField]
		private GUI_RepairOrdersView repairedEmailOrders;

		[SerializeField]
		private GUI_FreeSalesView freeSales;

		[SerializeField]
		private GUI_MoneyReceiptView moneyReceipt;

		public void ShowStats(DayEndWindowStatsArguments arguments)
		{
			currentDayNumberText.text = arguments.CurrentDay.ToString();
			repairedWorkOrders.Init(arguments.WorkOrdersStatistics, arguments.ClaimedWorkOrders);
			repairedEmailOrders.Init(arguments.EmailOrdersStatistics, arguments.ClaimedEmailOrders);
			freeSales.Init(arguments.SoldDevices);
			moneyReceipt.Init(arguments.MoneyReceiptData);
		}
	}
}
