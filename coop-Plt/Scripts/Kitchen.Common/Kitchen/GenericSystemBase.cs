using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Kitchen.Layouts;
using KitchenData;
using Unity.Collections;
using Unity.Entities;
using UnityEngine;

namespace Kitchen
{
	public abstract class GenericSystemBase : SystemBase, IPersist
	{
		[StructLayout(LayoutKind.Sequential, Size = 1)]
		protected struct CSystemDataMarker : IComponentData
		{
		}

		private EntityQuery Players;

		private List<Vector3> GetPostTemp = new List<Vector3>();

		protected BufferContainerSystem _BufferSystem;

		public Entity DataEntity;

		[ReadOnly]
		private EntityQuery _SingletonEntityQuery_SAssetDirectory_9;

		[ReadOnly]
		private EntityQuery _SingletonEntityQuery_SGameTime_10;

		[ReadOnly]
		private EntityQuery _SingletonEntityQuery_SLayout_11;

		private EntityQuery _SingletonEntityQuery_SPerformSceneTransition_12;

		[ReadOnly]
		private EntityQuery _SingletonEntityQuery_SPerformSceneTransition_13;

		protected PopupUtilities PopupUtilities => base.World.GetExistingSystem<PopupUtilities>();

		protected TransitionUtilities TransitionUtilities => base.World.GetExistingSystem<TransitionUtilities>();

		protected EntityViewManager EntityViewManager => base.World.GetExistingSystem<EntityViewManager>();

		protected AssetDirectory AssetDirectory => base.EntityManager.GetSharedComponentData<CViewDirectory>(_SingletonEntityQuery_SAssetDirectory_9.GetSingletonEntity()).Directory;

		protected Transform UIContainer => base.EntityManager.GetSharedComponentData<CViewDirectory>(_SingletonEntityQuery_SAssetDirectory_9.GetSingletonEntity()).UIContainer;

		protected Bounds UIBounds => base.EntityManager.GetSharedComponentData<CViewDirectory>(_SingletonEntityQuery_SAssetDirectory_9.GetSingletonEntity()).UIBounds;

		protected Camera UICamera => base.EntityManager.GetSharedComponentData<CViewDirectory>(_SingletonEntityQuery_SAssetDirectory_9.GetSingletonEntity()).UICamera;

		protected GameData Data => GameData.Main;

		protected new SGameTime Time => _SingletonEntityQuery_SGameTime_10.GetSingleton<SGameTime>();

		protected IViewRouter Router => base.World.GetExistingSystem<RouterManager>().Entrypoint;

		protected TileManager TileManager => base.World.GetExistingSystem<TileManager>();

		protected DynamicBuffer<CLayoutRoomTile> Tiles => GetBuffer<CLayoutRoomTile>(_SingletonEntityQuery_SLayout_11.GetSingletonEntity());

		protected DynamicBuffer<CLayoutOccupant> Occupants => GetBuffer<CLayoutOccupant>(_SingletonEntityQuery_SLayout_11.GetSingletonEntity());

		protected Bounds Bounds
		{
			get
			{
				if (RequireEntity<SLayout>(out var comp) && Require<CBounds>(comp, out CBounds comp2))
				{
					return comp2.Bounds;
				}
				return default(Bounds);
			}
		}

		protected NativeArray<CLayoutRoomTile> GetTiles => Tiles.ToNativeArray(Allocator.TempJob);

		protected BufferContainerSystem BufferSystem
		{
			get
			{
				if (_BufferSystem == null)
				{
					_BufferSystem = base.World.GetOrCreateSystem<BufferContainerSystem>();
				}
				return _BufferSystem;
			}
		}

		protected Vector3 GetFallbackTile()
		{
			return GetFrontDoor(get_external_tile: true) - new Vector3(0f, 0f, 1f);
		}

