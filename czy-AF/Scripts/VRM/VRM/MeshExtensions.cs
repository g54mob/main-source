using System.Linq;
using UnityEngine;

namespace VRM
{
	public static class MeshExtensions
	{
		public static Mesh Copy(this Mesh src, bool copyBlendShape)
		{
			Mesh mesh = new Mesh();
			mesh.name = src.name + "(copy)";
			mesh.indexFormat = src.indexFormat;
			mesh.vertices = src.vertices;
			mesh.normals = src.normals;
			mesh.tangents = src.tangents;
			mesh.colors = src.colors;
			mesh.uv = src.uv;
			mesh.uv2 = src.uv2;
			mesh.uv3 = src.uv3;
			mesh.uv4 = src.uv4;
			mesh.boneWeights = src.boneWeights;
			mesh.bindposes = src.bindposes;
			mesh.subMeshCount = src.subMeshCount;
			for (int i = 0; i < mesh.subMeshCount; i++)
			{
				mesh.SetIndices(src.GetIndices(i), src.GetTopology(i), i);
			}
			mesh.RecalculateBounds();
			if (copyBlendShape)
			{
				Vector3[] vertices = src.vertices;
				Vector3[] normals = src.normals;
				Vector3[] deltaTangents = null;
				for (int j = 0; j < src.blendShapeCount; j++)
				{
					src.GetBlendShapeFrameVertices(j, 0, vertices, normals, deltaTangents);
					mesh.AddBlendShapeFrame(src.GetBlendShapeName(j), src.GetBlendShapeFrameWeight(j, 0), vertices, normals, deltaTangents);
				}
			}
			return mesh;
		}

		public static void ApplyRotationAndScale(this Mesh src, Matrix4x4 m)
		{
			m.SetColumn(3, new Vector4(0f, 0f, 0f, 1f));
			src.ApplyMatrix(m);
		}

		public static void ApplyMatrix(this Mesh src, Matrix4x4 m)
		{
			src.vertices = src.vertices.Select((Vector3 x) => m.MultiplyPoint(x)).ToArray();
			if (src.normals != null && src.normals.Length != 0)
			{
				src.normals = src.normals.Select((Vector3 x) => m.MultiplyVector(x)).ToArray();
			}
			if (src.tangents != null && src.tangents.Length != 0)
			{
				src.tangents = src.tangents.Select(delegate(Vector4 x)
				{
					Vector3 vector = m.MultiplyVector(x);
					return new Vector4(vector.x, vector.y, vector.z, x.w);
				}).ToArray();
			}
		}
	}
}
