using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.EventSystems;

namespace FIMSpace.FOptimizing
{
	[AddComponentMenu("FImpossible Creations/Optimizers 2/Optimizers Manager", 11)]
	[DefaultExecutionOrder(1001)]
	public class OptimizersManager : MonoBehaviour, IDropHandler, IEventSystemHandler, IFHierarchyIcon
	{
		[BurstCompile]
		public struct CullingDelayJob : IJob
		{
			public NativeList<float> elapsed;

			[ReadOnly]
			public float delta;

			public void Execute()
			{
				for (int i = 0; i < elapsed.Length; i++)
				{
					elapsed[i] += delta;
				}
			}
		}

		[BurstCompile]
		public struct CreateRayCommandsJob : IJobParallelFor
		{
			[ReadOnly]
			public float3 position;

			[ReadOnly]
			public quaternion rotation;

			[ReadOnly]
			public int rayCastCycleOffset;

			[ReadOnly]
			public NativeArray<float3> rayDirs;

			[ReadOnly]
			public int mask;

			[ReadOnly]
			public float maxDistance;

			[WriteOnly]
			public NativeArray<RaycastCommand> rayCommands;

			public void Execute(int index)
			{
				float3 float5 = math.mul(rotation, rayDirs[rayCastCycleOffset + index]);
				RaycastCommand value = new RaycastCommand(position, float5, maxDistance, mask);
				rayCommands[index] = value;
			}
		}

		[BurstCompile]
		public struct CreateTransparentRayCommandsJob : IJobParallelFor
		{
			[ReadOnly]
			public float3 position;

			[ReadOnly]
			public NativeList<float3> rayPoints;

			[ReadOnly]
			public int mask;

			[ReadOnly]
			public float maxDistance;

			[WriteOnly]
			public NativeArray<RaycastCommand> rayCommands;

			public void Execute(int index)
			{
				float3 x = rayPoints[index] - position;
				RaycastCommand value = new RaycastCommand(rayPoints[index], math.normalize(x), maxDistance - math.length(x), mask);
				rayCommands[index] = value;
			}
		}

		[BurstCompile]
		public struct GetResultsJob : IJob
		{
			public NativeList<int> visible;

			[ReadOnly]
			public NativeList<int> hitted;

			[WriteOnly]
			public NativeList<float> elapsed;

			public void Execute()
			{
				for (int i = 0; i < hitted.Length; i++)
				{
					int value = hitted[i];
					int num = visible.IndexOf(value);
					if (num < 0)
					{
						visible.Add(in value);
						elapsed.Add(0f);
					}
					else
					{
						elapsed[num] = 0f;
					}
				}
			}
		}

		[Tooltip("(DontDestroyOnLoad - untoggled just for package examples purpose!)\n\nWith this option enabled, manager will be never destroyed, even during changing scenes. This one manager can be used as only manager in whole game time")]
		public bool ExistThroughScenes = true;

		[Tooltip("You can use this parameter for global quality settings, max distance value for all optimizers will by multiplied by this value (It's not done dynamically - only new initialized optimizers will be affected by this parameter)")]
		[Range(0.5f, 1.5f)]
		public float GlobalMaxDistanceMultiplier = 1f;

		[Tooltip("You should use as many as you can optimizers with same LOD distances and LODs counts to get best from culling containers.\n\nThis number defines how many slots should pre define each container for target optimizers components.\n\nWhen you use many components with different LOD counts or different LOD distance settings and there is only few (for example 200) objects to optimize in each distance range / lod count set you should change this number to be lower to not prepare too much slots for target optimizers (tiny bit higer RAM usage if capacity size is too big)")]
		public int SingleContainerCapacity = 300;

		[Tooltip("Drawing Human Size Reference sprite in scene view next to manager's position")]
		public bool DrawHumanSizeRefIcon;

		public bool UpdateOptimizersSystem = true;

		public static bool DrawGizmos = false;

		public static readonly LayerMask LM_TransparentFX = 1;

		private static OptimizersManager _get;

		private static bool _wasSearchingManager = false;

		[Tooltip("Main rendering camera reference")]
		public Camera TargetCamera;

		[Tooltip("If you use VR SDK or some auto main camera creation/assign logics, increase this value to for example 3 to let engine do main camera calculations and then assign new camera for optimizers automatically")]
		public int GetCameraAfter;

		private Camera _lastcamera;

		private static Camera _mainCam;

		private Vector3 previousCameraPositionMoveTrigger;

		private List<List<Optimizer_Base>> dynamicLists;

		private bool existThroughScenes;

		private bool initialized;

		public static bool AppIsQuitting = false;

		public bool UseDOTSProgressiveCulling;

		[Tooltip("Which Layers should be treated as obstacles in sight.\nIf it's the same like 'OptimizersCullingLayer' then only objects with optimizers will be able to cover other objects with optimizers.\nUse another layers to make them cover optimized objects (without optimizers will not be hidden - they will be just sight obstacles).")]
		public LayerMask ProgressiveCullingMask = 16;

		[Tooltip("Layer for optimizers detection colliders, should be unique for better performance. (this layer will be applied for culling detection colliders generated when game starts)")]
		[FPD_Layers]
		public int OptimizersCullingLayer = 4;

		[Tooltip("Allowing raycasts going through objects with 'Is Obstacle = false' under OptimizerReference component. Means it can be used for example on lights -> can be occluded but can't occlude others")]
		public bool SupportNotObstacles = true;

		[Tooltip("Higher value = shorter time for disappearing objects outside camera frustum and higher precision but slightly bigger load on performance.\nIf your scene have a lot of small detail objects for culling you should put response quality higher but if your scenes have just many medium/sized objects with optimizers on then you can lower it.\nIf some objects starts to disappear and appear every few frames that means response quality is too low.")]
		[SerializeField]
		[Range(250f, 3000f)]
		private int ProgressiveResponseQuality = 1000;

		[Tooltip("Auto Set progress delay to hide objects")]
		public bool ProgAutoDelay = true;

		[Tooltip("Target progress time delay in seconds to hide objects")]
		[SerializeField]
		private float ProgCullDelay = 1.5f;

		private float dots_debug_drawRaysTimer;

		[Tooltip("Enabling drawing raycasts done for progressive culling")]
		public bool DebugProgressiveCasting;

		[Tooltip("Interval for drawing raycasts done by algorithm")]
		[Range(0.01f, 2f)]
		public float DebugProgrFreq = 1f;

		[Tooltip("Drawing all done raycasts, not only ones which hit optimizers")]
		[Range(0f, 1f)]
		public float DebugProgrAllAlpha;

		[Tooltip("Automatically refresh progressive culling range when screen size changes or camera's FOV")]
		public bool AutoDetectFOVAndScreenChange;

		private Vector2 dots_preScreen;

		private float dots_preFOV = 60f;

		private bool dots_triggerRefresh;

		private bool dots_paused;

		private NativeList<int> dots_VisibleIds;

		private NativeList<int> dots_HittedId;

		private NativeList<float> dots_DelayElapsed;

		private NativeList<JobHandle> dots_JobHandles;

		private NativeList<JobHandle> dots_JobHandlesTr;

		private NativeArray<float3> dots_Rays;

		private NativeArray<RaycastHit> dots_HitsResults;

		private NativeArray<RaycastCommand> dots_RayCommands;

		private NativeList<float3> dots_TransparentHitPoints;

		private NativeArray<RaycastHit> dots_TrHitsResults;

		private NativeArray<RaycastCommand> dots_TransparentRayCommands;

		private int dots_Progressed;

		private readonly List<Optimizer_Base> dots_OptimizersList = new List<Optimizer_Base>();

		private readonly Dictionary<Optimizer_Base, int> dots_OptToId = new Dictionary<Optimizer_Base, int>();

		private readonly Dictionary<int, Optimizer_Base> dots_IdToOpt = new Dictionary<int, Optimizer_Base>();

		private readonly List<int> dots_ToRemoveOpt = new List<int>();

