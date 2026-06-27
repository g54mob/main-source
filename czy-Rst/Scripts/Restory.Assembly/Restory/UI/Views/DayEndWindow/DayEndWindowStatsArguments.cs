using System.Collections.Generic;
using Restory.Gameplay.Statistics;

namespace Restory.UI.Views.DayEndWindow
{
	public class DayEndWindowStatsArguments
	{
		public int CurrentDay;

		public OrdersStatisticsData WorkOrdersStatistics;

		public OrdersStatisticsData EmailOrdersStatistics;

		public List<GameStatisticsSentDeviceRecord> ClaimedWorkOrders;

		public List<GameStatisticsSentDeviceRecord> ClaimedEmailOrders;

		public List<GameStatisticsSentDeviceRecord> SoldDevices;

		public MoneyReceiptData MoneyReceiptData;
	}
}
