using System;
using System.Collections.Generic;
using UnityEngine;

namespace EasyRoads3Dv3
{
	[AddComponentMenu("")]
	public class OOCCCOQDQO : MonoBehaviour
	{
		public static void ODDQQCOOCD(Mesh mesh)
		{
			int num = -1;
			Vector3[] verts = mesh.vertices;
			Vector3[] array = new Vector3[mesh.vertices.Length];
			Array.Copy(mesh.vertices, array, mesh.vertices.Length);
			int[] tris = mesh.triangles;
			int[] array2 = new int[mesh.triangles.Length];
			Array.Copy(mesh.triangles, array2, mesh.triangles.Length);
			for (int i = 0; i < verts.Length - 1; i++)
			{
				if (verts[i] != Vector3.zero)
				{
					num = ODDCQDDOCQ(ref verts, i + 1, verts[i]);
					if (num != -1)
					{
						OQODDODOQC(ref tris, num, i);
					}
				}
			}
			List<int> list = new List<int>();
			for (int j = 0; j < tris.Length; j += 3)
			{
				if (tris[j] != tris[j + 1] && tris[j] != tris[j + 2] && tris[j + 1] != tris[j + 2])
				{
					list.Add(tris[j]);
					list.Add(tris[j + 1]);
					list.Add(tris[j + 2]);
				}
			}
			mesh.vertices = verts;
			mesh.triangles = list.ToArray();
			mesh.RecalculateNormals();
			mesh.RecalculateBounds();
			Vector3[] array3 = new Vector3[mesh.normals.Length];
			Array.Copy(mesh.normals, array3, mesh.normals.Length);
			for (int k = 0; k < verts.Length; k++)
			{
				if (!(verts[k] == Vector3.zero))
				{
					continue;
				}
				for (int l = 0; l < verts.Length; l++)
				{
					if (array[k] == mesh.vertices[l])
					{
						array3[k] = array3[l];
						break;
					}
				}
			}
			mesh.vertices = array;
			mesh.triangles = array2;
			mesh.normals = array3;
		}

		public static void OptimizeMeshFull(Mesh mesh)
		{
			int num = -1;
			Vector3[] verts = mesh.vertices;
			Vector3[] destinationArray = new Vector3[mesh.vertices.Length];
			Array.Copy(mesh.vertices, destinationArray, mesh.vertices.Length);
			int[] tris = mesh.triangles;
			int[] destinationArray2 = new int[mesh.triangles.Length];
			Array.Copy(mesh.triangles, destinationArray2, mesh.triangles.Length);
			for (int i = 0; i < verts.Length - 1; i++)
			{
				if (verts[i] != Vector3.zero)
				{
					num = ODDCQDDOCQ(ref verts, i + 1, verts[i]);
					if (num != -1)
					{
						OQODDODOQC(ref tris, num, i);
					}
				}
			}
			List<int> list = new List<int>();
			for (int j = 0; j < tris.Length; j += 3)
			{
				if (tris[j] != tris[j + 1] && tris[j] != tris[j + 2] && tris[j + 1] != tris[j + 2])
				{
					list.Add(tris[j]);
					list.Add(tris[j + 1]);
					list.Add(tris[j + 2]);
				}
			}
			mesh.vertices = verts;
			mesh.triangles = list.ToArray();
		}

		public static void OptimizeVertices(List<Vector3> vecs, List<int> triangles)
		{
			int num = -1;
			Vector3[] verts = vecs.ToArray();
			int[] tris = triangles.ToArray();
			for (int i = 0; i < verts.Length - 1; i++)
			{
				if (verts[i] != Vector3.zero)
				{
					num = ODDCQDDOCQ(ref verts, i + 1, verts[i]);
					if (num != -1)
					{
						OQODDODOQC(ref tris, num, i);
					}
				}
			}
			List<int> list = new List<int>();
			for (int j = 0; j < tris.Length; j += 3)
			{
				if (tris[j] != tris[j + 1] && tris[j] != tris[j + 2] && tris[j + 1] != tris[j + 2])
				{
					list.Add(tris[j]);
					list.Add(tris[j + 1]);
					list.Add(tris[j + 2]);
				}
			}
			vecs = new List<Vector3>(verts);
			triangles = new List<int>(list);
		}

		public static int ODDCQDDOCQ(ref Vector3[] verts, int start, Vector3 v)
		{
			for (int i = start; i < verts.Length; i++)
			{
				if (verts[i] == v)
				{
					verts[i] = Vector3.zero;
					return i;
				}
			}
			return -1;
		}

		public static void OQODDODOQC(ref int[] tris, int old, int newInt)
		{
			for (int i = 0; i < tris.Length; i++)
			{
				if (tris[i] == old)
				{
					tris[i] = newInt;
				}
			}
		}
	}
}
