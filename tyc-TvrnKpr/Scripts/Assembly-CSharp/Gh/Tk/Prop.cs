using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using LitJson;
using UnityEngine;
using UnityEngine.Scripting;

namespace Gh.Tk
{
	[InitializeOnGameStarted]
	[PersistenceOptIn]
	public class Prop : GameObjectX, IPatronRatable, IPriceConfigurable, IDisplayNameConfigurable
	{
		protected Transform _brokenModel;

		protected Transform _normalModel;

		protected Transform _ashModel;

		[HideInInspector]
		public string FeedbackCategoryToUse;

		[HideInInspector]
		public PropSturdiness Sturdiness;

		public static EventHandler<EventArgs> ValidPropsChanged;

		public static HashSet<Prop> AllProps;

		public static EventHandler<EventArgs<Prop>> BrokenStateChanged;

		public int maxQueueLength;

		[Header("Patron preferences")]
		public bool isPatronUsable;

		public int stars;

		[HideInInspector]
		public string propSize;

		[HideInInspector]
		public List<string> tags;

		[PersistenceOptIn]
		[PersistenceObjectReference]
		public List<Staff> StaffIdleAt;

		private static readonly SlotOption[] DefaultMaintenanceSlotOptions;

		private static readonly List<string> DefaultMaintenanceDefaultOptions;

		private static readonly ScheduleTimeSlot[] DefaultMaintenanceSchedule;

		public List<string> traits;

		[JsonIgnore]
		private double? _lastTranslationChangeOverride;

		[PersistenceOptIn]
		private double _lastTranslationChange;

		protected WallAddOn _wallAddOn;

		protected WallReplacement _wallReplacement;

		public string[] ValidZones;

		[Header("runtime")]
		public int repairDuration;

		public int cleanDuration;

		private DamageStat _damageStat;

		[PersistenceOptIn]
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		private bool _isDead;

		private FrameCachedValue<bool> _isInRightZoneCheck;

		private FrameCachedValue<ListPoolX.DisposablePooledList<Room>> _canUseWallPropCachedRooms;

		public static EventHandler<EventArgs<Prop>> IsInWrongZone;

		public List<string> SupportedBehaviours;

		public static EventHandler<EventArgs<Prop>> FilthOutputChanged;

		public float filthIncreasePerUse;

		public bool canPlayerSetPrice;

		public int maxPrice;

		[PersistenceOptIn]
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		private int _currentPrice;

		[PersistenceOptIn]
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		public bool needsPropSpecificConversations;

		protected override int DefaultComponentCollectionSize => 0;

		[JsonIgnore]
		public string FullNameKey => null;

		[JsonIgnore]
		public int Stars => 0;

		[JsonIgnore]
		public string Category => null;

		[JsonIgnore]
		public double LastTranslationChange
		{
			get
			{
				return 0.0;
			}
			private set
			{
			}
		}

		[JsonIgnore]
		public bool IsDestroyed { get; private set; }

		public DamageStat DamageStat => null;

		public override float Damage
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public bool IsDead
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
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		public bool IsAsh { get; set; }

		public Maintainable Maintainable { get; private set; }

		public override List<TileData> CurrentTiles => null;

		public int CurrentPrice
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public event EventHandler<EventArgs<bool>> IsDeadChanged
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

		public event EventHandler Used
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

		public static event EventHandler<EventArgs<Prop>> PropDecorOutputChanged
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

		public event EventHandler<UsageEventArgs> UsageStarted
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

		public event EventHandler<UsageEventArgs> UsageFinished
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

		public static event EventHandler<EventArgs> CleanJobSpawned
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

		[Preserve]
		private static void OnGameStarted()
		{
		}

		public float GetSturdinessDamageFactor()
		{
			return 0f;
		}

		public float GetEffectiveStars()
		{
			return 0f;
		}

		public override void Start()
		{
		}

		private void Prop_ChangedRooms(object sender, EventArgs<List<Room>> e)
		{
		}

		public void UpdateLastTranslationChange()
		{
		}

		public void UpdateLastTranslationChangeOverride()
		{
		}

		public void ClearLastTranslationChangeOverride()
		{
		}

		public override void Awake()
		{
		}

		private void GenerateDirt(DirtType type, int amount)
		{
		}

		public Bounds GetTotalBoundsWithoutDirt()
		{
			return default(Bounds);
		}

		private int GetMaxAmountOfDirtObjects()
		{
			return 0;
		}

		private bool AddRandomDirt(DirtType type, Bounds bounds)
		{
			return false;
		}

		private void CreateDirt(Vector3 position, Quaternion rotation, DirtType type)
		{
		}

		public virtual void OnCustomSetDown(Actor actor, GameItem itemToSetDown, int positionIndex)
		{
		}

		public virtual void OnCustomPickup(Actor actor, GameItem itemToSetDown, int positionIndex)
		{
		}

		public override void OnDestroy()
		{
		}

		private void RoomController_RoomsChanged(object sender, EventArgs e)
		{
		}

		private void Room_ZoneChanged(object sender, EventArgs e)
		{
		}

		public bool IsBuilt()
		{
			return false;
		}

		public override bool IsReadyToUse(bool ignoreWhenBroken = false)
		{
			return false;
		}

