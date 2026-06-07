#define UNITY_2022_3_OR_NEWER
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using Unity.Profiling;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Rendering;
using UnityEngine.Rendering.RenderGraphModule;
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering.Universal.Internal;
using WaveHarmonic.Crest.Internal;
using WaveHarmonic.Crest.Portals;
using WaveHarmonic.Crest.RelativeSpace;
using WaveHarmonic.Crest.Utility;
using WaveHarmonic.Crest.Utility.Internal;

namespace WaveHarmonic.Crest
{
	public sealed class WaterRenderer : ManagerBehaviour<WaterRenderer>
	{
		internal static class ShaderIDs
		{
			public static readonly int s_Center = Shader.PropertyToID("g_Crest_WaterCenter");

			public static readonly int s_Scale = Shader.PropertyToID("g_Crest_WaterScale");

			public static readonly int s_Time = Shader.PropertyToID("g_Crest_Time");

			public static readonly int s_CascadeData = Shader.PropertyToID("g_Crest_CascadeData");

			public static readonly int s_CascadeDataSource = Shader.PropertyToID("g_Crest_CascadeDataSource");

			public static readonly int s_LodChange = Shader.PropertyToID("g_Crest_LodChange");

			public static readonly int s_MeshScaleLerp = Shader.PropertyToID("g_Crest_MeshScaleLerp");

			public static readonly int s_LodCount = Shader.PropertyToID("g_Crest_LodCount");

			public static readonly int s_WaterDepthAtViewer = Shader.PropertyToID("g_Crest_WaterDepthAtViewer");

			public static readonly int s_MaximumVerticalDisplacement = Shader.PropertyToID("g_Crest_MaximumVerticalDisplacement");

			public static readonly int s_HorizonNormal = Shader.PropertyToID("g_Crest_HorizonNormal");

			public static readonly int s_AbsorptionColor = Shader.PropertyToID("_Crest_AbsorptionColor");

			public static readonly int s_Absorption = Shader.PropertyToID("_Crest_Absorption");

			public static readonly int s_Scattering = Shader.PropertyToID("_Crest_Scattering");

			public static readonly int s_Anisotropy = Shader.PropertyToID("_Crest_Anisotropy");

			public static readonly int s_AmbientTerm = Shader.PropertyToID("_Crest_AmbientTerm");

			public static readonly int s_DirectTerm = Shader.PropertyToID("_Crest_DirectTerm");

			public static readonly int s_ShadowsAffectsAmbientFactor = Shader.PropertyToID("_Crest_ShadowsAffectsAmbientFactor");

			public static readonly int s_PlanarReflectionsEnabled = Shader.PropertyToID("_Crest_PlanarReflectionsEnabled");

			public static readonly int s_Occlusion = Shader.PropertyToID("_Crest_Occlusion");

			public static readonly int s_OcclusionUnderwater = Shader.PropertyToID("_Crest_OcclusionUnderwater");

			public static readonly int s_CenterDelta = Shader.PropertyToID("g_Crest_WaterCenterDelta");

			public static readonly int s_ScaleChange = Shader.PropertyToID("g_Crest_WaterScaleChange");

			public static readonly int s_VolumeExtinctionLength = Shader.PropertyToID("_Crest_VolumeExtinctionLength");

			public static readonly int s_PrimaryLightDirection = Shader.PropertyToID("g_Crest_PrimaryLightDirection");

			public static readonly int s_PrimaryLightIntensity = Shader.PropertyToID("g_Crest_PrimaryLightIntensity");

			public static readonly int s_PrimaryLightFallback = Shader.PropertyToID("g_Crest_PrimaryLightFallback");

			public static readonly int s_ScreenSpaceShadowTexture = Shader.PropertyToID("_Crest_ScreenSpaceShadowTexture");

			public static readonly int s_TemporaryDepthTexture = Shader.PropertyToID("_Crest_TemporaryDepthTexture");

			public static readonly int s_PrimaryLightHasCookie = Shader.PropertyToID("g_Crest_PrimaryLightHasCookie");
		}

		[Flags]
		internal enum ActiveModules
		{
			Nothing = 0,
			Surface = 2,
			Volume = 4,
			SurfaceAndVolume = 6,
			Reflections = 8,
			Portal = 0x10,
			Meniscus = 0x20,
			Mask = 0x40,
			Shadows = 0x80,
			Everything = -1
		}

		private sealed class PerCameraData
		{
			public bool _RenderedThisFrame;

			public bool _ExecutedThisFrame;

			public float _Scale = 1f;

			public Vector3 _Position;

			public Vector3 _OldViewpointPosition;

			public float _ViewpointHeightAboveWaterSmooth;

			public bool _IsFirstFrameSinceEnabled = true;

			public BufferedData<Vector4[]> _CascadeData;

			public float _ViewerHeightAboveWater;

			public float _ViewerDistanceToShoreline;

			public int _LastFrame = -1;
		}

		[Serializable]
		internal sealed class DebugFields
		{
			[HideInInspector]
			[SerializeField]
			public bool _VisualizeData;

			[SerializeField]
			public VisualizeDataTypes _VisualizeDataType;

			[SerializeField]
			public float _VisualizeDataExposure;

			[SerializeField]
			public float _VisualizeDataRange = 10f;

			[SerializeField]
			public bool _VisualizeDataSaturate = true;

			[HideInInspector]
			[Tooltip("Simulates cameras not rendering.")]
			[SerializeField]
			public bool _SimulatePaused;

			[Tooltip("Attach debug GUI that adds some controls and allows to visualize the water data.")]
			[SerializeField]
			public bool _AttachDebugGUI;

			[Tooltip("Show hidden objects like water chunks in the hierarchy.")]
			[SerializeField]
			public bool _ShowHiddenObjects;

			[HideInInspector]
			[Tooltip("Water will not move with viewpoint.")]
			[SerializeField]
			public bool _DisableFollowViewpoint;

			[Tooltip("Resources are normally released in OnDestroy (except in edit mode) which avoids expensive rebuilds when toggling this component. This option moves it to OnDisable. If you need this active then please report to us.")]
			[SerializeField]
			public bool _DestroyResourcesInOnDisable;

			[HideInInspector]
			[Tooltip("Log scale changes to the console.")]
			[SerializeField]
			public bool _LogScaleChange;

			[HideInInspector]
			[Tooltip("Pause the editor when the scale changes.")]
			[SerializeField]
			public bool _PauseOnScaleChange;

			[HideInInspector]
			[Tooltip("Ignore waves when calculation scale.")]
			[SerializeField]
			public bool _IgnoreWavesForScaleChange;

			[HideInInspector]
			[SerializeField]
			public bool _OverrideScale;

			[HideInInspector]
			[SerializeField]
			public int _ScaleOverride;

			[Tooltip("Emulate running on a client without a GPU. Equivalent to running standalone with -nographics argument.")]
			[SerializeField]
			public bool _ForceNoGraphics;
		}

		internal sealed class CopyTargetsRenderPass : ScriptableRenderPass
		{
			private readonly WaterRenderer _Water;

			private readonly CopyDepthPass _CopyDepthPass;

			private readonly Shader _CopyDepthShader;

			private readonly Material _CopyDepthMaterial;

			private static readonly FieldInfo s_OpaqueColor = typeof(UniversalRenderer).GetField("m_OpaqueColor", BindingFlags.Instance | BindingFlags.NonPublic);

			private static readonly FieldInfo s_ActiveRenderPassQueue = typeof(ScriptableRenderer).GetField("m_ActiveRenderPassQueue", BindingFlags.Instance | BindingFlags.NonPublic);

			private readonly CopyColorPass _CopyColorPass;

			private readonly Material _CopyColorMaterial;

			private readonly Material _SampleColorMaterial;

			public static CopyTargetsRenderPass Instance { get; set; }

			public CopyTargetsRenderPass(WaterRenderer water)
			{
				_Water = water;
				_CopyDepthShader = Shader.Find("Hidden/Universal Render Pipeline/CopyDepth");
				_CopyDepthPass = new CopyDepthPass(base.renderPassEvent, _CopyDepthShader, shouldClear: false, copyToDepth: true, RenderingUtils.MultisampleDepthResolveSupported(), "Crest.DrawWater");
				_CopyColorMaterial = new Material(Shader.Find("Hidden/Universal/CoreBlit"));
				_SampleColorMaterial = new Material(Shader.Find("Hidden/Universal Render Pipeline/Sampling"));
				_CopyColorPass = new CopyColorPass(base.renderPassEvent, _SampleColorMaterial, _CopyColorMaterial, "Crest.DrawWater");
			}

			public static void Enable(WaterRenderer water)
			{
				Instance = new CopyTargetsRenderPass(water);
			}

			[Conditional("UNITY_2022_3_OR_NEWER")]
			internal void OnBeginCameraRendering(ScriptableRenderContext context, Camera camera)
			{
				WaterRenderer water = _Water;
				if ((!water.WriteToColorTexture && !water.WriteToDepthTexture) || !SurfaceRenderer.IsTransparent(water.Surface.Material))
				{
					return;
				}
				base.renderPassEvent = (water.RenderBeforeTransparency ? RenderPassEvent.BeforeRenderingTransparents : RenderPassEvent.AfterRenderingTransparents);
				_CopyColorPass.renderPassEvent = base.renderPassEvent;
				_CopyDepthPass.renderPassEvent = base.renderPassEvent;
				ScriptableRenderer scriptableRenderer = camera.GetUniversalAdditionalCameraData().scriptableRenderer;
				scriptableRenderer.EnqueuePass(this);
				if (GraphicsSettings.GetRenderPipelineSettings<RenderGraphSettings>().enableRenderCompatibilityMode)
				{
					if (water.WriteToColorTexture)
					{
						scriptableRenderer.EnqueuePass(_CopyColorPass);
					}
					if (water.WriteToDepthTexture)
					{
						scriptableRenderer.EnqueuePass(_CopyDepthPass);
					}
				}
			}

			public override void RecordRenderGraph(RenderGraph graph, ContextContainer frame)
			{
				UniversalResourceData universalResourceData = frame.Get<UniversalResourceData>();
				TextureDesc descriptor = universalResourceData.cameraDepthTexture.GetDescriptor(graph);
				if (_Water.WriteToColorTexture)
				{
					_CopyColorPass.RenderToExistingTexture(graph, frame, universalResourceData.cameraOpaqueTexture, universalResourceData.cameraColor, UniversalRenderPipeline.asset.opaqueDownsampling);
				}
				if (_Water.WriteToDepthTexture)
				{
					_CopyDepthPass.CopyToDepth = descriptor.colorFormat == GraphicsFormat.None;
					_CopyDepthPass.Render(graph, frame, universalResourceData.cameraDepthTexture, universalResourceData.cameraDepth);
				}
			}

			[Obsolete]
			public override void OnCameraSetup(CommandBuffer buffer, ref RenderingData data)
			{
				UniversalRenderer universalRenderer = (UniversalRenderer)data.cameraData.renderer;
				RTHandle rTHandle = s_OpaqueColor.GetValue(universalRenderer) as RTHandle;
				if (universalRenderer.cameraColorTargetHandle?.rt != null && rTHandle?.rt != null)
				{
					_CopyColorPass.Setup(universalRenderer.cameraColorTargetHandle, rTHandle, UniversalRenderPipeline.asset.opaqueDownsampling);
				}
				else
				{
					(s_ActiveRenderPassQueue.GetValue(universalRenderer) as List<ScriptableRenderPass>).Remove(_CopyColorPass);
				}
				if (universalRenderer.cameraDepthTargetHandle?.rt != null && universalRenderer.m_DepthTexture?.rt != null)
				{
					_CopyDepthPass.CopyToDepth = universalRenderer.m_DepthTexture.rt.graphicsFormat == GraphicsFormat.None;
					_CopyDepthPass.m_CopyResolvedDepth = false;
					_CopyDepthPass.Setup(universalRenderer.cameraDepthTargetHandle, universalRenderer.m_DepthTexture);
				}
				else
				{
					(s_ActiveRenderPassQueue.GetValue(universalRenderer) as List<ScriptableRenderPass>).Remove(_CopyDepthPass);
				}
			}

