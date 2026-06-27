using System.Collections.Generic;
using Restory.Gameplay.InteractiveObjects;
using UnityEngine;

namespace Restory.Gameplay.Storages
{
	public class DevicesFromNpcsSpawnPoints : MonoBehaviour
	{
		[SerializeField]
		private Transform[] deviceSpawnPoints = new Transform[0];

		private InteractiveObject[] registeredDevices;

		public IReadOnlyList<InteractiveObject> DevicesAtSpawnPoints => registeredDevices;

		private void Awake()
		{
			registeredDevices = new InteractiveObject[deviceSpawnPoints.Length];
		}

		public bool TryToGetVacantSpawnPoint(out Transform spawnPoint)
		{
			for (int i = 0; i < registeredDevices.Length; i++)
			{
				if (registeredDevices[i] == null)
				{
					spawnPoint = deviceSpawnPoints[i];
					return true;
				}
			}
			spawnPoint = null;
			return false;
		}

		public bool TryToRegisterDeviceAtSpawnPoint(InteractiveObject targetDevice, Transform spawnPoint)
		{
			for (int i = 0; i < deviceSpawnPoints.Length; i++)
			{
				if (deviceSpawnPoints[i] == spawnPoint)
				{
					registeredDevices[i] = targetDevice;
					return true;
				}
			}
			return false;
		}

		public bool UnregisterDeviceFromSpawnPoint(InteractiveObject deviceContainer)
		{
			if (!deviceContainer)
			{
				return false;
			}
			bool result = false;
			for (int i = 0; i < registeredDevices.Length; i++)
			{
				if (registeredDevices[i] == deviceContainer)
				{
					registeredDevices[i] = null;
					result = true;
				}
			}
			return result;
		}

		public void UnregisterDeviceFromSpawnPoint(Transform spawnPoint)
		{
			for (int i = 0; i < deviceSpawnPoints.Length; i++)
			{
				if (deviceSpawnPoints[i] == spawnPoint)
				{
					registeredDevices[i] = null;
				}
			}
		}

		public void AttachRestoredDevicesToSpawnPoints(InteractiveObject[] restoredDevicesAtSpawnPoints)
		{
			for (int i = 0; i < registeredDevices.Length; i++)
			{
				registeredDevices[i] = restoredDevicesAtSpawnPoints[i];
			}
		}
	}
}