		protected Vector3 GetFrontDoor(bool get_external_tile = false)
		{
			if (TryGetSingletonEntity<SLayout>(out var value) && HasComponent<CFrontDoorMarker>(value))
			{
				Vector3 location = GetComponent<CFrontDoorMarker>(value).Location;
				if (get_external_tile)
				{
					return location - new Vector3(0f, 0f, 1f);
				}
				return location;
			}
			return Vector3.zero;
		}

		protected Vector3 GetRerollTile()
		{
			Vector3 frontDoor = GetFrontDoor(get_external_tile: true);
			int num = ((!(frontDoor.x > 0f)) ? 1 : (-1));
			return frontDoor + new Vector3(num * 3, 0f, 0f);
		}

		protected Vector3 GetNameplateTile()
		{
			Vector3 nameplateTile = Decorator.GetNameplateTile(GetFrontDoor());
			return new Vector3(nameplateTile.x, 0f, nameplateTile.z);
		}

		protected Vector3 GetPracticeTile()
		{
			Vector3 frontDoor = GetFrontDoor(get_external_tile: true);
			int num = ((!(frontDoor.x > 0f)) ? 1 : (-1));
			return frontDoor + new Vector3(num * 4, 0f, 0f);
		}

		protected void GetReservedTiles(List<Vector3> output)
		{
			output.Add(GetNameplateTile());
			output.Add(GetRerollTile());
			output.Add(GetPracticeTile());
		}

		protected List<Vector3> GetPostTiles(bool force_inside = false)
		{
			TileManager.InvalidateTileCache();
			List<Vector3> list = new List<Vector3>();
			if (!force_inside && !Preferences.Get<bool>(Pref.LettersSpawnInside) && RequireEntity<SLayout>(out var comp) && Require<CBounds>(comp, out CBounds comp2))
			{
				Vector3 frontDoor = GetFrontDoor(get_external_tile: true);
				Vector3 rerollTile = GetRerollTile();
				Vector3 practiceTile = GetPracticeTile();
				Vector3 nameplateTile = GetNameplateTile();
				float x = comp2.Bounds.min.x;
				float x2 = comp2.Bounds.max.x;
				for (float num = x; num < x2; num += 1f)
				{
					if (Math.Abs(num - frontDoor.x) > 0.1f && Math.Abs(num - (frontDoor.x + 1f)) > 0.1f)
					{
						Vector3 vector = new Vector3(num, 0f, frontDoor.z - 1f);
						if (!vector.IsSameTile(rerollTile) && !vector.IsSameTile(practiceTile) && !vector.IsSameTile(nameplateTile) && TileManager.GetOccupant(vector) == default(Entity))
						{
							list.Add(vector);
						}
						Vector3 vector2 = new Vector3(num, 0f, frontDoor.z);
						if (!vector2.IsSameTile(rerollTile) && !vector2.IsSameTile(practiceTile) && !vector2.IsSameTile(nameplateTile) && TileManager.GetOccupant(vector2) == default(Entity))
						{
							list.Add(vector2);
						}
					}
				}
				return list;
			}
			if (Players == default(EntityQuery))
			{
				Players = GetEntityQuery(typeof(CPlayer), typeof(CPosition));
			}
			Bounds bounds = Bounds;
			bounds.Encapsulate(bounds.min - new Vector3(0f, 0f, 2f));
			bounds.Expand(0.1f);
			GetPostTemp.Clear();
			using NativeArray<CPosition> nativeArray = Players.ToComponentDataArray<CPosition>(Allocator.Temp);
			foreach (CPosition item in nativeArray)
			{
				Vector3 vector3 = item.Position.Rounded();
				CLayoutRoomTile tile = TileManager.GetTile(vector3);
				if (!LayoutHelpers.IsInside(tile.Type))
				{
					continue;
				}
				foreach (LayoutPosition item2 in LayoutHelpers.AllNearbyRange2)
				{
					Vector3 vector4 = vector3 + (Vector3)item2;
					if (!GetPostTemp.Contains(vector4) && TileManager.GetTile(vector4).RoomID == tile.RoomID && bounds.Contains(vector4))
					{
						GetPostTemp.Add(vector4);
					}
				}
			}
			GetPostTemp.ShuffleInPlace();
			list.AddRange(GetPostTemp);
			GetPostTemp.Clear();
			foreach (CLayoutRoomTile tile2 in Tiles)
			{
				if (!GetPostTemp.Contains(tile2.Position) && !list.Contains(tile2.Position) && LayoutHelpers.IsInside(tile2.Type))
				{
					GetPostTemp.Add(tile2.Position);
				}
			}
			GetPostTemp.ShuffleInPlace();
			list.AddRange(GetPostTemp);
			return list;
		}

