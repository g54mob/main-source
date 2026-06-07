using AmplifyOcclusion;
using UnityEngine;
using UnityEngine.Rendering;

[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Amplify Occlusion")]
[ImageEffectAllowedInSceneView]
[RequireComponent(typeof(Camera))]
public class AmplifyOcclusionEffect : MonoBehaviour
{
	public enum ApplicationMethod
	{
		PostEffect = 0,
		Deferred = 1,
		Debug = 2
	}

	public enum PerPixelNormalSource
	{
		None = 0,
		Camera = 1,
		GBuffer = 2,
		GBufferOctaEncoded = 3
	}

	private struct CmdBuffer
	{
		public CommandBuffer cmdBuffer;

		public CameraEvent cmdBufferEvent;

		public string cmdBufferName;
	}

	private static int m_nextID;

	private int m_myID;

	private string m_myIDstring;

	private float m_oneOverDepthScale;

	[Header("Ambient Occlusion")]
	[Tooltip("How to inject the occlusion: Post Effect = Overlay, Deferred = Deferred Injection, Debug - Vizualize.")]
	public ApplicationMethod ApplyMethod;

	[Tooltip("Number of samples per pass.")]
	public SampleCountLevel SampleCount;

	[Tooltip("Source of per-pixel normals: None = All, Camera = Forward, GBuffer = Deferred.")]
	public PerPixelNormalSource PerPixelNormals;

	[Tooltip("Final applied intensity of the occlusion effect.")]
	[Range(0f, 1f)]
	public float Intensity;

	[Tooltip("Color tint for occlusion.")]
	public Color Tint;

	[Tooltip("Radius spread of the occlusion.")]
	public float Radius;

	[Tooltip("Power exponent attenuation of the occlusion.")]
	[Range(0f, 16f)]
	public float PowerExponent;

	[Tooltip("Controls the initial occlusion contribution offset.")]
	[Range(0f, 0.99f)]
	public float Bias;

	[Tooltip("Controls the thickness occlusion contribution.")]
	[Range(0f, 1f)]
	public float Thickness;

	[Tooltip("Compute the Occlusion and Blur at half of the resolution.")]
	public bool Downsample;

	[Tooltip("Cache optimization for best performance / quality tradeoff.")]
	public bool CacheAware;

	[Header("Distance Fade")]
	[Tooltip("Control parameters at faraway.")]
	public bool FadeEnabled;

	[Tooltip("Distance in Unity unities that start to fade.")]
	public float FadeStart;

	[Tooltip("Length distance to performe the transition.")]
	public float FadeLength;

	[Tooltip("Final Intensity parameter.")]
	[Range(0f, 1f)]
	public float FadeToIntensity;

	public Color FadeToTint;

	[Tooltip("Final Radius parameter.")]
	public float FadeToRadius;

	[Tooltip("Final PowerExponent parameter.")]
	[Range(0f, 16f)]
	public float FadeToPowerExponent;

	[Tooltip("Final Thickness parameter.")]
	[Range(0f, 1f)]
	public float FadeToThickness;

	[Header("Bilateral Blur")]
	public bool BlurEnabled;

	[Tooltip("Radius in screen pixels.")]
	[Range(1f, 4f)]
	public int BlurRadius;

	[Tooltip("Number of times that the Blur will repeat.")]
	[Range(1f, 4f)]
	public int BlurPasses;

	[Tooltip("Sharpness of blur edge-detection: 0 = Softer Edges, 20 = Sharper Edges.")]
	[Range(0f, 20f)]
	public float BlurSharpness;

	[Header("Temporal Filter")]
	[Tooltip("Accumulates the effect over the time.")]
	public bool FilterEnabled;

	public bool FilterDownsample;

	[Tooltip("Controls the accumulation decayment: 0 = More flicker with less ghosting, 1 = Less flicker with more ghosting.")]
	[Range(0f, 1f)]
	public float FilterBlending;

	[Tooltip("Controls the discard sensitivity based on the motion of the scene and objects.")]
	[Range(0f, 1f)]
	public float FilterResponse;

	private bool m_HDR;

	private bool m_MSAA;

	private PerPixelNormalSource m_prevPerPixelNormals;

	private ApplicationMethod m_prevApplyMethod;

	private bool m_prevDeferredReflections;

	private SampleCountLevel m_prevSampleCount;

	private bool m_prevDownsample;

	private bool m_prevCacheAware;

	private bool m_prevBlurEnabled;

	private int m_prevBlurRadius;

	private int m_prevBlurPasses;

	private bool m_prevFilterEnabled;

	private bool m_prevFilterDownsample;

	private bool m_prevHDR;

	private bool m_prevMSAA;

	private Camera m_targetCamera;

	private RenderTargetIdentifier[] applyDebugTargetsTemporal;

	private RenderTargetIdentifier[] applyDeferredTargets_Log_Temporal;

	private RenderTargetIdentifier[] applyDeferredTargetsTemporal;

	private RenderTargetIdentifier[] applyOcclusionTemporal;

	private RenderTargetIdentifier[] applyPostEffectTargetsTemporal;

	private bool useMRTBlendingFallback;

	private bool checkedforMRTBlendingFallback;

	private CmdBuffer m_commandBuffer_Parameters;

	private CmdBuffer m_commandBuffer_Occlusion;

	private CmdBuffer m_commandBuffer_Apply;

	private static Mesh m_quadMesh;

	private static Material m_occlusionMat;

	private static Material m_blurMat;

	private static Material m_applyOcclusionMat;

	private RenderTextureFormat m_occlusionRTFormat;

	private RenderTextureFormat m_accumTemporalRTFormat;

	private RenderTextureFormat m_temporaryEmissionRTFormat;

	private RenderTextureFormat m_motionIntensityRTFormat;

	private bool m_paramsChanged;

	private bool m_clearHistory;

	private RenderTexture m_occlusionDepthRT;

	private RenderTexture[] m_temporalAccumRT;

	private RenderTexture m_depthMipmap;

	private uint m_sampleStep;

	private uint m_curTemporalIdx;

	private uint m_prevTemporalIdx;

	private string[] m_tmpMipString;

	private int m_numberMips;

	private readonly RenderTargetIdentifier[] m_applyDeferredTargets;

	private readonly RenderTargetIdentifier[] m_applyDeferredTargets_Log;

	private TargetDesc m_target;

	private AmplifyOcclusionViewProjMatrix m_viewProjMatrix;

	private bool UsingTemporalFilter => false;

	private bool UsingMotionVectors => false;

	private bool UsingFilterDownsample => false;

	private void createCommandBuffer(ref CmdBuffer aCmdBuffer, string aCmdBufferName, CameraEvent aCameraEvent)
	{
	}

	private void cleanupCommandBuffer(ref CmdBuffer aCmdBuffer)
	{
	}

	private void createQuadMesh()
	{
	}

	private void PerformBlit(CommandBuffer cb, Material mat, int pass)
	{
	}

	private void checkMaterials(bool aThroughErrorMsg)
	{
	}

	private bool checkRenderTextureFormats()
	{
		return false;
	}

	private void OnEnable()
	{
	}

	private void Reset()
	{
	}

	private void OnDisable()
	{
	}

	private void releaseTemporalRT()
	{
	}

	private void ClearHistory(CommandBuffer cb)
	{
	}

	private void checkParamsChanged()
	{
	}

	private void updateParams()
	{
	}

	private void Update()
	{
	}

	private void OnPreRender()
	{
	}

	private void OnPostRender()
	{
	}

	private void commandBuffer_FillComputeOcclusion(CommandBuffer cb)
	{
	}

	private int commandBuffer_NeighborMotionIntensity(CommandBuffer cb, int aSourceWidth, int aSourceHeight)
	{
		return 0;
	}

	private void commandBuffer_Blur(CommandBuffer cb, RenderTargetIdentifier aSourceRT, int aSourceWidth, int aSourceHeight)
	{
	}

	private int getTemporalPass()
	{
		return 0;
	}

	private void commandBuffer_TemporalFilter(CommandBuffer cb)
	{
	}

	private void commandBuffer_FillApplyDeferred(CommandBuffer cb, bool logTarget)
	{
	}

	private void commandBuffer_FillApplyPostEffect(CommandBuffer cb)
	{
	}

	private void commandBuffer_FillApplyDebug(CommandBuffer cb)
	{
	}

	private void UpdateGlobalShaderConstants(CommandBuffer cb)
	{
	}

	private void UpdateGlobalShaderConstants_AmbientOcclusion(CommandBuffer cb)
	{
	}

	private void UpdateGlobalShaderConstants_Matrices(CommandBuffer cb)
	{
	}
}
