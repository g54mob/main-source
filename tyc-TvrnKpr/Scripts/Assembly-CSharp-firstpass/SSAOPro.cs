using UnityEngine;

[ImageEffectAllowedInSceneView]
[HelpURL("http://www.thomashourdel.com/ssaopro/doc/")]
[ExecuteInEditMode]
[AddComponentMenu("Image Effects/SSAO Pro")]
[RequireComponent(typeof(Camera))]
public class SSAOPro : MonoBehaviour
{
	public enum BlurMode
	{
		None = 0,
		Gaussian = 1,
		HighQualityBilateral = 2
	}

	public enum SampleCount
	{
		VeryLow = 0,
		Low = 1,
		Medium = 2,
		High = 3,
		Ultra = 4
	}

	protected enum Pass
	{
		Clear = 0,
		GaussianBlur = 5,
		HighQualityBilateralBlur = 6,
		Composite = 7
	}

	public Texture2D NoiseTexture;

	public bool UseHighPrecisionDepthMap;

	public SampleCount Samples;

	[Range(1f, 4f)]
	public int Downsampling;

	[Range(0.01f, 1.25f)]
	public float Radius;

	[Range(0f, 16f)]
	public float Intensity;

	[Range(0f, 10f)]
	public float Distance;

	[Range(0f, 1f)]
	public float Bias;

	[Range(0f, 1f)]
	public float LumContribution;

	[ColorUsage(false)]
	public Color OcclusionColor;

	public float CutoffDistance;

	public float CutoffFalloff;

	public BlurMode Blur;

	public bool BlurDownsampling;

	[Range(1f, 4f)]
	public int BlurPasses;

	[Range(1f, 20f)]
	public float BlurBilateralThreshold;

	public bool DebugAO;

	protected Shader m_ShaderSSAO;

	protected Material m_Material;

	protected Camera m_Camera;

	public Material Material => null;

	public Shader ShaderSSAO => null;

	private void OnEnable()
	{
	}

	private void OnPreRender()
	{
	}

	private void OnDisable()
	{
	}

	[ImageEffectOpaque]
	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
	}
}
