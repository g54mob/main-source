using UnityEngine;

namespace Brewery.Map
{
	[CreateAssetMenu(fileName = "MapCameraSettings", menuName = "Brewery/Map Camera Settings", order = 100)]
	public class MapCameraSettings : ScriptableObject
	{
		[Header("Map Camera View")]
		[Tooltip("World position where the map camera looks at the world from")]
		public Vector3 mapViewPosition;

		[Tooltip("Rotation of the map camera (angle looking down at world)")]
		public Vector3 mapViewRotation;

		[Tooltip("Field of View for map camera (if perspective) or Orthographic Size (if orthographic)")]
		[Range(10f, 120f)]
		public float mapCameraFOV;

		[Header("Transition Settings")]
		[Tooltip("Duration of camera transition from player to map (seconds)")]
		[Range(0.1f, 3f)]
		public float transitionDuration;

		[Tooltip("Easing curve for camera transition (animation curve)")]
		public AnimationCurve transitionCurve;

		[Tooltip("Zoom effect during transition (FOV multiplier at peak)")]
		[Range(0.5f, 2f)]
		public float zoomTransitionMultiplier;

		[Header("WASD Navigation")]
		[Tooltip("Movement speed when navigating map with WASD (units per second)")]
		[Range(1f, 100f)]
		public float navigationSpeed;

		[Tooltip("Acceleration time for WASD movement (smoother feel)")]
		[Range(0f, 1f)]
		public float navigationAcceleration;

		[Tooltip("Speed multiplier when holding Shift while navigating (e.g., 2.5 = 2.5x faster)")]
		[Range(1f, 5f)]
		public float sprintSpeedMultiplier;

		[Tooltip("Use global/world space controls (true) or camera-relative (false)")]
		public bool useGlobalControls;

		[Header("Camera Boundaries (Clamping)")]
		[Tooltip("Boundary mode: None (unrestricted), SimpleBox (rectangular bounds), or ColliderBased (irregular shapes)")]
		public BoundaryMode boundaryMode;

		[Header("Simple Box Boundaries")]
		[Tooltip("Minimum X coordinate the map camera can reach")]
		public float minX;

		[Tooltip("Maximum X coordinate the map camera can reach")]
		public float maxX;

		[Tooltip("Minimum Z coordinate the map camera can reach")]
		public float minZ;

		[Tooltip("Maximum Z coordinate the map camera can reach")]
		public float maxZ;

		[Header("Collider-Based Boundaries")]
		[Tooltip("Layer mask for boundary colliders - camera must stay inside these BoxColliders")]
		public LayerMask boundaryLayer;

		[Tooltip("Speed of smooth pushback when camera goes outside boundaries")]
		[Range(1f, 50f)]
		public float pushbackSpeed;

		[Tooltip("Radius for boundary checking (helps with smooth transitions at edges)")]
		[Range(0.1f, 5f)]
		public float boundaryCheckRadius;

		[Header("Zoom Controls")]
		[Tooltip("Enable mouse wheel zoom in/out")]
		public bool enableZoom;

		[Tooltip("Zoom sensitivity (how much mouse wheel changes zoom per scroll tick)")]
		[Range(1f, 500f)]
		public float zoomSensitivity;

		[Tooltip("Smooth zoom transitions")]
		public bool smoothZoom;

		[Tooltip("Zoom smoothing speed (higher = faster, snappier zoom)")]
		[Range(5f, 100f)]
		public float zoomSmoothSpeed;

		[Tooltip("How much you can zoom IN from the default (subtracted from mapCameraFOV)")]
		[Range(0f, 50f)]
		public float maxZoomInOffset;

		[Tooltip("How much you can zoom OUT from the default (added to mapCameraFOV)")]
		[Range(0f, 60f)]
		public float maxZoomOutOffset;

		[Header("Depth of Field Settings")]
		[Tooltip("Enable depth of field blur when map is open")]
		public bool enableBlur;

		[Tooltip("DoF mode: Gaussian (fast) or Bokeh (high quality)")]
		public DepthOfFieldMode dofMode;

		[Header("Gaussian DoF (Fast)")]
		[Tooltip("Start distance for Gaussian blur")]
		[Range(0f, 100f)]
		public float gaussianStart;

		[Tooltip("End distance for Gaussian blur")]
		[Range(10f, 500f)]
		public float gaussianEnd;

		[Tooltip("Maximum blur radius for Gaussian DoF")]
		[Range(0.5f, 2f)]
		public float gaussianMaxRadius;

		[Tooltip("Enable high quality sampling for Gaussian DoF")]
		public bool gaussianHighQuality;

