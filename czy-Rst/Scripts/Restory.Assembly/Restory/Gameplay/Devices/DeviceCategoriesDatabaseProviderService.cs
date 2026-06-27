using Restory.Data.Devices;

namespace Restory.Gameplay.Devices
{
	public class DeviceCategoriesDatabaseProviderService
	{
		private readonly DeviceCategoriesDatabase database;

		public IDeviceCategory AllDevicesCategory => database.AllDevicesCategory;

		public DeviceCategoriesDatabase Database => database;

		public DeviceCategoriesDatabaseProviderService(DeviceCategoriesDatabase database)
		{
			this.database = database;
		}
	}
}