		protected bool GetComponentOfSingletonHolder<TComp, TSing>(out TComp result) where TComp : struct, IComponentData where TSing : IComponentData
		{
			result = default(TComp);
			if (!HasSingleton<TSing>())
			{
				return false;
			}
			return GetComponentOfHeld<TComp>(GetSingletonEntity<TSing>(), out result);
		}

		protected bool HasComponentOfHeld<T>(Entity ent) where T : struct, IComponentData
		{
			if (!HasComponent<CItemHolder>(ent))
			{
				return false;
			}
			CItemHolder component = GetComponent<CItemHolder>(ent);
			if (!HasComponent<T>(component))
			{
				return false;
			}
			return HasComponent<T>(component);
		}

		protected bool GetComponentOfHeld<T>(Entity ent, out T result) where T : struct, IComponentData
		{
			result = default(T);
			if (!HasComponent<CItemHolder>(ent))
			{
				return false;
			}
			CItemHolder component = GetComponent<CItemHolder>(ent);
			if (!HasComponent<T>(component))
			{
				return false;
			}
			result = GetComponent<T>(component);
			return true;
		}

		protected bool GetEntityOfSingletonHolder<TSing>(out Entity result) where TSing : IComponentData
		{
			result = default(Entity);
			if (!HasSingleton<TSing>())
			{
				return false;
			}
			return GetHeld(GetSingletonEntity<TSing>(), out result);
		}

		protected bool GetHeld(Entity ent, out Entity result)
		{
			result = default(Entity);
			if (!HasComponent<CItemHolder>(ent))
			{
				return false;
			}
			result = GetComponent<CItemHolder>(ent);
			return true;
		}

		protected Entity AddEntity<T>(T t) where T : struct, IComponentData
		{
			Entity entity = base.EntityManager.CreateEntity(typeof(T));
			base.EntityManager.SetComponentData(entity, t);
			return entity;
		}

		protected Entity GetEntity<T>() where T : struct, IComponentData
		{
			if (!Has<T>())
			{
				Set(new T());
			}
			return GetSingletonEntity<T>();
		}

		protected bool RequireEntity<T>(out Entity comp) where T : struct, IComponentData
		{
			comp = default(Entity);
			if (HasSingleton<T>())
			{
				comp = GetSingletonEntity<T>();
				return true;
			}
			return false;
		}

		protected bool Require<T>(out T comp) where T : struct, IComponentData
		{
			comp = default(T);
			if (HasSingleton<T>())
			{
				comp = GetSingleton<T>();
				return true;
			}
			return false;
		}

		protected T GetOrCreate<T>() where T : struct, IComponentData
		{
			if (Require<T>(out var comp))
			{
				return comp;
			}
			Set(new T());
			return new T();
		}

		protected T GetOrDefault<T>() where T : struct, IComponentData
		{
			if (Require<T>(out var comp))
			{
				return comp;
			}
			return new T();
		}

		protected T GetOrDefault<T>(Entity e) where T : struct, IComponentData
		{
			if (Require<T>(e, out T comp))
			{
				return comp;
			}
			return new T();
		}

