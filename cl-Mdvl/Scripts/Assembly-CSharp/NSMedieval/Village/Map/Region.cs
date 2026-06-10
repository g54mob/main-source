using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSEipix.Model;
using NSMedieval.BuildingComponents;
using NSMedieval.Controllers;
using NSMedieval.Goap;
using NSMedieval.Map;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.State;
using NSMedieval.Types;
using NSMedieval.Utils.Pool;
using NSMedieval.Water;
using UnityEngine;

namespace NSMedieval.Village.Map
{
	public class Region : IGameDisposable, IDisposable
	{
		private enum MutationType
		{
			Add = 0,
			Remove = 1
		}

		private class RegionObjectsMutation
		{
			public MutationType Type;

			public WorldObject WorldObject;

			public RegionObjectsMutation(MutationType type, WorldObject worldObject)
			{
				Type = type;
				WorldObject = worldObject;
			}
		}

		private readonly int uniqueId;

		private readonly List<MapNode> nodes = new List<MapNode>();

		private readonly HashSet<Region> connections = new HashSet<Region>();

		private GridDataType gridDataType;

		private uint area;

		private bool isInitialized;

		private RegionAttribute attribute;

		private readonly Dictionary<RegionAttribute, ushort> attributeValues = new Dictionary<RegionAttribute, ushort>();

		private ushort[] penaltiesCalculated;

		private ShortRange yRange = new ShortRange(short.MaxValue, short.MinValue);

		private VillageMap map;

		private bool hasBridgeConnections;

		private bool boundsChanged;

		private Vector3 boundsCenter;

		private Vector3 boundsSize;

		private readonly HashSet<WorldObject> reachableObjectsRaw = new HashSet<WorldObject>();

		private readonly HashSet<WorldObject> reachableBuildingsRaw = new HashSet<WorldObject>();

		private readonly ConcurrentQueue<RegionObjectsMutation> reachableObjectScheduledMutations = new ConcurrentQueue<RegionObjectsMutation>();

		private int reachableObjectsReadersCount;

		public Vector3 BoundsCenter
		{
			get
			{
				if (boundsChanged)
				{
					boundsChanged = false;
					CalculateBoundsCenterAndSize();
				}
				return boundsCenter;
			}
		}

		public Vector3 BoundsSize
		{
			get
			{
				if (boundsChanged)
				{
					boundsChanged = false;
					CalculateBoundsCenterAndSize();
				}
				return boundsSize;
			}
		}

		public int UniqueId => uniqueId;

		public List<MapNode> Nodes => nodes;

		public HashSet<Region> Connections => connections;

		public bool HasDisposed { get; private set; }

		public float TotalBuildingWealth { get; private set; }

		public ShortRange YRange => yRange;

		public GridDataType GridDataType => gridDataType;

		public bool IsEmpty => Nodes.Count == 0;

		public bool IsInitialized => isInitialized;

		public RegionAttribute Attribute => attribute;

		public ushort[] PenaltiesCalculated => penaltiesCalculated;

		public bool HasBridgeConnections => hasBridgeConnections;

		public uint Area
		{
			get
			{
				return area;
			}
			set
			{
				area = value;
			}
		}

		public virtual bool IsBridge => false;

		public VillageMap Map => map;

		public IEnumerable<WorldObject> ReachableObjects
		{
			get
			{
				BlockIfDirtyAndNotMainThread();
				if (HasDisposed)
				{
					yield break;
				}
				try
				{
					Interlocked.Increment(ref reachableObjectsReadersCount);
					foreach (WorldObject item in reachableObjectsRaw)
					{
						yield return item;
					}
				}
				finally
				{
					Interlocked.Decrement(ref reachableObjectsReadersCount);
				}
			}
		}

		public IEnumerable<WorldObject> ReachableBuildings
		{
			get
			{
				BlockIfDirtyAndNotMainThread();
				if (HasDisposed)
				{
					yield break;
				}
				try
				{
					Interlocked.Increment(ref reachableObjectsReadersCount);
					foreach (WorldObject item in reachableBuildingsRaw)
					{
						yield return item;
					}
				}
				finally
				{
					Interlocked.Decrement(ref reachableObjectsReadersCount);
				}
			}
		}

		public bool HasPenMarker
		{
			get
			{
				foreach (MapNode node in nodes)
				{
					if (node != null && (node.Tag & MapNodeTags.PenMarker) != MapNodeTags.None)
					{
						return true;
					}
				}
				return false;
			}
		}

		public bool HasMapEdgeNodes { get; private set; }

		public int NonRoofedNodesCount { get; private set; }

		public bool IsDirty { get; set; }

		public bool IsReachableBeingProcessed => reachableObjectsReadersCount > 0;

