using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Effects;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using Managers.Selection.EventData;
using NGS.MeshFusionPro;
using NSEipix;
using NSEipix.Base;
using NSEipix.Model;
using NSEipix.Repository;
using NSMedieval.Construction;
using NSMedieval.Controllers;
using NSMedieval.Dictionary;
using NSMedieval.Enums;
using NSMedieval.EnvironmentEffects;
using NSMedieval.Goap;
using NSMedieval.Layers;
using NSMedieval.Manager;
using NSMedieval.Managers;
using NSMedieval.Managers.Selection;
using NSMedieval.Map;
using NSMedieval.Model;
using NSMedieval.MovableBuildings;
using NSMedieval.OcclusionCulling;
using NSMedieval.PlayerTriggeredEventSystem;
using NSMedieval.Pool;
using NSMedieval.Repository;
using NSMedieval.Research;
using NSMedieval.Scripts.Pooler;
using NSMedieval.State;
using NSMedieval.StatsSystem;
using NSMedieval.Tutorial;
using NSMedieval.Types;
using NSMedieval.UI;
using NSMedieval.UI.Utils;
using NSMedieval.View;
using NSMedieval.Views.Resources;
using NSMedieval.Village;
using NSMedieval_Pooling;
using UnityEngine;
using UnityEngine.Rendering;

namespace NSMedieval.BuildingComponents
{
	[DisallowMultipleComponent]
	[RequireComponent(typeof(MeshVariationHandler))]
	public class BaseBuildingViewComponent : SelectableObject, IPoolable, IGameDisposable, IDisposable, IAdditionalMenuOwner, IOcclusionObject
	{
		private static readonly int PlaceBlueprint = Animator.StringToHash("PlaceBlueprint");

		private readonly LayerObjectHide layerObjectHide = new LayerObjectHide();

		[SerializeField]
		private GameObject blueprint;

		[SerializeField]
		private GameObject foundation;

		[SerializeField]
		private GameObject finished;

		[SerializeField]
		private List<MeshRenderer> shadowCasters;

		[SerializeField]
		private List<GameObject> lodsAndShadowCasters;

		[SerializeField]
		private List<LODGroup> lodGroups;

		[SerializeField]
		private List<GameObject> lods;

		[SerializeField]
		private GameObject destructionMarker;

		[SerializeField]
		private string buildBlueprintParticles = "blueprint_placed";

		private List<GameObject> workPositionsMarkers;

		[SerializeField]
		private BlueprintPlacedEffect blueprintPlacedEffect;

		[NonSerialized]
		private Shaker shaker;

		[NonSerialized]
		private BaseBuildingInstance baseBuildingInstance;

		[NonSerialized]
		private BaseBuildingBlueprint baseBuildingBlueprint;

		[NonSerialized]
		private ResourcePileIndicatorView indicatorUI;

		[NonSerialized]
		private Collider clickCollider;

		private GameObject combatColliderGameObject;

		[SerializeField]
		private Collider[] particleBuildEmitterColliders;

		[SerializeField]
		private Collider[] particleFoundationEmitterColliders;

		[SerializeField]
		private MeshFusionSource[] meshFusionSources;

		[NonSerialized]
		private GameObject particlesBlueprintInstance;

		[NonSerialized]
		private FoundationSetup foundationSetup;

		[NonSerialized]
		private InfoPanelData infoPanelData;

		[NonSerialized]
		private bool isForceHidden;

		[NonSerialized]
		private bool isHealthAtMax;

		[NonSerialized]
		private bool isInMeshFusion;

		private string overridenAdditionalMenuItemId = "buildingFinished";

		private MeshVariationHandler meshVariationHandler;

		[NonSerialized]
		private SelectionExtraView selectionExtraView;

		[NonSerialized]
		public Func<InfoPanelBody, InfoPanelBody> injectComponentDataEvent;

		private BuildingUsePositionsComponent buildingUseComponent;

		private Bounds occlusionLocalSpaceBoundingBox;

		public Bounds OcclusionLocalSpaceBoundingBox
		{
			get
			{
				return occlusionLocalSpaceBoundingBox;
			}
			set
			{
				occlusionLocalSpaceBoundingBox = value;
				if (MonoSingleton<OcclusionCullingManager>.IsInstantiated())
				{
					MonoSingleton<OcclusionCullingManager>.Instance.RefreshChunk(this);
				}
			}
		}

		[field: NonSerialized]
		public List<MeshRenderer> BlueprintMeshRenderers { get; private set; }

		[field: NonSerialized]
		public List<MeshRenderer> FoundationMeshRenderers { get; private set; }

		[field: NonSerialized]
		public List<MeshRenderer> FinishedMeshRenderers { get; private set; }

		public bool IgnoreSelectionHighlight { get; set; }

		public bool HasDisposed { get; private set; }

		public LayerObjectHide LayerObjectHide => layerObjectHide;

		public override bool IsBuilding => true;

		[field: NonSerialized]
		public BuildProgress BuildProgress { get; private set; }

		public Collider ClickCollider
		{
			get
			{
				if (clickCollider == null)
				{
					clickCollider = base.gameObject.GetComponentInChildren<Collider>();
				}
				return clickCollider;
			}
			set
			{
				clickCollider = value;
			}
		}

		public bool IsOcclusionCulled
		{
			get
			{
				return LayerObjectHide.IsOcclusionCulled;
			}
			set
			{
				if (!isInMeshFusion && layerObjectHide.IsOcclusionCulled != value)
				{
					LayerObjectHide.IsOcclusionCulled = value;
					this.BuildingOcclusionCullingChangedEvent?.Invoke(value);
				}
			}
		}

		public BaseBuildingInstance BaseBuildingInstance => baseBuildingInstance;

		public override bool Visible => layerObjectHide.Visible;

		public GameObject Blueprint => blueprint;

		public GameObject Foundation => foundation;

		public GameObject Finished => finished;

		public IEnumerable<MeshFusionSource> MeshFusionSources => meshFusionSources;

		public OcclusionCullingMode OcclusionCullingMode
		{
			get
			{
				if (baseBuildingInstance?.Blueprint == null || !MonoSingleton<GlobalSaveController>.IsInstantiated() || GlobalSaveController.CurrentVillageData == null)
				{
					return OcclusionCullingMode.Disabled;
				}
				OcclusionCullingMode occlusionCullingMode = baseBuildingInstance.Blueprint.OcclusionCullingMode;
				if (occlusionCullingMode == OcclusionCullingMode.Disabled)
				{
					return OcclusionCullingMode.Disabled;
				}
				if (baseBuildingInstance.BuildingType == BuildingType.Roof && !GlobalSaveController.CurrentVillageData.RoofsVisible)
				{
					occlusionCullingMode = OcclusionCullingMode.CanBeOccludedOnly;
				}
				if (baseBuildingInstance.ConstructionPhase != ConstructionPhase.Blueprint)
				{
					return occlusionCullingMode;
				}
				return OcclusionCullingMode.CanBeOccludedOnly;
			}
		}

		public Vector3 WorldPosition
		{
			get
			{
				if (!(this == null))
				{
					return base.transform.position;
				}
				return Vector3.zero;
			}
		}

		[field: NonSerialized]
		public event Action OverrideSelectionExtraViewEvent;

		[field: NonSerialized]
		public event Action<BaseBuildingInstance> ConstructionCompletedEvent;

		[field: NonSerialized]
		public event Action RequestInfoPanelDataEvent;

		[field: NonSerialized]
		public event Action<bool> ObjectPlacedOnMapEvent;

		[field: NonSerialized]
		public event Action<bool> AfterBaseBuildingPlacedEvent;

		[field: NonSerialized]
		public event Action EnterPoolEvent;

		[field: NonSerialized]
		public event Action ExitPoolEvent;

		[field: NonSerialized]
		public event Action ReturnToBlueprintEvent;

		[field: NonSerialized]
		public event Action BaseBuildingEnterFoundationStateEvent;

		[field: NonSerialized]
		public event Action BaseBuildingEnterFinishedStateEvent;

		[field: NonSerialized]
		public event Action ReturnToPoolEvent;

		[field: NonSerialized]
		public event Action DisposedInternalEvent;

		[field: NonSerialized]
		public event Action<IGameDisposable> OnDisposedEvent;

		[field: NonSerialized]
		public event Action BuildingMeshVariationRotatedEvent;

		[field: NonSerialized]
		public event Action BuildingMeshVariationSetEvent;

		public event Func<Transform> RequestGuiOverlayHookTransformEvent;

		[field: NonSerialized]
		public event Action BuildingSelectedEvent;

		[field: NonSerialized]
		public event Action BuildingDeselectedEvent;

		[field: NonSerialized]
		public event Action<bool> BuildingOcclusionCullingChangedEvent;

		public void SetBaseBuildingInstance(BaseBuildingInstance baseBuildingInstance)
		{
			this.baseBuildingInstance = baseBuildingInstance;
			baseBuildingBlueprint = baseBuildingInstance.Blueprint;
			this.baseBuildingInstance.BuildingMeshVariationRotatedEvent += OnBuildingMeshVariationRotated;
			this.baseBuildingInstance.BuildingMeshVariationFlippedEvent += OnBuildingMeshVariationFlipped;
			this.baseBuildingInstance.BuildingMeshVariationSetEvent += BuildingMeshVariationSet;
			this.baseBuildingInstance.SelectBuildingEvent += OnSelectBuilding;
			this.baseBuildingInstance.PileForbidChangedColorBlueprintEvent += OnPileForbidChangedColorBlueprint;
			if (this.baseBuildingInstance.Stats != null)
			{
				isHealthAtMax = this.baseBuildingInstance.Stats.GetStat(StatType.Health).IsAtMaximum();
			}
			else
			{
				isHealthAtMax = !baseBuildingInstance.HasDisposed;
			}
			InitModelSettings();
		}

		public override void OnLeavingMainScene()
		{
			RemoveFromMeshFusion();
			layerObjectHide?.Reset();
			ResetShadowCastingMode();
			base.OnLeavingMainScene();
			ClearEvents();
		}

		private void ClearEvents()
		{
			this.OverrideSelectionExtraViewEvent = null;
			this.ConstructionCompletedEvent = null;
			this.RequestInfoPanelDataEvent = null;
			this.ObjectPlacedOnMapEvent = null;
			this.AfterBaseBuildingPlacedEvent = null;
			this.EnterPoolEvent = null;
			this.ExitPoolEvent = null;
			this.ReturnToBlueprintEvent = null;
			this.BaseBuildingEnterFoundationStateEvent = null;
			this.BaseBuildingEnterFinishedStateEvent = null;
			this.DisposedInternalEvent = null;
			this.ReturnToPoolEvent = null;
			this.OnDisposedEvent = null;
			this.RequestGuiOverlayHookTransformEvent = null;
			this.BuildingMeshVariationRotatedEvent = null;
			this.BuildingMeshVariationSetEvent = null;
			this.BuildingSelectedEvent = null;
			this.BuildingDeselectedEvent = null;
			this.BuildingOcclusionCullingChangedEvent = null;
			injectComponentDataEvent = null;
			baseBuildingInstance = null;
			infoPanelData = null;
			selectionExtraView = null;
		}

