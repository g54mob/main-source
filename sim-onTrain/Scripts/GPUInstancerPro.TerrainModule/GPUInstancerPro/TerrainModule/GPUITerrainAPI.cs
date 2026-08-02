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

		public static void RequireUpdate(GPUIDetailManager detailManager, bool forceImmediateUpdate = false)
		{
			detailManager.RequireUpdate(forceImmediateUpdate);
		}

		public static void RequireUpdate(GPUITreeManager treeManager, bool reloadTreeInstances = true)
		{
			treeManager.RequireUpdate(reloadTreeInstances);
		}
	}
}