		private static Mesh _mesh_cube;

		private static Mesh _mesh_sphere;

		public List<Optimizer_Base> notContainedStaticOptimizers = new List<Optimizer_Base>();

		public List<Optimizer_Base> notContainedDynamicOptimizers = new List<Optimizer_Base>();

		public List<Optimizer_Base> notContainedEffectiveOptimizers = new List<Optimizer_Base>();

		public List<Optimizer_Base> notContainedTriggerOptimizers = new List<Optimizer_Base>();

		private Optimizers_CullingContainer _editorToDrawContainer;

		[Header("Dynamic Optimization Parameters")]
		public bool Advanced;

		[Tooltip("Drawing during playmode info on screen")]
		public bool Debugging;

		[Tooltip("If camera is not moving or not rotating there will be ignored some of calculations")]
		public bool DetectCameraFreeze;

		internal static int RaycastsInThisFrame = 0;

		internal static int HiddenObjects = 0;

		[Tooltip("When you adding this component, algorithm is adapting this value as MainCamera Far Clipping planes are setted*\n\nAutomatic optimization distance values basing on main character size - Check human scale gizmo in scene view next to camera (It can need other adjustement anyway - depends of project needs)")]
		public float WorldScale = 2f;

		[Tooltip("What amount of units should move camera/optimized object in previous frame to trigger checking LOD state (if camera and object doesn't move checking LOD state will be ignored - optimization for system)")]
		public float MoveTreshold;

		[Tooltip("If you want to object checking be even quicker (in some cases can affect a little performance but will reponse much quicker)")]
		[Range(0f, 1f)]
		public float UpdateBoost;

		[Tooltip("You can define in which distances optimized objects should be prioritized lower for checking LOD state")]
		public float[] Distances;

		private Optimizers_DynamicClock[] clocks;

		private long totalTimeConsumption;

		private readonly List<Optimizers_Transitioning> transitioningPool = new List<Optimizers_Transitioning>();

		private readonly List<Optimizers_Transitioning> transitioning = new List<Optimizers_Transitioning>();

		public static float MaxDistanceMultiplier
		{
			get
			{
				if (Exists)
				{
					return MaxDistanceMultiplier;
				}
				return 1f;
			}
		}

		public static int InstantTransition { get; private set; }

		public string EditorIconPath
		{
			get
			{
				if (PlayerPrefs.GetInt("OptH", 1) == 0)
				{
					return "";
				}
				return "FIMSpace/Optimizers 2/OptManagerIconSmall";
			}
		}

		public static OptimizersManager Instance
		{
			get
			{
				if (_get == null)
				{
					GenerateOptimizersManager();
				}
				if (_get == null)
				{
					return UnityEngine.Object.FindObjectOfType<OptimizersManager>();
				}
				return _get;
			}
			private set
			{
				_get = value;
			}
		}

		public static bool Exists
		{
			get
			{
				if (_get == null)
				{
					if (_wasSearchingManager)
					{
						return false;
					}
					OptimizersManager optimizersManager = UnityEngine.Object.FindObjectOfType<OptimizersManager>();
					_wasSearchingManager = true;
					if (optimizersManager == null)
					{
						return false;
					}
					optimizersManager.SetGet();
				}
				return _get != null;
			}
		}

		public static Camera MainCamera
		{
			get
			{
				if (_mainCam == null)
				{
					GetMainCamera();
				}
				return _mainCam;
			}
			private set
			{
				_mainCam = value;
			}
		}

		public Dictionary<int, Optimizers_CullingContainersList> CullingContainersIDSpecific { get; private set; }

		public Plane[] CurrentFrustumPlanes { get; private set; }

		public Optimizers_DynamicClock[] GetClocks => clocks;

		public void OnDrop(PointerEventData data)
		{
		}

		private static void GenerateOptimizersManager()
		{
			OptimizersManager optimizersManager = UnityEngine.Object.FindObjectOfType<OptimizersManager>();
			if (!optimizersManager)
			{
				GameObject obj = new GameObject("Generated Optimizers Manager");
				obj.transform.SetAsFirstSibling();
				optimizersManager = obj.AddComponent<OptimizersManager>();
			}
			_get = optimizersManager;
			Instance = optimizersManager;
			if (Application.isPlaying)
			{
				Instance.Init();
			}
		}

		private static void GetMainCamera(bool hard = false)
		{
			Camera mainCam = _mainCam;
			Camera camera = Camera.main;
			if (camera == null)
			{
				camera = UnityEngine.Object.FindObjectOfType<Camera>();
				if ((bool)camera)
				{
					Debug.LogWarning("[OPTIMIZERS] There is no object with 'MainCamera' Tag!");
				}
				else if (FEditor_OneShotLog.CanDrawLog("OptNoCamera", 10))
				{
					Debug.LogWarning("[OPTIMIZERS] There is no camera on the scene!");
				}
			}
			_mainCam = camera;
			Instance.TargetCamera = camera;
			if (mainCam != camera)
			{
				SetNewMainCamera(camera);
			}
		}

		public void SetGet()
		{
			OptimizersManager optimizersManager = UnityEngine.Object.FindObjectOfType<OptimizersManager>();
			bool flag = false;
			if ((bool)optimizersManager && optimizersManager != this)
			{
				if (Application.isPlaying)
				{
					Debug.LogWarning("[OPTIMIZERS] There can't be two Optimizers Managers at the same time! I'm removing new one!");
					UnityEngine.Object.Destroy(this);
					flag = true;
				}
				else
				{
					Debug.LogWarning("[OPTIMIZERS EDITOR] There can't be two Optimizers Managers at the same time! I'm removing previous one!");
					UnityEngine.Object.DestroyImmediate(optimizersManager);
					flag = true;
				}
			}
			if (flag)
			{
				return;
			}
			if (_get != null && _get != this)
			{
				if (Application.isPlaying)
				{
					Debug.LogWarning("[OPTIMIZERS] There can't be two Optimizers Managers at the same time! I'm removing new one!");
					UnityEngine.Object.Destroy(this);
				}
				else
				{
					Debug.LogWarning("[OPTIMIZERS EDITOR] There can't be two Optimizers Managers at the same time! I'm removing previous one!");
					UnityEngine.Object.DestroyImmediate(_get);
				}
			}
			else
			{
				Instance = this;
			}
		}

		public static void SetNewMainCamera(Camera camera)
		{
			if (camera == null)
			{
				return;
			}
			MainCamera = camera;
			Instance._lastcamera = MainCamera;
			Instance.TargetCamera = MainCamera;
			foreach (Optimizer_Base notContainedStaticOptimizer in Instance.notContainedStaticOptimizers)
			{
				notContainedStaticOptimizer.RefreshCamera(camera);
			}
			foreach (Optimizer_Base notContainedDynamicOptimizer in Instance.notContainedDynamicOptimizers)
			{
				notContainedDynamicOptimizer.RefreshCamera(camera);
			}
			foreach (Optimizer_Base notContainedEffectiveOptimizer in Instance.notContainedEffectiveOptimizers)
			{
				notContainedEffectiveOptimizer.RefreshCamera(camera);
			}
			foreach (Optimizer_Base notContainedTriggerOptimizer in Instance.notContainedTriggerOptimizers)
			{
				notContainedTriggerOptimizer.RefreshCamera(camera);
			}
			SetNewMainCameraForContainers(camera);
			InstantTransition = 2;
			DOTS_RefreshCamera();
		}

		public static void SetNewMainCameraForContainers(Camera camera)
		{
			MainCamera = camera;
			if (Instance.CullingContainersIDSpecific != null)
			{
				foreach (KeyValuePair<int, Optimizers_CullingContainersList> item in Instance.CullingContainersIDSpecific)
				{
					for (int i = 0; i < item.Value.Count; i++)
					{
						item.Value[i].SetNewCamera(camera);
					}
				}
			}
			Instance.InitCameraFrustum();
		}

