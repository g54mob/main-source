using System;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Jobs;
using Unity.Profiling;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.XR;

namespace LeTai.Asset.TranslucentImage
{
	[ExecuteAlways]
	[RequireComponent(typeof(Camera))]
	[AddComponentMenu("Image Effects/Tai Le Assets/Translucent Image Source")]
	[HelpURL("https://leloctai.com/asset/translucentimage/docs/articles/customize.html#translucent-image-source")]
	public class TranslucentImageSource : MonoBehaviour
	{
		[SerializeField]
		private BlurConfig blurConfig;

		[SerializeField]
		[Range(0f, 3f)]
		[Tooltip("Reduce the size of the screen before processing. Increase will improve performance but create more artifact")]
		private int downsample;

		[SerializeField]
		[Tooltip("Choose which part of the screen to blur. Smaller region is faster")]
		private Rect blurRegion = new Rect(0f, 0f, 1f, 1f);

		[SerializeField]
		[Tooltip("How many time to blur per second. Reduce to increase performance and save battery for slow moving background")]
		private float maxUpdateRate = float.PositiveInfinity;

		[SerializeField]
		[Tooltip("Preview the effect fullscreen. Not recommended for runtime use")]
		private bool preview;

		[SerializeField]
		[Tooltip("Fill the background where the frame buffer alpha is 0. Useful for VR Underlay and Passthrough, where these areas would otherwise be black")]
		private BackgroundFill backgroundFill = new BackgroundFill();

		[SerializeField]
		[Tooltip("Always blur the entire blur region to reduce cpu usage")]
		private bool skipCulling;

		private int lastDownsample;

		private Rect lastBlurRegion = new Rect(0f, 0f, 1f, 1f);

		private Vector2Int lastCamPixelSize = Vector2Int.zero;

		private float lastUpdate;

		private IBlurAlgorithm blurAlgorithm;

		private Camera camera;

		private Material previewMaterial;

		private RenderTexture blurredScreen;

		private CommandBuffer cmd;

		private bool isForOverlayCanvas;

		private bool needRegisterCanvasPreRenderCallback;

		private readonly List<IActiveRegionProvider> activeRegionProviders = new List<IActiveRegionProvider>();

		private VPMatrixCache vpMatrixCache;

		private NativeList<ActiveRegion> activeRegions;

		private NativeArray<Rect> activeRegionJobResult;

		private JobHandle findBoundsJobHandle;

		private static readonly Rect FULLSCREEN_REGION = new Rect(0f, 0f, 1f, 1f);

		private static ProfilerMarker profilerMarkerCull = new ProfilerMarker("TranslucentImageSource.Culling");

		private TextureDimension lastEyeTexDim;

		public BlurConfig BlurConfig
		{
			get
			{
				return blurConfig;
			}
			set
			{
				blurConfig = value;
				InitializeBlurAlgorithm();
			}
		}

		public int Downsample
		{
			get
			{
				return downsample;
			}
			set
			{
				downsample = Mathf.Max(0, value);
			}
		}

		public Rect BlurRegion
		{
			get
			{
				return blurRegion;
			}
			set
			{
				Vector2 vector = new Vector2(1f / (float)Cam.pixelWidth, 1f / (float)Cam.pixelHeight);
				blurRegion.x = Mathf.Clamp(value.x, 0f, 1f - vector.x);
				blurRegion.y = Mathf.Clamp(value.y, 0f, 1f - vector.y);
				blurRegion.width = Mathf.Clamp(value.width, vector.x, 1f - blurRegion.x);
				blurRegion.height = Mathf.Clamp(value.height, vector.y, 1f - blurRegion.y);
				OnBlurRegionChanged();
			}
		}

		public Rect ActiveRegion { get; private set; }

		public float MaxUpdateRate
		{
			get
			{
				return maxUpdateRate;
			}
			set
			{
				maxUpdateRate = value;
			}
		}

		public BackgroundFill BackgroundFill
		{
			get
			{
				return backgroundFill;
			}
			set
			{
				backgroundFill = value;
			}
		}

		public bool Preview
		{
			get
			{
				return preview;
			}
			set
			{
				preview = value;
			}
		}

		public bool SkipCulling
		{
			get
			{
				return skipCulling;
			}
			set
			{
				skipCulling = value;
			}
		}

