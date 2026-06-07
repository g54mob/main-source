using System;
using System.Collections.Generic;
using DV.Utils;
using JBooth.MicroSplat;
using UnityEngine;

namespace DV.TerrainSystem
{
	public class TerrainHoleManager : SingletonBehaviour<TerrainHoleManager>
	{
		public Camera playerCamera;

		public int maxHoles = 100;

		public float checkRadius = 1500f;

		private TerrainGrid terrainGrid;

		private Camera prevPlayerCamera;

		private TerrainHole prevClosestHole;

		private TerrainHole[] allHoles;

		private BoundingSphere[] boundingSpheres;

		private int nextHoleIndex;

		private CullingGroup cg;

		private HashSet<TerrainHole> potentiallyVisibleHoles = new HashSet<TerrainHole>();

		private bool potentiallyVisibleHolesChanged;

		private int closestIndex;

		private int closestRobin;

		public TerrainHole ClosestHoleIgnoringVisibility
		{
			get
			{
				if (closestIndex >= allHoles.Length)
				{
					return null;
				}
				return allHoles[closestIndex];
			}
		}

		public new static string AllowAutoCreate()
		{
			return null;
		}

		private void OnEnable()
		{
			if ((bool)SingletonBehaviour<TerrainGrid>.Instance)
			{
				terrainGrid = SingletonBehaviour<TerrainGrid>.Instance;
				terrainGrid.TerrainsMoved += OnTerrainsMoved;
				allHoles = new TerrainHole[maxHoles];
				boundingSpheres = new BoundingSphere[maxHoles];
				cg = new CullingGroup();
				if ((bool)playerCamera)
				{
					cg.targetCamera = playerCamera;
					cg.SetDistanceReferencePoint(playerCamera.transform);
				}
				cg.SetBoundingDistances(new float[2]
				{
					checkRadius,
					float.PositiveInfinity
				});
				cg.SetBoundingSpheres(boundingSpheres);
				cg.SetBoundingSphereCount(nextHoleIndex);
				CullingGroup cullingGroup = cg;
				cullingGroup.onStateChanged = (CullingGroup.StateChanged)Delegate.Combine(cullingGroup.onStateChanged, new CullingGroup.StateChanged(OnSphereStateChanged));
			}
			else
			{
				Debug.LogError("TerrainHoleManager couldn't find TerrainGrid instance, destroying self", this);
				UnityEngine.Object.Destroy(this);
			}
		}

		private void OnDisable()
		{
			if (cg != null)
			{
				CullingGroup cullingGroup = cg;
				cullingGroup.onStateChanged = (CullingGroup.StateChanged)Delegate.Remove(cullingGroup.onStateChanged, new CullingGroup.StateChanged(OnSphereStateChanged));
				cg.Dispose();
				cg = null;
			}
			if ((bool)terrainGrid)
			{
				terrainGrid.TerrainsMoved -= OnTerrainsMoved;
			}
			if ((bool)prevClosestHole && (bool)prevClosestHole.Terrain)
			{
				MicroSplatTerrain componentInChildren = prevClosestHole.Terrain.GetComponentInChildren<MicroSplatTerrain>();
				if ((bool)componentInChildren)
				{
					UpdateMicroSplatHole(componentInChildren, Vector3.zero, 0f);
				}
			}
		}

		public void RegisterHole(TerrainHole hole)
		{
			if (nextHoleIndex > maxHoles - 1)
			{
				Debug.LogError(string.Format("{0} already has maximum number of holes registered ({1}), increase '{2}'", "TerrainHoleManager", maxHoles, "maxHoles"), this);
				return;
			}
			hole.managerIndex = nextHoleIndex;
			allHoles[nextHoleIndex] = hole;
			boundingSpheres[nextHoleIndex].position = hole.transform.position;
			boundingSpheres[nextHoleIndex].radius = hole.radius;
			UpdateHoleTerrain(hole);
			nextHoleIndex++;
			cg?.SetBoundingSphereCount(nextHoleIndex);
		}

		public void UnregisterHole(TerrainHole hole)
		{
			int managerIndex = hole.managerIndex;
			int num = nextHoleIndex - 1;
			if (managerIndex != num)
			{
				allHoles[managerIndex] = allHoles[num];
				allHoles[managerIndex].managerIndex = managerIndex;
				boundingSpheres[managerIndex] = boundingSpheres[num];
			}
			nextHoleIndex--;
			hole.managerIndex = -1;
			potentiallyVisibleHoles.Remove(hole);
			UpdateHole();
			cg?.SetBoundingSphereCount(nextHoleIndex);
		}

		public void RefreshHolePositions()
		{
			for (int i = 0; i < nextHoleIndex; i++)
			{
				boundingSpheres[i].position = allHoles[i].transform.position;
			}
			if ((bool)prevClosestHole && (bool)prevClosestHole.Terrain)
			{
				MicroSplatTerrain componentInChildren = prevClosestHole.Terrain.GetComponentInChildren<MicroSplatTerrain>();
				if ((bool)componentInChildren)
				{
					UpdateMicroSplatHole(componentInChildren, prevClosestHole.transform.position, prevClosestHole.radius);
				}
			}
		}

