using System;
using NAudio.CoreAudioApi.Interfaces;

namespace NAudio.CoreAudioApi
{
	public class MMDevice : IDisposable
	{
		private readonly IMMDevice deviceInterface;

		private PropertyStore propertyStore;

		private AudioMeterInformation audioMeterInformation;

		private AudioEndpointVolume audioEndpointVolume;

		private AudioSessionManager audioSessionManager;

		private static Guid IID_IAudioMeterInformation;

		private static Guid IID_IAudioEndpointVolume;

		private static Guid IID_IAudioClient;

		private static Guid IDD_IAudioSessionManager;

		public AudioClient AudioClient => null;

		public AudioMeterInformation AudioMeterInformation => null;

		public AudioEndpointVolume AudioEndpointVolume => null;

		public AudioSessionManager AudioSessionManager => null;

		public PropertyStore Properties => null;

		public string FriendlyName => null;

		public string DeviceFriendlyName => null;

		public string IconPath => null;

		public string ID => null;

		public DataFlow DataFlow => default(DataFlow);

		public DeviceState State => default(DeviceState);

		public void GetPropertyInformation(StorageAccessMode stgmAccess = StorageAccessMode.Read)
		{
		}

		private AudioClient GetAudioClient()
		{
			return null;
		}

		private void GetAudioMeterInformation()
		{
		}

		private void GetAudioEndpointVolume()
		{
		}

		private void GetAudioSessionManager()
		{
		}

		internal MMDevice(IMMDevice realDevice)
		{
		}

		public override string ToString()
		{
			return null;
		}

		public void Dispose()
		{
		}

		~MMDevice()
		{
		}
	}
}
