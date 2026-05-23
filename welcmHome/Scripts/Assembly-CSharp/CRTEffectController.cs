using UnityEngine;
using UnityEngine.Rendering;

[ExecuteInEditMode]
public class CRTEffectController : MonoBehaviour
{
	[SerializeField]
	protected VolumeProfile volumeProfile;

	[SerializeField]
	protected bool isEnabled = true;

	protected Crt crt;

	[SerializeField]
	protected float scanlinesWeight = 1f;

	[SerializeField]
	protected float noiseWeight = 1f;

	[SerializeField]
	protected float screenBendX = 1000f;

	[SerializeField]
	protected float screenBendY = 1000f;

	[SerializeField]
	protected float vignetteAmount;

	[SerializeField]
	protected float vignetteSize;

	[SerializeField]
	protected float vignetteRounding;

	[SerializeField]
	protected float vignetteSmoothing;

	[SerializeField]
	protected float scanLinesDensity = 200f;

	[SerializeField]
	protected float scanLinesSpeed = -10f;

	[SerializeField]
	protected float noiseAmount = 250f;

	[SerializeField]
	protected Vector2 chromaticRed;

	[SerializeField]
	protected Vector2 chromaticGreen;

	[SerializeField]
	protected Vector2 chromaticBlue;

	[SerializeField]
	protected float grilleOpacity = 0.4f;

	[SerializeField]
	protected float grilleCounterOpacity = 0.2f;

	[SerializeField]
	protected float grilleResolution = 360f;

	[SerializeField]
	protected float grilleCounterResolution = 540f;

	[SerializeField]
	protected float grilleBrightness = 15f;

	[SerializeField]
	protected float grilleUvRotation = 90f;

	[SerializeField]
	protected float grilleUvMidPoint = 0.5f;

	[SerializeField]
	protected Vector3 grilleShift = new Vector3(1f, 1f, 1f);

	protected void Update()
	{
		SetParams();
	}

	protected void SetParams()
	{
		if (isEnabled && !(volumeProfile == null))
		{
			if (crt == null)
			{
				volumeProfile.TryGet<Crt>(out crt);
			}
			if (!(crt == null))
			{
				crt.scanlinesWeight.value = scanlinesWeight;
				crt.noiseWeight.value = noiseWeight;
				crt.screenBendX.value = screenBendX;
				crt.screenBendY.value = screenBendY;
				crt.vignetteAmount.value = vignetteAmount;
				crt.vignetteSize.value = vignetteSize;
				crt.vignetteRounding.value = vignetteRounding;
				crt.vignetteSmoothing.value = vignetteSmoothing;
				crt.scanlinesDensity.value = scanLinesDensity;
				crt.scanlinesSpeed.value = scanLinesDensity;
				crt.noiseAmount.value = noiseAmount;
				crt.chromaticRed.value = chromaticRed;
				crt.chromaticGreen.value = chromaticGreen;
				crt.chromaticBlue.value = chromaticBlue;
				crt.grilleOpacity.value = grilleOpacity;
				crt.grilleCounterOpacity.value = grilleCounterOpacity;
				crt.grilleResolution.value = grilleResolution;
				crt.grilleCounterResolution.value = grilleCounterResolution;
				crt.grilleBrightness.value = grilleBrightness;
				crt.grilleUvRotation.value = grilleUvRotation;
				crt.grilleUvMidPoint.value = grilleUvMidPoint;
				crt.grilleShift.value = grilleShift;
			}
		}
	}
}
