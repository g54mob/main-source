using System;
using System.Collections.Generic;
using UnityEngine;

namespace UnityMeshSimplifier
{
	public static class MeshCombiner
	{
		public static Mesh CombineMeshes(Transform rootTransform, MeshRenderer[] renderers, out Material[] resultMaterials, Dictionary<Transform, Transform> topLevelParents = null, Dictionary<string, BlendShapeFrame> blendShapes = null)
		{
			resultMaterials = null;
			return null;
		}

		public static Mesh CombineMeshes(Transform rootTransform, SkinnedMeshRenderer[] renderers, out Material[] resultMaterials, out Transform[] resultBones)
		{
			resultMaterials = null;
			resultBones = null;
			return null;
		}

		public static Mesh CombineMeshes(Mesh[] meshes, Matrix4x4[] transforms, Tuple<Matrix4x4, bool>[] normalsTransforms, Material[][] materials, out Material[] resultMaterials, Dictionary<string, BlendShapeFrame> blendShapes = null)
		{
			resultMaterials = null;
			return null;
		}

		public static Mesh CombineMeshes(Mesh[] meshes, Matrix4x4[] transforms, Tuple<Matrix4x4, bool>[] normalsTransforms, Material[][] materials, Transform[][] bones, out Material[] resultMaterials, out Transform[] resultBones, Dictionary<string, BlendShapeFrame> blendShapes = null)
		{
			resultMaterials = null;
			resultBones = null;
			return null;
		}

		private static Transform GetTopLevelParent(Transform forObject)
		{
			return null;
		}

		private static void CopyVertexPositions(List<Vector3> list, Vector3[] arr)
		{
		}

		private static void CopyVertexAttributes<T>(ref List<T> dest, IEnumerable<T> src, int previousVertexCount, int meshVertexCount, int totalVertexCount, T defaultValue)
		{
		}

		private static T[] MergeArrays<T>(T[] arr1, T[] arr2)
		{
			return null;
		}

		private static void TransformVertices(Vector3[] vertices, ref Matrix4x4 transform)
		{
		}

		private static void TransformNormals(Vector3[] normals, ref Tuple<Matrix4x4, bool> transform)
		{
		}

		private static void TransformTangents(Vector4[] tangents, ref Tuple<Matrix4x4, bool> transform)
		{
		}

		private static void RemapBones(BoneWeight[] boneWeights, int[] boneIndices)
		{
		}

		private static Matrix4x4 ScaleMatrix(ref Matrix4x4 matrix, float scale)
		{
			return default(Matrix4x4);
		}
	}
}