		public static void SwitchOptimizersOnOrOff(bool on = true, bool refreshLODStates = true, bool newSwitchingApproach = true)
		{
			if (!Instance)
			{
				return;
			}
			if (refreshLODStates)
			{
				if (newSwitchingApproach)
				{
					SwitchCurrentOptimizersOnOrOff(on);
				}
				else if (!on)
				{
					Optimizer_Base[] array = UnityEngine.Object.FindObjectsOfType<Optimizer_Base>();
					foreach (Optimizer_Base optimizer_Base in array)
					{
						if (optimizer_Base.CullingGroup != null)
						{
							optimizer_Base.CullingGroup.enabled = on;
						}
						optimizer_Base.ChangeLODLevelTo(0);
					}
				}
				else
				{
					Optimizer_Base[] array = UnityEngine.Object.FindObjectsOfType<Optimizer_Base>();
					foreach (Optimizer_Base optimizer_Base2 in array)
					{
						if (optimizer_Base2.CullingGroup != null)
						{
							optimizer_Base2.CullingGroup.enabled = on;
						}
						optimizer_Base2.ChangeLODLevelTo(optimizer_Base2.PreviousLODLevel);
					}
				}
			}
			else
			{
				Optimizer_Base[] array = UnityEngine.Object.FindObjectsOfType<Optimizer_Base>();
				foreach (Optimizer_Base optimizer_Base3 in array)
				{
					if (optimizer_Base3.CullingGroup != null)
					{
						optimizer_Base3.CullingGroup.enabled = on;
					}
				}
			}
			Instance.enabled = on;
		}

		public static void SwitchCurrentOptimizersOnOrOff(bool on = true)
		{
			if (!Instance)
			{
				return;
			}
			if (!on)
			{
				Optimizer_Base[] array = UnityEngine.Object.FindObjectsOfType<Optimizer_Base>();
				for (int i = 0; i < array.Length; i++)
				{
					array[i].SwitchOFFOptimizer();
				}
			}
			else
			{
				Optimizer_Base[] array = UnityEngine.Object.FindObjectsOfType<Optimizer_Base>();
				for (int i = 0; i < array.Length; i++)
				{
					array[i].SwitchONOptimizer();
				}
			}
		}

		private static int GetDistanceTypesCount()
		{
			return Enum.GetValues(typeof(EOptimizingDistance)).Length;
		}

		private void Awake()
		{
			Optimizer_Base._RefreshHandleUnityLOD();
			AppIsQuitting = false;
			if (!Application.isPlaying)
			{
				SetGet();
			}
			else
			{
				Init();
			}
		}

		private void Start()
		{
			Init();
			if (GetCameraAfter > 0)
			{
				StartCoroutine(CGetCamera(GetCameraAfter));
			}
		}

		private void Reset()
		{
			GetMainCamera();
			if ((bool)MainCamera)
			{
				WorldScale = (float)Math.Round(MainCamera.farClipPlane / 520f, 2);
			}
		}

		public void Init()
		{
			if (initialized || !UpdateOptimizersSystem)
			{
				return;
			}
			SetGet();
			if (Instance != this)
			{
				Instance.CleanLevelDatas();
				return;
			}
			if (Application.isPlaying)
			{
				if (ExistThroughScenes)
				{
					UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
					existThroughScenes = true;
				}
				dynamicLists = new List<List<Optimizer_Base>>();
				CullingContainersIDSpecific = new Dictionary<int, Optimizers_CullingContainersList>();
				initialized = true;
				GenerateClocks();
				RefreshDistances();
				RunDynamicClocks();
			}
			InstantTransition = 0;
			InitCameraFrustum();
			AppIsQuitting = false;
			DOTS_Initialize();
		}

		private void InitCameraFrustum()
		{
			if ((bool)MainCamera)
			{
				Instance.CurrentFrustumPlanes = GeometryUtility.CalculateFrustumPlanes(MainCamera);
			}
			else
			{
				Instance.CurrentFrustumPlanes = new Plane[6];
			}
		}

		private void Update()
		{
			if (UpdateOptimizersSystem)
			{
				DOTS_PreUpdate();
			}
		}

		private void LateUpdate()
		{
			if (!UpdateOptimizersSystem)
			{
				return;
			}
			if (!existThroughScenes && ExistThroughScenes)
			{
				UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
			}
			if (TargetCamera == null)
			{
				GetMainCamera();
				SetNewMainCamera(TargetCamera);
				if (TargetCamera != null)
				{
					Debug.Log("[OPTIMIZERS] New Camera detected and assigned! " + TargetCamera.name);
				}
			}
			else
			{
				if (TargetCamera != MainCamera)
				{
					SetNewMainCamera(TargetCamera);
					Debug.Log("[OPTIMIZERS] New Camera detected and assigned! " + TargetCamera.name);
				}
				DOTS_PostUpdate();
				TransitionsUpdate();
				DynamicUpdate();
			}
			if (InstantTransition > 0)
			{
				InstantTransition--;
			}
		}

		public void OnValidate()
		{
			if (!(Instance != this))
			{
				if (_lastcamera != TargetCamera)
				{
					SetNewMainCamera(TargetCamera);
				}
				if (TargetCamera != null && TargetCamera != MainCamera)
				{
					MainCamera = TargetCamera;
				}
				if (WorldScale <= 0f)
				{
					WorldScale = 0.1f;
				}
				if (!Advanced)
				{
					MoveTreshold = WorldScale / (150f * (1f + UpdateBoost));
				}
				RefreshDistances();
				if (!Advanced)
				{
					Debugging = false;
				}
				if (GetCameraAfter < 0)
				{
					GetCameraAfter = 0;
				}
				TargetCamera = MainCamera;
				if (SingleContainerCapacity < 25)
				{
					SingleContainerCapacity = 25;
				}
				if (SingleContainerCapacity > 10000)
				{
					SingleContainerCapacity = 10000;
				}
				DOTS_AutomaticallySetCullDelayDuration();
			}
		}

		private IEnumerator CGetCamera(int framesDelay, bool hard = false)
		{
			for (int elapsed = 0; elapsed < framesDelay; elapsed++)
			{
				yield return null;
			}
			GetMainCamera(hard);
		}

		private void CleanLevelDatas()
		{
			for (int num = transitioning.Count - 1; num >= 0; num--)
			{
				if (transitioning[num] == null)
				{
					transitioning.RemoveAt(num);
				}
				else if (transitioning[num].Optimizer == null)
				{
					transitioning.RemoveAt(num);
				}
				else if (transitioning[num].Finished)
				{
					transitioning.RemoveAt(num);
				}
			}
			for (int num2 = notContainedDynamicOptimizers.Count - 1; num2 >= 0; num2--)
			{
				if (notContainedDynamicOptimizers[num2] == null)
				{
					notContainedDynamicOptimizers.RemoveAt(num2);
				}
			}
			for (int num3 = notContainedEffectiveOptimizers.Count - 1; num3 >= 0; num3--)
			{
				if (notContainedEffectiveOptimizers[num3] == null)
				{
					notContainedEffectiveOptimizers.RemoveAt(num3);
				}
			}
			for (int num4 = notContainedStaticOptimizers.Count - 1; num4 >= 0; num4--)
			{
				if (notContainedStaticOptimizers[num4] == null)
				{
					notContainedStaticOptimizers.RemoveAt(num4);
				}
			}
			for (int num5 = notContainedTriggerOptimizers.Count - 1; num5 >= 0; num5--)
			{
				if (notContainedTriggerOptimizers[num5] == null)
				{
					notContainedTriggerOptimizers.RemoveAt(num5);
				}
			}
			GetMainCamera(hard: true);
			if (MainCamera == null)
			{
				Debug.Log("[OPTIMIZERS WARNING] NO MAIN CAMERA DETECTED!");
			}
		}

		private void OnApplicationQuit()
		{
			AppIsQuitting = true;
		}

		public void SetGlobalMaxDistanceMultiplier(float value)
		{
			GlobalMaxDistanceMultiplier = value;
		}

