namespace NAudio.Wave.SampleProviders
{
	public class FadeInOutSampleProvider : ISampleProvider
	{
		private enum FadeState
		{
			Silence = 0,
			FadingIn = 1,
			FullVolume = 2,
			FadingOut = 3
		}

		private readonly object lockObject;

		private readonly ISampleProvider source;

		private int fadeSamplePosition;

		private int fadeSampleCount;

		private FadeState fadeState;

		public WaveFormat WaveFormat => null;

		public FadeInOutSampleProvider(ISampleProvider source, bool initiallySilent = false)
		{
		}

		public void BeginFadeIn(double fadeDurationInMilliseconds)
		{
		}

		public void BeginFadeOut(double fadeDurationInMilliseconds)
		{
		}

		public int Read(float[] buffer, int offset, int count)
		{
			return 0;
		}

		private static void ClearBuffer(float[] buffer, int offset, int count)
		{
		}

		private void FadeOut(float[] buffer, int offset, int sourceSamplesRead)
		{
		}

		private void FadeIn(float[] buffer, int offset, int sourceSamplesRead)
		{
		}
	}
}
