using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using LitJson;
using UnityEngine;
using UnityEngine.Scripting;

namespace Gh.Tk
{
	[InitializeOnGameStarted]
	public class Room : GameObjectX, IPriceConfigurable, IPatronRatable, IDisplayNameConfigurable
	{
		public static class NavigationZoneTags
		{
			public const int StaffZones = 1;

			public const int Unzoned = 2;

			public const int PrivateZones = 3;

			public const int Avoid = 4;
		}

		[CompilerGenerated]
		private sealed class _003C_003Ec__DisplayClass111_0
		{
			public Staff staff;

			public Room _003C_003E4__this;

			public Func<FireExtinguisher, float> _003C_003E9__10;

			internal void _003CGetAvailableManualJobs_003Eb__0()
			{
			}

			internal void _003CGetAvailableManualJobs_003Eb__1()
			{
			}

			internal void _003CGetAvailableManualJobs_003Eb__6()
			{
			}

			internal float _003CGetAvailableManualJobs_003Eb__10(FireExtinguisher x)
			{
				return 0f;
			}

			internal void _003CGetAvailableManualJobs_003Eb__2()
			{
			}

			internal void _003CGetAvailableManualJobs_003Eb__4()
			{
			}

			internal void _003CGetAvailableManualJobs_003Eb__19()
			{
			}
		}

		[CompilerGenerated]
		private sealed class _003C_003Ec__DisplayClass111_1
		{
			public ButtonContextMenuItem polishFloorButton;

			public _003C_003Ec__DisplayClass111_0 CS_0024_003C_003E8__locals1;

			internal bool _003CGetAvailableManualJobs_003Eb__5()
			{
				return false;
			}
		}

		[CompilerGenerated]
		private sealed class _003CGetAvailableManualJobs_003Ed__111 : IEnumerable<ContextMenuItem>, IEnumerable, IEnumerator<ContextMenuItem>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private ContextMenuItem _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			private Staff staff;

			public Staff _003C_003E3__staff;

			public Room _003C_003E4__this;

			private _003C_003Ec__DisplayClass111_0 _003C_003E8__1;

			private _003C_003Ec__DisplayClass111_1 _003C_003E8__2;

			private IEnumerator<ContextMenuItem> _003C_003E7__wrap1;

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
			public _003CGetAvailableManualJobs_003Ed__111(int _003C_003E1__state)
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
		private sealed class _003CGetAvailableManualJobs_003Ed__112 : IEnumerable<ContextMenuItem>, IEnumerable, IEnumerator<ContextMenuItem>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private ContextMenuItem _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			public Room _003C_003E4__this;

			private Patron patron;

			public Patron _003C_003E3__patron;

			private IEnumerator<ContextMenuItem> _003C_003E7__wrap1;

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
			public _003CGetAvailableManualJobs_003Ed__112(int _003C_003E1__state)
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

		public static HashSet<Room> AllRooms;

		private static string _roomNamePrefix;

		private RoomZone _currentZone;

		[PersistenceOptIn]
		public int roomId;

		[PersistenceOptIn]
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		private int _costToUnlock;

		[PersistenceOptIn]
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		private ZonePolicy[] _policies;

		[PersistenceOptIn]
		[PersistenceObjectReference]
		[PersistenceAllowBrokenReferenceOnLoad]
		public List<Room> ConnectingRooms;

		public static int TilesPerCombinedMesh;

		private List<MeshFilter> _roomMeshFilters;

		private GameObject _navigationTagModifiers;

		[JsonIgnore]
		private List<TileData> _roomTiles;

		[JsonIgnore]
		private bool _roomTilesDirty;

		private GameObject _selectionHighlightStitchedObject;

		private static GameObject _floorSelectionPrefab;

		private static Color? _floorSelectionDefaultColor;

		protected List<Prop> Props;

		public List<Actor> Actors;

		public List<Fire> Fires;