		private IEnumerator QueueAddCamera(Camera camera)
		{
			yield return new WaitForEndOfFrame();
			yield return new WaitForEndOfFrame();
			yield return null;
			yield return null;
			yield return null;
			Vector3 pos = camera.transform.position;
			Quaternion rot = camera.transform.rotation;
			yield return null;
			yield return null;
			yield return null;
			yield return new WaitForEndOfFrame();
			yield return new WaitForEndOfFrame();
			camera.transform.position = Vector3.one * 10000f;
			camera.transform.rotation = Quaternion.Euler(-90f, 0f, 0f);
			yield return null;
			yield return null;
			yield return null;
			yield return null;
			yield return null;
			if (camera == null)
			{
				yield break;
			}
			MainCamera = camera;
			Instance._lastcamera = MainCamera;
			Instance.TargetCamera = MainCamera;
			foreach (Optimizer_Base notContainedStaticOptimizer in Instance.notContainedStaticOptimizers)
			{
				notContainedStaticOptimizer.RefreshCamera(camera);
			}
			foreach (Optimizer_Base notContainedDynamicOptimizer in Instance.notContainedDynamicOptimizers)
			{
				notContainedDynamicOptimizer.RefreshCamera(camera);
			}
			foreach (Optimizer_Base notContainedEffectiveOptimizer in Instance.notContainedEffectiveOptimizers)
			{
				notContainedEffectiveOptimizer.RefreshCamera(camera);
			}
			foreach (Optimizer_Base notContainedTriggerOptimizer in Instance.notContainedTriggerOptimizers)
			{
				notContainedTriggerOptimizer.RefreshCamera(camera);
			}
			SetNewMainCameraForContainers(camera);
			InstantTransition = 2;
			DOTS_RefreshCamera();
			if (pos != Vector3.one * 10000f)
			{
				camera.transform.position = pos;
				camera.transform.rotation = rot;
			}
		}

		private void DOTS_Initialize()
		{
			if (Instance.UseDOTSProgressiveCulling)
			{
				dots_VisibleIds = new NativeList<int>(Allocator.Persistent);
				dots_HittedId = new NativeList<int>(Allocator.Persistent);
				dots_DelayElapsed = new NativeList<float>(Allocator.Persistent);
				dots_JobHandles = new NativeList<JobHandle>(Allocator.Persistent);
				dots_JobHandlesTr = new NativeList<JobHandle>(Allocator.Persistent);
				Instance.dots_TransparentHitPoints = new NativeList<float3>(Allocator.Persistent);
				_mesh_cube = CreatePrimitiveMesh(PrimitiveType.Cube);
				_mesh_sphere = CreatePrimitiveMesh(PrimitiveType.Sphere);
				DOTS_RefreshCamera();
				DOTS_AutomaticallySetCullDelayDuration();
			}
		}

		public static void DOTS_RefreshCamera()
		{
			if (Instance.UseDOTSProgressiveCulling)
			{
				if (Instance.dots_RayCommands.IsCreated)
				{
					Instance.dots_RayCommands.Dispose();
				}
				if (Instance.dots_HitsResults.IsCreated)
				{
					Instance.dots_HitsResults.Dispose();
				}
				Instance.dots_RayCommands = new NativeArray<RaycastCommand>(Instance.ProgressiveResponseQuality, Allocator.Persistent);
				Instance.dots_HitsResults = new NativeArray<RaycastHit>(Instance.ProgressiveResponseQuality, Allocator.Persistent);
				Instance.DOTS_RefreshRaycastFrustum();
				Instance.dots_preScreen = new Vector2(Screen.width, Screen.height);
				if (Instance.TargetCamera != null)
				{
					Instance.dots_preFOV = Instance.TargetCamera.fieldOfView;
				}
			}
		}

		private void DOTS_PreUpdate()
		{
			if (Instance.UseDOTSProgressiveCulling)
			{
				if (AutoDetectFOVAndScreenChange)
				{
					DOTS_CheckScreenAndFOVChange();
				}
				DOTS_ScheduleRaycasting();
				if (SupportNotObstacles)
				{
					DOTS_ScheduleTrasnparentRaycasting();
				}
			}
		}

		private void DOTS_PostUpdate()
		{
			if (!Instance.UseDOTSProgressiveCulling)
			{
				return;
			}
			JobHandle.CompleteAll(dots_JobHandles);
			if (SupportNotObstacles)
			{
				JobHandle.CompleteAll(dots_JobHandlesTr);
				dots_TransparentHitPoints.Clear();
			}
			ApplyHitsResults(dots_HitsResults);
			if (SupportNotObstacles)
			{
				ApplyHitsResults(dots_TrHitsResults);
			}
			IJobExtensions.Schedule(new GetResultsJob
			{
				visible = dots_VisibleIds,
				hitted = dots_HittedId,
				elapsed = dots_DelayElapsed
			}).Complete();
			int num = 0;
			while (num < dots_VisibleIds.Length)
			{
				int num2 = dots_VisibleIds[num];
				try
				{
					if (dots_DelayElapsed[num] > ProgCullDelay)
					{
						dots_IdToOpt[num2].DOTSObstacleCheck(visible: false);
						dots_VisibleIds.RemoveAtSwapBack(num);
						dots_DelayElapsed.RemoveAtSwapBack(num);
					}
					else
					{
						dots_IdToOpt[num2].DOTSObstacleCheck(visible: true);
						num++;
					}
				}
				catch (MissingReferenceException)
				{
					dots_ToRemoveOpt.Add(num2);
					num++;
				}
			}
			DOTS_HandleRemoving();
			if (DebugProgressiveCasting)
			{
				dots_debug_drawRaysTimer -= Time.deltaTime;
				if (dots_debug_drawRaysTimer < 0f)
				{
					dots_debug_drawRaysTimer = DebugProgrFreq;
					DOTS_DebugDrawRaycasts();
				}
			}
		}

		private void ApplyHitsResults(NativeArray<RaycastHit> results)
		{
			for (int i = 0; i < results.Length; i++)
			{
				if (!(results[i].collider != null))
				{
					continue;
				}
				OptimizersReference component = results[i].collider.GetComponent<OptimizersReference>();
				if (!component)
				{
					continue;
				}
				if (component.Parent == null)
				{
					UnityEngine.Object.Destroy(component);
					continue;
				}
				dots_HittedId.Add(dots_OptToId[component.Parent]);
				if (SupportNotObstacles && !component.IsObstacle)
				{
					dots_TransparentHitPoints.Add((float3)(results[i].point - results[i].normal * results[i].distance * 0.01f));
				}
			}
		}

		private void DOTS_CheckScreenAndFOVChange()
		{
			Vector2 vector = new Vector2(Screen.width, Screen.height);
			if (dots_preScreen != vector)
			{
				dots_triggerRefresh = true;
			}
			else if (TargetCamera != null && dots_preFOV != TargetCamera.fieldOfView)
			{
				dots_triggerRefresh = true;
			}
			if (!dots_paused && Application.isFocused && Application.isPlaying && dots_triggerRefresh)
			{
				DOTS_RefreshCamera();
				dots_triggerRefresh = false;
			}
			if (TargetCamera != null)
			{
				dots_preFOV = TargetCamera.fieldOfView;
			}
			dots_preScreen = vector;
		}

		private void OnApplicationPause(bool pause)
		{
			dots_paused = pause;
		}

		private Transform DOTS_GenerateContainerFor(Transform parent, Vector3 localOffset)
		{
			Transform obj = new GameObject("Optimizers-DOTS Culling Helper").transform;
			obj.SetParent(parent.transform);
			obj.localPosition = localOffset;
			obj.localRotation = Quaternion.identity;
			obj.localScale = Vector3.one;
			return obj;
		}

