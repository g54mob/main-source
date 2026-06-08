using UnityEngine;

[ExecuteInEditMode]
public class CameraReplacementTest : ImageEffectBase
{
	public static CameraReplacementTest Instance;

	[Header("Merge Shaders (the shader that merges the data into the final scene - there can only be 1 in use) ---")]
	[Tooltip("Supports dual-color banding\r\n\r\n- See 'Dual-Color Banding Options' for available options\r\n\r\n['Use Array Merge Shader' = false]")]
	public Shader DualColorBandMergeShader;

	[Tooltip("Must restart game for this to take effect.")]
	public bool UseColorArrayMergeShader;

	[Tooltip("Supports color-array\r\n\r\n- See 'Color-Array Options' for available options\r\n\r\n['Use Array Merge Shader' = true]")]
	public Shader ColorArrayMergeShader;

	[Tooltip("Different camera to model angels cause 'noise' in dot projection - use to bance between blured and crisp dots when close")]
	public float filterTolerance = 0.1f;

	[Header("Effect Shader (projects dots onto scene) ---")]
	public bool IncludeNormalShader = true;

	public Shader normalProjectionShader;

	public LayerMask normalCameraCullingMask;

	[Header("Source Pixel Render Target (RT from PixelDataCamera) ---")]
	public RenderTexture pixelRT;

	[Tooltip("The scale of the texture's uv scale for flat areas (i.e. floor)\r\n\r\nNote, this is multiplication, so 0.5 = half scale")]
	public float scaleOfFlat = 0.33f;

	[Tooltip("The scale of the texture's uv scale for raised areas (i.e. objects)\r\n\r\nNote, this is multiplication, so 0.5 = half scale")]
	public float scaleOfRaised = 0.5f;

	[Tooltip("R = determines whether floor or raised\r\n\r\nG = horizontal banding\r\n\r\nB = color index (if 'Use Array Merge Shader' = true)")]
	[Header("Source Depth Render Target (RT from DepthDataCamera) ---")]
	public RenderTexture depthRT;

	[Header("Source Light Mask Render Target (RT from LightDataCamera as mask) ---")]
	public bool UseLightMask = true;

	public RenderTexture lightRT;

	[Header("Shared Color Options ---")]
	public Color flatAreaColor = Color.green;

	public float brightnessOfFlat = 1f;

	[Tooltip("Colors are choosen from this swatch based on the values in the B channel of the 'Depth RT' render target")]
	[Header("Color-Array Options (if 'Use Array Merge Shader' = true) ---")]
	public Texture2D colorArraySwatch;

	[Header("Dual-Color Banding Options (if 'Use Array Merge Shader' = false) ---")]
	public Color raisedAreaColor = Color.red;

	public float brightnessOfRaised = 1f;

	[Tooltip("Enable/Disable Dual-Color Banding")]
	public bool enableColorBanding = true;

	[Tooltip("Where the first color band starts (relative to the floor)\r\n\r\nNote 0.302 = floor and ~0.330 = above any current objects.\r\n\r\nSet outside that range to 'disable' just this one band")]
	public float firstColorBandStart = 0.308f;

	[Tooltip("Where the second color band starts (relative to the floor)\r\n\r\nNote 0.302 = floor and ~0.330 = above any current objects.\r\n\r\nSet outside that range to 'disable' just this one band")]
	public float secondColorBandStart = 0.315f;

	[Tooltip("How much brighter should this band be?\r\n\r\nThis value is added to RGB channels of the 'Raised Area Green' color.\r\n\r\nUse negative values to darken.")]
	public float firstColorBandDelta = 0.3f;

	[Tooltip("How much brighter should this band be?\r\n\r\nThis value is added to RGB channels of the 'Raised Area Green' color.\r\n\r\nUse negative values to darken.")]
	public float secondColorBandDelta = 0.2f;

	[Tooltip("How much dimmer the stale data should be vs. regular\r\n\r\nThis is multiplied by the Flat color (currently not raised) so 0.5 means 50% as bright.")]
	[Header("Stale Data Options ---")]
	public float staleDataDimFactor = 0.5f;

	[Header("Debug Options (no longer available here - add CameraDebugMerge to this camera) ---")]
	private RenderTexture normalRT;

	private RenderTexture maskRT;

	private GameObject effectCamera;

	private Shader originalShader;

	public static RenderTexture NormalRT
	{
		get
		{
			if (Instance != null)
			{
				return Instance.normalRT;
			}
			return null;
		}
	}

	public static RenderTexture TextureBombRT
	{
		get
		{
			if (Instance != null)
			{
				return Instance.pixelRT;
			}
			return null;
		}
	}

	private void OnDestroy()
	{
		originalShader = null;
		normalProjectionShader = null;
		DualColorBandMergeShader = null;
		ColorArrayMergeShader = null;
		normalProjectionShader = null;
		colorArraySwatch = null;
		effectCamera = null;
		RenderTexture.ReleaseTemporary(normalRT);
		normalRT = null;
		pixelRT = null;
		depthRT = null;
		lightRT = null;
		maskRT = null;
	}

