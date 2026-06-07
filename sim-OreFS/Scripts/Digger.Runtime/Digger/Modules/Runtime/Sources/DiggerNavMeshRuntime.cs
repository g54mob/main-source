using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Digger.Modules.Core.Sources;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

namespace Digger.Modules.Runtime.Sources
{
	[AddComponentMenu("Digger/Digger NavMesh Runtime")]
	public class DiggerNavMeshRuntime : MonoBehaviour
	{
		private DiggerSystem[] diggerSystems;

		private NavMeshSurface[] surfaces;

		private List<NavMeshBuildSource>[] initialNavMeshBuildSourcesPerSurface;

		private List<NavMeshBuildSource>[] navMeshBuildSources;

		private Bounds[] initialBoundsPerSurface;

		private Bounds[] boundsPerSurface;

		private void Awake()
		{
			diggerSystems = UnityEngine.Object.FindObjectsByType<DiggerSystem>(FindObjectsSortMode.None);
			surfaces = UnityEngine.Object.FindObjectsByType<NavMeshSurface>(FindObjectsSortMode.None);
			initialNavMeshBuildSourcesPerSurface = new List<NavMeshBuildSource>[surfaces.Length];
			navMeshBuildSources = new List<NavMeshBuildSource>[surfaces.Length];
			initialBoundsPerSurface = new Bounds[surfaces.Length];
			boundsPerSurface = new Bounds[surfaces.Length];
		}

		public void CollectNavMeshSources()
		{
			MethodInfo method = typeof(NavMeshSurface).GetMethod("CollectSources", BindingFlags.Instance | BindingFlags.NonPublic);
			if (method == null)
			{
				Debug.LogError("Cannot call method 'CollectSources' on NavMeshSurface. NavMesh support won't work.");
				return;
			}
			MethodInfo method2 = typeof(NavMeshSurface).GetMethod("CalculateWorldBounds", BindingFlags.Instance | BindingFlags.NonPublic);
			if (method2 == null)
			{
				Debug.LogError("Cannot call method 'CalculateWorldBounds' on NavMeshSurface. NavMesh Digger support won't work.");
				return;
			}
			for (int i = 0; i < surfaces.Length; i++)
			{
				NavMeshSurface obj = surfaces[i];
				List<NavMeshBuildSource> list = (List<NavMeshBuildSource>)method.Invoke(obj, null);
				list.RemoveAll((NavMeshBuildSource x) => x.component != null && x.component.gameObject.GetComponent<ChunkObject>() != null);
				initialNavMeshBuildSourcesPerSurface[i] = list;
				initialBoundsPerSurface[i] = (Bounds)method2.Invoke(obj, new object[1] { list });
				navMeshBuildSources[i] = new List<NavMeshBuildSource>(list.Capacity + 100);
			}
		}

		public void UpdateNavMeshAsync()
		{
			RefreshNavMeshSources();
			StartCoroutine(UpdateNavMeshCoroutine(null));
		}

		public void UpdateNavMeshAsync(Action callback)
		{
			RefreshNavMeshSources();
			StartCoroutine(UpdateNavMeshCoroutine(callback));
		}

		private void RefreshNavMeshSources()
		{
			for (int i = 0; i < surfaces.Length; i++)
			{
				List<NavMeshBuildSource> list = navMeshBuildSources[i];
				list.Clear();
				list.AddRange(initialNavMeshBuildSourcesPerSurface[i]);
				boundsPerSurface[i] = initialBoundsPerSurface[i];
				DiggerSystem[] array = diggerSystems;
				foreach (DiggerSystem obj in array)
				{
					obj.AddNavMeshSources(list);
					Bounds bounds = obj.Bounds;
					boundsPerSurface[i] = ExpandBounds(boundsPerSurface[i], bounds.min, bounds.max);
				}
			}
		}

		private IEnumerator UpdateNavMeshCoroutine(Action callback)
		{
			for (int i = 0; i < surfaces.Length; i++)
			{
				NavMeshSurface surface = surfaces[i];
				List<NavMeshBuildSource> list = navMeshBuildSources[i];
				if (list.Count == 0)
				{
					surface.RemoveData();
					continue;
				}
				if (!surface.navMeshData)
				{
					surface.navMeshData = InitializeBakeData(surface);
				}
				yield return NavMeshBuilder.UpdateNavMeshDataAsync(surface.navMeshData, surface.GetBuildSettings(), list, boundsPerSurface[i]);
				surface.RemoveData();
				surface.AddData();
			}
			callback?.Invoke();
		}

		private static Bounds ExpandBounds(Bounds bounds, Vector3 min, Vector3 max)
		{
			if (bounds.min.x < min.x)
			{
				min.x = bounds.min.x;
			}
			if (bounds.min.y < min.y)
			{
				min.y = bounds.min.y;
			}
			if (bounds.min.z < min.z)
			{
				min.z = bounds.min.z;
			}
			if (bounds.max.x > max.x)
			{
				max.x = bounds.max.x;
			}
			if (bounds.max.y > max.y)
			{
				max.y = bounds.max.y;
			}
			if (bounds.max.z > max.z)
			{
				max.z = bounds.max.z;
			}
			bounds.SetMinMax(min, max);
			return bounds;
		}

		private static NavMeshData InitializeBakeData(NavMeshSurface surface)
		{
			List<NavMeshBuildSource> sources = new List<NavMeshBuildSource>();
			return NavMeshBuilder.BuildNavMeshData(surface.GetBuildSettings(), sources, default(Bounds), surface.transform.position, surface.transform.rotation);
		}
	}
}
