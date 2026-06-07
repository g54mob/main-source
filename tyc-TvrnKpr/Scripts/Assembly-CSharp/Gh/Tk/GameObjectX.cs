using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using DG.Tweening;
using LitJson;
using Pathfinding;
using UnityEngine;
using UnityEngine.Serialization;
using Utils;

namespace Gh.Tk
{
	[DisallowMultipleComponent]
	[SelectionBase]
	public class GameObjectX : MonoBehaviourX, IReferenceableObject, ICustomSaveState, ILateRestoreState, ILateLateRestoreState, ISelectable, IContextMenuProvider, IBasicAnimEventSupport
	{
		public delegate void PrimaryClickAction(bool isDeselectClick);

		public delegate void PrimaryClickActionListener(GameObjectX gox, bool isDeselectClick);

		[Serializable]
		public class SpawnedItem : IEquatable<SpawnedItem>
		{
			public int GoxId;

			[JsonIgnore]
			private GameObjectX _gox;

			public string ChildTransformName;

			[JsonIgnore]
			public GameObjectX Gox
			{
				get
				{
					return null;
				}
				set
				{
				}
			}

			public override bool Equals(object obj)
			{
				return false;
			}

			public bool Equals(SpawnedItem other)
			{
				return false;
			}

			public override int GetHashCode()
			{
				return 0;
			}
		}

		public class GameObjectXEventArgs<T> : EventArgs<T>
		{
			public GameObjectX GameObjectX { get; set; }

			public GameObjectXEventArgs(T item, GameObjectX gox)
				: base(default(T))
			{
			}
		}

		[Serializable]
		public enum MeshType
		{
			Dirt = 0
		}

		public class StatusInfo : IPersistable
		{
			public int contextId;

			public int priority;

