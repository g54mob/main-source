using System;
using Rewired;
using Rewired.HID.Drivers;
using Rewired.Windows.RawInput;

internal interface MdvOMMNxWfcPHdPxtxTUTmquguI : IDisposable
{
	bUiVDUOAHpFECnWVzgHAGOUkHLxZ HidDevice { get; }

	string ProductName { get; }

	string Manufacturer { get; }

	int VendorId { get; }

	int ProductId { get; }

	Guid ProductGuid { get; }

	Guid InstanceGuid { get; }

	DeviceType DeviceType { get; }

	bool IsBluetoothDevice { get; }

	string BluetoothDeviceName { get; }

	string HWDefinitionMatchTag { get; }

	HIDDeviceDriver Driver { get; }

	Controller.Extension ControllerExtension { get; }

	bool IsValid { get; }

	void Update(UpdateLoopType P_0);

	void UpdateFinished();

	void Acquire();

	void Unacquire();

	bool IsAttached();
}
