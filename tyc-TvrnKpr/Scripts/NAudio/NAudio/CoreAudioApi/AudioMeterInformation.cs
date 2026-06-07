using NAudio.CoreAudioApi.Interfaces;

namespace NAudio.CoreAudioApi
{
	public class AudioMeterInformation
	{
		private readonly IAudioMeterInformation audioMeterInformation;

		private readonly EEndpointHardwareSupport hardwareSupport;

		private readonly AudioMeterInformationChannels channels;

		public AudioMeterInformationChannels PeakValues => null;

		public EEndpointHardwareSupport HardwareSupport => default(EEndpointHardwareSupport);

		public float MasterPeakValue => 0f;

		internal AudioMeterInformation(IAudioMeterInformation realInterface)
		{
		}
	}
}