		public List<GameObject> OnPlayParticlesFromColliderVolume(string particleName, bool autoStop = true, bool unscaledTime = false, Action<GameObject> callback = null)
		{
			List<GameObject> list = new List<GameObject>();
			Collider[] array;
			if (!string.IsNullOrEmpty(baseBuildingInstance.Blueprint.MeshColliderMeshId))
			{
				Collider[] obj = new Collider[1] { clickCollider };
				array = obj;
				particleFoundationEmitterColliders = obj;
				particleBuildEmitterColliders = array;
			}
			array = particleBuildEmitterColliders;
			foreach (Collider collider in array)
			{
				GameObject gameObject = MonoSingleton<ParticleSystemPool>.Instance.PlayParticles(particleName, MonoSingleton<ParticleSystemPool>.Instance.transform, autoStop, unscaledTime, callback);
				MonoSingleton<ParticleSystemPool>.Instance.SetEmitterSize(particleName, gameObject, collider, 1f);
				if (gameObject != null)
				{
					gameObject.transform.position = collider.gameObject.transform.position;
				}
				list.Add(gameObject);
			}
			return list;
		}

		private void InitModelSettings()
		{
			BaseBuildingBlueprint baseBuildingBlueprint = baseBuildingInstance.Blueprint;
			HandleSelectionBoxCollider(baseBuildingBlueprint);
			if (buildingUseComponent != null)
			{
				buildingUseComponent.Initialize(baseBuildingBlueprint.WorkPositionsArray);
			}
			if (baseBuildingBlueprint.Cover <= 0f || baseBuildingBlueprint.BuildingType == BuildingType.Roof)
			{
				return;
			}
			combatColliderGameObject = GameObjectPool.GetDefaultEmpty(returnActive: false, "CombatCollider");
			combatColliderGameObject.transform.SetParent(finished.transform.parent, worldPositionStays: false);
			combatColliderGameObject.layer = LayerMask.NameToLayer("CombatCover");
			if (!string.IsNullOrEmpty(baseBuildingBlueprint.MeshColliderMeshId))
			{
				MeshCollider meshCollider = combatColliderGameObject.AddComponent<MeshCollider>();
				meshCollider.sharedMesh = MonoRepository<MeshRepository, NSMedieval.Model.KeyGameObjectPair>.Instance.GetMeshByAddress(baseBuildingBlueprint.MeshColliderMeshId);
				meshCollider.convex = true;
				meshCollider.cookingOptions = MeshColliderCookingOptions.UseFastMidphase;
				return;
			}
			BoxCollider boxCollider = combatColliderGameObject.AddComponent<BoxCollider>();
			boxCollider.center = Vector3.zero;
			boxCollider.size = Vector3.zero;
			if (baseBuildingBlueprint.CombatBoxColliderSettings.IsValid)
			{
				baseBuildingBlueprint.CombatBoxColliderSettings.ApplyToBoxCollider(boxCollider);
			}
			else
			{
				baseBuildingBlueprint.BoxColliderSettings.ApplyToBoxCollider(boxCollider);
			}
		}

		private void HandleSelectionBoxCollider(BaseBuildingBlueprint blueprint)
		{
			BoxCollider component = GetComponent<BoxCollider>();
			if (!(component == null))
			{
				component.center = Vector3.zero;
				component.size = Vector3.zero;
				if (blueprint.BoxColliderSettings.IsValid)
				{
					blueprint.BoxColliderSettings.ApplyToBoxCollider(component);
				}
				destructionMarker.transform.localPosition = component.center;
				UpdateOcclusionBoundingBox();
			}
		}

		private void OnDrawGizmos()
		{
			Gizmos.color = Color.white;
			Gizmos.DrawSphere(destructionMarker.transform.position, 0.2f);
			Gizmos.color = Color.gray;
			Gizmos.DrawSphere(destructionMarker.transform.position, 0.15f);
			Gizmos.color = Color.green;
			Gizmos.DrawSphere(destructionMarker.transform.position, 0.1f);
		}

		public override WorldObject GetAsWorldObject()
		{
			return baseBuildingInstance;
		}

		public void SetAdditionalMenuItemId(string overridenAdditionalMenuItemId)
		{
			this.overridenAdditionalMenuItemId = overridenAdditionalMenuItemId;
		}

		private void OnSelectBuilding()
		{
			Select();
		}

		private void OnPileForbidChangedColorBlueprint(bool sourcePileForbidden)
		{
			ColorBlueprint(sourcePileForbidden ? 0f : 2f);
		}

		public void SetForceHide(bool hidden)
		{
			isForceHidden = hidden;
		}

		public override void RefreshVisibility(float layerLevel = float.NaN)
		{
			if (!isForceHidden)
			{
				if (float.IsNaN(layerLevel))
				{
					layerLevel = MonoSingleton<World>.Instance.LayerLevel;
				}
				layerObjectHide.RefreshVisibility(layerLevel);
				if (BaseBuildingInstance != null && !BaseBuildingInstance.HasDisposed && BaseBuildingInstance.ConstructionPhase == ConstructionPhase.Finished && finished != null && !finished.activeSelf)
				{
					finished.SetActive(value: true);
				}
			}
		}

		public override void SetMeshRenderersVisible(bool visible)
		{
			if (isForceHidden)
			{
				visible = false;
			}
			if (visible)
			{
				layerObjectHide.RefreshVisibility(MonoSingleton<World>.Instance.LayerLevel);
			}
			else
			{
				layerObjectHide.ForceHide();
			}
		}

		protected override bool IsSelectionNull()
		{
			if (baseBuildingInstance != null)
			{
				return baseBuildingInstance.HasDisposed;
			}
			return true;
		}