		private void DOTS_AttachCollider(Transform parent, Mesh collision, Optimizer_Base optimizer, bool isObstacle)
		{
			MeshCollider meshCollider = parent.gameObject.AddComponent<MeshCollider>();
			meshCollider.gameObject.layer = OptimizersCullingLayer;
			meshCollider.sharedMesh = collision;
			OptimizersReference optimizersReference = parent.gameObject.AddComponent<OptimizersReference>();
			optimizersReference.Parent = optimizer;
			optimizersReference.IsObstacle = isObstacle;
		}

		private void DOTS_AddToCullingLists(Optimizer_Base optimizer, int id)
		{
			dots_IdToOpt.Add(id, optimizer);
			dots_OptToId.Add(optimizer, id);
			dots_OptimizersList.Add(optimizer);
		}

		private void DOTS_ScheduleRaycasting()
		{
			dots_JobHandles.Clear();
			dots_HittedId.Clear();
			CreateRayCommandsJob jobData = new CreateRayCommandsJob
			{
				position = MainCamera.transform.position,
				rotation = MainCamera.transform.rotation,
				rayCastCycleOffset = dots_Progressed,
				rayDirs = dots_Rays,
				maxDistance = MainCamera.farClipPlane,
				mask = ProgressiveCullingMask,
				rayCommands = dots_RayCommands
			};
			dots_JobHandles.Add(IJobParallelForExtensions.Schedule(jobData, ProgressiveResponseQuality, 64));
			dots_Progressed += ProgressiveResponseQuality;
			if (dots_Progressed >= dots_Rays.Length - ProgressiveResponseQuality)
			{
				dots_Progressed = 0;
			}
			JobHandle.CompleteAll(dots_JobHandles);
			dots_JobHandles.Clear();
			dots_JobHandles.Add(RaycastCommand.ScheduleBatch(dots_RayCommands, dots_HitsResults, 1));
			CullingDelayJob jobData2 = new CullingDelayJob
			{
				elapsed = dots_DelayElapsed,
				delta = Time.deltaTime
			};
			dots_JobHandles.Add(IJobExtensions.Schedule(jobData2));
		}

		private void DOTS_ScheduleTrasnparentRaycasting()
		{
			dots_JobHandlesTr.Clear();
			if (Instance.dots_TrHitsResults.IsCreated)
			{
				Instance.dots_TrHitsResults.Dispose();
			}
			Instance.dots_TrHitsResults = new NativeArray<RaycastHit>(dots_TransparentHitPoints.Length, Allocator.Persistent);
			if (Instance.dots_TransparentRayCommands.IsCreated)
			{
				Instance.dots_TransparentRayCommands.Dispose();
			}
			Instance.dots_TransparentRayCommands = new NativeArray<RaycastCommand>(dots_TransparentHitPoints.Length, Allocator.Persistent);
			CreateTransparentRayCommandsJob jobData = new CreateTransparentRayCommandsJob
			{
				position = MainCamera.transform.position,
				rayPoints = dots_TransparentHitPoints,
				maxDistance = MainCamera.farClipPlane,
				mask = ProgressiveCullingMask,
				rayCommands = dots_TransparentRayCommands
			};
			dots_JobHandlesTr.Add(IJobParallelForExtensions.Schedule(jobData, dots_TransparentHitPoints.Length, 32));
			JobHandle.CompleteAll(dots_JobHandlesTr);
			dots_JobHandlesTr.Clear();
			dots_JobHandlesTr.Add(RaycastCommand.ScheduleBatch(dots_TransparentRayCommands, dots_TrHitsResults, 1));
		}

		public void DOTS_AddOptimizer(Optimizer_Base optimizer)
		{
			if (optimizer == null || !optimizer.UseDOTS || !Instance.UseDOTSProgressiveCulling)
			{
				return;
			}
			int instanceID = optimizer.GetInstanceID();
			if (dots_IdToOpt.ContainsKey(instanceID) || dots_OptimizersList.Contains(optimizer))
			{
				return;
			}
			bool flag = true;
			if (optimizer.DOTSDetection == EDOTSDetection.Auto && optimizer.DOTSMeshData != null && optimizer.DOTSMeshData.Count != 0)
			{
				for (int i = 0; i < optimizer.DOTSMeshData.Count; i++)
				{
					if (optimizer.DOTSMeshData[i].SharedMesh != null && optimizer.DOTSMeshData[i].SceneTransform != null)
					{
						flag = false;
						break;
					}
				}
			}
			bool flag2 = optimizer.DOTSObstacleType == EDOTSObstacle.StopRays || optimizer.DOTSObstacleType == EDOTSObstacle.Auto;
			if (optimizer.DOTSObstacleType == EDOTSObstacle.Auto)
			{
				for (int j = 0; j < optimizer.GetToOptimizeCount(); j++)
				{
					if (!flag2)
					{
						break;
					}
					Component optimizedComponent = optimizer.GetOptimizedComponent(j);
					if (!(optimizedComponent == null))
					{
						if ((bool)(optimizedComponent as SkinnedMeshRenderer))
						{
							flag2 = false;
						}
						if ((bool)(optimizedComponent as Light))
						{
							flag2 = false;
						}
						if ((bool)(optimizedComponent as ParticleSystem))
						{
							flag2 = false;
						}
					}
				}
			}
			if (!SupportNotObstacles && !flag2)
			{
				return;
			}
			if (optimizer.DOTSDetection == EDOTSDetection.Custom)
			{
				foreach (OptimizersReference item in Optimizer_Base.FindComponentsInAllChildren<OptimizersReference>(optimizer.transform))
				{
					if (!(item.Parent != null) || !(item.Parent != optimizer))
					{
						item.Parent = optimizer;
						item.gameObject.layer = OptimizersCullingLayer;
					}
				}
			}
			else if (flag)
			{
				Transform transform = null;
				Mesh mesh = null;
				if (optimizer.DOTSDetection != EDOTSDetection.Auto)
				{
					transform = DOTS_GenerateContainerFor(optimizer.transform, optimizer.DOTSOffset);
					if (optimizer.DOTSDetection == EDOTSDetection.Cube)
					{
						transform.localScale = optimizer.DOTSSize;
						mesh = _mesh_cube;
					}
					else
					{
						transform.localScale = Vector3.one * optimizer.DOTSRadius * 2f;
						mesh = _mesh_sphere;
					}
				}
				if (transform == null || mesh == null)
				{
					return;
				}
				DOTS_AttachCollider(transform, mesh, optimizer, flag2);
			}
			else if (optimizer.DOTSDetection == EDOTSDetection.Auto)
			{
				for (int k = 0; k < optimizer.DOTSMeshData.Count; k++)
				{
					Optimizer_Base.DOTS_DetectionData dOTS_DetectionData = optimizer.DOTSMeshData[k];
					if (dOTS_DetectionData != null && !(dOTS_DetectionData.SceneTransform == null) && !(dOTS_DetectionData.SharedMesh == null))
					{
						Transform parent = DOTS_GenerateContainerFor(dOTS_DetectionData.SceneTransform, Vector3.zero);
						DOTS_AttachCollider(parent, dOTS_DetectionData.SharedMesh, optimizer, flag2);
					}
				}
			}
			DOTS_AddToCullingLists(optimizer, instanceID);
			optimizer.DOTSObstacleCheck(visible: false);
		}

		public void DOTS_RemoveOptimizer(Optimizer_Base optimizer)
		{
			if (!Instance.UseDOTSProgressiveCulling)
			{
				return;
			}
			if (optimizer.UseDOTS && dots_OptimizersList.Contains(optimizer))
			{
				dots_OptimizersList.Remove(optimizer);
			}
			if (dots_IdToOpt.ContainsValue(optimizer))
			{
				int key = dots_IdToOpt.First((KeyValuePair<int, Optimizer_Base> findId) => findId.Value == optimizer).Key;
				dots_ToRemoveOpt.Add(key);
			}
		}

		private void DOTS_HandleRemoving()
		{
			if (Instance.UseDOTSProgressiveCulling)
			{
				for (int i = 0; i < dots_ToRemoveOpt.Count; i++)
				{
					DOTS_InternalRemove(dots_ToRemoveOpt[i]);
				}
				dots_ToRemoveOpt.Clear();
			}
		}

