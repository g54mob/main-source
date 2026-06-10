using System;
using System.Collections.Generic;
using System.Linq;
using NSEipix.Base;
using NSMedieval.Types;
using NSMedieval.Village;
using NSMedieval.Village.Map;
using NSMedieval.Water;
using UnityEngine;

namespace NSMedieval.Model
{
	[Serializable]
	public class WalkSpeedMultiplier : NSEipix.Base.Model
	{
		[Serializable]
		private class WorldObjectSpeedPair
		{
			[SerializeField]
			private string worldObjectId;

			[SerializeField]
			private float speed;

			public string WorldObjectId => worldObjectId;

			public float Speed => speed;
		}

		[SerializeField]
		private string id;

		[SerializeField]
		private List<WorldObjectSpeedPair> overrideWalkSpeed = new List<WorldObjectSpeedPair>();

		[SerializeField]
		private float[] waterSpeedMultiplier;

		private bool walkSpeedByWorldObjectIdCacheInit;

		private Dictionary<string, float> walkSpeedByWorldObjectIdCache;

		private Dictionary<string, float> WalkSpeedByWorldObjectId
		{
			get
			{
				if (!walkSpeedByWorldObjectIdCacheInit)
				{
					walkSpeedByWorldObjectIdCacheInit = true;
					walkSpeedByWorldObjectIdCache = new Dictionary<string, float>();
					foreach (WorldObjectSpeedPair item in overrideWalkSpeed.Where((WorldObjectSpeedPair pair) => !walkSpeedByWorldObjectIdCache.ContainsKey(pair.WorldObjectId)))
					{
						walkSpeedByWorldObjectIdCache.Add(item.WorldObjectId, item.Speed);
					}
				}
				return walkSpeedByWorldObjectIdCache;
			}
		}

		public static float GetSpeedMultiplier(WalkSpeedMultiplier speedMultiplier, MapNode currentNode)
		{
			WaterDepthLevel waterDepthLevel = currentNode.WaterDepthLevel;
			float waterSpeedMult = GetWaterSpeedMult(speedMultiplier, waterDepthLevel);
			GridDataType dataType = currentNode.DataType;
			if ((dataType & GridDataType.Trap) != GridDataType.None)
			{
				WorldObject worldObject = currentNode.GetWorldObject(GridDataType.Trap);
				if (worldObject != null && !worldObject.HasDisposed)
				{
					return waterSpeedMult * speedMultiplier.GetWalkSpeedForObject(worldObject);
				}
			}
			if ((dataType & GridDataType.ProductionBuilding) != GridDataType.None)
			{
				WorldObject worldObject2 = currentNode.GetWorldObject(GridDataType.ProductionBuilding);
				if (worldObject2 != null && !worldObject2.HasDisposed)
				{
					return waterSpeedMult * speedMultiplier.GetWalkSpeedForObject(worldObject2);
				}
			}
			if ((dataType & GridDataType.ResourcePile) != GridDataType.None)
			{
				WorldObject worldObject3 = currentNode.GetWorldObject(WorldObjectType.ResourcePile);
				if (worldObject3 != null && !worldObject3.HasDisposed)
				{
					return waterSpeedMult * speedMultiplier.GetWalkSpeedForObject(worldObject3);
				}
			}
			if ((dataType & GridDataType.PlantMapResource) != GridDataType.None)
			{
				WorldObject worldObject4 = currentNode.GetWorldObject(WorldObjectType.MapResource);
				if (worldObject4 != null && !worldObject4.HasDisposed)
				{
					return waterSpeedMult * speedMultiplier.GetWalkSpeedForObject(worldObject4);
				}
			}
			if ((dataType & GridDataType.Furniture) != GridDataType.None)
			{
				WorldObject worldObject5 = currentNode.GetWorldObject(GridDataType.Furniture);
				if (worldObject5 != null && !worldObject5.HasDisposed)
				{
					return waterSpeedMult * speedMultiplier.GetWalkSpeedForObject(worldObject5);
				}
			}
			if (!currentNode.HasWorldObjects())
			{
				return waterSpeedMult * 0.85f;
			}
			foreach (WorldObject worldObject6 in currentNode.WorldObjects)
			{
				if (worldObject6 != null && (worldObject6.GridDataType & GridDataType.SocketableItem) == 0 && worldObject6.Type == WorldObjectType.Building)
				{
					return waterSpeedMult * speedMultiplier.GetWalkSpeedForObject(worldObject6);
				}
			}
			return waterSpeedMult * 0.85f;
		}

		private static float GetWaterSpeedMult(WalkSpeedMultiplier speedMultiplier, WaterDepthLevel nodeWaterDepth)
		{
			if ((nodeWaterDepth & WaterDepthLevel.High) != 0 && speedMultiplier.waterSpeedMultiplier.Length >= 4)
			{
				return speedMultiplier.waterSpeedMultiplier[3];
			}
			if ((nodeWaterDepth & WaterDepthLevel.Medium) != 0 && speedMultiplier.waterSpeedMultiplier.Length >= 3)
			{
				return speedMultiplier.waterSpeedMultiplier[2];
			}
			if ((nodeWaterDepth & WaterDepthLevel.Low) != 0 && speedMultiplier.waterSpeedMultiplier.Length >= 2)
			{
				return speedMultiplier.waterSpeedMultiplier[1];
			}
			if (speedMultiplier.waterSpeedMultiplier.Length >= 1)
			{
				return speedMultiplier.waterSpeedMultiplier[0];
			}
			return 1f;
		}

		private float GetWalkSpeedForObject(WorldObject worldObject)
		{
			if (!worldObject.HasDisposed && WalkSpeedByWorldObjectId.TryGetValue(worldObject.BlueprintId, out var value))
			{
				return value;
			}
			return worldObject.WalkSpeedMultiplier;
		}

		public override string GetID()
		{
			return id;
		}
	}
}