		private void OnTerrainsMoved()
		{
			for (int i = 0; i < nextHoleIndex; i++)
			{
				UpdateHoleTerrain(allHoles[i]);
			}
		}

		private void UpdateHoleTerrain(TerrainHole hole)
		{
			Terrain loadedTerrainAt = terrainGrid.GetLoadedTerrainAt(hole.transform.position);
			hole.Terrain = loadedTerrainAt;
		}

		private void OnSphereStateChanged(CullingGroupEvent sphere)
		{
			if (sphere.currentDistance == 0 && (sphere.hasBecomeVisible || (sphere.isVisible && sphere.previousDistance != sphere.currentDistance)))
			{
				TerrainHole terrainHole = allHoles[sphere.index];
				if (terrainHole != null)
				{
					potentiallyVisibleHoles.Add(terrainHole);
				}
			}
			else
			{
				TerrainHole item = allHoles[sphere.index];
				potentiallyVisibleHoles.Remove(item);
			}
			potentiallyVisibleHolesChanged = true;
		}

		private void Update()
		{
			if (prevPlayerCamera != playerCamera)
			{
				Camera camera = (prevPlayerCamera = ((playerCamera != null) ? playerCamera : null));
				cg.targetCamera = camera;
				cg.SetDistanceReferencePoint(camera?.transform);
			}
			if (potentiallyVisibleHolesChanged)
			{
				potentiallyVisibleHolesChanged = false;
				UpdateHole();
			}
			if (!prevPlayerCamera)
			{
				return;
			}
			if (closestRobin >= allHoles.Length)
			{
				closestRobin = 0;
			}
			if (allHoles.Length != 0 && allHoles[closestRobin] != null)
			{
				Vector3 position = prevPlayerCamera.transform.position;
				float sqrMagnitude = (position - ClosestHoleIgnoringVisibility.transform.position).sqrMagnitude;
				if ((position - allHoles[closestRobin].transform.position).sqrMagnitude < sqrMagnitude)
				{
					closestIndex = closestRobin;
				}
			}
			closestRobin++;
		}

		private void UpdateHole()
		{
			if (!playerCamera)
			{
				Debug.LogWarning("TerrainHoleManager doesn't have a camera assigned, holes won't work", this);
				return;
			}
			Transform obj = playerCamera.transform;
			Vector3 position = obj.position;
			Vector3 forward = obj.forward;
			TerrainHole terrainHole = null;
			float num = float.PositiveInfinity;
			foreach (TerrainHole potentiallyVisibleHole in potentiallyVisibleHoles)
			{
				if (potentiallyVisibleHole == null)
				{
					Debug.LogWarning("Encountered null hole while iterating, this shouldn't happen", this);
					continue;
				}
				float sqrMagnitude = (potentiallyVisibleHole.transform.position - position).sqrMagnitude;
				bool flag = Vector3.Dot(forward, potentiallyVisibleHole.transform.forward) < 0f;
				if (potentiallyVisibleHoles.Count == 1 || (sqrMagnitude < num && flag))
				{
					num = sqrMagnitude;
					terrainHole = potentiallyVisibleHole;
				}
			}
			if (terrainHole != null && terrainHole != prevClosestHole)
			{
				prevClosestHole = terrainHole;
				MicroSplatTerrain microSplatTerrain = (terrainHole.Terrain ? terrainHole.Terrain.GetComponentInChildren<MicroSplatTerrain>() : null);
				if ((bool)microSplatTerrain)
				{
					UpdateMicroSplatHole(microSplatTerrain, terrainHole.transform.position, terrainHole.radius);
				}
			}
			else if (terrainHole == null && prevClosestHole != null)
			{
				MicroSplatTerrain microSplatTerrain2 = (prevClosestHole.Terrain ? prevClosestHole.Terrain.GetComponentInChildren<MicroSplatTerrain>() : null);
				if ((bool)microSplatTerrain2)
				{
					UpdateMicroSplatHole(microSplatTerrain2, Vector3.zero, 0f);
				}
				prevClosestHole = null;
			}
		}

		public static void UpdateMicroSplatHole(MicroSplatTerrain microSplat, Vector3 position, float radius)
		{
			if (!(microSplat == null))
			{
				Vector4 value = position;
				value.w = radius * radius;
				microSplat.templateMaterial.SetVector("_AlphaHoleDV_1", value);
				microSplat.Sync();
			}
		}

		private void OnDrawGizmos()
		{
			if (!Application.isPlaying)
			{
				return;
			}
			for (int i = 0; i < nextHoleIndex; i++)
			{
				TerrainHole terrainHole = allHoles[i];
				if (!(terrainHole == null))
				{
					Gizmos.color = ((terrainHole == prevClosestHole) ? Color.blue : (potentiallyVisibleHoles.Contains(terrainHole) ? Color.green : Color.red));
					Gizmos.DrawWireSphere(boundingSpheres[i].position, boundingSpheres[i].radius);
				}
			}
		}
	}
}