		public List<GameObjectX> GameObjectXs;

		public List<Door> Doors;

		public List<DirtBase> Dirt;

		public List<InfestationNest> Nests;

		private int _tileCount;

		[PersistenceOptIn]
		private float _secondsUntilNextDustGeneration;

		[PersistenceOptIn]
		private float _lastDustGeneration;

		[PersistenceOptIn]
		private float _dustToGain;

		[PersistenceOptIn]
		private float _secondsUntilNextActorFireCheck;

		private int _maxActorsToCheckForFireAtOnce;

		[PersistenceOptIn]
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		private int _currentPrice;

		private static readonly int[] _tapRoomRoomSizes;

		public static EventHandler RoomStarChanged;

		private FrameCachedValue<float> _decorationValueCache;

		[JsonIgnore]
		public string FullNameKey => null;

		public RoomZone CurrentZone
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public override List<Room> CurrentRooms
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		[PersistenceOptIn]
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		public bool IsOutsideArea { get; private set; }

		public int Stars => 0;

		public string Category => null;

		[PersistenceOptIn]
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		public bool IsValid { get; private set; }

		public int CostToUnlock
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public bool IsLockedToPlayer => false;

		public ZonePolicy[] Policies => null;

		public List<TileData> Tiles => null;

		[PersistenceOptIn]
		[PersistenceObjectReference]
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		internal GameItemTemplate SelectedLinenType { get; private set; }

		public static GameObject FloorSelectionPrefab => null;

		private static Color FloorSelectionDefaultColor => default(Color);

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

		public StarRatingManager StarRatingManager { get; private set; }

		public static event EventHandler AllRoomsChanged
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

		public event EventHandler<EventArgs<RoomZone>> CurrentZoneChanged
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

		public static event EventHandler LockedRoomsChanged
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

		public static event EventHandler<EventArgs> ZoneChanged
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

		public static event EventHandler AfterZoneChanged
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

		public event EventHandler SelectedLinenTypeChanged
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

		public static event EventHandler<EventArgs<Room>> PropsChanged
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

		public override string GetDisplayNameKey(bool withPrefix = true)
		{
			return null;
		}

		public override string GetDisplayName(bool withPrefix = true)
		{
			return null;
		}

		public Vector3 GetWorldPosition()
		{
			return default(Vector3);
		}

		public void RefreshPoliciesFromZone()
		{
		}

		public bool IsZonedAs(string zoneId)
		{
			return false;
		}

		public override ScheduleTimeSlot[] GetDefaultSchedule()
		{
			return null;
		}

		public override List<SlotOption> GetAvailableScheduleItems()
		{
			return null;
		}

		public bool IsSchedulingAllowed()
		{
			return false;
		}

		public override bool CanSelect()
		{
			return false;
		}

		public override void Start()
		{
		}

		public override IEnumerable<ContextMenuItem> GetContextMenuItems()
		{
			return null;
		}

		private void UpdateContextMenu()
		{
		}

		public ContextMenuItem[] GetRezoneContextMenuItems()
		{
			return null;
		}

		public void InitRoom(int id, bool isOutside)
		{
		}

		internal void Invalidate()
		{
		}

		public void InvalidateSelectionHighlight()
		{
		}

		private void CreateNavigationTagModifiers()
		{
		}

		private IEnumerable<Tuple<Vector2Int, Vector2Int>> GetFillingRectangles()
		{
			return null;
		}

		public void CreateRoomMeshes()
		{
		}

		private void ClearRoomMeshes()
		{
		}

		private void CreateRoomMesh(CombineInstance[] combineInstances, Material[] sharedMaterials)
		{
		}

		public IEnumerable<Prop> GetValidProps()
		{
			return null;
		}

		public IEnumerable<T> GetValidProps<T>() where T : Prop
		{
			return null;
		}

		public IEnumerable<Prop> GetProps()
		{
			return null;
		}