	private void OnPreRender()
	{
		Instance = this;
		if (UseColorArrayMergeShader)
		{
			if (ColorArrayMergeShader != null)
			{
				originalShader = shader;
				shader = ColorArrayMergeShader;
			}
			else
			{
				Debug.LogWarning("Don't forget to set the other merge shader, first!");
			}
		}
		else if (DualColorBandMergeShader != null)
		{
			shader = DualColorBandMergeShader;
		}
		CleanRenderTextures();
		Camera camera = null;
		if (IncludeNormalShader)
		{
			normalRT = RenderTexture.GetTemporary(Screen.width, Screen.height, 16);
			normalRT.name = "Normal RT";
			camera = GetEffectCamera();
			camera.CopyFrom(GetComponent<Camera>());
			camera.cullingMask = normalCameraCullingMask;
			camera.clearFlags = CameraClearFlags.Skybox;
			camera.backgroundColor = new Color(0f, 0f, 0f, 0f);
			camera.depthTextureMode = DepthTextureMode.None;
			camera.targetTexture = normalRT;
			if (pixelRT != null)
			{
				pixelRT.wrapMode = TextureWrapMode.Repeat;
				Shader.SetGlobalTexture("_ProjectTex", pixelRT);
			}
			Shader.SetGlobalFloat("_ScaleFloor", scaleOfFlat);
			Shader.SetGlobalFloat("_ScaleRaised", scaleOfRaised);
			if (DroneManager.Instance != null && DroneManager.Instance.CurrentDrone != null)
			{
				Transform transform = null;
				transform = ((!DroneManager.Instance.DebugUseTestSpotlight && !DroneManager.Instance.DebugUseCameraArraySpotlight) ? DroneManager.Instance.CurrentDrone.transform.Find("Spotlight").transform : ((!DroneManager.Instance.DebugUseCameraArraySpotlight) ? DroneManager.Instance.CurrentDrone.Swival.transform.Find("SpotlightTest").transform : DroneManager.Instance.CurrentDrone.transform.Find("SpotlightTestCameraArray").transform));
				Vector3 forward = transform.forward;
				Vector4 vec = new Vector4(forward.x, forward.y, forward.z, 1f);
				GameObject gameObject = GameObject.FindGameObjectWithTag("DroneMainCamera");
				Transform transform2 = gameObject.transform;
				Vector3 vector = transform2.InverseTransformPoint(DroneManager.Instance.CurrentDrone.transform.position);
				Vector4 vec2 = new Vector4(vector.x, vector.y, vector.z, 1f);
				vec2.x += 0.5f;
				vec2.y += 0.5f;
				Shader.SetGlobalVector("_ObjPos", vec2);
				Shader.SetGlobalVector("_ObjForward", vec);
			}
			if (normalProjectionShader != null)
			{
				camera.RenderWithShader(normalProjectionShader, "RenderType");
			}
		}
	}

	private void OnRenderImage(RenderTexture src, RenderTexture dest)
	{
		if (IncludeNormalShader)
		{
			base.material.SetTexture("_OtherTex", normalRT);
		}
		if (UseLightMask)
		{
			base.material.SetTexture("_LightMaskTex", lightRT);
		}
		if (depthRT != null)
		{
			base.material.SetTexture("_DepthTex", depthRT);
		}
		if (UseColorArrayMergeShader && colorArraySwatch != null)
		{
			base.material.SetTexture("_ColorSwatchTex", colorArraySwatch);
		}
		base.material.SetColor("_FlatColor", flatAreaColor);
		base.material.SetFloat("_FlatColorBrightness", brightnessOfFlat);
		base.material.SetColor("_RaisedColor", raisedAreaColor);
		base.material.SetFloat("_RaisedColorBrightness", brightnessOfRaised);
		if (enableColorBanding)
		{
			base.material.SetFloat("_EnableBanding", 1f);
		}
		else
		{
			base.material.SetFloat("_EnableBanding", 0f);
		}
		base.material.SetFloat("_Band1Start", firstColorBandStart);
		base.material.SetFloat("_Band2Start", secondColorBandStart);
		base.material.SetFloat("_Band1ColorDelta", firstColorBandDelta);
		base.material.SetFloat("_Band2ColorDelta", secondColorBandDelta);
		base.material.SetFloat("_StaleDataFadeFactor", staleDataDimFactor);
		base.material.SetFloat("_FilterTolerance", filterTolerance);
		Graphics.Blit(src, dest, base.material);
	}

	private Camera GetEffectCamera()
	{
		if (effectCamera == null)
		{
			effectCamera = new GameObject("EffectCamera");
			effectCamera.AddComponent<Camera>();
			effectCamera.GetComponent<Camera>().enabled = false;
			effectCamera.hideFlags = HideFlags.HideAndDontSave;
		}
		return effectCamera.GetComponent<Camera>();
	}

	private void CleanRenderTextures()
	{
		if (normalRT != null)
		{
			RenderTexture.ReleaseTemporary(normalRT);
			normalRT = null;
		}
		if (maskRT != null)
		{
			RenderTexture.ReleaseTemporary(maskRT);
			maskRT = null;
		}
		Shader.SetGlobalTexture("_NormalOverlayTex", null);
		Shader.SetGlobalTexture("_ProjectTex", null);
		Shader.SetGlobalTexture("_SourceTex", null);
		Shader.SetGlobalTexture("_RandomTex", null);
		Shader.SetGlobalVector("_ObjectPos", Vector4.zero);
		Shader.SetGlobalVector("_ObjectForward", Vector4.zero);
		Shader.SetGlobalFloat("_ScaleFloor", 0f);
		Shader.SetGlobalFloat("_ScaleRaised", 0f);
	}
}
