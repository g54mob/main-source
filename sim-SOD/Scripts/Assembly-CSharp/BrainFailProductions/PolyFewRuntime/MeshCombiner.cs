using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace BrainFailProductions.PolyFewRuntime
{
	public static class MeshCombiner
	{
		public struct StaticRenderer
		{
			public string name;

			public bool isNewMesh;

			public Transform transform;

			public Mesh mesh;

			public Material[] materials;
		}

		public struct SkinnedRenderer
		{
			public bool hasBlendShapes;

			public string name;

			public bool isNewMesh;

			public Transform transform;

			public Mesh mesh;

			public Material[] materials;

			public Transform rootBone;

			public Transform[] bones;
		}

		[Serializable]
		public struct BlendShape
		{
			public string ShapeName;

			public BlendShapeFrame[] Frames;

			public BlendShape(string shapeName, BlendShapeFrame[] frames)
			{
				ShapeName = null;
				Frames = null;
			}
		}

		[Serializable]
		public struct BlendShapeFrame
		{
			public string shapeName;

			public float frameWeight;

			public Vector3[] deltaVertices;

			public Vector3[] deltaNormals;

			public Vector3[] deltaTangents;

			public int vertexOffset;

			public BlendShapeFrame(float frameWeight, Vector3[] deltaVertices, Vector3[] deltaNormals, Vector3[] deltaTangents)
			{
				shapeName = null;
				this.frameWeight = 0f;
				this.deltaVertices = null;
				this.deltaNormals = null;
				this.deltaTangents = null;
				vertexOffset = 0;
			}

			public BlendShapeFrame(string shapeName, float frameWeight, Vector3[] deltaVertices, Vector3[] deltaNormals, Vector3[] deltaTangents, int vertexOffset)
			{
				this.shapeName = null;
				this.frameWeight = 0f;
				this.deltaVertices = null;
				this.deltaNormals = null;
				this.deltaTangents = null;
				this.vertexOffset = 0;
			}
		}

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

		private static MeshRenderer[] unityCombinedMeshRenderers;

		private static Material[] unityCombinedMeshesMats;

		private static bool didUseUnityCombine;

		public static bool generateUV2;

		public static StaticRenderer[] GetStaticRenderers(MeshRenderer[] renderers)
		{
			return null;
		}

		public static SkinnedRenderer[] GetSkinnedRenderers(SkinnedMeshRenderer[] renderers)
		{
			return null;
		}

		public static StaticRenderer[] CombineStaticMeshes(Transform transform, int levelIndex, MeshRenderer[] renderers, bool autoName = true, string combinedBaseName = "")
		{
			return null;
		}

		public static SkinnedRenderer[] CombineSkinnedMeshes(Transform transform, int levelIndex, SkinnedMeshRenderer[] renderers, ref SkinnedMeshRenderer[] renderersActuallyCombined, bool autoName = true, string combinedBaseName = "")
		{
			return null;
		}

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

		private static void ParentAndResetTransform(Transform transform, Transform parentTransform)
		{
		}

		private static void ParentAndOffsetTransform(Transform transform, Transform parentTransform, Transform originalTransform)
		{
		}

		private static Transform FindBestRootBone(Transform transform, SkinnedMeshRenderer[] skinnedMeshRenderers)
		{
			return null;
		}

		private static Transform FindBestRootBone(Dictionary<Transform, Transform> topLevelParents, SkinnedMeshRenderer[] skinnedMeshRenderers)
		{
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

		private static void CombineMeshesUnity(Transform parentTransform, MeshFilter[] meshFilters)
		{
		}
	}
}
