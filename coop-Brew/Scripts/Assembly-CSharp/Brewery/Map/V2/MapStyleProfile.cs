using UnityEngine;

namespace Brewery.Map.V2
{
	[CreateAssetMenu(fileName = "MapStyleProfile", menuName = "Brewery/Map Style Profile", order = 101)]
	public class MapStyleProfile : ScriptableObject
	{
		[Header("═══ Edge Detection (Ink Outlines) ═══")]
		[Tooltip("Strength of depth-based edge detection")]
		[Range(0f, 50f)]
		public float edgeStrength;

		[Tooltip("Threshold below which edges are not drawn")]
		[Range(0f, 0.1f)]
		public float edgeThreshold;

		[Tooltip("Thickness of edge lines (1 = 1 pixel, higher = thicker)")]
		[Range(0.5f, 5f)]
		public float edgeThickness;

		[Tooltip("Wobble/scribble effect on edges (0 = clean, higher = more hand-drawn)")]
		[Range(0f, 10f)]
		public float edgeWobble;

		[Tooltip("Color of ink outlines")]
		public Color edgeColor;

		[Header("═══ Contour Lines ═══")]
		[Tooltip("World-space vertical distance between contour lines (meters)")]
		[Range(0.5f, 50f)]
		public float contourSpacing;

		[Tooltip("Visual thickness of contour lines")]
		[Range(0.005f, 0.15f)]
		public float contourThickness;

		[Tooltip("Color of contour lines")]
		public Color contourColor;

		[Tooltip("Every Nth contour line is drawn as a major (thicker) line")]
		[Range(2f, 10f)]
		public int majorContourEvery;

		[Header("═══ Height-Based Coloring ═══")]
		[Tooltip("World Y considered the lowest point")]
		public float heightMin;

		[Tooltip("World Y considered the highest point")]
		public float heightMax;

		[Tooltip("How much to blend height colors over the scene (0 = original scene, 1 = full topo colors)")]
		[Range(0f, 1f)]
		public float heightColorBlend;

		[Tooltip("Color for lowest elevation (water/valleys)")]
		public Color heightColor0_Valleys;

		[Tooltip("Color for low elevation (plains/fields)")]
		public Color heightColor1_Plains;

		[Tooltip("Color for mid elevation (hills)")]
		public Color heightColor2_Hills;

		[Tooltip("Color for high elevation (mountains)")]
		public Color heightColor3_Mountains;

		[Tooltip("Color for highest elevation (peaks)")]
		public Color heightColor4_Peaks;

		[Header("═══ Paper / Parchment Texture ═══")]
		[Tooltip("Intensity of procedural paper texture overlay")]
		[Range(0f, 1f)]
		public float paperIntensity;

		[Tooltip("Tint color of the paper (warm = parchment, cool = blueprint)")]
		public Color paperTint;

		[Tooltip("Scale of the paper noise pattern")]
		[Range(1f, 100f)]
		public float paperScale;

		[Header("═══ Desaturation ═══")]
		[Tooltip("How much to desaturate the scene (0 = full color, 1 = grayscale)")]
		[Range(0f, 1f)]
		public float desaturation;

		[Header("═══ Grid Overlay ═══")]
		[Tooltip("Enable coordinate grid overlay")]
		public bool gridEnabled;

		[Tooltip("World-space distance between grid lines (meters)")]
		[Range(5f, 200f)]
		public float gridSpacing;

		[Tooltip("Visual thickness of grid lines")]
		[Range(0.001f, 0.05f)]
		public float gridThickness;

		[Tooltip("Grid line color")]
		public Color gridColor;

		[Header("═══ Vignette (Aged Border) ═══")]
		[Tooltip("Strength of the aged border vignette")]
		[Range(0f, 3f)]
		public float vignetteStrength;

		[Tooltip("Color of the vignette tint")]
		public Color vignetteTint;

		[Header("═══ Camera Settings ═══")]
		[Tooltip("Use orthographic (true map) or perspective (3D depth) projection")]
		public bool useOrthographic;

		[Tooltip("Height above the player the map camera sits")]
		[Range(20f, 500f)]
		public float cameraHeight;

		[Tooltip("Camera look-down angle (90 = straight down)")]
		[Range(45f, 90f)]
		public float cameraAngle;

		[Tooltip("Starting angle on map open — creeps to cameraAngle during open polish (0 = disabled, uses cameraAngle immediately)")]
		[Range(0f, 89f)]
		public float cameraOpenAngle;

		[Tooltip("Orthographic size (zoom level) — used when useOrthographic is true")]
		[Range(10f, 500f)]
		public float orthographicSize;

		[Tooltip("Field of view — used when useOrthographic is false")]
		[Range(10f, 120f)]
		public float fieldOfView;

		[Tooltip("Minimum zoom (ortho size or FOV depending on mode)")]
		[Range(5f, 50f)]
		public float minZoom;

