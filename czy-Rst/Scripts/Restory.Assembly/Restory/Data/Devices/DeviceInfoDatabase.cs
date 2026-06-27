using System.Collections.Generic;
using System.Linq;
using Restory.Data.Elements;
using UnityEngine;
using Zenject;

namespace Restory.Data.Devices
{
	[CreateAssetMenu(menuName = "Restory/Devices/DeviceInfoDatabase", fileName = "Name - DeviceInfoDatabase")]
	public class DeviceInfoDatabase : ScriptableObject, IInitializable
	{
		[SerializeField]
		private List<DeviceInfo> devices;

		public IReadOnlyCollection<IDeviceInfo> Devices => devices;

		public void Initialize()
		{
			foreach (DeviceInfo device in devices)
			{
				foreach (IElementInfo element in device.Elements)
				{
					element.SourceDevice = device;
				}
			}
		}

		public bool TryGetDeviceInfo(IElementInfo elementInfo, out IDeviceInfo deviceInfo)
		{
			foreach (DeviceInfo device in devices)
			{
				if (device.Elements.Contains(elementInfo))
				{
					deviceInfo = device;
					return true;
				}
			}
			deviceInfo = null;
			return false;
		}
	}
}
