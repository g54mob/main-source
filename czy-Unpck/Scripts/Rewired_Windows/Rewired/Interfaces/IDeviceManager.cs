using System;

namespace Rewired.Interfaces
{
	internal interface IDeviceManager
	{
		event Action<EventArgs> DeviceConnectedEvent;

		event Action<EventArgs> DeviceDisconnectedEvent;

		event Action<EventArgs> DeviceDisconnectPendingEvent;

		void OnDestroy();
	}
}
