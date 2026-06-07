using System;
using System.Collections.Generic;
using UnityEngine;

namespace EasyRoads3Dv3
{
	public class ERMeshCombineUtility
	{
		public struct MeshInstance
		{
			public Mesh mesh;

			public int subMeshIndex;

			public Matrix4x4 transform;

			public int vertexCount;
		}

		public static Mesh Combine(Transform container, MeshInstance[] combines, bool generateStrips)
		{
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			MeshInstance[] array = combines;
			for (int i = 0; i < array.Length; i++)
			{
				MeshInstance meshInstance = array[i];
				if (!meshInstance.mesh)
				{
					continue;
				}
				num += meshInstance.mesh.vertexCount;
				if (!generateStrips)
				{
					continue;
				}
				int num4 = meshInstance.mesh.GetTriangles(meshInstance.subMeshIndex).Length;
				if (num4 != 0)
				{
					if (num3 != 0)
					{
						num3 = (((num3 & 1) != 1) ? (num3 + 2) : (num3 + 3));
					}
					num3 += num4;
				}
				else
				{
					generateStrips = false;
				}
			}
			if (!generateStrips)
			{
				array = combines;
				for (int i = 0; i < array.Length; i++)
				{
					MeshInstance meshInstance = array[i];
					if ((bool)meshInstance.mesh && meshInstance.mesh.GetTopology(meshInstance.subMeshIndex) == MeshTopology.Triangles)
					{
						num2 += meshInstance.mesh.GetTriangles(meshInstance.subMeshIndex).Length;
					}
				}
			}
			Vector3[] array2 = new Vector3[num];
			Vector3[] normals = new Vector3[num];
			Vector4[] tangents = new Vector4[num];
			Vector2[] uv = new Vector2[num];
			Vector2[] uv2 = new Vector2[num];
			int[] array3 = new int[num2];
			int[] array4 = new int[num3];
			int _3AAAA = 0;
			array = combines;
			for (int i = 0; i < array.Length; i++)
			{
				MeshInstance meshInstance = array[i];
				if ((bool)meshInstance.mesh)
				{
					ᙃ(meshInstance.mesh.vertexCount, meshInstance.mesh.vertices, array2, ref _3AAAA, meshInstance.transform);
				}
			}
			_3AAAA = 0;
			array = combines;
			for (int i = 0; i < array.Length; i++)
			{
				MeshInstance meshInstance = array[i];
				if ((bool)meshInstance.mesh)
				{
					Matrix4x4 transform = meshInstance.transform;
					transform = transform.inverse.transpose;
					ᙄ(meshInstance.mesh.vertexCount, meshInstance.mesh.normals, normals, ref _3AAAA, transform);
				}
			}
			_3AAAA = 0;
			array = combines;
			for (int i = 0; i < array.Length; i++)
			{
				MeshInstance meshInstance = array[i];
				if ((bool)meshInstance.mesh)
				{
					Matrix4x4 transform = meshInstance.transform;
					transform = transform.inverse.transpose;
					_4AAAA(meshInstance.mesh.vertexCount, meshInstance.mesh.tangents, tangents, ref _3AAAA, transform);
				}
			}
			_3AAAA = 0;
			array = combines;
			for (int i = 0; i < array.Length; i++)
			{
				MeshInstance meshInstance = array[i];
				if ((bool)meshInstance.mesh)
				{
					ᙃ(meshInstance.mesh.vertexCount, meshInstance.mesh.uv, uv, ref _3AAAA);
				}
			}
			_3AAAA = 0;
			array = combines;
			for (int i = 0; i < array.Length; i++)
			{
				MeshInstance meshInstance = array[i];
				if ((bool)meshInstance.mesh)
				{
					ᙃ(meshInstance.mesh.vertexCount, meshInstance.mesh.uv2, uv2, ref _3AAAA);
				}
			}
			int num5 = 0;
			int num6 = 0;
			int num7 = 0;
			array = combines;
			for (int i = 0; i < array.Length; i++)
			{
				MeshInstance meshInstance = array[i];
				if (!meshInstance.mesh)
				{
					continue;
				}
				if (generateStrips)
				{
					int[] triangles = meshInstance.mesh.GetTriangles(meshInstance.subMeshIndex);
					if (num6 != 0)
					{
						if ((num6 & 1) == 1)
						{
							array4[num6] = array4[num6 - 1];
							array4[num6 + 1] = triangles[0] + num7;
							array4[num6 + 2] = triangles[0] + num7;
							num6 += 3;
						}
						else
						{
							array4[num6] = array4[num6 - 1];
							array4[num6 + 1] = triangles[0] + num7;
							num6 += 2;
						}
					}
					for (int j = 0; j < triangles.Length; j++)
					{
						array4[j + num6] = triangles[j] + num7;
					}
					num6 += triangles.Length;
				}
				else if (meshInstance.mesh.GetTopology(meshInstance.subMeshIndex) == MeshTopology.Triangles)
				{
					int[] triangles2 = meshInstance.mesh.GetTriangles(meshInstance.subMeshIndex);
					for (int j = 0; j < triangles2.Length; j++)
					{
						array3[j + num5] = triangles2[j] + num7;
					}
					num5 += triangles2.Length;
				}
				num7 += meshInstance.mesh.vertexCount;
			}
			Mesh mesh = new Mesh();
			if (array2.Length >= 65000)
			{
				Debug.Log(array2.Length);
				if (container != null && container.parent != null && container.parent.parent != null)
				{
					Debug.Log("EasyRoads3D: " + container.parent.name + " (" + container.parent.parent.name + ") too many vertices, Unity does not allow more then 65000 vertices for a mesh, mesh combine aborted.");
				}
				return mesh;
			}
			mesh.name = "Combined Mesh";
			mesh.vertices = array2;
			mesh.normals = normals;
			mesh.tangents = tangents;
			mesh.uv = uv;
			mesh.uv2 = uv2;
			if (generateStrips)
			{
				mesh.SetTriangles(array4, 0);
			}
			else
			{
				mesh.triangles = array3;
			}
			return mesh;
		}

