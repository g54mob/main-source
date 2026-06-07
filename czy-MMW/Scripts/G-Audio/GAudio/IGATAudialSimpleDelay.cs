namespace GAudio
{
	public interface IGATAudialSimpleDelay
	{
		[FloatPropertyRange(10f, 3000f)]
		float DelayMS { get; set; }

		[FloatPropertyRange(0f, 1f)]
		float DryWet { get; set; }

		[FloatPropertyRange(0.1f, 1f)]
		float Decay { get; set; }
	}
}