			[Obsolete]
			public override void Execute(ScriptableRenderContext context, ref RenderingData data)
			{
			}
		}

		private const string k_SurfaceRendererObsoleteMessage = "This property can now be found on WaterRenderer.Surface";

		[Obsolete("This property can now be found on WaterRenderer.Surface")]
		[HideInInspector]
		[Tooltip("The water chunk renderers will have this layer.")]
		[SerializeField]
		private int _Layer = 4;

		[Obsolete("This property can now be found on WaterRenderer.Surface")]
		[HideInInspector]
		[Tooltip("Material to use for the water surface.")]
		[SerializeField]
		internal Material _Material;

		[Obsolete("This property can now be found on WaterRenderer.Surface")]
		[HideInInspector]
		[Tooltip("Underwater will copy from this material if set.\n\nUseful for overriding properties for the underwater effect. To see what properties can be overriden, see the disabled properties on the underwater material. This does not affect the surface.")]
		[SerializeField]
		internal Material _VolumeMaterial;

		[Obsolete("This property can now be found on WaterRenderer.Surface")]
		[HideInInspector]
		[Tooltip("Template for water chunks as a prefab.\n\nThe only requirements are that the prefab must contain a MeshRenderer at the root and not a MeshFilter or WaterChunkRenderer. MR values will be overwritten where necessary and the prefabs are linked in edit mode.")]
		[SerializeField]
		internal GameObject _ChunkTemplate;

		[Obsolete("This property can now be found on WaterRenderer.Surface")]
		[HideInInspector]
		[Tooltip("Have the water surface cast shadows for albedo (both foam and custom).")]
		[SerializeField]
		internal bool _CastShadows;

		[Obsolete("This property can now be found on WaterRenderer.Surface")]
		[HideInInspector]
		[Tooltip("Whether 'Water Body' components will cull the water tiles.\n\nDisable if you want to use the 'Material Override' feature and still have an ocean.")]
		[SerializeField]
		private bool _WaterBodyCulling = true;

		[Obsolete("This property can now be found on WaterRenderer.Surface")]
		[HideInInspector]
		[Tooltip("How many frames to distribute the chunk bounds calculation.\n\nThe chunk bounds are calculated per frame to ensure culling is correct when using inputs that affect displacement. Some performance can be saved by distributing the load over several frames. The higher the frames, the longer it will take - lowest being instant.")]
		[SerializeField]
		private int _TimeSliceBoundsUpdateFrameCount = 1;

		[Obsolete("This property can now be found on WaterRenderer.Surface")]
		[HideInInspector]
		[Tooltip("How to handle self-intersections of the water surface.\n\nThey can be caused by choppy waves which can cause a flipped underwater effect. When not using the portals/volumes, this fix is only applied when within 2 metres of the water surface. Automatic will disable the fix if portals/volumes are used which is the recommend setting.")]
		[SerializeField]
		internal SurfaceRenderer.SurfaceSelfIntersectionFixMode _SurfaceSelfIntersectionFixMode = SurfaceRenderer.SurfaceSelfIntersectionFixMode.Automatic;

		[Obsolete("This property can now be found on WaterRenderer.Surface")]
		[HideInInspector]
		[Tooltip("Whether to allow sorting using the render queue.\n\nIf you need to change the minor part of the render queue (eg +100), then enable this option. As a side effect, it will also disable the front-to-back rendering optimization for Crest. This option does not affect changing the major part of the render queue (eg AlphaTest, Transparent), as that is always allowed.\n\nRender queue sorting is required for some third-party integrations.")]
		[SerializeField]
		private bool _AllowRenderQueueSorting;

		internal const string k_RunUpdateMarker = "Crest.WaterRenderer.RunUpdate";

		private static readonly ProfilerMarker s_RunUpdateMarker = new ProfilerMarker("Crest.WaterRenderer.RunUpdate");

		private readonly SampleCollisionHelper _CenterOfDetailDisplacementCorrectionHelper = new SampleCollisionHelper();

		private float _ViewpointHeightAboveWaterSmooth;

		private readonly SampleCollisionHelper _SampleHeightHelper = new SampleCollisionHelper();

		private readonly SampleDepthHelper _SampleDepthHelper = new SampleDepthHelper();

		internal float _ViewerHeightAboveWaterPerCamera;

		private readonly SampleCollisionHelper _SampleHeightHelperPerCamera = new SampleCollisionHelper();

		private float _TeleportTimerForHeightQueries;

		private bool _IsFirstFrameSinceEnabled = true;

		internal bool _HasTeleportedThisFrame;

		private Vector3 _OldViewpointPosition;

		private const float k_RenderAboveSeaLevel = 10000f;

		private const float k_RenderBelowSeaLevel = 10000f;

		private Matrix4x4[] _ProjectionMatrix;

		private readonly System.Collections.Generic.Stack<ActiveModules> _RecursiveActiveModules = new System.Collections.Generic.Stack<ActiveModules>();

		internal ActiveModules _ActiveModules;

		private RenderPipeline _SetUpFor;

		internal MaskRenderer _Mask;

		private bool _DonePerCameraHeight;

		internal bool _PerCameraHeightReady;

		private bool _Initialized;

		private int _GeneratedSettingsHash;

		internal static Action<WaterRenderer, Camera> s_OnBeforeBuildCommandBuffer;

		internal const string k_DrawLodData = "Crest.LodData";

		private BufferedData<Vector4[]> _CascadeData;

		internal ScriptableRenderContext _Context;

		internal static Action<Camera> s_OnLoadCameraData;

		internal static Action<Camera> s_OnStoreCameraData;

		internal static Action<Camera> s_OnRemoveCameraData;

		private readonly List<Camera> _Cameras = new List<Camera>();

		private PerCameraData _CurrentPerCameraData;

		private readonly Dictionary<Camera, PerCameraData> _PerCameraData = new Dictionary<Camera, PerCameraData>();

		private readonly Dictionary<Camera, int> _PerCameraLastFrame = new Dictionary<Camera, int>();

		private Coroutine _EndOfFrame;

		private bool _IsEndOfFrame;

		private bool _RenderShadows;

		private bool _HasAnyViewpointExecuted;

		private bool _HasAnyViewerRendered;

		internal const string k_DrawWater = "Crest.DrawWater";

		internal const string k_DrawCopyColor = "CopyColor";

		internal const string k_DrawCopyDepth = "CopyDepth";

		private bool _DoneMatrices;

		private CommandBuffer _ScreenSpaceShadowMapBuffer;

		private CommandBuffer _UpdateColorDepthTexturesBuffer;

		private bool _DoneCameraOpaqueTexture;

		private RTHandle _CameraOpaqueTexture;

		private CommandBuffer _CameraOpaqueTextureCommands;

		internal const float k_MaximumWindSpeedKPH = 150f;

		[Tooltip("The camera which drives the water data.\n\nSetting this is optional. Defaults to the main camera.")]
		[SerializeField]
		internal Camera _Camera;

		[Tooltip("Optional provider for time.\n\nCan be used to hard-code time for automation, or provide server time. Defaults to local Unity time.")]
		[SerializeField]
		internal TimeProvider _TimeProvider;

		[Tooltip("Uses a provided WindZone as the source of global wind.\n\nIt must be directional. Wind speed units are presumed to be in m/s.")]
		[SerializeField]
		private WindZone _WindZone;

		[Tooltip("Whether to override the given wind zone's wind speed.")]
		[SerializeField]
		private bool _OverrideWindZoneWindSpeed;

		[Tooltip("Base wind speed in km/h.\n\nControls wave conditions. Can be overridden on Shape* components.")]
		[SerializeField]
		internal float _WindSpeed = 10f;

		[Tooltip("Whether to override the given wind zone's wind direction.")]
		[SerializeField]
		private bool _OverrideWindZoneWindDirection;

		[Tooltip("Base wind direction in degrees.\n\nControls wave conditions. Can be overridden on Shape* components.")]
		[SerializeField]
		internal float _WindDirection;

		[Tooltip("Whether to override the given wind zone's wind turbulence.")]
		[SerializeField]
		private bool _OverrideWindZoneWindTurbulence;

		[Tooltip("Base wind turbulence.\n\nControls wave conditions. Can be overridden on ShapeFFT components.")]
		[SerializeField]
		internal float _WindTurbulence = 0.145f;

		[Tooltip("Provide your own gravity value instead of Physics.gravity.")]
		[SerializeField]
		private bool _OverrideGravity;

		[Tooltip("Gravity for all wave calculations.")]
		[SerializeField]
		private float _GravityOverride = -9.8f;

		[Tooltip("Multiplier for physics gravity.")]
		[SerializeField]
		private float _GravityMultiplier = 1f;

		[Tooltip("The primary light that affects the water.\n\nSetting this is optional. This should be a directional light. Defaults to RenderSettings.sun.")]
		[SerializeField]
		private Light _PrimaryLight;

		[Tooltip("When in the render pipeline the water is rendered.\n\nDefault is the old behaviour which is controlled by Unity.\n\nBefore Transparency has advantages like being compatible with soft particles, refractive shaders, and possibly third-party atmospheric fog.")]
		[SerializeField]
		private WaterInjectionPoint _InjectionPoint;

		[Tooltip("Whether to write the water surface color to the color/opaque texture.\n\nThis is likely only beneficial if the water injection point is before transparency, and there are shaders which need it (like refraction).")]
		[SerializeField]
		internal bool _WriteToColorTexture = true;

		[Tooltip("Whether to write the water surface depth to the depth texture.\n\nThe water surface writes to the depth buffer, but Unity does not copy it to the depth texture for post-processing effects like Depth of Field (or refraction). This will copy the depth buffer to the depth texture.\n\nIf the water injection point is in the transparent pass, be wary that it will include all transparent objects that write to depth. Furthermore, other third parties may already be doing this, and we do not check whether it is necessary to copy or not.\n\nThis feature has a considerable overhead if using the built-in render pipeline, as it requires rendering the surface depth another time.")]
		[SerializeField]
		internal bool _WriteToDepthTexture = true;

		[Tooltip("Whether to enable motion vector support.")]
		[SerializeField]
		internal bool _WriteMotionVectors = true;

		[Tooltip("Whether to override the automatic detection of framebuffer HDR rendering (BIRP only).\n\nRendering using HDR formats is optional, but there is no way for us to determine if HDR rendering is enabled in the Graphics Settings. We make an educated based on which platform is the target. If you see rendering issues, try disabling this.\n\n This has nothing to do with having an HDR monitor.")]
		[SerializeField]
		private bool _OverrideRenderHDR;

		[Tooltip("Force HDR format usage (BIRP only).\n\nIf enabled, we assume the framebuffer is an HDR format, otherwise an LDR format.")]
		[SerializeField]
		private bool _RenderHDR = true;

		[Tooltip("The water surface renderer.")]
		[SerializeReference]
		private SurfaceRenderer _Surface = new SurfaceRenderer();

		[Tooltip("The scale the water can be (infinity for no maximum).\n\nWater is scaled horizontally with viewer height, to keep the meshing suitable for elevated viewpoints. This sets the minimum and maximum the water will be scaled. Low minimum values give lots of detail, but will limit the horizontal extents of the water detail. Increasing the minimum value can be a great performance saving for mobile as it will reduce draw calls.")]
		[SerializeField]
		private Vector2 _ScaleRange = new Vector2(4f, 256f);

