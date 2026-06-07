using System.Runtime.InteropServices;
using Crosstales.NAudio.CoreAudioApi.Interfaces;

namespace Crosstales.NAudio.CoreAudioApi
{
	public class AudioEndpointVolumeChannels
	{
		private readonly IAudioEndpointVolume audioEndPointVolume;

		private readonly AudioEndpointVolumeChannel[] channels;

		public int Count
		{
			get
			{
				Marshal.ThrowExceptionForHR(audioEndPointVolume.GetChannelCount(out var pnChannelCount));
				return pnChannelCount;
			}
		}

		public AudioEndpointVolumeChannel this[int index] => channels[index];

		internal AudioEndpointVolumeChannels(IAudioEndpointVolume parent)
		{
			audioEndPointVolume = parent;
			int count = Count;
			channels = new AudioEndpointVolumeChannel[count];
			for (int i = 0; i < count; i++)
			{
				channels[i] = new AudioEndpointVolumeChannel(audioEndPointVolume, i);
			}
		}
	}
}
