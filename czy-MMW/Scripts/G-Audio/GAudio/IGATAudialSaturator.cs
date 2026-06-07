namespace GAudio
{
	public interface IGATAudialSaturator
	{
		[FloatPropertyRange(0f, 3f)]
		float InGain { get; set; }

		[FloatPropertyRange(0f, 1f)]
		float Thresh { get; set; }

		[FloatPropertyRange(0f, 1f)]
		float Amount { get; set; }
	}
}
