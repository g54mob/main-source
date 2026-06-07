using NAudio.CoreAudioApi.Interfaces;

namespace NAudio.CoreAudioApi
{
	public class AudioEndpointVolumeChannels
	{
		private readonly IAudioEndpointVolume audioEndPointVolume;

		private readonly AudioEndpointVolumeChannel[] channels;

		public int Count => 0;

		public AudioEndpointVolumeChannel this[int index] => null;

		internal AudioEndpointVolumeChannels(IAudioEndpointVolume parent)
		{
		}
	}
}
