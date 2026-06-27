using System;
using System.Collections.Generic;
using Restory.Data.Identifications;
using Restory.Data.SaveLoad;
using Restory.Data.SaveLoad.Containers;
using Restory.Data.SaveLoad.DataMigration;
using Restory.Gameplay.InteractiveObjects;
using Restory.Gameplay.SaveLoad.Exceptions;
using Restory.Gameplay.Storages;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.Devices
{
	public class DeviceSaveLoadService : MonoBehaviour, ISaveableComponent, ISaveableComponentReader, ISaveableComponentWriter, IDisposable
	{
		private DeviceService deviceService;

		private DeviceRegistry deviceRegistry;

		private DevicesStoragesRegistry devicesStoragesRegistry;

		[Inject]
		private void Construct(DeviceService deviceService, DeviceRegistry deviceRegistry, DevicesStoragesRegistry devicesStoragesRegistry)
		{
			this.deviceService = deviceService;
			this.deviceRegistry = deviceRegistry;
			this.devicesStoragesRegistry = devicesStoragesRegistry;
		}

		public void Dispose()
		{
			deviceRegistry.Clear();
		}

		public void RestoreState(object state)
		{
			try
			{
				foreach (DeviceData device in DataMigrationWizard.Migrate<DeviceRegistrySaveData>(state, base.gameObject).Devices)
				{
					if (device.DeviceState == InteractiveObjectState.Placed)
					{
						deviceService.PlaceNewDeviceContainer(device);
						continue;
					}
					DeviceContainer deviceContainer = deviceService.CreateStoredDeviceContainer(device);
					switch (device.DeviceState)
					{
					case InteractiveObjectState.Stored:
						TryToPutDeviceIntoStorage(device, deviceContainer);
						break;
					case InteractiveObjectState.Delivery:
						deviceContainer.SetState(InteractiveObjectState.Delivery);
						break;
					default:
						Debug.LogError($"Unexpected device state: {device.DeviceState}");
						break;
					case InteractiveObjectState.Shipment:
						break;
					}
				}
			}
			catch (Exception innerException)
			{
				Debug.LogException(new RestoreProgressException(base.gameObject, state, innerException));
			}
		}

		public object CaptureState()
		{
			try
			{
				DeviceRegistrySaveData deviceRegistrySaveData = new DeviceRegistrySaveData
				{
					Devices = new List<DeviceData>()
				};
				foreach (DeviceContainer item in deviceRegistry.All)
				{
					deviceRegistrySaveData.Devices.Add(deviceService.CreateDeviceData(item));
				}
				return deviceRegistrySaveData;
			}
			catch (Exception innerException)
			{
				Debug.LogException(new CaptureProgressException(base.gameObject, innerException));
				return null;
			}
		}

		private bool TryToPutDeviceIntoStorage(DeviceData deviceData, DeviceContainer deviceContainer)
		{
			if (string.IsNullOrEmpty(deviceData.StorageID))
			{
				return false;
			}
			foreach (DevicesStorage storage in devicesStoragesRegistry.Storages)
			{
				if ((bool)storage && storage.TryGetComponent<Identificator>(out var component) && component.ID == deviceData.StorageID)
				{
					DevicePack componentInParent = deviceContainer.GetComponentInParent<DevicePack>();
					if ((bool)componentInParent)
					{
						componentInParent.transform.parent = storage.transform;
					}
					else
					{
						deviceContainer.transform.parent = storage.transform;
					}
					storage.AddDeviceToStorage(deviceContainer);
					return true;
				}
			}
			return false;
		}
	}
}
