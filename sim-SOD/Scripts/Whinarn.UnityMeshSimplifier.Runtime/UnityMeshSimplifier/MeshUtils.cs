using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace UnityMeshSimplifier
{
	public static class MeshUtils
	{
		public const int UVChannelCount = 8;

		public static Mesh CreateMesh(Vector3[] vertices, int[][] indices, Vector3[] normals, Vector4[] tangents, Color[] colors, BoneWeight[] boneWeights, List<Vector2>[] uvs, Matrix4x4[] bindposes, BlendShape[] blendShapes)
		{
			return null;
		}

		public static Mesh CreateMesh(Vector3[] vertices, int[][] indices, Vector3[] normals, Vector4[] tangents, Color[] colors, BoneWeight[] boneWeights, List<Vector4>[] uvs, Matrix4x4[] bindposes, BlendShape[] blendShapes)
		{
			return null;
		}

		public static Mesh CreateMesh(Vector3[] vertices, int[][] indices, Vector3[] normals, Vector4[] tangents, Color[] colors, BoneWeight[] boneWeights, List<Vector2>[] uvs2D, List<Vector3>[] uvs3D, List<Vector4>[] uvs4D, Matrix4x4[] bindposes, BlendShape[] blendShapes)
		{
			return null;
		}

		public static BlendShape[] GetMeshBlendShapes(Mesh mesh)
		{
			return null;
		}

		public static void LOG(string s)
		{
		}

		public static void ApplyMeshBlendShapes(Mesh mesh, BlendShape[] blendShapes)
		{
		}

		public static List<Vector4>[] GetMeshUVs(Mesh mesh)
		{
			return null;
		}

		public static List<Vector4> GetMeshUVs(Mesh mesh, int channel)
		{
			return null;
		}

		public static int GetUsedUVComponents(List<Vector4> uvs)
		{
			return 0;
		}

		public static Vector2[] ConvertUVsTo2D(List<Vector4> uvs)
		{
			return null;
		}

		public static Vector3[] ConvertUVsTo3D(List<Vector4> uvs)
		{
			return null;
		}

		public static Vector2Int[] GetSubMeshIndexMinMax(int[][] indices, out IndexFormat indexFormat)
		{
			indexFormat = default(IndexFormat);
			return null;
		}

		private static void GetIndexMinMax(int[] indices, out int minIndex, out int maxIndex)
		{
			minIndex = default(int);
			maxIndex = default(int);
		}
	}
}
