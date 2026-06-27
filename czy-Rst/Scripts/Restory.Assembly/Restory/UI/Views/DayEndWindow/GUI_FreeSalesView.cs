using System.Collections.Generic;
using Restory.Gameplay.Statistics;
using Restory.UI.Presenters.Devices;
using TMPro;
using UnityEngine;

namespace Restory.UI.Views.DayEndWindow
{
	public class GUI_FreeSalesView : MonoBehaviour
	{
		[SerializeField]
		private TMP_Text soldDevicesCountText;

		[SerializeField]
		private Transform soldDevicesIconsParent;

		[SerializeField]
		private GUI_DeviceIcon deviceIconPrefab;

		public void Init(List<GameStatisticsSentDeviceRecord> soldDevices)
		{
			if (soldDevices == null || soldDevices.Count == 0)
			{
				base.gameObject.SetActive(value: false);
				return;
			}
			for (int i = 0; i < soldDevicesIconsParent.childCount; i++)
			{
				Object.Destroy(soldDevicesIconsParent.GetChild(i).gameObject);
			}
			foreach (GameStatisticsSentDeviceRecord soldDevice in soldDevices)
			{
				Object.Instantiate(deviceIconPrefab, soldDevicesIconsParent).Initialize(soldDevice.DeviceInfo, soldDevice.DeviceQuality);
			}
			SetSoldDevicesText(soldDevices.Count);
		}

		private void SetSoldDevicesText(int soldDevicesTodayCount)
		{
			soldDevicesCountText.text = $"{soldDevicesTodayCount}";
		}
	}
}
