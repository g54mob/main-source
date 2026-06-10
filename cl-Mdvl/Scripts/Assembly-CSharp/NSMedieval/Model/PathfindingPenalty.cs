using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using NSEipix.Base;
using NSMedieval.Types;
using NSMedieval.Village;
using NSMedieval.Village.Map;
using NSMedieval.Water;
using UnityEngine;

namespace NSMedieval.Model
{
	[Serializable]
	public class PathfindingPenalty : IndexedModel
	{
		[Serializable]
		private class WorldObjectPenaltyPair
		{
			[SerializeField]
			private string worldObjectId;

			[SerializeField]
			private ushort penalty;

			public string WorldObjectId => worldObjectId;

			public ushort Penalty => penalty;
		}

		public const short AntiPathCrowdingPenalty = 20;

		private const GridDataType BuildingsGridDataType = GridDataType.SlopeOrStairs | GridDataType.BuildingUnfinished | GridDataType.BuildingFinished | GridDataType.OthersUnfinished;

		[SerializeField]
		private string id;

		[SerializeField]
		private List<WorldObjectPenaltyPair> overridePenalty = new List<WorldObjectPenaltyPair>();

		[SerializeField]
		private string[] ignoreObjects;

		[SerializeField]
		private uint insideHomeAreaPenalty;

		[SerializeField]
		private uint outsideHomeAreaPenalty;

		[SerializeField]
		private List<IntIntPair> regionAttributePenalties;

		[SerializeField]
		private bool antiPathCrowdingPenaltyEnabled;

		private HashSet<string> ignoreObjectsCache;

		private Dictionary<string, uint> penaltyByWorldObjectIdCache;

		private bool ignoreObjectsCacheInit;

		private bool penaltyByWorldObjectIdCacheInit;

		private Dictionary<string, uint> PenaltyByWorldObjectId
		{
			get
			{
				if (!penaltyByWorldObjectIdCacheInit)
				{
					penaltyByWorldObjectIdCacheInit = true;
					penaltyByWorldObjectIdCache = new Dictionary<string, uint>();
					foreach (WorldObjectPenaltyPair item in overridePenalty.Where((WorldObjectPenaltyPair pair) => !penaltyByWorldObjectIdCache.ContainsKey(pair.WorldObjectId)))
					{
						penaltyByWorldObjectIdCache.Add(item.WorldObjectId, item.Penalty);
					}
				}
				return penaltyByWorldObjectIdCache;
			}
		}

		private HashSet<string> IgnoreObjects
		{
			get
			{
				if (!ignoreObjectsCacheInit)
				{
					ignoreObjectsCacheInit = true;
					ignoreObjectsCache = new HashSet<string>(ignoreObjects);
				}
				return ignoreObjectsCache;
			}
		}

		public List<IntIntPair> RegionAttributePenalties => regionAttributePenalties;

		public bool AntiPathCrowdingPenaltyEnabled => antiPathCrowdingPenaltyEnabled;

		public static ushort GetPathfindingPenalty(PathfindingPenalty penalty, MapNode currentNode, VillageMap map)
		{
			if (penalty == null)
			{
				return 1000;
			}
			ushort num = GetBasePathfindingPenalty(penalty, currentNode, map);
			if (penalty.AntiPathCrowdingPenaltyEnabled)
			{
				uint num2 = 20 * map.AntiPathCrowdingManager.GetPathCount(currentNode);
				num = LimitPenalty(num + num2);
			}
			return num;
		}

