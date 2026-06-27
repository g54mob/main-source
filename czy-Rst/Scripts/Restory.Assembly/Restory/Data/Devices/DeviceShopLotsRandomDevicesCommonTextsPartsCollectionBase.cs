using Restory.Data.RandomBallsPoolSystems;

namespace Restory.Data.Devices
{
	public abstract class DeviceShopLotsRandomDevicesCommonTextsPartsCollectionBase : RandomBallsPoolSystemSettings<string>
	{
		protected override bool IsRandomObjectsListReadOnly => true;
	}
}