		[Tooltip("Drops the height for maximum water detail based on waves.\n\nThis means if there are big waves, max detail level is reached at a lower height, which can help visual range when there are very large waves and camera is at sea level.")]
		[SerializeField]
		private float _DropDetailHeightBasedOnWaves = 0.2f;

		[Tooltip("Number of levels of details (chunks, scales etc) to generate.\n\nThe horizontal range of the water surface doubles for each added LOD, while GPU processing time increases linearly. The higher the number, the further out detail will be. Furthermore, the higher the count, the more larger wavelengths can be filtering in queries.")]
		[SerializeField]
		private int _Slices = 9;

		[Tooltip("The resolution of the various water LOD data.\n\nThis includes mesh density, displacement textures, foam data, dynamic wave simulation, etc. Sets the 'detail' present in the water - larger values give more detail at increased run-time expense. This value can be overriden per LOD in their respective settings except for Animated Waves which is tied to this value.")]
		[SerializeField]
		private int _Resolution = 384;

		[Tooltip("How much of the water shape gets tessellated by geometry.\n\nFor example, if set to four, every geometry quad will span 4x4 LOD data texels. a value of 2 will generate one vert per 2x2 LOD data texels. A value of 1 means a vert is generated for every LOD data texel. Larger values give lower fidelity surface shape with higher performance.")]
		[SerializeField]
		internal int _GeometryDownSampleFactor = 2;

		[Tooltip("Applied to the extents' far vertices to make them larger.\n\nIncrease if the extents do not reach the horizon or you see the underwater effect at the horizon.")]
		[SerializeField]
		internal float _ExtentsSizeMultiplier = 100f;

		[Tooltip("Whether to support multiple center-of-detail (per camera).")]
		[SerializeField]
		private bool _MultipleViewpoints;

		[Tooltip("The viewpoint which drives the water detail - the center of the LOD system.\n\nSetting this is optional. Defaults to the camera.")]
		[SerializeField]
		private Transform _Viewpoint;

		[Tooltip("Rules to exclude cameras from being a center-of-detail.\n\nThese are exclusion rules, so for all cameras, select Nothing.")]
		[SerializeField]
		private WaterCameraExclusion _CameraExclusions = WaterCameraExclusion.Everything;

		[Tooltip("The background rendering mode when a camera does not render.\n\nWhen switching between multiple cameras, simulations will not progress for cameras which do not render for that frame. This setting tells the system when it should continue to progress the simulations.")]
		[SerializeField]
		internal WaterDataBackgroundMode _DataBackgroundMode = WaterDataBackgroundMode.Never;

		[Tooltip("Keep the center of detail from drifting from the viewpoint.\n\nLarge horizontal displacement can displace the center of detail. This uses queries to keep the center of detail aligned.")]
		[SerializeField]
		private bool _CenterOfDetailDisplacementCorrection = true;

		[Tooltip("Also checks terrain height when determining the scale.\n\nThe scale is changed based on the viewer's height above the water surface. This can be a problem with varied water level, as the viewer may not be directly over the higher water level leading to a height difference, and thus incorrect scale.")]
		[SerializeField]
		private bool _SampleTerrainHeightForScale = true;

		[Tooltip("Forces smoothing for scale changes.\n\nWhen water level varies, smoothing scale change can prevent pops when the viewer's height above water sharply changes. Smoothing is disabled when terrain sampling is enabled or the water level simulation is disabled.")]
		[SerializeField]
		private bool _ForceScaleChangeSmoothing;

		[Tooltip("The distance threshold for when the viewer has considered to have teleported.\n\nThis is used to prevent popping, and for prewarming simulations. Threshold is in Unity units.")]
		[SerializeField]
		private float _TeleportThreshold = 100f;

		[Tooltip("All waves (including Dynamic Waves) are written to this simulation.")]
		[SerializeReference]
		internal AnimatedWavesLod _AnimatedWavesLod = new AnimatedWavesLod();

		[Tooltip("Water depth information used for shallow water, shoreline foam, wave attenuation, among others.")]
		[SerializeReference]
		internal DepthLod _DepthLod = new DepthLod();

		[Tooltip("Varying water level to support water bodies at different heights and rivers to run down slopes.")]
		[SerializeReference]
		internal LevelLod _LevelLod = new LevelLod();

		[Tooltip("Simulation of foam created in choppy water and dissipating over time.")]
		[SerializeReference]
		internal FoamLod _FoamLod = new FoamLod();

		[Tooltip("Dynamic waves generated from interactions with objects such as boats.")]
		[SerializeReference]
		internal DynamicWavesLod _DynamicWavesLod = new DynamicWavesLod();

		[Tooltip("Horizontal motion of water body, akin to water currents.")]
		[SerializeReference]
		internal FlowLod _FlowLod = new FlowLod();

		[Tooltip("Shadow information used for lighting water.")]
		[SerializeReference]
		internal ShadowLod _ShadowLod = new ShadowLod();

		[Tooltip("Absorption information - gives color to water.")]
		[SerializeReference]
		internal AbsorptionLod _AbsorptionLod = new AbsorptionLod();

		[Tooltip("Scattering information - gives color to water.")]
		[SerializeReference]
		internal ScatteringLod _ScatteringLod = new ScatteringLod();

		[Tooltip("Clip surface information for clipping the water surface.")]
		[SerializeReference]
		internal ClipLod _ClipLod = new ClipLod();

		[Tooltip("Albedo - a colour layer composited onto the water surface.")]
		[SerializeReference]
		internal AlbedoLod _AlbedoLod = new AlbedoLod();

		[Tooltip("The reflection renderer.")]
		[SerializeReference]
		internal WaterReflections _Reflections = new WaterReflections();

		[Tooltip("The underwater renderer.")]
		[SerializeReference]
		internal UnderwaterRenderer _Underwater = new UnderwaterRenderer();

		[Tooltip("The meniscus module.")]
		[SerializeReference]
		internal Meniscus _Meniscus = new Meniscus();

		[HideInInspector]
		[Tooltip("The portal renderer.")]
		[SerializeReference]
		internal PortalRenderer _Portals = new PortalRenderer();

		[SerializeField]
		internal bool _ShowWaterProxyPlane;

		[Tooltip("Move water with Scene view camera if Scene window is focused.")]
		[SerializeField]
		internal bool _FollowSceneCamera = true;

		[Tooltip("Each scene view will have its own viewpoint.")]
		[SerializeField]
		private bool _EditorMultipleViewpoints = true;

		[Tooltip("Whether height queries are enabled in edit mode.\n\nQueries force enable \"Always Refresh\" scene view option.")]
		[SerializeField]
		internal bool _HeightQueries = true;

		[SerializeField]
		internal DebugFields _Debug = new DebugFields();

		[SerializeField]
		[HideInInspector]
		internal WaterResources _Resources;

		internal const RenderPassEvent k_WaterRenderPassEvent = RenderPassEvent.BeforeRenderingTransparents;

		public AbsorptionLod AbsorptionLod => _AbsorptionLod;

		public AlbedoLod AlbedoLod => _AlbedoLod;

		[Obsolete("This property can now be found on WaterRenderer.Surface")]
		public bool AllowRenderQueueSorting
		{
			get
			{
				return GetAllowRenderQueueSorting();
			}
			set
			{
				SetAllowRenderQueueSorting(_AllowRenderQueueSorting, _AllowRenderQueueSorting = value);
			}
		}

		public AnimatedWavesLod AnimatedWavesLod => _AnimatedWavesLod;

		public Camera Viewer
		{
			get
			{
				return GetViewer();
			}
			set
			{
				_Camera = value;
			}
		}

		public WaterCameraExclusion CameraExclusions
		{
			get
			{
				return _CameraExclusions;
			}
			set
			{
				_CameraExclusions = value;
			}
		}

		[Obsolete("This property can now be found on WaterRenderer.Surface")]
		public bool CastShadows
		{
			get
			{
				return GetCastShadows();
			}
			set
			{
				SetCastShadows(_CastShadows, _CastShadows = value);
			}
		}

		public bool CenterOfDetailDisplacementCorrection
		{
			get
			{
				return _CenterOfDetailDisplacementCorrection;
			}
			set
			{
				_CenterOfDetailDisplacementCorrection = value;
			}
		}

		public ClipLod ClipLod => _ClipLod;

		public WaterDataBackgroundMode DataBackgroundMode
		{
			get
			{
				return _DataBackgroundMode;
			}
			set
			{
				_DataBackgroundMode = value;
			}
		}

		public DepthLod DepthLod => _DepthLod;

		public float DropDetailHeightBasedOnWaves
		{
			get
			{
				return _DropDetailHeightBasedOnWaves;
			}
			set
			{
				_DropDetailHeightBasedOnWaves = value;
			}
		}

		public DynamicWavesLod DynamicWavesLod => _DynamicWavesLod;

		public float ExtentsSizeMultiplier
		{
			get
			{
				return _ExtentsSizeMultiplier;
			}
			set
			{
				_ExtentsSizeMultiplier = value;
			}
		}

		public FlowLod FlowLod => _FlowLod;

		public FoamLod FoamLod => _FoamLod;

		public bool ForceScaleChangeSmoothing
		{
			get
			{
				return _ForceScaleChangeSmoothing;
			}
			set
			{
				_ForceScaleChangeSmoothing = value;
			}
		}

		public int GeometryDownSampleFactor
		{
			get
			{
				return _GeometryDownSampleFactor;
			}
			set
			{
				_GeometryDownSampleFactor = value;
			}
		}

		public float GravityMultiplier
		{
			get
			{
				return _GravityMultiplier;
			}
			set
			{
				_GravityMultiplier = value;
			}
		}

		public float GravityOverride
		{
			get
			{
				return _GravityOverride;
			}
			set
			{
				_GravityOverride = value;
			}
		}

		public WaterInjectionPoint InjectionPoint
		{
			get
			{
				return _InjectionPoint;
			}
			set
			{
				_InjectionPoint = value;
			}
		}

		[Obsolete("This property can now be found on WaterRenderer.Surface")]
		public int Layer
		{
			get
			{
				return GetLayer();
			}
			set
			{
				SetLayer(_Layer, _Layer = value);
			}
		}

		public LevelLod LevelLod => _LevelLod;

		[Obsolete("This property can now be found on WaterRenderer.Surface")]
		public Material Material
		{
			get
			{
				return GetMaterial();
			}
			set
			{
				SetMaterial(_Material, _Material = value);
			}
		}

		public Meniscus Meniscus => _Meniscus;

		public bool OverrideGravity
		{
			get
			{
				return _OverrideGravity;
			}
			set
			{
				_OverrideGravity = value;
			}
		}

		public bool OverrideRenderHDR
		{
			get
			{
				return _OverrideRenderHDR;
			}
			set
			{
				_OverrideRenderHDR = value;
			}
		}

		public bool OverrideWindZoneWindDirection
		{
			get
			{
				return _OverrideWindZoneWindDirection;
			}
			set
			{
				_OverrideWindZoneWindDirection = value;
			}
		}

		public bool OverrideWindZoneWindSpeed
		{
			get
			{
				return _OverrideWindZoneWindSpeed;
			}
			set
			{
				_OverrideWindZoneWindSpeed = value;
			}
		}

		public bool OverrideWindZoneWindTurbulence
		{
			get
			{
				return _OverrideWindZoneWindTurbulence;
			}
			set
			{
				_OverrideWindZoneWindTurbulence = value;
			}
		}

		public PortalRenderer Portals => _Portals;

		public Light PrimaryLight
		{
			get
			{
				return GetPrimaryLight();
			}
			set
			{
				_PrimaryLight = value;
			}
		}

		public WaterReflections Reflections => _Reflections;

		public bool RenderHDR
		{
			get
			{
				return _RenderHDR;
			}
			set
			{
				_RenderHDR = value;
			}
		}

		public int LodResolution
		{
			get
			{
				return _Resolution;
			}
			set
			{
				_Resolution = value;
			}
		}

