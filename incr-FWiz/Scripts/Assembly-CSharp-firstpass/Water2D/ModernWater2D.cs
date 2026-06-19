using UnityEngine;

namespace Water2D
{
	[ExecuteAlways]
	[RequireComponent(typeof(SpriteRenderer))]
	public class ModernWater2D : MonoBehaviour
	{
		[HideInInspector]
		[SerializeField]
		public static ModernWater2DSettings defaultSettings;

		[HideInInspector]
		[SerializeField]
		public SimulationType _waterSimulationType;

		[HideInInspector]
		[SerializeField]
		private WaterSimulation _waterSimulation;

		[HideInInspector]
		[SerializeField]
		private WaveSimulation _wavesSimulation;

		[HideInInspector]
		[SerializeField]
		private static ObstructorManager _obstructorManager;

		[HideInInspector]
		[SerializeField]
		private static ReflectionsSystem _reflectionsManagerPlatformer;

		[HideInInspector]
		[SerializeField]
		private static ReflectionsSystem _reflectionsManagerTopDown;

		[HideInInspector]
		[SerializeField]
		private static ReflectionsSystem _reflectionsManagerRayMarch;

		[HideInInspector]
		[SerializeField]
		private SurfaceRenderingManager _surfaceRenderer;

		[HideInInspector]
		[SerializeField]
		private LayerRenderer _childPPLayerRenderer;

		[HideInInspector]
		[SerializeField]
		private GameObject _childPP;

		[SerializeField]
		[HideInInspector]
		public WaterCryo<bool> ManagersVisible;

		[HideInInspector]
		[SerializeField]
		public WaterCryo<bool> enableObstruction;

		[HideInInspector]
		[SerializeField]
		public WaterCryo<bool> enableReflections;

		[HideInInspector]
		[SerializeField]
		public WaterCryo<bool> enableSimulation;

		[HideInInspector]
		[SerializeField]
		public WaterCryo<bool> enableWavesSimulation;

		[HideInInspector]
		[SerializeField]
		public WaterCryo<bool> enableBlur;

		[HideInInspector]
		[SerializeField]
		public bool lightingWhenBlur;

		[HideInInspector]
		[SerializeField]
		public WaterCryo<bool> normalsPreview;

		[HideInInspector]
		[SerializeField]
		public WaterCryo<bool> overrideMainCamera;

		[HideInInspector]
		[SerializeField]
		public Camera cameraOverride;

		[SerializeField]
		[HideInInspector]
		public float raymarchUnits;

		[HideInInspector]
		[SerializeField]
		public ModernWater2DSettings settings;

		[HideInInspector]
		[SerializeField]
		public bool customWaterMaterial;

		[HideInInspector]
		[SerializeField]
		private Material _mat;

		[HideInInspector]
		[SerializeField]
		private Material _matb;

		[HideInInspector]
		[SerializeField]
		private static Transform _managersParent;

		[HideInInspector]
		[SerializeField]
		private SpriteRenderer _sr;

		public const string managersParentName = "2DWaterManagers";

		public const string srLayer = "Water";

		public const string sr2Layer = "WaterPostProcessing";

		private Vector2 resolution;

		[HideInInspector]
		[SerializeField]
		public ObstructorManager obstructorManager
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		[HideInInspector]
		[SerializeField]
		public SurfaceRenderingManager surfaceRenderer
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		[HideInInspector]
		[SerializeField]
		public ReflectionsSystem reflectionsManagerPlatformer
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		[HideInInspector]
		[SerializeField]
		public ReflectionsSystem reflectionsManagerRayMarch
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		[HideInInspector]
		[SerializeField]
		public ReflectionsSystem reflectionsManagerTopDown
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public WaterSimulation waterSimulation
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public WaveSimulation wavesSimulation
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public GameObject childPP
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		[HideInInspector]
		[SerializeField]
		public Material mat
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		[HideInInspector]
		[SerializeField]
		public Material matb
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public static Transform managersParent
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public SpriteRenderer sr
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		private void OnEnable()
		{
		}

		private void SetLayers()
		{
		}

		private void CreateDestroyPostProcessingCamera()
		{
		}

		private void CreateChildPP()
		{
		}

		private void SetCameraAboveWaterTransform(Transform t, float deltaZ)
		{
		}

		private Camera GetCameraRenderingScreen()
		{
			return null;
		}

		private void SetCameraLayers()
		{
		}

		public void SetWaterSim(ref WaterSimulation _waterSimulation)
		{
		}

		private void Start()
		{
		}

		private void SetupManagers()
		{
		}

		private void OnResolutionChanged()
		{
		}

		private bool CheckForResolutionChanged()
		{
			return false;
		}

		private void SimulationSetup()
		{
		}

		private void CameraSetup()
		{
		}

		private void SetCallbacks()
		{
		}

		public void OnCameraSettingsChanged()
		{
		}

		private void OnOSimulationChanged()
		{
		}

		private void SetupWaveSimulation()
		{
		}

		private void OnWavesSimulationChanged()
		{
		}

		private void OnObstructionChanged()
		{
		}

		private void OnInspectorSettingsChanged()
		{
		}

		public void OnBlurMaterialChanged()
		{
		}

		private void SetMaterials()
		{
		}

		private void OnBlurChanged()
		{
		}

		private void OnWaterChanged()
		{
		}

		private void OnReflectionsChanged()
		{
		}

		private void Awake()
		{
		}

		private void Update()
		{
		}

		private void ReflectionsUpdate()
		{
		}

		private void SurfaceSetup()
		{
		}

		private void BelowWaterSetup()
		{
		}

		private void FixedUpdate()
		{
		}

		private void OnDrawGizmos()
		{
		}

		public static Texture2D Create(Gradient grad, int width = 32, int height = 1)
		{
			return null;
		}

		private void OnTriggerEnter2D(Collider2D collision)
		{
		}
	}
}
