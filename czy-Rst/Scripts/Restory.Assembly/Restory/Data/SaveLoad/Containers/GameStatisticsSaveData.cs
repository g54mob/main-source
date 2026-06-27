using System;
using System.Collections.Generic;
using Restory.Data.RegularPayments;
using Restory.Gameplay.Statistics;

namespace Restory.Data.SaveLoad.Containers
{
	[Serializable]
	public class GameStatisticsSaveData
	{
		public bool ClearDataInTheMorning;

		public int CurrentDay;

		public OrdersStatisticsData WorkOrdersStatistics;

		public OrdersStatisticsData EmailOrdersStatistics;

		public RegularPaymentInfo[] RegularPaymentsMade;

		public Expense[] Expenses;

		public int MoneyAtDayStart;

		public int MoneyChanged;

		public GameStatisticsSentDeviceSaveData[] SentDevices;

		public List<GameStatisticsSentDecorData> SentDecors;
	}
}
