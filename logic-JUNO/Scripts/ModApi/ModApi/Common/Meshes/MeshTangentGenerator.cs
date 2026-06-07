using UnityEngine;

namespace ModApi.Common.Meshes
{
	public class MeshTangentGenerator
	{
		public static void CalculateTangents(int[] triangles, Vector3[] vertices, Vector2[] uvs, Vector3[] normals, Vector3[] tempTangents1, Vector3[] tempTangents2, Vector4[] results)
		{
			int num = triangles.Length;
			for (long num2 = 0L; num2 < num; num2 += 3)
			{
				long num3 = triangles[num2];
				long num4 = triangles[num2 + 1];
				long num5 = triangles[num2 + 2];
				Vector3 vector = vertices[num3];
				Vector3 vector2 = vertices[num4];
				Vector3 vector3 = vertices[num5];
				Vector2 vector4 = uvs[num3];
				Vector2 vector5 = uvs[num4];
				Vector2 vector6 = uvs[num5];
				float num6 = vector2.x - vector.x;
				float num7 = vector3.x - vector.x;
				float num8 = vector2.y - vector.y;
				float num9 = vector3.y - vector.y;
				float num10 = vector2.z - vector.z;
				float num11 = vector3.z - vector.z;
				float num12 = vector5.x - vector4.x;
				float num13 = vector6.x - vector4.x;
				float num14 = vector5.y - vector4.y;
				float num15 = vector6.y - vector4.y;
				float num16 = num12 * num15 - num13 * num14;
				float num17 = ((num16 == 0f) ? 0f : (1f / num16));
				Vector3 vector7 = new Vector3((num15 * num6 - num14 * num7) * num17, (num15 * num8 - num14 * num9) * num17, (num15 * num10 - num14 * num11) * num17);
				Vector3 vector8 = new Vector3((num12 * num7 - num13 * num6) * num17, (num12 * num9 - num13 * num8) * num17, (num12 * num11 - num13 * num10) * num17);
				tempTangents1[num3] += vector7;
				tempTangents1[num4] += vector7;
				tempTangents1[num5] += vector7;
				tempTangents2[num3] += vector8;
				tempTangents2[num4] += vector8;
				tempTangents2[num5] += vector8;
			}
			int num18 = vertices.Length;
			for (long num19 = 0L; num19 < num18; num19++)
			{
				Vector3 normal = normals[num19];
				Vector3 tangent = tempTangents1[num19];
				Vector3.OrthoNormalize(ref normal, ref tangent);
				results[num19].x = tangent.x;
				results[num19].y = tangent.y;
				results[num19].z = tangent.z;
				results[num19].w = ((Vector3.Dot(Vector3.Cross(normal, tangent), tempTangents2[num19]) < 0f) ? (-1f) : 1f);
			}
		}

		public static Vector4[] CalculateTangents(Mesh mesh)
		{
			int vertexCount = mesh.vertexCount;
			Vector4[] array = new Vector4[vertexCount];
			CalculateTangents(mesh.triangles, mesh.vertices, mesh.uv, mesh.normals, new Vector3[vertexCount], new Vector3[vertexCount], array);
			return array;
		}

		public static void UpdateTangents(Mesh mesh)
		{
			mesh.tangents = CalculateTangents(mesh);
		}
	}
}