		public RenderTexture BlurredScreen
		{
			get
			{
				return blurredScreen;
			}
			set
			{
				blurredScreen = value;
			}
		}

		public Rect CamRectOverride { get; set; } = Rect.zero;

		public Rect BlurRegionNormalizedScreenSpace
		{
			get
			{
				Rect rect = ((CamRectOverride.width == 0f) ? Cam.rect : CamRectOverride);
				rect.min = Vector2.Max(Vector2.zero, rect.min);
				rect.max = Vector2.Min(Vector2.one, rect.max);
				return new Rect(rect.position + BlurRegion.position * rect.size, rect.size * BlurRegion.size);
			}
			set
			{
				Rect rect = ((CamRectOverride.width == 0f) ? Cam.rect : CamRectOverride);
				rect.min = Vector2.Max(Vector2.zero, rect.min);
				rect.max = Vector2.Min(Vector2.one, rect.max);
				BlurRegion = new Rect((value.position - rect.position) / rect.size, value.size / rect.size);
			}
		}

		internal Camera Cam
		{
			get
			{
				if (!camera)
				{
					return camera = GetComponent<Camera>();
				}
				return camera;
			}
		}

		private float MinUpdateCycle
		{
			get
			{
				if (!(MaxUpdateRate > 0f))
				{
					return float.PositiveInfinity;
				}
				return 1f / MaxUpdateRate;
			}
		}

		private bool ShouldCull
		{
			get
			{
				if (!SkipCulling)
				{
					return !XRSettings.enabled;
				}
				return false;
			}
		}

		public event Action blurredScreenChanged;

		public event Action blurRegionChanged;

		public void OnBlurRegionChanged()
		{
			this.blurRegionChanged?.Invoke();
		}

		public void RegisterActiveRegionProvider(IActiveRegionProvider provider)
		{
			activeRegionProviders.Add(provider);
		}

		public void UnRegisterActiveRegionProvider(IActiveRegionProvider provider)
		{
			activeRegionProviders.Remove(provider);
		}

		private void OnEnable()
		{
			vpMatrixCache = new VPMatrixCache();
			activeRegions = new NativeList<ActiveRegion>(4, Allocator.Persistent);
			activeRegionJobResult = new NativeArray<Rect>(1, Allocator.Persistent);
			needRegisterCanvasPreRenderCallback = true;
		}

		private void OnDisable()
		{
			needRegisterCanvasPreRenderCallback = false;
			Canvas.willRenderCanvases -= OnWillRenderCanvases;
			CompleteCull();
			vpMatrixCache.Dispose();
			activeRegions.Dispose();
			activeRegionJobResult.Dispose();
		}

		protected virtual void Start()
		{
			Init();
		}

		private void Update()
		{
			if (needRegisterCanvasPreRenderCallback)
			{
				Canvas.willRenderCanvases += OnWillRenderCanvases;
				needRegisterCanvasPreRenderCallback = false;
			}
		}

		private void OnDestroy()
		{
			if ((bool)BlurredScreen)
			{
				BlurredScreen.Release();
			}
		}

		private void OnRenderImage(RenderTexture source, RenderTexture destination)
		{
			if (cmd == null)
			{
				cmd = new CommandBuffer();
				cmd.name = "Translucent Image Source";
			}
			if (blurAlgorithm != null && BlurConfig != null)
			{
				if (ShouldUpdateBlur())
				{
					cmd.Clear();
					if (CompleteCull())
					{
						ReallocateBlurTexIfNeeded(Vector2Int.RoundToInt(Cam.pixelRect.size));
						blurAlgorithm.Init(BlurConfig, isBirp: true);
						BlurExecutor.BlurExecutionData data = new BlurExecutor.BlurExecutionData(source, this, blurAlgorithm);
						BlurExecutor.ExecuteBlurWithTempTextures(cmd, ref data);
						Graphics.ExecuteCommandBuffer(cmd);
					}
				}
				if (Preview)
				{
					previewMaterial.SetVector(ShaderID.CROP_REGION, RectUtils.ToMinMaxVector(BlurRegion));
					Graphics.Blit(BlurredScreen, destination, previewMaterial);
				}
				else
				{
					Graphics.Blit(source, destination);
				}
			}
			else
			{
				Graphics.Blit(source, destination);
			}
		}

