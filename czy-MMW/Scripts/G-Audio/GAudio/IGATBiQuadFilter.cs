namespace GAudio
{
	public interface IGATBiQuadFilter
	{
		[FloatPropertyRange(20f, 5000f)]
		float Freq { get; set; }

		[FloatPropertyRange(0.5f, 16f)]
		double Q { get; set; }

		[FloatPropertyRange(0f, 1f)]
		float Mix { get; set; }

		void SetParams(float frequency, double q, float peakGain);
	}
}