		private static ushort GetBasePathfindingPenalty(PathfindingPenalty penalty, MapNode currentNode, VillageMap map)
		{
			uint num = 0u;
			if (penalty.insideHomeAreaPenalty != 0 || penalty.outsideHomeAreaPenalty != 0)
			{
				if (map?.HomeArea == null)
				{
					return 1000;
				}
				num = (map.HomeArea.IsHomeArea(currentNode.Index) ? penalty.insideHomeAreaPenalty : penalty.outsideHomeAreaPenalty);
			}
			WaterDepthLevel waterDepthLevel = currentNode.WaterDepthLevel;
			if (waterDepthLevel >= WaterDepthLevel.Low)
			{
				ushort num2 = CalculateWaterPenalty(1000u, waterDepthLevel);
				num = LimitPenalty(num + num2);
			}
			if (currentNode.Tag == MapNodeTags.None && (!currentNode.IsWalkable || currentNode.DataType == GridDataType.None))
			{
				return LimitPenalty(num + 1000);
			}
			WorldObject worldObject;
			if (currentNode.CheckIsDataType(GridDataType.Trap))
			{
				worldObject = currentNode.GetWorldObject(GridDataType.Trap);
				if (worldObject != null && !worldObject.HasDisposed && !penalty.IgnoreWorldObject(worldObject))
				{
					return LimitPenalty(num + penalty.GetPenaltyForObject(worldObject));
				}
			}
			if (currentNode.CheckIsDataType(GridDataType.Grave))
			{
				worldObject = currentNode.GetWorldObject(GridDataType.Grave);
				if (worldObject != null && !worldObject.HasDisposed && !penalty.IgnoreWorldObject(worldObject))
				{
					return LimitPenalty(num + penalty.GetPenaltyForObject(worldObject));
				}
			}
			if (currentNode.CheckIsDataType(GridDataType.ProductionBuilding))
			{
				worldObject = currentNode.GetWorldObject(GridDataType.ProductionBuilding);
				if (worldObject != null && !worldObject.HasDisposed)
				{
					return LimitPenalty(num + penalty.GetPenaltyForObject(worldObject));
				}
			}
			if (currentNode.CheckIsDataType(GridDataType.ResourcePile))
			{
				worldObject = currentNode.GetWorldObject(GridDataType.ResourcePile);
				if (worldObject != null && !worldObject.HasDisposed && !string.IsNullOrEmpty(worldObject.BlueprintId))
				{
					return LimitPenalty(num + penalty.GetPenaltyForObject(worldObject));
				}
			}
			worldObject = currentNode.GetWorldObject(WorldObjectType.MapResource);
			if (worldObject != null && !worldObject.HasDisposed)
			{
				return LimitPenalty(num + penalty.GetPenaltyForObject(worldObject));
			}
			if (currentNode.CheckIsDataType(GridDataType.Furniture))
			{
				worldObject = currentNode.GetWorldObject(GridDataType.Furniture);
				if (worldObject != null && !worldObject.HasDisposed)
				{
					return LimitPenalty(num + penalty.GetPenaltyForObject(worldObject));
				}
			}
			if (currentNode.CheckIsDataType(GridDataType.SlopeOrStairs | GridDataType.BuildingUnfinished | GridDataType.BuildingFinished | GridDataType.OthersUnfinished))
			{
				worldObject = currentNode.GetWorldObject(GridDataType.SlopeOrStairs | GridDataType.BuildingUnfinished | GridDataType.BuildingFinished | GridDataType.OthersUnfinished);
				if (worldObject != null && !worldObject.HasDisposed && !penalty.IgnoreWorldObject(worldObject))
				{
					return LimitPenalty(num + penalty.GetPenaltyForObject(worldObject));
				}
			}
			return LimitPenalty(num + 1000);
		}

		public static ushort GetPathfindingPenaltyForRegion(PathfindingPenalty penalty, RegionAttribute attribute, ushort attributeValue)
		{
			for (int i = 0; i < penalty.RegionAttributePenalties.Count; i++)
			{
				if (((uint)penalty.RegionAttributePenalties[i].Key & (uint)attribute) != 0)
				{
					return (ushort)(penalty.regionAttributePenalties[i].Value * attributeValue);
				}
			}
			return 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static ushort LimitPenalty(uint penaltyValue)
		{
			if (penaltyValue > 65535)
			{
				return ushort.MaxValue;
			}
			return (ushort)penaltyValue;
		}

		private static ushort CalculateWaterPenalty(uint defaultPenalty, WaterDepthLevel waterDepth)
		{
			if (waterDepth >= WaterDepthLevel.High)
			{
				return (ushort)((float)defaultPenalty * 12f);
			}
			return (ushort)((float)defaultPenalty * 7f);
		}

		public override string GetID()
		{
			return id;
		}

		private bool IgnoreWorldObject(WorldObject worldObject)
		{
			if (ignoreObjects == null)
			{
				return false;
			}
			return ignoreObjects.Contains(worldObject.BlueprintId);
		}

		private uint GetPenaltyForObject(WorldObject worldObject)
		{
			if (PenaltyByWorldObjectId.ContainsKey(worldObject.BlueprintId))
			{
				return PenaltyByWorldObjectId[worldObject.BlueprintId];
			}
			return worldObject.PathfindingPenalty;
		}
	}
}
