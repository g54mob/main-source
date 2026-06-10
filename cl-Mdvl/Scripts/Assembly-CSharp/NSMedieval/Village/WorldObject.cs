using System;
using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSEipix.Model;
using NSMedieval.BuildingComponents;
using NSMedieval.Construction;
using NSMedieval.Controllers;
using NSMedieval.Enums;
using NSMedieval.Goap;
using NSMedieval.Manager;
using NSMedieval.Map;
using NSMedieval.RoomDetection;
using NSMedieval.Serialization;
using NSMedieval.State;
using NSMedieval.Types;
using NSMedieval.Utils.Pool;
using NSMedieval.Utils.Pool.Janitors;
using NSMedieval.View;
using NSMedieval.Village.Map;
using NSMedieval.Village.Map.Pathfinding;
using UnityEngine;

namespace NSMedieval.Village
{
	[Serializable]
	[FVSerializableKey("WorldObject", "")]
	public abstract class WorldObject : IGoapTargetable, IGameDisposable, IDisposable, IReservable, IGridPositionProvider, ILightReceiver, IFVSerializable
	{
		[SerializeField]
		protected string blueprintId;

		[SerializeField]
		private Vec3Int gridDataPosition;

		[SerializeField]
		private Vec3Int size;

		[SerializeField]
		private ReachabilityInfo reachabilityInfo;

		[SerializeField]
		private float angle;

		[SerializeField]
		private WorldObjectType type;

		[SerializeField]
		private GridDataType gridDataDataType;

		[NonSerialized]
		private Vector3 worldPosition;

		[NonSerialized]
		private readonly ConcurrentHashSet<Vec3Int> reachablePositions;

		[SerializeField]
		private int uniqueId;

		[SerializeField]
		private FactionOwnership factionOwnership;

		private Vector3 centralPosition;

		public bool IsReachabilityUpdateInProgress { get; private set; }

		public int UniqueId
		{
			get
			{
				if (uniqueId == 0)
				{
					uniqueId = MonoSingleton<UniqueIdManager>.Instance.GetUniqueId(UniqueIdType.WorldObject);
				}
				return uniqueId;
			}
		}

		public string BlueprintId => blueprintId;

		public FactionOwnership FactionOwnership => factionOwnership;

		public bool HasDisposed { get; protected set; }

		internal virtual ThermalModel ThermalModel => null;

		public WorldObjectType Type => type;

		public GridDataType GridDataType
		{
			get
			{
				if (gridDataDataType != GridDataType.None)
				{
					return gridDataDataType;
				}
				gridDataDataType = WorldObjectTemporaryDataTypeSwitcher.GetWorldObjectDataType(this);
				return gridDataDataType;
			}
			protected set
			{
				GridDataType gridDataType = gridDataDataType;
				if (gridDataType != value)
				{
					gridDataDataType = value;
					Map.OnWorldObjectDataTypeChanged(this, gridDataType);
				}
			}
		}

		public Vec3Int Size => size;

		public float Angle
		{
			get
			{
				return angle;
			}
			protected set
			{
				if (!Mathf.Approximately(angle, value))
				{
					angle = value;
					CalculateReachabilityOptimizedCall();
				}
			}
		}

		public virtual ConcurrentHashSet<Vec3Int> ReachablePositions => reachablePositions;

		public virtual ushort PathfindingPenalty => 1000;

		public virtual float WalkSpeedMultiplier => 1f;

		public Vec3Int GridDataPosition => gridDataPosition;

		public Vector3 WorldPosition => worldPosition;

		public VillageInstance Village => VillageManager.ActiveVillage;

		public VillageMap Map => Village?.Map;

		public abstract List<Vec3Int> Positions { get; }

		protected ReachabilityInfo ReachabilityInfo => reachabilityInfo;

		public virtual float Flammability { get; }

		public virtual bool IsOnFire
		{
			get
			{
				if (!HasDisposed)
				{
					return Map.FireSimLogic.GetFireData(GetNode().Index) > 0f;
				}
				return false;
			}
		}

