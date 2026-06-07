using UnityEngine;

[RequireComponent(typeof(Camera))]
[AddComponentMenu("Image Effects/LIVENDA/CTAA_PC")]
public class CTAA_PC : MonoBehaviour
{
	[Space(5f)]
	public bool CTAA_Enabled = true;

	[Header("CTAA Settings")]
	[Tooltip("Number of Frames to Blend via Re-Projection")]
	[Range(3f, 16f)]
	public int TemporalStability = 6;

	[Space(5f)]
	[Tooltip("Anti-Aliasing Response and Strength for HDR Pixels")]
	[Range(0.001f, 4f)]
	public float HdrResponse = 1.2f;

	[Space(5f)]
	[Tooltip("Amount of AA Blur in Geometric edges")]
	[Range(0f, 2f)]
	public float EdgeResponse = 0.5f;

	[Space(5f)]
	[Tooltip("Amount of Automatic Sharpness added based on relative velocities")]
	[Range(0f, 1.5f)]
	public float AdaptiveSharpness = 0.2f;

	[Space(5f)]
	[Tooltip("Amount sub-pixel Camera Jitter")]
	[Range(0f, 0.5f)]
	public float TemporalJitterScale = 0.475f;

	[Space(5f)]
	[Tooltip("Eliminates Micro Shimmer - (No Dynamic Objects) Suitable for Architectural Visualisation, CAD, Engineering or non-moving objects. Camera can be moved.")]
	public bool AntiShimmerMode;

	private int upscaleFactor = 1;

	private int resizeDownFactor = 1;

	public LayerMask m_ExcludeLayers;

	public int SuperSampleMode;

	public bool ExtendedFeatures;

	public bool MSAA_Control;

	public int m_MSAA_Level;

	public bool m_LayerMaskingEnabled = true;

	private Vector4 delValues = new Vector4(0.01f, 2f, 0.5f, 0.3f);

	private bool PreEnhanceEnabled = true;

	private float preEnhanceStrength = 1f;

	private float preEnhanceClamp = 0.005f;

	private float AdaptiveResolve = 3000f;

	private float jitterScale = 1f;

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

	private float[] x_jit = new float[16]
	{
		0.5f, -0.25f, 0.75f, -0.125f, 0.625f, 0.575f, -0.875f, 0.0625f, -0.3f, 0.75f,
		-0.25f, -0.625f, 0.325f, 0.975f, -0.075f, 0.625f
	};

	private float[] y_jit = new float[16]
	{
		0.33f, -0.66f, 0.51f, 0.44f, -0.77f, 0.12f, -0.55f, 0.88f, -0.83f, 0.14f,
		0.71f, -0.34f, 0.87f, -0.12f, 0.75f, 0.08f
	};

	public bool moveActive = true;

	public float speed = 0.002f;

	private int count;

	private int startResX;

	private int startResY;

	private Camera m_LayerRenderCam;

	private Camera m_LayerMaskCam;

	private void SetCTAA_Parameters()
	{
		PreEnhanceEnabled = (double)AdaptiveSharpness > 0.01;
		preEnhanceStrength = Mathf.Lerp(0.2f, 2f, AdaptiveSharpness);
		preEnhanceClamp = Mathf.Lerp(0.005f, 0.12f, AdaptiveSharpness);
		jitterScale = TemporalJitterScale;
		AdaptiveResolve = 3000f;
		ctaaMat.SetFloat("_AntiShimmer", AntiShimmerMode ? 1f : 0f);
		ctaaMat.SetVector("_delValues", delValues);
	}

	private static Material CreateMaterial(string shadername)
	{
		if (string.IsNullOrEmpty(shadername))
		{
			return null;
		}
		return new Material(Shader.Find(shadername))
		{
			hideFlags = HideFlags.HideAndDontSave
		};
	}

	private static void DestroyMaterial(Material mat)
	{
		if (mat != null)
		{
			Object.DestroyImmediate(mat);
			mat = null;
		}
	}

	private void Awake()
	{
		if (ctaaMat == null)
		{
			ctaaMat = CreateMaterial("Hidden/CTAA_PC");
		}
		if (mat_enhance == null)
		{
			mat_enhance = CreateMaterial("Hidden/CTAA_Enhance_PC");
		}
		firstFrame = true;
		swap = true;
		frameCounter = 0;
		SetCTAA_Parameters();
	}

