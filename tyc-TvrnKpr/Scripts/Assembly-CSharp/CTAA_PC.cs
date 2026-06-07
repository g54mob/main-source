using UnityEngine;

[RequireComponent(typeof(Camera))]
[AddComponentMenu("Image Effects/LIVENDA/CTAA_PC")]
public class CTAA_PC : MonoBehaviour
{
	[Space(5f)]
	public bool CTAA_Enabled;

	[Header("CTAA Settings")]
	[Tooltip("Number of Frames to Blend via Re-Projection")]
	[Range(3f, 16f)]
	public int TemporalStability;

	[Space(5f)]
	[Tooltip("Anti-Aliasing Response and Strength for HDR Pixels")]
	[Range(0.001f, 4f)]
	public float HdrResponse;

	[Space(5f)]
	[Tooltip("Amount of AA Blur in Geometric edges")]
	[Range(0f, 2f)]
	public float EdgeResponse;

	[Space(5f)]
	[Tooltip("Amount of Automatic Sharpness added based on relative velocities")]
	[Range(0f, 1.5f)]
	public float AdaptiveSharpness;

	[Space(5f)]
	[Tooltip("Amount sub-pixel Camera Jitter")]
	[Range(0f, 0.5f)]
	public float TemporalJitterScale;

	[Space(5f)]
	[Tooltip("Eliminates Micro Shimmer - (No Dynamic Objects) Suitable for Architectural Visualisation, CAD, Engineering or non-moving objects. Camera can be moved.")]
	public bool AntiShimmerMode;

	private int upscaleFactor;

	private int resizeDownFactor;

	public LayerMask m_ExcludeLayers;

	public int SuperSampleMode;

	public bool ExtendedFeatures;

	public bool MSAA_Control;

	public int m_MSAA_Level;

	public bool m_LayerMaskingEnabled;

	private Vector4 delValues;

	private bool PreEnhanceEnabled;

	private float preEnhanceStrength;

	private float preEnhanceClamp;

	private float AdaptiveResolve;

	private float jitterScale;

	private Material ctaaMat;

	private Material mat_enhance;

	private RenderTexture rtAccum0;

	private RenderTexture rtAccum1;

	private RenderTexture afterPreEnhace;

	private RenderTexture upScaleRT;

	private bool firstFrame;

	private bool swap;

	private int frameCounter;

	private Vector3 camoldpos;

	private float[] x_jit;

	private float[] y_jit;

	public bool moveActive;

	public float speed;

	private int count;

	private int startResX;

	private int startResY;

	private Camera m_LayerRenderCam;

	private Camera m_LayerMaskCam;

	private void SetCTAA_Parameters()
	{
	}

	private static Material CreateMaterial(string shadername)
	{
		return null;
	}

	private static void DestroyMaterial(Material mat)
	{
	}

	private void Awake()
	{
	}

	private void OnEnable()
	{
	}

	public void ResetCTAA_CAM()
	{
	}

	private void LateUpdate()
	{
	}

	private void OnDisable()
	{
	}

	private void OnDestroy()
	{
	}

	private void Start()
	{
	}

	private void OnPreCull()
	{
	}

	private void jitterCam()
	{
	}

	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
	}

	public RenderTexture getCTAA_Render()
	{
		return null;
	}
}
