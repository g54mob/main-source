public struct CargoLeakProperties
{
	public float maxLeakFlow;

	public float minLeakFlow;

	public float volatility;

	public float dissipationRate;

	public float inverseDensity;

	public CargoLeakProperties(float maxLeakFlow, float minLeakFlow, float volatility = 0f, float dissipationRate = 0f, float density = 0f)
	{
		this.maxLeakFlow = maxLeakFlow;
		this.minLeakFlow = minLeakFlow;
		this.volatility = volatility;
		this.dissipationRate = dissipationRate;
		inverseDensity = ((density <= float.Epsilon) ? 0f : (1f / density));
	}
}