	private void OnEnable()
	{
		if (ctaaMat == null)
		{
			ctaaMat = CreateMaterial("Hidden/CTAA_PC");
		}
		if (mat_enhance == null)
		{
			mat_enhance = CreateMaterial("Hidden/CTAA_Enhance_PC");
		}
		firstFrame = true;
		swap = true;
		frameCounter = 0;
		SetCTAA_Parameters();
		Camera component = GetComponent<Camera>();
		component.depthTextureMode |= DepthTextureMode.Depth;
		component.depthTextureMode |= DepthTextureMode.MotionVectors;
	}

	public void ResetCTAA_CAM()
	{
		count = 0;
		moveActive = true;
	}

	private void LateUpdate()
	{
		if (moveActive)
		{
			if (count < 2)
			{
				base.transform.position += new Vector3(0f, 1f * speed, 0f);
				count++;
			}
			else if (count < 4)
			{
				base.transform.position -= new Vector3(0f, 1f * speed, 0f);
				count++;
			}
			else
			{
				moveActive = false;
			}
		}
	}

	private void OnDisable()
	{
		if (ctaaMat != null)
		{
			DestroyMaterial(ctaaMat);
		}
		if (mat_enhance != null)
		{
			DestroyMaterial(mat_enhance);
		}
		if (rtAccum0 != null)
		{
			Object.DestroyImmediate(rtAccum0);
		}
		rtAccum0 = null;
		if (rtAccum1 != null)
		{
			Object.DestroyImmediate(rtAccum1);
		}
		rtAccum1 = null;
		if (afterPreEnhace != null)
		{
			Object.DestroyImmediate(afterPreEnhace);
		}
		afterPreEnhace = null;
		GetComponent<Camera>().targetTexture = null;
		if (upScaleRT != null)
		{
			Object.DestroyImmediate(upScaleRT);
		}
		upScaleRT = null;
		if (m_LayerRenderCam != null)
		{
			m_LayerRenderCam.targetTexture = null;
			Object.Destroy(m_LayerRenderCam.gameObject);
		}
		if (m_LayerMaskCam != null)
		{
			m_LayerMaskCam.targetTexture = null;
			Object.Destroy(m_LayerMaskCam.gameObject);
		}
	}

	private void OnDestroy()
	{
		if (ctaaMat != null)
		{
			DestroyMaterial(ctaaMat);
		}
		if (mat_enhance != null)
		{
			DestroyMaterial(mat_enhance);
		}
		if (rtAccum0 != null)
		{
			Object.DestroyImmediate(rtAccum0);
		}
		rtAccum0 = null;
		if (rtAccum1 != null)
		{
			Object.DestroyImmediate(rtAccum1);
		}
		rtAccum1 = null;
		if (afterPreEnhace != null)
		{
			Object.DestroyImmediate(afterPreEnhace);
		}
		afterPreEnhace = null;
		GetComponent<Camera>().targetTexture = null;
		if (upScaleRT != null)
		{
			Object.DestroyImmediate(upScaleRT);
		}
		upScaleRT = null;
		if (m_LayerRenderCam != null)
		{
			m_LayerRenderCam.targetTexture = null;
			Object.Destroy(m_LayerRenderCam.gameObject);
		}
		if (m_LayerMaskCam != null)
		{
			m_LayerMaskCam.targetTexture = null;
			Object.Destroy(m_LayerMaskCam.gameObject);
		}
	}

