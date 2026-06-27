using System.Collections.Generic;
using Restory.Gameplay.Statistics;
using Restory.UI.Presenters.Devices;
using TMPro;
using UnityEngine;

namespace Restory.UI.Views.DayEndWindow
{
	public class GUI_RepairOrdersView : MonoBehaviour
	{
		[SerializeField]
		private TMP_Text claimedOrdersCountText;

		[SerializeField]
		private TMP_Text ordersInProgressCountText;

		[SerializeField]
		private Transform soldDevicesIconsParent;

		[SerializeField]
		private GUI_DeviceIcon deviceIconPrefab;

		public void Init(OrdersStatisticsData ordersStatistics, List<GameStatisticsSentDeviceRecord> claimedOrders)
		{
			if (ordersStatistics.AssignedOrdersIDs.Count == 0 && claimedOrders.Count == 0)
			{
				base.gameObject.SetActive(value: false);
				return;
			}
			for (int i = 0; i < soldDevicesIconsParent.childCount; i++)
			{
				Object.Destroy(soldDevicesIconsParent.GetChild(i).gameObject);
			}
			foreach (GameStatisticsSentDeviceRecord claimedOrder in claimedOrders)
			{
				Object.Instantiate(deviceIconPrefab, soldDevicesIconsParent).Initialize(claimedOrder.DeviceInfo, claimedOrder.DeviceQuality);
			}
			SetOrdersInProgressText(ordersStatistics.AssignedOrdersIDs.Count);
			SetOrdersCompletedText(claimedOrders.Count);
		}

		private void SetOrdersCompletedText(int ordersCompletedToday)
		{
			claimedOrdersCountText.text = $"{ordersCompletedToday}";
		}

		private void SetOrdersInProgressText(int ordersInProgressToday)
		{
			ordersInProgressCountText.text = $"{ordersInProgressToday}";
		}
	}
}