		public bool IsBroken()
		{
			return false;
		}

		public void InstantRepair()
		{
		}

		public void InstantPolish()
		{
		}

		public void InstantClean()
		{
		}

		protected virtual void OnIsBrokenChanged(object sender, EventArgs<bool> e)
		{
		}

		protected virtual void Dying()
		{
		}

		public void DestroyInventory()
		{
		}

		private void OnDamageValueChanged(object sender, ValueChangedEventArgs<float> e)
		{
		}

		public void UpdateSparkGeneratorEnabledState()
		{
		}

		public void Trash()
		{
		}

		protected override void LateRestoreStateInternal(IDataStore data)
		{
		}

		public bool IsInRightZone()
		{
			return false;
		}

		public virtual bool CanUse(Actor actor, bool ignoreMaintenanceState = false, bool ignoreBrokenState = false)
		{
			return false;
		}

		private bool CanUseWallAddOnProp(Actor actor)
		{
			return false;
		}

		public virtual bool IsAllowedToAdvanceInQueue(Actor actor)
		{
			return false;
		}

		internal virtual void OnEditingFinished()
		{
		}

		internal void OnEditingStarted()
		{
		}

		public override void PostBuiltInit()
		{
		}

		public override void OnDemolish()
		{
		}

		public void Rebuild()
		{
		}

		private void CheckZone()
		{
		}

		public void NotifyUsed()
		{
		}

		public void ShowModel(PropModelTypes type)
		{
		}

		protected virtual void ActivateBrokenModel(bool activate)
		{
		}

		public override sbyte GetEffectiveDecorOutput()
		{
			return 0;
		}

		public void InvalidateDecorEffect()
		{
		}

		protected override void AddDefaultContextMenuItems()
		{
		}

		protected void ActivateAshModel()
		{
		}

		public void TurnToAsh()
		{
		}

		public bool CanBeUsedForBehaviour(string behaviour, bool ignoreOpeningHours = false)
		{
			return false;
		}

		public virtual bool CanBeUsedForBehaviour(ActorBehaviour behaviour, bool ignoreOpeningHours = false)
		{
			return false;
		}

		public bool IsBehaviourAllowedInRoom(string behaviour)
		{
			return false;
		}

		private bool IsBehaviourAllowedInRoomForWallAddOnProp(string behaviour)
		{
			return false;
		}

		public float RateDesirability(Actor actor)
		{
			return 0f;
		}

		public float RateDesirability(Actor actor, string behaviour)
		{
			return 0f;
		}

		public virtual float RateDesirability(Actor actor, ActorBehaviour behaviour)
		{
			return 0f;
		}

		public virtual Job UseService(Actor actor, ActorBehaviour behaviour, string usageKeyOverride = null, GameItem item = null, float duration = -1f)
		{
			return null;
		}

		private void BeginAreaEffectsOnUsageStarted(string usageKey)
		{
		}

		private void EndAreaEffectsOnUseageFinished(string usageKey)
		{
		}

		protected virtual void ChargeForUse(Patron patron, string usageKey)
		{
		}

		public virtual void EndUse(string usageKey, Actor actor)
		{
		}

		public virtual void BeginUse(string usageKey, Actor actor)
		{
		}

		protected void OnUsageStarted(UsageEventArgs e)
		{
		}

		protected void OnUsageFinished(UsageEventArgs e)
		{
		}

		public virtual void IncreaseUsageFilth()
		{
		}

		private void OnFilthOutputChanged()
		{
		}

		public bool ChangeFilthOutput(float filth)
		{
			return false;
		}

		public void DecreaseFilth(float delta)
		{
		}

		private void SpawnCleanJobIfNeeded()
		{
		}

		private void UpdateFilthVisualsAndOutput()
		{
		}

		public void OnCleaned()
		{
		}

		public virtual float? GetFilth()
		{
			return null;
		}

		public virtual int GetPrice()
		{
			return 0;
		}

		public int GetTier()
		{
			return 0;
		}

		public virtual (int, string) GetOkPrice(string race, int tier, bool generateReason)
		{
			return default((int, string));
		}

		public float GetExpectedQuality(string race, int tier)
		{
			return 0f;
		}

		public virtual float GetEffectiveQuality(string race, int tier, StringBuilder details = null)
		{
			return 0f;
		}

		public (int, int) GetAllowedPriceRange()
		{
			return default((int, int));
		}

		public override IEnumerable<ContextMenuItem> GetContextMenuItems()
		{
			return null;
		}

		public void ApplyCookingEffects(Ingredient craftedItem)
		{
		}

		private float GetChanceForContamination()
		{
			return 0f;
		}

		public override bool CanBeDamaged()
		{
			return false;
		}

		public bool FitsPropFilter(string propFilter)
		{
			return false;
		}

		public Maintenance_Job CreateRepairJob()
		{
			return null;
		}

		public virtual void CreateMaintenanceJob()
		{
		}

		protected override void UpdateInternal()
		{
		}

		public void Break()
		{
		}

		public void CoverInFilth()
		{
		}

		public override void EditSchedule()
		{
		}

		protected override string GetDefaultDisplayNameKey()
		{
			return null;
		}
	}
}