		private void Init()
		{
			previewMaterial = new Material(Shader.Find("Hidden/FillCrop"));
			InitializeBlurAlgorithm();
			ReallocateBlurTexIfNeeded(Vector2Int.RoundToInt(Cam.pixelRect.size));
			lastDownsample = Downsample;
		}

		private void InitializeBlurAlgorithm()
		{
			if (blurConfig is ScalableBlurConfig)
			{
				blurAlgorithm = new ScalableBlur();
			}
			else
			{
				blurAlgorithm = new ScalableBlur();
			}
		}

		private void OnWillRenderCanvases()
		{
			StartCull();
		}

		private void StartCull()
		{
			findBoundsJobHandle.Complete();
			vpMatrixCache.Clear();
			activeRegions.Clear();
			bool flag = false;
			for (int i = 0; i < activeRegionProviders.Count; i++)
			{
				if (activeRegionProviders[i].HaveActiveRegion())
				{
					flag = true;
					if (!ShouldCull)
					{
						break;
					}
					activeRegionProviders[i].GetActiveRegion(vpMatrixCache, out var activeRegion);
					activeRegions.Add(in activeRegion);
				}
			}
			if (flag)
			{
				if (ShouldCull)
				{
					findBoundsJobHandle = new ActiveRegionMergeJob
					{
						vpMatrices = vpMatrixCache.VpMatrices,
						activeRegions = activeRegions,
						scale = new Vector2(1f / (float)Cam.pixelWidth, 1f / (float)Cam.pixelHeight),
						merged = activeRegionJobResult
					}.Schedule();
				}
				else
				{
					ActiveRegion = FULLSCREEN_REGION;
				}
			}
			else
			{
				ActiveRegion = Rect.zero;
			}
		}

		public bool CompleteCull()
		{
			if (!ShouldCull)
			{
				return true;
			}
			findBoundsJobHandle.Complete();
			ActiveRegion = activeRegionJobResult[0];
			if (ActiveRegion.width > 0f)
			{
				return ActiveRegion.height > 0f;
			}
			return false;
		}

		private void CreateNewBlurredScreen(Vector2Int camPixelSize)
		{
			if ((bool)BlurredScreen)
			{
				BlurredScreen.Release();
			}
			if (XRSettings.enabled)
			{
				BlurredScreen = new RenderTexture(XRSettings.eyeTextureDesc);
				BlurredScreen.width = Mathf.RoundToInt((float)BlurredScreen.width * BlurRegion.width) >> Downsample;
				BlurredScreen.height = Mathf.RoundToInt((float)BlurredScreen.height * BlurRegion.height) >> Downsample;
				BlurredScreen.depth = 0;
			}
			else
			{
				BlurredScreen = new RenderTexture(Mathf.RoundToInt((float)camPixelSize.x * BlurRegion.width) >> Downsample, Mathf.RoundToInt((float)camPixelSize.y * BlurRegion.height) >> Downsample, 0);
			}
			BlurredScreen.antiAliasing = 1;
			BlurredScreen.useMipMap = false;
			BlurredScreen.name = base.gameObject.name + " Translucent Image Source";
			BlurredScreen.filterMode = FilterMode.Bilinear;
			BlurredScreen.Create();
			this.blurredScreenChanged?.Invoke();
		}

		public void ReallocateBlurTexIfNeeded(Vector2Int camPixelSize)
		{
			if (BlurredScreen == null || !BlurredScreen.IsCreated() || Downsample != lastDownsample || !RectUtils.ApproximateEqual01(BlurRegion, lastBlurRegion) || camPixelSize != lastCamPixelSize || XRSettings.deviceEyeTextureDimension != lastEyeTexDim)
			{
				CreateNewBlurredScreen(camPixelSize);
				lastDownsample = Downsample;
				lastBlurRegion = BlurRegion;
				lastCamPixelSize = camPixelSize;
				lastEyeTexDim = XRSettings.deviceEyeTextureDimension;
			}
			lastUpdate = GetTrueCurrentTime();
		}

		public bool ShouldUpdateBlur()
		{
			if (!base.enabled)
			{
				return false;
			}
			if (Preview)
			{
				return true;
			}
			return GetTrueCurrentTime() - lastUpdate >= MinUpdateCycle;
		}

		private static float GetTrueCurrentTime()
		{
			return Time.unscaledTime;
		}
	}
}
