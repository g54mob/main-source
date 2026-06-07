namespace GAudio
{
	public interface IGATLFO
	{
		[FloatPropertyRange(0.25f, 20f)]
		float Frequency { get; set; }

		[FloatPropertyRange(0f, 1f)]
		float Strength { get; set; }

		void SetInitParams(float frequency, float strength);
	}
}
