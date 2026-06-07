namespace WaveHarmonic.Crest
{
	internal interface IQueryable
	{
		int ResultGuidCount { get; }

		int RequestCount { get; }

		int QueryCount { get; }

		void UpdateQueries(WaterRenderer water);

		void SendReadBack(WaterRenderer water);

		void CleanUp();

		void Initialize(WaterRenderer water);
	}
}
