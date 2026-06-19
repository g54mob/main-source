using System.Collections.Generic;
using UnityEngine;

public static class MeshModifier
{
	public static Mesh CombineMeshes(List<Mesh> meshes, List<Matrix4x4> transforms)
	{
		CombineInstance[] array = new CombineInstance[meshes.Count];
		for (int i = 0; i < meshes.Count; i++)
		{
			array[i].mesh = meshes[i];
			array[i].transform = transforms[i];
		}
		Mesh mesh = new Mesh();
		mesh.CombineMeshes(array);
		return mesh;
	}

	public static Mesh RemoveFaces(Mesh mesh, List<Vector3> removalNormals)
	{
		Vector3[] array = new Vector3[mesh.vertexCount];
		int[] array2 = new int[mesh.GetTriangles(0).Length];
		array = mesh.vertices;
		array2 = mesh.GetTriangles(0);
		List<Vector3> list = new List<Vector3>();
		List<int> list2 = new List<int>();
		for (int i = 0; i < array2.Length; i += 3)
		{
			int num = array2[i];
			int num2 = array2[i + 1];
			int num3 = array2[i + 2];
			Vector3 vector = mesh.normals[num];
			Vector3 vector2 = mesh.normals[num2];
			Vector3 vector3 = mesh.normals[num3];
			bool flag = false;
			for (int j = 0; j < removalNormals.Count; j++)
			{
				if (vector == removalNormals[j] && vector2 == removalNormals[j] && vector3 == removalNormals[j])
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				list2.Add(num);
				list2.Add(num2);
				list2.Add(num3);
			}
		}
		list.AddRange(array);
		int[] array3 = new int[list2.Count];
		list2.CopyTo(array3);
		mesh.SetVertices(list);
		mesh.SetTriangles(array3, 0);
		mesh.RecalculateNormals();
		return mesh;
	}
}
