using System;

namespace NAudio.Wave
{
	public static class WaveExtensionMethods
	{
		public static ISampleProvider ToSampleProvider(this IWaveProvider waveProvider)
		{
			return null;
		}

		public static void Init(this IWavePlayer wavePlayer, ISampleProvider sampleProvider, bool convertTo16Bit = false)
		{
		}

		public static WaveFormat AsStandardWaveFormat(this WaveFormat waveFormat)
		{
			return null;
		}

		public static IWaveProvider ToWaveProvider(this ISampleProvider sampleProvider)
		{
			return null;
		}

		public static IWaveProvider ToWaveProvider16(this ISampleProvider sampleProvider)
		{
			return null;
		}

		public static ISampleProvider FollowedBy(this ISampleProvider sampleProvider, ISampleProvider next)
		{
			return null;
		}

		public static ISampleProvider FollowedBy(this ISampleProvider sampleProvider, TimeSpan silenceDuration, ISampleProvider next)
		{
			return null;
		}

		public static ISampleProvider Skip(this ISampleProvider sampleProvider, TimeSpan skipDuration)
		{
			return null;
		}

		public static ISampleProvider Take(this ISampleProvider sampleProvider, TimeSpan takeDuration)
		{
			return null;
		}

		public static ISampleProvider ToMono(this ISampleProvider sourceProvider, float leftVol = 0.5f, float rightVol = 0.5f)
		{
			return null;
		}

		public static ISampleProvider ToStereo(this ISampleProvider sourceProvider, float leftVol = 1f, float rightVol = 1f)
		{
			return null;
		}
	}
}