		private void DOTS_InternalRemove(int id)
		{
			if (Instance.UseDOTSProgressiveCulling && dots_IdToOpt.ContainsKey(id))
			{
				dots_IdToOpt.Remove(id);
				int num = dots_VisibleIds.IndexOf(id);
				if (num >= 0)
				{
					dots_VisibleIds.RemoveAtSwapBack(num);
					dots_DelayElapsed.RemoveAtSwapBack(num);
				}
			}
		}

		private static Mesh CreatePrimitiveMesh(PrimitiveType type)
		{
			GameObject obj = GameObject.CreatePrimitive(type);
			Mesh sharedMesh = obj.GetComponent<MeshFilter>().sharedMesh;
			UnityEngine.Object.Destroy(obj);
			return sharedMesh;
		}

		private float DOTS_PointDisperse(int index, int baseV)
		{
			float num = 0f;
			float num2 = 1f / (float)baseV;
			int num3 = index;
			while (num3 > 0)
			{
				num += num2 * (float)(num3 % baseV);
				num3 = Mathf.FloorToInt(num3 / baseV);
				num2 /= (float)baseV;
			}
			return num;
		}

		private void DOTS_RefreshRaycastFrustum()
		{
			int length = Mathf.RoundToInt((float)(Screen.width * Screen.height / 4) / (float)ProgressiveResponseQuality) * ProgressiveResponseQuality;
			if (dots_Rays.IsCreated)
			{
				dots_Rays.Dispose();
			}
			dots_Rays = new NativeArray<float3>(length, Allocator.Persistent);
			Vector3 position = MainCamera.transform.position;
			quaternion quaternion2 = MainCamera.transform.rotation;
			float fieldOfView = MainCamera.fieldOfView;
			MainCamera.fieldOfView += 1f;
			MainCamera.transform.position = Vector3.zero;
			MainCamera.transform.rotation = Quaternion.identity;
			for (int i = 0; i < dots_Rays.Length; i++)
			{
				Vector2 vector = new Vector2(DOTS_PointDisperse(i, 2), DOTS_PointDisperse(i, 3));
				Ray ray = MainCamera.ViewportPointToRay(new Vector3(vector.x, vector.y, 0f));
				dots_Rays[i] = ray.direction;
			}
			MainCamera.transform.position = position;
			MainCamera.transform.rotation = quaternion2;
			MainCamera.fieldOfView = fieldOfView;
		}

		private void DOTS_DebugDrawRaycasts()
		{
			NativeArray<RaycastHit> nativeArray = dots_HitsResults;
			NativeArray<RaycastHit> nativeArray2 = dots_TrHitsResults;
			Color color = new Color(0.9f, 0.25f, 0.4f, 0.02f * DebugProgrAllAlpha);
			if (DebugProgrAllAlpha > 0f)
			{
				if (DebugProgrFreq < 0.3f)
				{
					DebugProgrFreq = 0.3f;
				}
				for (int i = 0; i < dots_Rays.Length; i++)
				{
					Debug.DrawRay(MainCamera.transform.position, MainCamera.transform.rotation * dots_Rays[i] * MainCamera.farClipPlane, color, UnityEngine.Random.Range(0.35f, 0.9f) * DebugProgrFreq);
				}
			}
			Color color2 = new Color(0f, 1f, 0f, 0.75f);
			Color color3 = new Color(0f, 0f, 0f, 0.5f);
			Color color4 = new Color(0.8f, 0.8f, 0.8f, 0.1f);
			for (int j = 0; j < nativeArray.Length; j++)
			{
				if (!nativeArray[j].collider)
				{
					continue;
				}
				if ((bool)nativeArray[j].collider.gameObject.GetComponent<OptimizersReference>())
				{
					if (nativeArray[j].collider.gameObject.GetComponent<OptimizersReference>().IsObstacle)
					{
						Debug.DrawLine(MainCamera.transform.position, nativeArray[j].point, color2, UnityEngine.Random.Range(0.8f, 1f) * DebugProgrFreq);
					}
					else
					{
						Debug.DrawLine(MainCamera.transform.position, nativeArray[j].point, color4, UnityEngine.Random.Range(0.8f, 1f) * DebugProgrFreq);
					}
				}
				else
				{
					Debug.DrawLine(MainCamera.transform.position, nativeArray[j].point, color3, UnityEngine.Random.Range(0.8f, 1f) * DebugProgrFreq);
				}
			}
			if (!SupportNotObstacles)
			{
				return;
			}
			if (dots_TransparentHitPoints.Length > 0)
			{
				Color color5 = new Color(0.8f, 0.8f, 0.8f, 0.01f);
				for (int k = 0; k < dots_TransparentHitPoints.Length; k++)
				{
					Vector3 vector = (Vector3)dots_TransparentHitPoints[k] - MainCamera.transform.position;
					Debug.DrawRay(dots_TransparentHitPoints[k], vector.normalized * (MainCamera.farClipPlane - vector.magnitude), color5, UnityEngine.Random.Range(0.8f, 1f) * DebugProgrFreq);
				}
			}
			color2 = new Color(0f, 1f, 1f, 1f);
			for (int l = 0; l < nativeArray2.Length; l++)
			{
				if (!nativeArray2[l].collider)
				{
					continue;
				}
				if ((bool)nativeArray2[l].collider.gameObject.GetComponent<OptimizersReference>())
				{
					if (nativeArray2[l].collider.gameObject.GetComponent<OptimizersReference>().IsObstacle)
					{
						Debug.DrawLine(MainCamera.transform.position, nativeArray2[l].point, color2, UnityEngine.Random.Range(0.8f, 1f) * DebugProgrFreq);
					}
					else
					{
						Debug.DrawLine(MainCamera.transform.position, nativeArray2[l].point, color4, UnityEngine.Random.Range(0.8f, 1f) * DebugProgrFreq);
					}
				}
				else
				{
					Debug.DrawLine(MainCamera.transform.position, nativeArray2[l].point, color3, UnityEngine.Random.Range(0.8f, 1f) * DebugProgrFreq);
				}
			}
		}

		private void DOTS_Dispose()
		{
			if (Instance.UseDOTSProgressiveCulling)
			{
				if (dots_JobHandles.IsCreated && dots_JobHandles.Length > 0)
				{
					JobHandle.CompleteAll(dots_JobHandles);
					dots_JobHandles.Dispose();
				}
				if (dots_Rays.IsCreated)
				{
					dots_Rays.Dispose();
				}
				if (dots_VisibleIds.IsCreated)
				{
					dots_VisibleIds.Dispose();
				}
				if (dots_HittedId.IsCreated)
				{
					dots_HittedId.Dispose();
				}
				if (dots_DelayElapsed.IsCreated)
				{
					dots_DelayElapsed.Dispose();
				}
				dots_RayCommands.Dispose();
				dots_HitsResults.Dispose();
				dots_TransparentHitPoints.Dispose();
				if (SupportNotObstacles)
				{
					dots_TransparentRayCommands.Dispose();
					dots_TrHitsResults.Dispose();
				}
			}
		}

		public void DOTS_AutomaticallySetCullDelayDuration()
		{
			if (ProgAutoDelay)
			{
				float num = Mathf.Lerp(1f, 0.65f, UpdateBoost);
				float num2 = Mathf.Lerp(1f, 0.75f, UpdateBoost);
				if (ProgressiveResponseQuality < 1000)
				{
					ProgCullDelay = Mathf.Lerp(3.5f * num, 2f * num, Mathf.InverseLerp(100f, 1000f, ProgressiveResponseQuality));
				}
				else
				{
					ProgCullDelay = Mathf.Lerp(2f * num, 0.5f * num2, Mathf.InverseLerp(1000f, 6000f, ProgressiveResponseQuality));
				}
			}
		}

