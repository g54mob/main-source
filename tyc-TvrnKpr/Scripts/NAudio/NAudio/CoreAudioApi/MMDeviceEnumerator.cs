using System;
using System.Runtime.InteropServices;
using NAudio.CoreAudioApi.Interfaces;

namespace NAudio.CoreAudioApi
{
	public class MMDeviceEnumerator : IDisposable
	{
		private IMMDeviceEnumerator realEnumerator;

		public MMDeviceCollection EnumerateAudioEndPoints(DataFlow dataFlow, DeviceState dwStateMask)
		{
			return null;
		}

		public MMDevice GetDefaultAudioEndpoint(DataFlow dataFlow, Role role)
		{
			return null;
		}

		public bool HasDefaultAudioEndpoint(DataFlow dataFlow, Role role)
		{
			return false;
		}

		public MMDevice GetDevice(string id)
		{
			return null;
		}

		public int RegisterEndpointNotificationCallback([In] IMMNotificationClient client)
		{
			return 0;
		}

		public int UnregisterEndpointNotificationCallback([In] IMMNotificationClient client)
		{
			return 0;
		}

		public void Dispose()
		{
		}

		protected virtual void Dispose(bool disposing)
		{
		}
	}
}