		protected override void Awake()
		{
			base.Awake();
			clickCollider = base.gameObject.GetComponentInChildren<Collider>();
			foundationSetup = base.gameObject.GetComponent<FoundationSetup>();
			BuildProgress = base.gameObject.GetComponent<BuildProgress>();
			workPositionsMarkers = new List<GameObject>();
			buildingUseComponent = GetComponent<BuildingUsePositionsComponent>();
			BlueprintMeshRenderers = blueprint.GetComponentsInChildren<MeshRenderer>().ToList();
			FoundationMeshRenderers = LayerObjectHide.GetMeshRenderers(foundation);
			FinishedMeshRenderers = LayerObjectHide.GetMeshRenderers(finished, shadowCasters);
			foreach (MeshRenderer blueprintMeshRenderer in BlueprintMeshRenderers)
			{
				blueprintMeshRenderer.SetPropertyBlock(new MaterialPropertyBlock());
			}
			foreach (MeshRenderer finishedMeshRenderer in FinishedMeshRenderers)
			{
				finishedMeshRenderer.SetPropertyBlock(new MaterialPropertyBlock());
			}
			shaker = GetComponent<Shaker>();
			meshVariationHandler = GetComponent<MeshVariationHandler>();
			bool isEnabled;
			if (base.gameObject.name.Contains("wall_element") && base.gameObject.activeInHierarchy)
			{
				FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(29, 3, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Constructables\\Building Components\\Basic buildings\\BaseBuildingViewComponent.cs");
				if (isEnabled)
				{
					messageBuilder.AppendFormatted(base.gameObject.GetHashCode());
					messageBuilder.AppendLiteral("-");
					messageBuilder.AppendFormatted(base.gameObject.name);
					messageBuilder.AppendLiteral(" this.meshVariationHandler: ");
					messageBuilder.AppendFormatted(meshVariationHandler == null);
				}
				Log.Debug(messageBuilder);
			}
			if (meshVariationHandler == null)
			{
				FVLogErrorInterpolationHandler messageBuilder2 = new FVLogErrorInterpolationHandler(39, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Constructables\\Building Components\\Basic buildings\\BaseBuildingViewComponent.cs");
				if (isEnabled)
				{
					messageBuilder2.AppendLiteral("meshVariationHandler not assigned for ");
					messageBuilder2.AppendFormatted(base.gameObject.GetHashCode());
					messageBuilder2.AppendLiteral(" ");
				}
				Log.Error(messageBuilder2);
			}
		}

		public void UpdateOcclusionBoundingBox()
		{
			if (FinishedMeshRenderers != null)
			{
				occlusionLocalSpaceBoundingBox = new Bounds(base.transform.position, Vector3.zero);
				foreach (MeshRenderer finishedMeshRenderer in FinishedMeshRenderers)
				{
					if (finishedMeshRenderer != null)
					{
						occlusionLocalSpaceBoundingBox.Encapsulate(finishedMeshRenderer.bounds);
					}
				}
				occlusionLocalSpaceBoundingBox.center -= base.transform.position;
			}
			if (MonoSingleton<OcclusionCullingManager>.IsInstantiated())
			{
				MonoSingleton<OcclusionCullingManager>.Instance.RefreshChunk(this);
			}
		}

		protected override void Start()
		{
			base.Start();
			base.gameObject.tag = "Building";
			Transform[] componentsInChildren = base.transform.GetComponentsInChildren<Transform>(includeInactive: true);
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				componentsInChildren[i].tag = "Building";
			}
			UpdateOcclusionBoundingBox();
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			if (MonoSingleton<LayerHidingManager>.IsInstantiated())
			{
				MonoSingleton<LayerHidingManager>.Instance.LayerDownConstructablesEvent -= RefreshVisibility;
				MonoSingleton<LayerHidingManager>.Instance.LayerUpConstructablesEvent -= RefreshVisibility;
			}
			ClearEvents();
			BuildProgress = null;
			shaker = null;
			baseBuildingInstance = null;
		}

		public string GetAdditionalMenuId()
		{
			if (BaseBuildingInstance == null || BaseBuildingInstance.HasDisposed)
			{
				return string.Empty;
			}
			return BaseBuildingInstance.ConstructionPhase switch
			{
				ConstructionPhase.Blueprint => "buildingBlueprint", 
				ConstructionPhase.Foundation => "buildingFoundation", 
				ConstructionPhase.Finished => overridenAdditionalMenuItemId, 
				_ => "building", 
			};
		}

		public IGoapTargetable GetAsTarget()
		{
			return BaseBuildingInstance;
		}

		public Transform GetGuiOverlayHookTransform()
		{
			Transform transform = this.RequestGuiOverlayHookTransformEvent?.Invoke();
			if (!(transform != null))
			{
				return base.transform;
			}
			return transform;
		}

		public bool ShouldMenuFollowHookTransform()
		{
			return true;
		}

		protected override void OnPointerEnter(Vector3 pos)
		{
			switch (MonoSingleton<SelectionManager>.Instance.OrderType)
			{
			case OrderType.Allow:
			case OrderType.Forbid:
			{
				BaseBuildingInstance obj = baseBuildingInstance;
				if (obj != null && obj.ConstructionPhase == ConstructionPhase.Finished)
				{
					return;
				}
				break;
			}
			case OrderType.CutAllVegetation:
			case OrderType.Chopping:
			case OrderType.Harvesting:
			case OrderType.Hunting:
			case OrderType.UrgentHaul:
			case OrderType.Digging:
			case OrderType.Fishing:
				return;
			}
			base.OnPointerEnter(pos);
		}

		private void ResetMeshVariationsOnEnterPool()
		{
			if (!(baseBuildingBlueprint == null))
			{
				UpdateMeshVariation(baseBuildingBlueprint.GetMeshVariation("default"));
				meshVariationHandler.UpdateMeshRotation(0f, flipX: false, flipZ: false);
				ResetLodsAndShadowCastersTransform();
				baseBuildingBlueprint = null;
			}
		}

		public void EnterPool()
		{
			ResetMeshVariationsOnEnterPool();
			if (!blueprint.activeSelf)
			{
				blueprint.SetActive(value: true);
			}
			if (foundation.activeSelf)
			{
				foundation.SetActive(value: false);
			}
			if (finished.activeSelf)
			{
				finished.SetActive(value: false);
			}
			if (MonoSingleton<SelectableObjectManager>.IsInstantiated())
			{
				MonoSingleton<SelectableObjectManager>.Instance.RemoveObject(this);
			}
			if (combatColliderGameObject != null)
			{
				GameObjectPool.Return(combatColliderGameObject);
				combatColliderGameObject = null;
			}
			if (shadowCasters != null)
			{
				foreach (MeshRenderer shadowCaster in shadowCasters)
				{
					if (!(shadowCaster == null))
					{
						shadowCaster.shadowCastingMode = ShadowCastingMode.ShadowsOnly;
						shadowCaster.enabled = false;
					}
				}
			}
			layerObjectHide?.Reset();
			layerObjectHide?.SetOwnerBuilding(null);
			ResetShadowCastingMode();
			this.EnterPoolEvent?.Invoke();
			baseBuildingInstance?.Dispose();
			baseBuildingInstance = null;
			if (buildingUseComponent != null)
			{
				buildingUseComponent.Dispose();
			}
		}

		public void ExitPool()
		{
			SetPlaceableMaterial();
			if (ClickCollider != null)
			{
				ClickCollider.enabled = true;
			}
			if (destructionMarker != null)
			{
				destructionMarker.SetActive(value: false);
				MonoSingleton<OrderMarkAnimationManager>.Instance.CancelOngoingAnimation(destructionMarker);
			}
			MonoSingleton<SelectableObjectManager>.Instance.RegisterObject(this);
			this.ExitPoolEvent?.Invoke();
		}

		private void OnReturnToBlueprint()
		{
			baseBuildingInstance.BaseBuildingEnterFoundationStateEvent += OnBaseBuildingEnterFoundationState;
			foundation.SetActive(value: false);
			blueprint.SetActive(value: true);
			finished.SetActive(value: false);
			layerObjectHide.SetupMeshRenderers(BlueprintMeshRenderers);
			List<MeshRenderer> list = new List<MeshRenderer>();
			list.AddRange(BlueprintMeshRenderers);
			list.AddRange(FoundationMeshRenderers);
			list.AddRange(FinishedMeshRenderers);
			layerObjectHide.ResetAfterFailedConstruction(MonoSingleton<World>.Instance.ElevationLevel, list);
			layerObjectHide.RefreshVisibility(MonoSingleton<World>.Instance.ElevationLevel);
			UpdateMeshVariation();
			UpdateMeshRotation();
			ColorBlueprint(2f);
			if (BuildProgress != null)
			{
				BuildProgress.ResetProgress();
			}
			StringIntDictionary materials = baseBuildingInstance.Blueprint.Materials;
			if (materials != null && materials.Dictionary?.Count == 0)
			{
				OnBaseBuildingEnterFoundationState();
			}
			this.ReturnToBlueprintEvent?.Invoke();
			UpdateOcclusionBoundingBox();
		}

		public void InitMeshVariationOnLoad()
		{
			UpdateMeshVariation();
			UpdateMeshRotation();
			ResetLodsAndShadowCastersTransform();
		}

		private void OnOrderDestruction(BuildingOrderEventData eventData)
		{
			if (IgnoreSelectionHighlight || baseBuildingInstance == null || baseBuildingInstance.HasDisposed || !baseBuildingInstance.OwnedByPlayer() || (int)(base.transform.position.y / (float)World.MapBlockHeight) > MonoSingleton<World>.Instance.ElevationLevel || (eventData.AffectOnlyOneLayer && (int)base.transform.position.y != (int)eventData.Y) || (eventData.OrderType == OrderType.Deconstructing && !eventData.BuildingTypes.HasFlag(baseBuildingInstance.BuildingType)))
			{
				return;
			}
			bool flag = false;
			foreach (Vec3Int position in baseBuildingInstance.Positions)
			{
				if (SelectionManager.IsWithinSelectionBounds((Vector3)position, eventData.MinPoint.x, eventData.MaxPoint.x, eventData.MinPoint.y, eventData.MaxPoint.y))
				{
					flag = true;
				}
			}
			if (flag)
			{
				HandleOrderDragSelection(eventData.OrderType);
			}
		}

		private void OnBaseBuildingEnterFoundationState(bool afterLoading = false)
		{
			if (baseBuildingInstance == null || baseBuildingInstance.HasDisposed)
			{
				Log.Warning("OnBaseBuildingEnterFoundationState building was disposed or null.", "C:\\GIT\\dev\\Assets\\Scripts\\Constructables\\Building Components\\Basic buildings\\BaseBuildingViewComponent.cs");
				return;
			}
			if (foundationSetup != null)
			{
				foundationSetup.SetDynamicSize(BaseBuildingInstance.Positions);
			}
			if (blueprint.activeSelf)
			{
				blueprint.SetActive(value: false);
			}
			if (!foundation.activeSelf && BaseBuildingInstance.ConstructionPhase == ConstructionPhase.Foundation)
			{
				OnPlayParticlesFromColliderVolume("foundation_appear");
				foundation.SetActive(value: true);
			}
			if (!finished.activeSelf)
			{
				finished.SetActive(value: true);
				CheckIfShouldDisableLODs();
			}
			List<MeshRenderer> list = new List<MeshRenderer>();
			list.AddRange(FoundationMeshRenderers);
			list.AddRange(FinishedMeshRenderers);
			UpdateObjectLayerInfo(list);
			layerObjectHide.RefreshVisibility(MonoSingleton<World>.Instance.ElevationLevel, forceHideOrShow: true);
			if (!afterLoading)
			{
				BuildProgress.enabled = true;
			}
			if (afterLoading && BuildProgress != null)
			{
				BuildProgress.UpdateProgress(baseBuildingInstance.RemainingTime);
				BuildProgress.ParticlesOff();
			}
			this.BaseBuildingEnterFoundationStateEvent?.Invoke();
			UpdateOcclusionBoundingBox();
		}

		private void OnBaseBuildingEnterFinishedState(bool afterLoading = false)
		{
			if (baseBuildingInstance == null || baseBuildingInstance.HasDisposed)
			{
				Log.Warning("OnBaseBuildingEnterFinishedState building was disposed or null.", "C:\\GIT\\dev\\Assets\\Scripts\\Constructables\\Building Components\\Basic buildings\\BaseBuildingViewComponent.cs");
				return;
			}
			if (MonoSingleton<OcclusionCullingManager>.IsInstantiated())
			{
				MonoSingleton<OcclusionCullingManager>.Instance.RefreshChunk(this);
			}
			blueprint.SetActive(value: false);
			foundation.SetActive(value: false);
			finished.SetActive(value: true);
			CheckIfShouldDisableLODs();
			if (baseBuildingInstance.Blueprint.UseShadowCasters && shadowCasters != null)
			{
				foreach (MeshRenderer shadowCaster in shadowCasters)
				{
					if (!(shadowCaster == null))
					{
						shadowCaster.enabled = true;
					}
				}
			}
			UpdateObjectLayerInfo(FinishedMeshRenderers);
			EnableCombatColliders(active: true);
			RegisterStatCallbacks();
			SetDestructionMaterialPropertyAfterLoading();
			if (BuildProgress != null)
			{
				BuildProgress.SetStartTime(baseBuildingInstance.Blueprint.BuildTime);
				BuildProgress.UpdateProgress(baseBuildingInstance.RemainingTime);
				baseBuildingInstance.TimeRemainingEvent -= BuildProgress.UpdateProgress;
				BaseBuildingInstance.TriggerBuildParticlesEvent -= BuildProgress.TriggerParticles;
				MonoSingleton<TaskController>.Instance.WaitForNextFrameUnscaled().Then(delegate
				{
					BuildProgress.SetToFullyBuilt();
				});
			}
			if (!LayerObjectHide.Visible)
			{
				LayerObjectHide.ForceHide();
			}
			if (MonoSingleton<SelectionManager>.IsInstantiated() && (!afterLoading || baseBuildingInstance.ConstructionPhase != ConstructionPhase.Finished))
			{
				MonoSingleton<SelectionManager>.Instance.AllowOrForbidEvent -= OnForbidOrAllowBuilding;
			}
			if (baseBuildingInstance.MarkedForDestruction && destructionMarker != null)
			{
				MonoSingleton<OrderMarkAnimationManager>.Instance.AnimateOrderIcon(destructionMarker.GetComponent<AnimatedRenderMeshes>());
			}
			this.BaseBuildingEnterFinishedStateEvent?.Invoke();
			AddToMeshFusion();
			UpdateOcclusionBoundingBox();
		}

		public int GetMeshFusionVariationsHash()
		{
			HashCode hashCode = default(HashCode);
			hashCode.Add(baseBuildingInstance.BlueprintId);
			foreach (string item in baseBuildingInstance.VariationsApplied)
			{
				MeshVariation meshVariation = baseBuildingInstance.Blueprint.GetMeshVariation(item);
				if (meshVariation.HasShaderParams || meshVariation.HasTextureSlots)
				{
					hashCode.Add(item);
				}
			}
			return hashCode.ToHashCode();
		}

		public void AddToMeshFusion()
		{
			if (meshFusionSources != null && meshFusionSources.Length != 0 && isHealthAtMax)
			{
				if (shaker != null)
				{
					shaker.Stop();
				}
				isInMeshFusion = true;
				MonoSingleton<MeshFusionControllersManager>.Instance.AddToMeshFusion(this);
			}
		}

		public void RemoveFromMeshFusion()
		{
			if (meshFusionSources != null)
			{
				isInMeshFusion = false;
				MonoSingleton<MeshFusionControllersManager>.Instance.RemoveFromMeshFusion(this);
			}
		}

		public override bool IsInMeshFusion()
		{
			return isInMeshFusion;
		}

		public void OnMeshCombinedEvent(MeshFusionSource source, IEnumerable<ICombinedObjectPart> parts)
		{
			source.onCombineFinished -= OnMeshCombinedEvent;
			Renderer component = source.gameObject.GetComponent<Renderer>();
			MaterialPropertyBlock materialPropertyBlock = MonoSingleton<MaterialPropertyBlockManager>.Instance.GetMaterialPropertyBlock(component);
			materialPropertyBlock.SetFloat("_BuildProgress", 1f);
			foreach (ICombinedObjectPart part in parts)
			{
				if (!(part.Root is Component component2))
				{
					continue;
				}
				Renderer[] componentsInChildren = component2.gameObject.GetComponentsInChildren<Renderer>();
				if (componentsInChildren == null)
				{
					continue;
				}
				Renderer[] array = componentsInChildren;
				foreach (Renderer renderer in array)
				{
					if (source.SetShadowCastingMode)
					{
						renderer.shadowCastingMode = source.ShadowCastingModeValue;
					}
					renderer.SetPropertyBlock(materialPropertyBlock);
				}
			}
		}

		private void CheckIfShouldDisableLODs()
		{
			if (baseBuildingInstance == null || baseBuildingInstance.HasDisposed || baseBuildingInstance.Blueprint.UseLOD)
			{
				return;
			}
			foreach (LODGroup lodGroup in lodGroups)
			{
				lodGroup.enabled = false;
			}
			foreach (GameObject lod in lods)
			{
				lod.SetActive(value: false);
			}
		}

		private void EnableCombatColliders(bool active)
		{
			combatColliderGameObject?.SetActive(active);
		}

		private void OnConstructionPaused()
		{
			BuildProgress.ParticlesOff();
		}

		private void OnConstructionStarted()
		{
			BuildProgress.ParticlesOn();
		}

		private void OnObjectDisposed(IGameDisposable disposedObject)
		{
			Dispose();
		}

		public void Dispose()
		{
			if (HasDisposed || MonoSingleton<SceneController>.IsApplicationIsQuitting())
			{
				return;
			}
			RemoveFromMeshFusion();
			HasDisposed = true;
			if (MonoSingleton<SelectionManager>.IsInstantiated())
			{
				MonoSingleton<SelectionManager>.Instance.OrderDeconstructionEvent -= OnOrderDestruction;
				MonoSingleton<SelectionManager>.Instance.SelectionDeconstructHighlightEvent -= OnSelectionHighlight;
				MonoSingleton<SelectionManager>.Instance.AllowOrForbidEvent -= OnForbidOrAllowBuilding;
			}
			if (MonoSingleton<LayerHidingManager>.IsInstantiated())
			{
				MonoSingleton<LayerHidingManager>.Instance.LayerDownConstructablesEvent -= RefreshVisibility;
				MonoSingleton<LayerHidingManager>.Instance.LayerUpConstructablesEvent -= RefreshVisibility;
			}
			if (!LoadingController.IsLeavingMainScene && BuildProgress != null)
			{
				BuildProgress.ResetProgress();
			}
			if (baseBuildingInstance != null)
			{
				baseBuildingInstance.ForbidChangeEvent -= UpdateIndicator;
			}
			if (!LoadingController.IsLeavingMainScene)
			{
				ShowDisposeParticles();
				Deselect();
			}
			DestroySelectableObject();
			if (!LoadingController.IsLeavingMainScene && baseBuildingInstance != null)
			{
				BaseBuildingBlueprint blueprint = baseBuildingInstance.Blueprint;
				if (blueprint.HasDestructionAnimation)
				{
					BuildProgress.enabled = true;
					float animationDuration = UnityEngine.Random.Range(0.55f, 0.77f);
					AnimateObjectDestroyed(animationDuration, delegate
					{
						BuildProgress.enabled = false;
						StartCoroutine(ReturnToPoolDelay(blueprint));
					});
				}
				else
				{
					StartCoroutine(ReturnToPoolDelay(blueprint));
				}
			}
			if ((bool)indicatorUI)
			{
				indicatorUI.SetIndicator(ResourcePileIndicatorStatus.None);
			}
			if (!LoadingController.IsLeavingMainScene)
			{
				this.OnDisposedEvent?.Invoke(this);
			}
			this.OverrideSelectionExtraViewEvent = null;
			this.ConstructionCompletedEvent = null;
			this.RequestInfoPanelDataEvent = null;
			this.ObjectPlacedOnMapEvent = null;
			this.AfterBaseBuildingPlacedEvent = null;
			this.EnterPoolEvent = null;
			this.ExitPoolEvent = null;
			this.ReturnToBlueprintEvent = null;
			this.BaseBuildingEnterFoundationStateEvent = null;
			this.BaseBuildingEnterFinishedStateEvent = null;
			this.DisposedInternalEvent = null;
			this.OnDisposedEvent = null;
			this.BuildingMeshVariationRotatedEvent = null;
			this.BuildingMeshVariationSetEvent = null;
			this.BuildingSelectedEvent = null;
			this.BuildingOcclusionCullingChangedEvent = null;
			injectComponentDataEvent = null;
			baseBuildingInstance = null;
			infoPanelData = null;
			selectionExtraView = null;
			if (MonoSingleton<OcclusionCullingManager>.IsInstantiated())
			{
				MonoSingleton<OcclusionCullingManager>.Instance.UnregisterObject(this);
			}
		}

		public void OnAfterDisposedInternalEvent()
		{
			StartCoroutine(ReturnToPoolDelay(baseBuildingInstance.Blueprint));
		}

		private IEnumerator ReturnToPoolDelay(BaseBuildingBlueprint blueprint)
		{
			this.ReturnToPoolEvent?.Invoke();
			yield return new WaitForSecondsRealtime(0.5f);
			layerObjectHide?.SetOwnerBuilding(null);
			layerObjectHide?.Reset();
			ResetShadowCastingMode();
			EnableCombatColliders(active: false);
			this.blueprint.SetActive(value: true);
			foundation.SetActive(value: false);
			if (MonoSingleton<BuildingsPool>.IsInstantiated() && blueprint != null)
			{
				MonoSingleton<BuildingsPool>.Instance.Return(this, blueprint);
				if (baseBuildingInstance != null)
				{
					baseBuildingInstance = null;
				}
			}
		}

		private void ResetShadowCastingMode()
		{
			ResetMeshRendererShadowCastingMode(BlueprintMeshRenderers);
			ResetMeshRendererShadowCastingMode(FinishedMeshRenderers);
			ResetMeshRendererShadowCastingMode(FoundationMeshRenderers);
			static void ResetMeshRendererShadowCastingMode(IEnumerable<MeshRenderer> meshRenderersToReset)
			{
				if (meshRenderersToReset == null)
				{
					return;
				}
				foreach (MeshRenderer item in meshRenderersToReset)
				{
					if (!(item == null))
					{
						item.shadowCastingMode = ShadowCastingMode.On;
					}
				}
			}
		}

		public void AnimateObjectDestroyed(float animationDuration, Action animationDoneCallback)
		{
			if (BuildProgress == null || !baseBuildingInstance.ConstructionPhase.Equals(ConstructionPhase.Finished))
			{
				animationDoneCallback?.Invoke();
				return;
			}
			MonoSingleton<TaskController>.Instance.WaitUntil((float elapsedTime) => DestroyAnim(elapsedTime, animationDuration)).Then(delegate
			{
				if (base.gameObject.activeInHierarchy)
				{
					animationDoneCallback?.Invoke();
				}
			});
			bool DestroyAnim(float time, float duration)
			{
				BuildProgress.UpdateDestroyProgress(time / duration);
				return time >= duration;
			}
		}

		public void SetUnplaceableMaterial()
		{
			if (BlueprintMeshRenderers == null)
			{
				return;
			}
			foreach (MeshRenderer blueprintMeshRenderer in BlueprintMeshRenderers)
			{
				if (!(blueprintMeshRenderer == null))
				{
					MaterialPropertyBlock materialPropertyBlock = MonoSingleton<MaterialPropertyBlockManager>.Instance.GetMaterialPropertyBlock(blueprintMeshRenderer);
					materialPropertyBlock.SetFloat("_materialChange", 1f);
					blueprintMeshRenderer.SetPropertyBlock(materialPropertyBlock);
				}
			}
		}

		private void RegisterStatCallbacks()
		{
			BaseBuildingInstance obj = baseBuildingInstance;
			if (obj != null && obj.ConstructionPhase == ConstructionPhase.Finished)
			{
				(baseBuildingInstance?.Stats)?.Controller.RegisterListener(StatEventType.ValueUpdated, StatType.Health, OnHealthUpdated);
			}
		}

		private void OnHealthUpdated(object data)
		{
			StatInstance statInstance = (StatInstance)data;
			if (meshFusionSources != null)
			{
				bool flag = isHealthAtMax;
				isHealthAtMax = statInstance.IsAtMaximum();
				if (isHealthAtMax != flag)
				{
					if (isHealthAtMax)
					{
						if (!isInMeshFusion)
						{
							AddToMeshFusion();
						}
					}
					else if (isInMeshFusion)
					{
						RemoveFromMeshFusion();
					}
				}
			}
			if (!(statInstance.Current <= 0.1f) && !(this == null))
			{
				SetDestructionMaterialProperty(statInstance.Current / statInstance.Max);
				if (!CheckIfBuildingIsTakingFireDamage())
				{
					MonoSingleton<CameraManager>.Instance.OnCameraShakeEvent(base.transform.position, CameraShakeStrength.Weak);
				}
				if (shaker != null && !statInstance.DisableShaker)
				{
					shaker.Shake(statInstance, baseBuildingInstance);
				}
			}
		}

		private bool CheckIfBuildingIsTakingFireDamage()
		{
			if (baseBuildingInstance == null || baseBuildingInstance.HasDisposed)
			{
				return false;
			}
			foreach (Vec3Int position in baseBuildingInstance.Positions)
			{
				if (baseBuildingInstance.Map?.FireSimLogic?.IsFireAt(position) == true)
				{
					return true;
				}
			}
			return false;
		}

		private void SetDestructionMaterialProperty(float value)
		{
			foreach (MeshRenderer finishedMeshRenderer in FinishedMeshRenderers)
			{
				if (!(finishedMeshRenderer == null))
				{
					MaterialPropertyBlock materialPropertyBlock = MonoSingleton<MaterialPropertyBlockManager>.Instance.GetMaterialPropertyBlock(finishedMeshRenderer);
					materialPropertyBlock.SetFloat("_Destruction1", 1f - value);
					finishedMeshRenderer.SetPropertyBlock(materialPropertyBlock);
				}
			}
		}

		private void SetDestructionMaterialPropertyAfterLoading()
		{
			StatInstance statInstance = BaseBuildingInstance.Stats?.GetStat(StatType.Health);
			if (statInstance != null)
			{
				SetDestructionMaterialProperty(statInstance.Current / statInstance.Max);
			}
		}

		private void UpdateObjectLayerInfo(IEnumerable<MeshRenderer> activeMeshRenderers)
		{
			layerObjectHide.SetupMeshRenderers(activeMeshRenderers);
		}

		private void SetPlaceableMaterial()
		{
			foreach (MeshRenderer blueprintMeshRenderer in BlueprintMeshRenderers)
			{
				MaterialPropertyBlock materialPropertyBlock = MonoSingleton<MaterialPropertyBlockManager>.Instance.GetMaterialPropertyBlock(blueprintMeshRenderer);
				materialPropertyBlock.SetFloat("_materialChange", 2f);
				blueprintMeshRenderer.SetPropertyBlock(materialPropertyBlock);
			}
		}

		public void PreObjectPlacedOnMap()
		{
			MonoSingleton<SelectionManager>.Instance.OrderDeconstructionEvent += OnOrderDestruction;
			MonoSingleton<SelectionManager>.Instance.SelectionDeconstructHighlightEvent += OnSelectionHighlight;
			baseBuildingInstance.BaseBuildingEnterFoundationStateEvent += OnBaseBuildingEnterFoundationState;
			baseBuildingInstance.BaseBuildingEnterFinishedStateEvent += OnBaseBuildingEnterFinishedState;
			baseBuildingInstance.ConstructionPausedEvent += OnConstructionPaused;
			baseBuildingInstance.ConstructionStartedEvent += OnConstructionStarted;
			baseBuildingInstance.ReturnToBlueprintEvent += OnReturnToBlueprint;
			baseBuildingInstance.OnDisposedEvent += OnObjectDisposed;
			baseBuildingInstance.ForbidChangeEvent += UpdateIndicator;
			MonoSingleton<TaskController>.Instance.WaitFor(0.1f).Then(delegate
			{
				DestroySelectableObject();
				base.Start();
			});
		}

		public ShadowCastingMode GetShadowCastingMode(Renderer renderer, BaseBuildingBlueprint blueprint)
		{
			if (shadowCasters.Contains(renderer))
			{
				return ShadowCastingMode.ShadowsOnly;
			}
			if (!blueprint.UseShadowCasters)
			{
				return ShadowCastingMode.On;
			}
			return ShadowCastingMode.Off;
		}

		public void ObjectPlacedOnMap(bool afterLoading = false)
		{
			HasDisposed = false;
			ColorBlueprint(2f);
			InitMeshVariationOnLoad();
			if (BuildProgress != null)
			{
				BaseBuildingInstance.TimeRemainingEvent += BuildProgress.UpdateProgress;
				BaseBuildingInstance.TriggerBuildParticlesEvent += BuildProgress.TriggerParticles;
				if (BaseBuildingInstance.Blueprint.BuildingType.Equals(BuildingType.Beam))
				{
					BuildProgress.SetEmitterSize(new List<Vec3Int>
					{
						new Vec3Int(BaseBuildingInstance.GridDataPosition.x, BaseBuildingInstance.GridDataPosition.y * World.MapBlockHeight, BaseBuildingInstance.GridDataPosition.z)
					}, BaseBuildingInstance.Size, BaseBuildingInstance.Blueprint.BuildingType);
				}
				else
				{
					BuildProgress.SetEmitterSize(BaseBuildingInstance.Positions, BaseBuildingInstance.Size, BaseBuildingInstance.Blueprint.BuildingType);
				}
				if ((!afterLoading || BaseBuildingInstance.ConstructionPhase.Equals(ConstructionPhase.Blueprint)) && BuildProgress != null)
				{
					BuildProgress.ResetProgress();
				}
				if (afterLoading && BaseBuildingInstance.ConstructionPhase != ConstructionPhase.Finished)
				{
					BuildProgress.SetStartTime(BaseBuildingInstance.Blueprint.BuildTime);
					BuildProgress.UpdateProgress(BaseBuildingInstance.RemainingTime);
				}
			}
			layerObjectHide.SetupColliders(ClickCollider);
			layerObjectHide.SetupMeshRenderers(BlueprintMeshRenderers);
			layerObjectHide.Setup(BaseBuildingInstance.GridDataPosition.y, BaseBuildingInstance.Blueprint.LayerHideOffset, BaseBuildingInstance.Blueprint.LayerShadowOffset, LayerHideType.Building);
			layerObjectHide.SetOwnerBuilding(baseBuildingInstance);
			if (baseBuildingInstance.Blueprint.UseShadowCasters)
			{
				foreach (MeshRenderer finishedMeshRenderer in FinishedMeshRenderers)
				{
					finishedMeshRenderer.shadowCastingMode = ShadowCastingMode.Off;
				}
				if (shadowCasters != null)
				{
					foreach (MeshRenderer shadowCaster in shadowCasters)
					{
						if (!(shadowCaster == null))
						{
							shadowCaster.shadowCastingMode = ShadowCastingMode.ShadowsOnly;
						}
					}
				}
			}
			MonoSingleton<LayerHidingManager>.Instance.LayerDownConstructablesEvent += RefreshVisibility;
			MonoSingleton<LayerHidingManager>.Instance.LayerUpConstructablesEvent += RefreshVisibility;
			layerObjectHide.RefreshVisibility(MonoSingleton<World>.Instance.ElevationLevel);
			if (!afterLoading)
			{
				if (blueprintPlacedEffect != null && !TutorialManager.IsTutorialActive)
				{
					if (!MonoSingleton<BuildingPlacementManager>.Instance.Autoconstruct)
					{
						for (int i = 0; i < BlueprintMeshRenderers.Count; i++)
						{
							BlueprintMeshRenderers[i].enabled = false;
						}
					}
					MonoSingleton<BlueprintPlaceVisualsManager>.Instance.AddBlueprintToList(blueprintPlacedEffect);
				}
				else
				{
					PlayParticlesOnBlueprintPlaced();
					MonoSingleton<CameraManager>.Instance.OnCameraShakeEvent(base.transform.position, CameraShakeStrength.Blueprint);
				}
			}
			if (shaker != null)
			{
				shaker.Initialize();
			}
			Vector3 position = base.transform.position;
			Vector3 position2 = new Vector3(position.x, Mathf.Clamp(position.y + (float)BaseBuildingInstance.Size.y + 0.5f, 0f, position.y + (float)World.MapBlockHeight - 0.5f), position.z);
			if (indicatorUI == null)
			{
				indicatorUI = UnityEngine.Object.Instantiate(MonoRepository<PrefabRepository, NSMedieval.Model.KeyGameObjectPair>.Instance.GetByAddress("resource_pile_indicator"), position2, Quaternion.identity, base.transform).GetComponent<ResourcePileIndicatorView>();
			}
			UpdateIndicator(baseBuildingInstance);
			if (!afterLoading || baseBuildingInstance.ConstructionPhase != ConstructionPhase.Finished)
			{
				MonoSingleton<SelectionManager>.Instance.AllowOrForbidEvent += OnForbidOrAllowBuilding;
			}
			StringIntDictionary materials = baseBuildingInstance.Blueprint.Materials;
			if (materials != null && materials.Dictionary?.Count == 0)
			{
				finished.SetActive(value: true);
			}
			CheckIfShouldDisableLODs();
			baseBuildingInstance.Map.BuildingsManagerMain.CacheBuildingInstance(this, afterLoading);
			baseBuildingInstance.Map.BuildingsManagerMain.CacheBuildingCopySettings(baseBuildingInstance);
			this.ObjectPlacedOnMapEvent?.Invoke(afterLoading);
			this.ObjectPlacedOnMapEvent = null;
			this.AfterBaseBuildingPlacedEvent?.Invoke(afterLoading);
			this.AfterBaseBuildingPlacedEvent = null;
			if (MonoSingleton<OcclusionCullingManager>.IsInstantiated())
			{
				MonoSingleton<OcclusionCullingManager>.Instance.RegisterObject(this);
			}
		}

		private void OnSelectionHighlight(BuildingOrderEventData eventData)
		{
			if (IgnoreSelectionHighlight || baseBuildingInstance == null || baseBuildingInstance.HasDisposed || !baseBuildingInstance.OwnedByPlayer() || (int)(base.transform.position.y / (float)World.MapBlockHeight) > MonoSingleton<World>.Instance.ElevationLevel)
			{
				return;
			}
			if (!SelectionManager.IsWithinSelectionBounds(base.transform.position, eventData.MinPoint.x, eventData.MaxPoint.x, eventData.MinPoint.y, eventData.MaxPoint.y))
			{
				HideHighlight();
			}
			else if (!eventData.AffectOnlyOneLayer || (int)base.transform.position.y == (int)eventData.Y)
			{
				if (!OrderShouldHighlightMe(eventData))
				{
					HideHighlight();
				}
				else
				{
					ShowHighlight();
				}
			}
		}

		private bool OrderShouldHighlightMe(BuildingOrderEventData eventData)
		{
			ConstructionPhase constructionPhase = baseBuildingInstance.ConstructionPhase;
			if (eventData.OrderType.Equals(OrderType.Deconstructing))
			{
				if (!eventData.BuildingTypes.HasFlag(baseBuildingInstance.BuildingType))
				{
					return false;
				}
				if (constructionPhase.Equals(ConstructionPhase.Finished) && !baseBuildingInstance.MarkedForDestruction)
				{
					return true;
				}
			}
			if (eventData.OrderType.Equals(OrderType.Cancel))
			{
				if (constructionPhase.Equals(ConstructionPhase.Blueprint) || constructionPhase.Equals(ConstructionPhase.Foundation))
				{
					return true;
				}
				if (baseBuildingInstance.MarkedForDestruction)
				{
					return true;
				}
			}
			if (eventData.OrderType.Equals(OrderType.Allow) && baseBuildingInstance.IsForbidden)
			{
				if (baseBuildingInstance.ConstructionPhase == ConstructionPhase.Blueprint && eventData.OrderAllowType.HasFlag(OrderAllowType.Blueprints))
				{
					if (eventData.AffectOnlyOneLayer)
					{
						return (int)base.transform.position.y == (int)eventData.Y;
					}
					return true;
				}
				if (baseBuildingInstance.ConstructionPhase == ConstructionPhase.Foundation && eventData.OrderAllowType.HasFlag(OrderAllowType.Foundations))
				{
					if (eventData.AffectOnlyOneLayer)
					{
						return (int)base.transform.position.y == (int)eventData.Y;
					}
					return true;
				}
			}
			if (eventData.OrderType.Equals(OrderType.Forbid) && !baseBuildingInstance.IsForbidden)
			{
				if (baseBuildingInstance.ConstructionPhase == ConstructionPhase.Blueprint && eventData.OrderAllowType.HasFlag(OrderAllowType.Blueprints))
				{
					if (eventData.AffectOnlyOneLayer)
					{
						return (int)base.transform.position.y == (int)eventData.Y;
					}
					return true;
				}
				if (baseBuildingInstance.ConstructionPhase == ConstructionPhase.Foundation && eventData.OrderAllowType.HasFlag(OrderAllowType.Foundations))
				{
					if (eventData.AffectOnlyOneLayer)
					{
						return (int)base.transform.position.y == (int)eventData.Y;
					}
					return true;
				}
			}
			return false;
		}

		public void PlayParticlesOnBlueprintPlaced()
		{
			if (!(particlesBlueprintInstance != null))
			{
				particlesBlueprintInstance = MonoSingleton<ParticleSystemPool>.Instance.PlayParticles(buildBlueprintParticles, base.transform.position, autoStop: true, useUnscaledTime: true);
				if (particlesBlueprintInstance != null)
				{
					MonoSingleton<ParticleSystemPool>.Instance.SetEmitterSize(buildBlueprintParticles, particlesBlueprintInstance, clickCollider, 1f);
				}
			}
		}

		public void ColorBlueprint(float shaderValue)
		{
			foreach (MeshRenderer blueprintMeshRenderer in BlueprintMeshRenderers)
			{
				MaterialPropertyBlock materialPropertyBlock = MonoSingleton<MaterialPropertyBlockManager>.Instance.GetMaterialPropertyBlock(blueprintMeshRenderer);
				materialPropertyBlock.SetFloat("_materialChange", shaderValue);
				blueprintMeshRenderer.SetPropertyBlock(materialPropertyBlock);
			}
		}

		internal override void Select()
		{
			base.Select();
			if (base.Selected)
			{
				TryShowWorkPositionMarkers();
				this.BuildingSelectedEvent?.Invoke();
			}
		}

		internal override void Deselect(bool isSilent = false)
		{
			base.Deselect(isSilent);
			if (!base.Selected && !TryHideWorkPositionMarkers())
			{
				this.BuildingDeselectedEvent?.Invoke();
			}
		}

		public void OnMarkedForDeconstruction()
		{
			if (BaseBuildingInstance.ConstructionPhase != ConstructionPhase.Finished)
			{
				baseBuildingInstance.Map.BuildingsManagerMain.DestroyBuilding(BaseBuildingInstance);
			}
			else if (destructionMarker != null)
			{
				MonoSingleton<OrderMarkAnimationManager>.Instance.AnimateOrderIcon(destructionMarker.GetComponent<AnimatedRenderMeshes>());
			}
		}

		public void OnUnMarkedForDeconstruction()
		{
			if (destructionMarker != null)
			{
				destructionMarker.SetActive(value: false);
				MonoSingleton<OrderMarkAnimationManager>.Instance.CancelOngoingAnimation(destructionMarker);
			}
		}

		private void TryShowWorkPositionMarkers()
		{
			if (baseBuildingInstance == null || baseBuildingInstance.HasDisposed)
			{
				return;
			}
			BaseBuildingBlueprint baseBuildingBlueprint = baseBuildingInstance.Blueprint;
			if (baseBuildingBlueprint.WorkPositionsArray != null && baseBuildingBlueprint.WorkPositionsArray.Length != 0)
			{
				TransformSettings[] workPositionsArray = baseBuildingBlueprint.WorkPositionsArray;
				foreach (TransformSettings obj in workPositionsArray)
				{
					GameObject gameObject = GameObjectPool.Get("WorkerPositionMarker");
					gameObject.transform.SetParent(buildingUseComponent.WorkPositionsParent, worldPositionStays: false);
					obj.ApplyToTransform(gameObject.transform);
					workPositionsMarkers.Add(gameObject);
				}
			}
		}

		private bool TryHideWorkPositionMarkers()
		{
			if (workPositionsMarkers == null)
			{
				return true;
			}
			foreach (GameObject workPositionsMarker in workPositionsMarkers)
			{
				GameObjectPool.Return(workPositionsMarker);
			}
			workPositionsMarkers.Clear();
			return false;
		}

		private void HandleOrderDragSelection(OrderType orderType)
		{
			if (baseBuildingInstance == null || baseBuildingInstance.HasDisposed || !baseBuildingInstance.OwnedByPlayer())
			{
				return;
			}
			if (BaseBuildingInstance.ConstructionPhase.Equals(ConstructionPhase.Blueprint) || BaseBuildingInstance.ConstructionPhase.Equals(ConstructionPhase.Foundation))
			{
				if (!orderType.Equals(OrderType.Deconstructing))
				{
					baseBuildingInstance.Map.BuildingsManagerMain.DestroyBuilding(BaseBuildingInstance);
				}
			}
			else if (BaseBuildingInstance.ConstructionPhase.Equals(ConstructionPhase.Finished))
			{
				if (orderType.Equals(OrderType.Deconstructing))
				{
					if (MonoSingleton<BuildingPlacementManager>.Instance.Autoconstruct)
					{
						baseBuildingInstance.BuildingDeconstructed(baseBuildingInstance.WorldPosition);
					}
					else if (!BaseBuildingInstance.MarkedForDestruction)
					{
						BaseBuildingInstance.SetMarkedForDestruction(value: true);
					}
				}
				if (orderType.Equals(OrderType.Cancel) && BaseBuildingInstance.MarkedForDestruction)
				{
					BaseBuildingInstance.SetMarkedForDestruction(value: false);
				}
			}
			else
			{
				baseBuildingInstance.Map.BuildingsManagerMain.DestroyBuilding(BaseBuildingInstance);
			}
		}

		public void SetInfoPanelData(InfoPanelData infoPanelData)
		{
			this.infoPanelData = infoPanelData;
		}

		public InfoPanelHeader GetHeaderData()
		{
			if (baseBuildingInstance == null || baseBuildingInstance.HasDisposed)
			{
				return null;
			}
			return new InfoPanelHeader(baseBuildingInstance.BlueprintId, baseBuildingInstance.GetBuildingName(), "building");
		}

		public List<InfoPanelStat> GetInfoStats()
		{
			List<InfoPanelStat> list = new List<InfoPanelStat>();
			if (baseBuildingInstance.ConstructionPhase.Equals(ConstructionPhase.Blueprint) || baseBuildingInstance.ConstructionPhase.Equals(ConstructionPhase.Foundation))
			{
				list.Add(new InfoPanelStat("menu_completion", "%", new IntRange((int)(BuildProgress.GetBuildProgress() * 100f), 100)));
				return list;
			}
			StatInstance stat = baseBuildingInstance.Stats.GetStat(StatType.Health);
			list.Add(new InfoPanelStat("menu_hit_points", "/", new IntRange(Mathf.RoundToInt(stat.Current), Mathf.RoundToInt(stat.Max)), StatType.Health));
			return list;
		}

		public List<InfoPanelResource> GetResourcesInfo()
		{
			List<InfoPanelResource> list = new List<InfoPanelResource>();
			if (baseBuildingInstance == null || baseBuildingInstance.HasDisposed || baseBuildingInstance.ConstructionPhase.Equals(ConstructionPhase.Finished))
			{
				return list;
			}
			foreach (KeyValuePair<string, int> resource in baseBuildingInstance.ConstructionCost)
			{
				ResourceInstance resourceInstance = baseBuildingInstance.Storage.Resources.FirstOrDefault((ResourceInstance stored) => stored.BlueprintId.Equals(resource.Key));
				list.Add(new InfoPanelResource(resource.Key, "resource", new IntRange(resourceInstance?.Amount ?? 0, resource.Value)));
			}
			return list;
		}

		private void ForbidBuildable(bool forbid)
		{
			if (BaseBuildingInstance == null)
			{
				Log.Error("ForbidBuildable: BaseBuildingInstance is null. Should not happen", "C:\\GIT\\dev\\Assets\\Scripts\\Constructables\\Building Components\\Basic buildings\\BaseBuildingViewComponent.cs");
			}
			else
			{
				BaseBuildingInstance.IsForbidden = forbid;
			}
		}

		public List<string> GetDescriptions()
		{
			return new List<string> { BuildingUtils.GetLocalizedInfo(baseBuildingInstance.BlueprintId) };
		}

		public List<InfoPanelAction> GetInfoPanelActions()
		{
			List<InfoPanelAction> list = new List<InfoPanelAction>();
			if (TutorialManager.IsTutorialActive)
			{
				return list;
			}
			if (baseBuildingInstance.FactionOwnership == FactionOwnership.Enemy)
			{
				if (!BaseBuildingInstance.Blueprint.CanBeMoved)
				{
					return list;
				}
				if (!BaseBuildingInstance.MarkedForMoving)
				{
					int currentIndex = ((BaseBuildingInstance.MarkedForUninstall || BaseBuildingInstance.MarkedForMoving) ? 1 : 0);
					KeyValuePair<SelectionInputActionData, Action>[] objectActions = new KeyValuePair<SelectionInputActionData, Action>[2]
					{
						new KeyValuePair<SelectionInputActionData, Action>(Repository<ObjectActionDataRepository, SelectionInputActionData>.Instance.GetByID("UninstallBuilding"), UninstallBuilding),
						new KeyValuePair<SelectionInputActionData, Action>(Repository<ObjectActionDataRepository, SelectionInputActionData>.Instance.GetByID("Cancel"), CancelUninstall)
					};
					list.Add(new InfoPanelAction(objectActions, currentIndex));
				}
				return list;
			}
			if (MonoSingleton<PlayerTriggeredEventManager>.Instance.IsInEventRoom(baseBuildingInstance) && MonoSingleton<PlayerTriggeredEventManager>.Instance.IsEventRunning())
			{
				return list;
			}
			int currentIndex2 = (BaseBuildingInstance.MarkedForDestruction ? 1 : 0);
			KeyValuePair<SelectionInputActionData, Action>[] objectActions2 = new KeyValuePair<SelectionInputActionData, Action>[2]
			{
				new KeyValuePair<SelectionInputActionData, Action>(Repository<ObjectActionDataRepository, SelectionInputActionData>.Instance.GetByID("Deconstructing"), delegate
				{
					MarkForDeconstruction(OrderType.Deconstructing);
				}),
				new KeyValuePair<SelectionInputActionData, Action>(Repository<ObjectActionDataRepository, SelectionInputActionData>.Instance.GetByID("Cancel"), delegate
				{
					MarkForDeconstruction(OrderType.Cancel);
				})
			};
			if (BaseBuildingInstance.ConstructionPhase.Equals(ConstructionPhase.Blueprint) || BaseBuildingInstance.ConstructionPhase.Equals(ConstructionPhase.Foundation))
			{
				list.Add(new InfoPanelAction(objectActions2, 1));
			}
			else
			{
				list.Add(new InfoPanelAction(objectActions2, currentIndex2));
			}
			if (!BaseBuildingInstance.ConstructionPhase.Equals(ConstructionPhase.Finished))
			{
				int currentIndex3 = (BaseBuildingInstance.IsForbidden ? 1 : 0);
				KeyValuePair<SelectionInputActionData, Action>[] objectActions3 = new KeyValuePair<SelectionInputActionData, Action>[2]
				{
					new KeyValuePair<SelectionInputActionData, Action>(Repository<ObjectActionDataRepository, SelectionInputActionData>.Instance.GetByID("Forbid"), delegate
					{
						ForbidBuildable(forbid: true);
					}),
					new KeyValuePair<SelectionInputActionData, Action>(Repository<ObjectActionDataRepository, SelectionInputActionData>.Instance.GetByID("Allow"), delegate
					{
						ForbidBuildable(forbid: false);
					})
				};
				list.Add(new InfoPanelAction(objectActions3, currentIndex3));
			}
			if (BaseBuildingInstance.Blueprint.BuildingCategoryUI != BuildingCategoryUI.None && MonoSingleton<ResearchManager>.Instance.Researched(BaseBuildingInstance.Blueprint.GetID()))
			{
				KeyValuePair<SelectionInputActionData, Action>[] objectActions4 = new KeyValuePair<SelectionInputActionData, Action>[1]
				{
					new KeyValuePair<SelectionInputActionData, Action>(Repository<ObjectActionDataRepository, SelectionInputActionData>.Instance.GetByID("CopyBuilding"), CopyBuilding)
				};
				list.Add(new InfoPanelAction(objectActions4));
			}
			if (!BaseBuildingInstance.Blueprint.CanBeMoved)
			{
				return list;
			}
			if (baseBuildingInstance.ConstructionPhase != ConstructionPhase.Finished)
			{
				return list;
			}
			if (!BaseBuildingInstance.MarkedForUninstall && MonoSingleton<SelectableObjectManager>.Instance.SelectedObjects.Count <= 1)
			{
				int currentIndex4 = ((BaseBuildingInstance.MarkedForUninstall || BaseBuildingInstance.MarkedForMoving) ? 1 : 0);
				KeyValuePair<SelectionInputActionData, Action>[] objectActions5 = new KeyValuePair<SelectionInputActionData, Action>[2]
				{
					new KeyValuePair<SelectionInputActionData, Action>(Repository<ObjectActionDataRepository, SelectionInputActionData>.Instance.GetByID("MoveBuilding"), MoveBuilding),
					new KeyValuePair<SelectionInputActionData, Action>(Repository<ObjectActionDataRepository, SelectionInputActionData>.Instance.GetByID("Cancel"), CancelUninstall)
				};
				list.Add(new InfoPanelAction(objectActions5, currentIndex4));
			}
			if (!BaseBuildingInstance.MarkedForMoving)
			{
				int currentIndex5 = ((BaseBuildingInstance.MarkedForUninstall || BaseBuildingInstance.MarkedForMoving) ? 1 : 0);
				KeyValuePair<SelectionInputActionData, Action>[] objectActions6 = new KeyValuePair<SelectionInputActionData, Action>[2]
				{
					new KeyValuePair<SelectionInputActionData, Action>(Repository<ObjectActionDataRepository, SelectionInputActionData>.Instance.GetByID("UninstallBuilding"), UninstallBuilding),
					new KeyValuePair<SelectionInputActionData, Action>(Repository<ObjectActionDataRepository, SelectionInputActionData>.Instance.GetByID("Cancel"), CancelUninstall)
				};
				list.Add(new InfoPanelAction(objectActions6, currentIndex5));
			}
			return list;
		}

		private void UninstallBuilding()
		{
			if (baseBuildingInstance != null && !baseBuildingInstance.HasDisposed)
			{
				BaseBuildingInstance.SetIsMarkedForUninstall(markedForUninstall: true);
				MonoSingleton<ConstructablesGoapUninstallManager>.Instance.AddToUninstallList(BaseBuildingInstance);
			}
		}

		private void MoveBuilding()
		{
			if (baseBuildingInstance != null && !baseBuildingInstance.HasDisposed && !(baseBuildingInstance.Blueprint == null))
			{
				if (baseBuildingInstance.MarkedForUninstall)
				{
					CancelUninstall();
				}
				MonoSingleton<MoveBuildingsManager>.Instance.SetBuildingToMove(BaseBuildingInstance);
				BaseBuildingInstance.SetIsMarkedForMoving(markedForMoving: true);
				MonoSingleton<BuildingPlacementManager>.Instance.InitializeBuilding(BaseBuildingInstance.Blueprint.GetID(), RelocateBuilding.Move);
			}
		}

		private void CancelUninstall()
		{
			if (BaseBuildingInstance != null && !BaseBuildingInstance.HasDisposed)
			{
				BaseBuildingInstance.CancelUninstall();
			}
		}

		private void MarkForDeconstruction(OrderType order)
		{
			if (baseBuildingInstance == null || baseBuildingInstance.HasDisposed)
			{
				return;
			}
			if (baseBuildingInstance.ConstructionPhase.Equals(ConstructionPhase.Finished))
			{
				if (MonoSingleton<BuildingPlacementManager>.Instance.Autoconstruct)
				{
					baseBuildingInstance.BuildingDeconstructed(baseBuildingInstance.WorldPosition);
				}
				else
				{
					baseBuildingInstance.SetMarkedForDestruction(order == OrderType.Deconstructing);
				}
			}
			else
			{
				baseBuildingInstance.BuildingCanceled(baseBuildingInstance.WorldPosition);
			}
		}

		private void CopyBuilding()
		{
			Deselect();
			if (!HasDisposed && BaseBuildingInstance != null && !BaseBuildingInstance.HasDisposed)
			{
				BaseBuildingInstance.Map.BuildingsManagerMain.SetBuildingToCopy(BaseBuildingInstance);
				MonoSingleton<UIController>.Instance.CopyBuilding(BaseBuildingInstance.Blueprint.GetID(), BaseBuildingInstance.Blueprint.BuildingCategoryUI, BaseBuildingInstance.Blueprint.BuildingSubCategoryUI);
			}
		}

		public List<string> GetBuildPhaseInfo()
		{
			return BuildingUtils.GetLocalizedGetBuildPhaseInfo(baseBuildingInstance);
		}

		public List<string> GetInfos()
		{
			List<string> list = new List<string>();
			list.AddRange(BuildingUtils.GetInfoLines(baseBuildingInstance));
			return list;
		}

		public override string GetSimpleName()
		{
			if (!HasDisposed && baseBuildingInstance != null && !baseBuildingInstance.HasDisposed)
			{
				return baseBuildingInstance.GetBuildingName();
			}
			return string.Empty;
		}

		public override string GetMultiselectName()
		{
			if (!HasDisposed && BaseBuildingInstance != null && !BaseBuildingInstance.HasDisposed)
			{
				return BaseBuildingInstance.BlueprintId;
			}
			return string.Empty;
		}

		public override InfoPanelData GetInfoPanelData()
		{
			infoPanelData = null;
			infoPanelData = UpdateCallback();
			return infoPanelData;
		}

		private InfoPanelBody GetInfoPanelBody()
		{
			InfoPanelBody infoPanelBody = new InfoPanelBody(baseBuildingInstance.BlueprintId, baseBuildingInstance.GetBuildingName(), string.Empty, GetInfoStats(), GetBuildPhaseInfo(), GetResourcesInfo(), GetDescriptions(), GetInfos());
			return injectComponentDataEvent?.Invoke(infoPanelBody) ?? infoPanelBody;
		}

		public override InfoPanelData UpdateCallback()
		{
			if (HasDisposed || BaseBuildingInstance == null || BaseBuildingInstance.HasDisposed)
			{
				return null;
			}
			InfoPanelHeader headerData = GetHeaderData();
			if (baseBuildingInstance == null)
			{
				Debug.Log("BaseBuildableView.Buildable is null while calling GetInfoPanelData.");
				return null;
			}
			if (baseBuildingInstance.Blueprint == null)
			{
				Debug.Log("BaseBuildableView.Blueprint is null while calling GetInfoPanelData.");
				return null;
			}
			InfoPanelBody infoPanelBody = GetInfoPanelBody();
			InfoPanelFooter footer = new InfoPanelFooter(GetInfoPanelActions(), baseBuildingInstance);
			if (BaseBuildingInstance.OwnedByPlayer())
			{
				infoPanelData = null;
				this.RequestInfoPanelDataEvent?.Invoke();
				if (infoPanelData != null)
				{
					GetExtraPanelViews(infoPanelData.ExtraPanelViews);
					return infoPanelData;
				}
				infoPanelData = new InfoPanelData(InfoPanelDataType.General, headerData, infoPanelBody, footer, GetExtraPanelViews(new List<SelectionExtraView>()));
			}
			else
			{
				infoPanelData = new InfoPanelData(InfoPanelDataType.General, headerData, infoPanelBody, footer);
			}
			return infoPanelData;
		}

		public void SetSelectionExtraView(SelectionExtraView selectionExtraView)
		{
			this.selectionExtraView = selectionExtraView;
		}

		private List<SelectionExtraView> GetExtraPanelViews(List<SelectionExtraView> extraViews)
		{
			if (baseBuildingInstance.FactionOwnership == FactionOwnership.Enemy)
			{
				return null;
			}
			selectionExtraView = null;
			this.OverrideSelectionExtraViewEvent?.Invoke();
			if (selectionExtraView != null)
			{
				extraViews.Add(selectionExtraView);
				bool isEnabled;
				FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(18, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Constructables\\Building Components\\Basic buildings\\BaseBuildingViewComponent.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Added extra view: ");
					messageBuilder.AppendFormatted(extraViews.Count);
				}
				Log.Debug(messageBuilder);
			}
			return AppendAdditionalExtraViews(baseBuildingInstance, extraViews);
		}

		public static List<SelectionExtraView> AppendAdditionalExtraViews(BaseBuildingInstance baseBuildingInstance, List<SelectionExtraView> extraViews)
		{
			if (baseBuildingInstance.Blueprint.ShowVariations)
			{
				extraViews.Add(new InfoPanelMeshVariations(baseBuildingInstance));
			}
			if (baseBuildingInstance.Blueprint.CanHaveOwner)
			{
				extraViews.Add(new InfoPanelBuildingOwnership(baseBuildingInstance));
			}
			if (baseBuildingInstance.EligibleForEvent())
			{
				extraViews.Add(new InfoPanelPlayerTriggeredEvent(baseBuildingInstance));
			}
			return extraViews;
		}

		public LinkedList<LifeEventLogStruct> GetLifeEventLog()
		{
			return null;
		}

		private void OnBuildingMeshVariationRotated()
		{
			UpdateMeshRotation();
			this.BuildingMeshVariationRotatedEvent?.Invoke();
			ResetLodsAndShadowCastersTransform();
			if (baseBuildingInstance.ConstructionPhase == ConstructionPhase.Finished)
			{
				MonoSingleton<MeshFusionControllersManager>.Instance.RefreshMeshFusion(this);
			}
		}

		private void OnBuildingMeshVariationFlipped()
		{
			UpdateMeshRotation();
			this.BuildingMeshVariationRotatedEvent?.Invoke();
			ResetLodsAndShadowCastersTransform();
			if (baseBuildingInstance.ConstructionPhase == ConstructionPhase.Finished)
			{
				MonoSingleton<MeshFusionControllersManager>.Instance.RefreshMeshFusion(this);
			}
		}

		private void BuildingMeshVariationSet()
		{
			UpdateMeshVariation();
			this.BuildingMeshVariationSetEvent?.Invoke();
			ResetLodsAndShadowCastersTransform();
			if (baseBuildingInstance.ConstructionPhase == ConstructionPhase.Finished)
			{
				MonoSingleton<MeshFusionControllersManager>.Instance.RefreshMeshFusion(this);
			}
		}

		public void UpdateMeshVariation(MeshVariation meshVariation)
		{
			bool isEnabled;
			if (meshVariationHandler == null)
			{
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(55, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Constructables\\Building Components\\Basic buildings\\BaseBuildingViewComponent.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("UpdateMeshVariation ");
					messageBuilder.AppendFormatted(base.gameObject.GetHashCode());
					messageBuilder.AppendLiteral("-");
					messageBuilder.AppendFormatted(base.gameObject.name);
					messageBuilder.AppendLiteral(" this.meshVariationHandler is NULL");
				}
				Log.Error(messageBuilder);
			}
			else if (meshVariation == null)
			{
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(43, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Constructables\\Building Components\\Basic buildings\\BaseBuildingViewComponent.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("UpdateMeshVariation ");
					messageBuilder.AppendFormatted(base.gameObject.GetHashCode());
					messageBuilder.AppendLiteral("-");
					messageBuilder.AppendFormatted(base.gameObject.name);
					messageBuilder.AppendLiteral(" meshVariation is null");
				}
				Log.Error(messageBuilder);
			}
			else if (string.IsNullOrEmpty(meshVariation.Name))
			{
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(48, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Constructables\\Building Components\\Basic buildings\\BaseBuildingViewComponent.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("UpdateMeshVariation ");
					messageBuilder.AppendFormatted(base.gameObject.GetHashCode());
					messageBuilder.AppendLiteral("-");
					messageBuilder.AppendFormatted(base.gameObject.name);
					messageBuilder.AppendLiteral(" meshVariation.Name is null");
				}
				Log.Error(messageBuilder);
			}
			else
			{
				meshVariationHandler.UpdateMeshVariation(meshVariation, BaseBuildingInstance?.MaterialVariationsApplied);
			}
		}

		private void UpdateMeshVariation()
		{
			if (BaseBuildingInstance == null || BaseBuildingInstance.HasDisposed)
			{
				return;
			}
			bool isEnabled;
			if (BaseBuildingInstance.VariationsApplied == null)
			{
				FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(54, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Constructables\\Building Components\\Basic buildings\\BaseBuildingViewComponent.cs");
				if (isEnabled)
				{
					messageBuilder.AppendFormatted(base.gameObject.name);
					messageBuilder.AppendLiteral(" this.BaseBuildingInstance.VariationsApplied == null: ");
					messageBuilder.AppendFormatted(BaseBuildingInstance.VariationsApplied == null);
				}
				Log.Debug(messageBuilder);
				return;
			}
			if (BaseBuildingInstance.VariationsApplied.Count == 0)
			{
				FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(52, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Constructables\\Building Components\\Basic buildings\\BaseBuildingViewComponent.cs");
				if (isEnabled)
				{
					messageBuilder.AppendFormatted(base.gameObject.name);
					messageBuilder.AppendLiteral(" this.BaseBuildingInstance.VariationsApplied.Count: ");
					messageBuilder.AppendFormatted(BaseBuildingInstance.VariationsApplied.Count);
				}
				Log.Debug(messageBuilder);
				return;
			}
			foreach (string item in BaseBuildingInstance.VariationsApplied)
			{
				MeshVariation meshVariation = BaseBuildingInstance.Blueprint.GetMeshVariation(item);
				UpdateMeshVariation(meshVariation);
			}
		}

		private void UpdateMeshRotation()
		{
			if (BaseBuildingInstance.VariationsApplied != null)
			{
				meshVariationHandler.UpdateMeshRotation(BaseBuildingInstance.RotateMeshVariation, BaseBuildingInstance.FlipXMeshVariation, BaseBuildingInstance.FlipZMeshVariation);
			}
		}

		private void ResetLodsAndShadowCastersTransform()
		{
			foreach (GameObject lodsAndShadowCaster in lodsAndShadowCasters)
			{
				lodsAndShadowCaster.transform.localPosition = Vector3.zero;
				lodsAndShadowCaster.transform.localRotation = Quaternion.identity;
				lodsAndShadowCaster.transform.localScale = Vector3.one;
			}
		}

		private void UpdateIndicator(IForbidable pileInstance)
		{
			if (pileInstance == baseBuildingInstance && baseBuildingInstance != null && !baseBuildingInstance.HasDisposed)
			{
				bool isEnabled;
				FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(22, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Constructables\\Building Components\\Basic buildings\\BaseBuildingViewComponent.cs");
				if (isEnabled)
				{
					messageBuilder.AppendFormatted(baseBuildingInstance);
					messageBuilder.AppendLiteral(" VIEW update indicator");
				}
				Log.Trace(messageBuilder);
				ResourcePileIndicatorStatus indicator = ResourcePileIndicatorStatus.None;
				if (baseBuildingInstance.IsForbidden)
				{
					indicator = ResourcePileIndicatorStatus.Forbidden;
				}
				if ((bool)indicatorUI)
				{
					indicatorUI.SetIndicator(indicator);
				}
			}
		}

		private void OnForbidOrAllowBuilding(OrderEventData eventData)
		{
			if (this == null)
			{
				Log.Info("OnForbidOrAllowBuilding: view is null!", "C:\\GIT\\dev\\Assets\\Scripts\\Constructables\\Building Components\\Basic buildings\\BaseBuildingViewComponent.cs");
			}
			else if (base.gameObject == null)
			{
				Log.Info("OnForbidOrAllowBuilding: gameObject is null!", "C:\\GIT\\dev\\Assets\\Scripts\\Constructables\\Building Components\\Basic buildings\\BaseBuildingViewComponent.cs");
			}
			else if (base.transform == null)
			{
				Log.Info("OnForbidOrAllowBuilding: transform is null!", "C:\\GIT\\dev\\Assets\\Scripts\\Constructables\\Building Components\\Basic buildings\\BaseBuildingViewComponent.cs");
			}
			else if (baseBuildingInstance == null)
			{
				Log.Info("OnForbidOrAllowBuilding baseBuildingInstance is null!", "C:\\GIT\\dev\\Assets\\Scripts\\Constructables\\Building Components\\Basic buildings\\BaseBuildingViewComponent.cs");
			}
			else if (ObjectIsSelectedByOrder(eventData) && baseBuildingInstance.ConstructionPhase != ConstructionPhase.Finished && (baseBuildingInstance.ConstructionPhase != ConstructionPhase.Blueprint || eventData.OrderAllowType.HasFlag(OrderAllowType.Blueprints)) && (baseBuildingInstance.ConstructionPhase != ConstructionPhase.Foundation || eventData.OrderAllowType.HasFlag(OrderAllowType.Foundations)))
			{
				if (eventData.OrderType.Equals(OrderType.Allow))
				{
					baseBuildingInstance.IsForbidden = false;
				}
				else
				{
					baseBuildingInstance.IsForbidden = true;
				}
			}
		}

		private void ShowDisposeParticles()
		{
			if (!LoadingController.IsSceneTransition && !LoadingController.IsLeavingMainScene && MonoSingleton<World>.IsInstantiated() && MonoSingleton<ParticleSystemPool>.IsInstantiated() && BaseBuildingInstance != null && !string.IsNullOrEmpty(BaseBuildingInstance.Blueprint.DestroyParticles) && !BaseBuildingInstance.MarkedForMoving && !BaseBuildingInstance.MarkedForUninstall && (BaseBuildingInstance.ConstructionPhase.Equals(ConstructionPhase.Finished) || BaseBuildingInstance.ConstructionPhase.Equals(ConstructionPhase.Foundation)))
			{
				GameObject gameObject = MonoSingleton<ParticleSystemPool>.Instance.PlayParticles(BaseBuildingInstance.Blueprint.DestroyParticles, BaseBuildingInstance.GetPosition());
				if (gameObject != null)
				{
					MonoSingleton<ParticleSystemPool>.Instance.SetEmitterSize(BaseBuildingInstance.Blueprint.DestroyParticles, gameObject, clickCollider, 0.8f);
				}
			}
		}

		private Vector3 ParticleEmitterSize()
		{
			return new Vector3(y: (!(clickCollider != null) || !(clickCollider is BoxCollider)) ? ((float)World.MapBlockHeight) : ((BoxCollider)clickCollider).size.y, x: BaseBuildingInstance.Size.x, z: BaseBuildingInstance.Size.z);
		}
	}
}