		public int GetRoomSize()
		{
			return 0;
		}

		public int GetCostToRezone(RoomZone newZone)
		{
			return 0;
		}

		public void ZoneAs(RoomZone zone)
		{
		}

		private void RezoneRoomTiles()
		{
		}

		private void ApplyAtmosphereEquilibriumValues()
		{
		}

		internal void RefreshTiles(bool animate = false)
		{
		}

		public void RefreshConnectingRooms()
		{
		}

		public bool CanEnter(Actor actor)
		{
			return false;
		}

		public void ChangeLinenType(GameItemTemplate type)
		{
		}

		internal bool IsBehaviourAllowed(string behaviour)
		{
			return false;
		}

		public override void AddHighlight(Color? color = null)
		{
		}

		private void NewHighlight(GameObject obj, TileData tile, int rotation)
		{
		}

		public override void RemoveHighlight()
		{
		}

		public override bool IsHighlighted()
		{
			return false;
		}

		[IteratorStateMachine(typeof(_003CGetAvailableManualJobs_003Ed__111))]
		public override IEnumerable<ContextMenuItem> GetAvailableManualJobs(Staff staff)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CGetAvailableManualJobs_003Ed__112))]
		public override IEnumerable<ContextMenuItem> GetAvailableManualJobs(Patron patron)
		{
			return null;
		}

		public override bool IsInsideTavern()
		{
			return false;
		}

		public override void OnDestroy()
		{
		}

		public override void UpdateObject()
		{
		}

		public void ApplyRoomAreaMesh(GameObject baseObject)
		{
		}

		public new bool IsOnFire()
		{
			return false;
		}

		public void Add(Fire fire)
		{
		}

		public void Remove(Fire fire)
		{
		}

		public void Add(GameObjectX gox)
		{
		}

		public void Remove(GameObjectX gox)
		{
		}

		protected override void UpdateInternal()
		{
		}

		private void GenerateDirtAndDust()
		{
		}

		private void GenerateDirtAndDust(float deltaTime)
		{
		}

		private void UpdateFireCheck()
		{
		}

		private void CheckActorsForFire()
		{
		}

		public bool IsScheduled(string scheduleOption)
		{
			return false;
		}

		public bool IsExplicitlyScheduled(string scheduleOption)
		{
			return false;
		}

		public float GetStockManagementUrgency()
		{
			return 0f;
		}

		public (int, int) GetAllowedPriceRange()
		{
			return default((int, int));
		}

		public int GetPrice()
		{
			return 0;
		}

		public int GetTier()
		{
			return 0;
		}

		public (int, string) GetOkPrice(string race, int tier, bool generateReason)
		{
			return default((int, string));
		}

		public float GetEffectiveQuality(string race, int tier, StringBuilder details = null)
		{
			return 0f;
		}

		public float GetExpectedQuality(string race, int tier)
		{
			return 0f;
		}

		public ScheduleTimeSlot GetScheduleForHour(int targetHour)
		{
			return null;
		}

		public override void EditSchedule()
		{
		}

		public TileData GetNearRandomSecludedTile(GameObjectX nearWhere, GameObjectX[] obstaclesToExclude = null, float distanceBias = 1f, float obstacleInfluenceDecay = 0.5f, float applyPenaltyIfNearerThan = 3f, Actor actorToReachIt = null)
		{
			return null;
		}

		public bool IsDeepCleaned()
		{
			return false;
		}

		public int GetNumberOfBehavioursThatCanBeHandledInRom(Patron patron)
		{
			return 0;
		}

		private void ExcludeNullsFromLists()
		{
		}

		private void PlayZoningSFX(RoomZone zone)
		{
		}

		public void UpdateStarRatingManager()
		{
		}

		private void OnStarRatingChanged(object sender, EventArgs e)
		{
		}

		internal float CalculateDecorationValue()
		{
			return 0f;
		}
	}
}
