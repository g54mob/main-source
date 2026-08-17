using System;
using Cpp2ILInjected;
using UnityEngine;

public class MeshData
{
	public Vector3[] vertices;

	public int[] triangles;

	public Vector2[] uvs;

	private int triangleIndex;

	public MeshData(int meshWidth, int meshHeight)
	{
		//IL_00b4: Expected O, but got I4
		//IL_0012: Expected O, but got I4
		//IL_003c: Expected O, but got I4
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Expected O, but got Unknown
		//IL_0073: Expected O, but got I4
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
		object obj = meshWidth * meshHeight;
		Vector3[] array = new Vector3[obj];
		vertices = array;
		object obj2 = meshWidth * meshHeight;
		Vector2[] array2 = new Vector2[obj2];
		uvs = array2;
		object obj3 = meshHeight * 2;
		object obj4 = meshHeight + obj3;
		object obj5 = obj4 * 2;
		object obj6 = obj5 - 6;
		object obj7 = meshWidth - 1;
		object obj8 = obj6 * obj7;
		int[] array3 = new int[obj8];
		triangles = array3;
	}

	public void AddTriangle(int a, int b, int c)
	{
		//IL_004e: Expected O, but got I4
		//IL_0083: Expected O, but got I4
		int[] array = triangles;
		int num = triangleIndex;
		array[num] = a;
		int[] array2 = triangles;
		object obj = triangleIndex + 1;
		array2[obj] = b;
		int[] array3 = triangles;
		object obj2 = triangleIndex + 2;
		array3[obj2] = c;
		int num2 = triangleIndex + 3;
		triangleIndex = num2;
	}

	public Mesh CreateMesh()
	{
		Mesh mesh = new Mesh();
		if ((object)mesh != null)
		{
			mesh.vertices = vertices;
			mesh.triangles = triangles;
			mesh.uv = uvs;
			mesh.RecalculateNormals();
			return mesh;
		}
		return (Mesh)(object)new NullReferenceException();
	}
}
