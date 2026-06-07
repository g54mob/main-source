using NAudio.CoreAudioApi.Interfaces;

namespace NAudio.CoreAudioApi
{
	public class AudioEndpointVolumeVolumeRange
	{
		private readonly float volumeMinDecibels;

		private readonly float volumeMaxDecibels;

		private readonly float volumeIncrementDecibels;

		public float MinDecibels => 0f;

		public float MaxDecibels => 0f;

		public float IncrementDecibels => 0f;

		internal AudioEndpointVolumeVolumeRange(IAudioEndpointVolume parent)
		{
		}
	}
}
