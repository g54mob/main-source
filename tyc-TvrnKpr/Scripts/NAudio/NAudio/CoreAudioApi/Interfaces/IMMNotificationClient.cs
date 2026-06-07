using System.Runtime.InteropServices;

namespace NAudio.CoreAudioApi.Interfaces
{
	[Guid("7991EEC9-7E89-4D85-8390-6C703CEC60C0")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IMMNotificationClient
	{
		void OnDeviceStateChanged(string deviceId, DeviceState newState);

		void OnDeviceAdded(string pwstrDeviceId);

		void OnDeviceRemoved(string deviceId);

		void OnDefaultDeviceChanged(DataFlow flow, Role role, string defaultDeviceId);

		void OnPropertyValueChanged(string pwstrDeviceId, PropertyKey key);
	}
}