		public bool SampleTerrainHeightForScale
		{
			get
			{
				return _SampleTerrainHeightForScale;
			}
			set
			{
				_SampleTerrainHeightForScale = value;
			}
		}

		public Vector2 ScaleRange
		{
			get
			{
				return _ScaleRange;
			}
			set
			{
				_ScaleRange = value;
			}
		}

		public ScatteringLod ScatteringLod => _ScatteringLod;

		public ShadowLod ShadowLod => _ShadowLod;

		public int LodLevels
		{
			get
			{
				return _Slices;
			}
			set
			{
				_Slices = value;
			}
		}

		public SurfaceRenderer Surface => _Surface;

		public float TeleportThreshold
		{
			get
			{
				return _TeleportThreshold;
			}
			set
			{
				_TeleportThreshold = value;
			}
		}

		[Obsolete("This property can now be found on WaterRenderer.Surface")]
		public int TimeSliceBoundsUpdateFrameCount
		{
			get
			{
				return GetTimeSliceBoundsUpdateFrameCount();
			}
			set
			{
				SetTimeSliceBoundsUpdateFrameCount(_TimeSliceBoundsUpdateFrameCount, _TimeSliceBoundsUpdateFrameCount = value);
			}
		}

		public UnderwaterRenderer Underwater => _Underwater;

		public Transform Viewpoint
		{
			get
			{
				return GetViewpoint();
			}
			set
			{
				_Viewpoint = value;
			}
		}

		[Obsolete("This property can now be found on WaterRenderer.Surface")]
		public Material VolumeMaterial
		{
			get
			{
				return GetVolumeMaterial();
			}
			set
			{
				SetVolumeMaterial(_VolumeMaterial, _VolumeMaterial = value);
			}
		}

		[Obsolete("This property can now be found on WaterRenderer.Surface")]
		public bool WaterBodyCulling
		{
			get
			{
				return GetWaterBodyCulling();
			}
			set
			{
				SetWaterBodyCulling(_WaterBodyCulling, _WaterBodyCulling = value);
			}
		}

		public float WindDirection
		{
			get
			{
				return GetWindDirection();
			}
			set
			{
				_WindDirection = value;
			}
		}

		public float WindSpeed
		{
			get
			{
				return GetWindSpeed();
			}
			set
			{
				_WindSpeed = value;
			}
		}

		public float WindTurbulence
		{
			get
			{
				return GetWindTurbulence();
			}
			set
			{
				_WindTurbulence = value;
			}
		}

		public WindZone WindZone
		{
			get
			{
				return _WindZone;
			}
			set
			{
				_WindZone = value;
			}
		}

		public bool WriteMotionVectors
		{
			get
			{
				return GetWriteMotionVectors();
			}
			set
			{
				_WriteMotionVectors = value;
			}
		}

		public bool WriteToColorTexture
		{
			get
			{
				return GetWriteToColorTexture();
			}
			set
			{
				_WriteToColorTexture = value;
			}
		}

		public bool WriteToDepthTexture
		{
			get
			{
				return GetWriteToDepthTexture();
			}
			set
			{
				_WriteToDepthTexture = value;
			}
		}

		internal Camera CurrentCamera { get; private set; }

		internal float ViewerAltitudeLevelAlpha { get; private set; }

		public float ViewerHeightAboveWater { get; private set; }

		public float ViewpointHeightAboveWater { get; private set; }

		public float ViewerDistanceToShoreline { get; private set; }

		private Vector3 TeleportOriginThisFrame => ShiftingOrigin.ShiftThisFrame;

		internal float WindSpeedKPH => _WindSpeed;

		private bool WindSpeedOverriden
		{
			get
			{
				if (!(_WindZone == null))
				{
					return _OverrideWindZoneWindSpeed;
				}
				return true;
			}
		}

		private bool WindDirectionOverriden
		{
			get
			{
				if (!(_WindZone == null))
				{
					return _OverrideWindZoneWindDirection;
				}
				return true;
			}
		}

		private bool WindTurbulenceOverriden
		{
			get
			{
				if (!(_WindZone == null))
				{
					return _OverrideWindZoneWindTurbulence;
				}
				return true;
			}
		}

		internal Vector3 Position { get; private set; }

		internal GameObject Container { get; private set; }

		public float SeaLevel => Position.y;

		public WaveHarmonic.Crest.Utility.Internal.Stack<ITimeProvider> TimeProviders { get; private set; } = new WaveHarmonic.Crest.Utility.Internal.Stack<ITimeProvider>();

		public ITimeProvider TimeProvider => TimeProviders.Peek();

		internal float CurrentTime => TimeProvider.Time;

		internal float DeltaTime => TimeProvider.Delta;

		public float Gravity => _GravityMultiplier * Mathf.Abs(_OverrideGravity ? _GravityOverride : Physics.gravity.y);

		internal bool RenderBeforeTransparency => _InjectionPoint == WaterInjectionPoint.BeforeTransparent;

		internal List<Lod> Simulations { get; } = new List<Lod>();

		internal bool Active
		{
			get
			{
				if (base.enabled)
				{
					return this == ManagerBehaviour<WaterRenderer>.Instance;
				}
				return false;
			}
		}

		public static bool RunningWithoutGraphics
		{
			get
			{
				bool num = SystemInfo.graphicsDeviceType == GraphicsDeviceType.Null;
				bool flag = ManagerBehaviour<WaterRenderer>.Instance != null && ManagerBehaviour<WaterRenderer>.Instance._Debug._ForceNoGraphics;
				return num || flag;
			}
		}

		internal bool IsRunningWithoutGraphics
		{
			get
			{
				if (SystemInfo.graphicsDeviceType != GraphicsDeviceType.Null)
				{
					return _Debug._ForceNoGraphics;
				}
				return true;
			}
		}

		[Obsolete("We no longer care whether Unity is running in non-interactive mode.")]
		public static bool RunningHeadless => false;

		public static int FrameCount => Time.frameCount;

		internal CommandBuffer SimulationBuffer { get; private set; }

		internal BufferedData<Vector4[]> CascadeData { get; private set; }

		internal int BufferSize => 2;

		public float Scale { get; private set; }

		internal bool ScaleCouldIncrease
		{
			get
			{
				if (_ScaleRange.y != float.PositiveInfinity)
				{
					return Scale < _ScaleRange.y * 0.99f;
				}
				return true;
			}
		}

		internal bool ScaleCouldDecrease => Scale > _ScaleRange.x * 1.01f;

		internal int ScaleDifferencePower2 { get; private set; }

		public ICollisionProvider CollisionProvider => AnimatedWavesLod?.Provider;

		public IFlowProvider FlowProvider => FlowLod?.Provider;

		public IDepthProvider DepthProvider => DepthLod?.Provider;

		private bool FallBackRequired
		{
			get
			{
				if (_HasAnyViewerRendered)
				{
					return !_HasAnyViewpointExecuted;
				}
				return false;
			}
		}

		internal bool IsSeparateViewpointCameraLoop { get; private set; }

		internal bool IsMultipleViewpointMode
		{
			get
			{
				if (!MultipleViewpoints)
				{
					return EditorMultipleViewpoints;
				}
				return true;
			}
		}

		internal bool IsSingleViewpointMode => !IsMultipleViewpointMode;

		internal bool SupportsRecursiveRendering => true;

		private bool EditorMultipleViewpoints => false;

		internal bool MultipleViewpoints
		{
			get
			{
				if (_MultipleViewpoints)
				{
					return SupportsRecursiveRendering;
				}
				return false;
			}
		}

		internal Rendering.BIRP.FrameBufferFormatOverride FrameBufferFormatOverride
		{
			get
			{
				if (_OverrideRenderHDR)
				{
					if (!_RenderHDR)
					{
						return Rendering.BIRP.FrameBufferFormatOverride.LDR;
					}
					return Rendering.BIRP.FrameBufferFormatOverride.HDR;
				}
				return Rendering.BIRP.FrameBufferFormatOverride.None;
			}
		}

		private protected override int Version => Mathf.Max(base.Version, 2);

		[Obsolete]
		private int GetLayer()
		{
			return Surface.Layer;
		}

		[Obsolete]
		private void SetLayer(int previous, int current)
		{
			Surface.Layer = current;
		}

		[Obsolete]
		private Material GetMaterial()
		{
			return Surface.Material;
		}

		[Obsolete]
		private void SetMaterial(Material previous, Material current)
		{
			Surface.Material = current;
		}

		[Obsolete]
		private Material GetVolumeMaterial()
		{
			return Surface.VolumeMaterial;
		}

		[Obsolete]
		private void SetVolumeMaterial(Material previous, Material current)
		{
			Surface.VolumeMaterial = current;
		}

		[Obsolete]
		private bool GetCastShadows()
		{
			return Surface.CastShadows;
		}

		[Obsolete]
		private void SetCastShadows(bool previous, bool current)
		{
			Surface.CastShadows = current;
		}

		[Obsolete]
		private bool GetWaterBodyCulling()
		{
			return Surface.WaterBodyCulling;
		}

		[Obsolete]
		private void SetWaterBodyCulling(bool previous, bool current)
		{
			Surface.WaterBodyCulling = current;
		}

		[Obsolete]
		private int GetTimeSliceBoundsUpdateFrameCount()
		{
			return Surface.TimeSliceBoundsUpdateFrameCount;
		}

		[Obsolete]
		private void SetTimeSliceBoundsUpdateFrameCount(int previous, int current)
		{
			Surface.TimeSliceBoundsUpdateFrameCount = current;
		}

		[Obsolete]
		private bool GetAllowRenderQueueSorting()
		{
			return Surface.AllowRenderQueueSorting;
		}

		[Obsolete]
		private void SetAllowRenderQueueSorting(bool previous, bool current)
		{
			Surface.AllowRenderQueueSorting = current;
		}

		private Transform GetViewpoint()
		{
			if (MultipleViewpoints)
			{
				if (!(CurrentCamera == null))
				{
					return CurrentCamera.transform;
				}
				return null;
			}
			if (_Viewpoint != null)
			{
				return _Viewpoint;
			}
			Camera viewer = Viewer;
			if (viewer != null)
			{
				return viewer.transform;
			}
			return null;
		}

		internal Camera GetViewer(bool includeSceneCamera = true, bool initial = false)
		{
			if (!initial && MultipleViewpoints)
			{
				return CurrentCamera;
			}
			if (_Camera != null)
			{
				return _Camera;
			}
			return Camera.main;
		}

		private float GetWindSpeed()
		{
			if (WindSpeedOverriden)
			{
				return _WindSpeed;
			}
			return _WindZone.windMain * 3.6f;
		}

		private float GetWindDirection()
		{
			if (WindDirectionOverriden)
			{
				return _WindDirection;
			}
			return Mathf.Atan2(_WindZone.transform.forward.z, _WindZone.transform.forward.x) * 57.29578f;
		}

		private float GetWindTurbulence()
		{
			if (WindTurbulenceOverriden)
			{
				return _WindTurbulence;
			}
			return _WindZone.windTurbulence;
		}

		internal Matrix4x4 GetProjectionMatrix(int slice)
		{
			return _ProjectionMatrix[slice];
		}

		internal static Matrix4x4 CalculateViewMatrixFromSnappedPositionRHS(Vector3 snapped)
		{
			return Helpers.CalculateWorldToCameraMatrixRHS(snapped + Vector3.up * 10000f, Quaternion.AngleAxis(90f, Vector3.right));
		}

		private Light GetPrimaryLight()
		{
			if (!(_PrimaryLight == null))
			{
				return _PrimaryLight;
			}
			return RenderSettings.sun;
		}

		private bool GetWriteMotionVectors()
		{
			return _WriteMotionVectors;
		}

