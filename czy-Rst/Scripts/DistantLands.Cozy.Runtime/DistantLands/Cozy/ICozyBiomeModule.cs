namespace DistantLands.Cozy
{
	public interface ICozyBiomeModule
	{
		bool isBiomeModule { get; set; }

		void AddBiome();

		void RemoveBiome();

		void UpdateBiomeModule();

		bool CheckBiome();

		void ComputeBiomeWeights();

		float ReportWeight();
	}
}