		private static void ᙃ(int ᙂ, Vector3[] _1AAAA, Vector3[] ᙄ, ref int _3AAAA, Matrix4x4 _4AAAA)
		{
			for (int i = 0; i < _1AAAA.Length; i++)
			{
				ref Vector3 reference = ref ᙄ[i + _3AAAA];
				reference = _4AAAA.MultiplyPoint(_1AAAA[i]);
			}
			_3AAAA += ᙂ;
		}

		private static void ᙄ(int ᙂ, Vector3[] _1AAAA, Vector3[] ᙄ, ref int _3AAAA, Matrix4x4 _4AAAA)
		{
			for (int i = 0; i < _1AAAA.Length; i++)
			{
				ref Vector3 reference = ref ᙄ[i + _3AAAA];
				reference = _4AAAA.MultiplyVector(_1AAAA[i]).normalized;
			}
			_3AAAA += ᙂ;
		}

		private static void ᙃ(int ᙂ, Vector2[] _1AAAA, Vector2[] ᙄ, ref int _3AAAA)
		{
			for (int i = 0; i < _1AAAA.Length; i++)
			{
				ref Vector2 reference = ref ᙄ[i + _3AAAA];
				reference = _1AAAA[i];
			}
			_3AAAA += ᙂ;
		}

		private static void _4AAAA(int ᙂ, Vector4[] _1AAAA, Vector4[] ᙄ, ref int _3AAAA, Matrix4x4 _4AAAA)
		{
			for (int i = 0; i < _1AAAA.Length; i++)
			{
				Vector4 vector = _1AAAA[i];
				Vector3 vector2 = new Vector3(vector.x, vector.y, vector.z);
				vector2 = _4AAAA.MultiplyVector(vector2);
				ref Vector4 reference = ref ᙄ[i + _3AAAA];
				reference = new Vector4(vector2.x, vector2.y, vector2.z, vector.w);
			}
			_3AAAA += ᙂ;
		}

