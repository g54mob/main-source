using UnityEngine;
using UnityEngine.Rendering;

public class Crt : VolumeComponent, IPostProcessComponent
{
	public FloatParameter scanlinesWeight = new FloatParameter(1f);

	public FloatParameter noiseWeight = new FloatParameter(1f);

	public FloatParameter screenBendX = new FloatParameter(1000f);

	public FloatParameter screenBendY = new FloatParameter(1000f);

	public FloatParameter vignetteAmount = new FloatParameter(0f);

	public FloatParameter vignetteSize = new FloatParameter(2f);

	public FloatParameter vignetteRounding = new FloatParameter(2f);

	public FloatParameter vignetteSmoothing = new FloatParameter(1f);

	public FloatParameter scanlinesDensity = new FloatParameter(200f);

	public FloatParameter scanlinesSpeed = new FloatParameter(-10f);

	public FloatParameter noiseAmount = new FloatParameter(250f);

	public Vector2Parameter chromaticRed = new Vector2Parameter(default(Vector2));

	public Vector2Parameter chromaticGreen = new Vector2Parameter(default(Vector2));

	public Vector2Parameter chromaticBlue = new Vector2Parameter(default(Vector2));

	public FloatParameter grilleOpacity = new FloatParameter(0.4f);

	public FloatParameter grilleCounterOpacity = new FloatParameter(0.2f);

	public FloatParameter grilleResolution = new FloatParameter(360f);

	public FloatParameter grilleCounterResolution = new FloatParameter(540f);

	public FloatParameter grilleUvRotation = new FloatParameter(90f);

	public FloatParameter grilleBrightness = new FloatParameter(15f);

	public FloatParameter grilleUvMidPoint = new FloatParameter(0.5f);

	public Vector3Parameter grilleShift = new Vector3Parameter(new Vector3(1f, 1f, 1f));

	public bool IsActive()
	{
		return true;
	}

	public bool IsTileCompatible()
	{
		return false;
	}
}
