using UnityEngine;

namespace NSMedieval.MeshTools
{
	public static class TangentSolver
	{
		public static Vector4[] CalculateMeshTangents(int[] triangles, Vector3[] vertices, Vector3[] normals, Vector2[] uv)
		{
			int num = triangles.Length;
			int num2 = vertices.Length;
			Vector3[] array = new Vector3[num2];
			Vector3[] array2 = new Vector3[num2];
			Vector4[] array3 = new Vector4[num2];
			Vector2 vector = Vector2.zero;
			Vector2 vector2 = Vector2.zero;
			Vector2 vector3 = Vector2.zero;
			for (long num3 = 0L; num3 < num; num3 += 3)
			{
				long num4 = triangles[num3];
				long num5 = triangles[num3 + 1];
				long num6 = triangles[num3 + 2];
				if (uv.Length != 0)
				{
					vector = uv[num4];
					vector2 = uv[num5];
					vector3 = uv[num6];
				}
				Vector3 vector4 = vertices[num4];
				Vector3 vector5 = vertices[num5];
				Vector3 vector6 = vertices[num6];
				float num7 = vector5.x - vector4.x;
				float num8 = vector6.x - vector4.x;
				float num9 = vector5.y - vector4.y;
				float num10 = vector6.y - vector4.y;
				float num11 = vector5.z - vector4.z;
				float num12 = vector6.z - vector4.z;
				float num13 = vector2.x - vector.x;
				float num14 = vector3.x - vector.x;
				float num15 = vector2.y - vector.y;
				float num16 = vector3.y - vector.y;
				float num17 = num13 * num16 - num14 * num15;
				float num18 = ((num17 == 0f) ? 0f : (1f / num17));
				Vector3 vector7 = new Vector3((num16 * num7 - num15 * num8) * num18, (num16 * num9 - num15 * num10) * num18, (num16 * num11 - num15 * num12) * num18);
				Vector3 vector8 = new Vector3((num13 * num8 - num14 * num7) * num18, (num13 * num10 - num14 * num9) * num18, (num13 * num12 - num14 * num11) * num18);
				array[num4] += vector7;
				array[num5] += vector7;
				array[num6] += vector7;
				array2[num4] += vector8;
				array2[num5] += vector8;
				array2[num6] += vector8;
			}
			for (long num19 = 0L; num19 < num2; num19++)
			{
				Vector3 normal = normals[num19];
				Vector3 tangent = array[num19];
				Vector3.OrthoNormalize(ref normal, ref tangent);
				array3[num19].x = tangent.x;
				array3[num19].y = tangent.y;
				array3[num19].z = tangent.z;
				array3[num19].w = ((Vector3.Dot(Vector3.Cross(normal, tangent), array2[num19]) < 0f) ? (-1f) : 1f);
			}
			return array3;
		}
	}
}
