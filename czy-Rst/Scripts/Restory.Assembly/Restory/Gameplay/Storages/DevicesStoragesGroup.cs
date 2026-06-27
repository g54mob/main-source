using System;
using System.Collections.Generic;
using Restory.Gameplay.Devices;
using Restory.Utils;
using UnityEngine;

namespace Restory.Gameplay.Storages
{
	public class DevicesStoragesGroup : MonoBehaviour
	{
		[SerializeField]
		private DevicesStorage[] devicesStorages = new DevicesStorage[0];

		public event Action OnStoragesContentsChanged;

		private void OnEnable()
		{
			DevicesStorage[] array = devicesStorages;
			foreach (DevicesStorage devicesStorage in array)
			{
				if (devicesStorage.MonoShellExists())
				{
					devicesStorage.OnStorageContentsChanged += ResolveStorageContentsChanged;
				}
			}
		}

		private void OnDisable()
		{
			DevicesStorage[] array = devicesStorages;
			foreach (DevicesStorage devicesStorage in array)
			{
				if (devicesStorage.MonoShellExists())
				{
					devicesStorage.OnStorageContentsChanged -= ResolveStorageContentsChanged;
				}
			}
		}

		public IEnumerable<DeviceContainer> GetAllDevicesInStorages()
		{
			DevicesStorage[] array = devicesStorages;
			foreach (DevicesStorage devicesStorage in array)
			{
				foreach (DeviceContainer storedDevice in devicesStorage.StoredDevices)
				{
					if ((bool)storedDevice)
					{
						yield return storedDevice;
					}
				}
			}
		}

		public bool IsDeviceInOneOfTheStorages(DeviceContainer deviceToCheck)
		{
			DevicesStorage[] array = devicesStorages;
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i].IsDeviceInStorage(deviceToCheck))
				{
					return true;
				}
			}
			return false;
		}

		private void ResolveStorageContentsChanged()
		{
			this.OnStoragesContentsChanged?.Invoke();
		}
	}
}
