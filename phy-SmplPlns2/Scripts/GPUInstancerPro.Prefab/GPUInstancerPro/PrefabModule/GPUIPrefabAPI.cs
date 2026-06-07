using System.Collections.Generic;
using UnityEngine;

namespace GPUInstancerPro.PrefabModule
{
	public static class GPUIPrefabAPI
	{
		public static int AddPrototype(GPUIPrefabManager prefabManager, GameObject prefab)
		{
			return prefabManager.AddPrototype(prefab);
		}

		public static void AddPrefabInstance(GPUIPrefab gpuiPrefab)
		{
			GPUIPrefabManager.AddPrefabInstance(gpuiPrefab);
		}

		public static void AddPrefabInstances(IEnumerable<GPUIPrefab> gpuiPrefabs)
		{
			GPUIPrefabManager.AddPrefabInstances(gpuiPrefabs);
		}

		public static bool AddPrefabInstances(GPUIPrefabManager prefabManager, IEnumerable<GPUIPrefab> instances, int prototypeIndex)
		{
			return prefabManager.AddPrefabInstances(instances, prototypeIndex);
		}

		public static void AddPrefabInstances(GPUIPrefabManager prefabManager, IEnumerable<GameObject> gameObjects, int prototypeIndex)
		{
			prefabManager.AddPrefabInstances(gameObjects, prototypeIndex);
		}

		public static bool AddPrefabInstance(GPUIPrefabManager prefabManager, GameObject go, int prototypeIndex)
		{
			return prefabManager.AddPrefabInstance(go, prototypeIndex);
		}

		public static bool AddPrefabInstance(GPUIPrefabManager prefabManager, GPUIPrefab gpuiPrefab, int prototypeIndex = -1)
		{
			return prefabManager.AddPrefabInstance(gpuiPrefab, prototypeIndex);
		}

		public static int AddPrefabInstanceImmediate(GPUIPrefabManager prefabManager, GPUIPrefab gpuiPrefab, int prototypeIndex = -1)
		{
			return prefabManager.AddPrefabInstanceImmediate(gpuiPrefab, prototypeIndex);
		}

		public static void RemovePrefabInstance(GPUIPrefab gpuiPrefab)
		{
			gpuiPrefab.RemovePrefabInstance();
		}

		public static void UpdateTransformData(GPUIPrefabManager prefabManager)
		{
			prefabManager.UpdateTransformData();
		}

		public static void UpdateTransformData(GPUIPrefabManager prefabManager, int prototypeIndex)
		{
			prefabManager.UpdateTransformData(prototypeIndex);
		}

		public static void UpdateTransformData(GPUIPrefabManager prefabManager, GPUIPrefab gpuiPrefab)
		{
			prefabManager.UpdateTransformData(gpuiPrefab);
		}

		public static void RequireTransformUpdate(GPUIPrefabManager prefabManager)
		{
			prefabManager.RequireTransformUpdate();
		}
	}
}
