using System.Collections.Generic;
using UnityEngine;

namespace Water2D
{
	public class ObstructorManager : WaterFeatureLayerRenderer
	{
		[SerializeField]
		[HideInInspector]
		public static ObstructorManager instance;

		[HideInInspector]
		[SerializeField]
		public WaterCryo<bool> overrideMainCamera;

		[HideInInspector]
		[SerializeField]
		public WaterCryo<bool> obstructionObjectsVisible;

		[HideInInspector]
		[SerializeField]
		public WaterCryo<bool> cameraVisible;

		[HideInInspector]
		[SerializeField]
		public WaterCryo<float> _textureResolution;

		[HideInInspector]
		[SerializeField]
		public Camera cam;

		[HideInInspector]
		[SerializeField]
		public Shader jfShader;

		[HideInInspector]
		[SerializeField]
		public Shader uvShader;

		[HideInInspector]
		[SerializeField]
		public Material jfMaterial;

		[HideInInspector]
		[SerializeField]
		public Material uvMaterial;

		[HideInInspector]
		[SerializeField]
		public RenderTexture jfRenderTexture1;

		[HideInInspector]
		[SerializeField]
		public RenderTexture jfRenderTexture2;

		[HideInInspector]
		[SerializeField]
		private Camera _mainCamera;

		public const string rlayer = "Obstructors";

		public const string redMatPath = "Materials/Red";

		public const string red3dMatPath = "Materials/Red3d";

		private Material _red;

		private Material _red3d;

		[SerializeField]
		private Dictionary<Transform, ObstructorSO> _obstructors;

		[SerializeField]
		[HideInInspector]
		private static Dictionary<int, ObstructorPair> _obstructionSprites;

		[SerializeField]
		[HideInInspector]
		public bool genSDF;

		[HideInInspector]
		[SerializeField]
		public float textureResolution => 0f;

		[HideInInspector]
		[SerializeField]
		public Camera mainCamera
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Material red
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Material red3d
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public LayerRenderer layerRenderer
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Vector2 sizeMLP => default(Vector2);

		private Dictionary<Transform, ObstructorSO> obstructors
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		private static Dictionary<int, ObstructorPair> obstructionSprites
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		private void Awake()
		{
		}

		private void Singleton()
		{
		}

		public static ObstructorManager GetInstance()
		{
			return null;
		}

		public void UpdateSettings(ObstructorSettings os)
		{
		}

		private void SetCallbacks()
		{
		}

		private void OnSettingsChangedScene()
		{
		}

		private void ObstructionObjectsVisible(bool value)
		{
		}

		public void AddObstructor(ObstructorSO obs)
		{
		}

		public void RemoveObstructor(Transform t)
		{
		}

		public void GetAllObstructors()
		{
		}

		private void SetMainCam()
		{
		}

		private void OnEnable()
		{
		}

		private void Start()
		{
		}

		private void OnDisable()
		{
		}

		private void GenTextures()
		{
		}

		public void GenerateSDF()
		{
		}

		protected override void Update()
		{
		}

		private void UpdateObstructionSprites()
		{
		}

		private void UpdateReflectionsShader()
		{
		}
	}
}
