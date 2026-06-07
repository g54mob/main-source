using NAudio.CoreAudioApi.Interfaces;

namespace NAudio.CoreAudioApi
{
	public class AudioEndpointVolumeStepInformation
	{
		private readonly uint step;

		private readonly uint stepCount;

		public uint Step => 0u;

		public uint StepCount => 0u;

		internal AudioEndpointVolumeStepInformation(IAudioEndpointVolume parent)
		{
		}
	}
}
