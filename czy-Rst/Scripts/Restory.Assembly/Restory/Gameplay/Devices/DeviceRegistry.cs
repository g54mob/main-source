using System;
using System.Collections.Generic;

namespace Restory.Gameplay.Devices
{
	public class DeviceRegistry
	{
		private readonly HashSet<DeviceContainer> all = new HashSet<DeviceContainer>();

		public IReadOnlyCollection<DeviceContainer> All => all;

		public event Action<DeviceContainer> OnDeviceRegistered;

		public event Action<DeviceContainer> OnDeviceUnregistered;

		public void Register(DeviceContainer device)
		{
			all.Add(device);
			this.OnDeviceRegistered?.Invoke(device);
		}

		public void Unregister(DeviceContainer device)
		{
			all.Remove(device);
			this.OnDeviceUnregistered?.Invoke(device);
		}

		public void Clear()
		{
			all.Clear();
		}
	}
}
