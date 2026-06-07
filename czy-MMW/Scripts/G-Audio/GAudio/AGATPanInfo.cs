namespace GAudio
{
	public abstract class AGATPanInfo
	{
		public abstract bool IsAudible { get; }

		public abstract void PanMixSample(IGATBufferedSample sample, int length, float[] audioBuffer, float gain = 1f);

		public abstract void PanMixProcessingBuffer(IGATBufferedSample sample, int length, float[] audioBuffer, float gain = 1f);

		public abstract void SetGains(float[] gains);

		public void SetStereoPan(float pan)
		{
			SetGains(new float[2]
			{
				1f - pan,
				pan
			});
		}

		public void SetStereoPan(float pan, float gain)
		{
			SetGains(new float[2]
			{
				(1f - pan) * gain,
				pan * gain
			});
		}
	}
}