		protected Entity New<T>(T val) where T : struct, IComponentData
		{
			Entity entity = base.EntityManager.CreateEntity(typeof(T));
			base.EntityManager.AddComponentData(entity, val);
			return entity;
		}

		protected bool Has<T>() where T : struct, IComponentData
		{
			return HasSingleton<T>();
		}

		protected bool Has<T>(Entity e) where T : struct, IComponentData
		{
			return HasComponent<T>(e);
		}

		protected bool HasBuffer<T>(Entity e) where T : struct, IBufferElementData
		{
			return base.EntityManager.HasComponent<T>(e);
		}

		protected Entity Set<T>() where T : struct, IComponentData
		{
			if (!TryGetSingletonEntity<T>(out var value))
			{
				Entity entity = base.EntityManager.CreateEntity();
				base.EntityManager.AddComponent<T>(entity);
				return entity;
			}
			return value;
		}

		protected void Set<T>(Entity e) where T : struct, IComponentData
		{
			if (!Has<T>(e))
			{
				base.EntityManager.AddComponent<T>(e);
			}
		}

		protected void Unset<T>(Entity e) where T : struct, IComponentData
		{
			if (Has<T>(e))
			{
				base.EntityManager.RemoveComponent<T>(e);
			}
		}

		protected Entity Set<T>(T t) where T : struct, IComponentData
		{
			if (!TryGetSingletonEntity<T>(out var value))
			{
				Entity entity = base.EntityManager.CreateEntity();
				base.EntityManager.AddComponentData(entity, t);
				return entity;
			}
			base.EntityManager.SetComponentData(value, t);
			return value;
		}

		protected void Set<T>(Entity e, T t) where T : struct, IComponentData
		{
			if (!Has<T>(e))
			{
				base.EntityManager.AddComponentData(e, t);
			}
			else
			{
				base.EntityManager.SetComponentData(e, t);
			}
		}

		protected void Clear<T>() where T : struct, IComponentData
		{
			if (TryGetSingletonEntity<T>(out var value))
			{
				base.EntityManager.DestroyEntity(value);
			}
		}

		protected bool Require<T>(Entity e, out T comp) where T : struct, IComponentData
		{
			comp = default(T);
			if (HasComponent<T>(e))
			{
				bool isZeroSized = TypeManager.GetTypeInfo(TypeManager.GetTypeIndex<T>()).IsZeroSized;
				comp = (isZeroSized ? new T() : GetComponent<T>(e));
				return true;
			}
			return false;
		}

		protected bool Require<T>(Entity e, out DynamicBuffer<T> comp) where T : struct, IBufferElementData
		{
			return RequireBuffer(e, out comp);
		}

		protected bool RequireBuffer<T>(Entity e, out DynamicBuffer<T> comp) where T : struct, IBufferElementData
		{
			comp = default(DynamicBuffer<T>);
			if (base.EntityManager.HasComponent<T>(e))
			{
				comp = GetBuffer<T>(e);
				return true;
			}
			return false;
		}

		protected virtual void Initialise()
		{
		}

		protected EntityCommandBuffer GetCommandBuffer(ECB ecb)
		{
			return BufferSystem.GetCommandBuffer(ecb);
		}

		protected sealed override void OnCreate()
		{
			_BufferSystem = base.World.GetOrCreateSystem<BufferContainerSystem>();
			Initialise();
		}

		public virtual void PostInitialisation()
		{
			CreateDataEntity();
		}

		protected virtual void CreateDataEntity()
		{
			DataEntity = base.EntityManager.CreateEntity(typeof(CSystemDataMarker));
		}

		protected virtual T GetData<T>() where T : struct, IComponentData
		{
			return base.EntityManager.GetComponentData<T>(DataEntity);
		}

		public virtual void BeforeLoading(SaveSystemType system_type)
		{
		}

		public virtual void AfterLoading(SaveSystemType system_type)
		{
		}