			[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
			public float autoRemoveTime;

			[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
			public float showTime;

			public string icon;

			public string iconBackerStyle;

			[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
			public string highLevelDescription;

			[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
			public string activityDescription;

			[JsonIgnore]
			public bool IsEnabled => false;
		}

		public class ErrorInfo : StatusInfo
		{
			public string errorKey;

			[FormerlySerializedAs("errorMessage")]
			public string errorMessageKey;

			[FormerlySerializedAs("errorDetail")]
			public string errorDetailKey;

			public string alertType;
		}

		[CompilerGenerated]
		private sealed class _003C_003Ec__DisplayClass473_0
		{
			public GameObjectX _003C_003E4__this;

			public Staff staff;

			public Func<Job, bool> _003C_003E9__2;

			internal void _003CGetAvailableManualJobs_003Eb__0()
			{
			}

			internal bool _003CGetAvailableManualJobs_003Eb__2(Job x)
			{
				return false;
			}
		}

		[CompilerGenerated]
		private sealed class _003CGetAvailableManualJobs_003Ed__473 : IEnumerable<ContextMenuItem>, IEnumerable, IEnumerator<ContextMenuItem>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private ContextMenuItem _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			public GameObjectX _003C_003E4__this;

			private Staff staff;

			public Staff _003C_003E3__staff;

			private _003C_003Ec__DisplayClass473_0 _003C_003E8__1;

			private IEnumerator<Job> _003C_003E7__wrap1;

			ContextMenuItem IEnumerator<ContextMenuItem>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CGetAvailableManualJobs_003Ed__473(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			private void _003C_003Em__Finally1()
			{
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}

			[DebuggerHidden]
			IEnumerator<ContextMenuItem> IEnumerable<ContextMenuItem>.GetEnumerator()
			{
				return null;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
			}
		}

		[CompilerGenerated]
		private sealed class _003CGetAvailableManualJobs_003Ed__474 : IEnumerable<ContextMenuItem>, IEnumerable, IEnumerator<ContextMenuItem>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private ContextMenuItem _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			ContextMenuItem IEnumerator<ContextMenuItem>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CGetAvailableManualJobs_003Ed__474(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}

			[DebuggerHidden]
			IEnumerator<ContextMenuItem> IEnumerable<ContextMenuItem>.GetEnumerator()
			{
				return null;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
			}
		}

		public static HashSet<GameObjectX> AllGameObjectXs;

		public bool ShowInventoryOnInfoPanel;

		[SerializeField]
		[PersistenceOptIn]
		protected string _defaultDisplayName;

		[PersistenceOptIn]
		protected string _playerSetDisplayName;

		[HideInInspector]
		[PersistenceOptIn]
		public string Description;

		[PersistenceOptIn]
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		public bool IsTemporarilyBlockingDirt;

		private Buildable _buildable;

		protected AccessPoint[] staffAccessPoints;

		protected AccessPoint[] patronAccessPoints;

		public bool IsSocialPoint;

		private List<AccessPoint> _obstructedMandatoryAccessPoints;

		private bool _mandatoryAccessPointIsObstructed;

		public Transform ModelTransform;

		private EventHandler _inventoryChangedHandler;

		[SerializeField]
		private GameObject _soundPlayerObject;

		protected bool _isSoundInitilized;

		private bool _blowOutFireStatusIconActive;

		private bool _isDecorBakeInvalid;

		[SerializeField]
		[HideInInspector]
		protected List<Renderer> _highlightableRenderers;

		private static int[] _layersToIgnoreForHighlighting;

		protected readonly List<GameObject> _currentSelectionHighlights;

		private bool _isSelected;

		private Collider[] _colliders;

		internal GameController _gameController;

		private FrameCachedValue<List<TileData>> _tiles;

		public EventHandler<EventArgs<Room>> LeftRoom;

		public EventHandler<EventArgs<Room>> EnteredRoom;

		protected EventHandler<EventArgs<List<Room>>> ChangedRooms;

		protected static readonly NNConstraint NnConstraint;

		[PersistenceOptIn]
		public SpawnedItem SpawnedConvItem;

		[PersistenceOptIn]
		public List<SpawnedItem> SpawnedItems;

		[PersistenceOptIn]
		private List<string> _transformsToEnable;

		[PersistenceOptIn]
		private List<string> _transformsToDisable;

		[SerializeField]
		private bool _suppressInfoPanel;

		[SerializeField]
		private bool _supressNoModelFoundWarning;

		private static float _precise;

		private bool? _canCatchFire;

		private const float MinDistanceToBigFireForBlowOutFireStatusIconSquared = 64f;

		private bool _showCollisionWireframes;

		private readonly List<CollisionVisualizer> _collisionVisualizers;

		private bool _markedToDestroy;

		[JsonIgnore]
		private bool _isCoreInitialized;

		private readonly Dictionary<Type, object> _aiComponentLookupCache;

		private readonly HashSet<Type> _aiComponentTypesWichAreNotPresent;

		private float _accumulatedDeltaTime;

		private const float DeltaThreshold = 0.25f;

		private const float MaxDeltaThreshold = 1f;

		private const int MaxFrameDistribution = 30;

		private int _targetFrameNumber;

		[JsonIgnore]
		public SparksGenerator SparksGenerator;

		protected AnimationController _animationController;

		private const string TurnLeftAnimation = "u:turnLeft;";

		private const string TurnRightAnimation = "u:turnRight;";

		[PersistenceOptIn]
		public RollingList<LogEntry<AnimationBoolLog>> AnimationBoolLogs;

		[PersistenceOptIn]
		public List<string> CurrentAnimationBoolsSet;

		public bool _canBeAtmosphereSource;

		protected bool _isAtmosphereSourceStationary;

		private FrameCachedValue<List<TileData>> _atmosphereTilesCache;

		private Dictionary<string, FrameCachedValue<float>> _atmosphereValuesCache;

		[Header("Atmosphere")]
		[PersistenceOptIn]
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		public float temperatureOutput;

		public bool isTemperatureActiveOnStart;

		[PersistenceOptIn]
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		public float noiseOutput;

		public bool isNoiseActiveOnStart;

		[PersistenceOptIn]
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		public float filthOutput;

		public bool isFilthActiveOnStart;

		[PersistenceOptIn]
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		public float brightnessOutput;

		public bool isBrightnessActiveOnStart;

		[PersistenceOptIn]
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		public float decorOutput;

		public bool isDecorActiveOnStart;

		public EventHandler FilthChanged;

		[PersistenceOptIn]
		private Dictionary<string, sbyte> _atmosphereEffectOutputs;

		[PersistenceOptIn]
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		private int _previousTileIndex;

		private Transform _decoObstruction;

		[PersistenceOptIn]
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		private bool _autoGenerateObstruction;

		private bool _boxColliderUpdateSuppressed;

		private readonly List<GameObject> _obstructionVisuals;

		private bool _showObstructions;

		private bool _obstructionBoxColliderIsDirty;

		[Tooltip("specify groups of meshrenderers that can be disabled by the player")]
		public MeshGroup[] namedMeshGroups;

		private Dictionary<DirtType, bool> _dirtRendererValidChecks;

		[PersistenceOptIn]
		private List<string> disabledMeshGroups;

		private List<EntityObject> _replayEntityObjects;

		[PersistenceOptIn]
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		protected float _entityObjectsAtmosphereOutput;

		private static readonly Dictionary<string, GameObject[]> _dirtPrefabs;

		[HideInInspector]
		public Flammability Flammability;

		[HideInInspector]
		public SparkChance SparkChance;

		[PersistenceOptIn]
		public RollingList<LogEntry<string>> ActivityLog;

		[PersistenceOptIn]
		public RollingList<LogEntry<string>> JobLog;

		private static PrefabObjectPool _nameTagPool;

		private NameTag3DUIView _nameTag3DUIView;

		private bool _isNameTagDirty;

		public bool canHaveSchedule;

		public SlotOption[] allowedScheduleItems;

		public ScheduleTimeSlot[] defaultSchedule;

		[PersistenceOptIn]
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		private ScheduleTimeSlot[] _schedule;

		private static readonly ScheduleTimeSlot TempSlot;

		private StatusIconUIView _statusIconUIView;

		[PersistenceOptIn]
		private List<StatusInfo> _statusInfoItems;

		internal ErrorInfo[] _currentErrors;

		private ErrorInfo _currentErrorItem;

		public static EventHandler CurrentErrorsChanged;

		protected virtual int DefaultComponentCollectionSize => 0;

		[PersistenceOptIn]
		public int Id { get; private set; }

		public string DefaultDisplayName => null;

		public bool HasPlayerSetCustomName => false;

		public Buildable Buildable => null;

		[PersistenceOptIn]
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		public bool Ready { get; set; }

		public Inventory Inventory { get; protected set; }

		[PersistenceOptIn]
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		public GameItem GameItem { get; set; }

		public bool IsCurrentlySelectable { get; set; }

		public bool MandatoryAccessPointIsObstructed
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool IsStillLoading { get; protected set; }

		public bool StartWasCalled { get; private set; }

		public BaseAnimationOld[] BaseAnimationsOld { get; private set; }

		public BaseAnimation[] BaseAnimations { get; private set; }

		public NavmeshCut[] ObstacleWhenInUseNavMeshCuts { get; private set; }

		public GameObject SoundPlayerObject
		{
			get
			{
				return null;
			}
			protected set
			{
			}
		}

		public ObservableCollection<ContextMenuItem> ContextMenuItems { get; private set; }

		public bool IsSelected
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public Dictionary<string, PrimaryClickActionListener> OnPrimaryClickActionListeners { get; set; }

		public virtual List<TileData> CurrentTiles => null;

		public virtual List<Room> CurrentRooms { get; set; }

		public PrefabTypeIdentifier PrefabTypeIdentifier { get; set; }

		public bool SuppressInfoPanel
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		[PersistenceOptIn]
		[PersistenceObjectReference]
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		public Fire Fire { get; set; }

		public virtual float Damage
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public bool ShowCollisionWireframes
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool MarkedToDestroy
		{
			get
			{
				return false;
			}
			private set
			{
			}
		}

		[PersistenceOptIn]
		protected List<AiComponent> _aiComponents { get; private set; }

		public IEnumerable<AiComponent> AiComponents => null;

		public IEnumerable<IAiComponentVisualInfo> AiComponentVisualInfos => null;

		public IEnumerable<GameObjectXTrait> Traits => null;

		public IEnumerable<GameObjectXStat> Stats => null;

		public bool AutoGenerateObstruction
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		protected Transform DecorationObstacle => null;

		[PersistenceOptIn]
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		public EntityObject DecorEntityObject { get; private set; }

		[PersistenceOptIn]
		public Dictionary<DirtType, EntityObject> DirtEntityObjects { get; private set; }

		[PersistenceOptIn]
		[PersistenceObjectReference]
		public ObservableCollection<Job> CurrentJobs { get; protected set; }

		public ScheduleTimeSlot[] Schedule
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public IEnumerable<StatusInfo> StatusInfoItems => null;

		public event EventHandler DisplayNameChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public static event EventHandler<EventArgs> MandatoryAccessPointIsObstructedChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event EventHandler PostBuilt
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event EventHandler BeforeDemolishing
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event EventHandler Destroyed
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event EventHandler<EventArgs<SpawnedItem>> SpawnedItemAdded
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event EventHandler<EventArgs> MarkedToDestroyChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public static event EventHandler<GameObjectXEventArgs<AiComponent>> AiComponentAdded
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public static event EventHandler<GameObjectXEventArgs<AiComponent>> AiComponentRemoved
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public static event EventHandler<EventArgs> ScheduleChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event EventHandler ProblemsChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public void GenerateId()
		{
		}

		public void SetDefaultDisplayName(string nameKey)
		{
		}

		public virtual void SetDisplayName(string newName)
		{
		}

		public virtual string GetDisplayName(bool withPrefix = true)
		{
			return null;
		}

		public virtual string GetDisplayNameKey(bool withPrefix = true)
		{
			return null;
		}

		protected virtual string GetDefaultDisplayNameKey()
		{
			return null;
		}

		protected string GetNameModifier()
		{
			return null;
		}

		public static IEnumerable<Renderer> GetMaterialRenderers(Transform target)
		{
			return null;
		}

		public virtual bool IsReadyToUse(bool ignoreWhenBroken = false)
		{
			return false;
		}

		public virtual bool StartDropInventoryJob()
		{
			return false;
		}

		public virtual bool CanUseDirectly(Actor actor)
		{
			return false;
		}

		public virtual int GetPositionFor(GameItemTemplate template, int amount, bool ignoreOverride = true)
		{
			return 0;
		}

		public GameObject GetModelCopyForUI(Transform where)
		{
			return null;
		}

		protected virtual GameObject CreateUIModel()
		{
			return null;
		}

		public static void SetFinalModel(Transform modelTransform)
		{
		}

		public IEnumerable<AccessPoint> GetAccessPoints(Actor actor)
		{
			return null;
		}

		public IEnumerable<AccessPoint> GetAccessPoints(AccessPoint.AccessType type, bool ignoreObstruction = false)
		{
			return null;
		}

		private void AccessPointObstructionChanged(object sender, EventArgs e)
		{
		}

		private void UpdateAccessPointObstructed(AccessPoint ap)
		{
		}

		public IEnumerable<AccessPoint> GetAllAccessPoints(bool ignoreObstruction = false)
		{
			return null;
		}

		public IEnumerable<AccessPoint> GetAllWaitPoints(Actor actor)
		{
			return null;
		}

		public IEnumerable<Actor> GetAllActorsInQueue()
		{
			return null;
		}

		public int GetTotalAmountOfActorsQueuing(AccessPoint.AccessType type, Actor toIgnore = null)
		{
			return 0;
		}

		public int GetTotalAmountOfPatronsQueueing(Actor toIgnore = null)
		{
			return 0;
		}

		public int GetTotalAmountOfStaffQueuing(Staff toIgnore = null)
		{
			return 0;
		}

		public virtual void SaveState(IDataStore data)
		{
		}

		public virtual void RestoreState(IDataStore data)
		{
		}

		public void LateRestoreState(IDataStore data)
		{
		}

		protected virtual void LateRestoreStateInternal(IDataStore data)
		{
		}

		public void SetFinalModel(bool enable)
		{
		}

		public virtual void Awake()
		{
		}

		protected virtual void OnInventoryChanged()
		{
		}

		public override void Start()
		{
		}

		public virtual void PlaySoundEvent(string eventName)
		{
		}

		public void StopSoundEvent(string eventName)
		{
		}

		public bool IsSoundEventPlaying(string fireSoundEvent)
		{
			return false;
		}

		protected void InitSoundComponents()
		{
		}

		private void SetBoolOnSpawnedItems(object sender, AnimationEventArgs e)
		{
		}

		public void SetBoolOnSpawnedItems(string parameter, bool value)
		{
		}

		protected virtual void UpdateInternal()
		{
		}

		private void EnableBlowOutFireStatusIcon()
		{
		}

		public void DisableBlowOutFireStatusIcon()
		{
		}

		public void SmallFireIconClicked()
		{
		}

		protected void UpdateCurrentJobs()
		{
		}

		public override void UpdateObject()
		{
		}

		public void LateLateRestoreState(IDataStore data)
		{
		}

		public void InvalidateBakedDecor()
		{
		}

		protected virtual Job GetNextJob()
		{
			return null;
		}

		public virtual void PostBuiltInit()
		{
		}

		public virtual void OnDemolish()
		{
		}

		private void PlayDemolishedEffect()
		{
		}

		protected void DropInventoryItemsOnFloor()
		{
		}

		public override void OnDestroy()
		{
		}

		protected void RemoveRelatedJobs(bool includeMaintenanceJobs = true)
		{
		}

		public virtual IEnumerable<ContextMenuItem> GetContextMenuItems()
		{
			return null;
		}

		[ContextMenu("SetupHighlightableRenderers")]
		public void SetupHighlightableRenderers()
		{
		}

		public virtual bool IsHighlighted()
		{
			return false;
		}

		public virtual void AddHighlight(Color? color = null)
		{
		}

		public virtual void RemoveHighlight()
		{
		}

		public virtual bool CanSelect()
		{
			return false;
		}

		public virtual PrimaryClickAction GetPrimaryClickAction()
		{
			return null;
		}

		public bool AreCollidersOutsideTavern()
		{
			return false;
		}

		public bool AreCollidersInsideTavern()
		{
			return false;
		}

		public bool IsInLockedRoom()
		{
			return false;
		}

		public virtual bool IsInsideTavern()
		{
			return false;
		}

		private bool CalculateIsFootprintInside(bool isInside, bool acceptPartialHits = false)
		{
			return false;
		}

		public float GetAngleTo(GameObjectX obj)
		{
			return 0f;
		}

		public void ShowEventCamera(string textKey, float duration = -1f, string visual = "Default")
		{
		}

		public void UpdateCurrentRooms(bool forceTileRefresh = false)
		{
		}

		public bool CanReach(Actor actor)
		{
			return false;
		}

		private List<Room> GetCurrentRoomsFromNextDoorWhichLeadsInside()
		{
			return null;
		}

		public static bool CanReachAnyRooms(List<Room> targetRooms, Actor actor)
		{
			return false;
		}

		public void RemoveConvItem()
		{
		}

		public void SpawnConvItem(string uniqueType, Transform parentBone)
		{
		}

		public void SpawnItem(GameObject obj, string childTransformName)
		{
		}

		protected void SpawnItem(GameObject obj, Transform parentBone)
		{
		}

		private SpawnedItem SpawnItem(string uniqueType, Transform parentBone)
		{
			return null;
		}

		public void RemoveAllSpawnedItems()
		{
		}

		public void RemoveItem(string prefabTypeIdentifier, string childTransformName)
		{
		}

		public void SwitchParentTransformForSpawnedItem(string prefabTypeIdentifier, string sourceChildTransformName, string targetChildTransformName)
		{
		}

		public void Enable(string transformName)
		{
		}

		public void Disable(string transformName)
		{
		}

		public void Reset()
		{
		}

		public void EnableOnTarget(string transformName)
		{
		}

		public void DisableOnTarget(string transformName)
		{
		}

		public void EnableOnTargetItems(string transformName)
		{
		}

		public void DisableOnTargetItems(string transformName)
		{
		}

		public void EnableRandomOnSpawnedItems(string[] transformNames)
		{
		}

		public void EnableOnSpawnedItems(string transformName)
		{
		}

		public void DisableOnSpawnedItems(string transformName)
		{
		}

		public virtual float GetEffectiveness(string usage)
		{
			return 0f;
		}

		public bool IsCurrentlyUsed()
		{
			return false;
		}

		public virtual void Explode()
		{
		}

		public bool CanCatchFire()
		{
			return false;
		}

		public bool IsOnFire()
		{
			return false;
		}

		private void LateUpdate()
		{
		}

		private bool IsCarriedByActor()
		{
			return false;
		}

		public virtual void CatchFire(float startTemperature = 0.1f, Transform targetTransform = null)
		{
		}

		public IEnumerable<GameObjectX> GetObjectsToCycle()
		{
			return null;
		}

		public virtual TooltipData GetTooltipData()
		{
			return null;
		}

		public static (Vector3?, Quaternion) GetHit(Bounds bounds, GameObjectX filterGox = null, Transform filterTransform = null, LayerMask? layers = null)
		{
			return default((Vector3?, Quaternion));
		}

		public (Vector3, float) GetGotoTargetData()
		{
			return default((Vector3, float));
		}

		public virtual bool CanBeDamaged()
		{
			return false;
		}

		public void PlayParticleEffect(string prefabId)
		{
		}

		public virtual void MarkToDestroy()
		{
		}

		public bool IsCoolingProp()
		{
			return false;
		}

		protected void InitializeCore()
		{
		}

		public T AddAiComponent<T>() where T : AiComponent
		{
			return null;
		}

		public T GetOrAddAiComponent<T>() where T : AiComponent
		{
			return null;
		}

		public void RemoveAiComponent<T>() where T : AiComponent
		{
		}

		internal virtual void RaiseAiComponentAddedEvent(AiComponent item)
		{
		}

		internal virtual void RaiseAiComponentRemovedEvent(AiComponent item)
		{
		}

		public void AddAiComponent(AiComponent component)
		{
		}

		public void RemoveAiComponent(AiComponent component)
		{
		}

		public bool HasAiComponent<T>() where T : AiComponent
		{
			return false;
		}

		private void RebuildComponentCacheFromAiComponents()
		{
		}

		public T GetAiComponent<T>() where T : AiComponent
		{
			return null;
		}

		public void SetStatModifier<T>(string modifierKey, float changePerSecond, string displayReasonKey = "", float duration = -1f) where T : GameObjectXStat
		{
		}

		protected void UpdateAiComponents()
		{
		}

		private void PerformAiComponentsUpdateInternal(float deltaTime)
		{
		}

		public bool HasStat<T>() where T : GameObjectXStat
		{
			return false;
		}

		public T GetStat<T>() where T : GameObjectXStat
		{
			return null;
		}

		public T GetTrait<T>() where T : GameObjectXTrait
		{
			return null;
		}

		public T GetOrAddTrait<T>() where T : GameObjectXTrait
		{
			return null;
		}

		public bool HasTrait<T>() where T : GameObjectXTrait
		{
			return false;
		}

		public bool HasTraitOfType(string traitType)
		{
			return false;
		}

		public void AddTrait(string typeName, bool logAsTavernEvent = false)
		{
		}

		public void RemoveTrait(string typeName, bool logAsTavernEvent = false)
		{
		}

		public T AddTrait<T>() where T : GameObjectXTrait
		{
			return null;
		}

		public void RemoveTrait<T>() where T : GameObjectXTrait
		{
		}

		protected virtual void AddDefaultComponents()
		{
		}

		public virtual void Init()
		{
		}

		public IEnumerable<string> GetAvailableAnimations(string usage, GameObjectX gox, AccessPoint ap = null, GameItem gameItem = null, int position = -1, AccessPoint tap = null)
		{
			return null;
		}

		protected virtual IEnumerable<string> GetAvailableAnimations(GameObjectX gox, string activity, AccessPoint ap = null, int position = -1, GameItem gameItem = null, AccessPoint tap = null)
		{
			return null;
		}

		public void HandleIngredientVisualsOnTarget()
		{
		}

		public void AttachSpawnConvItemListener(EventHandler<SpawnConvItemEventArgs> eventHandler)
		{
		}

		public void RemoveSpawnConvItemListener(EventHandler<SpawnConvItemEventArgs> eventHandler)
		{
		}

		public void SetAnimationBool(string animation, bool value, GameObjectX interactionObject = null, string usedByRace = null, string controllerTransformName = null)
		{
		}

		public void TurnLeft(bool value)
		{
		}

		public void TurnRight(bool value)
		{
		}

		private void SetTurnAnimation(string animation, bool value)
		{
		}

		private void LogAnimationBool(string animation, bool value)
		{
		}

		public bool GetAnimationBool(string animation)
		{
			return false;
		}

		public void AttachAnimEventListener(EventHandler<AnimationEventArgs> eventHandler)
		{
		}

		public void RemoveAnimEventListener(EventHandler<AnimationEventArgs> eventHandler)
		{
		}

		public IEnumerable<AnimatorControllerParameter> GetAnimationParameters()
		{
			return null;
		}

		public void SetAnimationTrigger(string trigger, string controllerTransformName = null)
		{
		}

		public void SetAnimationFloatValue(string paramName, float value)
		{
		}

		public void SetAnimationIntValue(string paramName, int value)
		{
		}

		public void SwitchAnimationLayer(string layer, GameObjectX interactionObject = null, string usedByRace = null, string controllerTransformName = null)
		{
		}

		public void SetAnimationSpeedFactor(float speedFactor)
		{
		}

		public void FireAnimEvent(string name)
		{
		}

		public void TryResetAnimationController()
		{
		}

		public void AttachSetBoolOnTargetListener(EventHandler<AnimationEventArgs> eventHandler)
		{
		}

		public void RemoveSetBoolOnTargetListener(EventHandler<AnimationEventArgs> eventHandler)
		{
		}

		protected void CrossFadeInFixedTime(string stateNameHash, float transitionDuration)
		{
		}

		protected void SetIdleSubState(float idleSubState)
		{
		}

		protected void SetSubIdleStateTransition(float transitionValue)
		{
		}

		public bool IsAnimating(int layer)
		{
			return false;
		}

		public void AttachSpawnItemListener(EventHandler<SpawnItemEventArgs> eventHandler)
		{
		}

		public void RemoveSpawnItemListener(EventHandler<SpawnItemEventArgs> eventHandler)
		{
		}

		public void SetAnimationMovementSpeed(float moveSpeed)
		{
		}

		public void SetAnimationRotationSpeed(float speed)
		{
		}

		public void AttachSetBoolOnItemsListener(EventHandler<AnimationEventArgs> eventHandler)
		{
		}

		public void RemoveSetBoolOnItemsListener(EventHandler<AnimationEventArgs> eventHandler)
		{
		}

		public bool IsInAnimationState(string state)
		{
			return false;
		}

		public string GetSetAnimationBoolInfo()
		{
			return null;
		}

		public string GetAnimationBoolHistory(int maxAmount)
		{
			return null;
		}

		public string GetJobLogHistory(int maxAmount)
		{
			return null;
		}

		public string GetActivityLogHistory(int maxAmount)
		{
			return null;
		}

		public void SetAsCameraFollowTarget()
		{
		}

		public float GetAtmosphereValue(string atmosphereType)
		{
			return 0f;
		}

		public virtual sbyte GetEffectiveDecorOutput()
		{
			return 0;
		}

		protected virtual void SetFilth(float filth)
		{
		}

		public int GetFilthPercentage()
		{
			return 0;
		}

		protected void ApplyInitialAtmosphereOutputs()
		{
		}

		protected void RemoveAtmosphereOutputs()
		{
		}

		public void SetAreaEffectActive(string effect, bool active, sbyte? value = null)
		{
		}

		public void StartAreaEffects()
		{
		}

		public void StopAreaEffects()
		{
		}

		protected void CheckForTileChange(bool forceUpdate = false)
		{
		}

		public virtual GameItem[] GetInventoryContentOrdered()
		{
			return null;
		}

		public string GetMaxConfiguredAreaEffectType()
		{
			return null;
		}

		private void UpdateBoxCollider()
		{
		}

		protected virtual void OnDecorVolumeChanged()
		{
		}

		public void ShowObstructions(bool show)
		{
		}

		private void UpdateObstructionVisuals()
		{
		}

		public void MarkObstructionBoxColliderDirty()
		{
		}

		private void UpdateObstructionBoxCollider()
		{
		}

		public void CheckNamedMeshGroups()
		{
		}

		public IEnumerable<string> GetDisabledMeshGroups()
		{
			return null;
		}

		protected void RestoreDisabledMeshGroups()
		{
		}

		private void OnBuildHelpersChanged(object sender, EventArgs<bool> eventArgs)
		{
		}

		private void ForceEnabledMeshGroupColliders(bool forceEnable)
		{
		}

		public void ToggleMeshVisibility(string meshGroup, bool? visible = null)
		{
		}

		protected virtual void AddDefaultContextMenuItems()
		{
		}

		public Sequence ReplayDecorCreation(bool prepareAndCleanEntities = true, float maxInterval = 0.12f, float maxSequenceDuration = 5f, Ease easing = Ease.Linear)
		{
			return null;
		}

		private void PrepareForReplay()
		{
		}

		private void CleanUpReplay()
		{
		}

		public static Sequence ReplayAllDecorationsPerProp(GameObjectX[] objects, float delayBetweenPropsStart = 0.5f, float maxIntervalPerDecor = 0.12f, float maxDecorSequenceDuration = 5f, Ease propEase = Ease.Linear, Ease decorEase = Ease.Linear)
		{
			return null;
		}

		public static Sequence ReplayAllDecorationsIndividually(GameObjectX[] objects, float totalDuration = 5f, Ease easing = Ease.Linear)
		{
			return null;
		}

		internal ContextMenuItem CreateToggleVisibilityContextMenuItem()
		{
			return null;
		}

		internal void SetNewDecorEntityObject(EntityObject entityObject)
		{
		}

		public void EnsureDecorEntityObjectExists()
		{
		}

		public void EnsureDirtEntityObjectExists(DirtType type)
		{
		}

		private void SetNewDirtEntityObject(DirtType type, EntityObject entityObject)
		{
		}

		public void AttachToDecor(EntityObject obj)
		{
		}

		public void RemoveFromDecor(EntityObject obj)
		{
		}

		public void AttachToDirt(DirtType type, EntityObject obj)
		{
		}

		public void DestroyEntity(GameObject go)
		{
		}

		protected void InvalidateAllDirtRenderers()
		{
		}

		protected void InvalidateDirtRenderer(DirtType type)
		{
		}

		public override void OnEnable()
		{
		}

		public override void OnDisable()
		{
		}

		public void TrySaveAsUserTemplate()
		{
		}

		private void RemoveAllEntities()
		{
		}

		public void RemoveDirtEntities(DirtType type)
		{
		}

		private void RemoveDecorEntities()
		{
		}

		public void InvalidateDecorationEffects()
		{
		}

		protected static GameObject GetRandomDirtPrefab(DirtType dirtType, string uniqueKeyFilterOverride = null)
		{
			return null;
		}

		public Flammability GetCurrentFlammability()
		{
			return default(Flammability);
		}

		public bool IsCurrentlyHandlingJobOfType<T>() where T : Job
		{
			return false;
		}

		public bool IsCurrentlyHandlingJobOfTypeWithATargetSet<T>() where T : Job
		{
			return false;
		}

		public void AddActivityLog(string value)
		{
		}

		public void AddJobLog(string value)
		{
		}

		public void AssignParallelJob(Job newJob)
		{
		}

		public void AssignJob(Job newJob, bool destroyOthers = false)
		{
		}

		public virtual bool InjectJob(Job job)
		{
			return false;
		}

		private void CheckNotStartedJobs()
		{
		}

		public void StartJob(Job job)
		{
		}

		public void ReportActivityProgress(int progress)
		{
		}

		protected ContextMenuItem CreateJobAssignmentContextMenuItem(Job job, Staff staff)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CGetAvailableManualJobs_003Ed__473))]
		public virtual IEnumerable<ContextMenuItem> GetAvailableManualJobs(Staff staff)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CGetAvailableManualJobs_003Ed__474))]
		public virtual IEnumerable<ContextMenuItem> GetAvailableManualJobs(Patron patron)
		{
			return null;
		}

		public virtual void AbortAllJobs()
		{
		}

		public void AbortCurrentJobs()
		{
		}

		private void ShowNameTag(string name)
		{
		}

		private void HideNameTag()
		{
		}

		private void InitNameTag()
		{
		}

		private void PositionNameTag()
		{
		}

		public void MarkNameTagDirty()
		{
		}

		public void UpdateNameTagVisibility()
		{
		}

		protected virtual bool ShouldShowNameTag()
		{
			return false;
		}

		public bool HasDefaultSchedule()
		{
			return false;
		}

		protected virtual void OnScheduleChanged()
		{
		}

		public virtual List<SlotOption> GetAvailableScheduleItems()
		{
			return null;
		}

		public ScheduleTimeSlot GetScheduleForCurrentHour(float hourOffset = 0f)
		{
			return null;
		}

		public virtual void EditSchedule()
		{
		}

		public virtual ScheduleTimeSlot[] GetDefaultSchedule()
		{
			return null;
		}

		public void ShowPriorityIcon(bool show)
		{
		}

		protected StatusIconUIView GetStatusIcon()
		{
			return null;
		}

		protected virtual void InitStatusIcon()
		{
		}

		[ContextMenu("Update Status Icon Position")]
		public void UpdateStatusIconPosition()
		{
		}

		protected bool IsStatusIconSet()
		{
			return false;
		}

		private void ClearStatusIcon()
		{
		}

		private void SetStatusIconInternal(string icon, string backer = "none")
		{
		}

		protected virtual List<Collider> GetCollidersForStatusIconHeight()
		{
			return null;
		}

		public virtual Vector3 GetStatusIconPosition(bool worldSpace = false)
		{
			return default(Vector3);
		}

		public void SetStatusInfo(string icon, IReferenceableObject context, string backer = "thought", int priority = 0, float autoRemoveInSeconds = -1f, float showAfterSeconds = 0f)
		{
		}

		public ErrorInfo GetProblemInfo()
		{
			return null;
		}

		public ErrorInfo[] GetProblemInfos()
		{
			return null;
		}

		public virtual int SetErrorInfo(string errorKey, string errorMessageKey, string errorDetailKey, string icon, string backer = "thought", int priority = 5, float autoRemoveInSeconds = -1f, string alertType = "critical", float showAfterSeconds = 0f)
		{
			return 0;
		}

		public void ClearError(string errorKey)
		{
		}

		private void SetStatusInfoInternal(string icon, int contextId, string backer = "thought", int priority = 0, float autoRemoveInSeconds = -1f, float showAfterSeconds = 0f)
		{
		}

		private static float GetTimeStamp(float secondsFromNow)
		{
			return 0f;
		}

		private void UpdateStatusIcons()
		{
		}

		public void InvalidateStatusVisuals()
		{
		}

		public void ClearStatusIcon(IReferenceableObject context)
		{
		}

		public void ClearAllStatusIconsWithIcon(string icon)
		{
		}

		public void ClearAllStatusIconsWithPriority(int priority)
		{
		}

		public void ClearStatusIcon(int id)
		{
		}

		public void SetStoryMeterValue(float value)
		{
		}

		public float GetStoryMeterValue()
		{
			return 0f;
		}

		public void HideStoryMeter()
		{
		}

		public (int, string) GetTasksInfo(StringBuilder sb, out Dictionary<string, Action> actions)
		{
			actions = null;
			return default((int, string));
		}
	}
}