		internal void AddToContainer(Optimizer_Base optimizer)
		{
			if (!UpdateOptimizersSystem || optimizer == null)
			{
				return;
			}
			Optimizers_CullingContainer optimizers_CullingContainer = null;
			if (CullingContainersIDSpecific.TryGetValue(optimizer.ContainerGeneratedID, out var value))
			{
				if (!optimizer.UseMultiShape)
				{
					for (int i = 0; i < value.Count; i++)
					{
						if (value[i].HaveFreeSlots)
						{
							optimizers_CullingContainer = value[i];
							break;
						}
					}
				}
				else
				{
					for (int j = 0; j < value.Count; j++)
					{
						if (value[j].HaveFreeSlots && value[j].Optimizers.Length - value[j].SlotsTaken > optimizer.Shapes.Count + 1)
						{
							optimizers_CullingContainer = value[j];
							break;
						}
					}
				}
				if (optimizers_CullingContainer == null)
				{
					optimizers_CullingContainer = GenerateNewContainer(optimizer);
					value.Add(optimizers_CullingContainer);
				}
			}
			else
			{
				value = new Optimizers_CullingContainersList(optimizer.ContainerGeneratedID);
				optimizers_CullingContainer = GenerateNewContainer(optimizer);
				value.Add(optimizers_CullingContainer);
				CullingContainersIDSpecific.Add(optimizer.ContainerGeneratedID, value);
			}
			optimizers_CullingContainer.AddOptimizer(optimizer);
			DOTS_AddOptimizer(optimizer);
		}

		private Optimizers_CullingContainer GenerateNewContainer(Optimizer_Base optimizer)
		{
			Optimizers_CullingContainer optimizers_CullingContainer = new Optimizers_CullingContainer(SingleContainerCapacity);
			optimizers_CullingContainer.InitializeContainer(optimizer.ContainerGeneratedID, optimizer.GetDistanceMeasures(), TargetCamera);
			return optimizers_CullingContainer;
		}

		internal void RemoveFromContainer(Optimizer_Base optimizer)
		{
			if (UpdateOptimizersSystem && !(optimizer == null))
			{
				DOTS_RemoveOptimizer(optimizer);
				optimizer.OwnerContainer.RemoveOptimizer(optimizer);
			}
		}

		private void OnDestroy()
		{
			ClearCullingContainers();
			DOTS_Dispose();
		}

		internal void ClearCullingContainers()
		{
			if (!UpdateOptimizersSystem || CullingContainersIDSpecific == null)
			{
				return;
			}
			foreach (KeyValuePair<int, Optimizers_CullingContainersList> item in CullingContainersIDSpecific)
			{
				item.Value.Dispose();
			}
			CullingContainersIDSpecific.Clear();
		}

		internal void SwitchCullingContainers(bool enable)
		{
			if (!UpdateOptimizersSystem || CullingContainersIDSpecific == null)
			{
				return;
			}
			foreach (KeyValuePair<int, Optimizers_CullingContainersList> item in CullingContainersIDSpecific)
			{
				for (int i = 0; i < item.Value.Count; i++)
				{
					item.Value[i].CullingGroup.enabled = enable;
				}
			}
		}

		public int[] GetContainersIDs()
		{
			int[] array = new int[CullingContainersIDSpecific.Count];
			int num = 0;
			foreach (KeyValuePair<int, Optimizers_CullingContainersList> item in CullingContainersIDSpecific)
			{
				array[num++] = item.Key;
			}
			return array;
		}

		public void RegisterNotContainedOptimizer(Optimizer_Base optimizer, bool init = false)
		{
			switch (optimizer.OptimizingMethod)
			{
			case EOptimizingMethod.Static:
				RegisterNotContainedStaticOptimizer(optimizer, init);
				break;
			case EOptimizingMethod.Dynamic:
				RegisterNotContainedDynamicOptimizer(optimizer, init);
				break;
			case EOptimizingMethod.Effective:
				RegisterNotContainedEffectiveOptimizer(optimizer, init);
				break;
			case EOptimizingMethod.TriggerBased:
				RegisterNotContainedTriggerOptimizer(optimizer, init);
				break;
			}
		}

		public void RegisterNotContainedStaticOptimizer(Optimizer_Base optimizer, bool init = false)
		{
			if (UpdateOptimizersSystem)
			{
				if (init)
				{
					notContainedStaticOptimizers.Add(optimizer);
				}
				else if (!notContainedStaticOptimizers.Contains(optimizer))
				{
					notContainedStaticOptimizers.Add(optimizer);
				}
				DOTS_AddOptimizer(optimizer);
			}
		}

		public void RegisterNotContainedDynamicOptimizer(Optimizer_Base optimizer, bool init = false)
		{
			if (UpdateOptimizersSystem)
			{
				if (init)
				{
					notContainedDynamicOptimizers.Add(optimizer);
				}
				else if (!notContainedDynamicOptimizers.Contains(optimizer))
				{
					notContainedDynamicOptimizers.Add(optimizer);
				}
				DOTS_AddOptimizer(optimizer);
			}
		}

		public void RegisterNotContainedEffectiveOptimizer(Optimizer_Base optimizer, bool init = false)
		{
			if (UpdateOptimizersSystem)
			{
				if (init)
				{
					notContainedEffectiveOptimizers.Add(optimizer);
				}
				else if (!notContainedEffectiveOptimizers.Contains(optimizer))
				{
					notContainedEffectiveOptimizers.Add(optimizer);
				}
				DOTS_AddOptimizer(optimizer);
			}
		}

		public void RegisterNotContainedTriggerOptimizer(Optimizer_Base optimizer, bool init = false)
		{
			if (UpdateOptimizersSystem)
			{
				if (init)
				{
					notContainedTriggerOptimizers.Add(optimizer);
				}
				else if (!notContainedTriggerOptimizers.Contains(optimizer))
				{
					notContainedTriggerOptimizers.Add(optimizer);
				}
				DOTS_AddOptimizer(optimizer);
			}
		}

		public void UnRegisterOptimizer(Optimizer_Base optimizer)
		{
			if (UpdateOptimizersSystem && !optimizer.AddToContainer)
			{
				switch (optimizer.OptimizingMethod)
				{
				case EOptimizingMethod.Static:
					UnRegisterStaticOptimizer(optimizer);
					break;
				case EOptimizingMethod.Dynamic:
					UnRegisterDynamicOptimizer(optimizer);
					break;
				case EOptimizingMethod.Effective:
					UnRegisterEffectiveOptimizer(optimizer);
					break;
				case EOptimizingMethod.TriggerBased:
					UnRegisterTriggerOptimizer(optimizer);
					break;
				}
			}
		}

		public void UnRegisterStaticOptimizer(Optimizer_Base optimizer)
		{
			if (UpdateOptimizersSystem)
			{
				if (notContainedStaticOptimizers.Contains(optimizer))
				{
					notContainedStaticOptimizers.Remove(optimizer);
				}
				DOTS_RemoveOptimizer(optimizer);
			}
		}

		public void UnRegisterDynamicOptimizer(Optimizer_Base optimizer)
		{
			if (UpdateOptimizersSystem)
			{
				if (!notContainedDynamicOptimizers.Contains(optimizer))
				{
					notContainedDynamicOptimizers.Remove(optimizer);
				}
				DOTS_RemoveOptimizer(optimizer);
			}
		}

		public void UnRegisterEffectiveOptimizer(Optimizer_Base optimizer)
		{
			if (UpdateOptimizersSystem)
			{
				if (!notContainedEffectiveOptimizers.Contains(optimizer))
				{
					notContainedEffectiveOptimizers.Remove(optimizer);
				}
				DOTS_RemoveOptimizer(optimizer);
			}
		}

		public void UnRegisterTriggerOptimizer(Optimizer_Base optimizer)
		{
			if (UpdateOptimizersSystem)
			{
				if (!notContainedTriggerOptimizers.Contains(optimizer))
				{
					notContainedTriggerOptimizers.Remove(optimizer);
				}
				DOTS_RemoveOptimizer(optimizer);
			}
		}

