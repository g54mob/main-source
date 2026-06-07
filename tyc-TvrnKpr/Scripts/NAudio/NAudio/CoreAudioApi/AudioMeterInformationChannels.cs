using NAudio.CoreAudioApi.Interfaces;

namespace NAudio.CoreAudioApi
{
	public class AudioMeterInformationChannels
	{
		private readonly IAudioMeterInformation audioMeterInformation;

		public int Count => 0;

		public float this[int index] => 0f;

		internal AudioMeterInformationChannels(IAudioMeterInformation parent)
		{
		}
	}
}
