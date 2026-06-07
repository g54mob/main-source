using System.Collections.Generic;
using UnityEngine;

namespace tripolygon.UModeler
{
	public class Builder
	{
		public static BuilderCallback modelBuilt;

		public static BuilderCallback modelBuilding;

		private static void AssignMaterials(MeshRenderer renderer, Material[] materials)
		{
			if (renderer != null && materials != null)
			{
				renderer.sharedMaterial = ((materials.Length != 0) ? materials[0] : null);
				renderer.sharedMaterials = materials;
			}
		}

		public static void Build(UModeler modeler, int shelf = -1)
		{
			modeler.editableMesh.uvIslandManager.RemoveAllEmpty();
			using (new ShelfHolder(modeler.editableMesh))
			{
				for (int i = 0; i < 2; i++)
				{
					if ((shelf != -1 && shelf != i) || (i == 1 && UMContext.activeModeler != modeler))
					{
						continue;
					}
					if (modelBuilding != null)
					{
						modelBuilding(modeler, i);
					}
					MirrorHelper.MirrorAll(i, modeler.editableMesh);
					modeler.editableMesh.shelf = i;
					if (i == 0)
					{
						if (modeler.renderableMeshFilter.sharedMesh != null)
						{
							Compile(modeler, modeler.renderableMeshFilter.sharedMesh);
							AssignMaterials(modeler.meshRenderer, modeler.materials.ToArray());
							Bounds bounds = new Bounds
							{
								center = modeler.editableMesh.aabb.GetCenter()
							};
							if (modeler.editableMesh.aabb.max != AABB.maxInit || modeler.editableMesh.aabb.min != AABB.minInit)
							{
								bounds.extents = modeler.editableMesh.aabb.max - bounds.center;
							}
							modeler.renderableMeshFilter.sharedMesh.bounds = bounds;
						}
					}
					else if (modeler.engineResources != null)
					{
						if (modeler.engineResources.RenderableMesh != null)
						{
							Compile(modeler, modeler.engineResources.RenderableMesh);
						}
						modeler.engineResources.RenderableMaterials.Clear();
						modeler.engineResources.RenderableMaterials.AddRange(modeler.materials.ToArray());
					}
					if (modelBuilt != null)
					{
						modelBuilt(modeler, i);
					}
				}
			}
		}

		public static void BuildByGameObject(GameObject go, bool buildChildren)
		{
			UModeler component = go.GetComponent<UModeler>();
			if (component != null && !component.editableMesh.IsEmpty())
			{
				MeshFilter component2 = go.GetComponent<MeshFilter>();
				if (component2 == null || component2.sharedMesh == null || component2.sharedMesh.vertexCount == 0)
				{
					component.Build();
				}
			}
			if (buildChildren)
			{
				for (int i = 0; i < go.transform.childCount; i++)
				{
					BuildByGameObject(go.transform.GetChild(i).gameObject, buildChildren);
				}
			}
		}

		private static void Compile(UModeler modeler, Mesh InMesh)
		{
			CachedMesh cachedMesh = new CachedMesh();
			SmoothingGroupManager smoothingGroups = modeler.editableMesh.smoothingGroups;
			HashSet<int> hashSet = new HashSet<int>();
			for (int i = 0; i < modeler.editableMesh.GetPolygonCount(); i++)
			{
				SimplePolygon polygon = modeler.editableMesh.GetPolygon(i);
				if (polygon.IsOpen())
				{
					continue;
				}
				int num = smoothingGroups.Contains(polygon);
				if (num != -1)
				{
					hashSet.Add(num);
					if (polygon.RefreshCheck(EPolygonCacheRefreshFlag.RenderableMesh))
					{
						smoothingGroups.GetSmoothingGroup(num).Invalidate();
					}
				}
				else
				{
					cachedMesh.Join(polygon.renderableMesh, polygon.matID);
				}
			}
			for (int j = 0; j < smoothingGroups.GetSmoothingGroupCount(); j++)
			{
				if (!hashSet.Contains(j))
				{
					continue;
				}
				SmoothingGroup smoothingGroup = smoothingGroups.GetSmoothingGroup(j);
				SortedDictionary<int, CachedMesh> sortedDictionary = smoothingGroup.CreateMeshes(modeler.editableMesh);
				if (sortedDictionary.Count == 0)
				{
					smoothingGroup.Invalidate();
					continue;
				}
				foreach (KeyValuePair<int, CachedMesh> item in sortedDictionary)
				{
					cachedMesh.Join(item.Value, item.Key);
				}
			}
			if (cachedMesh.vertices.Count >= 3 && cachedMesh.indices.Count >= 3)
			{
				cachedMesh.ConvertToRawMesh(modeler, InMesh);
			}
			else if (InMesh != null)
			{
				InMesh.Clear();
			}
		}
	}
}
