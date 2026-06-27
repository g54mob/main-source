using System;
using Restory.Data.Licenses;
using Restory.Gameplay.Licenses;
using Zenject;

namespace Restory.Gameplay.Devices
{
	public class DeviceLicensingService : IInitializable, IDisposable
	{
		private readonly DevicePacker devicePacker;

		private readonly DeviceRegistry deviceRegistry;

		private readonly LicensesService licensesService;

		[Inject]
		public DeviceLicensingService(DevicePacker devicePacker, DeviceRegistry deviceRegistry, LicensesService licensesService)
		{
			this.devicePacker = devicePacker;
			this.deviceRegistry = deviceRegistry;
			this.licensesService = licensesService;
		}

		public void Initialize()
		{
			licensesService.OnLicenseAdded += ResolveLicenseAdded;
		}

		public void Dispose()
		{
			licensesService.OnLicenseAdded -= ResolveLicenseAdded;
		}

		private void ResolveLicenseAdded(LicensesService _, LicenseInfo licenseInfo)
		{
			foreach (DeviceContainer item in deviceRegistry.All)
			{
				if (!(item.Device.Info.License != licenseInfo) && item.Package is UnlicensedDevicePackage)
				{
					devicePacker.RepackLicensedDeviceContainer(item);
				}
			}
		}
	}
}