		public bool IsWater
		{
			get
			{
				if (nodes.Count != 0)
				{
					return nodes[0].IsWater;
				}
				return false;
			}
		}

		public bool IsFire
		{
			get
			{
				if (nodes.Count != 0)
				{
					return nodes[0].IsFire;
				}
				return false;
			}
		}

		public WaterDepthLevel WaterDepthLevel
		{
			get
			{
				if (nodes.Count != 0)
				{
					return nodes[0].WaterDepthLevel;
				}
				return WaterDepthLevel.None;
			}
		}

		public event Action<IGameDisposable> OnDisposedEvent;

		public Region(int uniqueId, VillageMap map)
		{
			this.uniqueId = uniqueId;
			this.map = map;
			boundsChanged = true;
		}

		public virtual void Dispose()
		{
			if (HasDisposed)
			{
				return;
			}
			if (!LoadingController.IsSceneTransition)
			{
				foreach (MapNode node in nodes)
				{
					node.SetRegion(null, silent: true);
				}
				RemoveAllConnections();
			}
			HasDisposed = true;
			if (!LoadingController.IsLeavingMainScene)
			{
				this.OnDisposedEvent?.Invoke(this);
			}
			this.OnDisposedEvent = null;
			map = null;
			nodes.Clear();
			connections.Clear();
			reachableObjectsRaw.Clear();
			reachableBuildingsRaw.Clear();
			reachableObjectScheduledMutations.Clear();
			IsDirty = false;
			TotalBuildingWealth = 0f;
		}

		public override string ToString()
		{
			return $"Region ({UniqueId}), TotalBuildingWealth: {TotalBuildingWealth}";
		}

		public void SetAttributeValue(RegionAttribute attribute, ushort value)
		{
			if (value == 0)
			{
				this.attribute &= ~attribute;
				if (attributeValues.ContainsKey(attribute))
				{
					attributeValues[attribute] = 0;
				}
				UpdatePenalties();
				return;
			}
			this.attribute |= attribute;
			if (!attributeValues.ContainsKey(attribute))
			{
				attributeValues.Add(attribute, value);
				UpdatePenalties();
			}
			if (attributeValues[attribute] != value)
			{
				attributeValues[attribute] = value;
				UpdatePenalties();
			}
		}

		public ushort GetAttributeValue(RegionAttribute attribute)
		{
			if ((this.attribute & attribute) == 0)
			{
				return 0;
			}
			return attributeValues[attribute];
		}

		public virtual void Initialize(bool initialGeneration)
		{
			if (nodes.Count == 0)
			{
				Log.Error("Region with 0 nodes have been spotted. This is a problem...", "C:\\GIT\\dev\\Assets\\Scripts\\Village\\Map\\Region\\Region.cs");
			}
			RefreshNeighbourConnections();
			isInitialized = true;
			if (initialGeneration)
			{
				return;
			}
			MonoSingleton<TaskController>.Instance.WaitForNextFrame().Then(delegate
			{
				if (!HasDisposed)
				{
					ScanForReachableObjects();
				}
			});
		}

		public virtual void AddNode(MapNode node)
		{
			if (node.Region != null && node.Region != this)
			{
				Log.Error("Tried adding node to region, but node was already in region " + node.Region.UniqueId, "C:\\GIT\\dev\\Assets\\Scripts\\Village\\Map\\Region\\Region.cs");
				return;
			}
			if (node.Position.y < yRange.Min)
			{
				yRange.Min = (short)node.Position.y;
			}
			if (node.Position.y > yRange.Max)
			{
				yRange.Max = (short)node.Position.y;
			}
			if (!HasMapEdgeNodes)
			{
				HasMapEdgeNodes = node.IsEdge();
			}
			if (node.Coverage != CoverageType.Roofed)
			{
				AddToUnroofedCount(node, 1);
			}
			node.SetRegion(this);
			nodes.Add(node);
			boundsChanged = true;
			GetArea()?.NodeAdded();
			Map.NodeAddedToRegion(this, node);
		}

		public virtual void RemoveNode(MapNode node)
		{
			if (node.Region != this)
			{
				return;
			}
			GetArea()?.NodeRemoved();
			nodes.Remove(node);
			node.SetRegion(null);
			if (yRange.Min != yRange.Max && (node.Position.y == yRange.Max || node.Position.y == yRange.Min))
			{
				foreach (MapNode node2 in nodes)
				{
					if (node2.Position.y < yRange.Min)
					{
						yRange.Min = (short)node2.Position.y;
					}
					if (node2.Position.y > yRange.Max)
					{
						yRange.Max = (short)node2.Position.y;
					}
				}
			}
			if (node.Coverage != CoverageType.Roofed)
			{
				AddToUnroofedCount(node, -1);
			}
			HasMapEdgeNodes = nodes.Any((MapNode mapNode) => mapNode.IsEdge());
			Map.NodeRemovedFromRegion(this, node);
			boundsChanged = true;
		}