		[Header("Bokeh DoF (High Quality)")]
		[Tooltip("Focus distance for Bokeh DoF")]
		[Range(0.1f, 200f)]
		public float bokehFocusDistance;

		[Tooltip("Aperture (f-stop) - lower = more blur, shallower DoF")]
		[Range(1f, 32f)]
		public float bokehAperture;

		[Tooltip("Focal length in mm - affects blur amount")]
		[Range(10f, 300f)]
		public float bokehFocalLength;

		[Tooltip("Blade count for bokeh shape (0 = circular)")]
		[Range(0f, 9f)]
		public int bokehBladeCount;

		[Tooltip("Blade curvature (affects bokeh shape roundness)")]
		[Range(0f, 1f)]
		public float bokehBladeCurvature;

		[Tooltip("Blade rotation angle")]
		[Range(-180f, 180f)]
		public float bokehBladeRotation;

		[Header("Legacy Blur (Fallback)")]
		[Tooltip("Blur intensity when map is open (aperture value) - used as fallback")]
		[Range(0f, 10f)]
		public float blurIntensity;

		[Header("Motion Blur")]
		[Tooltip("Enable motion blur during camera transition")]
		public bool enableMotionBlur;

		[Tooltip("Motion blur intensity during transition")]
		[Range(0f, 1f)]
		public float motionBlurIntensity;

		[Header("Speed Blur")]
		[Tooltip("Enable speed-based blur during WASD movement")]
		public bool enableSpeedBlur;

		[Tooltip("Speed threshold for blur effect (units/sec)")]
		[Range(5f, 50f)]
		public float speedBlurThreshold;

		[Header("Camera Settings")]
		[Tooltip("Use orthographic camera for map view instead of perspective")]
		public bool useOrthographic;

		[Tooltip("Lock player movement when map is open")]
		public bool lockPlayerMovement;

		[Tooltip("Show cursor when map is open")]
		public bool showCursor;

		[Header("Camera Rendering (Map Mode)")]
		[Tooltip("Change camera culling mask when in map mode (e.g., hide certain layers)")]
		public bool changeCullingMask;

		[Tooltip("Culling mask to use in map mode (what layers the camera can see)")]
		public LayerMask mapCullingMask;

		[Tooltip("Change camera clear flags in map mode")]
		public bool changeClearFlags;

		[Tooltip("Clear flags to use in map mode")]
		public CameraClearFlags mapClearFlags;

		[Tooltip("Change camera background color in map mode")]
		public bool changeBackgroundColor;

		[Tooltip("Background color for map camera")]
		public Color mapBackgroundColor;

		[Tooltip("Change render distance (far clip plane) in map mode")]
		public bool changeFarClipPlane;

		[Tooltip("Far clip plane distance for map camera")]
		[Range(100f, 5000f)]
		public float mapFarClipPlane;

		[Tooltip("Fade out fog when map is open (clearer view from above)")]
		public bool fadeOutFog;

		[Tooltip("Fog fade transition duration (seconds)")]
		[Range(0.1f, 3f)]
		public float fogTransitionDuration;

		[Header("Post-Processing Effects")]
		[Tooltip("Enable color grading adjustments in map view")]
		public bool enableColorGrading;

		[Tooltip("Saturation adjustment (-100 to 100, 0 = no change)")]
		[Range(-100f, 100f)]
		public float saturationAdjustment;

		[Tooltip("Contrast adjustment (-100 to 100, 0 = no change)")]
		[Range(-100f, 100f)]
		public float contrastAdjustment;

		[Tooltip("Color filter tint for map view")]
		public Color colorFilterTint;

		[Header("Vignette Effect")]
		[Tooltip("Enable vignette effect around edges")]
		public bool enableVignette;

		[Tooltip("Vignette intensity (0 = off, 1 = full)")]
		[Range(0f, 1f)]
		public float vignetteIntensity;

		[Tooltip("Vignette smoothness")]
		[Range(0.01f, 1f)]
		public float vignetteSmoothness;

		[Tooltip("Vignette color")]
		public Color vignetteColor;

		[Header("Ambient Occlusion")]
		[Tooltip("Enable ambient occlusion in map view for depth")]
		public bool enableAmbientOcclusion;

		[Tooltip("AO intensity")]
		[Range(0f, 4f)]
		public float aoIntensity;

		[Header("Debug")]
		[Tooltip("Show debug gizmos in scene view (boundaries, map position)")]
		public bool showDebugGizmos;

		[Tooltip("Show debug logs in console")]
		public bool showDebugLogs;

		public float MinZoom => 0f;

		public float MaxZoom => 0f;

		private void OnValidate()
		{
		}
	}
}
