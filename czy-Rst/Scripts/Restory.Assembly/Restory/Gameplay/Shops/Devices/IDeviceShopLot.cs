using Restory.Data.Devices.Condition;
using Restory.Data.Devices.Quality;

namespace Restory.Gameplay.Shops.Devices
{
	public interface IDeviceShopLot : ILot
	{
		IDeviceCondition Device { get; }

		DeviceQualityBase Quality { get; }
	}
}
