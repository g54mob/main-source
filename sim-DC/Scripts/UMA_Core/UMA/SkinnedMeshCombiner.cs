using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

namespace UMA
{
	public static class SkinnedMeshCombiner
	{
		public class CombineInstance
		{
			public UMAMeshData meshData;

			public int[] targetSubmeshIndices;

			public BitArray[] triangleMask;

			public SlotData slotData;
		}

		private enum MeshComponents
		{
			none = 0,
			has_normals = 1,
			has_tangents = 2,
			has_colors32 = 4,
			has_uv = 8,
			has_uv2 = 0x10,
			has_uv3 = 0x20,
			has_uv4 = 0x40,
			has_blendShapes = 0x80,
			has_clothSkinning = 0x100
		}

		private class BlendShapeVertexData
		{
			public bool hasNormals;

			public bool hasTangents;

			public int frameCount;

			public float[] frameWeights;

			public int index;
		}

		private class BoneIndexEntry
		{
			public int index;

			public List<int> indices;

			public int Count => 0;

			public int this[int idx] => 0;

			internal void AddIndex(int idx)
			{
			}
		}

		private static Dictionary<int, BoneIndexEntry> bonesCollection;

		private static List<Matrix4x4> bindPoses;

		private static List<int> bonesList;

		private static NativeArray<BoneWeight1> nativeBoneWeights;

		private static NativeArray<byte> nativeBonesPerVertex;

		static SkinnedMeshCombiner()
		{
		}

		private static void CurrentDomain_DomainUnload(object sender, EventArgs e)
		{
		}

		private static void CleanupNativeArrays()
		{
		}

		public static List<UMABlendShape> GetBlendshapeSources(UMAMeshData meshData, UMAData.UMARecipe recipe)
		{
			return null;
		}

		public static void CombineMeshes(UMAMeshData target, CombineInstance[] sources, BlendShapeSettings blendShapeSettings, UMAData.UMARecipe recipe, int currentRenderer)
		{
		}

		private static void ArrayCopyandExpand(UMAMeshData meshData, int expandAlongNormal, ref Vector3[] vertices, int vertexIndex, int sourceVertexCount)
		{
		}

		public static UMAMeshData ShallowInstanceMesh(UMAMeshData source, BitArray[] triangleMask = null)
		{
			return null;
		}

		public static bool BakeBlendShape(Dictionary<string, BlendShapeData> blendShapes, UMABlendShape currentShape, ref int vertexIndex, Vector3[] vertices, Vector3[] normals, Vector4[] tangents, bool has_Normals, bool has_Tangents)
		{
			return false;
		}

		public static void ConvertData(ref Vector2 source, ref ClothSkinningCoefficient dest)
		{
		}

		public static void ConvertData(ref ClothSkinningCoefficient source, ref Vector2 dest)
		{
		}

		private static void MergeSortedTransforms(UMATransform[] mergedTransforms, ref int len1, UMATransform[] umaTransforms)
		{
		}

		private static void AnalyzeBlendShapeSources(CombineInstance[] sources, BlendShapeSettings blendShapeSettings, ref MeshComponents meshComponents, out Dictionary<string, BlendShapeVertexData> blendShapeNames, UMAData.UMARecipe recipe)
		{
			blendShapeNames = null;
		}

		private static void InitializeBlendShapeData(ref int vertexCount, Dictionary<string, BlendShapeVertexData> blendShapeNames, UMABlendShape[] blendShapes)
		{
		}

		private static void AnalyzeSources(CombineInstance[] sources, int[] subMeshTriangleLength, ref int vertexCount, ref int boneweightcount, ref int bindPoseCount, ref int transformHierarchyCount, ref MeshComponents meshComponents)
		{
		}

		private static int FindTargetSubMeshCount(CombineInstance[] sources)
		{
			return 0;
		}

		private static void BuildBoneWeights(UMAMeshData data, NativeArray<BoneWeight1> dest, NativeArray<byte> destBonesPerVertex, int destIndex, int destBoneweightIndex, Dictionary<int, BoneIndexEntry> bonesCollection, List<Matrix4x4> bindPosesList, List<int> bonesList)
		{
		}

		private static bool CompareSkinningMatrices(Matrix4x4 m1, ref Matrix4x4 m2)
		{
			return false;
		}

		private static int TranslateBoneIndex(int index, int[] bonesHashes, Matrix4x4[] bindPoses, Dictionary<int, BoneIndexEntry> bonesCollection, List<Matrix4x4> bindPosesList, List<int> bonesList)
		{
			return 0;
		}

		private static void CopyColorsToColors32(Color[] source, int sourceIndex, Color32[] dest, int destIndex, int count)
		{
		}

		private static void FillArray(Vector4[] array, int index, int count, Vector4 value)
		{
		}

		private static void FillArray(Vector3[] array, int index, int count, Vector3 value)
		{
		}

		private static void FillArray(Vector2[] array, int index, int count, Vector2 value)
		{
		}

		private static void FillArray(Color[] array, int index, int count, Color value)
		{
		}

		private static void FillArray(Color32[] array, int index, int count, Color32 value)
		{
		}

		private static void CopyIntArrayAdd(NativeArray<int> source, int sourceIndex, NativeArray<int> dest, int destIndex, int count, int add)
		{
		}

		public static bool MaskedCopyIntArrayAdd(NativeArray<int> source, int sourceIndex, NativeArray<int> dest, int destIndex, int count, int add, BitArray mask)
		{
			return false;
		}

		private static T[] EnsureArrayLength<T>(T[] oldArray, int newLength)
		{
			return null;
		}
	}
}