		public abstract bool BlueprintExists { get; }

		public event Func<List<Vec3Int>> GetReachablePointsEvent;

		public event Action<FactionOwnership> FactionChangedEvent;

		public event Action<IGameDisposable> OnDisposedEvent;

		public event Action<IReservable, IGoapAgentOwner> OnReservedEvent;

		public event Action<IReservable, IGoapAgentOwner> OnReleasedEvent;

		public void AddReachablePosition(Vec3Int position)
		{
			reachablePositions.Add(position);
		}

		protected WorldObject(WorldObjectType type, Vector3 worldPosition, Vec3Int size, float angle = 0f, GridDataType dataType = GridDataType.None, FactionOwnership factionOwnership = FactionOwnership.Player)
		{
			this.type = type;
			gridDataDataType = dataType;
			this.size = size;
			this.angle = angle;
			reachablePositions = new ConcurrentHashSet<Vec3Int>();
			this.factionOwnership = factionOwnership;
			SetupWorldObject(worldPosition);
		}

		protected WorldObject(Vector3 worldPosition)
		{
			reachablePositions = new ConcurrentHashSet<Vec3Int>();
			gridDataPosition = worldPosition.ToGridVec3Int();
			this.worldPosition = worldPosition;
			reachablePositions.Add(gridDataPosition);
			type = WorldObjectType.PathfindingPoint;
		}

		protected WorldObject()
		{
		}

		public virtual int GetMaxReservers()
		{
			return 1;
		}

		public virtual Vector3 GetPosition()
		{
			return WorldPosition;
		}

		public virtual Vec3Int GetGridPosition()
		{
			return GridDataPosition;
		}

