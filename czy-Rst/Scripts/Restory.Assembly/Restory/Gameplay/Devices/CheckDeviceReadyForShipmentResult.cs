namespace Restory.Gameplay.Devices
{
	public enum CheckDeviceReadyForShipmentResult
	{
		Success = 0,
		Fail_DeviceQualityUnknown = 1,
		Fail_DeviceFromOrderIsNotOfIdealQuality = 2,
		Fail_DeviceIsUniqueAndNotForSale = 3,
		Fail_DeviceIsPartOfAWorkOrderWithAnotherDeviceAlreadyInShipment = 4,
		Fail_NotAllDeviceWorkTypesCompleted = 5
	}
}
