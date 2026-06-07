using System;
using NAudio.CoreAudioApi.Interfaces;

namespace NAudio.CoreAudioApi
{
	internal class AudioEndpointVolumeCallback : IAudioEndpointVolumeCallback
	{
		private readonly AudioEndpointVolume parent;

		internal AudioEndpointVolumeCallback(AudioEndpointVolume parent)
		{
		}

		public void OnNotify(IntPtr notifyData)
		{
		}
	}
}