		public Vector3 GetCentralPosition()
		{
			if (centralPosition != default(Vector3))
			{
				return centralPosition;
			}
			bool isEnabled;
			FVLogDebugInterpolationHandler messageBuilder;
			if (Positions == null || Positions.Count == 0)
			{
				centralPosition = WorldPosition;
				messageBuilder = new FVLogDebugInterpolationHandler(10, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Village\\WorldObject.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Center: (");
					messageBuilder.AppendFormatted(centralPosition);
					messageBuilder.AppendLiteral(")");
				}
				Log.Debug(messageBuilder);
				return centralPosition;
			}
			HashSet<float> hashSet = new HashSet<float>();
			HashSet<float> hashSet2 = new HashSet<float>();
			foreach (Vec3Int position in Positions)
			{
				hashSet.Add(position.x);
				hashSet2.Add(position.z);
			}
			centralPosition = new Vector3(hashSet.Average(), GridUtils.GetWorldPosition(Positions.First()).y, hashSet2.Average());
			messageBuilder = new FVLogDebugInterpolationHandler(10, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Village\\WorldObject.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Center: (");
				messageBuilder.AppendFormatted(centralPosition);
				messageBuilder.AppendLiteral(")");
			}
			Log.Debug(messageBuilder);
			return centralPosition;
		}

		public virtual bool DestroyByFire()
		{
			return true;
		}

		public virtual SelectableObject GetView()
		{
			return null;
		}

		public MapNode GetNode()
		{
			return Map?.GetNode(GridDataPosition);
		}

		public void SetFaction(FactionOwnership newFactionOwnership)
		{
			if (factionOwnership != newFactionOwnership)
			{
				FactionOwnership oldFaction = factionOwnership;
				factionOwnership = newFactionOwnership;
				this.FactionChangedEvent?.Invoke(factionOwnership);
				MonoSingleton<ConstructionController>.Instance.FactionOwnershipChanged(oldFaction, factionOwnership, this);
			}
		}

		public bool OwnedByPlayer()
		{
			return factionOwnership == FactionOwnership.Player;
		}

		public IEnumerable<MapNode> Nodes()
		{
			if (Positions == null || Positions.Count == 0)
			{
				MapNode node = Map.GetNode(GridDataPosition);
				if (node != null)
				{
					yield return node;
				}
			}
			List<Vec3Int> positions = Positions;
			if (positions == null)
			{
				yield break;
			}
			foreach (Vec3Int item in positions)
			{
				MapNode node2 = Map.GetNode(item);
				if (node2 != null)
				{
					yield return node2;
				}
			}
		}

		public virtual void ReInstantiate()
		{
			if (Village.SavedObjectsSpawned)
			{
				CalculateReachabilityOptimizedCall();
			}
			worldPosition = GridUtils.GetWorldPosition(GridDataPosition);
		}

		public Room GetRoom()
		{
			if (Map == null || Map.HasDisposed)
			{
				return null;
			}
			return Map.RoomDetection.GetRoom(gridDataPosition);
		}

		public virtual void SetupWorldObject(Vector3 worldPosition)
		{
			gridDataPosition = worldPosition.ToGridVec3Int();
			this.worldPosition = worldPosition;
			CalculateReachabilityOptimizedCall();
		}

		public void SetReachability(ReachabilityInfo info)
		{
			reachabilityInfo = info;
			reachablePositions?.Clear();
			if (Village.SavedObjectsSpawned)
			{
				CalculateReachability();
			}
		}

		public virtual void Dispose()
		{
			if (!HasDisposed)
			{
				if (!LoadingController.IsLeavingMainScene)
				{
					RemoveFromRegions();
				}
				IsReachabilityUpdateInProgress = false;
				reachablePositions.Clear();
				this.GetReachablePointsEvent = null;
				HasDisposed = true;
				if (!LoadingController.IsLeavingMainScene)
				{
					this.OnDisposedEvent?.Invoke(this);
				}
				this.OnDisposedEvent = null;
				this.OnReleasedEvent = null;
				this.OnReservedEvent = null;
				this.FactionChangedEvent = null;
				MonoSingleton<UniqueIdManager>.Instance.ReleaseUniqueId(UniqueIdType.WorldObject, uniqueId);
			}
		}

		public virtual void OnReservationChanged(bool isReserved, IGoapAgentOwner agent)
		{
			if (isReserved)
			{
				this.OnReservedEvent?.Invoke(this, agent);
			}
			else
			{
				this.OnReleasedEvent?.Invoke(this, agent);
			}
		}

		public void ShowVisualDebuggingAid()
		{
			Color color = Color.magenta;
			string tag = WorldPosition.ToString();
			foreach (Vec3Int reachablePosition in ReachablePositions)
			{
				MonoSingleton<VisualDebugManager>.Instance.DrawSphere(VisualDebugType.Reachability, tag, reachablePosition.ToVector3World(), 0.35f, color);
				color = Color.white;
			}
			Vec3Int vec3Int = new Vec3Int(Size.x, 0, Size.z);
			float num = angle;
			if (this is BaseBuildingInstance { BuildingType: BuildingType.Roof })
			{
				if (Mathf.Approximately(num, 270f))
				{
					num = 0f;
				}
				else if (Mathf.Approximately(num, 90f))
				{
					num = 180f;
				}
			}
			Bounds boundsCornerStart = Singleton<GridTools>.Instance.GetBoundsCornerStart(WorldPosition, vec3Int, num, 1);
			Vector3 min = boundsCornerStart.min;
			Vector3 max = boundsCornerStart.max;
			min.y -= 0.25f;
			max.y -= 0.25f;
			MonoSingleton<VisualDebugManager>.Instance.DrawRect(VisualDebugType.Reachability, tag, min, max, Color.blue);
		}

		public Vec3Int GetPointReachableByWorker(HumanoidInstance humanoid = null)
		{
			if (HasDisposed || ReachablePositions == null || ReachablePositions.Count <= 0)
			{
				return Vec3Int.zero;
			}
			if (humanoid != null)
			{
				return ReachablePositions.FirstOrDefault((Vec3Int item) => PathfinderUtil.IsPathPossible(humanoid, item));
			}
			foreach (HumanoidInstance worker in GlobalSaveController.CurrentVillageData.Workers)
			{
				foreach (Vec3Int reachablePosition in ReachablePositions)
				{
					if (PathfinderUtil.IsPathPossible(worker, reachablePosition))
					{
						return reachablePosition;
					}
				}
			}
			return Vec3Int.zero;
		}

		public void HideVisualDebuggingAid()
		{
			if (!MonoSingleton<VisualDebugManager>.IsInstantiated() || VisualDebugManager.IsEnabled)
			{
				MonoSingleton<VisualDebugManager>.Instance.HideForTag(WorldPosition.ToString());
			}
		}

		public Vec3Int GetFirstReachablePosition(IPathfindingAgent agent)
		{
			if (ReachablePositions == null || ReachablePositions.Count == 0)
			{
				if (PathfinderUtil.IsPathPossible(agent, GridDataPosition))
				{
					return GridDataPosition;
				}
				return Vec3Int.zero;
			}
			foreach (Vec3Int reachablePosition in ReachablePositions)
			{
				if (PathfinderUtil.IsPathPossible(agent, reachablePosition))
				{
					return reachablePosition;
				}
			}
			return Vec3Int.zero;
		}

		public virtual float GetBeautyInput()
		{
			return 0f;
		}

		public virtual bool BeautyBlocker()
		{
			return false;
		}

		public float GetReceivingLightAmount()
		{
			return Map.TemperatureManager.GetLightIntensity(gridDataPosition);
		}

		public float GetSunlightLossMultiplier()
		{
			float receivingLightAmount = GetReceivingLightAmount();
			return Mathf.Lerp(1f, -4f, receivingLightAmount);
		}

		protected void SetReachabilityInfo(ReachabilityInfo reachabilityInfo)
		{
			this.reachabilityInfo = reachabilityInfo;
		}

		public void SetObjectSize(Vec3Int size)
		{
			if (this.size.x != size.x || this.size.z != size.z)
			{
				this.size = size;
				CalculateReachabilityOptimizedCall();
			}
		}

		protected virtual List<Vec3Int> GatherReachabilityNodePositions()
		{
			if (size.x == 1 && size.z == 1)
			{
				return new List<Vec3Int> { GridDataPosition };
			}
			return Singleton<GridTools>.Instance.GetPositions(GridDataPosition, size, angle);
		}

		public virtual void ReCalculateReachability()
		{
			CalculateReachabilityOptimizedCall();
		}

		protected void CalculateReachabilityOptimizedCall(Func<MapNode, bool> additionalCheck = null)
		{
			IsReachabilityUpdateInProgress = true;
			MonoSingleton<TaskController>.Instance.OptimizedCall(this, "CalculateReachability", delegate
			{
				CalculateReachability(additionalCheck);
			});
		}

		protected virtual void CalculateReachability(Func<MapNode, bool> additionalCheck = null)
		{
			if (reachabilityInfo == null)
			{
				reachabilityInfo = new ReachabilityInfo(new IntRange(0, 0));
			}
			RemoveFromRegions();
			reachablePositions.Clear();
			if ((GridDataPosition.x == 0 && GridDataPosition.y == 0) || (size.x == 0 && size.z == 0))
			{
				return;
			}
			List<Vec3Int> positions = this.GetReachablePointsEvent?.Invoke();
			if (positions == null || positions.Count == 0)
			{
				positions = GatherReachabilityNodePositions();
			}
			if (positions == null || positions.Count == 0)
			{
				IsReachabilityUpdateInProgress = false;
				return;
			}
			foreach (Vec3Int item in positions)
			{
				ReachabilityUtil.GatherReachablePositions(item, reachabilityInfo, reachablePositions, additionalCheck);
			}
			if (positions.Count <= 1 || reachablePositions.Count < 2)
			{
				RegisterInRegions();
				IsReachabilityUpdateInProgress = false;
				return;
			}
			reachabilityInfo.ForEachYAccess(delegate(int yPos, WorldDirection direction)
			{
				if ((direction & WorldDirection.C) != WorldDirection.None)
				{
					return;
				}
				foreach (Vec3Int item2 in positions)
				{
					Vec3Int position = item2;
					reachablePositions.RemoveWhere((Vec3Int item) => Vec3Int.Distance(in item, in position) <= 0.45f);
				}
			});
			RegisterInRegions();
			IsReachabilityUpdateInProgress = false;
		}

		protected void RegisterInRegions()
		{
			using PooledHashSet<int> pooledHashSet = HashSetPool<int>.GetJanitor();
			Region region = GetNode()?.Region;
			if (region != null)
			{
				region.ScheduleRegisterReachableObject(this);
				pooledHashSet.Add(region.UniqueId);
			}
			if (reachablePositions == null || reachablePositions.Count == 0)
			{
				return;
			}
			foreach (Vec3Int reachablePosition in reachablePositions)
			{
				region = Map.GetNode(reachablePosition)?.Region;
				if (region != null && pooledHashSet.Add(region.UniqueId))
				{
					region.ScheduleRegisterReachableObject(this);
				}
			}
		}

		protected void RemoveFromRegions()
		{
			using PooledHashSet<int> pooledHashSet = HashSetPool<int>.GetJanitor();
			Region region = GetNode()?.Region;
			if (region != null)
			{
				region.ScheduleRemoveReachableObject(this);
				pooledHashSet.Add(region.UniqueId);
			}
			if (reachablePositions == null || reachablePositions.Count == 0)
			{
				return;
			}
			foreach (Vec3Int reachablePosition in reachablePositions)
			{
				region = Map.GetNode(reachablePosition)?.Region;
				if (region != null && pooledHashSet.Add(region.UniqueId))
				{
					region.ScheduleRemoveReachableObject(this);
				}
			}
		}

		public void UpdateReachability()
		{
			ReCalculateReachability();
		}

		public int GetUniqueId()
		{
			return uniqueId;
		}

		public virtual void Serialize(FVSerializer serializer)
		{
			serializer.Write("blueprintId", blueprintId);
			serializer.Write("gridDataPosition", gridDataPosition);
			serializer.Write("size", size);
			serializer.Write("reachabilityInfo", reachabilityInfo);
			serializer.Write("angle", angle);
			serializer.WriteEnum("type", type);
			serializer.WriteEnum("gridDataDataType", gridDataDataType);
			serializer.Write("uniqueId", uniqueId);
			serializer.WriteEnum("factionOwnership", factionOwnership);
			serializer.Write("hasDisposed", HasDisposed);
		}

		public WorldObject(FVDeserializer deserializer)
		{
			reachablePositions = new ConcurrentHashSet<Vec3Int>();
			blueprintId = deserializer.ReadString("blueprintId");
			gridDataPosition = deserializer.ReadVec3Int("gridDataPosition");
			size = deserializer.ReadVec3Int("size");
			reachabilityInfo = deserializer.ReadObject<ReachabilityInfo>("reachabilityInfo");
			angle = deserializer.ReadFloat("angle");
			type = deserializer.ReadEnum("type", WorldObjectType.None);
			gridDataDataType = deserializer.ReadEnum("gridDataDataType", GridDataType.None);
			uniqueId = deserializer.ReadInt("uniqueId");
			factionOwnership = deserializer.ReadEnum("factionOwnership", FactionOwnership.Player);
			if (size == Vec3Int.zero)
			{
				SerializableVector2Int serializableVector2Int = deserializer.ReadVec2Int("objectSize");
				size = new Vec3Int(serializableVector2Int.x, 1, serializableVector2Int.y);
			}
			HasDisposed = deserializer.ReadBool("hasDisposed");
		}
	}
}
