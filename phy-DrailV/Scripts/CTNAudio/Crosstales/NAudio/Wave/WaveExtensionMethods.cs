using Crosstales.NAudio.Wave.SampleProviders;

namespace Crosstales.NAudio.Wave
{
	public static class WaveExtensionMethods
	{
		public static ISampleProvider ToSampleProvider(this IWaveProvider waveProvider)
		{
			return SampleProviderConverters.ConvertWaveProviderIntoSampleProvider(waveProvider);
		}

		public static void Init(this IWavePlayer wavePlayer, ISampleProvider sampleProvider, bool convertTo16Bit)
		{
			IWaveProvider waveProvider2;
			if (!convertTo16Bit)
			{
				IWaveProvider waveProvider = new SampleToWaveProvider(sampleProvider);
				waveProvider2 = waveProvider;
			}
			else
			{
				IWaveProvider waveProvider = new SampleToWaveProvider16(sampleProvider);
				waveProvider2 = waveProvider;
			}
			IWaveProvider waveProvider3 = waveProvider2;
			wavePlayer.Init(waveProvider3);
		}
	}
}