		private bool GetWriteToColorTexture()
		{
			if (!_WriteToColorTexture || !RenderBeforeTransparency)
			{
				return Meniscus.RequiresOpaqueTexture;
			}
			return true;
		}

		private bool GetWriteToDepthTexture()
		{
			if (_WriteToDepthTexture)
			{
				return Surface.Enabled;
			}
			return false;
		}

		internal static bool ShouldRender(Camera camera)
		{
			return true;
		}

		internal static bool ShouldRender(Camera camera, int layer)
		{
			if (!ShouldRender(camera))
			{
				return false;
			}
			if (!Helpers.MaskIncludesLayer(camera.cullingMask, layer))
			{
				return false;
			}
			return true;
		}

		internal static bool ShouldRender(Camera camera, WaterCameraExclusion exclusion)
		{
			if (camera.cameraType == CameraType.SceneView)
			{
				return true;
			}
			if (camera.TryGetComponent<WaterCamera>(out var component) && component.isActiveAndEnabled)
			{
				return true;
			}
			return (!exclusion.HasFlag(WaterCameraExclusion.Hidden) || !camera.hideFlags.HasFlag(HideFlags.HideInHierarchy) || camera.cameraType == CameraType.Reflection) && (!exclusion.HasFlag(WaterCameraExclusion.Reflection) || camera.cameraType != CameraType.Reflection) && (!exclusion.HasFlag(WaterCameraExclusion.NonMainCamera) || camera.CompareTag("MainCamera"));
		}

		internal static bool ShouldRender(Camera camera, int layer, WaterCameraExclusion exclusion)
		{
			if (!ShouldRender(camera, layer))
			{
				return false;
			}
			if (!ShouldRender(camera, exclusion))
			{
				return false;
			}
			return true;
		}

		private bool ShouldExecuteViewpoint(Camera camera, int layer, WaterCameraExclusion exclusion)
		{
			if (IsSingleViewpointMode)
			{
				_RenderShadows = true;
				return false;
			}
			if (!ShouldRender(camera, layer, exclusion))
			{
				return false;
			}
			return true;
		}

		public static Vector4 CalculateAbsorptionValueFromColor(Color color)
		{
			return UpdateAbsorptionFromColor(color);
		}

		internal static Vector4 UpdateAbsorptionFromColor(Color color)
		{
			Vector3 zero = Vector3.zero;
			zero.x = Mathf.Log(Mathf.Max(color.r, 0.0001f));
			zero.y = Mathf.Log(Mathf.Max(color.g, 0.0001f));
			zero.z = Mathf.Log(Mathf.Max(color.b, 0.0001f));
			return ((0f - color.a) * 32f * zero / 5f).XYZN(1f);
		}

		internal static void UpdateAbsorptionFromColor(Material material)
		{
			Color color = material.GetColor(ShaderIDs.s_AbsorptionColor);
			Vector3 zero = Vector3.zero;
			zero.x = Mathf.Log(Mathf.Max(color.r, 0.0001f));
			zero.y = Mathf.Log(Mathf.Max(color.g, 0.0001f));
			zero.z = Mathf.Log(Mathf.Max(color.b, 0.0001f));
			material.SetVector(ShaderIDs.s_Absorption, UpdateAbsorptionFromColor(color));
		}

		internal float MaximumWavelength(int slice, int resolution)
		{
			return MaximumWavelength(CalcLodScale(slice), resolution);
		}

		internal float MaximumWavelength(float scale, int resolution)
		{
			float num = 4f * scale / (float)resolution;
			float num2 = 2f;
			return 2f * num * num2;
		}

		internal float CalcLodScale(float slice)
		{
			return Scale * Mathf.Pow(2f, slice);
		}

		internal float CalcGridSize(int slice)
		{
			return CalcLodScale(slice) / (float)LodResolution;
		}

		private protected override void Initialize()
		{
			base.Initialize();
			_SetUpFor = RenderPipelineHelper.RenderPipeline;
			_IsFirstFrameSinceEnabled = true;
			CurrentCamera = GetViewer(includeSceneCamera: true, initial: true);
			if (_Mask == null)
			{
				_Initialized = false;
			}
			if (_Initialized)
			{
				Enable();
				return;
			}
			WaveHarmonic.Crest.Utility.RTHandles.Initialize();
			_Mask = MaskRenderer.Instantiate(this);
			Meniscus.Initialize(this);
			Surface._Water = this;
			_Reflections._Water = this;
			_Reflections._UnderWater = _Underwater;
			_Underwater._Water = this;
			_DepthLod._Water = this;
			_LevelLod._Water = this;
			_FlowLod._Water = this;
			_DynamicWavesLod._Water = this;
			_AnimatedWavesLod._Water = this;
			_FoamLod._Water = this;
			_ClipLod._Water = this;
			_AbsorptionLod._Water = this;
			_ScatteringLod._Water = this;
			_AlbedoLod._Water = this;
			_ShadowLod._Water = this;
			Simulations.Clear();
			Simulations.Add(_DepthLod);
			Simulations.Add(_LevelLod);
			Simulations.Add(_FlowLod);
			Simulations.Add(_DynamicWavesLod);
			Simulations.Add(_AnimatedWavesLod);
			Simulations.Add(_FoamLod);
			Simulations.Add(_AbsorptionLod);
			Simulations.Add(_ScatteringLod);
			Simulations.Add(_ClipLod);
			Simulations.Add(_AlbedoLod);
			Simulations.Add(_ShadowLod);
			TimeProviders.Clear();
			TimeProviders.Push(new DefaultTimeProvider());
			if (_TimeProvider != null)
			{
				TimeProviders.Push(_TimeProvider);
			}
			if (!VerifyRequirements())
			{
				base.enabled = false;
				return;
			}
			if (SimulationBuffer == null)
			{
				CommandBuffer obj = new CommandBuffer
				{
					name = "Crest.LodData"
				};
				CommandBuffer commandBuffer = obj;
				SimulationBuffer = obj;
			}
			Container = new GameObject
			{
				name = "Container",
				hideFlags = (_Debug._ShowHiddenObjects ? HideFlags.DontSave : HideFlags.HideAndDontSave)
			};
			Container.transform.SetParent(base.transform, worldPositionStays: false);
			Scale = Mathf.Clamp(Scale, _ScaleRange.x, _ScaleRange.y);
			foreach (Lod simulation in Simulations)
			{
				if (simulation._Enabled)
				{
					simulation.Initialize();
				}
			}
			_ProjectionMatrix = new Matrix4x4[LodLevels];
			CascadeData = (_CascadeData = InitializePerFrameMaterialParameters());
			if (Application.isPlaying && _Debug._AttachDebugGUI && !TryGetComponent<DebugGUI>(out var _))
			{
				base.gameObject.AddComponent<DebugGUI>().hideFlags = HideFlags.DontSave;
			}
			_GeneratedSettingsHash = CalculateSettingsHash();
			if (Surface.Enabled)
			{
				Surface.Initialize();
			}
			foreach (WaterBody waterBody in WaterBody.WaterBodies)
			{
				if (waterBody._Material != null)
				{
					Surface.UpdateMaterial(waterBody._Material, ref waterBody._MotionVectorMaterial);
				}
			}
			Enable();
			_Initialized = true;
		}

		private void OnDisable()
		{
			Disable();
			if (_Debug._DestroyResourcesInOnDisable || !Application.isPlaying)
			{
				Destroy();
			}
		}

		private void OnDestroy()
		{
			if (!_Debug._DestroyResourcesInOnDisable && Application.isPlaying)
			{
				Destroy();
			}
		}

		private protected override void Enable()
		{
			base.Enable();
			if (!IsSingleViewpointMode && !RunningWithoutGraphics)
			{
				_EndOfFrame = StartCoroutine(UpdateSkippedCameras());
			}
			RenderPipelineManager.activeRenderPipelineTypeChanged -= OnActiveRenderPipelineTypeChanged;
			RenderPipelineManager.activeRenderPipelineTypeChanged += OnActiveRenderPipelineTypeChanged;
			foreach (Lod simulation in Simulations)
			{
				simulation.SetGlobals(enable: true);
				if (simulation.Enabled)
				{
					simulation.Enable();
				}
			}
			if (!IsRunningWithoutGraphics)
			{
				ShiftingOrigin.OnShift = (Action<Vector3>)Delegate.Remove(ShiftingOrigin.OnShift, new Action<Vector3>(OnOriginShift));
				ShiftingOrigin.OnShift = (Action<Vector3>)Delegate.Combine(ShiftingOrigin.OnShift, new Action<Vector3>(OnOriginShift));
				if (RenderPipelineHelper.IsLegacy)
				{
					Camera.onPreCull = (Camera.CameraCallback)Delegate.Remove(Camera.onPreCull, new Camera.CameraCallback(OnBeginCameraRendering));
					Camera.onPreCull = (Camera.CameraCallback)Delegate.Combine(Camera.onPreCull, new Camera.CameraCallback(OnBeginCameraRendering));
					Camera.onPostRender = (Camera.CameraCallback)Delegate.Remove(Camera.onPostRender, new Camera.CameraCallback(OnEndCameraRendering));
					Camera.onPostRender = (Camera.CameraCallback)Delegate.Combine(Camera.onPostRender, new Camera.CameraCallback(OnEndCameraRendering));
				}
				else
				{
					RenderPipelineManager.beginCameraRendering -= OnBeginCameraRendering;
					RenderPipelineManager.beginCameraRendering += OnBeginCameraRendering;
					RenderPipelineManager.endCameraRendering -= OnEndCameraRendering;
					RenderPipelineManager.endCameraRendering += OnEndCameraRendering;
				}
				if (RenderPipelineHelper.IsUniversal)
				{
					SurfaceRenderer.WaterSurfaceRenderPass.Enable(this);
				}
				Container.SetActive(value: true);
				_Mask.Enable();
				if (_Underwater._Enabled)
				{
					_Underwater.OnEnable();
				}
				if (Meniscus.Enabled)
				{
					Meniscus.Enable();
				}
				if (RenderPipelineHelper.IsUniversal && (WriteToColorTexture || WriteToDepthTexture))
				{
					CopyTargetsRenderPass.Enable(this);
				}
				if (_Reflections._Enabled)
				{
					_Reflections.OnEnable();
				}
			}
		}

		private void OnBeginCameraRendering(Camera camera)
		{
			if (_SetUpFor == RenderPipelineHelper.RenderPipeline && _Initialized)
			{
				WaveHarmonic.Crest.Utility.RTHandles.OnBeginCameraRendering(camera);
				OnBeginCameraRendering(_Context, camera);
			}
		}

