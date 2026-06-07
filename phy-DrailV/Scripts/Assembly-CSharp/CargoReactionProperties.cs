public struct CargoReactionProperties
{
	public float reactivity;

	public float reactivityModifierToOthers;

	public float ignitionReactivityMin;

	public float ignitionReactivityMax;

	public float criticalVolumeIgnitionMin;

	public float criticalVolumeIgnitionMax;

	public float explosionDelay;

	public CargoReactionProperties(float reactivity, float reactivityModifierToOthers = 0f, float ignitionReactivityMin = float.PositiveInfinity, float ignitionReactivityMax = float.PositiveInfinity, float criticalVolumeIgnitionMin = float.PositiveInfinity, float criticalVolumeIgnitionMax = float.PositiveInfinity, float explosionDelay = 0f)
	{
		this.reactivity = reactivity;
		this.reactivityModifierToOthers = reactivityModifierToOthers;
		this.ignitionReactivityMin = ignitionReactivityMin;
		this.ignitionReactivityMax = ignitionReactivityMax;
		this.criticalVolumeIgnitionMin = (float.IsPositiveInfinity(criticalVolumeIgnitionMin) ? float.PositiveInfinity : (criticalVolumeIgnitionMin * 0.5f));
		this.criticalVolumeIgnitionMax = (float.IsPositiveInfinity(criticalVolumeIgnitionMax) ? float.PositiveInfinity : (criticalVolumeIgnitionMax * 0.5f));
		this.explosionDelay = explosionDelay;
	}
}