		public static void CombineMesh(GameObject go, Mesh mesh, Transform container, bool isSideObject)
		{
			Transform transform = go.transform;
			bool generateStrips = false;
			Component[] componentsInChildren = transform.GetComponentsInChildren(typeof(MeshFilter));
			Matrix4x4 worldToLocalMatrix = transform.transform.worldToLocalMatrix;
			List<CombineClass> list = new List<CombineClass>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				MeshFilter meshFilter = (MeshFilter)componentsInChildren[i];
				Renderer component = componentsInChildren[i].GetComponent<Renderer>();
				MeshInstance item = new MeshInstance
				{
					mesh = meshFilter.sharedMesh
				};
				if (!(component != null) || !component.enabled || !(item.mesh != null))
				{
					continue;
				}
				item.transform = worldToLocalMatrix * meshFilter.transform.localToWorldMatrix;
				Material[] sharedMaterials = component.sharedMaterials;
				for (int j = 0; j < sharedMaterials.Length; j++)
				{
					item.subMeshIndex = Math.Min(j, item.mesh.subMeshCount - 1);
					List<MeshInstance> combinedInstances = GetCombinedInstances(list, sharedMaterials[j]);
					if (combinedInstances != null)
					{
						combinedInstances.Add(item);
						continue;
					}
					combinedInstances = new List<MeshInstance>();
					combinedInstances.Add(item);
					list.Add(new CombineClass
					{
						m = sharedMaterials[j],
						objects = combinedInstances
					});
				}
				component.enabled = false;
			}
			int num = 0;
			foreach (CombineClass item2 in list)
			{
				MeshInstance[] array = item2.objects.ToArray();
				bool flag = false;
				for (int i = 0; i < array.Length; i++)
				{
					if (mesh == array[i].mesh)
					{
						flag = true;
						break;
					}
				}
				MeshFilter meshFilter;
				if (list.Count == 1 || flag)
				{
					if (transform.GetComponent(typeof(MeshFilter)) == null)
					{
						transform.gameObject.AddComponent(typeof(MeshFilter));
					}
					if (!transform.GetComponent<MeshRenderer>())
					{
						transform.gameObject.AddComponent<MeshRenderer>();
					}
					meshFilter = (MeshFilter)transform.GetComponent(typeof(MeshFilter));
					meshFilter.mesh = Combine(container, array, generateStrips);
					transform.GetComponent<MeshRenderer>().material = item2.m;
					transform.GetComponent<MeshRenderer>().enabled = true;
					continue;
				}
				num++;
				string text = "";
				text = ((list.Count <= 2) ? "Instantiated Objects" : ("Instantiated Objects " + num));
				go = new GameObject(text);
				go.transform.parent = transform.transform;
				go.AddComponent(typeof(MeshFilter));
				go.AddComponent<MeshRenderer>();
				go.transform.localScale = Vector3.one;
				go.transform.localRotation = Quaternion.identity;
				go.transform.localPosition = Vector3.zero;
				go.GetComponent<MeshRenderer>().material = item2.m;
				meshFilter = (MeshFilter)go.GetComponent(typeof(MeshFilter));
				meshFilter.mesh = Combine(container, array, generateStrips);
				if ((bool)go.GetComponent<MeshRenderer>().sharedMaterial)
				{
					go.name = go.GetComponent<MeshRenderer>().sharedMaterial.name;
				}
			}
		}

		public static List<MeshInstance> GetCombinedInstances(List<CombineClass> mToMesh, Material m)
		{
			foreach (CombineClass item in mToMesh)
			{
				if (item.m == m)
				{
					return item.objects;
				}
			}
			return null;
		}
	}
}
