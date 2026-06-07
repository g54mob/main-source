namespace GAudio
{
	public interface IGATProcessedSample : IRetainable, IGATDataOwner
	{
		double Pitch { get; }

		IGATBufferedSampleOptions Play(AGATPanInfo panInfo, float gain = 1f, GATPlayer.OnShouldMixSample mixCallback = null);

		IGATBufferedSampleOptions Play(GATPlayer player, AGATPanInfo panInfo, float gain = 1f, GATPlayer.OnShouldMixSample mixCallback = null);

		IGATBufferedSampleOptions PlayScheduled(double dspTime, AGATPanInfo panInfo, float gain = 1f, GATPlayer.OnShouldMixSample mixCallback = null);

		IGATBufferedSampleOptions PlayScheduled(GATPlayer player, double dspTime, AGATPanInfo panInfo, float gain = 1f, GATPlayer.OnShouldMixSample mixCallback = null);

		IGATBufferedSampleOptions Play(int trackNb, float gain = 1f, GATPlayer.OnShouldMixSample mixCallback = null);

		IGATBufferedSampleOptions Play(GATPlayer player, int trackNb, float gain = 1f, GATPlayer.OnShouldMixSample mixCallback = null);

		IGATBufferedSampleOptions PlayScheduled(double dspTime, int trackNb, float gain = 1f, GATPlayer.OnShouldMixSample mixCallback = null);

		IGATBufferedSampleOptions PlayScheduled(GATPlayer player, double dspTime, int trackNb, float gain = 1f, GATPlayer.OnShouldMixSample mixCallback = null);

		void UpdateAudioData();
	}
}