		public virtual bool RefreshNeighbourConnections()
		{
			HashSet<Region> hashSet = RemoveGetAllConnections();
			foreach (MapNode node in nodes)
			{
				ScanForNeighbours(node);
			}
			bool flag = Connections.Count != hashSet.Count;
			if (!flag)
			{
				foreach (Region connection in Connections)
				{
					flag |= !hashSet.Contains(connection);
					if (flag)
					{
						break;
					}
				}
			}
			HashSetPool<Region>.Return(hashSet);
			return flag;
		}

		public void ApplyScheduledMutations()
		{
			RegionObjectsMutation result;
			while (reachableObjectScheduledMutations.TryDequeue(out result))
			{
				if (result?.WorldObject == null)
				{
					continue;
				}
				switch (result.Type)
				{
				case MutationType.Add:
					reachableObjectsRaw.Add(result.WorldObject);
					if (result.WorldObject.Type == WorldObjectType.Building && reachableBuildingsRaw.Add(result.WorldObject) && result.WorldObject is BaseBuildingInstance baseBuildingInstance2)
					{
						TotalBuildingWealth += baseBuildingInstance2.GetWealth();
					}
					gridDataType |= result.WorldObject.GridDataType;
					break;
				case MutationType.Remove:
					reachableObjectsRaw.Remove(result.WorldObject);
					if (result.WorldObject.Type == WorldObjectType.Building && reachableBuildingsRaw.Remove(result.WorldObject) && result.WorldObject is BaseBuildingInstance baseBuildingInstance)
					{
						TotalBuildingWealth -= baseBuildingInstance.GetWealth();
					}
					RefreshGridDataTypeOptimized();
					break;
				}
			}
		}

		public void ScheduleRegisterReachableObject(WorldObject obj)
		{
			if (obj != null)
			{
				bool isEnabled;
				FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(45, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Village\\Map\\Region\\Region.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("ScheduleRegisterReachableObject region ");
					messageBuilder.AppendFormatted(UniqueId);
					messageBuilder.AppendLiteral(", obj ");
					messageBuilder.AppendFormatted(obj);
				}
				Log.Trace(messageBuilder);
				reachableObjectScheduledMutations.Enqueue(new RegionObjectsMutation(MutationType.Add, obj));
				map.RegionManager.MarkRegionAsDirty(this);
			}
		}

		public void ScheduleRemoveReachableObject(WorldObject obj)
		{
			if (obj != null)
			{
				bool isEnabled;
				FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(43, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Village\\Map\\Region\\Region.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("ScheduleRemoveReachableObject region ");
					messageBuilder.AppendFormatted(UniqueId);
					messageBuilder.AppendLiteral(", obj ");
					messageBuilder.AppendFormatted(obj);
				}
				Log.Trace(messageBuilder);
				reachableObjectScheduledMutations.Enqueue(new RegionObjectsMutation(MutationType.Remove, obj));
				map.RegionManager.MarkRegionAsDirty(this);
			}
		}

		public void RefreshGridDataTypeOptimized()
		{
			if (MonoSingleton<TaskController>.IsInstantiated())
			{
				MonoSingleton<TaskController>.Instance.OptimizedCall(this, "refreshGridDataType", RefreshGridDataType);
			}
		}

		public int GetHopsCount(Region region, int maxHops = -1)
		{
			if (Connections.Contains(region))
			{
				return 1;
			}
			if (maxHops == 1 || maxHops - 1 <= 0)
			{
				return -1;
			}
			foreach (Region connection in Connections)
			{
				int hopsCount = connection.GetHopsCount(region, maxHops - 1);
				if (hopsCount > 0)
				{
					return hopsCount + 1;
				}
			}
			return -1;
		}

		public void UpdatePenalties()
		{
			if (attribute == RegionAttribute.None)
			{
				return;
			}
			if (penaltiesCalculated == null)
			{
				penaltiesCalculated = new ushort[PathfindingPenaltyRepository.FastRepo.Count];
			}
			for (int num = 1; num < 8; num *= 2)
			{
				RegionAttribute regionAttribute = (RegionAttribute)num;
				if ((attribute & regionAttribute) != RegionAttribute.None)
				{
					ushort attributeValue = attributeValues[regionAttribute];
					for (int i = 0; i < PathfindingPenaltyRepository.FastRepo.Count; i++)
					{
						penaltiesCalculated[i] = PathfindingPenalty.GetPathfindingPenaltyForRegion(PathfindingPenaltyRepository.FastRepo[i], regionAttribute, attributeValue);
					}
				}
			}
		}

