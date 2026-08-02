using UnityEngine;

[ExecuteInEditMode]
public class NatureManager : MonoBehaviour
{
	[Header("Clouds")]
	[Tooltip("The X speed the clouds move with")]
	[Range(0f, 1f)]
	public float xSpeed = 0.2f;

	[Tooltip("The Y speed the clouds move with")]
	[Range(0f, 1f)]
	public float ySpeed = 0.2f;

	[Tooltip("The color of the cloud shadow")]
	public Color cloudColor = Color.white;

	[Header("Fading")]
	[Tooltip("Enable/Disable dithering")]
	public bool enableDithering;

	[Tooltip("The maximum distance the foliage is rendered")]
	[Range(0f, 200f)]
	public float fadingDistance = 30f;

	[Tooltip("Foliage/Terrain blending minimum")]
	[Range(-10f, 10f)]
	public float ditherBottomLevel = 1f;

	[Tooltip("Foliage/Terrain blending maximum")]
	[Range(-10f, 10f)]
	public float ditherFade = 6f;

	[Tooltip("Dithering when using default grass")]
	[Range(0f, 10f)]
	public float terrainGrassDitherMin = 1f;

	[Range(0f, 20f)]
	public float terrainGrassDitherMax = 6f;

	[Header("Wind")]
	[Tooltip("Small wind intensity")]
	[Range(0f, 100f)]
	public float smallWindIntensity = 20f;

	[Tooltip("Small wind multiplier")]
	[Range(-3f, 3f)]
	public float smallWindMultiplier = 1f;

	[Tooltip("Large wind intensity")]
	[Range(0f, 100f)]
	public float largeWindIntensity = 20f;

	[Tooltip("Large wind multiplier")]
	[Range(-3f, 3f)]
	public float largeWindMultiplier = 1f;

	[Header("Other")]
	[Tooltip("Small wind intensity")]
	[Range(0f, 1f)]
	public float smoothness = 0.1f;

	private void Start()
	{
	}

	private void Update()
	{
		if (enableDithering)
		{
			Shader.EnableKeyword("_DITHERINGON_ON");
		}
		else if (!enableDithering)
		{
			Shader.DisableKeyword("_DITHERINGON_ON");
		}
		Vector2 vector = new Vector2(xSpeed, ySpeed);
		Shader.SetGlobalVector("CloudSpeed", vector);
		Shader.SetGlobalColor("CloudColor", cloudColor);
		Shader.SetGlobalFloat("FoliageRenderDistance", fadingDistance);
		Shader.SetGlobalFloat("DitherBottomLevel", ditherBottomLevel);
		Shader.SetGlobalFloat("DitherFade", ditherFade);
		Shader.SetGlobalFloat("FoliageDitherMin", terrainGrassDitherMin);
		Shader.SetGlobalFloat("FoliageDitherMax", terrainGrassDitherMax);
		Shader.SetGlobalFloat("WindNoiseSmall", smallWindIntensity);
		Shader.SetGlobalFloat("WindNoiseSmallMultiply", smallWindMultiplier);
		Shader.SetGlobalFloat("WindNoiseLarge", largeWindIntensity);
		Shader.SetGlobalFloat("WindNoiseLargeMultiply", largeWindMultiplier);
		Shader.SetGlobalFloat("FoliageSmoothness", smoothness);
	}
}
