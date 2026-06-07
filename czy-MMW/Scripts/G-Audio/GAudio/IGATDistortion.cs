namespace GAudio
{
	public interface IGATDistortion
	{
		[FloatPropertyRange(0.001f, 1f)]
		float Threshold { get; set; }

		[FloatPropertyRange(0f, 1f)]
		float Mix { get; set; }
	}
}
