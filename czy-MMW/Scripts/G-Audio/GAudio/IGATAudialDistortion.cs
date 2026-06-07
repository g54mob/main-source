namespace GAudio
{
	public interface IGATAudialDistortion
	{
		[FloatPropertyRange(0f, 3f)]
		float InGain { get; set; }

		[FloatPropertyRange(1E-05f, 1f)]
		float Thresh { get; set; }

		[FloatPropertyRange(0f, 1f)]
		float DryWet { get; set; }

		[FloatPropertyRange(0f, 5f)]
		float OutGain { get; set; }
	}
}
