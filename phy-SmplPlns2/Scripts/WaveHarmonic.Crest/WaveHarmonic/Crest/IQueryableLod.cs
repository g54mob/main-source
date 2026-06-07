namespace WaveHarmonic.Crest
{
	public interface IQueryableLod<out T> where T : IQueryProvider
	{
		string Name { get; }

		bool Enabled { get; }

		WaterRenderer Water { get; }

		int MaximumQueryCount { get; }

		float Texel { get; }

		LodQuerySource QuerySource { get; }
	}
}
