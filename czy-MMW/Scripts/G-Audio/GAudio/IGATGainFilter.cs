namespace GAudio
{
	public interface IGATGainFilter
	{
		[FloatPropertyRange(0f, 5f)]
		float Gain { get; set; }

		[ToggleGroupProperty(1)]
		bool Clip { get; set; }

		[FloatPropertyRange(0f, 1f)]
		float Threshold { get; set; }
	}
}
