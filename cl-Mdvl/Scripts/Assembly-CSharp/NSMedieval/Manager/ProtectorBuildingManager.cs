using System.Collections.Generic;
using NSEipix.Base;
using NSMedieval.BuildingComponents;
using NSMedieval.Construction;
using NSMedieval.State;
using NSMedieval.Tools;
using NSMedieval.Village;
using NSMedieval.Village.Map;
using UnityEngine;

namespace NSMedieval.Manager
{
	public class ProtectorBuildingManager
	{
		private readonly Dictionary<WorldObject, bool> isBuildingProtecting = new Dictionary<WorldObject, bool>();

		private readonly object protectedNodesLock = new object();

		private VillageMap map;

		private const int Radius = 6;

		private Vec3Int[] neighborsRadius;

		private int[] protectedNodes;

		public bool IsProtected(int nodeIndex)
		{
			lock (protectedNodesLock)
			{
				return protectedNodes[nodeIndex] > 0;
			}
		}

		public void Initialize(VillageMap villageMap)
		{
			map = villageMap;
			protectedNodes = new int[map.Size.x * map.Size.y * map.Size.z];
			neighborsRadius = CreateNeighbors(6);
			MonoSingleton<ConstructionController>.Instance.FuelConsumerStateChangedEvent += OnFuelConsumerStateChanged;
			MonoSingleton<ConstructionController>.Instance.DestroyBuildingEvent += OnBuildingRemoved;
			MonoSingleton<ConstructionController>.Instance.ConstructionCompletedEvent += OnBuildingConstructed;
			MonoSingleton<ProductionManager>.Instance.ProductionStateChangedEvent += OnProductionStateChanged;
		}

		public void Dispose()
		{
			if (MonoSingleton<ConstructionController>.IsInstantiated())
			{
				MonoSingleton<ConstructionController>.Instance.FuelConsumerStateChangedEvent -= OnFuelConsumerStateChanged;
				MonoSingleton<ConstructionController>.Instance.DestroyBuildingEvent -= OnBuildingRemoved;
				MonoSingleton<ConstructionController>.Instance.ConstructionCompletedEvent -= OnBuildingConstructed;
			}
			if (MonoSingleton<ProductionManager>.IsInstantiated())
			{
				MonoSingleton<ProductionManager>.Instance.ProductionStateChangedEvent -= OnProductionStateChanged;
			}
			map = null;
		}

		public static Vec3Int[] CreateNeighbors(int radius)
		{
			List<Vec3Int> list = new List<Vec3Int>();
			for (int i = -radius; i <= radius; i++)
			{
				for (int j = -radius; j <= radius; j++)
				{
					Vec3Int item = new Vec3Int(i, 0, j);
					if (item.magnitude <= (float)radius)
					{
						list.Add(item);
					}
				}
			}
			return list.ToArray();
		}

		public void GetProtectors(Vec3Int position, ref HashSet<WorldObject> outputSet)
		{
			outputSet.Clear();
			MapNode[] gridSpaceData = map.GridSpaceData;
			Vec3Int[] array = neighborsRadius;
			for (int i = 0; i < array.Length; i++)
			{
				Vec3Int b = array[i];
				Vec3Int vec3Int = position + b;
				if (!GridDataIndexTools.InRange(vec3Int))
				{
					continue;
				}
				int num = GridDataIndexTools.FastTo1DIndex(vec3Int);
				foreach (WorldObject worldObject in gridSpaceData[num].WorldObjects)
				{
					if (isBuildingProtecting.ContainsKey(worldObject) && isBuildingProtecting[worldObject] && !outputSet.Contains(worldObject))
					{
						outputSet.Add(worldObject);
					}
				}
			}
		}

