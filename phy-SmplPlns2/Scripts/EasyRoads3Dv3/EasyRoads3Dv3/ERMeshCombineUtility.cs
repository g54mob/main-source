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

			public bool flipTriangles;
		}

		public static Mesh Combine(Transform container, MeshInstance[] combines, bool generateStrips)
		{
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			for (int i = 0; i < combines.Length; i++)
			{
				MeshInstance meshInstance = combines[i];
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
				for (int j = 0; j < combines.Length; j++)
				{
					MeshInstance meshInstance2 = combines[j];
					if ((bool)meshInstance2.mesh && meshInstance2.mesh.GetTopology(meshInstance2.subMeshIndex) == MeshTopology.Triangles)
					{
						num2 += meshInstance2.mesh.GetTriangles(meshInstance2.subMeshIndex).Length;
					}
				}
			}
			Vector3[] array = new Vector3[num];
			Vector3[] normals = new Vector3[num];
			Vector4[] tangents = new Vector4[num];
			Vector2[] uv = new Vector2[num];
			Vector2[] uv2 = new Vector2[num];
			int[] array2 = new int[num2];
			int[] array3 = new int[num3];
			int wssss = 0;
			for (int k = 0; k < combines.Length; k++)
			{
				MeshInstance meshInstance3 = combines[k];
				if ((bool)meshInstance3.mesh)
				{
					ussst(meshInstance3.mesh.vertexCount, meshInstance3.mesh.vertices, array, ref wssss, meshInstance3.transform);
				}
			}
			wssss = 0;
			for (int l = 0; l < combines.Length; l++)
			{
				MeshInstance meshInstance4 = combines[l];
				if ((bool)meshInstance4.mesh)
				{
					Matrix4x4 transform = meshInstance4.transform;
					transform = transform.inverse.transpose;
					vssss(meshInstance4.mesh.vertexCount, meshInstance4.mesh.normals, normals, ref wssss, transform);
				}
			}
			wssss = 0;
			for (int m = 0; m < combines.Length; m++)
			{
				MeshInstance meshInstance5 = combines[m];
				if ((bool)meshInstance5.mesh)
				{
					Matrix4x4 transform2 = meshInstance5.transform;
					transform2 = transform2.inverse.transpose;
					xssss(meshInstance5.mesh.vertexCount, meshInstance5.mesh.tangents, tangents, ref wssss, transform2);
				}
			}
			wssss = 0;
			for (int n = 0; n < combines.Length; n++)
			{
				MeshInstance meshInstance6 = combines[n];
				if ((bool)meshInstance6.mesh)
				{
					ussst(meshInstance6.mesh.vertexCount, meshInstance6.mesh.uv, uv, ref wssss);
				}
			}
			wssss = 0;
			for (int num5 = 0; num5 < combines.Length; num5++)
			{
				MeshInstance meshInstance7 = combines[num5];
				if ((bool)meshInstance7.mesh)
				{
					ussst(meshInstance7.mesh.vertexCount, meshInstance7.mesh.uv2, uv2, ref wssss);
				}
			}
			int num6 = 0;
			int num7 = 0;
			int num8 = 0;
			for (int num9 = 0; num9 < combines.Length; num9++)
			{
				MeshInstance meshInstance8 = combines[num9];
				if (!meshInstance8.mesh)
				{
					continue;
				}
				if (generateStrips)
				{
					int[] triangles = meshInstance8.mesh.GetTriangles(meshInstance8.subMeshIndex);
					if (num7 != 0)
					{
						if ((num7 & 1) == 1)
						{
							array3[num7] = array3[num7 - 1];
							array3[num7 + 1] = triangles[0] + num8;
							array3[num7 + 2] = triangles[0] + num8;
							num7 += 3;
						}
						else
						{
							array3[num7] = array3[num7 - 1];
							array3[num7 + 1] = triangles[0] + num8;
							num7 += 2;
						}
					}
					for (int num10 = 0; num10 < triangles.Length; num10++)
					{
						array3[num10 + num7] = triangles[num10] + num8;
					}
					num7 += triangles.Length;
				}
				else if (meshInstance8.mesh.GetTopology(meshInstance8.subMeshIndex) == MeshTopology.Triangles)
				{
					int[] triangles2 = meshInstance8.mesh.GetTriangles(meshInstance8.subMeshIndex);
					if (!meshInstance8.flipTriangles)
					{
						for (int num11 = 0; num11 < triangles2.Length; num11++)
						{
							array2[num11 + num6] = triangles2[num11] + num8;
						}
					}
					else
					{
						int num12 = 0;
						for (int num13 = 0; num13 < triangles2.Length; num13 += 3)
						{
							array2[num13 + num6] = triangles2[num13] + num8;
							num12 = triangles2[num13 + 1] + num8;
							array2[num13 + num6 + 1] = triangles2[num13 + 2] + num8;
							array2[num13 + num6 + 2] = num12;
						}
					}
					num6 += triangles2.Length;
				}
				num8 += meshInstance8.mesh.vertexCount;
			}
			Mesh mesh = new Mesh();
			if (array.Length >= 65000)
			{
				if (container != null && container.parent != null && container.parent.parent != null)
				{
					Debug.Log("EasyRoads3D: " + container.parent.name + " (" + container.parent.parent.name + ") too many vertices, Unity does not allow more then 65000 vertices for a mesh, mesh combine aborted.");
				}
				return mesh;
			}
			mesh.name = "Combined Mesh";
			mesh.vertices = array;
			mesh.normals = normals;
			mesh.tangents = tangents;
			mesh.uv = uv;
			mesh.uv2 = uv2;
			if (generateStrips)
			{
				mesh.SetTriangles(array3, 0);
			}
			else
			{
				mesh.triangles = array2;
			}
			return mesh;
		}

		private static void ussst(int tssss, Vector3[] ussss, Vector3[] vssss, ref int wssss, Matrix4x4 xssss)
		{
			for (int i = 0; i < ussss.Length; i++)
			{
				vssss[i + wssss] = xssss.MultiplyPoint(ussss[i]);
			}
			wssss += tssss;
		}

		private static void vssss(int tssss, Vector3[] ussss, Vector3[] vssss, ref int wssss, Matrix4x4 xssss)
		{
			for (int i = 0; i < ussss.Length; i++)
			{
				vssss[i + wssss] = xssss.MultiplyVector(ussss[i]).normalized;
			}
			wssss += tssss;
		}

		private static void ussst(int tssss, Vector2[] ussss, Vector2[] vssss, ref int wssss)
		{
			for (int i = 0; i < ussss.Length; i++)
			{
				vssss[i + wssss] = ussss[i];
			}
			wssss += tssss;
		}

		private static void xssss(int tssss, Vector4[] ussss, Vector4[] vssss, ref int wssss, Matrix4x4 xssss)
		{
			for (int i = 0; i < ussss.Length; i++)
			{
				Vector4 vector = ussss[i];
				Vector3 vector2 = new Vector3(vector.x, vector.y, vector.z);
				vector2 = xssss.MultiplyVector(vector2);
				vssss[i + wssss] = new Vector4(vector2.x, vector2.y, vector2.z, vector.w);
			}
			wssss += tssss;
		}

		public static void CombineMesh(GameObject go, Mesh mesh, Transform container, bool isSideObject)
		{
			Transform transform = go.transform;
			int layer = go.layer;
			bool isStatic = go.isStatic;
			bool generateStrips = false;
			Component[] componentsInChildren = transform.GetComponentsInChildren(typeof(MeshFilter));
			Matrix4x4 worldToLocalMatrix = transform.transform.worldToLocalMatrix;
			List<CombineClass> list = new List<CombineClass>();
			Renderer renderer = null;
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				MeshFilter meshFilter = (MeshFilter)componentsInChildren[i];
				Renderer renderer2 = (renderer = componentsInChildren[i].GetComponent<Renderer>());
				MeshInstance item = new MeshInstance
				{
					mesh = meshFilter.sharedMesh
				};
				if (meshFilter.transform.localScale.x == -1f || (meshFilter.transform.parent != null && meshFilter.transform.parent.localScale.x == -1f))
				{
					item.flipTriangles = true;
				}
				else
				{
					item.flipTriangles = false;
				}
				if (!(renderer2 != null) || !renderer2.enabled || !(item.mesh != null))
				{
					continue;
				}
				item.transform = worldToLocalMatrix * meshFilter.transform.localToWorldMatrix;
				Material[] sharedMaterials = renderer2.sharedMaterials;
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
				renderer2.enabled = false;
			}
			int num = 0;
			foreach (CombineClass item2 in list)
			{
				MeshInstance[] array = item2.objects.ToArray();
				bool flag = false;
				for (int k = 0; k < array.Length; k++)
				{
					if (mesh == array[k].mesh)
					{
						flag = true;
						break;
					}
				}
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
					MeshFilter meshFilter2 = (MeshFilter)transform.GetComponent(typeof(MeshFilter));
					meshFilter2.mesh = Combine(container, array, generateStrips);
					transform.GetComponent<MeshRenderer>().material = item2.m;
					transform.GetComponent<MeshRenderer>().enabled = true;
					transform.gameObject.layer = layer;
					transform.gameObject.isStatic = isStatic;
					if (!(renderer != null))
					{
					}
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
				go.isStatic = isStatic;
				go.layer = layer;
				if (renderer != null)
				{
					if (go.GetComponent<MeshRenderer>() == null)
					{
						go.AddComponent<MeshRenderer>();
					}
					go.GetComponent<MeshRenderer>().shadowCastingMode = renderer.shadowCastingMode;
				}
				go.GetComponent<MeshRenderer>().material = item2.m;
				MeshFilter meshFilter3 = (MeshFilter)go.GetComponent(typeof(MeshFilter));
				meshFilter3.mesh = Combine(container, array, generateStrips);
				if ((bool)go.GetComponent<MeshRenderer>().sharedMaterial)
				{
					go.name = go.GetComponent<MeshRenderer>().sharedMaterial.name;
				}
				go.layer = layer;
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
