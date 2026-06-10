using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace FIMSpace.FOptimizing
{
	public abstract class Optimizer_Base : MonoBehaviour
	{
		public enum EFOptEditorCategory
		{
			Setup = 0,
			List = 1,
			Features = 2,
			LODs = 3
		}

		[Serializable]
		public class DOTS_DetectionData
		{
			public Mesh SharedMesh;

			public Transform SceneTransform;

			public DOTS_DetectionData Set(Transform t, Mesh m)
			{
				SharedMesh = m;
				SceneTransform = t;
				return this;
			}
		}

		[Serializable]
		public class MultiShapeBound
		{
			public Vector3 position;

			public float radius = 1f;

			public Transform transform;
		}

		[Tooltip("Adding optimizer to culling container - when used a lot of objects with same max distance levels and LOD levels count it can boost performance a lot.")]
		public bool AddToContainer = true;

		protected BoundingSphere[] visibilitySpheres;

		protected BoundingSphere mainVisibilitySphere;

		protected CullingGroupEvent lastEvent;

		public static bool _HandleUnityLOD = true;

		public static bool _editor_DragAndDropOptim = false;

		public bool _editor_DrawSetup = true;

		public bool _editor_DrawOptimizeList = true;

		public bool _editor_DrawAddFeatures;

		public bool _editor_DrawLODLevelsSetup = true;

		public bool _editor_DrawExtra;

		public bool _editor_horizontal = true;

		public EFOptEditorCategory _editor_category;

		private bool isQuitting;

		internal bool Editor_WasSaving;

		[HideInInspector]
		public bool Editor_InIsolatedScene;

		[HideInInspector]
		public bool Editor_JustCreated = true;

		protected bool wasDisabled;

		internal bool WasAskingForStatic;

		public static readonly Color[] lODColors = new Color[8]
		{
			new Color(0.2231376f, 0.8011768f, 0.1619608f, 1f),
			new Color(0.2070592f, 0.6333336f, 0.7556864f, 1f),
			new Color(0.159216f, 0.5578432f, 0.3435296f, 1f),
			new Color(0.1333336f, 0.4f, 0.7982352f, 1f),
			new Color(0.3827448f, 0.2886272f, 0.5239216f, 1f),
			new Color(0.8f, 0.4423528f, 0f, 1f),
			new Color(0.4886272f, 0.1078432f, 0.80196f, 1f),
			new Color(0.7749016f, 0.6368624f, 0.0250984f, 1f)
		};

		public static readonly Color culledLODColor = new Color(0.4f, 0f, 0f, 0.5f);

		[Tooltip("If Progressive Occlusion Culling should be applied with this optimizer")]
		public bool UseDOTS;

		[Tooltip("If this object shouldn be or not be sight obstacle. If it lets rays through it means this object is transparent and can't occlude other objects but can be occluded by other objects.\nIf 'Not Obstacles' are disabled under Optimizers Manager then Occlusion will not be triggered on the object if it will be automatically detected that it should be transparent (when particle system or light is attached to the object)")]
		public EDOTSObstacle DOTSObstacleType = EDOTSObstacle.Auto;

		[Tooltip("Detecting object's visibility with meshes or simple shapes")]
		public EDOTSDetection DOTSDetection;

		[Tooltip("List of meshes to detect visibility on with DOTS")]
		public List<DOTS_DetectionData> DOTSMeshData;

		public Vector3 DOTSOffset = Vector3.zero;

		public Vector3 DOTSSize = Vector3.one;

		public float DOTSRadius = 1f;

		public bool UseMultiShape;

		[HideInInspector]
		[Range(0f, 1f)]
		[Tooltip("How many spheres should be created in auto detection process")]
		public float AutoPrecision = 0.25f;

		[HideInInspector]
		[Tooltip("[Optional] Mesh to create detection spheres on it's structure")]
		public Mesh AutoReferenceMesh;

		[HideInInspector]
		public bool DrawPositionHandles = true;

		[HideInInspector]
		public bool ScalingHandles = true;

		[HideInInspector]
		public List<MultiShapeBound> Shapes;

		[HideInInspector]
		public List<Vector3> ShapePos;

		[HideInInspector]
		public List<float> ShapeRadius;

		protected int nearestDistanceLevel;

		protected int preNearestDistanceLevel;

		protected int[] sphereState;

		protected int spheresVisible;

		protected int[] spheresWithLOD;

		public bool UseObstacleDetection;

		[HideInInspector]
		[Range(0f, 5f)]
		[Tooltip("Allowing component to do more raycasts to detect obstacles covering it")]
		public int CoveragePrecision = 1;

		[HideInInspector]
		[Range(0f, 1.5f)]
		[Tooltip("If you want to avoid casting some raycasts from below ground")]
		public float CoverageScale = 1f;

		[HideInInspector]
		[Tooltip("Layer mask for raycasts checking obstacles in front of object in direction to camera")]
		public LayerMask CoverageMask = 1;

		[HideInInspector]
		[Tooltip("Draw menu for customized raycasting points")]
		public bool CustomCoveragePoints;

		[HideInInspector]
		public List<Vector3> CoverageOffsets;

		private int currentCoveragePrecision = -1;

		public Collider[] ignoredObstacleColliders;

		private Vector3[] coverageActiveArray;

		protected int isSelected = -1;

		protected int isResizing = -1;

		protected OptimizersManager manager;

		private Bounds optimizerBounds;

		private float lastDynamicDistance;

		private Transform triggersContainer;

		[HideInInspector]
		[Tooltip("Layer for triggers container to detect intersections only with Camera layer\n(camera and containers can have the same layer but change collision matrix)")]
		public LayerMask OnlyCamCollLayer;

		protected int triggerDistanceState = -1;

		protected int preTriggerDistanceState = -1;

		protected List<int> triggersEntered;

		[Range(1f, 8f)]
		[Tooltip("Level of detail (LOD) steps to configure optimization levels")]
		public int LODLevels = 3;

		[SerializeField]
		[HideInInspector]
		protected int preLODLevels = 1;

		[Tooltip("Max distance from main camera.\nWhen exceed object will be culled")]
		public float MaxDistance = 100f;

		[Tooltip("[Static] - For models which aren't moving far from initial position or just stays in one place (method is using only CullingGroups - Very Effective for 'Cull if not see')\n\n[Dynamic] - For objects which are moving in scene's world. If object is moving very fast, use 'UpdateBost' slider in Optimizers Manager but using EFFECTIVE method more recommended in such situtation. Dynamic method can response with some delay when there are thousands of active objects to optimize.\n\n[EFFECTIVE] - Connecting features of static method and dynamic, the most resposible method when you have very mobile objects and you need quick detection if object is seen by camera\n\n[Trigger Based] Using trigger colliders to define distance levels (experimental)")]
		public EOptimizingMethod OptimizingMethod = EOptimizingMethod.Effective;

		[FPD_DrawTexture("FIMSpace/Optimizers 2/Opt_CullHelp", 128f, 20f, 120f, 165f)]
		[Tooltip("[Toggled] Changing LOD state to cull (or hidden) if camera is looking away from detection sphere/bounds\n\n[Untoggled] Only max distance will cull this object")]
		public bool CullIfNotSee = true;

		[Tooltip("CullIfNotSee: Radius of detecting object visibility for camera view (frustum - CullingGroups)")]
		public float DetectionRadius = 3f;

		[Tooltip("CullIfNotSee: Bounding Box for detecting object visibility for camera view (frustum)")]
		public Vector3 DetectionBounds = Vector3.one;

		[HideInInspector]
		public bool Hideable;

		[Tooltip("Offsetting center of detection sphere/bounds")]
		public Vector3 DetectionOffset = Vector3.zero;

		[Range(0f, 1f)]
		[Tooltip("Alpha for debug spheres etc. visible in scene view when object with Optimizer is selected and Optimizer is unfolded")]
		public float GizmosAlpha = 1f;

		public bool DrawGizmos = true;

		[Range(0f, 3f)]
		[Tooltip("How long (in seconds) should take transition between LOD levels (if transitioning for optimized component is supported)")]
		public float FadeDuration;

		[Tooltip("If you want to use transition when object goes out of camera view (camera frustum) and not fade just when distance ranges are changed.")]
		public bool FadeViewVisibility;

		[Tooltip("If at 'Culled' LOD state game object should be deactivated (after transition)\n\nWARNING: Deactivating whole game object is highly time comsuming for unity when you do it on multiple objects during one game frame\nif you use optimizers on many objects and experience lags during rotating camera then try not deactivating game object but just components inside 'To Optimize' list!")]
		public bool DeactivateObject;

		[HideInInspector]
		public List<float> LODPercent;

		protected Vector3 distancePoint = Vector3.zero;

		[HideInInspector]
		public bool AutoDistance;

		public float AutoDistanceFactor;

		[HideInInspector]
		public bool DrawAutoDistanceToggle = true;

		[HideInInspector]
		public int HiddenCullAt = -1;

		[HideInInspector]
		public int LimitLODLevels;

		protected bool drawDetectionSphere = true;

		protected float moveTreshold;

		[HideInInspector]
		public bool UnlockFirstLOD;

		protected bool WasOutOfCameraView;

		protected bool WasHidden;

		protected bool doFirstCull = true;

		[HideInInspector]
		public bool DrawGeneratedPrefabInfo;

		[HideInInspector]
		public bool DrawDeactivateToggle = true;

		public int ContainerGeneratedID { get; private set; }

		public Optimizers_CullingContainer OwnerContainer { get; private set; }

		public int ContainerSphereId { get; private set; }

		public int[] ContainerSphereIds { get; private set; }

		public CullingGroup CullingGroup { get; protected set; }

		public static bool _HandleUnityLODWithReload
		{
			get
			{
				_HandleUnityLOD = PlayerPrefs.GetInt("FOpt_ULOD", 1) == 1;
				return _HandleUnityLOD;
			}
			set
			{
				_HandleUnityLOD = value;
				PlayerPrefs.SetInt("FOpt_ULOD", value ? 1 : 0);
			}
		}

		public EOptimizingDistance? CurrentDynamicDistanceCategory { get; protected set; }

		public int DynamicListIndex { get; protected set; }

		public Vector3 PreviousPosition { get; protected set; }

		public Vector3 LastDynamicCheckCameraPosition { get; protected set; }

		public Vector3 LastTresholdCheckPos { get; protected set; }

		public Vector3 LastTresholdCheckCamPos { get; protected set; }

		public Quaternion LastTresholdCheckCamRot { get; protected set; }

		public float GetMaxDistance
		{
			get
			{
				float globalMaxDistanceMultiplier = OptimizersManager.Instance.GlobalMaxDistanceMultiplier;
				if (globalMaxDistanceMultiplier == 1f)
				{
					return MaxDistance;
				}
				return MaxDistance * globalMaxDistanceMultiplier;
			}
		}

		public bool OutOfDistance { get; protected set; }

		public bool OutOfCameraView { get; protected set; }

		public float[] DistanceLevels { get; protected set; }

		public int CurrentLODLevel { get; protected set; }

		public int PreviousLODLevel { get; protected set; }

		public int CurrentBackLODLevel { get; protected set; }

		public int CurrentDistanceLODLevel { get; protected set; }

		public bool IsCulled { get; protected set; }

		public bool IsHidden { get; protected set; }

		public bool FarAway { get; protected set; }

		public Transform TargetCamera { get; protected set; }

		public int TransitionNextLOD { get; internal set; }

		public float TransitionPercent { get; internal set; }

		internal void AssignToContainer(Optimizers_CullingContainer container, int sphereId, ref BoundingSphere sphere)
		{
			OwnerContainer = container;
			ContainerSphereId = sphereId;
			mainVisibilitySphere = sphere;
		}

		internal void AssignToContainer(Optimizers_CullingContainer container, int[] sphereIds)
		{
			OwnerContainer = container;
			ContainerSphereIds = sphereIds;
		}

		protected void InitStaticOptimizer()
		{
			if (!AddToContainer)
			{
				OptimizersManager.Instance.RegisterNotContainedStaticOptimizer(this, init: true);
			}
			InitCullingGroups(GetDistanceMeasures(), GetDetectionRadiusRaw(), OptimizersManager.MainCamera);
		}

		protected virtual void InitCullingGroups(float[] distances, float detectionSphereRadius = 2.5f, Camera targetCamera = null)
		{
			InitBaseCullingVariables(targetCamera);
			if (UseMultiShape && Shapes != null && Shapes.Count != 0)
			{
				InitCullingGroupsMultiShape(distances, detectionSphereRadius, targetCamera);
				return;
			}
			if (!AddToContainer)
			{
				SetDistanceLevels(distances);
				CullingGroup = new CullingGroup
				{
					targetCamera = targetCamera
				};
				visibilitySpheres = new BoundingSphere[1];
				visibilitySpheres[0] = new BoundingSphere(base.transform.position + base.transform.TransformVector(DetectionOffset), detectionSphereRadius * GetScaler(base.transform));
				mainVisibilitySphere = visibilitySpheres[0];
				CullingGroup.SetBoundingSpheres(visibilitySpheres);
				CullingGroup.SetBoundingSphereCount(1);
				CullingGroup.onStateChanged = CullingGroupStateChanged;
				CullingGroup.SetBoundingDistances(DistanceLevels);
				if ((bool)targetCamera)
				{
					CullingGroup.SetDistanceReferencePoint(targetCamera.transform);
				}
			}
			else
			{
				SetDistanceLevels(distances);
				OptimizersManager.Instance.AddToContainer(this);
			}
			distancePoint = GetReferencePosition();
			PreviousPosition = distancePoint;
		}

		public virtual void CullingGroupStateChanged(CullingGroupEvent cullingEvent)
		{
			if (UseMultiShape)
			{
				CullingGroupStateChangedMultiShape(cullingEvent);
				return;
			}
			lastEvent = cullingEvent;
			if (!base.enabled)
			{
				wasDisabled = true;
				return;
			}
			int num = cullingEvent.currentDistance;
			if (num == 0)
			{
				num = 1;
			}
			int num2 = cullingEvent.previousDistance;
			if (num2 == 0)
			{
				num2 = 1;
			}
			if (num > DistanceLevels.Length - 2)
			{
				OutOfDistance = true;
				if (num > DistanceLevels.Length - 1)
				{
					FarAway = true;
				}
				else
				{
					FarAway = false;
				}
			}
			else
			{
				OutOfDistance = false;
				FarAway = false;
			}
			if (CullIfNotSee)
			{
				bool flag = false;
				if (num2 == DistanceLevels.Length - 2 && num == DistanceLevels.Length - 1)
				{
					flag = true;
				}
				if (cullingEvent.hasBecomeVisible)
				{
					OutOfCameraView = false;
				}
				else if (cullingEvent.hasBecomeInvisible)
				{
					if (!flag)
					{
						OutOfCameraView = true;
					}
				}
				else if (cullingEvent.isVisible)
				{
					OutOfCameraView = false;
				}
			}
			else if (cullingEvent.hasBecomeVisible)
			{
				OutOfCameraView = false;
			}
			else if (cullingEvent.hasBecomeInvisible)
			{
				OutOfCameraView = true;
			}
			bool flag2 = false;
			int num3 = num - 1;
			if (num3 != CurrentDistanceLODLevel)
			{
				flag2 = true;
			}
			else if (WasOutOfCameraView != OutOfCameraView)
			{
				flag2 = true;
			}
			else if (WasHidden != IsHidden)
			{
				flag2 = true;
			}
			if (!doFirstCull)
			{
				if (flag2)
				{
					RefreshVisibilityState(num3);
				}
			}
			else
			{
				RefreshVisibilityState(num3);
			}
			distancePoint = GetReferencePosition();
			if (UseObstacleDetection && CullIfNotSee && !OutOfCameraView && !OutOfDistance && CoveragePrecision > -1)
			{
				ObstacleCheck();
			}
		}

		private void SetDistanceLevels(float[] distances)
		{
			DistanceLevels = new float[distances.Length + 2];
			DistanceLevels[0] = Mathf.Epsilon;
			for (int i = 1; i < distances.Length + 1; i++)
			{
				DistanceLevels[i] = distances[i - 1];
			}
			DistanceLevels[DistanceLevels.Length - 1] = distances[^1] * 1.5f;
		}

		protected void CleanCullingGroup()
		{
			if (CullingGroup != null)
			{
				CullingGroup.Dispose();
				CullingGroup = null;
			}
			if (OwnerContainer != null)
			{
				OwnerContainer.RemoveOptimizer(this);
			}
		}

		public static float GetScaler(Transform transform)
		{
			float num = 1f;
			if (transform.lossyScale.x > transform.lossyScale.y)
			{
				if (transform.lossyScale.y > transform.lossyScale.z)
				{
					return transform.lossyScale.y;
				}
				return transform.lossyScale.z;
			}
			return transform.lossyScale.x;
		}

		public void RefreshCamera(Camera camera)
		{
			if (!(camera == null))
			{
				TargetCamera = camera.transform;
				if (OwnerContainer == null && CullingGroup != null)
				{
					CullingGroup.targetCamera = camera;
					CullingGroup.SetDistanceReferencePoint(TargetCamera);
				}
			}
		}

		public virtual float[] GetDistanceMeasures()
		{
			EditorResetLODValues(logWarning: true);
			float[] array = new float[LODPercent.Count];
			float getMaxDistance = GetMaxDistance;
			for (int i = 0; i < LODPercent.Count; i++)
			{
				array[i] = getMaxDistance * LODPercent[i];
			}
			return array;
		}

		public virtual Vector3 GetReferencePosition()
		{
			if (UseMultiShape)
			{
				return GetReferencePositionMultiShape();
			}
			if (OptimizingMethod == EOptimizingMethod.Static && visibilitySpheres != null)
			{
				return visibilitySpheres[0].position;
			}
			return base.transform.position + base.transform.TransformVector(DetectionOffset);
		}

		public virtual float GetReferenceDistance()
		{
			if (OptimizingMethod == EOptimizingMethod.Static || OptimizingMethod == EOptimizingMethod.Effective)
			{
				float num = Vector3.Distance(GetReferencePosition(), TargetCamera.position);
				if (num < mainVisibilitySphere.radius)
				{
					return 0f;
				}
				return num - mainVisibilitySphere.radius;
			}
			return Vector3.Distance(PreviousPosition, LastDynamicCheckCameraPosition);
		}

		public float GetAddRadius()
		{
			if (OptimizingMethod == EOptimizingMethod.Static || OptimizingMethod == EOptimizingMethod.Effective)
			{
				return GetDetectionRadiusRaw() * base.transform.lossyScale.x;
			}
			return 0f;
		}

		protected virtual void StartVariablesRefresh()
		{
			manager = null;
			CurrentDynamicDistanceCategory = null;
			DynamicListIndex = 0;
			TransitionNextLOD = 0;
			TransitionPercent = -1f;
			ContainerGeneratedID = Optimizers_CullingContainer.GetId(GetDistanceMeasures());
			IsCulled = false;
			IsHidden = false;
		}

		protected virtual void InitBaseCullingVariables(Camera targetCamera)
		{
			OutOfDistance = true;
			OutOfCameraView = true;
			WasOutOfCameraView = false;
			IsHidden = false;
			WasHidden = false;
			CurrentLODLevel = 0;
			CurrentBackLODLevel = 0;
			CurrentDistanceLODLevel = 0;
			if (targetCamera == null)
			{
				targetCamera = Camera.main;
			}
			if (targetCamera == null)
			{
				if (FEditor_OneShotLog.CanDrawLog("optC", 16))
				{
					Debug.LogWarning("[OPTIMIZERS] There is no main camera on scene!");
				}
			}
			else
			{
				TargetCamera = targetCamera.transform;
			}
		}

		protected void RefreshVisibilityState(int targetLODLevel)
		{
			if (!base.enabled)
			{
				return;
			}
			bool flag = false;
			bool flag2 = false;
			bool flag3 = false;
			CurrentDistanceLODLevel = targetLODLevel;
			if (OutOfDistance)
			{
				flag = true;
			}
			else
			{
				if (CullIfNotSee && OutOfCameraView)
				{
					flag2 = true;
				}
				if (!flag2 && IsHidden)
				{
					flag2 = true;
				}
				if (flag2)
				{
					if (HiddenCullAt < 0)
					{
						flag = true;
					}
					else if (targetLODLevel < HiddenCullAt + 1)
					{
						targetLODLevel = LODLevels + 1;
						flag3 = true;
					}
					else
					{
						flag = true;
					}
				}
				else if (WasOutOfCameraView)
				{
					flag2 = true;
				}
			}
			if (!flag && !IsHidden && WasHidden)
			{
				flag2 = true;
			}
			if (flag2 && TransitionPercent >= 0f)
			{
				OptimizersManager.Instance.EndTransition(this);
			}
			if (!(IsCulled && flag))
			{
				if (doFirstCull)
				{
					if (flag)
					{
						ChangeLODLevelTo(LODLevels);
					}
					else
					{
						ChangeLODLevelTo(targetLODLevel);
					}
					doFirstCull = false;
				}
				else if (CullIfNotSee)
				{
					if (FadeViewVisibility)
					{
						flag2 = false;
					}
					if (flag2)
					{
						if (flag)
						{
							SetCulled();
						}
						else
						{
							if (TransitionPercent < 0f || flag3)
							{
								ChangeLODLevelTo(targetLODLevel);
							}
							if (!OutOfDistance)
							{
								SetCulled(culled: false);
							}
						}
					}
					else if (flag)
					{
						if (FadeDuration > 0f)
						{
							if (!OutOfDistance)
							{
								TransitionOrSetLODLevel(targetLODLevel);
							}
							else
							{
								TransitionOrSetLODLevel(LODLevels);
							}
						}
						else
						{
							TransitionOrSetLODLevel(LODLevels);
						}
					}
					else if (FadeDuration <= 0f)
					{
						SetLODLevel(targetLODLevel);
						SetCulled(culled: false);
					}
					else
					{
						TransitionOrSetLODLevel(targetLODLevel);
						SetCulled(culled: false, apply: false);
					}
				}
				else if (flag)
				{
					TransitionOrSetLODLevel(LODLevels);
				}
				else
				{
					TransitionOrSetLODLevel(targetLODLevel);
					SetCulled(culled: false);
				}
			}
			WasOutOfCameraView = OutOfCameraView;
			WasHidden = IsHidden;
		}

		protected virtual void TransitionOrSetLODLevel(int lodLevel)
		{
			if (FadeDuration <= 0f)
			{
				SetLODLevel(lodLevel);
			}
			else if (lodLevel != CurrentLODLevel || IsCulled || TransitionPercent != -1f)
			{
				if (lodLevel > LODLevels)
				{
					OptimizersManager.Instance.TransitionTo(this, LODLevels, FadeDuration);
				}
				else
				{
					OptimizersManager.Instance.TransitionTo(this, lodLevel, FadeDuration);
				}
			}
		}

		public void SetHidden(bool hide)
		{
			if (hide != IsHidden)
			{
				IsHidden = hide;
				RefreshVisibilityState(CurrentDistanceLODLevel);
			}
		}

		internal virtual void SetCulled(bool culled = true, bool apply = true)
		{
			if (culled && IsCulled == culled)
			{
				return;
			}
			IsCulled = culled;
			if (culled)
			{
				CurrentBackLODLevel = LODLevels;
				AllLODComponents_ApplyCulledState();
				if (DeactivateObject)
				{
					OnActivationChange(active: false);
					base.gameObject.SetActive(value: false);
				}
				return;
			}
			CurrentBackLODLevel = CurrentLODLevel;
			if (DeactivateObject && !base.gameObject.activeInHierarchy)
			{
				OnActivationChange(active: true);
				base.gameObject.SetActive(value: true);
			}
			if (apply)
			{
				AllLODComponents_ApplyCurrentState();
			}
		}

		protected abstract void AllLODComponents_ApplyCulledState();

		protected abstract void AllLODComponents_ApplyCurrentState();

		protected abstract void AllLODComponents_RefreshChoosedLODState(int lodLevel);

		protected abstract void AllLODComponents_ChangeChoosedLODState(int lodLevel);

		internal virtual void SetLODLevel(int lodLevel)
		{
			if (lodLevel == LODLevels)
			{
				SetCulled();
				CurrentLODLevel = lodLevel;
			}
			else
			{
				CurrentLODLevel = lodLevel;
				AllLODComponents_RefreshChoosedLODState(lodLevel);
			}
			CurrentBackLODLevel = CurrentLODLevel;
		}

		internal virtual void ChangeLODLevelTo(int lodLevel)
		{
			PreviousLODLevel = CurrentLODLevel;
			CurrentLODLevel = Mathf.Min(lodLevel, LODLevels + 2);
			CurrentBackLODLevel = CurrentLODLevel;
			AllLODComponents_ChangeChoosedLODState(lodLevel);
			bool flag = false;
			if (lodLevel >= LODLevels)
			{
				flag = ((lodLevel != LODLevels + 1) ? true : false);
			}
			if (flag)
			{
				CullOrUncullObject();
			}
			else
			{
				CullOrUncullObject(cull: false);
			}
		}

		internal virtual void CullOrUncullObject(bool cull = true)
		{
			if (IsCulled == cull)
			{
				return;
			}
			IsCulled = cull;
			if (cull)
			{
				if (DeactivateObject && base.gameObject.activeInHierarchy)
				{
					OnActivationChange(active: false);
					base.gameObject.SetActive(value: false);
				}
			}
			else if (DeactivateObject && !base.gameObject.activeInHierarchy)
			{
				OnActivationChange(active: true);
				base.gameObject.SetActive(value: true);
			}
		}

		public static void _RefreshHandleUnityLOD()
		{
			_HandleUnityLOD = _HandleUnityLODWithReload;
		}

		protected virtual void Start()
		{
			StartVariablesRefresh();
			RefreshInitialSettingsForOptimized();
			DOTSInit();
			switch (OptimizingMethod)
			{
			case EOptimizingMethod.Static:
				InitStaticOptimizer();
				break;
			case EOptimizingMethod.Dynamic:
				InitDynamicOptimizer(justDynamic: true);
				break;
			case EOptimizingMethod.Effective:
				InitEffectiveOptimizer();
				break;
			case EOptimizingMethod.TriggerBased:
				InitTriggerOptimizer();
				break;
			}
			moveTreshold = DetectionRadius * base.transform.lossyScale.x / 100f;
			if ((bool)OptimizersManager.Instance)
			{
				moveTreshold *= 1f - OptimizersManager.Instance.UpdateBoost * 0.999f;
			}
		}

		public abstract bool OptimizationListExists();

		public virtual void OnValidate()
		{
		}

		protected virtual void Reset()
		{
		}

		public virtual void AssignComponentsToOptimizeFrom(Component target, bool includeAdvanced = false)
		{
		}

		public bool CheckIfAlreadyInUse(LODsControllerBase generatedController, List<Optimizer_Base> childOptims)
		{
			bool flag = false;
			if (childOptims != null)
			{
				for (int i = 0; i < childOptims.Count; i++)
				{
					if (flag)
					{
						break;
					}
					if (!(childOptims[i] != this))
					{
						continue;
					}
					ScriptableOptimizer scriptableOptimizer = childOptims[i] as ScriptableOptimizer;
					if (scriptableOptimizer != null)
					{
						for (int j = 0; j < scriptableOptimizer.ToOptimize.Count; j++)
						{
							if (scriptableOptimizer.ToOptimize[j].Component == generatedController.Component)
							{
								flag = true;
								break;
							}
						}
						continue;
					}
					EssentialOptimizer essentialOptimizer = childOptims[i] as EssentialOptimizer;
					if (!(essentialOptimizer != null))
					{
						continue;
					}
					for (int k = 0; k < essentialOptimizer.ToOptimize.Count; k++)
					{
						if (essentialOptimizer.ToOptimize[k].Component == generatedController.Component)
						{
							flag = true;
							break;
						}
					}
				}
			}
			return flag;
		}

		public virtual void AssignCustomComponentToOptimize(MonoBehaviour target)
		{
		}

		public virtual void AssignComponentsToBeOptimizedFromAllChildren(GameObject target, bool searchForCustom = false)
		{
			RefreshToOptimizeList();
			if (!searchForCustom)
			{
				Transform[] componentsInChildren = target.GetComponentsInChildren<Transform>(includeInactive: true);
				foreach (Transform target2 in componentsInChildren)
				{
					AssignComponentsToOptimizeFrom(target2);
				}
			}
			else
			{
				Transform[] componentsInChildren = target.GetComponentsInChildren<Transform>(includeInactive: true);
				for (int i = 0; i < componentsInChildren.Length; i++)
				{
					MonoBehaviour[] components = componentsInChildren[i].gameObject.GetComponents<MonoBehaviour>();
					foreach (MonoBehaviour target3 in components)
					{
						AssignCustomComponentToOptimize(target3);
					}
				}
			}
			TryAutoComputeDetectionShape();
		}

		public abstract bool ContainsComponent(Component component);

		public abstract void RefreshToOptimizeList();

		public bool IsPrefabed()
		{
			return false;
		}

		protected virtual void RefreshInitialSettingsForOptimized()
		{
		}

		public virtual void RemoveFromToOptimizeAt(int i)
		{
		}

		public virtual void RemoveAllComponentsFromToOptimize()
		{
		}

		protected abstract LODsControllerBase AddToOptimize(LODsControllerBase lod);

		protected abstract void ResetLODs(bool hard = false);

		protected virtual void OnActivationChange(bool active)
		{
			if (OptimizingMethod != EOptimizingMethod.TriggerBased)
			{
				return;
			}
			if (!active)
			{
				if (triggersContainer.transform.parent != null)
				{
					triggersContainer.transform.SetParent(null, worldPositionStays: true);
				}
			}
			else if (triggersContainer.transform.parent == null)
			{
				triggersContainer.transform.SetParent(base.transform, worldPositionStays: true);
			}
		}

		public virtual void CheckForNullsToOptimize()
		{
		}

		protected virtual void OnDestroy()
		{
			DisposeDynamicOptimizer();
			CleanCullingGroup();
			if (!isQuitting && !OptimizersManager.AppIsQuitting)
			{
				OptimizersManager.Instance.UnRegisterOptimizer(this);
			}
		}

		private void OnApplicationQuit()
		{
			isQuitting = true;
			CleanCullingGroup();
		}

		public virtual void CleanAsset()
		{
		}

		public static List<T> FindComponentsInAllChildren<T>(Transform transformToSearchIn) where T : Component
		{
			List<T> list = new List<T>();
			Transform[] componentsInChildren = transformToSearchIn.GetComponentsInChildren<Transform>(includeInactive: true);
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				T component = componentsInChildren[i].GetComponent<T>();
				if ((bool)component)
				{
					list.Add(component);
				}
			}
			return list;
		}

		protected virtual void OptimizerReset()
		{
		}

		protected virtual void OnEnable()
		{
			if (wasDisabled)
			{
				ApplyLastEvent();
				wasDisabled = false;
			}
		}

		private void ApplyLastEvent()
		{
			if (OptimizingMethod == EOptimizingMethod.Dynamic)
			{
				OutOfCameraView = false;
				DynamicLODUpdate(CurrentDynamicDistanceCategory.Value, lastDynamicDistance);
				return;
			}
			if (OptimizingMethod == EOptimizingMethod.Effective && CurrentDynamicDistanceCategory.HasValue)
			{
				DynamicLODUpdate(CurrentDynamicDistanceCategory.Value, lastDynamicDistance);
			}
			CullingGroupStateChanged(lastEvent);
		}

		public void OptimizerOnValidate()
		{
		}

		protected void OnValidateStart()
		{
			if (LODLevels <= 0)
			{
				LODLevels = 2;
			}
			if (LODLevels > 8)
			{
				LODLevels = 8;
			}
			if (DetectionRadius < 0f)
			{
				DetectionRadius = 0f;
			}
		}

		protected virtual void OnValidateRefreshComponents()
		{
		}

		protected virtual void OnValidateUpdateToOptimize(bool hard = false)
		{
		}

		public void SetAutoDistance(float multiplier = 1f)
		{
			switch (OptimizingMethod)
			{
			case EOptimizingMethod.Static:
			case EOptimizingMethod.Effective:
				MaxDistance = DetectionRadius * 550f;
				MaxDistance *= GetScaler(base.transform);
				MaxDistance *= multiplier;
				if ((bool)OptimizersManager.MainCamera && MaxDistance > OptimizersManager.MainCamera.farClipPlane)
				{
					MaxDistance = OptimizersManager.MainCamera.farClipPlane;
				}
				break;
			case EOptimizingMethod.Dynamic:
			case EOptimizingMethod.TriggerBased:
				MaxDistance = DetectionBounds.magnitude * 166f;
				MaxDistance *= GetScaler(base.transform);
				if ((bool)OptimizersManager.MainCamera && MaxDistance > OptimizersManager.MainCamera.farClipPlane)
				{
					MaxDistance = OptimizersManager.MainCamera.farClipPlane;
				}
				MaxDistance *= multiplier;
				break;
			}
		}

		protected virtual void OnValidateCheckForStatic()
		{
		}

		public virtual void SyncWithReferences()
		{
		}

		public virtual void EditorUpdate()
		{
			if (LODLevels <= 0)
			{
				LODLevels = 2;
			}
			if (LODLevels > 8)
			{
				LODLevels = 8;
			}
			EditorResetLODValues();
		}

		public void EditorResetLODValues(bool logWarning = false)
		{
			if (LODPercent == null)
			{
				LODPercent = new List<float>();
			}
			if (LODLevels != LODPercent.Count)
			{
				float p = Mathf.Lerp(1f, 1.65f, Mathf.InverseLerp(1f, 7f, LODLevels));
				LODPercent.Clear();
				for (int i = 0; i < LODLevels; i++)
				{
					float num = 0f;
					num = 0.05f + Mathf.Pow((float)(i + 1) / (float)(LODLevels + 1), p);
					LODPercent.Add(num);
				}
				LODPercent[LODLevels - 1] = 1f;
			}
		}

		public void DOTSInit()
		{
		}

		public void DOTSObstacleCheck(bool visible)
		{
			SetHidden(!visible);
		}

		public void DOTSFindMeshes(bool force = false)
		{
			if (DOTSMeshData == null)
			{
				DOTSMeshData = new List<DOTS_DetectionData>();
			}
			if (force)
			{
				DOTSMeshData.Clear();
			}
			if (DOTSMeshData.Count != 0)
			{
				return;
			}
			for (int i = 0; i < GetToOptimizeCount(); i++)
			{
				Component optimizedComponent = GetOptimizedComponent(i);
				LODGroup lODGroup = optimizedComponent as LODGroup;
				if ((bool)lODGroup)
				{
					MeshRenderer meshRenderer = null;
					LOD[] lODs = lODGroup.GetLODs();
					if (lODs == null)
					{
						continue;
					}
					for (int j = 0; j < lODs.Length; j++)
					{
						if (lODs[j].renderers == null)
						{
							continue;
						}
						for (int k = 0; k < lODs[j].renderers.Length; k++)
						{
							Renderer renderer = lODs[j].renderers[k];
							if (!(renderer != null))
							{
								continue;
							}
							MeshRenderer meshRenderer2 = renderer as MeshRenderer;
							if (!(meshRenderer2 != null))
							{
								continue;
							}
							MeshFilter component = renderer.GetComponent<MeshFilter>();
							if ((bool)component && component.sharedMesh != null)
							{
								if (DOTSAlreadyContains(component.transform))
								{
									break;
								}
								DOTSMeshData.Add(new DOTS_DetectionData().Set(component.transform, component.sharedMesh));
								meshRenderer = meshRenderer2;
							}
						}
						if (meshRenderer != null)
						{
							break;
						}
					}
				}
				else
				{
					if (!(optimizedComponent is MeshRenderer))
					{
						continue;
					}
					MeshFilter component2 = optimizedComponent.GetComponent<MeshFilter>();
					if ((bool)component2 && (bool)component2.sharedMesh)
					{
						bool flag = true;
						if (!force && component2.name.ToLower().Contains("_lod") && !component2.name.ToLower().Contains("_lod0"))
						{
							flag = false;
						}
						if (flag && !DOTSAlreadyContains(optimizedComponent.transform))
						{
							DOTSMeshData.Add(new DOTS_DetectionData().Set(component2.transform, component2.sharedMesh));
						}
					}
				}
			}
		}

		public bool DOTSAlreadyContains(Transform t)
		{
			return DOTSMeshData.FirstOrDefault((DOTS_DetectionData x) => x.SceneTransform == t) != null;
		}

		protected void InitCullingGroupsMultiShape(float[] distances, float detectionSphereRadius = 2.5f, Camera targetCamera = null)
		{
			distancePoint = base.transform.position;
			if (!AddToContainer)
			{
				DistanceLevels = new float[distances.Length + 2];
				DistanceLevels[0] = Mathf.Epsilon;
				for (int i = 1; i < distances.Length + 1; i++)
				{
					DistanceLevels[i] = distances[i - 1];
				}
				DistanceLevels[DistanceLevels.Length - 1] = distances[^1] * 2f;
				CullingGroup = new CullingGroup
				{
					targetCamera = targetCamera
				};
				visibilitySpheres = GetBoundingSpheresMultiShape();
				sphereState = new int[visibilitySpheres.Length];
				mainVisibilitySphere = visibilitySpheres[0];
				for (int j = 0; j < sphereState.Length; j++)
				{
					sphereState[j] = 0;
				}
				spheresWithLOD = new int[LODLevels + 2];
				spheresWithLOD[1] = visibilitySpheres.Length;
				CullingGroup.SetBoundingSpheres(visibilitySpheres);
				CullingGroup.SetBoundingSphereCount(visibilitySpheres.Length);
				CullingGroup.onStateChanged = CullingGroupStateChangedMultiShape;
				CullingGroup.SetBoundingDistances(DistanceLevels);
				CullingGroup.SetDistanceReferencePoint(targetCamera.transform);
				spheresVisible = 0;
			}
			else
			{
				sphereState = new int[Shapes.Count];
				for (int k = 0; k < sphereState.Length; k++)
				{
					sphereState[k] = 0;
				}
				spheresWithLOD = new int[LODLevels + 2];
				spheresWithLOD[1] = LODLevels + 2;
				spheresVisible = 0;
				SetDistanceLevels(distances);
				OptimizersManager.Instance.AddToContainer(this);
			}
			float[] centerPosAndFarthest = GetCenterPosAndFarthest();
			distancePoint = new Vector3(centerPosAndFarthest[0], centerPosAndFarthest[1], centerPosAndFarthest[2]);
		}

		public void CullingGroupStateChangedMultiShape(CullingGroupEvent cullingEvent)
		{
			int num = cullingEvent.index;
			if (OwnerContainer != null)
			{
				num = GetIndexForCullEventMultiShape(num);
			}
			else if (UseMultiShape)
			{
				return;
			}
			int num2 = cullingEvent.currentDistance;
			if (num2 == 0)
			{
				num2 = 1;
			}
			if (num2 >= spheresWithLOD.Length)
			{
				num2 = spheresWithLOD.Length - 1;
			}
			sphereState[num] = num2;
			int num3 = cullingEvent.previousDistance;
			if (num3 == 0)
			{
				num3 = 1;
			}
			if (num3 >= spheresWithLOD.Length)
			{
				num3 = spheresWithLOD.Length - 1;
			}
			spheresWithLOD[num3]--;
			spheresWithLOD[num2]++;
			if (cullingEvent.hasBecomeInvisible)
			{
				spheresVisible--;
			}
			if (cullingEvent.hasBecomeVisible)
			{
				spheresVisible++;
			}
			int num4 = 0;
			for (int num5 = spheresWithLOD.Length - 1; num5 >= 0; num5--)
			{
				if (spheresWithLOD[num5] > 0)
				{
					num4 = num5;
				}
			}
			if (num4 == 0)
			{
				num4 = 1;
			}
			nearestDistanceLevel = num4;
			if (nearestDistanceLevel > DistanceLevels.Length - 2)
			{
				OutOfDistance = true;
				if (nearestDistanceLevel > DistanceLevels.Length - 1)
				{
					FarAway = true;
				}
				else
				{
					FarAway = false;
				}
			}
			else
			{
				OutOfDistance = false;
				FarAway = false;
			}
			if (spheresVisible == 0)
			{
				OutOfCameraView = true;
			}
			else
			{
				OutOfCameraView = false;
			}
			bool flag = false;
			if (preNearestDistanceLevel != nearestDistanceLevel)
			{
				flag = true;
			}
			else if (WasOutOfCameraView != OutOfCameraView)
			{
				flag = true;
			}
			else if (WasHidden != IsHidden)
			{
				flag = true;
			}
			if (flag)
			{
				RefreshVisibilityState(Mathf.Max(0, nearestDistanceLevel - 1));
				preNearestDistanceLevel = nearestDistanceLevel;
			}
		}

		public Vector3 GetReferencePositionMultiShape()
		{
			return distancePoint;
		}

		public void OnValidateMultiShape()
		{
			if (OptimizingMethod == EOptimizingMethod.Dynamic || OptimizingMethod == EOptimizingMethod.TriggerBased)
			{
				Debug.LogError("[OPTIMIZERS] Optimization Method " + OptimizingMethod.ToString() + " is not supported by Complex Shape Component!");
				OptimizingMethod = EOptimizingMethod.Effective;
			}
			CullIfNotSee = true;
			Hideable = true;
			if (!AutoReferenceMesh)
			{
				MeshFilter componentInChildren = GetComponentInChildren<MeshFilter>();
				if ((bool)componentInChildren)
				{
					AutoReferenceMesh = componentInChildren.sharedMesh;
				}
				if (!AutoReferenceMesh)
				{
					SkinnedMeshRenderer componentInChildren2 = base.gameObject.GetComponentInChildren<SkinnedMeshRenderer>();
					if ((bool)componentInChildren2)
					{
						AutoReferenceMesh = componentInChildren2.sharedMesh;
					}
				}
			}
			if (ShapePos.Count > 0)
			{
				for (int i = 0; i < ShapePos.Count; i++)
				{
					Shapes.Add(new MultiShapeBound());
					Shapes[i].position = ShapePos[i];
					Shapes[i].radius = ShapeRadius[i];
				}
				ShapePos.Clear();
				ShapeRadius.Clear();
			}
		}

		public void DynamicLODUpdateMiltiShape(EOptimizingDistance category, float distance)
		{
			PreviousPosition = visibilitySpheres[0].position + Vector3.right * moveTreshold * 2f;
		}

		protected void RefreshEffectiveCullingGroupsMultiShape()
		{
			if (!AddToContainer)
			{
				for (int i = 0; i < Shapes.Count; i++)
				{
					if (Shapes[i].transform == null)
					{
						visibilitySpheres[i].position = base.transform.TransformPoint(Shapes[i].position);
					}
					else
					{
						visibilitySpheres[i].position = Shapes[i].transform.TransformPoint(Shapes[i].position);
					}
				}
				return;
			}
			for (int j = 0; j < ContainerSphereIds.Length; j++)
			{
				if (Shapes[j].transform == null)
				{
					OwnerContainer.CullingSpheres[ContainerSphereIds[j]].position = base.transform.TransformPoint(Shapes[j].position);
				}
				else
				{
					OwnerContainer.CullingSpheres[ContainerSphereIds[j]].position = Shapes[j].transform.TransformPoint(Shapes[j].position);
				}
			}
		}

		private BoundingSphere GetVisibilitySphere(int i)
		{
			if (OwnerContainer == null)
			{
				return visibilitySpheres[i];
			}
			if (!UseMultiShape)
			{
				return OwnerContainer.CullingSpheres[ContainerSphereId];
			}
			return OwnerContainer.CullingSpheres[ContainerSphereIds[i]];
		}

		internal int GetIndexForCullEventMultiShape(int containerSphere)
		{
			for (int i = 0; i < ContainerSphereIds.Length; i++)
			{
				if (ContainerSphereIds[i] == containerSphere)
				{
					return i;
				}
			}
			Debug.LogWarning("[Optimizers Multi Shape Container] Wrong container sphere id! " + containerSphere);
			return -1;
		}

		protected BoundingSphere[] GetBoundingSpheresMultiShape()
		{
			BoundingSphere[] array = new BoundingSphere[Shapes.Count];
			for (int i = 0; i < Shapes.Count; i++)
			{
				if (Shapes[i].transform == null)
				{
					array[i] = new BoundingSphere(base.transform.TransformPoint(Shapes[i].position), DetectionRadius * Shapes[i].radius);
				}
				else
				{
					array[i] = new BoundingSphere(Shapes[i].transform.TransformPoint(Shapes[i].position), DetectionRadius * Shapes[i].radius);
				}
			}
			return array;
		}

		protected float[] GetCenterPosAndFarthest()
		{
			float[] array = new float[5];
			Vector3 zero = Vector3.zero;
			if (visibilitySpheres == null)
			{
				visibilitySpheres = GetBoundingSpheresMultiShape();
			}
			for (int i = 0; i < visibilitySpheres.Length; i++)
			{
				zero += GetVisibilitySphere(i).position;
			}
			zero /= (float)Shapes.Count;
			float num = 0f;
			float num2 = 0f;
			for (int j = 0; j < visibilitySpheres.Length; j++)
			{
				float num3 = Vector3.Distance(GetVisibilitySphere(j).position, zero);
				if (num3 > num)
				{
					num = num3;
				}
				if (GetVisibilitySphere(j).radius > num2)
				{
					num2 = GetVisibilitySphere(j).radius;
				}
			}
			array[0] = zero.x;
			array[1] = zero.y;
			array[2] = zero.z;
			array[3] = num;
			array[4] = num2;
			return array;
		}

		public void GenerateAutoShape()
		{
			if ((bool)AutoReferenceMesh)
			{
				List<Vector3> pointsFromMesh = GetPointsFromMesh(AutoReferenceMesh, AutoPrecision);
				Shapes = new List<MultiShapeBound>();
				for (int i = 0; i < pointsFromMesh.Count; i++)
				{
					Shapes.Add(new MultiShapeBound());
					Shapes[i].position = pointsFromMesh[i];
				}
			}
			else
			{
				Debug.LogError("[OPTIMIZERS] No mesh to reference from");
			}
		}

		protected List<Vector3> GetPointsFromMesh(Mesh mesh, float precision)
		{
			try
			{
				List<Vector3> list = new List<Vector3>();
				float num = (DetectionRadius = mesh.bounds.size.magnitude / Mathf.Lerp(2f, 10f, precision));
				list.Add(mesh.vertices[0]);
				for (int i = 0; i < 100; i++)
				{
					float num2 = float.MaxValue;
					int num3 = -1;
					for (int j = 0; j < mesh.vertices.Length; j++)
					{
						bool flag = true;
						for (int k = 0; k < list.Count; k++)
						{
							float num4 = Vector3.Distance(mesh.vertices[j], list[k]);
							if (num4 < num)
							{
								flag = false;
								break;
							}
						}
						if (flag)
						{
							float num4 = Vector3.Distance(mesh.vertices[j], list[i]);
							if (num4 < num2)
							{
								num2 = num4;
								num3 = j;
							}
						}
					}
					if (num3 == -1)
					{
						break;
					}
					list.Add(mesh.vertices[num3]);
				}
				return list;
			}
			catch (Exception)
			{
			}
			return null;
		}

		private void ObstacleCheck()
		{
			if (UseDOTS)
			{
				return;
			}
			RefreshCoverageDetectionPoints(CoverageOffsets, PreviousPosition);
			for (int i = 0; i < coverageActiveArray.Length; i++)
			{
				Physics.Linecast(TargetCamera.position, coverageActiveArray[i], out var hitInfo, CoverageMask, QueryTriggerInteraction.Ignore);
				bool flag = false;
				if ((bool)hitInfo.transform)
				{
					flag = true;
					if (ignoredObstacleColliders != null && ignoredObstacleColliders.Length != 0)
					{
						Collider[] array = ignoredObstacleColliders;
						for (int j = 0; j < array.Length; j++)
						{
							if (array[j] == hitInfo.collider)
							{
								flag = false;
								break;
							}
						}
					}
				}
				if (!flag)
				{
					SetHidden(hide: false);
					return;
				}
			}
			SetHidden(hide: true);
		}

		public void ObstacleDetectionOnValidate()
		{
			CullIfNotSee = true;
			if (OptimizingMethod == EOptimizingMethod.Static)
			{
				Debug.LogError("[OPTIMIZERS] " + OptimizingMethod.ToString() + " method is not supported for FOptimizer_ObstacleDetection component!");
				OptimizingMethod = EOptimizingMethod.Effective;
			}
		}

		public void RefreshCoverageDetectionPoints(List<Vector3> coverageOffsets, Vector3 origin)
		{
			if (coverageActiveArray == null)
			{
				coverageActiveArray = new Vector3[0];
			}
			if (coverageActiveArray.Length != CoverageOffsets.Count)
			{
				coverageActiveArray = new Vector3[CoverageOffsets.Count];
			}
			float num = CoverageScale * 0.7f;
			if (OptimizingMethod == EOptimizingMethod.Effective)
			{
				if (CustomCoveragePoints)
				{
					Quaternion quaternion = Quaternion.LookRotation(OptimizersManager.MainCamera.transform.position - origin);
					for (int i = 0; i < coverageOffsets.Count; i++)
					{
						coverageActiveArray[i] = origin;
						coverageActiveArray[i] += quaternion * Vector3.Scale(coverageOffsets[i] * num, Vector3.one * DetectionRadius);
					}
				}
				else
				{
					Quaternion quaternion2 = Quaternion.LookRotation(OptimizersManager.MainCamera.transform.position - origin);
					for (int j = 0; j < coverageOffsets.Count; j++)
					{
						coverageActiveArray[j] = origin;
						coverageActiveArray[j] += quaternion2 * coverageOffsets[j].normalized * DetectionRadius * num;
					}
				}
			}
			else
			{
				Quaternion quaternion3 = Quaternion.LookRotation(OptimizersManager.MainCamera.transform.position - origin);
				for (int k = 0; k < coverageOffsets.Count; k++)
				{
					coverageActiveArray[k] = origin;
					coverageActiveArray[k] += quaternion3 * Vector3.Scale(coverageOffsets[k] * num, DetectionBounds / 2f);
				}
			}
		}

		private void RefreshCoverageOffsets()
		{
			if (CustomCoveragePoints || currentCoveragePrecision == CoveragePrecision || CoveragePrecision == -1)
			{
				return;
			}
			currentCoveragePrecision = CoveragePrecision;
			CoverageOffsets = new List<Vector3>();
			Vector3[] array = new Vector3[0];
			if (OptimizingMethod == EOptimizingMethod.Effective)
			{
				if (CoveragePrecision == 0)
				{
					array = new Vector3[1]
					{
						new Vector3(0f, 0f, 1f)
					};
				}
				else if (CoveragePrecision == 4)
				{
					array = new Vector3[13];
					array[0] = new Vector3(0f, 0f, 1f);
					array[1] = new Vector3(-1f, 0f, 0f);
					array[2] = new Vector3(1f, 0f, 0f);
					array[3] = new Vector3(0f, 1f, 0f);
					array[4] = new Vector3(0f, -1f, 0f);
					array[5] = new Vector3(-0.5f, 0.5f, 0.85f);
					array[6] = new Vector3(0.5f, 0.5f, 0.85f);
					array[7] = new Vector3(0.5f, -0.5f, 0.85f);
					array[8] = new Vector3(-0.5f, -0.5f, 0.85f);
					array[9] = new Vector3(0.5f, 0.5f, 0f);
					array[11] = new Vector3(-0.5f, 0.5f, 0f);
					array[10] = new Vector3(-0.5f, -0.5f, 0f);
					array[12] = new Vector3(0.5f, -0.5f, 0f);
				}
				else if (CoveragePrecision == 5)
				{
					array = new Vector3[25];
					array[0] = new Vector3(0f, 0f, 1f);
					array[1] = new Vector3(-1f, 0f, 0f);
					array[2] = new Vector3(1f, 0f, 0f);
					array[3] = new Vector3(0f, 1f, 0f);
					array[4] = new Vector3(0f, -1f, 0f);
					array[5] = new Vector3(-0.5f, 0.5f, 0.85f);
					array[6] = new Vector3(0.5f, 0.5f, 0.85f);
					array[7] = new Vector3(0.5f, -0.5f, 0.85f);
					array[8] = new Vector3(-0.5f, -0.5f, 0.85f);
					array[9] = new Vector3(0.5f, 0.5f, 0f);
					array[11] = new Vector3(-0.5f, 0.5f, 0f);
					array[10] = new Vector3(-0.5f, -0.5f, 0f);
					array[12] = new Vector3(0.5f, -0.5f, 0f);
					for (int i = 13; i < array.Length; i++)
					{
						array[i] = new Vector3(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f));
					}
				}
				else if (CoveragePrecision == 3)
				{
					array = new Vector3[9]
					{
						new Vector3(0f, 0f, 1f),
						new Vector3(-1f, 0f, 0f),
						new Vector3(1f, 0f, 0f),
						new Vector3(0f, 1f, 0f),
						new Vector3(0f, -1f, 0f),
						new Vector3(-0.7f, 0.7f, 0.85f),
						new Vector3(0.7f, 0.7f, 0.85f),
						new Vector3(0.7f, -0.7f, 0.85f),
						new Vector3(-0.7f, -0.7f, 0.85f)
					};
				}
				else if (CoveragePrecision == 2)
				{
					array = new Vector3[5]
					{
						new Vector3(0f, 0f, 1f),
						new Vector3(-1f, 1f, 0.4f),
						new Vector3(1f, -1f, 0.4f),
						new Vector3(1f, 1f, 0.4f),
						new Vector3(-1f, -1f, 0.4f)
					};
				}
				else if (CoveragePrecision == 1)
				{
					array = new Vector3[4]
					{
						new Vector3(0f, 0f, 1f),
						new Vector3(0f, 0.4f, 0.1f),
						new Vector3(-0.6f, -0.3f, 0.15f),
						new Vector3(0.6f, -0.3f, 0.15f)
					};
				}
			}
			else if (CoveragePrecision == 0)
			{
				array = new Vector3[1]
				{
					new Vector3(0f, 0f, 1f)
				};
			}
			else if (CoveragePrecision == 4)
			{
				array = new Vector3[13]
				{
					new Vector3(0f, 0f, 1f),
					new Vector3(-1f, 1f, 0.4f),
					new Vector3(1f, -1f, 0.4f),
					new Vector3(1f, 1f, 0.4f),
					new Vector3(-1f, -1f, 0.4f),
					new Vector3(-0.7f, 0.4f, 0.85f),
					new Vector3(0.7f, 0.4f, 0.85f),
					new Vector3(0.7f, -0.4f, 0.85f),
					new Vector3(-0.7f, -0.4f, 0.85f),
					new Vector3(-1f, 0f, 0f),
					new Vector3(1f, 0f, 0f),
					new Vector3(0f, 1f, 0f),
					new Vector3(0f, -1f, 0f)
				};
			}
			else if (CoveragePrecision == 5)
			{
				array = new Vector3[25]
				{
					new Vector3(0f, 0f, 1f),
					new Vector3(-1f, 1f, 0.4f),
					new Vector3(1f, -1f, 0.4f),
					new Vector3(1f, 1f, 0.4f),
					new Vector3(-1f, -1f, 0.4f),
					new Vector3(-0.7f, 0.4f, 0.85f),
					new Vector3(0.7f, 0.4f, 0.85f),
					new Vector3(0.7f, -0.4f, 0.85f),
					new Vector3(-0.7f, -0.4f, 0.85f),
					new Vector3(-1f, 0f, 0f),
					new Vector3(1f, 0f, 0f),
					new Vector3(0f, 1f, 0f),
					new Vector3(0f, -1f, 0f),
					default(Vector3),
					default(Vector3),
					default(Vector3),
					default(Vector3),
					default(Vector3),
					default(Vector3),
					default(Vector3),
					default(Vector3),
					default(Vector3),
					default(Vector3),
					default(Vector3),
					default(Vector3)
				};
				for (int j = 13; j < array.Length; j++)
				{
					array[j] = new Vector3(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(0f, 1f));
				}
			}
			else if (CoveragePrecision == 3)
			{
				array = new Vector3[9]
				{
					new Vector3(0f, 0f, 1f),
					new Vector3(-1f, 1f, 0.4f),
					new Vector3(1f, -1f, 0.4f),
					new Vector3(1f, 1f, 0.4f),
					new Vector3(-1f, -1f, 0.4f),
					new Vector3(-0.7f, 0.4f, 0.85f),
					new Vector3(0.7f, 0.4f, 0.85f),
					new Vector3(0.7f, -0.4f, 0.85f),
					new Vector3(-0.7f, -0.4f, 0.85f)
				};
			}
			else if (CoveragePrecision == 2)
			{
				array = new Vector3[5]
				{
					new Vector3(0f, 0f, 1f),
					new Vector3(-1f, 1f, 0.4f),
					new Vector3(1f, -1f, 0.4f),
					new Vector3(1f, 1f, 0.4f),
					new Vector3(-1f, -1f, 0.4f)
				};
			}
			else if (CoveragePrecision == 1)
			{
				array = new Vector3[4]
				{
					new Vector3(0f, 0f, 1f),
					new Vector3(0f, 0.8f, 0.1f),
					new Vector3(-1f, -0.85f, 0.15f),
					new Vector3(1f, -0.85f, 0.15f)
				};
			}
			CoverageOffsets.Clear();
			for (int k = 0; k < array.Length; k++)
			{
				CoverageOffsets.Add(array[k]);
			}
		}

		public void Gizmos_IsResizingLOD(int lod)
		{
			isResizing = lod;
		}

		public void Gizmos_StopChanging()
		{
			isResizing = -1;
		}

		public void Gizmos_SelectLOD(int lod)
		{
			isSelected = lod;
		}

		protected virtual void OnDrawGizmos()
		{
			if (OptimizersManager.DrawGizmos && DrawGizmos && !(GizmosAlpha <= 0f))
			{
				Gizmos.DrawIcon(base.transform.position, "FIMSpace/Optimizers 2/Optimizers Gizmo Icon.png", allowScaling: true);
			}
		}

		public virtual int GetToOptimizeCount()
		{
			return 0;
		}

		public abstract void RefreshLODSettings();

		public virtual void SwitchOFFOptimizer()
		{
			ChangeLODLevelTo(0);
			SetCulled(culled: false);
			base.enabled = false;
		}

		public virtual void SwitchONOptimizer()
		{
			base.enabled = true;
			ChangeLODLevelTo(CurrentDistanceLODLevel);
			if (CullIfNotSee && OutOfCameraView)
			{
				SetCulled();
			}
		}

		public void SwitchOptimizerEnabled(bool enable)
		{
			if (base.enabled != enable)
			{
				if (enable)
				{
					SwitchONOptimizer();
				}
				else
				{
					SwitchOFFOptimizer();
				}
			}
		}

		private void InitDynamicOptimizer(bool justDynamic)
		{
			PreviousPosition = GetReferencePosition();
			if (manager == null)
			{
				manager = OptimizersManager.Instance;
				if ((bool)OptimizersManager.MainCamera)
				{
					TargetCamera = OptimizersManager.MainCamera.transform;
				}
			}
			if (justDynamic)
			{
				OptimizersManager.Instance.RegisterNotContainedDynamicOptimizer(this, init: true);
			}
			if ((bool)TargetCamera)
			{
				LastTresholdCheckPos = base.transform.position + Vector3.forward * 100f;
				LastTresholdCheckCamPos = TargetCamera.position + Vector3.forward * 100f;
				LastTresholdCheckCamRot = TargetCamera.rotation * Quaternion.Euler(180f, 0f, 0f);
			}
			DynamicListIndex = manager.AddToDynamic(this);
			if (OptimizingMethod != EOptimizingMethod.Effective)
			{
				RefreshDetectionBounds();
			}
		}

		internal void OnDynamicChange(int newIndex)
		{
			DynamicListIndex = newIndex;
		}

		public void RefreshDetectionBounds()
		{
			optimizerBounds = new Bounds(GetReferencePosition(), Vector3.Scale(DetectionBounds, base.transform.lossyScale));
		}

		protected void RefreshDistances()
		{
			float[] distanceMeasures = GetDistanceMeasures();
			DistanceLevels = new float[distanceMeasures.Length];
			for (int i = 0; i < distanceMeasures.Length; i++)
			{
				DistanceLevels[i] = distanceMeasures[i];
			}
		}

		internal abstract Optimizers_LODTransition GetLodTransitionFor(int optimizedIndex, int targetLOD);

		internal abstract ILODInstance GetLODInstance(int i, int targetLODLevel);

		public abstract Component GetOptimizedComponent(int i);

		internal abstract void RemoveToOptimize(LODsControllerBase lODsControllerBase);

		private void DisposeDynamicOptimizer()
		{
			if (!isQuitting && (bool)manager)
			{
				manager.RemoveFromDynamic(this);
			}
		}

		public virtual void DynamicLODUpdate(EOptimizingDistance category, float distance)
		{
			if (UseMultiShape)
			{
				DynamicLODUpdateMiltiShape(category, distance);
			}
			lastDynamicDistance = distance;
			CurrentDynamicDistanceCategory = category;
			if (!base.enabled)
			{
				wasDisabled = true;
				return;
			}
			Vector3 referencePosition = GetReferencePosition();
			int lODForDistance = GetLODForDistance(distance);
			if (OptimizingMethod == EOptimizingMethod.Dynamic)
			{
				if (distance > DistanceLevels[DistanceLevels.Length - 1])
				{
					OutOfDistance = true;
					FarAway = true;
				}
				else
				{
					OutOfDistance = false;
					FarAway = false;
				}
				if (CullIfNotSee)
				{
					optimizerBounds.center = referencePosition;
					OutOfCameraView = !GeometryUtility.TestPlanesAABB(manager.CurrentFrustumPlanes, optimizerBounds);
				}
				else
				{
					OutOfCameraView = false;
				}
				bool flag = false;
				if (lODForDistance != CurrentDistanceLODLevel)
				{
					flag = true;
				}
				else if (WasOutOfCameraView != OutOfCameraView)
				{
					flag = true;
				}
				else if (WasHidden != IsHidden)
				{
					flag = true;
				}
				if (flag)
				{
					RefreshVisibilityState(lODForDistance);
				}
			}
			else if (OptimizingMethod == EOptimizingMethod.Effective)
			{
				EffectiveLODUpdate();
			}
			else
			{
				TriggerLODUpdate();
			}
			PreviousPosition = referencePosition;
			LastDynamicCheckCameraPosition = TargetCamera.position;
			distancePoint = PreviousPosition;
			if (UseObstacleDetection && CoveragePrecision != -1 && !OutOfCameraView && !OutOfDistance)
			{
				ObstacleCheck();
			}
		}

		private int GetLODForDistance(float distance)
		{
			if (DistanceLevels == null)
			{
				Debug.LogWarning("[OPTIMIZERS] There was something wrong with distance ranges of this object (" + base.name + ")");
				RefreshDistances();
			}
			for (int i = 0; i < DistanceLevels.Length; i++)
			{
				if (distance < DistanceLevels[i])
				{
					return i;
				}
			}
			return LODLevels;
		}

		internal bool TresholdTrigger()
		{
			bool num = manager.CameraMoved(LastTresholdCheckCamPos, LastTresholdCheckCamRot);
			LastTresholdCheckCamPos = TargetCamera.position;
			LastTresholdCheckCamRot = TargetCamera.rotation;
			if (num)
			{
				LastTresholdCheckPos = base.transform.position;
				return true;
			}
			float magnitude = (LastTresholdCheckPos - base.transform.position).magnitude;
			LastTresholdCheckPos = base.transform.position;
			if (magnitude >= manager.MoveTreshold)
			{
				return true;
			}
			LastTresholdCheckPos = base.transform.position;
			return false;
		}

		private void InitEffectiveOptimizer()
		{
			if (!AddToContainer)
			{
				OptimizersManager.Instance.RegisterNotContainedEffectiveOptimizer(this, init: true);
			}
			InitCullingGroups(GetDistanceMeasures(), GetDetectionRadiusRaw(), OptimizersManager.MainCamera);
			InitDynamicOptimizer(justDynamic: false);
		}

		private void EffectiveLODUpdate()
		{
			if ((PreviousPosition - mainVisibilitySphere.position).magnitude > moveTreshold)
			{
				RefreshEffectiveCullingGroups();
			}
		}

		protected virtual void RefreshEffectiveCullingGroups()
		{
			if (!UseMultiShape)
			{
				if (OwnerContainer != null)
				{
					OwnerContainer.CullingSpheres[ContainerSphereId].position = GetReferencePosition();
				}
				else
				{
					mainVisibilitySphere.position = GetReferencePosition();
				}
			}
			else
			{
				RefreshEffectiveCullingGroupsMultiShape();
			}
		}

		private void InitTriggerOptimizer()
		{
			if (triggersEntered == null)
			{
				triggersEntered = new List<int>();
			}
			Transform transform = ((OptimizersManager.MainCamera != null) ? OptimizersManager.MainCamera.transform : null);
			if ((bool)transform)
			{
				OnlyCamCollLayer = transform.gameObject.layer;
			}
			TargetCamera = transform;
			float[] distanceMeasures = GetDistanceMeasures();
			DistanceLevels = new float[distanceMeasures.Length];
			for (int i = 0; i < distanceMeasures.Length; i++)
			{
				DistanceLevels[i] = distanceMeasures[i];
			}
			OptimizersManager.Instance.RegisterNotContainedTriggerOptimizer(this, init: true);
			if (CullIfNotSee)
			{
				InitDynamicOptimizer(justDynamic: false);
			}
			TriggerLODUpdate();
			GenerateTriggerHelpers();
			OutOfDistance = true;
			RefreshVisibilityState(CurrentDistanceLODLevel);
		}

		private void TriggerLODUpdate()
		{
			if (CullIfNotSee)
			{
				optimizerBounds.center = GetReferencePosition();
				OutOfCameraView = !GeometryUtility.TestPlanesAABB(manager.CurrentFrustumPlanes, optimizerBounds);
				if (WasOutOfCameraView != OutOfCameraView)
				{
					RefreshVisibilityState(CurrentDistanceLODLevel);
				}
			}
			else
			{
				OutOfCameraView = false;
			}
		}

		internal virtual void OnTriggerChange(Optimizers_TriggerHelper helper, bool exit)
		{
			int num;
			if (!exit)
			{
				if (!triggersEntered.Contains(helper.TriggerIndex))
				{
					triggersEntered.Add(helper.TriggerIndex);
				}
				num = helper.TriggerIndex;
			}
			else
			{
				triggersEntered.Remove(helper.TriggerIndex);
				num = ((triggersEntered.Count != 0) ? triggersEntered[triggersEntered.Count - 1] : LODLevels);
			}
			if (num >= LODLevels + 1)
			{
				num = LODLevels;
			}
			triggerDistanceState = num;
			bool flag = false;
			if (preTriggerDistanceState != num)
			{
				flag = true;
			}
			if (triggersEntered.Count == 0)
			{
				OutOfDistance = true;
			}
			else
			{
				OutOfDistance = false;
			}
			if (flag)
			{
				RefreshVisibilityState(num);
				preTriggerDistanceState = num;
			}
		}

		protected void GenerateTriggerHelpers()
		{
			if (!(triggersContainer == null))
			{
				return;
			}
			GameObject gameObject = new GameObject("Optimizers-" + base.name + "-Triggers");
			triggersContainer = gameObject.transform;
			triggersContainer.SetParent(base.transform);
			triggersContainer.localPosition = DetectionOffset;
			triggersContainer.localRotation = Quaternion.identity;
			triggersContainer.localScale = Vector3.one;
			triggersContainer.gameObject.layer = OnlyCamCollLayer;
			for (int i = 0; i < DistanceLevels.Length; i++)
			{
				GameObject obj = new GameObject(i.ToString());
				Transform obj2 = obj.transform;
				obj2.SetParent(triggersContainer, worldPositionStays: false);
				obj2.localPosition = Vector3.zero;
				obj2.localRotation = Quaternion.identity;
				obj2.localScale = Vector3.one;
				SphereCollider sphereCollider = obj.AddComponent<SphereCollider>();
				sphereCollider.isTrigger = true;
				float num = base.transform.lossyScale.x;
				if (num == 0f)
				{
					num = 1f;
				}
				sphereCollider.radius = DistanceLevels[i] / num;
				obj.AddComponent<Optimizers_TriggerHelper>().Initialize(this, i);
			}
		}

		public float GetDetectionRadiusRaw()
		{
			if (!CullIfNotSee)
			{
				return 0f;
			}
			return DetectionRadius;
		}

		public void TryAutoComputeDetectionShape(float scaleUp = 1f)
		{
			float num = 0f;
			Vector3[] array = null;
			Component component = null;
			List<Vector3[]> list = new List<Vector3[]>();
			for (int i = 0; i < GetToOptimizeCount(); i++)
			{
				Component optimizedComponent = GetOptimizedComponent(i);
				if (!(optimizedComponent == null))
				{
					Vector3[] array2 = MeasureBiggest(optimizedComponent.transform, withLodGroups: false, 0f, optimizedComponent.GetType());
					float x = array2[0].x;
					list.Add(array2);
					if (x > num)
					{
						num = x;
						array = array2;
						component = optimizedComponent;
					}
				}
			}
			if (GetToOptimizeCount() > 1)
			{
				Vector3 zero = Vector3.zero;
				Vector3 zero2 = Vector3.zero;
				Bounds bounds = new Bounds(list[0][2], Vector3.zero);
				Bounds bounds2 = new Bounds(list[0][2] + Vector3.up * list[0][0].x, Vector3.zero);
				for (int j = 0; j < list.Count; j++)
				{
					if (j > 0)
					{
						bounds.Encapsulate(list[j][2]);
					}
					Vector3 vector = base.transform.InverseTransformPoint(list[j][2]);
					Vector3 vector2 = base.transform.InverseTransformVector(Vector3.one * list[j][0].x);
					if (vector.x + vector2.x > zero.x)
					{
						zero.x = vector.x + vector2.x;
					}
					else if (vector.x - vector2.x < zero2.x)
					{
						zero2.x = vector.x - vector2.x;
					}
					if (vector.y + vector2.y > zero.y)
					{
						zero.y = vector.y + vector2.y;
					}
					else if (vector.y - vector2.y < zero2.y)
					{
						zero2.y = vector.y - vector2.y;
					}
					if (vector.z + vector2.z > zero.z)
					{
						zero.z = vector.z + vector2.z;
					}
					else if (vector.z - vector2.z < zero2.z)
					{
						zero2.z = vector.z - vector2.z;
					}
					if (j > 0)
					{
						bounds2.Encapsulate(list[j][2] + Vector3.up * list[j][0].x);
					}
					bounds2.Encapsulate(list[j][2] + Vector3.down * list[j][0].x);
					bounds2.Encapsulate(list[j][2] - Vector3.right * list[j][0].x);
					bounds2.Encapsulate(list[j][2] + Vector3.right * list[j][0].x);
					bounds2.Encapsulate(list[j][2] - Vector3.forward * list[j][0].x);
					bounds2.Encapsulate(list[j][2] + Vector3.forward * list[j][0].x);
				}
				DetectionRadius = GetBiggest(zero);
				if (GetBiggest(zero2, abs: true) > DetectionRadius)
				{
					DetectionRadius = GetBiggest(zero2, abs: true);
				}
				DetectionBounds = Vector3.zero;
				DetectionOffset = base.transform.InverseTransformPoint(bounds.center);
				DetectionOffset = base.transform.InverseTransformPoint(bounds2.center);
				DetectionRadius = bounds2.extents.magnitude;
				DetectionBounds = bounds2.extents * 2f;
			}
			else if (array != null)
			{
				DetectionRadius = array[0].x;
				DetectionBounds = array[1] * 2f;
				if (component != null)
				{
					DetectionOffset = base.transform.InverseTransformPoint(array[2]);
				}
			}
			DetectionRadius /= base.transform.lossyScale.x;
			DetectionRadius *= scaleUp;
			DetectionBounds.x /= base.transform.lossyScale.x;
			DetectionBounds.y /= base.transform.lossyScale.y;
			DetectionBounds.z /= base.transform.lossyScale.z;
			DetectionBounds *= scaleUp;
		}

		public static float GetBiggest(Vector3 from, bool abs = false)
		{
			if (abs)
			{
				from.x = Mathf.Abs(from.x);
				from.y = Mathf.Abs(from.y);
				from.z = Mathf.Abs(from.z);
			}
			if (from.x > from.y)
			{
				if (from.z > from.x)
				{
					return from.z;
				}
				return from.x;
			}
			if (from.z > from.y)
			{
				return from.z;
			}
			return from.y;
		}

		public static Vector3[] MeasureBiggest(Transform t, bool withLodGroups = true, float limitTo = 0f, Type checkOnly = null)
		{
			Vector3[] array = new Vector3[3]
			{
				default(Vector3),
				default(Vector3),
				default(Vector3)
			};
			float num = 0f;
			float num2 = 0f;
			float num3 = 0f;
			Vector3 vector = Vector3.zero;
			Vector3 vector2 = Vector3.zero;
			bool flag = true;
			if (checkOnly != null && typeof(Collider) == checkOnly)
			{
				flag = true;
			}
			if (flag)
			{
				Collider component = t.gameObject.GetComponent<Collider>();
				if ((bool)component)
				{
					num = component.bounds.extents.magnitude;
					if (num > num2)
					{
						num2 = num;
						if (num > num3)
						{
							num3 = num;
						}
					}
					if (component.bounds.extents.magnitude > vector.magnitude)
					{
						vector = component.bounds.extents;
						vector2 = component.bounds.center;
					}
				}
			}
			bool flag2 = true;
			if (checkOnly != null)
			{
				if (typeof(Renderer) == checkOnly)
				{
					flag2 = true;
				}
				if (typeof(MeshRenderer) == checkOnly)
				{
					flag2 = true;
				}
				if (typeof(SkinnedMeshRenderer) == checkOnly)
				{
					flag2 = true;
				}
			}
			if (flag2)
			{
				Renderer component2 = t.gameObject.GetComponent<Renderer>();
				if ((bool)component2)
				{
					num = component2.bounds.extents.magnitude;
					if (num > num2)
					{
						num2 = num;
						if (num > num3)
						{
							num3 = num;
						}
					}
					if (component2.bounds.extents.magnitude > vector.magnitude)
					{
						vector = component2.bounds.extents;
						vector2 = component2.bounds.center;
					}
				}
			}
			bool flag3 = true;
			if (checkOnly != null && typeof(Light) == checkOnly)
			{
				flag3 = true;
			}
			if (flag3)
			{
				Light component3 = t.gameObject.GetComponent<Light>();
				if ((bool)component3)
				{
					num = component3.range * 1.2f;
				}
				if (num > num2)
				{
					num2 = num;
				}
			}
			bool flag4 = true;
			if (checkOnly != null && typeof(ParticleSystem) == checkOnly)
			{
				flag4 = true;
			}
			if (flag4)
			{
				ParticleSystem component4 = t.gameObject.GetComponent<ParticleSystem>();
				if ((bool)component4)
				{
					ParticleSystemRenderer component5 = component4.GetComponent<ParticleSystemRenderer>();
					if ((bool)component5)
					{
						num = Vector3.Scale(component5.bounds.extents, t.lossyScale).magnitude * 2f;
						if (num > num2)
						{
							num2 = num;
							if (num > num3)
							{
								num3 = num;
							}
						}
						if (component5.bounds.extents.magnitude > vector.magnitude)
						{
							vector = Vector3.Scale(component5.bounds.extents, t.lossyScale);
							vector2 = component5.bounds.center;
						}
					}
				}
			}
			if (withLodGroups)
			{
				LODGroup component6 = t.gameObject.GetComponent<LODGroup>();
				if ((bool)component6)
				{
					component6.RecalculateBounds();
					float screenRelativeTransitionHeight = component6.GetLODs()[component6.GetLODs().Length - 1].screenRelativeTransitionHeight;
					Camera camera = OptimizersManager.MainCamera;
					if (camera == null)
					{
						camera = Camera.main;
					}
					float num4 = 60f;
					if ((bool)camera)
					{
						num4 = camera.fieldOfView;
					}
					float num5 = 100f / num4;
					num = 0.3f * component6.size * num5 * component6.transform.lossyScale.x / screenRelativeTransitionHeight;
					if (component6.GetLODs().Length == 1)
					{
						num *= 0.75f;
					}
					if (num > num2)
					{
						num2 = num;
					}
				}
			}
			if (limitTo > 0f && num2 > limitTo)
			{
				num2 = limitTo;
			}
			if (vector2 == Vector3.zero)
			{
				vector2 = t.position;
			}
			if (t.lossyScale.x == 0f || t.lossyScale.y == 0f || t.lossyScale.z == 0f)
			{
				Debug.Log("[Optimizers] Object can't have zero scale in any axis! (" + t.name + ")");
				array[0].x = num2;
				if (vector.magnitude == 0f)
				{
					vector = Vector3.one * num2;
				}
				array[1] = vector;
				array[2] = vector;
				array[3] = vector2;
				return array;
			}
			array[0].x = num2;
			if (vector.magnitude == 0f)
			{
				vector = Vector3.one * num2;
			}
			array[1] = vector;
			array[2] = vector2;
			return array;
		}

		public void CheckAndRemoveRenderersAlreadyInOtherLODGroup()
		{
			for (int i = 0; i < GetToOptimizeCount(); i++)
			{
				LODGroup lODGroup = GetOptimizedComponent(i) as LODGroup;
				if (!(lODGroup != null))
				{
					continue;
				}
				for (int num = GetToOptimizeCount(); num >= 0; num--)
				{
					Renderer renderer = GetOptimizedComponent(num) as Renderer;
					if ((bool)renderer && IsRendererInLODGroup(renderer, lODGroup))
					{
						RemoveFromToOptimizeAt(num);
					}
				}
				if (lODGroup.lodCount > LODLevels)
				{
					LODLevels = lODGroup.lodCount;
				}
			}
			EditorUpdate();
		}

		public static bool IsRendererInLODGroup(Renderer r, LODGroup lod)
		{
			for (int i = 0; i < lod.lodCount; i++)
			{
				for (int j = 0; j < lod.GetLODs()[i].renderers.Length; j++)
				{
					if (lod.GetLODs()[i].renderers[j] == r)
					{
						return true;
					}
				}
			}
			return false;
		}
	}
}
