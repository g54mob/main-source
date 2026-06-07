namespace GAudio
{
	public interface IGATDelay
	{
		[FloatPropertyRange(0.001f, 1f)]
		float Delay { get; set; }

		[FloatPropertyRange(0f, 1f)]
		float Feedback { get; set; }
	}
}