		private void OnBeginCameraRendering(ScriptableRenderContext context, Camera camera)
		{
			if (_SetUpFor != RenderPipelineHelper.RenderPipeline || !_Initialized || !ShouldRender(camera))
			{
				return;
			}
			_RecursiveActiveModules.Push(_ActiveModules);
			_ActiveModules = ActiveModules.Nothing;
			if (Surface.ShouldRender(camera))
			{
				_ActiveModules |= ActiveModules.Surface;
			}
			if (Underwater.ShouldRender(camera))
			{
				_ActiveModules |= ActiveModules.Volume;
			}
			else
			{
				_ActiveModules &= ~ActiveModules.Portal;
			}
			bool flag = !_ActiveModules.HasFlag(ActiveModules.Surface);
			bool flag2 = !_ActiveModules.HasFlag(ActiveModules.Volume);
			if ((!flag || !flag2) && GetViewer(includeSceneCamera: true, initial: true) == null)
			{
				flag = (flag2 = true);
			}
			if (flag)
			{
				Surface.ForceRenderingOff = true;
			}
			if (flag && flag2)
			{
				return;
			}
			if (Meniscus.ShouldRender(camera))
			{
				_ActiveModules |= ActiveModules.Meniscus;
			}
			if (Reflections.ShouldRender(camera))
			{
				_ActiveModules |= ActiveModules.Reflections;
			}
			if (_Mask.ShouldExecute(camera))
			{
				_ActiveModules |= ActiveModules.Mask;
			}
			if (ShadowLod.ShouldRender(camera))
			{
				_ActiveModules |= ActiveModules.Shadows;
			}
			_HasAnyViewerRendered = true;
			if (ShouldExecuteViewpoint(camera, Surface.Layer, _CameraExclusions))
			{
				int num = -1;
				if (_PerCameraLastFrame.ContainsKey(camera))
				{
					num = _PerCameraLastFrame[camera];
				}
				else
				{
					_PerCameraLastFrame.Add(camera, num);
				}
				if (num != Time.frameCount)
				{
					if (!_Cameras.Contains(camera))
					{
						_Cameras.Add(camera);
					}
					ExecuteViewpoint(camera);
					_PerCameraLastFrame[camera] = Time.frameCount;
				}
				_RenderShadows = true;
			}
			Shader.SetGlobalVector(ShaderIDs.s_HorizonNormal, new Vector2(Vector3.Dot(Vector3.up, camera.transform.right), Vector3.Dot(Vector3.up, camera.transform.up)));
			if (_ActiveModules.HasFlag(ActiveModules.Reflections))
			{
				_Reflections.OnBeginCameraRendering(context, camera);
			}
			if (_ActiveModules.HasFlag(ActiveModules.Volume))
			{
				Underwater.ExecuteHeightField(camera);
			}
			if (_ActiveModules.HasFlag(ActiveModules.Mask))
			{
				_Mask.OnBeginCameraRendering(camera);
			}
			ExecuteLighting(context, camera);
			if (_ActiveModules.HasFlag(ActiveModules.Volume))
			{
				Underwater.OnBeginCameraRendering(context, camera);
			}
			if (_ActiveModules.HasFlag(ActiveModules.Surface))
			{
				Surface.OnBeginCameraRendering(context, camera);
			}
			UpdateRenderPipelineTextures(context, camera);
			if (_ActiveModules.HasFlag(ActiveModules.Meniscus))
			{
				Meniscus.Renderer.OnBeginCameraRendering(camera);
			}
			if (_ActiveModules.HasFlag(ActiveModules.Shadows) && _RenderShadows)
			{
				ShadowLod.OnBeginCameraRendering(context, camera);
			}
		}

		private void UpdateRenderPipelineTextures(ScriptableRenderContext context, Camera camera)
		{
			if (_ActiveModules.HasFlag(ActiveModules.Surface))
			{
				if (RenderPipelineHelper.IsUniversal)
				{
					CopyTargetsRenderPass.Instance?.OnBeginCameraRendering(context, camera);
				}
				else if (RenderPipelineHelper.IsLegacy)
				{
					OnLegacyCopyPass(camera);
				}
			}
		}

		private void OnEndCameraRendering(Camera camera)
		{
			OnEndCameraRendering(_Context, camera);
		}

		private void OnEndCameraRendering(ScriptableRenderContext context, Camera camera)
		{
			_DonePerCameraHeight = false;
			_PerCameraHeightReady = false;
			if (Reflections.ReflectionCamera != camera)
			{
				Surface.ForceRenderingOff = false;
			}
			if (RenderPipelineHelper.IsLegacy)
			{
				OnEndCameraRenderingLegacy(camera);
			}
			if (_ActiveModules.HasFlag(ActiveModules.Mask))
			{
				_Mask.OnEndCameraRendering(camera);
			}
			if (_ActiveModules.HasFlag(ActiveModules.Meniscus))
			{
				Meniscus.Renderer.OnEndCameraRendering(camera);
			}
			if (_ActiveModules.HasFlag(ActiveModules.Volume))
			{
				Underwater.OnEndCameraRendering(camera);
			}
			if (_ActiveModules.HasFlag(ActiveModules.Surface))
			{
				Surface.OnEndCameraRendering(camera);
			}
			if (_ActiveModules.HasFlag(ActiveModules.Reflections))
			{
				_Reflections.OnEndCameraRendering(camera);
			}
			if (_ActiveModules.HasFlag(ActiveModules.Shadows) && _RenderShadows)
			{
				_ShadowLod.OnEndCameraRendering(camera);
			}
			_Reflections.OnEndReflectionCameraRendering(camera);
			if (camera == CurrentCamera)
			{
				IsSeparateViewpointCameraLoop = false;
				CurrentCamera = null;
				_RenderShadows = false;
			}
			_RecursiveActiveModules.TryPop(out _ActiveModules);
		}

		internal void UpdatePerCameraHeight(Camera camera)
		{
			if (!_DonePerCameraHeight)
			{
				Vector3 position = camera.transform.position;
				_PerCameraHeightReady |= _SampleHeightHelperPerCamera.SampleHeight(HashCode.Combine(_SampleHeightHelperPerCamera, camera), position, out var height, CollisionLayer.Everything, 0f, allowMultipleCallsPerFrame: true);
				_ViewerHeightAboveWaterPerCamera = position.y - height;
				if (camera == Reflections.ReflectionCamera)
				{
					_ViewerHeightAboveWaterPerCamera = 0f - _ViewerHeightAboveWaterPerCamera;
				}
				_DonePerCameraHeight = true;
			}
		}

		private void OnActiveRenderPipelineTypeChanged()
		{
			_Mask?.Destroy();
			_Mask = MaskRenderer.Instantiate(this);
			Meniscus.OnActiveRenderPipelineTypeChanged();
			if (base.isActiveAndEnabled)
			{
				Disable();
				Destroy();
				Initialize();
			}
		}

		internal void Rebuild()
		{
			Disable();
			Destroy();
			OnEnable();
		}

		private bool VerifyRequirements()
		{
			if (!RunningWithoutGraphics)
			{
				if (Application.platform == RuntimePlatform.WebGLPlayer && !Helpers.IsWebGPU)
				{
					UnityEngine.Debug.LogError("Crest: Crest does not support WebGL backends.", this);
					return false;
				}
				if (SystemInfo.graphicsShaderLevel < 45)
				{
					UnityEngine.Debug.LogError("Crest: Crest requires graphics devices that support shader level 4.5 or above.", this);
					return false;
				}
				if (!SystemInfo.supportsComputeShaders)
				{
					UnityEngine.Debug.LogError("Crest: Crest requires graphics devices that support compute shaders.", this);
					return false;
				}
				if (!SystemInfo.supports2DArrayTextures)
				{
					UnityEngine.Debug.LogError("Crest: Crest requires graphics devices that support 2D array textures.", this);
					return false;
				}
			}
			return true;
		}

		private int CalculateSettingsHash()
		{
			int hash = Hash.CreateHash();
			Hash.AddInt(_Resolution, ref hash);
			Hash.AddInt(_Slices, ref hash);
			Hash.AddBool(WriteMotionVectors, ref hash);
			Hash.AddBool(_Debug._ForceNoGraphics, ref hash);
			Hash.AddBool(_Debug._ShowHiddenObjects, ref hash);
			return hash;
		}

		private protected override void LateUpdate()
		{
			if (CalculateSettingsHash() != _GeneratedSettingsHash)
			{
				Rebuild();
			}
			if (RunningWithoutGraphics)
			{
				BroadcastUpdate();
				Position = new Vector3(0f, base.transform.position.y, 0f);
			}
			else
			{
				BroadcastUpdate();
				if (IsSingleViewpointMode)
				{
					ExecuteViewpoint(Viewer);
				}
				else
				{
					if (FallBackRequired)
					{
						ExecuteViewpoint(GetViewer(includeSceneCamera: true, initial: true));
					}
					PruneCameraData();
					_HasAnyViewpointExecuted = false;
					_HasAnyViewerRendered = false;
				}
			}
			base.LateUpdate();
			if (AnimatedWavesLod.QuerySource == LodQuerySource.CPU)
			{
				AnimatedWavesLod.Provider?.UpdateQueries(this);
			}
		}

		private void ExecuteViewpoint(Camera camera)
		{
			if (camera == _Reflections.ReflectionCamera)
			{
				return;
			}
			CurrentCamera = camera;
			LoadCameraData(camera);
			if (!_Debug._DisableFollowViewpoint && CurrentCamera != null)
			{
				LateUpdatePosition();
				LateUpdateViewerHeight();
				LateUpdateScale();
			}
			else
			{
				Position = new Vector3(0f, base.transform.position.y, 0f);
			}
			Shader.SetGlobalFloat(ShaderIDs.s_Time, CurrentTime);
			Shader.SetGlobalInteger(ShaderIDs.s_LodCount, LodLevels);
			SimulationBuffer.Clear();
			WritePerFrameMaterialParams(SimulationBuffer);
			s_OnBeforeBuildCommandBuffer?.Invoke(this, camera);
			foreach (Lod simulation in Simulations)
			{
				if (simulation.Enabled && (!_IsEndOfFrame || !simulation.SkipEndOfFrame))
				{
					simulation.BuildCommandBuffer(this, SimulationBuffer);
				}
			}
			Graphics.ExecuteCommandBuffer(SimulationBuffer);
			foreach (Lod simulation2 in Simulations)
			{
				if (simulation2.Enabled && (!_IsEndOfFrame || !simulation2.SkipEndOfFrame))
				{
					simulation2.AfterExecute();
				}
			}
			if (Surface.Enabled)
			{
				Surface.LateUpdate();
			}
			if (_Reflections._Enabled)
			{
				_Reflections.LateUpdate();
			}
			_IsFirstFrameSinceEnabled = false;
			_HasAnyViewpointExecuted = true;
			StoreCameraData(camera);
		}

		private BufferedData<Vector4[]> InitializePerFrameMaterialParameters()
		{
			BufferedData<Vector4[]> bufferedData = new BufferedData<Vector4[]>(BufferSize, () => new Vector4[16]);
			for (int num = bufferedData.Size - 1; num >= 0; num--)
			{
				UpdatePerFrameMaterialParameters(bufferedData.Previous(num));
			}
			return bufferedData;
		}

		private void UpdatePerFrameMaterialParameters(Vector4[] current)
		{
			int lodLevels = LodLevels;
			for (int i = 0; i < lodLevels; i++)
			{
				float num = CalcLodScale(i);
				current[i] = new Vector4(num, 1f, MaximumWavelength(num, DynamicWavesLod.Resolution), 0f);
				_ProjectionMatrix[i] = Matrix4x4.Ortho(-2f * num, 2f * num, -2f * num, 2f * num, 1f, 20000f);
			}
			current[lodLevels] = current[lodLevels - 1].XNZW(0f);
		}

		private void WritePerFrameMaterialParams(CommandBuffer commands)
		{
			CascadeData.Flip();
			Vector4[] current = CascadeData.Current;
			UpdatePerFrameMaterialParameters(current);
			commands.SetGlobalFloat(ShaderIDs.s_Scale, current[0].x);
			current[LodLevels] = current[LodLevels - 1].XNZW(0f);
			commands.SetGlobalVectorArray(ShaderIDs.s_CascadeData, current);
			commands.SetGlobalVectorArray(ShaderIDs.s_CascadeDataSource, CascadeData.Previous(1));
		}

		private void LateUpdatePosition()
		{
			Vector3 vector = Viewpoint.position;
			int id = HashCode.Combine(_CenterOfDetailDisplacementCorrectionHelper, Viewpoint);
			if (_CenterOfDetailDisplacementCorrection && _CenterOfDetailDisplacementCorrectionHelper.SampleDisplacement(id, vector, out var displacement, CollisionLayer.Everything, 0f, allowMultipleCallsPerFrame: true))
			{
				vector = new Vector3(vector.x - displacement.x, vector.y, vector.z - displacement.z);
			}
			vector.y = base.transform.position.y;
			if (Mathf.Abs(vector.x * 60f - Mathf.Round(vector.x * 60f)) < 0.001f)
			{
				vector.x += 0.002f;
			}
			if (Mathf.Abs(vector.z * 60f - Mathf.Round(vector.z * 60f)) < 0.001f)
			{
				vector.z += 0.002f;
			}
			Shader.SetGlobalVector(ShaderIDs.s_CenterDelta, (vector - Position).XZ());
			Position = vector;
			Shader.SetGlobalVector(ShaderIDs.s_Center, Position);
		}

