using System;

namespace Rewired.Interfaces
{
	internal interface IDeviceManager
	{
		event Action<EventArgs> DeviceConnectedEvent;

		event Action<EventArgs> DeviceDisconnectedEvent;

		void OnDestroy();
	}
}