		public virtual void BeforeSaving(SaveSystemType system_type)
		{
		}

		public virtual void AfterSaving(SaveSystemType system_type)
		{
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			base.EntityManager.DestroyEntity(DataEntity);
		}

		protected void StartSceneTransition(SceneType next)
		{
			if (!HasSingleton<SPerformSceneTransition>())
			{
				Entity entity = base.EntityManager.CreateEntity(typeof(SPerformSceneTransition), typeof(CDoNotPersist));
				base.EntityManager.AddComponentData(entity, new SPerformSceneTransition
				{
					NextScene = next
				});
			}
		}

		protected void MarkTransitionStageCompleted()
		{
			if (!HasSingleton<SPerformSceneTransition>())
			{
				Debug.LogWarning("Transitioning with no transition marker, reverting to franchise mode");
				base.EntityManager.CreateEntity(typeof(SPerformSceneTransition));
				_SingletonEntityQuery_SPerformSceneTransition_12.SetSingleton(new SPerformSceneTransition
				{
					NextScene = SceneType.Franchise
				});
			}
			else
			{
				SPerformSceneTransition singleton = _SingletonEntityQuery_SPerformSceneTransition_13.GetSingleton<SPerformSceneTransition>();
				singleton.StageComplete = true;
				_SingletonEntityQuery_SPerformSceneTransition_12.SetSingleton(singleton);
			}
		}

		public EntityQuery GetQuery(QueryHelper helper)
		{
			return GetEntityQuery(helper);
		}

		[Obsolete("Use TileManager.ClearOccupants instead")]
		protected void ClearOccupants()
		{
			TileManager.ClearOccupants();
		}

		[Obsolete("Use TileManager.SetOccupant instead")]
		protected void SetOccupant(Vector3 position, Entity e, OccupancyLayer layer = OccupancyLayer.Default)
		{
			TileManager.SetOccupant(position, e, layer);
		}

		[Obsolete("Use TileManager.GetOccupant instead")]
		protected Entity GetOccupant(Vector3 position, OccupancyLayer layer = OccupancyLayer.Default)
		{
			return TileManager.GetOccupant(position, layer);
		}

		[Obsolete("Use TileManager.GetPrimaryOccupant instead")]
		protected Entity GetPrimaryOccupant(Vector3 position)
		{
			return TileManager.GetPrimaryOccupant(position);
		}

		[Obsolete("Use TileManager.GetRoom instead")]
		protected int GetRoom(Vector3 position)
		{
			return TileManager.GetRoom(position);
		}

		[Obsolete("Use TileManager.GetTile instead")]
		protected CLayoutRoomTile GetTile(Vector3 position)
		{
			return TileManager.GetTile(position);
		}

		[Obsolete("Use TileManager.CanReach instead")]
		protected bool CanReach(Vector3 from, Vector3 to, bool do_not_swap = false)
		{
			return TileManager.CanReach(from, to, do_not_swap);
		}

		[Obsolete("Use TileManager.GetRoadMarker instead")]
		protected Vector3 GetRoadMarker()
		{
			return TileManager.GetRoadMarker();
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
			_SingletonEntityQuery_SAssetDirectory_9 = GetEntityQuery(ComponentType.ReadOnly<SAssetDirectory>());
			_SingletonEntityQuery_SGameTime_10 = GetEntityQuery(ComponentType.ReadOnly<SGameTime>());
			_SingletonEntityQuery_SLayout_11 = GetEntityQuery(ComponentType.ReadOnly<SLayout>());
			_SingletonEntityQuery_SPerformSceneTransition_12 = GetEntityQuery(ComponentType.ReadWrite<SPerformSceneTransition>());
			_SingletonEntityQuery_SPerformSceneTransition_13 = GetEntityQuery(ComponentType.ReadOnly<SPerformSceneTransition>());
		}
	}
}