		public void DrawBounds(Optimizers_CullingContainer cont)
		{
			_editorToDrawContainer = cont;
		}

		private void GenerateClocks()
		{
			if (UpdateOptimizersSystem && clocks == null)
			{
				clocks = new Optimizers_DynamicClock[GetDistanceTypesCount()];
				for (int i = 0; i < clocks.Length; i++)
				{
					dynamicLists.Add(new List<Optimizer_Base>());
					clocks[i] = new Optimizers_DynamicClock(this, (EOptimizingDistance)i, dynamicLists[i]);
				}
			}
		}

		private void RunDynamicClocks()
		{
			if (UpdateOptimizersSystem)
			{
				StartCoroutine(InitialCall());
				for (int i = 0; i < clocks.Length; i++)
				{
					StartCoroutine(clocks[i].WatchUpdate());
				}
			}
		}

		private void DynamicUpdate()
		{
			if (UpdateOptimizersSystem)
			{
				RaycastsInThisFrame = 0;
				GeometryUtility.CalculateFrustumPlanes(MainCamera, CurrentFrustumPlanes);
				totalTimeConsumption = 0L;
				for (int i = 0; i < clocks.Length; i++)
				{
					totalTimeConsumption += clocks[i].FrameTicksConsumption;
				}
			}
		}

		public static void CallUpdateAll()
		{
			if (!MainCamera)
			{
				return;
			}
			for (int i = 0; i < Instance.dynamicLists.Count; i++)
			{
				for (int num = Instance.dynamicLists[i].Count - 1; num >= 0; num--)
				{
					Instance.CheckElement(Instance.dynamicLists[i][num], num, full: false);
				}
			}
		}

		public int AddToDynamic(Optimizer_Base optimizer)
		{
			if (!UpdateOptimizersSystem)
			{
				return -1;
			}
			DOTS_AddOptimizer(optimizer);
			float distance = float.MaxValue;
			if ((bool)MainCamera)
			{
				distance = (optimizer.GetReferencePosition() - MainCamera.transform.position).magnitude;
			}
			EOptimizingDistance eOptimizingDistance = QualifyDistance(distance);
			int num = -1;
			if (optimizer.CurrentDynamicDistanceCategory != eOptimizingDistance)
			{
				if (optimizer.CurrentDynamicDistanceCategory.HasValue)
				{
					dynamicLists[(int)optimizer.CurrentDynamicDistanceCategory.Value].RemoveAt(optimizer.DynamicListIndex);
				}
				dynamicLists[(int)eOptimizingDistance].Add(optimizer);
				num = dynamicLists[(int)eOptimizingDistance].Count;
				if ((bool)MainCamera)
				{
					optimizer.DynamicLODUpdate(eOptimizingDistance, distance);
				}
				return num;
			}
			return optimizer.DynamicListIndex;
		}

		public void RemoveFromDynamic(Optimizer_Base optimizer)
		{
			if (UpdateOptimizersSystem)
			{
				DOTS_RemoveOptimizer(optimizer);
				if (optimizer.CurrentDynamicDistanceCategory.HasValue)
				{
					dynamicLists[(int)optimizer.CurrentDynamicDistanceCategory.Value].Remove(optimizer);
				}
			}
		}

		public void CheckElement(Optimizer_Base optimizer, int index, bool full = true)
		{
			if (full && !optimizer.TresholdTrigger())
			{
				return;
			}
			float distance = Vector3.Distance(optimizer.TargetCamera.position, optimizer.GetReferencePosition());
			EOptimizingDistance eOptimizingDistance = QualifyDistance(distance);
			if (eOptimizingDistance != optimizer.CurrentDynamicDistanceCategory)
			{
				int index2 = (int)eOptimizingDistance;
				if (optimizer.CurrentDynamicDistanceCategory.HasValue)
				{
					dynamicLists[(int)optimizer.CurrentDynamicDistanceCategory.Value].RemoveAt(index);
				}
				dynamicLists[index2].Add(optimizer);
				optimizer.OnDynamicChange(dynamicLists[index2].Count - 1);
			}
			optimizer.DynamicLODUpdate(eOptimizingDistance, distance);
		}

		private IEnumerator InitialCall()
		{
			yield return null;
			CallUpdateAll();
		}

		private EOptimizingDistance QualifyDistance(float distance)
		{
			for (int i = 0; i < Distances.Length; i++)
			{
				if (distance < Distances[i])
				{
					return (EOptimizingDistance)i;
				}
			}
			return EOptimizingDistance.Farthest;
		}

		public void RefreshDistances()
		{
			if (Advanced)
			{
				if (Distances != null)
				{
					for (int i = 1; i < Distances.Length; i++)
					{
						if (Distances[i] < Distances[i - 1] * 1.05f)
						{
							Distances[i] = Distances[i - 1] * 1.2f;
						}
					}
				}
				else
				{
					Distances = new float[GetDistanceTypesCount() - 1];
				}
			}
			else
			{
				Distances = new float[GetDistanceTypesCount() - 1];
				for (int j = 0; j < Distances.Length; j++)
				{
					Distances[j] = Mathf.Lerp(60f * WorldScale, 750f * WorldScale, (float)j / (float)Distances.Length);
				}
			}
		}

		public bool CameraMoved(Vector3 prePos, Quaternion preRot)
		{
			if (!DetectCameraFreeze)
			{
				return true;
			}
			bool flag = false;
			flag = (((MainCamera.transform.position - prePos).magnitude > Mathf.Max(1E-06f, Instance.MoveTreshold)) ? true : false);
			if (!flag && Quaternion.Angle(preRot, MainCamera.transform.rotation) > 0.1f)
			{
				flag = true;
			}
			return flag;
		}

		public void TransitionTo(Optimizer_Base optimizer, int targetLODLevel, float duration = 0f)
		{
			int instanceID = optimizer.GetInstanceID();
			Optimizers_Transitioning optimizers_Transitioning = null;
			for (int i = 0; i < transitioning.Count; i++)
			{
				if (transitioning[i].Id == instanceID)
				{
					optimizers_Transitioning = transitioning[i];
					break;
				}
			}
			if (optimizers_Transitioning != null)
			{
				optimizers_Transitioning.BreakCurrentTransition(duration, targetLODLevel);
				return;
			}
			optimizers_Transitioning = GetPoolTransitioningInstance(instanceID, optimizer, targetLODLevel, duration, transitioning.Count);
			transitioning.Add(optimizers_Transitioning);
		}

		private Optimizers_Transitioning GetPoolTransitioningInstance(int optimizerId, Optimizer_Base optimizer, int targetLODLevel, float duration, int index = -1)
		{
			if (transitioningPool.Count == 0)
			{
				return new Optimizers_Transitioning(optimizerId, optimizer, targetLODLevel, index);
			}
			Optimizers_Transitioning optimizers_Transitioning = transitioningPool[transitioningPool.Count - 1];
			transitioningPool.RemoveAt(transitioningPool.Count - 1);
			optimizers_Transitioning.Reset(optimizerId, optimizer, targetLODLevel, duration, index);
			return optimizers_Transitioning;
		}

		private void GiveBackTransitioningProcessorToPool(int i)
		{
			transitioningPool.Add(transitioning[i]);
			transitioning.RemoveAt(i);
		}

		public void EndTransition(Optimizer_Base optimizer)
		{
			int instanceID = optimizer.GetInstanceID();
			for (int num = transitioning.Count - 1; num >= 0; num--)
			{
				if (transitioning[num].Id == instanceID)
				{
					transitioning[num].Finish();
					GiveBackTransitioningProcessorToPool(num);
					break;
				}
			}
		}

		private void TransitionsUpdate()
		{
			float unscaledDeltaTime = Time.unscaledDeltaTime;
			for (int num = transitioning.Count - 1; num >= 0; num--)
			{
				transitioning[num].Update(unscaledDeltaTime);
				if (transitioning[num].Finished)
				{
					GiveBackTransitioningProcessorToPool(num);
				}
			}
		}
	}
}
