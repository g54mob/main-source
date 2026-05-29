using System;
using Rewired;

internal interface iflCBykpCtyCmFAlnduVbpFYFGW : IDisposable
{
	string SystemName { get; }

	string FriendlyName { get; }

	int VendorId { get; }

	int ProductId { get; }

	PidVid PidVid { get; }

	Guid InstanceGuid { get; }

	wQJNyUaUvslgkGHqqbQGKnHjBYM DeviceType { get; }

	bool IsBluetoothDevice { get; }

	Controller.Extension ControllerExtension { get; }

	bool SupportsVibration { get; }

	int VibrationMotorCount { get; }

	void Update(UpdateLoopType P_0);

	void UpdateFinished();

	void Acquire();

	void Unacquire();

	bool IsAttached();

	bool Matches(iflCBykpCtyCmFAlnduVbpFYFGW P_0);

	void SetVibration(int P_0, float P_1, bool P_2);

	void StopVibration();
}
