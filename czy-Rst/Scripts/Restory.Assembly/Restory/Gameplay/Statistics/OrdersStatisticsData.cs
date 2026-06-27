using System;
using System.Collections.Generic;

namespace Restory.Gameplay.Statistics
{
	[Serializable]
	public class OrdersStatisticsData
	{
		public int AllTimeCompletedOrdersCount;

		public int PreviousDayAssignedOrdersCount;

		public List<int> AssignedOrdersIDs = new List<int>();
	}
}
