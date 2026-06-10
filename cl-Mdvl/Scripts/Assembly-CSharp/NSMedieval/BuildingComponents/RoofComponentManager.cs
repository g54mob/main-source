using System;
using System.Collections.Generic;
using System.Linq;
using NSEipix.Base;
using NSMedieval.Map;
using NSMedieval.Utils.Pool;
using NSMedieval.Utils.Pool.Janitors;
using NSMedieval.Village.Map;
using UnityEngine;

namespace NSMedieval.BuildingComponents
{
	public class RoofComponentManager : ComponentBaseManager<RoofComponent, RoofComponentInstance>
	{
		private Dictionary<Vec3Int, List<RoofComponentInstance>> edgeLowPointsDict = new Dictionary<Vec3Int, List<RoofComponentInstance>>();

		public event Action<bool> SetRoofsVisibleEvent;

		public RoofComponentManager(VillageMap map)
			: base(map)
		{
		}

		public override void Dispose()
		{
			base.Dispose();
			edgeLowPointsDict.Clear();
			edgeLowPointsDict = null;
		}

		public void CacheRoofEdgeLowPoints(RoofComponentInstance roofComponentInstance)
		{
			foreach (Vec3Int edgeLowPoint in roofComponentInstance.EdgeLowPoints)
			{
				if (!edgeLowPointsDict.ContainsKey(edgeLowPoint))
				{
					edgeLowPointsDict.Add(edgeLowPoint, new List<RoofComponentInstance>());
				}
				edgeLowPointsDict[edgeLowPoint].Add(roofComponentInstance);
			}
		}

		public bool RoofEdgeExists(Vec3Int v)
		{
			if (!edgeLowPointsDict.TryGetValue(v, out var value))
			{
				return false;
			}
			return value.Count > 0;
		}

		public override void RemoveFromCache(RoofComponentInstance roofComponentInstance)
		{
			base.RemoveFromCache(roofComponentInstance);
			RemoveEdgeLowPoints(roofComponentInstance);
		}

		public void CreateAndCacheRoofComponentInstance(RoofComponentBlueprint blueprint, RoofComponent component, BaseBuildingInstance ownerBuilding, Vector3 scale)
		{
			RoofComponentInstance componentInstance = ComponentFactory.CreateComponentInstance(ownerBuilding, blueprint, (Vec3Int)scale);
			component.CacheInstance(componentInstance);
		}

		public void LadderBuilt(BaseBuildingInstance baseBuildingInstance)
		{
			using PooledList<Vec3Int> pooledList = ListPool<Vec3Int>.GetJanitor();
			pooledList.Add(baseBuildingInstance.GridDataPosition);
			pooledList.Add(baseBuildingInstance.GridDataPosition + Vec3Int.forward);
			pooledList.Add(baseBuildingInstance.GridDataPosition + Vec3Int.back);
			pooledList.Add(baseBuildingInstance.GridDataPosition + Vec3Int.left);
			pooledList.Add(baseBuildingInstance.GridDataPosition + Vec3Int.right);
			foreach (Vec3Int item in pooledList)
			{
				for (int i = 0; i < MonoSingleton<World>.Instance.SizeY; i++)
				{
					Vec3Int key = new Vec3Int(item.x, i, item.z);
					if (PositionInstanceDictionary.TryGetValue(key, out var value))
					{
						value.UpdateBuildingReachability();
					}
				}
			}
		}

		public void ShowHideRoofs()
		{
			if (GlobalSaveController.CurrentVillageData.RoofsVisible)
			{
				HideRoofs();
			}
			else
			{
				ShowRoofs();
			}
		}

		protected override void OnGameLoaded(bool fromSave)
		{
			base.OnGameLoaded(fromSave);
			if (!fromSave)
			{
				GlobalSaveController.CurrentVillageData.RoofsVisible = true;
			}
			if (GlobalSaveController.CurrentVillageData.RoofsVisible)
			{
				ShowRoofs(fromSave);
			}
			else
			{
				HideRoofs();
			}
		}

		private void RemoveEdgeLowPoints(RoofComponentInstance roofComponentInstance)
		{
			foreach (Vec3Int edgeLowPoint in roofComponentInstance.EdgeLowPoints)
			{
				if (edgeLowPointsDict.TryGetValue(edgeLowPoint, out var value))
				{
					value.Remove(roofComponentInstance);
				}
			}
		}

		private void ShowRoofs(bool fromSave = false)
		{
			GlobalSaveController.CurrentVillageData.RoofsVisible = true;
			Shader.SetGlobalFloat("_RoofsHidden", 0f);
			RoofComponentInstance[] array = InstanceComponentDictionary.Keys.ToArray();
			foreach (RoofComponentInstance key in array)
			{
				InstanceComponentDictionary[key].ShowRoof(fromSave);
			}
			this.SetRoofsVisibleEvent?.Invoke(obj: true);
		}

		private void HideRoofs()
		{
			GlobalSaveController.CurrentVillageData.RoofsVisible = false;
			Shader.SetGlobalFloat("_RoofsHidden", 1f);
			RoofComponentInstance[] array = InstanceComponentDictionary.Keys.ToArray();
			foreach (RoofComponentInstance key in array)
			{
				InstanceComponentDictionary[key].HideRoof();
			}
			this.SetRoofsVisibleEvent?.Invoke(obj: false);
		}
	}
}
