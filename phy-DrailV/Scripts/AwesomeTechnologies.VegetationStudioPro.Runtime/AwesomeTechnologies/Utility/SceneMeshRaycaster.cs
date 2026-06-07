using System.Collections.Generic;
using AwesomeTechnologies.External.Octree;
using UnityEngine;

namespace AwesomeTechnologies.Utility
{
	public class SceneMeshRaycaster
	{
		public List<MeshRendererRaycastInfo> MeshRendererRaycastInfoList = new List<MeshRendererRaycastInfo>();

		public List<TerrainCollider> SceneTerrainColliderList = new List<TerrainCollider>();

		public BoundsOctree<MeshRendererRaycastInfo> BoundsOctree;

		public SceneMeshRaycaster()
		{
			FindMeshRenderers();
			SetupOctree();
		}

		private Bounds GetSceneBounds()
		{
			Bounds result = ((MeshRendererRaycastInfoList.Count > 0) ? MeshRendererRaycastInfoList[0].Bounds : default(Bounds));
			for (int i = 0; i <= MeshRendererRaycastInfoList.Count - 1; i++)
			{
				result.Encapsulate(MeshRendererRaycastInfoList[i].Bounds);
			}
			return result;
		}

		private void SetupOctree()
		{
			Bounds sceneBounds = GetSceneBounds();
			BoundsOctree = new BoundsOctree<MeshRendererRaycastInfo>(sceneBounds.size.magnitude, sceneBounds.center, 1f, 1.2f);
			for (int i = 0; i <= MeshRendererRaycastInfoList.Count - 1; i++)
			{
				BoundsOctree.Add(MeshRendererRaycastInfoList[i], MeshRendererRaycastInfoList[i].Bounds);
			}
		}

		private void FindMeshRenderers()
		{
			MeshRendererRaycastInfoList.Clear();
			MeshRenderer[] array = Object.FindObjectsOfType<MeshRenderer>();
			for (int i = 0; i <= array.Length - 1; i++)
			{
				MeshRendererRaycastInfo meshRendererRaycastInfo = new MeshRendererRaycastInfo
				{
					MeshRenderer = array[i],
					Bounds = array[i].bounds,
					LocalToWorldMatrix4X4 = array[i].localToWorldMatrix
				};
				MeshFilter component = array[i].gameObject.GetComponent<MeshFilter>();
				if ((bool)component)
				{
					meshRendererRaycastInfo.Mesh = component.sharedMesh;
				}
				if ((bool)meshRendererRaycastInfo.Mesh)
				{
					MeshRendererRaycastInfoList.Add(meshRendererRaycastInfo);
				}
			}
			SceneTerrainColliderList.Clear();
			TerrainCollider[] collection = Object.FindObjectsOfType<TerrainCollider>();
			SceneTerrainColliderList.AddRange(collection);
		}

		private bool IntersectRayMesh(Ray ray, MeshFilter meshFilter, out RaycastHit hit)
		{
			return IntersectRayMesh(ray, meshFilter.mesh, meshFilter.transform.localToWorldMatrix, out hit);
		}

		private bool IntersectRayMesh(Ray ray, Mesh mesh, Matrix4x4 matrix, out RaycastHit hit)
		{
			hit = default(RaycastHit);
			return false;
		}

		public bool RaycastSceneMeshes(Ray ray, out RaycastHit hit, bool includeTerrain, bool includeColliders, bool includeMeshes)
		{
			hit = default(RaycastHit);
			bool result = false;
			float num = float.PositiveInfinity;
			RaycastHit hitInfo;
			if (includeTerrain && !includeColliders)
			{
				for (int i = 0; i <= SceneTerrainColliderList.Count - 1; i++)
				{
					if (SceneTerrainColliderList[i].Raycast(ray, out hitInfo, float.PositiveInfinity))
					{
						float num2 = Vector3.Distance(ray.origin, hitInfo.point);
						if (num2 < num)
						{
							num = num2;
							result = true;
							hit = hitInfo;
						}
					}
				}
			}
			if (includeColliders && !includeTerrain)
			{
				RaycastHit[] array = Physics.RaycastAll(ray, float.PositiveInfinity);
				for (int j = 0; j <= array.Length - 1; j++)
				{
					if (!(array[j].collider is TerrainCollider))
					{
						float num3 = Vector3.Distance(ray.origin, array[j].point);
						if (num3 < num)
						{
							num = num3;
							result = true;
							hit = array[j];
						}
					}
				}
			}
			if (includeTerrain && includeColliders && Physics.Raycast(ray, out hitInfo, float.PositiveInfinity))
			{
				float num4 = Vector3.Distance(ray.origin, hitInfo.point);
				if (num4 < num)
				{
					num = num4;
					result = true;
					hit = hitInfo;
				}
			}
			if (includeMeshes)
			{
				List<MeshRendererRaycastInfo> list = new List<MeshRendererRaycastInfo>();
				BoundsOctree.GetColliding(list, ray);
				for (int k = 0; k <= list.Count - 1; k++)
				{
					if (IntersectRayMesh(ray, list[k].Mesh, list[k].LocalToWorldMatrix4X4, out hitInfo))
					{
						float num5 = Vector3.Distance(ray.origin, hitInfo.point);
						if (num5 < num)
						{
							num = num5;
							result = true;
							hit = hitInfo;
						}
					}
				}
			}
			return result;
		}
	}
}
