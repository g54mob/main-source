using System.Collections.Generic;
using UnityEngine;

namespace GPUInstancerPro.TerrainModule
{
	public static class GPUITerrainAPI
	{
		public static void AddTerrains<T>(GPUITerrainManager<T> terrainManager, IEnumerable<Terrain> terrains) where T : GPUIPrototypeData, new()
		{
			terrainManager.AddTerrains(terrains);
		}

		public static void AddTerrains<T>(GPUITerrainManager<T> terrainManager, IEnumerable<GPUITerrain> gpuiTerrains) where T : GPUIPrototypeData, new()
		{
			terrainManager.AddTerrains(gpuiTerrains);
		}

		public static bool AddTerrain<T>(GPUITerrainManager<T> terrainManager, Terrain terrain) where T : GPUIPrototypeData, new()
		{
			return terrainManager.AddTerrain(terrain);
		}

		public static bool AddTerrain<T>(GPUITerrainManager<T> terrainManager, GPUITerrain gpuiTerrain) where T : GPUIPrototypeData, new()
		{
			return terrainManager.AddTerrain(gpuiTerrain);
		}

		public static bool RemoveTerrain<T>(GPUITerrainManager<T> terrainManager, Terrain terrain) where T : GPUIPrototypeData, new()
		{
			return terrainManager.RemoveTerrain(terrain);
		}

		public static bool RemoveTerrain<T>(GPUITerrainManager<T> terrainManager, GPUITerrain gpuiTerrain) where T : GPUIPrototypeData, new()
		{
			return terrainManager.RemoveTerrain(gpuiTerrain);
		}

		public static bool ContainsTerrains<T>(GPUITerrainManager<T> terrainManager, IEnumerable<Terrain> terrains) where T : GPUIPrototypeData, new()
		{
			return terrainManager.ContainsTerrains(terrains);
		}

		public static bool ContainsTerrain<T>(GPUITerrainManager<T> terrainManager, Terrain terrain) where T : GPUIPrototypeData, new()
		{
			return terrainManager.ContainsTerrain(terrain);
		}

		public static void RequireUpdate(GPUIDetailManager detailManager, bool forceImmediateUpdate = false, bool reloadTerrainDetailTextures = false)
		{
			detailManager.RequireUpdate(forceImmediateUpdate, reloadTerrainDetailTextures);
		}

		public static void RequireUpdate(GPUITreeManager treeManager, bool reloadTreeInstances = true)
		{
			treeManager.RequireUpdate(reloadTreeInstances);
		}

		public static void SetDetailDensityAdjustment(GPUIDetailManager detailManager, float newDensityValue)
		{
			if (detailManager == null)
			{
				return;
			}
			for (int i = 0; i < detailManager.GetPrototypeCount(); i++)
			{
				GPUIDetailPrototypeData prototypeData = detailManager.GetPrototypeData(i);
				if (prototypeData != null)
				{
					prototypeData.densityAdjustment = newDensityValue;
					prototypeData.SetParameterBufferData();
				}
			}
			detailManager.RequireUpdate();
		}

		public static void SetTreeInstances(GPUITerrain gpuiTerrain, TreeInstance[] treeInstances, bool applyToTerrainData = true)
		{
			if (!(gpuiTerrain == null))
			{
				gpuiTerrain.SetTreeInstances(treeInstances, applyToTerrainData);
			}
		}
	}
}
