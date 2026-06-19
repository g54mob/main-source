using UnityEngine;
using UnityEngine.Rendering;

public class RadicalCameraSettings : MonoBehaviour
{
	public enum FogMode
	{
		Exponential = 0,
		ExponentialSquared = 1,
		Linear = 2
	}

	[Header("Fog camera settings:")]
	public Color fogColor;

	public float fogDensity;

	public FogMode fogMode;

	private bool previousFog;

	private Color previousFogColor;

	private float previousFogDensity;

	private FogMode previousFogMode;

	private void OnPreRender()
	{
		RenderSettings.ambientMode = AmbientMode.Flat;
		RenderSettings.reflectionBounces = 0;
		RenderSettings.reflectionIntensity = 0f;
		previousFog = RenderSettings.fog;
		previousFogColor = RenderSettings.fogColor;
		previousFogDensity = RenderSettings.fogDensity;
		switch (RenderSettings.fogMode)
		{
		case UnityEngine.FogMode.Exponential:
			previousFogMode = FogMode.Exponential;
			break;
		case UnityEngine.FogMode.ExponentialSquared:
			previousFogMode = FogMode.ExponentialSquared;
			break;
		case UnityEngine.FogMode.Linear:
			previousFogMode = FogMode.Linear;
			break;
		}
		RenderSettings.fog = true;
		RenderSettings.fogColor = fogColor;
		RenderSettings.fogDensity = fogDensity;
		switch (fogMode)
		{
		case FogMode.Exponential:
			RenderSettings.fogMode = UnityEngine.FogMode.Exponential;
			break;
		case FogMode.ExponentialSquared:
			RenderSettings.fogMode = UnityEngine.FogMode.ExponentialSquared;
			break;
		case FogMode.Linear:
			RenderSettings.fogMode = UnityEngine.FogMode.Linear;
			break;
		}
	}

	private void OnPostRender()
	{
		RenderSettings.fog = previousFog;
		RenderSettings.fogColor = previousFogColor;
		RenderSettings.fogDensity = previousFogDensity;
		switch (previousFogMode)
		{
		case FogMode.Exponential:
			RenderSettings.fogMode = UnityEngine.FogMode.Exponential;
			break;
		case FogMode.ExponentialSquared:
			RenderSettings.fogMode = UnityEngine.FogMode.ExponentialSquared;
			break;
		case FogMode.Linear:
			RenderSettings.fogMode = UnityEngine.FogMode.Linear;
			break;
		}
	}
}
