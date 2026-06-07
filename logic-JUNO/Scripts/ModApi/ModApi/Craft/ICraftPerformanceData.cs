namespace ModApi.Craft
{
	public interface ICraftPerformanceData
	{
		double CurrentIsp { get; }

		double DeltaVStage { get; }

		float FuelAllStagesPercentage { get; }

		double RemainingBurnTime { get; }

		float ThrustToWeightRatio { get; }
	}
}