	private void Start()
	{
		if (ExtendedFeatures)
		{
			if (SuperSampleMode == 0)
			{
				upscaleFactor = 1;
				resizeDownFactor = 1;
			}
			else if (SuperSampleMode == 1)
			{
				upscaleFactor = 2;
				resizeDownFactor = 2;
			}
			else if (SuperSampleMode == 2)
			{
				upscaleFactor = 2;
				resizeDownFactor = 1;
			}
			Camera component = GetComponent<Camera>();
			startResX = Screen.width;
			startResY = Screen.height;
			int num = startResX * upscaleFactor;
			int num2 = startResY * upscaleFactor;
			if (upScaleRT == null || upScaleRT.width != num || upScaleRT.height != num2)
			{
				Object.Destroy(upScaleRT);
				upScaleRT = new RenderTexture(num, num2, 0, RenderTextureFormat.ARGB32);
				upScaleRT.filterMode = FilterMode.Bilinear;
				upScaleRT.wrapMode = TextureWrapMode.Repeat;
				upScaleRT.Create();
				GetComponent<Camera>().targetTexture = upScaleRT;
			}
			if (!m_LayerMaskCam)
			{
				GameObject gameObject = new GameObject("LayerMaskRenderCam");
				m_LayerMaskCam = gameObject.AddComponent<Camera>();
				m_LayerMaskCam.CopyFrom(component);
				m_LayerMaskCam.transform.position = base.transform.position;
				m_LayerMaskCam.transform.rotation = base.transform.rotation;
				LayerMask layerMask = -1;
				m_LayerMaskCam.cullingMask = layerMask;
				m_LayerMaskCam.depth = component.depth + 1f;
				m_LayerMaskCam.clearFlags = CameraClearFlags.Depth;
				m_LayerMaskCam.depthTextureMode = DepthTextureMode.None;
				m_LayerMaskCam.targetTexture = null;
				m_LayerMaskCam.allowMSAA = false;
				m_LayerMaskCam.enabled = false;
				m_LayerMaskCam.renderingPath = RenderingPath.Forward;
			}
			if (!m_LayerRenderCam)
			{
				GameObject gameObject2 = new GameObject("LayerRenderCam");
				m_LayerRenderCam = gameObject2.AddComponent<Camera>();
				m_LayerRenderCam.CopyFrom(component);
				m_LayerRenderCam.transform.position = base.transform.position;
				m_LayerRenderCam.transform.rotation = base.transform.rotation;
				m_LayerRenderCam.cullingMask = m_ExcludeLayers;
				m_LayerRenderCam.depth = component.depth + 1f;
				m_LayerRenderCam.clearFlags = CameraClearFlags.Depth;
				m_LayerRenderCam.depthTextureMode = DepthTextureMode.None;
				m_LayerRenderCam.targetTexture = null;
				m_LayerRenderCam.gameObject.AddComponent<RenderPostCTAA>();
				RenderPostCTAA component2 = m_LayerRenderCam.gameObject.GetComponent<RenderPostCTAA>();
				component2.ctaaPC = GetComponent<CTAA_PC>();
				component2.ctaaCamTransform = base.transform;
				component2.MaskRenderCam = m_LayerMaskCam.GetComponent<Camera>();
				component2.maskRenderShader = Shader.Find("Unlit/CtaaMaskRenderShader");
				component2.layerPostMat = new Material(Shader.Find("Hidden/CTAA_Layer_Post"));
				m_LayerRenderCam.enabled = true;
				component2.layerMaskingEnabled = m_LayerMaskingEnabled;
			}
			if (MSAA_Control)
			{
				QualitySettings.antiAliasing = m_MSAA_Level;
			}
		}
		else
		{
			MonoBehaviour.print("CTAA Standard Mode Enabled");
			upscaleFactor = 1;
			resizeDownFactor = 1;
			if (MSAA_Control)
			{
				QualitySettings.antiAliasing = m_MSAA_Level;
			}
		}
	}

	private void OnPreCull()
	{
		if ((startResX != Screen.width || startResY != Screen.height) && ExtendedFeatures)
		{
			if (SuperSampleMode == 0)
			{
				upscaleFactor = 1;
				resizeDownFactor = 1;
			}
			else if (SuperSampleMode == 1)
			{
				upscaleFactor = 2;
				resizeDownFactor = 2;
			}
			else if (SuperSampleMode == 2)
			{
				upscaleFactor = 2;
				resizeDownFactor = 1;
			}
			GetComponent<Camera>();
			startResX = Screen.width;
			startResY = Screen.height;
			int num = startResX * upscaleFactor;
			int num2 = startResY * upscaleFactor;
			if (upScaleRT == null || upScaleRT.width != num || upScaleRT.height != num2)
			{
				Object.Destroy(upScaleRT);
				upScaleRT = new RenderTexture(num, num2, 0, RenderTextureFormat.ARGB32);
				upScaleRT.filterMode = FilterMode.Bilinear;
				upScaleRT.wrapMode = TextureWrapMode.Repeat;
				upScaleRT.Create();
				GetComponent<Camera>().targetTexture = upScaleRT;
				Debug.Log("CTAA SuperResolution Updated");
			}
			moveActive = true;
			count = 0;
		}
		if (CTAA_Enabled)
		{
			jitterCam();
		}
	}