		private void LateUpdateScale()
		{
			float viewpointHeightAboveWaterSmooth = _ViewpointHeightAboveWaterSmooth;
			float num = 0f;
			foreach (var (_, lodInput2) in AnimatedWavesLod.s_Inputs)
			{
				if (lodInput2.WaveDisplacementReporter != null)
				{
					num = lodInput2.WaveDisplacementReporter.ReportWaveDisplacement(this, num);
				}
			}
			viewpointHeightAboveWaterSmooth += num * _DropDetailHeightBasedOnWaves;
			Shader.SetGlobalFloat(ShaderIDs.s_MaximumVerticalDisplacement, num);
			float num3 = Mathf.Max(Mathf.Abs(viewpointHeightAboveWaterSmooth) - 4f, 0f);
			Vector2 scaleRange = _ScaleRange;
			float a = num3;
			a = Mathf.Max(a, scaleRange.x);
			if (scaleRange.y < float.PositiveInfinity)
			{
				a = Mathf.Min(a, 1.99f * scaleRange.y);
			}
			float num4 = Mathf.Log(a) / Mathf.Log(2f);
			float num5 = Mathf.Floor(num4);
			ViewerAltitudeLevelAlpha = num4 - num5;
			float num6 = Mathf.Pow(2f, num5);
			if (Scale > 0f)
			{
				float num7 = num6 / Scale;
				float f = Mathf.Log(num7) / Mathf.Log(2f);
				ScaleDifferencePower2 = Mathf.RoundToInt(f);
				Shader.SetGlobalFloat(ShaderIDs.s_LodChange, ScaleDifferencePower2);
				Shader.SetGlobalFloat(ShaderIDs.s_ScaleChange, num7);
			}
			Scale = num6;
			Shader.SetGlobalFloat(ShaderIDs.s_MeshScaleLerp, ScaleCouldIncrease ? ViewerAltitudeLevelAlpha : 0f);
		}

		private void LateUpdateViewerHeight()
		{
			Transform viewpoint = Viewpoint;
			int id = HashCode.Combine(_SampleHeightHelper, viewpoint);
			_SampleHeightHelper.SampleHeight(id, viewpoint.position, out var height, CollisionLayer.Everything, 0f, allowMultipleCallsPerFrame: true);
			float viewerHeightAboveWater = (ViewpointHeightAboveWater = viewpoint.position.y - height);
			ViewerHeightAboveWater = viewerHeightAboveWater;
			float num2 = ViewpointHeightAboveWater;
			if (viewpoint != CurrentCamera.transform)
			{
				Transform transform = CurrentCamera.transform;
				_SampleHeightHelper.SampleHeight(HashCode.Combine(_SampleHeightHelper, transform), viewpoint.position, out height, CollisionLayer.Everything, 0f, allowMultipleCallsPerFrame: true);
				ViewerHeightAboveWater = transform.position.y - height;
			}
			if (_SampleTerrainHeightForScale && LevelLod.Enabled && _Viewpoint == null)
			{
				Vector3 position = viewpoint.position;
				float y = position.y;
				float num3 = float.PositiveInfinity;
				Terrain terrainAtPosition = Helpers.GetTerrainAtPosition(position.XZ());
				if (terrainAtPosition != null)
				{
					float num4 = terrainAtPosition.GetPosition().y + terrainAtPosition.SampleHeight(position);
					float num5 = y - num4;
					if (num5 >= 0f)
					{
						num3 = num5;
					}
				}
				if (num3 < Mathf.Abs(num2))
				{
					num2 = num3;
				}
			}
			if (_TeleportTimerForHeightQueries > 0f)
			{
				_TeleportTimerForHeightQueries -= Time.deltaTime;
			}
			bool flag = _IsFirstFrameSinceEnabled;
			if (!_IsFirstFrameSinceEnabled)
			{
				float sqrMagnitude = (_OldViewpointPosition - viewpoint.position - TeleportOriginThisFrame).sqrMagnitude;
				float num6 = _TeleportThreshold * _TeleportThreshold;
				flag = sqrMagnitude > num6;
			}
			if (flag)
			{
				_TeleportTimerForHeightQueries = 1f;
			}
			_HasTeleportedThisFrame = flag;
			_OldViewpointPosition = viewpoint.position;
			_ViewpointHeightAboveWaterSmooth = Mathf.Lerp(_ViewpointHeightAboveWaterSmooth, num2, (_TeleportTimerForHeightQueries > 0f || (!_ForceScaleChangeSmoothing && (!LevelLod.Enabled || _SampleTerrainHeightForScale))) ? 1f : 0.01f);
			_SampleDepthHelper.Sample(HashCode.Combine(_SampleDepthHelper, CurrentCamera), CurrentCamera.transform.position, out var result, allowMultipleCallsPerFrame: true);
			ViewerDistanceToShoreline = result.y;
			Shader.SetGlobalFloat(ShaderIDs.s_WaterDepthAtViewer, result.x);
		}

		private void Destroy()
		{
			foreach (Lod simulation in Simulations)
			{
				if (simulation.Enabled)
				{
					simulation.Destroy();
				}
			}
			Simulations.Clear();
			_Mask?.Destroy();
			Meniscus.Destroy();
			_Underwater.OnDestroy();
			_Reflections.OnDestroy();
			Surface.OnDestroy();
			if ((bool)Container)
			{
				Helpers.Destroy(Container);
				Container = null;
			}
			_Cameras.Clear();
			_PerCameraData.Clear();
			_Initialized = false;
		}

		private protected override void Disable()
		{
			if (_EndOfFrame != null)
			{
				StopCoroutine(_EndOfFrame);
			}
			foreach (Lod simulation in Simulations)
			{
				simulation.SetGlobals(enable: false);
				if (simulation.Enabled)
				{
					simulation.Disable();
				}
			}
			if (RenderPipelineHelper.IsLegacy && Viewer != null)
			{
				OnEndCameraRenderingLegacy(Viewer);
			}
			Camera.onPreCull = (Camera.CameraCallback)Delegate.Remove(Camera.onPreCull, new Camera.CameraCallback(OnBeginCameraRendering));
			Camera.onPostRender = (Camera.CameraCallback)Delegate.Remove(Camera.onPostRender, new Camera.CameraCallback(OnEndCameraRendering));
			ShiftingOrigin.OnShift = (Action<Vector3>)Delegate.Remove(ShiftingOrigin.OnShift, new Action<Vector3>(OnOriginShift));
			RenderPipelineManager.beginCameraRendering -= OnBeginCameraRendering;
			RenderPipelineManager.endCameraRendering -= OnEndCameraRendering;
			RenderPipelineManager.activeRenderPipelineTypeChanged -= OnActiveRenderPipelineTypeChanged;
			_Mask?.Disable();
			if (_Underwater._Enabled)
			{
				_Underwater.OnDisable();
			}
			if (_Reflections._Enabled)
			{
				_Reflections.OnDisable();
			}
			if (Meniscus.Enabled)
			{
				Meniscus.Disable();
			}
			if (Container != null)
			{
				Container.SetActive(value: false);
			}
			base.Disable();
		}

		private void OnOriginShift(Vector3 newOrigin)
		{
			foreach (Lod simulation in Simulations)
			{
				if (simulation.Enabled)
				{
					simulation.SetOrigin(newOrigin);
				}
			}
		}

		private bool ShouldExecuteSkippedFrame(Camera camera)
		{
			if (!MultipleViewpoints)
			{
				return false;
			}
			if (_DataBackgroundMode == WaterDataBackgroundMode.Never)
			{
				return false;
			}
			if (camera.cameraType == CameraType.SceneView)
			{
				return true;
			}
			if (_DataBackgroundMode == WaterDataBackgroundMode.Always)
			{
				return true;
			}
			if (_DataBackgroundMode == WaterDataBackgroundMode.Inactive && camera.isActiveAndEnabled)
			{
				return true;
			}
			if (_DataBackgroundMode == WaterDataBackgroundMode.Disabled && !camera.enabled)
			{
				return true;
			}
			return false;
		}

		internal bool ShouldExecuteQueries(Camera camera)
		{
			if (camera != null && _PerCameraData.ContainsKey(camera))
			{
				return _PerCameraData[camera]._ExecutedThisFrame;
			}
			return false;
		}

		private IEnumerator UpdateSkippedCameras()
		{
			while (true)
			{
				yield return Helpers.WaitForEndOfFrame;
				if (IsSingleViewpointMode)
				{
					continue;
				}
				_IsEndOfFrame = true;
				foreach (Camera camera in _Cameras)
				{
					if (!(camera == null) && _PerCameraData.ContainsKey(camera))
					{
						PerCameraData perCameraData = _PerCameraData[camera];
						perCameraData._ExecutedThisFrame = perCameraData._RenderedThisFrame;
						if (!perCameraData._RenderedThisFrame && ShouldExecuteSkippedFrame(camera))
						{
							ExecuteViewpoint(camera);
						}
						perCameraData._RenderedThisFrame = false;
					}
				}
				_IsEndOfFrame = false;
			}
		}

		private void LoadCameraData(Camera camera)
		{
			if (IsSingleViewpointMode || camera == null)
			{
				return;
			}
			if (!_PerCameraData.ContainsKey(camera))
			{
				_PerCameraData.Add(camera, new PerCameraData
				{
					_CascadeData = InitializePerFrameMaterialParameters()
				});
			}
			_CurrentPerCameraData = _PerCameraData[camera];
			CascadeData = _CurrentPerCameraData._CascadeData;
			Scale = _CurrentPerCameraData._Scale;
			Position = _CurrentPerCameraData._Position;
			_OldViewpointPosition = _CurrentPerCameraData._OldViewpointPosition;
			_ViewpointHeightAboveWaterSmooth = _CurrentPerCameraData._ViewpointHeightAboveWaterSmooth;
			_IsFirstFrameSinceEnabled = _CurrentPerCameraData._IsFirstFrameSinceEnabled;
			foreach (Lod simulation in Simulations)
			{
				if (simulation.Enabled)
				{
					simulation.LoadCameraData(camera);
				}
			}
			_CurrentPerCameraData._RenderedThisFrame = true;
			_CurrentPerCameraData._ExecutedThisFrame = true;
			IsSeparateViewpointCameraLoop = true;
			s_OnLoadCameraData?.Invoke(camera);
		}

		private void StoreCameraData(Camera camera)
		{
			if (IsSingleViewpointMode)
			{
				return;
			}
			_CurrentPerCameraData._Scale = Scale;
			_CurrentPerCameraData._Position = Position;
			_CurrentPerCameraData._OldViewpointPosition = _OldViewpointPosition;
			_CurrentPerCameraData._ViewpointHeightAboveWaterSmooth = _ViewpointHeightAboveWaterSmooth;
			_CurrentPerCameraData._IsFirstFrameSinceEnabled = _IsFirstFrameSinceEnabled;
			_CurrentPerCameraData._ViewerHeightAboveWater = ViewerHeightAboveWater;
			_CurrentPerCameraData._ViewerDistanceToShoreline = ViewerDistanceToShoreline;
			foreach (Lod simulation in Simulations)
			{
				if (simulation.Enabled)
				{
					simulation.StoreCameraData(camera);
				}
			}
			s_OnStoreCameraData?.Invoke(camera);
		}

