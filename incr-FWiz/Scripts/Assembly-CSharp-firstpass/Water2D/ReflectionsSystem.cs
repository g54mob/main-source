using System;
using System.Collections.Generic;
using UnityEngine;

namespace Water2D
{
	[Serializable]
	public class ReflectionsSystem : WaterFeatureLayerRenderer
	{
		[SerializeField]
		[HideInInspector]
		public static ReflectionsSystem instanceTopDown;

		[SerializeField]
		[HideInInspector]
		public static ReflectionsSystem instanceRayMarch;

		[SerializeField]
		[HideInInspector]
		public static ReflectionsSystem instancePlatformer;

		[SerializeField]
		[HideInInspector]
		private bool startupQF;

		[HideInInspector]
		public int pivotDetectionAlphaTreshold;

		[HideInInspector]
		[SerializeField]
		public WaterCryo<bool> overrideMainCamera;

		[HideInInspector]
		[SerializeField]
		public WaterCryo<bool> reflectionObjectsVisible;

		[HideInInspector]
		[SerializeField]
		public WaterCryo<bool> cameraVisible;

		[HideInInspector]
		[SerializeField]
		public WaterCryo<bool> defaultReflectionSprflipx;

		[HideInInspector]
		[SerializeField]
		public Camera mainCamera;

		[HideInInspector]
		[SerializeField]
		public Camera reflectionCamera;

		[HideInInspector]
		[SerializeField]
		public Material reflectorMat;

		[HideInInspector]
		[SerializeField]
		public Material reflectionMat;

		[HideInInspector]
		[SerializeField]
		public WaterCryo<float> textureResolution;

		[HideInInspector]
		[SerializeField]
		public int layers;

		public const string rlayer = "Reflections";

		public const string reflectorMatPath = "Materials/reflector_mat";

		public const string reflectionMatPath = "Materials/reflection_mat";

		[HideInInspector]
		[SerializeField]
		public bool topdown;

		[HideInInspector]
		[SerializeField]
		public bool raymarch;

		[HideInInspector]
		public int reflectionLayerIdx;

		[SerializeField]
		[HideInInspector]
		private ReflectionSettings _reflectionsSettings;

		[SerializeField]
		private Dictionary<Transform, ReflectionSO> _reflectors;

		[SerializeField]
		private Dictionary<Texture2D, Vector2> _pivots;

		[SerializeField]
		private Dictionary<Sprite, Vector2> _pivotsSH;

		private Transform[] cleaner;

		private int cleanIdx;

		public static bool update_extended;

		private LayerRenderer layerRenderer
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		[SerializeField]
		[HideInInspector]
		public ReflectionSettings reflectionsSettings
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		private Dictionary<Transform, ReflectionSO> reflectors
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		private Dictionary<Texture2D, Vector2> pivots
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		private Dictionary<Sprite, Vector2> pivotsSH
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public ReflectionsSystem(bool topdown)
		{
		}

		private void Awake()
		{
		}

		private void Singleton()
		{
		}

		public static ReflectionsSystem GetInstanceTopDown()
		{
			return null;
		}

		public static ReflectionsSystem GetInstancePlatformer()
		{
			return null;
		}

		public static ReflectionsSystem GetInstanceRayMarch()
		{
			return null;
		}

		public void AddReflector(ReflectionSO r)
		{
		}

		public void RemoveReflector(ReflectionSO r)
		{
		}

		public void GetAllReflectors()
		{
		}

		public void UpdateAllReflectors()
		{
		}

		public void ReflectionObjectsVisible(bool visible)
		{
		}

		public void UpdateSettings(ReflectionsSettings reflectionsSettings, bool topdown)
		{
		}

		private void SetCallbacks()
		{
		}

		private void OnSettingsChangedScene()
		{
		}

		private void OnSettingsChanged()
		{
		}

		public void OnEnable()
		{
		}

		private void SetupVariables()
		{
		}

		private void OnDisable()
		{
		}

		private void OnDestroy()
		{
		}

		private void Start()
		{
		}

		protected override void Update()
		{
		}

		private void UpdateReflections()
		{
		}

		private void UpdateReflectionsPhysics()
		{
		}

		private void UpdateReflection(ReflectionSO reflection)
		{
		}

		private void UpdateReflectionsShader()
		{
		}

		private void SetReflectionXOrientation(ReflectionSO reflection)
		{
		}

		private void SetReflectionPivotPos(ReflectionSO reflection)
		{
		}

		private bool IsSpriteFromSpriteSheet(Sprite s)
		{
			return false;
		}

		public Vector2 GetSpritePivotSpriteSheet(Sprite org)
		{
			return default(Vector2);
		}

		public Vector2 GetSpritePivot(Sprite org)
		{
			return default(Vector2);
		}
	}
}
