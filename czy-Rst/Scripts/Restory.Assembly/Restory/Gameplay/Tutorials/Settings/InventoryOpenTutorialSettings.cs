using System;
using Restory.Data.Devices;
using UnityEngine;

namespace Restory.Gameplay.Tutorials.Settings
{
	[Serializable]
	public class InventoryOpenTutorialSettings
	{
		[SerializeField]
		private DeviceInfo targetDeviceInfo;

		public DeviceInfo TargetDeviceInfo => targetDeviceInfo;
	}
}