		private void RemoveCameraData(Camera camera)
		{
			Surface.RemoveCameraData(camera);
			foreach (Lod simulation in Simulations)
			{
				simulation.RemoveCameraData(camera);
			}
			if (_PerCameraData.ContainsKey(camera))
			{
				_PerCameraData.Remove(camera);
			}
			s_OnRemoveCameraData?.Invoke(camera);
		}

		private void PruneCameraData()
		{
			for (int num = _Cameras.Count - 1; num >= 0; num--)
			{
				Camera camera = _Cameras[num];
				if ((camera == null || !ShouldRender(camera, Surface._Layer, _CameraExclusions) || !_PerCameraData[camera]._ExecutedThisFrame) && (!FallBackRequired || !(GetViewer(includeSceneCamera: true, initial: true) == camera)))
				{
					RemoveCameraData(camera);
					_Cameras.RemoveAt(num);
				}
			}
			if (_Cameras.Count <= 0)
			{
				CascadeData = _CascadeData;
			}
		}

		internal bool GetViewerHeightAboveWater(Camera camera, out float height)
		{
			height = SeaLevel;
			if (!IsMultipleViewpointMode)
			{
				height = ViewerHeightAboveWater;
				return true;
			}
			if (!_PerCameraData.ContainsKey(camera))
			{
				return false;
			}
			height = _PerCameraData[camera]._ViewerHeightAboveWater;
			return true;
		}

		internal bool GetViewerDistanceToShoreline(Camera camera, out float distance)
		{
			distance = SeaLevel;
			if (!IsMultipleViewpointMode)
			{
				distance = ViewerDistanceToShoreline;
				return true;
			}
			if (!_PerCameraData.ContainsKey(camera))
			{
				return false;
			}
			distance = _PerCameraData[camera]._ViewerDistanceToShoreline;
			return true;
		}

		internal Transform GetClosestViewpoint(Vector3 position)
		{
			if (!IsMultipleViewpointMode)
			{
				return Viewpoint;
			}
			float num = float.PositiveInfinity;
			Camera camera = null;
			foreach (Camera camera2 in _Cameras)
			{
				if (!(camera2 == null))
				{
					float num2 = Mathf.Abs((camera2.transform.position - position).sqrMagnitude);
					if (num2 < num)
					{
						camera = camera2;
						num = num2;
					}
				}
			}
			if (camera == null)
			{
				return null;
			}
			return camera.transform;
		}

		internal bool IsClosestViewpoint(Vector3 position)
		{
			if (!IsMultipleViewpointMode)
			{
				return true;
			}
			return Viewpoint == GetClosestViewpoint(position);
		}

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
		private static void InitializeOnLoad()
		{
			Shader.SetGlobalTexture(WaveHarmonic.Crest.ShaderIDs.Unity.s_ShadowMapTexture, Texture2D.whiteTexture);
		}

		internal void UpdateMatrices(Camera camera)
		{
			if (!_DoneMatrices)
			{
				Rendering.BIRP.SetMatrices(camera);
				_DoneMatrices = true;
			}
		}

		private void OnBeginCameraRenderingLegacy(Camera camera)
		{
			if (!(PrimaryLight == null))
			{
				if (_ScreenSpaceShadowMapBuffer == null)
				{
					_ScreenSpaceShadowMapBuffer = new CommandBuffer
					{
						name = "Crest.CausticsOcclusion"
					};
				}
				_ScreenSpaceShadowMapBuffer.Clear();
				_ScreenSpaceShadowMapBuffer.SetGlobalTexture(ShaderIDs.s_ScreenSpaceShadowTexture, BuiltinRenderTextureType.CurrentActive);
				PrimaryLight.AddCommandBuffer(LightEvent.AfterScreenspaceMask, _ScreenSpaceShadowMapBuffer);
				Shader.SetGlobalTexture(ShaderIDs.s_ScreenSpaceShadowTexture, Rendering.BIRP.GetWhiteTexture(camera));
				Helpers.SetGlobalBoolean(ShaderIDs.s_PrimaryLightHasCookie, PrimaryLight.cookie != null);
			}
		}

		private void OnEndCameraRenderingLegacy(Camera camera)
		{
			_DoneMatrices = false;
			_DoneCameraOpaqueTexture = false;
			if (_UpdateColorDepthTexturesBuffer != null)
			{
				camera.RemoveCommandBuffer(RenderBeforeTransparency ? CameraEvent.BeforeForwardAlpha : CameraEvent.AfterForwardAlpha, _UpdateColorDepthTexturesBuffer);
			}
			if (QualitySettings.shadows != UnityEngine.ShadowQuality.Disable && PrimaryLight != null && _ScreenSpaceShadowMapBuffer != null)
			{
				PrimaryLight.RemoveCommandBuffer(LightEvent.AfterScreenspaceMask, _ScreenSpaceShadowMapBuffer);
			}
			Shader.SetGlobalTexture(WaveHarmonic.Crest.ShaderIDs.Unity.s_CameraOpaqueTexture, Texture2D.grayTexture);
		}

		[Conditional("UNITY_2022_3_OR_NEWER")]
		private void OnLegacyCopyPass(Camera camera)
		{
			if (SurfaceRenderer.IsTransparent(Surface.Material))
			{
				if (_UpdateColorDepthTexturesBuffer == null)
				{
					_UpdateColorDepthTexturesBuffer = new CommandBuffer
					{
						name = "Crest.DrawWater"
					};
				}
				_UpdateColorDepthTexturesBuffer.Clear();
				CommandBuffer updateColorDepthTexturesBuffer = _UpdateColorDepthTexturesBuffer;
				if (WriteToColorTexture)
				{
					UpdateCameraOpaqueTexture(camera, updateColorDepthTexturesBuffer);
				}
				if (WriteToDepthTexture && Shader.GetGlobalTexture(WaveHarmonic.Crest.ShaderIDs.Unity.s_CameraDepthTexture) is RenderTexture renderTexture)
				{
					updateColorDepthTexturesBuffer.BeginSample("CopyDepth");
					RenderTargetIdentifier target = new RenderTargetIdentifier(renderTexture, 0, CubemapFace.Unknown, -1);
					int s_TemporaryDepthTexture = ShaderIDs.s_TemporaryDepthTexture;
					updateColorDepthTexturesBuffer.GetTemporaryRT(s_TemporaryDepthTexture, renderTexture.descriptor);
					CoreUtils.SetRenderTarget(updateColorDepthTexturesBuffer, s_TemporaryDepthTexture, ClearFlag.Depth);
					Surface.Render(camera, updateColorDepthTexturesBuffer, null, Surface.Material.FindPass("DepthOnly"), culled: true);
					updateColorDepthTexturesBuffer.SetGlobalTexture(Helpers.ShaderIDs.s_MainTexture, s_TemporaryDepthTexture);
					Helpers.Blit(updateColorDepthTexturesBuffer, target, Rendering.BIRP.UtilityMaterial, 2);
					updateColorDepthTexturesBuffer.ReleaseTemporaryRT(s_TemporaryDepthTexture);
					updateColorDepthTexturesBuffer.EndSample("CopyDepth");
				}
				if (WriteToColorTexture || WriteToDepthTexture)
				{
					camera.AddCommandBuffer(RenderBeforeTransparency ? CameraEvent.BeforeForwardAlpha : CameraEvent.AfterForwardAlpha, updateColorDepthTexturesBuffer);
				}
			}
		}

		internal void UpdateCameraOpaqueTexture(Camera camera, CommandBuffer commands)
		{
			commands.BeginSample("CopyColor");
			commands.Blit(dest: new RenderTargetIdentifier(_CameraOpaqueTexture, 0, CubemapFace.Unknown, -1), source: BuiltinRenderTextureType.CameraTarget);
			commands.EndSample("CopyColor");
		}

		[Conditional("UNITY_2022_3_OR_NEWER")]
		internal void OnBeginCameraOpaqueTexture(Camera camera)
		{
			if (_DoneCameraOpaqueTexture)
			{
				return;
			}
			camera.depthTextureMode |= DepthTextureMode.Depth;
			RenderTextureDescriptor descriptor = Rendering.BIRP.GetCameraTargetDescriptor(camera, FrameBufferFormatOverride);
			descriptor.depthStencilFormat = GraphicsFormat.None;
			if (descriptor.width > 0)
			{
				RenderPipelineCompatibilityHelper.ReAllocateIfNeeded(ref _CameraOpaqueTexture, in descriptor);
				if (_CameraOpaqueTextureCommands == null)
				{
					_CameraOpaqueTextureCommands = new CommandBuffer
					{
						name = "Crest.DrawWater"
					};
				}
				_CameraOpaqueTextureCommands.Clear();
				_CameraOpaqueTextureCommands.SetGlobalTexture(WaveHarmonic.Crest.ShaderIDs.Unity.s_CameraOpaqueTexture, _CameraOpaqueTexture);
				UpdateCameraOpaqueTexture(camera, _CameraOpaqueTextureCommands);
				camera.AddCommandBuffer(CameraEvent.BeforeForwardAlpha, _CameraOpaqueTextureCommands);
				_DoneCameraOpaqueTexture = true;
			}
		}

		internal void OnEndCameraOpaqueTexture(Camera camera)
		{
			if (_CameraOpaqueTextureCommands != null)
			{
				camera.RemoveCommandBuffer(CameraEvent.BeforeForwardAlpha, _CameraOpaqueTextureCommands);
			}
		}

		private void ExecuteLighting(ScriptableRenderContext context, Camera camera)
		{
			Light primaryLight = PrimaryLight;
			bool flag = primaryLight != null && primaryLight.isActiveAndEnabled && (RenderPipelineHelper.IsHighDefinition || primaryLight.bakingOutput.isBaked);
			Helpers.SetGlobalBoolean(ShaderIDs.s_PrimaryLightFallback, flag);
			if (flag)
			{
				Vector3 vector = -primaryLight.transform.forward;
				Color clear = Color.clear;
				bool lightsUseLinearIntensity = GraphicsSettings.lightsUseLinearIntensity;
				Color color = (lightsUseLinearIntensity ? primaryLight.color.linear : primaryLight.color);
				color *= primaryLight.intensity;
				if (lightsUseLinearIntensity && primaryLight.useColorTemperature)
				{
					color *= Mathf.CorrelatedColorTemperatureToRGB(primaryLight.colorTemperature);
				}
				if (!lightsUseLinearIntensity)
				{
					color = color.MaybeLinear();
				}
				clear = (lightsUseLinearIntensity ? color.MaybeGamma() : color);
				Shader.SetGlobalVector(ShaderIDs.s_PrimaryLightDirection, vector);
				Shader.SetGlobalVector(ShaderIDs.s_PrimaryLightIntensity, clear);
			}
			if (RenderPipelineHelper.IsLegacy)
			{
				OnBeginCameraRenderingLegacy(camera);
			}
		}

		private protected override void OnMigrate()
		{
			base.OnMigrate();
			if (_Version < 1)
			{
				Surface._Layer = _Layer;
				Surface._Material = _Material;
				Surface._VolumeMaterial = _VolumeMaterial;
				Surface._ChunkTemplate = _ChunkTemplate;
				Surface._CastShadows = _CastShadows;
				Surface._WaterBodyCulling = _WaterBodyCulling;
				Surface._TimeSliceBoundsUpdateFrameCount = _TimeSliceBoundsUpdateFrameCount;
				Surface._AllowRenderQueueSorting = _AllowRenderQueueSorting;
				Surface._SurfaceSelfIntersectionFixMode = _SurfaceSelfIntersectionFixMode;
				_DepthLod._IncludeTerrainHeight = false;
			}
			if (_Version < 2)
			{
				AnimatedWavesLod.QuerySource = (LodQuerySource)Mathf.Max(0, (int)(AnimatedWavesLod.CollisionSource - 1));
			}
		}
	}
}
