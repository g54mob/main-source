using System;
using System.Collections.Generic;
using UnityEngine;

namespace VRM
{
	public static class BoneMeshEraser
	{
		private struct ExcludeBoneIndex
		{
			public readonly bool Bone0;

			public readonly bool Bone1;

			public readonly bool Bone2;

			public readonly bool Bone3;

			public ExcludeBoneIndex(bool bone0, bool bone1, bool bone2, bool bone3)
			{
				Bone0 = bone0;
				Bone1 = bone1;
				Bone2 = bone2;
				Bone3 = bone3;
			}
		}

		[Serializable]
		public struct EraseBone
		{
			public Transform Bone;

			public bool Erase;

			public override string ToString()
			{
				return Bone.name + ":" + Erase;
			}
		}

		private static int ExcludeTriangles(int[] triangles, BoneWeight[] bws, int[] exclude)
		{
			int result = 0;
			if (bws != null && bws.Length != 0)
			{
				for (int i = 0; i < triangles.Length; i += 3)
				{
					int num = triangles[i];
					int num2 = triangles[i + 1];
					int num3 = triangles[i + 2];
					BoneWeight boneWeight = bws[num];
					ExcludeBoneIndex excludeBoneIndex = AreBoneContains(ref exclude, boneWeight.boneIndex0, boneWeight.boneIndex1, boneWeight.boneIndex2, boneWeight.boneIndex3);
					if ((boneWeight.weight0 > 0f && excludeBoneIndex.Bone0) || (boneWeight.weight1 > 0f && excludeBoneIndex.Bone1) || (boneWeight.weight2 > 0f && excludeBoneIndex.Bone2) || (boneWeight.weight3 > 0f && excludeBoneIndex.Bone3))
					{
						continue;
					}
					BoneWeight boneWeight2 = bws[num2];
					ExcludeBoneIndex excludeBoneIndex2 = AreBoneContains(ref exclude, boneWeight2.boneIndex0, boneWeight2.boneIndex1, boneWeight2.boneIndex2, boneWeight2.boneIndex3);
					if ((!(boneWeight2.weight0 > 0f) || !excludeBoneIndex2.Bone0) && (!(boneWeight2.weight1 > 0f) || !excludeBoneIndex2.Bone1) && (!(boneWeight2.weight2 > 0f) || !excludeBoneIndex2.Bone2) && (!(boneWeight2.weight3 > 0f) || !excludeBoneIndex2.Bone3))
					{
						BoneWeight boneWeight3 = bws[num3];
						ExcludeBoneIndex excludeBoneIndex3 = AreBoneContains(ref exclude, boneWeight3.boneIndex0, boneWeight3.boneIndex1, boneWeight3.boneIndex2, boneWeight3.boneIndex3);
						if ((!(boneWeight3.weight0 > 0f) || !excludeBoneIndex3.Bone0) && (!(boneWeight3.weight1 > 0f) || !excludeBoneIndex3.Bone1) && (!(boneWeight3.weight2 > 0f) || !excludeBoneIndex3.Bone2) && (!(boneWeight3.weight3 > 0f) || !excludeBoneIndex3.Bone3))
						{
							triangles[result++] = num;
							triangles[result++] = num2;
							triangles[result++] = num3;
						}
					}
				}
			}
			return result;
		}

		private static ExcludeBoneIndex AreBoneContains(ref int[] exclude, int boneIndex0, int boneIndex1, int boneIndex2, int boneIndex3)
		{
			bool bone = false;
			bool bone2 = false;
			bool bone3 = false;
			bool bone4 = false;
			for (int i = 0; i < exclude.Length; i++)
			{
				if (exclude[i] == boneIndex0)
				{
					bone = true;
				}
				else if (exclude[i] == boneIndex1)
				{
					bone2 = true;
				}
				else if (exclude[i] == boneIndex2)
				{
					bone3 = true;
				}
				else if (exclude[i] == boneIndex3)
				{
					bone4 = true;
				}
			}
			return new ExcludeBoneIndex(bone, bone2, bone3, bone4);
		}

		public static Mesh CreateErasedMesh(Mesh src, int[] eraseBoneIndices)
		{
			Mesh mesh = new Mesh();
			mesh.name = src.name + "(erased)";
			mesh.indexFormat = src.indexFormat;
			mesh.vertices = src.vertices;
			mesh.normals = src.normals;
			mesh.uv = src.uv;
			mesh.tangents = src.tangents;
			mesh.boneWeights = src.boneWeights;
			mesh.bindposes = src.bindposes;
			mesh.subMeshCount = src.subMeshCount;
			for (int i = 0; i < src.subMeshCount; i++)
			{
				int[] indices = src.GetIndices(i);
				int num = ExcludeTriangles(indices, mesh.boneWeights, eraseBoneIndices);
				int[] array = new int[num];
				Array.Copy(indices, 0, array, 0, num);
				mesh.SetIndices(array, MeshTopology.Triangles, i);
			}
			return mesh;
		}

		public static int IndexOf(this Transform[] list, Transform target)
		{
			for (int i = 0; i < list.Length; i++)
			{
				if (list[i] == target)
				{
					return i;
				}
			}
			return -1;
		}

		public static IEnumerable<Transform> Ancestor(this Transform t)
		{
			yield return t;
			if (!(t.parent != null))
			{
				yield break;
			}
			foreach (Transform item in t.parent.Ancestor())
			{
				yield return item;
			}
		}
	}
}
