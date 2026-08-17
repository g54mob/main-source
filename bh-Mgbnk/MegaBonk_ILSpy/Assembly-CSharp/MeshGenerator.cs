using System;
using UnityEngine;

public static class MeshGenerator
{
	public static MeshData GenerateTerrainMesh(float[,] heightMap, float heightMultiplier, AnimationCurve heightCurve, int levelOfDetail)
	{
		//IL_003c: Expected O, but got I4
		//IL_004a: Expected O, but got I4
		//IL_05ef: Expected O, but got I4
		//IL_05f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_05fc: Expected I4, but got Unknown
		//IL_060a: Expected O, but got I4
		//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ed: Expected O, but got Unknown
		//IL_0103: Unknown result type (might be due to invalid IL or missing references)
		//IL_0108: Expected O, but got Unknown
		//IL_0111: Unknown result type (might be due to invalid IL or missing references)
		//IL_0116: Expected O, but got Unknown
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0124: Expected O, but got Unknown
		//IL_0182: Expected O, but got I4
		//IL_018b: Expected O, but got I4
		//IL_05bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_05c0: Expected O, but got Unknown
		//IL_01b1: Expected F4, but got I4
		int length = heightMap.GetLength(0);
		int length2 = heightMap.GetLength(1);
		object obj = length - 1;
		object obj2 = length2 - 1;
		float num = (float)obj * -0.5f;
		float num2 = (float)obj2 * 0.5f;
		bool flag = levelOfDetail == 0;
		int num3 = 1;
		int num4 = 1;
		if (!flag)
		{
			num4 = levelOfDetail + levelOfDetail;
			num3 = num4;
		}
		object obj3 = length - 1;
		int num5 = obj3 / num4;
		object obj4 = num5 + 1;
		MeshData meshData = new MeshData(0, 0);
		object obj5 = obj4 * obj4;
		Vector3[] vertices = new Vector3[obj5];
		meshData.vertices = vertices;
		object obj6 = obj4 * obj4;
		Vector2[] uvs = new Vector2[obj6];
		meshData.uvs = uvs;
		object obj7 = obj4 * 2;
		object obj8 = obj4 + obj7;
		object obj9 = obj8 * 2;
		object obj10 = obj9 - 6;
		object obj11 = obj4 - 1;
		object obj12 = obj10 * obj11;
		int[] array = (meshData.triangles = new int[obj12]);
		if (length2 > 0)
		{
			object obj13 = 0;
			object obj14 = 0;
			int[] array2 = array;
			int num6 = 0;
			int num7 = num3;
			do
			{
				if (length > 0)
				{
					float num8 = length2;
					object obj15 = obj14;
					int[] array3 = null;
					Vector3[] vertices2 = meshData.vertices;
					throw new IndexOutOfRangeException();
				}
				obj13 += num7;
			}
			while ((nint)obj13 < length2);
		}
		return meshData;
	}
}
