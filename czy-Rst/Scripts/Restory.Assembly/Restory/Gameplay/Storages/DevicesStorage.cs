using System;
using System.Collections.Generic;
using Restory.Gameplay.Devices;
using Restory.Gameplay.InteractiveObjects;
using UnityEngine;

namespace Restory.Gameplay.Storages
{
	public class DevicesStorage : MonoBehaviour
	{
		private readonly List<DeviceContainer> storedDevices = new List<DeviceContainer>();

		public bool HasNoDevices => storedDevices.Count == 0;

		public IReadOnlyList<DeviceContainer> StoredDevices => storedDevices;

		public event Action OnStorageContentsChanged;

		public void AddDeviceToStorage(InteractiveObject deviceToAdd)
		{
			if (!(deviceToAdd is DeviceContainer item))
			{
				if (!(deviceToAdd is DevicePack devicePack) || storedDevices.Contains(devicePack.DeviceContainer))
				{
					return;
				}
				storedDevices.Add(devicePack.DeviceContainer);
			}
			else
			{
				if (storedDevices.Contains(item))
				{
					return;
				}
				storedDevices.Add(item);
			}
			this.OnStorageContentsChanged?.Invoke();
		}

		public void RemoveDeviceFromStorage(InteractiveObject deviceToRemove)
		{
			if (!(deviceToRemove is DeviceContainer item))
			{
				if (!(deviceToRemove is DevicePack devicePack) || !storedDevices.Contains(devicePack.DeviceContainer))
				{
					return;
				}
				storedDevices.Remove(devicePack.DeviceContainer);
			}
			else
			{
				if (!storedDevices.Contains(item))
				{
					return;
				}
				storedDevices.Remove(item);
			}
			this.OnStorageContentsChanged?.Invoke();
		}

		public bool IsDeviceInStorage(InteractiveObject deviceToCheck)
		{
			if (!(deviceToCheck is DeviceContainer deviceContainer))
			{
				if (!(deviceToCheck is DevicePack devicePack))
				{
					throw new NotImplementedException();
				}
				foreach (DeviceContainer storedDevice in storedDevices)
				{
					if ((bool)storedDevice && storedDevice == devicePack.DeviceContainer)
					{
						return true;
					}
				}
			}
			else
			{
				foreach (DeviceContainer storedDevice2 in storedDevices)
				{
					if ((bool)storedDevice2 && storedDevice2 == deviceContainer)
					{
						return true;
					}
				}
			}
			return false;
		}
	}
}
