using System;
using System.Runtime.InteropServices;
using Crosstales.NAudio.CoreAudioApi.Interfaces;

namespace Crosstales.NAudio.CoreAudioApi
{
	public class MMDeviceEnumerator
	{
		private readonly IMMDeviceEnumerator realEnumerator;

		public MMDeviceEnumerator()
		{
			if (Environment.OSVersion.Version.Major < 6)
			{
				throw new NotSupportedException("This functionality is only supported on Windows Vista or newer.");
			}
			realEnumerator = new MMDeviceEnumeratorComObject() as IMMDeviceEnumerator;
		}

		public MMDeviceCollection EnumerateAudioEndPoints(DataFlow dataFlow, DeviceState dwStateMask)
		{
			Marshal.ThrowExceptionForHR(realEnumerator.EnumAudioEndpoints(dataFlow, dwStateMask, out var devices));
			return new MMDeviceCollection(devices);
		}

		public MMDevice GetDefaultAudioEndpoint(DataFlow dataFlow, Role role)
		{
			IMMDevice endpoint = null;
			Marshal.ThrowExceptionForHR(realEnumerator.GetDefaultAudioEndpoint(dataFlow, role, out endpoint));
			return new MMDevice(endpoint);
		}

		public MMDevice GetDevice(string id)
		{
			IMMDevice deviceName = null;
			Marshal.ThrowExceptionForHR(realEnumerator.GetDevice(id, out deviceName));
			return new MMDevice(deviceName);
		}

		public int RegisterEndpointNotificationCallback([In][MarshalAs(UnmanagedType.Interface)] IMMNotificationClient client)
		{
			return realEnumerator.RegisterEndpointNotificationCallback(client);
		}

		public int UnregisterEndpointNotificationCallback([In][MarshalAs(UnmanagedType.Interface)] IMMNotificationClient client)
		{
			return realEnumerator.UnregisterEndpointNotificationCallback(client);
		}
	}
}
