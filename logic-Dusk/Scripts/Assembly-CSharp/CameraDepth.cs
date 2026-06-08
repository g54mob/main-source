using UnityEngine;

[ExecuteInEditMode]
public class CameraDepth : ImageEffectBase
{
	public Material mat;

	public float DistToLowerElevation = 10f;

	public float DistToUpperElevation = 20f;

	public Color LowerColor = Color.blue;

	public Color UpperColor = Color.green;

	public bool InvertYAxis;

	public bool DepthOnly;

	public bool InvertDepth;

	public float ColorGradiantFactor = 50f;

	public bool ApplyGreenTint = true;

	public float TintDarknessFactor = 1f;

	protected override void Start()
	{
		GetComponent<Camera>().depthTextureMode = DepthTextureMode.Depth;
		base.Start();
	}

	private void Update()
	{
	}

	private void OnRenderImage(RenderTexture src, RenderTexture dest)
	{
		mat.SetFloat("_GradFact", ColorGradiantFactor);
		mat.SetFloat("_LowerElevation", DistToLowerElevation);
		mat.SetFloat("_UpperElevation", DistToUpperElevation);
		mat.SetColor("_LowerColor", LowerColor);
		mat.SetColor("_UpperColor", UpperColor);
		mat.SetFloat("_InvertY", (!InvertYAxis) ? 0f : 1f);
		mat.SetFloat("_TintGreen", (!ApplyGreenTint) ? 0f : 1f);
		mat.SetFloat("_GreenFactor", Mathf.Clamp(TintDarknessFactor, 0f, 1f));
		mat.SetFloat("_InvertDepth", (!InvertDepth) ? 0f : 1f);
		mat.SetFloat("_DepthOnly", (!DepthOnly) ? 0f : 1f);
		Graphics.Blit(src, dest, mat);
	}
}
