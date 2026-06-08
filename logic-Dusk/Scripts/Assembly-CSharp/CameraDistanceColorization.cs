using UnityEngine;

[ExecuteInEditMode]
public class CameraDistanceColorization : ImageEffectBase
{
	public Material mat;

	public float LowerColorBounds = 0.6f;

	public float UpperColorBounds = 0.65f;

	public Color LowerColor = Color.blue;

	public Color UpperColor = Color.green;

	public float ColorBandSize = 0.1f;

	public float ClampLight = 1f;

	public bool InvertYAxis;

	protected override void Start()
	{
		GetComponent<Camera>().depthTextureMode = DepthTextureMode.Depth;
		base.Start();
	}

	private void OnDestroy()
	{
		mat = null;
	}

	private void OnRenderImage(RenderTexture src, RenderTexture dest)
	{
		mat.SetFloat("_LowerElevation", LowerColorBounds);
		mat.SetFloat("_UpperElevation", UpperColorBounds);
		mat.SetColor("_LowerColor", LowerColor);
		mat.SetColor("_UpperColor", UpperColor);
		mat.SetFloat("_ColorBandSize", Mathf.Clamp(ColorBandSize, 0f, 1f));
		mat.SetFloat("_ClampLight", Mathf.Clamp(ClampLight, 0f, 1f));
		mat.SetFloat("_InvertY", (!InvertYAxis) ? 0f : 1f);
		Graphics.Blit(src, dest, mat);
	}
}
