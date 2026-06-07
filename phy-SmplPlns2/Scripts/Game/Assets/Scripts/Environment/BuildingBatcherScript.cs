using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Environment
{
	[ExecuteInEditMode]
	public class BuildingBatcherScript : MonoBehaviour
	{
		[SerializeField]
		private string _batchedAssetsLocation = "Assets/Content/Flight/Locations/";

		[SerializeField]
		private List<GameObject> _batchedBuildings = new List<GameObject>();

		[SerializeField]
		private List<BuildingScript> _batchedBuildingSources = new List<BuildingScript>();

		[SerializeField]
		private List<Mesh> _batchedMeshes = new List<Mesh>();

		private void BatchBuildings()
		{
			List<BuildingBatcherScript> list = (from x in GetComponentsInChildren<BuildingBatcherScript>()
				where x != this
				select x).ToList();
			if (list.Count > 0)
			{
				int num = 0;
				int num2 = 0;
				foreach (BuildingBatcherScript item2 in list)
				{
					item2._batchedAssetsLocation = _batchedAssetsLocation + "/" + item2.name + "/";
					item2.BatchBuildings();
					num += item2._batchedBuildingSources.Count;
					num2 += item2._batchedBuildings.Count;
				}
				Debug.Log($"Total Buildings: {num}, Total Batches: {num2}");
				return;
			}
			UnbatchBuildings();
			BuildingScript[] componentsInChildren = GetComponentsInChildren<BuildingScript>();
			Dictionary<string, (BuildingStyle, List<BuildingScript>)> dictionary = new Dictionary<string, (BuildingStyle, List<BuildingScript>)>();
			BuildingScript[] array = componentsInChildren;
			foreach (BuildingScript buildingScript in array)
			{
				string styleName = buildingScript.BuildingStyle.StyleName;
				if (!dictionary.TryGetValue(styleName, out var value))
				{
					dictionary.Add(styleName, value = (buildingScript.BuildingStyle, new List<BuildingScript>()));
				}
				value.Item2.Add(buildingScript);
				_batchedBuildingSources.Add(buildingScript);
			}
			foreach (KeyValuePair<string, (BuildingStyle, List<BuildingScript>)> item3 in dictionary)
			{
				item3.Deconstruct(out var key, out var value2);
				(BuildingStyle, List<BuildingScript>) tuple = value2;
				string text = key;
				List<BuildingScript> item = tuple.Item2;
				Transform transform = base.transform.Find(text);
				if (transform != null)
				{
					if (Application.isPlaying)
					{
						UnityEngine.Object.Destroy(transform.gameObject);
					}
					else
					{
						UnityEngine.Object.DestroyImmediate(transform.gameObject);
					}
				}
				Vector3 zero = Vector3.zero;
				foreach (BuildingScript item4 in item)
				{
					zero += item4.transform.position;
				}
				zero /= (float)item.Count;
				GameObject gameObject = new GameObject("Batched Buildings (" + text + ")");
				MeshFilter meshFilter = gameObject.AddComponent<MeshFilter>();
				MeshRenderer meshRenderer = gameObject.AddComponent<MeshRenderer>();
				MeshCollider meshCollider = gameObject.AddComponent<MeshCollider>();
				gameObject.transform.SetParent(base.transform, worldPositionStays: false);
				gameObject.transform.position = zero;
				_batchedBuildings.Add(gameObject);
				Mesh mesh = new Mesh();
				mesh.name = "Batched Buildings Mesh (" + text + ")";
				foreach (BuildingScript item5 in item)
				{
					_ = new Matrix4x4[item5.MeshFilter.sharedMesh.subMeshCount];
				}
				int num4 = 0;
				foreach (BuildingScript item6 in item)
				{
					Mesh mesh2 = item6.MeshFilter?.sharedMesh;
					if (mesh2 != null)
					{
						num4 = Math.Max(num4, mesh2.subMeshCount);
					}
				}
				List<Vector3> list2 = new List<Vector3>();
				List<Vector3> list3 = new List<Vector3>();
				List<Vector4> list4 = new List<Vector4>();
				List<Vector2> list5 = new List<Vector2>();
				List<Vector2> list6 = new List<Vector2>();
				List<int>[] array2 = new List<int>[Math.Max(1, num4)];
				for (int num5 = 0; num5 < array2.Length; num5++)
				{
					array2[num5] = new List<int>();
				}
				foreach (BuildingScript item7 in item)
				{
					Mesh mesh3 = item7.MeshFilter?.sharedMesh;
					if (mesh3 == null)
					{
						continue;
					}
					Matrix4x4 matrix4x = gameObject.transform.worldToLocalMatrix * item7.transform.localToWorldMatrix;
					int count = list2.Count;
					Vector3[] vertices = mesh3.vertices;
					Vector3[] normals = mesh3.normals;
					Vector4[] tangents = mesh3.tangents;
					Vector2[] uv = mesh3.uv;
					Vector2[] uv2 = mesh3.uv2;
					for (int num6 = 0; num6 < vertices.Length; num6++)
					{
						list2.Add(matrix4x.MultiplyPoint3x4(vertices[num6]));
						if (normals != null && normals.Length == vertices.Length)
						{
							Vector3 normalized = matrix4x.MultiplyVector(normals[num6]).normalized;
							list3.Add(normalized);
						}
						if (tangents != null && tangents.Length == vertices.Length)
						{
							Vector4 vector = tangents[num6];
							Vector3 vector2 = new Vector3(vector.x, vector.y, vector.z);
							vector2 = matrix4x.MultiplyVector(vector2).normalized;
							list4.Add(new Vector4(vector2.x, vector2.y, vector2.z, vector.w));
						}
						if (uv != null && uv.Length == vertices.Length)
						{
							list5.Add(uv[num6]);
						}
						if (uv2 != null && uv2.Length == vertices.Length)
						{
							list6.Add(uv2[num6]);
						}
						else if (uv2 == null || uv2.Length != vertices.Length)
						{
							list6.Add(Vector2.zero);
						}
					}
					int num7 = Math.Max(1, mesh3.subMeshCount);
					for (int num8 = 0; num8 < num7; num8++)
					{
						int[] triangles = mesh3.GetTriangles(num8);
						List<int> list7 = ((array2.Length > num8) ? array2[num8] : null);
						if (list7 != null)
						{
							for (int num9 = 0; num9 < triangles.Length; num9++)
							{
								list7.Add(triangles[num9] + count);
							}
						}
					}
				}
				mesh.SetVertices(list2);
				if (list3.Count == list2.Count)
				{
					mesh.SetNormals(list3);
				}
				else
				{
					mesh.RecalculateNormals();
				}
				if (list4.Count == list2.Count)
				{
					mesh.SetTangents(list4);
				}
				else
				{
					mesh.RecalculateTangents();
				}
				if (list5.Count == list2.Count)
				{
					mesh.SetUVs(0, list5);
				}
				if (list6.Count == list2.Count)
				{
					mesh.SetUVs(1, list6);
				}
				mesh.subMeshCount = array2.Length;
				for (int num10 = 0; num10 < array2.Length; num10++)
				{
					mesh.SetTriangles(array2[num10].ToArray(), num10);
				}
				mesh.RecalculateBounds();
				_batchedMeshes.Add(mesh);
				meshFilter.sharedMesh = mesh;
				meshCollider.sharedMesh = mesh;
				MeshRenderer meshRenderer2 = item.FirstOrDefault()?.MeshRenderer;
				if (meshRenderer2 != null)
				{
					meshRenderer.sharedMaterials = meshRenderer2.sharedMaterials;
				}
				else
				{
					meshRenderer.sharedMaterials = Array.Empty<Material>();
				}
				foreach (BuildingScript item8 in item)
				{
					item8.OnBatched(this);
				}
			}
		}

		private void UnbatchBuildings()
		{
			List<BuildingBatcherScript> list = (from x in GetComponentsInChildren<BuildingBatcherScript>()
				where x != this
				select x).ToList();
			if (list.Count > 0)
			{
				foreach (BuildingBatcherScript item in list)
				{
					item.UnbatchBuildings();
				}
				return;
			}
			foreach (Mesh batchedMesh in _batchedMeshes)
			{
				if (!(batchedMesh == null) && 0 == 0)
				{
					if (Application.isPlaying)
					{
						UnityEngine.Object.Destroy(batchedMesh);
					}
					else
					{
						UnityEngine.Object.DestroyImmediate(batchedMesh);
					}
				}
			}
			_batchedMeshes.Clear();
			foreach (GameObject batchedBuilding in _batchedBuildings)
			{
				if (Application.isPlaying)
				{
					UnityEngine.Object.Destroy(batchedBuilding);
				}
				else
				{
					UnityEngine.Object.DestroyImmediate(batchedBuilding);
				}
			}
			_batchedBuildings.Clear();
			foreach (BuildingScript batchedBuildingSource in _batchedBuildingSources)
			{
				batchedBuildingSource?.OnUnbatched();
			}
			_batchedBuildingSources.Clear();
		}
	}
}
