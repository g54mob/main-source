using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Jobs;
using Unity.Profiling;
using UnityEngine;
using UnityEngine.Rendering;

namespace LeTai.Asset.TranslucentImage
{
	[AddComponentMenu("Image Effects/Tai Le Assets/Translucent Image Source")]
	[HelpURL("https://leloctai.com/asset/translucentimage/docs/articles/customize.html#translucent-image-source")]
	[RequireComponent(typeof(Camera))]
	[ExecuteAlways]
	public class TranslucentImageSource : MonoBehaviour
	{
		[SerializeField]
		private BlurConfig blurConfig;

		[Range(0f, 3f)]
		[SerializeField]
		[Tooltip("Reduce the size of the screen before processing. Increase will improve performance but create more artifact")]
		private int downsample;

		[SerializeField]
		[Tooltip("Choose which part of the screen to blur. Smaller region is faster")]
		private Rect blurRegion;

		[SerializeField]
		[Tooltip("How many time to blur per second. Reduce to increase performance and save battery for slow moving background")]
		private float maxUpdateRate;

		[Range(0f, 1f)]
		[Tooltip("Expand the blurred area to avoid gap around moving UIs when using a low Max Update Rate.\nUse higher value for lower Max Update Rate or faster UI movement. Use 0 for infinite Update Rate or static UIs.\nFor the best culling effectiveness, set this at runtime while UIs are moving, and reset to 0 while they're static.\nUnit: fraction of the screen's shorter side")]
		[SerializeField]
		private float cullPadding;

		[Tooltip("Preview the effect fullscreen. Not recommended for runtime use")]
		[SerializeField]
		private bool preview;

		[SerializeField]
		[Tooltip("Fill the background where the frame buffer alpha is 0. Useful for VR Underlay and Passthrough, where these areas would otherwise be black")]
		private BackgroundFill backgroundFill;

		[SerializeField]
		[Tooltip("Always blur the entire blur region to reduce cpu usage")]
		private bool skipCulling;

		private int lastDownsample;

		private Rect lastBlurRegion;

		private Rect lastCamPixelRect;

		private Vector2Int lastCamPixelSize;

		private float lastUpdate;

		private IBlurAlgorithm blurAlgorithm;

		private Camera camera;

		private Material previewMaterial;

		private RenderTexture blurredScreen;

		private CommandBuffer cmd;

		private bool isForOverlayCanvas;

		private bool needRegisterCanvasPreRenderCallback;

		private readonly List<IActiveRegionProvider> activeRegionProviders;

		private VPMatrixCache vpMatrixCache;

		private NativeList<ActiveRegion> activeRegions;

		private NativeArray<Rect> activeRegionJobResult;

		private JobHandle findBoundsJobHandle;

		private static readonly Rect FULLSCREEN_REGION;

		private static ProfilerMarker profilerMarkerCull;

		private TextureDimension lastEyeTexDim;

		private bool forceUpdateBlur;

		public BlurConfig BlurConfig
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public int Downsample
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public Rect BlurRegion
		{
			get
			{
				return default(Rect);
			}
			set
			{
			}
		}

		public Rect ActiveRegion { get; private set; }

		public float MaxUpdateRate
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float CullPadding
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public BackgroundFill BackgroundFill
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool Preview
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool SkipCulling
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public RenderTexture BlurredScreen
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Rect CamRectOverride { get; set; }

		public Rect BlurRegionNormalizedScreenSpace
		{
			get
			{
				return default(Rect);
			}
			set
			{
			}
		}

		internal Camera Cam => null;

		private float MinUpdateCycle => 0f;

		private bool ShouldCull => false;

		public event Action blurredScreenChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action blurRegionChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public void OnBlurRegionChanged()
		{
		}

		public void RegisterActiveRegionProvider(IActiveRegionProvider provider)
		{
		}

		public void UnRegisterActiveRegionProvider(IActiveRegionProvider provider)
		{
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		protected virtual void Start()
		{
		}

		private void Update()
		{
		}

		private void OnDestroy()
		{
		}

		private void OnRenderImage(RenderTexture source, RenderTexture destination)
		{
		}

		public void ManualUpdateBlur(RenderTexture source = null)
		{
		}

		public void ForceUpdateBlur()
		{
		}

		public void SetMaxUpdateRate(float rate)
		{
		}

		private void Init()
		{
		}

		private void InitializeBlurAlgorithm()
		{
		}

		private void OnWillRenderCanvases()
		{
		}

		private void StartCull()
		{
		}

		public bool CompleteCull()
		{
			return false;
		}

		private void CreateNewBlurredScreen(Vector2Int camPixelSize)
		{
		}

		public void ReallocateBlurTexIfNeeded(Rect camPixelRect)
		{
		}

		public bool ShouldUpdateBlur()
		{
			return false;
		}

		private static float GetTrueCurrentTime()
		{
			return 0f;
		}

		private Rect GetActiveCameraRect()
		{
			return default(Rect);
		}

		private Rect ViewportToScreen01Space(Rect rect)
		{
			return default(Rect);
		}

		private Rect Screen01ToViewportSpace(Rect rect)
		{
			return default(Rect);
		}
	}
}
