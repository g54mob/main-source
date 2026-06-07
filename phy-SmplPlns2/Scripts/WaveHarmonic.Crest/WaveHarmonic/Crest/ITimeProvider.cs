namespace WaveHarmonic.Crest
{
	public interface ITimeProvider
	{
		float Time { get; }

		float Delta { get; }
	}
}
