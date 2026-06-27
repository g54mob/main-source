using System.Collections.Generic;
using UnityEngine;

namespace Restory.Data.Devices
{
	[CreateAssetMenu(menuName = "Restory/Devices/AvailableDevicesGlobalPool", fileName = "AvailableDevicesGlobalPool")]
	public class AvailableDevicesList : ScriptableObject
	{
		[SerializeField]
		private List<AvailableDevicesListEntry> allDevices = new List<AvailableDevicesListEntry>();

		[SerializeField]
		private DeviceInfoDatabase devicesDatabase;

		public List<AvailableDevicesListEntry> AllDevices => allDevices;
	}
}
