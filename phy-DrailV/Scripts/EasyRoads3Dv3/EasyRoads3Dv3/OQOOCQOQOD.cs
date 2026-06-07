using System;
using System.Collections.Generic;
using UnityEngine;

namespace EasyRoads3Dv3
{
	public class OQOOCQOQOD : MonoBehaviour
	{
		public static void OCCCOQOCDO(Mesh mesh)
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
					num = ODDDDCDCCC(ref verts, i + 1, verts[i]);
					if (num != -1)
					{
						OOCDCDCDDQ(ref tris, num, i);
					}
				}
			}
			List<int> list = new List<int>();
			for (int i = 0; i < tris.Length; i += 3)
			{
				if (tris[i] != tris[i + 1] && tris[i] != tris[i + 2] && tris[i + 1] != tris[i + 2])
				{
					list.Add(tris[i]);
					list.Add(tris[i + 1]);
					list.Add(tris[i + 2]);
				}
			}
			mesh.vertices = verts;
			mesh.triangles = list.ToArray();
			mesh.RecalculateNormals();
			mesh.RecalculateBounds();
			Vector3[] array3 = new Vector3[mesh.normals.Length];
			Array.Copy(mesh.normals, array3, mesh.normals.Length);
			for (int i = 0; i < verts.Length; i++)
			{
				if (!(verts[i] == Vector3.zero))
				{
					continue;
				}
				for (int j = 0; j < verts.Length; j++)
				{
					if (array[i] == mesh.vertices[j])
					{
						ref Vector3 reference = ref array3[i];
						reference = array3[j];
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
					num = ODDDDCDCCC(ref verts, i + 1, verts[i]);
					if (num != -1)
					{
						OOCDCDCDDQ(ref tris, num, i);
					}
				}
			}
			List<int> list = new List<int>();
			for (int i = 0; i < tris.Length; i += 3)
			{
				if (tris[i] != tris[i + 1] && tris[i] != tris[i + 2] && tris[i + 1] != tris[i + 2])
				{
					list.Add(tris[i]);
					list.Add(tris[i + 1]);
					list.Add(tris[i + 2]);
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
					num = ODDDDCDCCC(ref verts, i + 1, verts[i]);
					if (num != -1)
					{
						OOCDCDCDDQ(ref tris, num, i);
					}
				}
			}
			List<int> list = new List<int>();
			for (int i = 0; i < tris.Length; i += 3)
			{
				if (tris[i] != tris[i + 1] && tris[i] != tris[i + 2] && tris[i + 1] != tris[i + 2])
				{
					list.Add(tris[i]);
					list.Add(tris[i + 1]);
					list.Add(tris[i + 2]);
				}
			}
			vecs = new List<Vector3>(verts);
			triangles = new List<int>(list);
		}

		public static int ODDDDCDCCC(ref Vector3[] verts, int start, Vector3 v)
		{
			for (int i = start; i < verts.Length; i++)
			{
				if (verts[i] == v)
				{
					ref Vector3 reference = ref verts[i];
					reference = Vector3.zero;
					return i;
				}
			}
			return -1;
		}

		public static void OOCDCDCDDQ(ref int[] tris, int old, int newInt)
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
