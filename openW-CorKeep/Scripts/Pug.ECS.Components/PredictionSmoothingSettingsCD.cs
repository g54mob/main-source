using Unity.Entities;

public struct PredictionSmoothingSettingsCD : IComponentData, IQueryTypeParameter
{
	public float minCorrectionThreshold;

	public float teleportDistanceThreshold;

	public float correctionMinRateHz;

	public float correctionMaxRateHz;

	public float correctionRateDistanceBlendStart;

	public float correctionRateDistanceBlendEnd;

	public void ResolveDefault()
	{
		minCorrectionThreshold = 0.25f;
		teleportDistanceThreshold = 10f;
		correctionMinRateHz = 3.3f;
		correctionMaxRateHz = 10f;
		correctionRateDistanceBlendStart = 0.25f;
		correctionRateDistanceBlendEnd = 1f;
	}
}
