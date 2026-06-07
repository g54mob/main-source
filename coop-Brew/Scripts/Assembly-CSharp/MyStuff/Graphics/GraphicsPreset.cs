using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace MyStuff.Graphics
{
	[CreateAssetMenu(fileName = "GraphicsPreset", menuName = "Graphics/Graphics Preset", order = 1)]
	public sealed class GraphicsPreset : ScriptableObject
	{
		[Header("=== Preset Metadata ===")]
		[Tooltip("Display name for this preset")]
		public string presetName;

		[Tooltip("Brief description of the visual style")]
		[TextArea(2, 4)]
		public string description;

		[Tooltip("Optional preview thumbnail")]
		public Texture2D previewThumbnail;

		[Tooltip("Preset author/creator")]
		public string author;

		[Tooltip("Preset version")]
		public string version;

		[Header("=== Bloom ===")]
		[Tooltip("Enable bloom effect")]
		public bool bloomEnabled;

		[Tooltip("Bloom intensity (0-10)")]
		[Range(0f, 10f)]
		public float bloomIntensity;

		[Tooltip("Brightness threshold for bloom (0-10)")]
		[Range(0f, 10f)]
		public float bloomThreshold;

		[Tooltip("Light scatter/diffusion (0-1)")]
		[Range(0f, 1f)]
		public float bloomScatter;

		[Tooltip("Optional dirt texture for bloom lens")]
		public Texture2D bloomDirtTexture;

		[Tooltip("Dirt texture strength (0-20)")]
		[Range(0f, 20f)]
		public float bloomDirtIntensity;

		[Tooltip("Bloom tint color")]
		public Color bloomTint;

		[Tooltip("High quality bloom sampling")]
		public bool bloomHighQuality;

		[Header("=== Color Adjustments ===")]
		[Tooltip("Enable color adjustments")]
		public bool colorAdjustmentsEnabled;

		[Tooltip("Post-exposure adjustment in EV (-10 to 10)")]
		[Range(-10f, 10f)]
		public float postExposure;

		[Tooltip("Contrast adjustment (-100 to 100)")]
		[Range(-100f, 100f)]
		public float contrast;

		[Tooltip("Color filter/tint")]
		public Color colorFilter;

		[Tooltip("Hue shift in degrees (-180 to 180)")]
		[Range(-180f, 180f)]
		public float hueShift;

		[Tooltip("Saturation adjustment (-100 to 100)")]
		[Range(-100f, 100f)]
		public float saturation;

		[Header("=== Tonemapping ===")]
		[Tooltip("Tonemapping mode")]
		public TonemappingMode tonemappingMode;

		[Header("=== White Balance ===")]
		[Tooltip("Enable white balance")]
		public bool whiteBalanceEnabled;

		[Tooltip("Temperature adjustment (-100 to 100)")]
		[Range(-100f, 100f)]
		public float temperature;

		[Tooltip("Tint adjustment (-100 to 100)")]
		[Range(-100f, 100f)]
		public float tint;

		[Header("=== Split Toning ===")]
		[Tooltip("Enable split toning")]
		public bool splitToningEnabled;

		[Tooltip("Shadow color tint")]
		public Color shadowsTint;

		[Tooltip("Highlights color tint")]
		public Color highlightsTint;

		[Tooltip("Balance between shadows and highlights (-100 to 100)")]
		[Range(-100f, 100f)]
		public float splitToningBalance;

		[Header("=== Vignette ===")]
		[Tooltip("Enable vignette")]
		public bool vignetteEnabled;

		[Tooltip("Vignette color")]
		public Color vignetteColor;

		[Tooltip("Vignette intensity (0-1)")]
		[Range(0f, 1f)]
		public float vignetteIntensity;

		[Tooltip("Vignette smoothness (0.01-1)")]
		[Range(0.01f, 1f)]
		public float vignetteSmoothness;

		[Tooltip("Rounded vignette")]
		public bool vignetteRounded;

		[Header("=== Depth of Field ===")]
		[Tooltip("Enable depth of field")]
		public bool depthOfFieldEnabled;

		[Tooltip("DOF mode")]
		public DepthOfFieldMode depthOfFieldMode;

		[Tooltip("Focus distance (meters)")]
		[Range(0.1f, 1000f)]
		public float focusDistance;

		[Tooltip("Aperture f-number (f/1.4 to f/32)")]
		[Range(1f, 32f)]
		public float aperture;

		[Tooltip("Focal length (mm) - affects blur amount")]
		[Range(1f, 300f)]
		public float focalLength;

		[Tooltip("Blade count for bokeh shape")]
		[Range(3f, 9f)]
		public int bladeCount;

		[Tooltip("Blade curvature (0-1)")]
		[Range(0f, 1f)]
		public float bladeCurvature;

		[Tooltip("Blade rotation (degrees)")]
		[Range(0f, 180f)]
		public float bladeRotation;

		[Header("Gaussian Mode Settings")]
		[Tooltip("Gaussian near blur start distance (meters)")]
		[Range(0f, 1000f)]
		public float gaussianStart;

		[Tooltip("Gaussian far blur end distance (meters)")]
		[Range(0f, 1000f)]
		public float gaussianEnd;

		[Tooltip("Gaussian max radius (blur intensity)")]
		[Range(0.5f, 1.5f)]
		public float gaussianMaxRadius;

		[Tooltip("Use high quality Gaussian (better quality, more performance cost)")]
		public bool gaussianHighQuality;

		[Header("=== Motion Blur ===")]
		[Tooltip("Enable motion blur")]
		public bool motionBlurEnabled;

		[Tooltip("Shutter angle (degrees, 0-360)")]
		[Range(0f, 360f)]
		public float motionBlurShutterAngle;

		[Tooltip("Sample count (quality vs performance)")]
		[Range(2f, 32f)]
		public int motionBlurSampleCount;

		[Header("=== Chromatic Aberration ===")]
		[Tooltip("Enable chromatic aberration")]
		public bool chromaticAberrationEnabled;

		[Tooltip("Aberration intensity (0-1)")]
		[Range(0f, 1f)]
		public float chromaticAberrationIntensity;

		[Header("=== Lens Distortion ===")]
		[Tooltip("Enable lens distortion")]
		public bool lensDistortionEnabled;

		[Tooltip("Distortion intensity (-1 to 1)")]
		[Range(-1f, 1f)]
		public float lensDistortionIntensity;

		[Tooltip("X scale multiplier")]
		[Range(0.01f, 5f)]
		public float lensDistortionXMultiplier;

		[Tooltip("Y scale multiplier")]
		[Range(0.01f, 5f)]
		public float lensDistortionYMultiplier;

		[Tooltip("Center point")]
		public Vector2 lensDistortionCenter;

		[Header("=== Film Grain ===")]
		[Tooltip("Enable film grain")]
		public bool filmGrainEnabled;

		[Tooltip("Grain type")]
		public FilmGrainLookup filmGrainType;

		[Tooltip("Grain intensity (0-1)")]
		[Range(0f, 1f)]
		public float filmGrainIntensity;

		[Tooltip("Grain response (shadows to highlights, 0-1)")]
		[Range(0f, 1f)]
		public float filmGrainResponse;

		[Header("=== Panini Projection ===")]
		[Tooltip("Enable panini projection")]
		public bool paniniProjectionEnabled;

		[Tooltip("Distance parameter (0-1)")]
		[Range(0f, 1f)]
		public float paniniDistance;

		[Tooltip("Crop to fit (0-1)")]
		[Range(0f, 1f)]
		public float paniniCropToFit;

		[Header("=== Lens Flare (Sun) ===")]
		[Tooltip("Enable lens flare on directional light (sun)")]
		public bool lensFlareEnabled;

		[Tooltip("Lens flare data asset (defines the flare appearance - create via Create > Rendering > Lens Flare (SRP))")]
		public ScriptableObject lensFlareData;

		[Tooltip("Overall flare intensity multiplier (0-10)")]
		[Range(0f, 10f)]
		public float lensFlareIntensity;

		[Tooltip("Flare scale/size multiplier (0.1-5)")]
		[Range(0.1f, 5f)]
		public float lensFlareScale;

		[Tooltip("Maximum attenuation distance (meters, 0 = infinite)")]
		[Range(0f, 1000f)]
		public float lensFlareMaxAttenuationDistance;

		[Tooltip("Attenuation by light distance (less flare when far)")]
		[Range(0f, 1f)]
		public float lensFlareDistanceAttenuation;

		[Tooltip("Occlusion radius (0-1, how much geometry blocks flare)")]
		[Range(0f, 1f)]
		public float lensFlareOcclusionRadius;

		[Tooltip("Number of samples for occlusion (2-64, higher = smoother)")]
		[Range(2f, 64f)]
		public int lensFlareOcclusionSamples;

		[Tooltip("Allow off-screen rendering of lens flare")]
		public bool lensFlareAllowOffScreen;

		[Header("=== Screen Space Ambient Occlusion ===")]
		[Tooltip("Enable SSAO (quality settings configured on the URP renderer asset)")]
		public bool ssaoEnabled;

		[Header("=== Fog ===")]
		[Tooltip("Enable fog")]
		public bool fogEnabled;

		[Tooltip("Fog color")]
		public Color fogColor;

		[Tooltip("Fog mode")]
		public FogMode fogMode;

		[Tooltip("Fog density (exponential modes)")]
		[Range(0f, 1f)]
		public float fogDensity;

		[Tooltip("Fog start distance (linear mode)")]
		[Range(0f, 1000f)]
		public float fogStart;

		[Tooltip("Fog end distance (linear mode)")]
		[Range(0f, 5000f)]
		public float fogEnd;

		[Header("=== Volumetric Fog ===")]
		[Tooltip("Enable volumetric fog (if supported)")]
		public bool volumetricFogEnabled;

		[Header("=== Ambient Lighting ===")]
		[Tooltip("Ambient mode")]
		public AmbientMode ambientMode;

		[Tooltip("Ambient sky color")]
		public Color ambientSkyColor;

		[Tooltip("Ambient equator color (Trilight mode)")]
		public Color ambientEquatorColor;

		[Tooltip("Ambient ground color (Trilight mode)")]
		public Color ambientGroundColor;

		[Tooltip("Ambient intensity multiplier")]
		[Range(0f, 8f)]
		public float ambientIntensity;

		[Header("=== Shadows ===")]
		[Tooltip("Shadow cascade count (1-4)")]
		[Range(1f, 4f)]
		public int shadowCascades;

		[Tooltip("Shadow distance (meters)")]
		[Range(10f, 500f)]
		public float shadowDistance;

		[Tooltip("Enable soft shadows")]
		public bool softShadows;

		[Tooltip("Main light shadow strength (0-1)")]
		[Range(0f, 1f)]
		public float mainLightShadowStrength;

		[Tooltip("Additional lights shadow strength (0-1)")]
		[Range(0f, 1f)]
		public float additionalLightsShadowStrength;

		[Header("=== Camera & Rendering ===")]
		[Tooltip("Enable HDR rendering")]
		public bool hdrEnabled;

		[Tooltip("MSAA level (0=off, 2x, 4x, 8x)")]
		public MsaaQuality msaaQuality;

		[Tooltip("Enable opaque texture (for effects that need scene color)")]
		public bool opaqueTexture;

		[Tooltip("Enable depth texture")]
		public bool depthTexture;

		[Tooltip("Enable dynamic resolution")]
		public bool dynamicResolution;

		[Tooltip("Render scale (0.5-2.0)")]
		[Range(0.5f, 2f)]
		public float renderScale;

		[Header("=== Renderer Features ===")]
		[Tooltip("Enable decals")]
		public bool decalsEnabled;

		[Tooltip("Use Forward+ rendering (requires URP 16+)")]
		public bool useForwardPlus;

		[Header("=== Display & Window ===")]
		[Tooltip("Preferred screen width (0 = use current)")]
		public int screenWidth;

		[Tooltip("Preferred screen height (0 = use current)")]
		public int screenHeight;

		[Tooltip("Fullscreen mode")]
		public FullScreenMode fullScreenMode;

		[Tooltip("Enable VSync (0=off, 1=on, 2=every 2nd frame)")]
		[Range(0f, 2f)]
		public int vSyncCount;

		[Tooltip("Target frame rate (-1 = unlimited)")]
		[Range(-1f, 300f)]
		public int targetFrameRate;

		[Header("=== Textures & Filtering ===")]
		[Tooltip("Anisotropic filtering mode")]
		public AnisotropicFiltering anisotropicFiltering;

		[Tooltip("Texture quality (mipmap limit, 0=highest, 3=lowest)")]
		[Range(0f, 3f)]
		public int textureQuality;

		[Tooltip("LOD bias (higher = better quality at distance)")]
		[Range(0f, 2f)]
		public float lodBias;

		[Tooltip("Maximum LOD level (0=highest detail)")]
		[Range(0f, 7f)]
		public int maximumLODLevel;

		[Header("=== Lighting Quality ===")]
		[Tooltip("Maximum pixel light count")]
		[Range(0f, 8f)]
		public int pixelLightCount;

		[Tooltip("Enable realtime reflection probes")]
		public bool realtimeReflectionProbes;

		[Header("=== Physics & Particles ===")]
		[Tooltip("Particle raycast budget")]
		[Range(4f, 4096f)]
		public int particleRaycastBudget;

		[Tooltip("Skin weights quality")]
		public SkinWeights skinWeights;

		[Header("=== Camera Settings ===")]
		[Tooltip("Field of view (degrees)")]
		[Range(30f, 120f)]
		public float fieldOfView;

		[Tooltip("Enable occlusion culling")]
		public bool occlusionCulling;

		[Header("=== Display Calibration ===")]
		[Tooltip("Brightness adjustment (-0.5 to +1.0)")]
		[Range(-0.5f, 1f)]
		public float brightness;

		[Header("=== Advanced Settings ===")]
		[Tooltip("Enable async upload")]
		public bool asyncUploadTimeSlice;

		[Tooltip("Async upload buffer size (MB)")]
		[Range(2f, 32f)]
		public int asyncUploadBufferSize;

		[Tooltip("Billboard facing camera position")]
		public bool billboardsFaceCameraPosition;

		[Tooltip("Enable streaming mipmaps")]
		public bool streamingMipmapsActive;

		[Tooltip("Streaming mipmap memory budget (MB)")]
		[Range(256f, 4096f)]
		public int streamingMipmapsMemoryBudget;

		[Header("=== Shadow Quality ===")]
		[Tooltip("Main light shadow resolution (Low=512, Medium=1024, High=2048, VeryHigh=4096)")]
		public ShadowResolution mainLightShadowResolution;

		[Tooltip("Additional lights shadow resolution")]
		public ShadowResolution additionalLightsShadowResolution;

		[Tooltip("Shadow depth bias — prevents shadow acne. Higher values may cause shadow detachment. Low-poly: 0.8-1.2")]
		[Range(0f, 10f)]
		public float shadowDepthBias;

		[Tooltip("Shadow normal bias — pushes shadow along surface normal. Keep LOW for low-poly (large flat faces distort shadows). Low-poly: 0.01-0.1")]
		[Range(0f, 10f)]
		public float shadowNormalBias;

		[Tooltip("Shadow near plane offset")]
		[Range(0f, 10f)]
		public float shadowNearPlane;

		[Tooltip("Cascade split blend — higher = smoother transitions between cascades, reduces seam flickering")]
		[Range(0f, 1f)]
		public float cascadeBlend;

		[Header("Shadow Cascade Distribution")]
		[Tooltip("First cascade split — closer to 0 gives more resolution near camera. For 2 cascades use ~0.33, for 4 cascades use ~0.067")]
		[Range(0f, 1f)]
		public float cascade2Split;

		[Tooltip("Second cascade split (4 cascades only)")]
		[Range(0f, 1f)]
		public float cascade3Split;

		[Tooltip("Third cascade split (4 cascades only)")]
		[Range(0f, 1f)]
		public float cascade4Split;

		[Header("=== Anti-Aliasing ===")]
		[Tooltip("Post-process anti-aliasing method (FXAA/SMAA/TAA)")]
		public PostAAMode postAntiAliasing;

		[Tooltip("FXAA quality preset")]
		public FXAAQuality fxaaQuality;

		[Tooltip("SMAA quality preset")]
		public SMAAQuality smaaQuality;

		[Tooltip("Temporal AA (TAA) enabled - reduces shadow and specular flickering")]
		public bool temporalAntiAliasingEnabled;

		[Tooltip("TAA jitter spread (0-1)")]
		[Range(0f, 1f)]
		public float taaJitterSpread;

		[Tooltip("TAA sharpness (0-1)")]
		[Range(0f, 1f)]
		public float taaSharpness;

		[Tooltip("TAA stationary blend (0-1, higher = sharper when still)")]
		[Range(0f, 1f)]
		public float taaStationaryBlending;

		[Tooltip("TAA motion blend (0-1, lower = less blur when moving)")]
		[Range(0f, 1f)]
		public float taaMotionBlending;

		[Header("=== Refresh Rate ===")]
		[Tooltip("Preferred refresh rate (0 = system default)")]
		[Range(0f, 240f)]
		public int refreshRate;

		[Header("=== Particle Quality ===")]
		[Tooltip("Enable soft particles")]
		public bool softParticles;

		[Header("=== Performance & Threading ===")]
		[Tooltip("Job worker count (-1 = auto, 0 = main thread only)")]
		[Range(-1f, 16f)]
		public int jobWorkerCount;

		[Tooltip("GPU skinning")]
		public bool gpuSkinning;

		public bool Validate(out string errorMessage)
		{
			errorMessage = null;
			return false;
		}

		public string GetSummary()
		{
			return null;
		}
	}
}
