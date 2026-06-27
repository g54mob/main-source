using System;
using System.Collections.Generic;
using Restory.Data.Devices;
using Restory.Data.Licenses;
using Restory.Data.SaveLoad;
using Restory.Gameplay.Licenses;
using Restory.Utils;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.WorkOrders.EmailOrders
{
	public class AvailableDevicesListTrackingService : MonoBehaviour, IInitializable, IDisposable, IPostRestoreComponent
	{
		[SerializeField]
		private AvailableDevicesList availableDevicesList;

		private LicensesService licensesService;

		private List<AvailableDevicesListEntry> originalList = new List<AvailableDevicesListEntry>();

		private List<AvailableDevicesListEntry> currentList = new List<AvailableDevicesListEntry>();

		public IReadOnlyList<AvailableDevicesListEntry> AllDevices => currentList;

		public event Action<AvailableDevicesListEntry> OnDeviceMadeAvailable;

		[Inject]
		private void Construct(LicensesService licensesService)
		{
			this.licensesService = licensesService;
		}

		public void Initialize()
		{
			licensesService.OnLicenseAdded += ResolveLicenseAdded;
		}

		public void Dispose()
		{
			if (licensesService.MonoShellExists())
			{
				licensesService.OnLicenseAdded -= ResolveLicenseAdded;
			}
		}

		private void ResolveLicenseAdded(LicensesService licensesService, LicenseInfo newLicense)
		{
			foreach (AvailableDevicesListEntry current in currentList)
			{
				if (current.Device.ID == newLicense.DeviceInfo.ID && !current.IsAvailable)
				{
					current.IsAvailable = true;
					this.OnDeviceMadeAvailable?.Invoke(current);
				}
			}
		}

		public IEnumerable<AvailableDevicesListEntry> GetAvailableDevicesList()
		{
			foreach (AvailableDevicesListEntry current in currentList)
			{
				if (current.IsAvailable)
				{
					yield return current;
				}
			}
		}

		public void PostRestore()
		{
			if (currentList.Count == 0)
			{
				foreach (AvailableDevicesListEntry allDevice in availableDevicesList.AllDevices)
				{
					if (allDevice != null && (bool)allDevice.Device)
					{
						originalList.Add(allDevice);
						currentList.Add(allDevice);
					}
				}
			}
			foreach (LicenseInfo activeLicense in licensesService.ActiveLicenses)
			{
				if (!activeLicense)
				{
					continue;
				}
				foreach (AvailableDevicesListEntry current in currentList)
				{
					if (current.Device.ID == activeLicense.DeviceInfo.ID)
					{
						current.IsAvailable = true;
					}
				}
			}
		}
	}
}