		public void DrawGizmos()
		{
			Color color = Gizmos.color;
			if (MonoSingleton<VillageManager>.IsInstantiated() && VillageManager.ActiveVillage != null)
			{
				VillageInstance activeVillage = VillageManager.ActiveVillage;
				Vector3 size = new Vector3(1f, 0.1f, 1f);
				if (activeVillage.Map != null)
				{
					int num = activeVillage.Map.GridSpaceData.Length;
					lock (protectedNodesLock)
					{
						for (int i = 0; i < num; i++)
						{
							if (protectedNodes[i] > 0)
							{
								Gizmos.color = Color.red * Mathf.Clamp01((float)(protectedNodes[i] + 1) / 4f);
								Gizmos.DrawCube(map.GridSpaceData[i].WorldPosition, size);
							}
						}
					}
				}
			}
			Gizmos.color = color;
		}

		public void BuildingLoaded(BaseBuildingInstance building)
		{
			if (building != null && !(building.Blueprint == null) && building.IsProtectingAgainstPredators())
			{
				bool isProtecting = building.IsProtectingAgainstPredators();
				SetBuildingProtecting(building, isProtecting);
			}
		}

		private void SetBuildingProtecting(BaseBuildingInstance building, bool isProtecting)
		{
			if (isBuildingProtecting.ContainsKey(building))
			{
				if (isBuildingProtecting[building] != isProtecting)
				{
					isBuildingProtecting[building] = isProtecting;
					AddToProtected(building.GridDataPosition, isProtecting ? 1 : (-1));
				}
			}
			else
			{
				isBuildingProtecting.Add(building, isProtecting);
				if (isProtecting)
				{
					AddToProtected(building.GridDataPosition, 1);
				}
			}
		}

		private void AddToProtected(Vec3Int position, int toAdd)
		{
			lock (protectedNodesLock)
			{
				Vec3Int[] array = neighborsRadius;
				for (int i = 0; i < array.Length; i++)
				{
					Vec3Int b = array[i];
					Vec3Int vec3Int = position + b;
					if (!GridDataIndexTools.InRange(vec3Int))
					{
						continue;
					}
					int num = GridDataIndexTools.FastTo1DIndex(vec3Int);
					protectedNodes[num] += toAdd;
					if (!map.CreaturesOnNodes.ContainsKey(num) || map.CreaturesOnNodes[num] == null)
					{
						continue;
					}
					foreach (CreatureBase item in map.CreaturesOnNodes[num])
					{
						item.OnPredatorProtectionChanged();
					}
				}
			}
		}

		private void OnBuildingRemoved(BaseBuildingInstance building)
		{
			if (building != null && !(building.Blueprint == null) && building.Blueprint.PassivePredatorProtection)
			{
				SetBuildingProtecting(building, isProtecting: false);
				isBuildingProtecting.Remove(building);
			}
		}

		private void OnFuelConsumerStateChanged(FuelConsumerComponentInstance fuelConsumerComponentInstance)
		{
			if (fuelConsumerComponentInstance != null && !fuelConsumerComponentInstance.HasDisposed)
			{
				BaseBuildingInstance ownerBuilding = fuelConsumerComponentInstance.OwnerBuilding;
				if (ownerBuilding != null && !ownerBuilding.HasDisposed)
				{
					bool isProtecting = fuelConsumerComponentInstance.IsProtectingAgainstPredators();
					SetBuildingProtecting(ownerBuilding, isProtecting);
				}
			}
		}

		private void OnBuildingConstructed(BaseBuildingInstance building)
		{
			BuildingLoaded(building);
		}

		private void OnProductionStateChanged(ProductionInstance productionInstance)
		{
			ProductionComponentInstance productionComponentInstance = productionInstance?.OwnerProductionComponentInstance;
			if (productionComponentInstance != null)
			{
				bool flag = productionComponentInstance.IsProtectingAgainstPredators();
				productionComponentInstance.OwnerBuilding.SetProtectingAgainstPredators(flag);
				SetBuildingProtecting(productionComponentInstance.OwnerBuilding, flag);
			}
		}
	}
}
