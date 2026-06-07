using UnityEngine;

public class WeatherPreset : ScriptableObject
{
	public Gradient SummerGradient;

	public Gradient WinterGradient;

	public Gradient SkyGradient;

	public Gradient AmbientGradient;

	public Gradient GrassVariance;

	[ContextMenuItem("Export temperature sheet", "ExportTemps")]
	public AnimationCurve TemperatureCurve;

	[ContextMenuItem("Export temperature sheet", "ExportTemps")]
	public AnimationCurve TempMin;

	[ContextMenuItem("Export temperature sheet", "ExportTemps")]
	public AnimationCurve TempRange;

	[ContextMenuItem("Export temperature sheet", "ExportTemps")]
	public AnimationCurve GrassPerlinCutoff;

	public Color GroundColor;

	public Color GrassBase;

	public Color GrassRoots;

	public Color GrassTips;

	public float GrassMin;

	public float GrassMax;

	public float AverageWind = 0.5f;

	[ContextMenuItem("Calculate temperature range", "CalculateRange")]
	public float MinimumTemperature;

	[ContextMenuItem("Calculate temperature range", "CalculateRange")]
	public float MaximumTemperature;

	public void ExportTemps()
	{
	}

	public void CalculateRange()
	{
	}
}