		public void CoverageChanged(MapNode node, CoverageType oldCoverage)
		{
			if (node.Coverage == CoverageType.Roofed)
			{
				AddToUnroofedCount(node, -1);
			}
			else
			{
				AddToUnroofedCount(node, 1);
			}
		}

		private void RefreshGridDataType()
		{
			if (HasDisposed || !MonoSingleton<VillageManager>.IsInstantiated())
			{
				return;
			}
			gridDataType = GridDataType.None;
			foreach (WorldObject item in reachableObjectsRaw)
			{
				gridDataType |= item.GridDataType;
			}
		}

		private void ScanForNeighbours(MapNode node, bool ignoreRamps = false)
		{
			foreach (MapNode item in node.ConnectionsSafe)
			{
				if (item == null)
				{
					throw new Exception("NULL connections! Should never happen 2 " + node.Position.ToString());
				}
				if (item.Region == null)
				{
					continue;
				}
				if (item.Region != this)
				{
					AddConnection(item.Region);
				}
				else if (!ignoreRamps && item.IsLayerRamp())
				{
					MapRampLogic.GetRampLowHighNodes(item.GetLayerRampObject(), out var lowestNode, out var highestNode);
					if (lowestNode != null)
					{
						ScanForNeighbours(lowestNode, ignoreRamps: true);
					}
					if (highestNode != null)
					{
						ScanForNeighbours(highestNode, ignoreRamps: true);
					}
				}
			}
		}

		private void AddConnection(Region connection)
		{
			if (connections.Add(connection))
			{
				connection.AddConnection(this);
				if (connection.IsBridge)
				{
					hasBridgeConnections = true;
				}
			}
		}

		private void RemoveConnection(Region connection)
		{
			if (!connections.Remove(connection))
			{
				return;
			}
			connection.RemoveConnection(this);
			if (!hasBridgeConnections || !connection.IsBridge)
			{
				return;
			}
			foreach (Region connection2 in connections)
			{
				if (connection2.IsBridge)
				{
					return;
				}
			}
			hasBridgeConnections = false;
		}

		private void BlockIfDirtyAndNotMainThread()
		{
			if (Thread.CurrentThread != MonoSingleton<ThreadingJobSystem>.Instance.MainThread)
			{
				while (IsDirty && !HasDisposed)
				{
					Thread.Sleep(1);
				}
			}
		}

		private void RemoveAllConnections()
		{
			HashSetPool<Region>.Return(RemoveGetAllConnections());
		}

		private HashSet<Region> RemoveGetAllConnections()
		{
			HashSet<Region> hashSet = HashSetPool<Region>.Get();
			foreach (Region connection in connections)
			{
				hashSet.Add(connection);
			}
			foreach (Region item in hashSet)
			{
				RemoveConnection(item);
			}
			return hashSet;
		}

		private void ScanForReachableObjects()
		{
			RefreshFromNodes(nodes);
			foreach (Region connection in Connections)
			{
				RefreshFromNodes(connection.nodes);
			}
			static void RefreshFromNodes(List<MapNode> nodes)
			{
				foreach (MapNode node in nodes)
				{
					IEnumerable<WorldObject> worldObjects = node.WorldObjects;
					if (worldObjects != null)
					{
						foreach (WorldObject item in worldObjects)
						{
							item.UpdateReachability();
						}
					}
				}
			}
		}

		private void AddToUnroofedCount(MapNode node, int add)
		{
			NonRoofedNodesCount += add;
			if (NonRoofedNodesCount == 1)
			{
				map.RegionBecameRoofed(this, isRoofed: false);
			}
			if (NonRoofedNodesCount == 0)
			{
				map.RegionBecameRoofed(this, isRoofed: true);
			}
		}

		public Area GetArea()
		{
			return map?.RegionAreaManager?.GetAreaById(area);
		}

		public bool IsFullyRoofed()
		{
			return NonRoofedNodesCount <= 0;
		}

		private void CalculateBoundsCenterAndSize()
		{
			Vec3Int b = Nodes[0].Position;
			Vec3Int a = Nodes[0].Position;
			foreach (MapNode node in Nodes)
			{
				b = Vec3Int.Min(in b, node.Position);
				a = Vec3Int.Max(in a, node.Position);
			}
			boundsCenter = ((b + a).ToVector3World() + Vector3.up * World.MapBlockHeight) * 0.5f;
			boundsSize = (a - b + Vec3Int.one).ToVector3();
		}
	}
}
