using System.Collections.Generic;
using UnityEngine;

namespace Restory.Data.Devices
{
	[CreateAssetMenu(menuName = "Restory/Devices/DeviceCategoriesDatabase", fileName = "DeviceCategoriesDatabase")]
	public class DeviceCategoriesDatabase : ScriptableObject
	{
		[SerializeField]
		private DeviceCategory allDevicesCategory;

		[SerializeField]
		private List<DeviceCategory> deviceCategories = new List<DeviceCategory>();

		public IDeviceCategory AllDevicesCategory => allDevicesCategory;

		public IReadOnlyList<IDeviceCategory> DeviceCategories => deviceCategories;
	}
}