	private void jitterCam()
	{
		GetComponent<Camera>().ResetWorldToCameraMatrix();
		GetComponent<Camera>().ResetProjectionMatrix();
		GetComponent<Camera>().nonJitteredProjectionMatrix = GetComponent<Camera>().projectionMatrix;
		Matrix4x4 projectionMatrix = GetComponent<Camera>().projectionMatrix;
		float num = x_jit[frameCounter] * jitterScale;
		float num2 = y_jit[frameCounter] * jitterScale;
		projectionMatrix.m02 += (num * 2f - 1f) / GetComponent<Camera>().pixelRect.width;
		projectionMatrix.m12 += (num2 * 2f - 1f) / GetComponent<Camera>().pixelRect.height;
		frameCounter++;
		frameCounter %= 16;
		GetComponent<Camera>().projectionMatrix = projectionMatrix;
	}

	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		if (CTAA_Enabled)
		{
			SetCTAA_Parameters();
			if (rtAccum0 == null || rtAccum0.width != source.width / resizeDownFactor || rtAccum0.height != source.height / resizeDownFactor)
			{
				Object.DestroyImmediate(rtAccum0);
				rtAccum0 = new RenderTexture(source.width / resizeDownFactor, source.height / resizeDownFactor, 0, source.format);
				rtAccum0.hideFlags = HideFlags.HideAndDontSave;
				rtAccum0.filterMode = FilterMode.Bilinear;
				rtAccum0.wrapMode = TextureWrapMode.Repeat;
			}
			if (rtAccum1 == null || rtAccum1.width != source.width / resizeDownFactor || rtAccum1.height != source.height / resizeDownFactor)
			{
				Object.DestroyImmediate(rtAccum1);
				rtAccum1 = new RenderTexture(source.width / resizeDownFactor, source.height / resizeDownFactor, 0, source.format);
				rtAccum1.hideFlags = HideFlags.HideAndDontSave;
				rtAccum1.filterMode = FilterMode.Bilinear;
				rtAccum1.wrapMode = TextureWrapMode.Repeat;
			}
			if (PreEnhanceEnabled)
			{
				if (afterPreEnhace == null || afterPreEnhace.width != source.width || afterPreEnhace.height != source.height)
				{
					Object.DestroyImmediate(afterPreEnhace);
					afterPreEnhace = new RenderTexture(source.width, source.height, 0, source.format);
					afterPreEnhace.hideFlags = HideFlags.HideAndDontSave;
					afterPreEnhace.filterMode = FilterMode.Point;
					afterPreEnhace.wrapMode = TextureWrapMode.Clamp;
				}
				mat_enhance.SetFloat("_AEXCTAA", 1f / (float)Screen.width);
				mat_enhance.SetFloat("_AEYCTAA", 1f / (float)Screen.height);
				mat_enhance.SetFloat("_AESCTAA", preEnhanceStrength);
				mat_enhance.SetFloat("_AEMAXCTAA", preEnhanceClamp);
				Graphics.Blit(source, afterPreEnhace, mat_enhance, 1);
				if (firstFrame)
				{
					Graphics.Blit(afterPreEnhace, rtAccum0);
					firstFrame = false;
				}
				ctaaMat.SetFloat("_AdaptiveResolve", AdaptiveResolve);
				ctaaMat.SetVector("_ControlParams", new Vector4(1f, TemporalStability, HdrResponse, EdgeResponse));
				if (swap)
				{
					ctaaMat.SetTexture("_Accum", rtAccum0);
					Graphics.Blit(afterPreEnhace, rtAccum1, ctaaMat);
					Graphics.Blit(rtAccum1, destination);
				}
				else
				{
					ctaaMat.SetTexture("_Accum", rtAccum1);
					Graphics.Blit(afterPreEnhace, rtAccum0, ctaaMat);
					Graphics.Blit(rtAccum0, destination);
				}
			}
			else
			{
				if (firstFrame)
				{
					Graphics.Blit(source, rtAccum0);
					firstFrame = false;
				}
				ctaaMat.SetFloat("_AdaptiveResolve", AdaptiveResolve);
				ctaaMat.SetVector("_ControlParams", new Vector4(1f, TemporalStability, HdrResponse, EdgeResponse));
				if (swap)
				{
					ctaaMat.SetTexture("_Accum", rtAccum0);
					Graphics.Blit(source, rtAccum1, ctaaMat);
					Graphics.Blit(rtAccum1, destination);
				}
				else
				{
					ctaaMat.SetTexture("_Accum", rtAccum1);
					Graphics.Blit(source, rtAccum0, ctaaMat);
					Graphics.Blit(rtAccum0, destination);
				}
			}
			swap = !swap;
		}
		else
		{
			Graphics.Blit(source, destination);
		}
	}

	public RenderTexture getCTAA_Render()
	{
		return upScaleRT;
	}
}
