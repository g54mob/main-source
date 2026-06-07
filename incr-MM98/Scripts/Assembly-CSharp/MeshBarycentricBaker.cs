using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

[DisallowMultipleComponent]
public class MeshBarycentricBaker : MonoBehaviour
{
	private void Awake()
	{
		BakeMeshes();
	}

	public void BakeMeshes()
	{
		MeshFilter[] componentsInChildren = GetComponentsInChildren<MeshFilter>(includeInactive: true);
		foreach (MeshFilter obj in componentsInChildren)
		{
			obj.mesh = BakeBarycentric(obj.sharedMesh);
		}
	}

	private static Mesh BakeBarycentric(Mesh source)
	{
		if (source == null)
		{
			return null;
		}
		int[] triangles = source.triangles;
		int num = triangles.Length;
		Vector3[] array = new Vector3[num];
		Vector3[] array2 = ((source.normals.Length != 0) ? new Vector3[num] : null);
		Vector2[] array3 = ((source.uv.Length != 0) ? new Vector2[num] : null);
		Vector2[] array4 = new Vector2[num];
		Vector3[] vertices = source.vertices;
		Vector3[] normals = source.normals;
		Vector2[] uv = source.uv;
		Vector2[] array5 = new Vector2[3]
		{
			new Vector2(1f, 0f),
			new Vector2(0f, 1f),
			new Vector2(0f, 0f)
		};
		int[] array6 = new int[num];
		for (int i = 0; i < num; i++)
		{
			int num2 = triangles[i];
			array[i] = vertices[num2];
			if (array2 != null && normals.Length > num2)
			{
				array2[i] = normals[num2];
			}
			if (array3 != null && uv.Length > num2)
			{
				array3[i] = uv[num2];
			}
			array4[i] = array5[i % 3];
			array6[i] = i;
		}
		Mesh mesh = new Mesh
		{
			name = source.name + "_Bary"
		};
		mesh.indexFormat = ((num > 65535) ? IndexFormat.UInt32 : IndexFormat.UInt16);
		mesh.vertices = array;
		mesh.triangles = array6;
		if (array2 != null)
		{
			mesh.normals = array2;
		}
		if (array3 != null)
		{
			mesh.uv = array3;
		}
		mesh.SetUVs(1, new List<Vector2>(array4));
		mesh.RecalculateBounds();
		if (array2 == null)
		{
			mesh.RecalculateNormals();
		}
		return mesh;
	}
}