		[Tooltip("Maximum zoom (ortho size or FOV depending on mode)")]
		[Range(100f, 1000f)]
		public float maxZoom;

		[Tooltip("Zoom speed multiplier")]
		[Range(1f, 200f)]
		public float zoomSpeed;

		[Tooltip("Zoom smoothing (higher = snappier)")]
		[Range(1f, 20f)]
		public float zoomSmoothing;

		[Header("═══ Navigation ═══")]
		[Tooltip("WASD/mouse drag navigation speed")]
		[Range(5f, 200f)]
		public float navigationSpeed;

		[Tooltip("Sprint multiplier when holding Shift")]
		[Range(1.5f, 5f)]
		public float sprintMultiplier;

		[Tooltip("Navigation smoothing (acceleration/deceleration)")]
		[Range(0.01f, 0.5f)]
		public float navigationSmoothing;

		[Tooltip("Enable mouse drag panning")]
		public bool enableDragPanning;

		[Tooltip("Drag panning sensitivity")]
		[Range(0.1f, 5f)]
		public float dragSensitivity;

		[Header("═══ Transition — Open Polish ═══")]
		[Tooltip("Duration of the fast open settle effect (seconds). Also controls ink draw speed.")]
		[Range(0.05f, 0.5f)]
		public float openDuration;

		[Tooltip("Duration of the ink line draw-in (seconds). 0 = instant, same as openDuration = sync with polish.")]
		[Range(0f, 2f)]
		public float inkDrawDuration;

		[Tooltip("Strength of the parchment veil on open (softens initial appearance, clamped to 0.35 in shader)")]
		[Range(0f, 0.5f)]
		public float paperVeilStrength;

		[Tooltip("Subtle radial paper settle on open (UV offset from center)")]
		[Range(0f, 0.02f)]
		public float paperParallaxStrength;

		[Tooltip("Ink bloom — slight line softness at open, settles to crisp")]
		[Range(0f, 1f)]
		public float inkBloomStrength;

		[Tooltip("Extra edge darkening/framing on open (reduces flash)")]
		[Range(0f, 1f)]
		public float frameDarkenStrength;

		[Header("═══ LOD / Culling Fix ═══")]
		[Tooltip("LOD bias for map camera. Lower = better performance (uses simpler meshes). The cartographic shader uses depth edges, so low-LOD meshes produce nearly identical results. 1 = normal, 0.1 = aggressive (best perf), 10 = force max detail (worst perf).")]
		[Range(0.1f, 10f)]
		public float lodBias;

		[Tooltip("Far clip plane for map camera")]
		[Range(100f, 5000f)]
		public float farClipPlane;

		[Tooltip("Custom per-layer culling distances (0 = use camera far clip)")]
		public float defaultLayerCullDistance;

		[Header("═══ Boundaries ═══")]
		[Tooltip("Enable simple box boundary clamping")]
		public bool enableBoundaries;

		[Tooltip("Minimum X coordinate the map camera can reach")]
		public float minX;

		[Tooltip("Maximum X coordinate the map camera can reach")]
		public float maxX;

		[Tooltip("Minimum Z coordinate the map camera can reach")]
		public float minZ;

		[Tooltip("Maximum Z coordinate the map camera can reach")]
		public float maxZ;

		[Header("═══ Hover System ═══")]
		[Tooltip("Layer mask for hover raycasts (which layers can be hovered)")]
		public LayerMask hoverRaycastLayers;

		[Tooltip("Maximum raycast distance for hover detection")]
		[Range(100f, 5000f)]
		public float maxHoverDistance;

		[Header("═══ Rendering ═══")]
		[Tooltip("URP Renderer index for the map camera. Use a stripped-down renderer (no SSAO, no bloom, no decals — just MapCartographicFeature) for massive perf gains. -1 = use default renderer.")]
		public int mapRendererIndex;

		[Tooltip("Layers to render ON TOP of the cartographic shader (no post-processing). Use this for particles, VFX, or anything that should appear over the map lines.")]
		public LayerMask overlayLayers;

		[Tooltip("Culling mask for the map camera (which layers to render)")]
		public LayerMask cullingMask;

		[Header("═══ Terrain Surface Rendering ═══")]
		[Tooltip("Enable terrain-texture-based rendering (roads, paths, etc.)")]
		public bool terrainSurfaceEnabled;

		[Tooltip("Primary surface group (e.g., paved roads — cobblestone)")]
		public TerrainSurfaceStyle surfaceGroupA;

		[Tooltip("Secondary surface group (e.g., dirt paths)")]
		public TerrainSurfaceStyle surfaceGroupB;

		[Header("═══ Debug ═══")]
		public bool showDebugLogs;

		public void ApplyTopoPreset()
		{
		}

		public void ApplyBlueprintPreset()
		{
		}

		public void ApplyWatercolorPreset()
		{
		}
	}
}
