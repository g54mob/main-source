using System;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Serialization;

namespace UMA
{
	[Serializable]
	public class UMAMeshData : MeshDetails
	{
		public Matrix4x4[] bindPoses;

		public UMABoneWeight[] boneWeights;

		public UMABlendShape[] blendShapes;

		public ClothSkinningCoefficient[] clothSkinning;

		public Vector2[] clothSkinningSerialized;

		public SubMeshTriangles[] submeshes;

		[NonSerialized]
		public Transform[] bones;

		[NonSerialized]
		public Transform rootBone;

		public UMATransform[] umaBones;

		public int umaBoneCount;

		public int rootBoneHash;

		public int[] boneNameHashes;

		public int subMeshCount;

		public int vertexCount;

		public string RootBoneName;

		[FormerlySerializedAs("SerializedBoneWeights")]
		public BoneWeight1[] ManagedBoneWeights;

		[FormerlySerializedAs("SerializedBonesPerVertex")]
		public byte[] ManagedBonesPerVertex;

		[NonSerialized]
		public bool LoadedBoneweights;

		public string SlotName;

		public static Dictionary<int, NativeArray<int>> SubmeshBuffers;

		public Vector3[] GetVertices()
		{
			return null;
		}

		public int BoneWeightOffset(int vertexIndex)
		{
			return 0;
		}

		static UMAMeshData()
		{
		}

		private static void CurrentDomain_DomainUnload(object sender, EventArgs e)
		{
		}

		public static void CleanupGlobalBuffers()
		{
		}

		public void MirrorU(int channel)
		{
		}

		public void MirrorV(int channel)
		{
		}

		public void MirrorUV(int Channel)
		{
		}

		public NativeArray<int> GetSubmeshBuffer(int size, int submeshIndex)
		{
			return default(NativeArray<int>);
		}

		public void PrepareVertexBuffers(int size)
		{
		}

		public void RetrieveDataFromUnityMesh(SkinnedMeshRenderer renderer, int submeshIndex, bool udimAdjustment = false)
		{
		}

		private static T[] RemapArray<T>(ICollection<int> map, T[] src)
		{
			return null;
		}

		public void RetrieveDataFromUnityMesh(Mesh sharedMesh, bool udimAdjustment = false, int subMeshInd = -1)
		{
		}

		public void OldetrieveDataFromUnityMesh(Mesh sharedMesh, bool udimAdjustment = false)
		{
		}

		public void RetrieveDataFromUnityCloth(Cloth cloth)
		{
		}

		public void UpdateBones(Transform rootBone, Transform[] bones)
		{
		}

		private static Transform RecursiveFindBone(Transform bone, string raceRoot)
		{
			return null;
		}

		private Transform FindRoot(Transform rootBone, Transform[] bones)
		{
			return null;
		}

		public void ApplyDataToUnityMesh(SkinnedMeshRenderer renderer, UMASkeleton skeleton, UMAData umaData)
		{
		}

		private VertexAttributeDescriptor[] GetVertexLayout()
		{
			return null;
		}

		private void SetBoneWeightsFromMeshData(Mesh mesh)
		{
		}

		private void ValidateNativeBuffers()
		{
		}

		public Mesh ToUnityMesh()
		{
			return null;
		}

		public void CopyDataToUnityMesh(SkinnedMeshRenderer renderer)
		{
		}

		public void LoadBoneWeights()
		{
		}

		public void LoadVariableBoneWeights()
		{
		}

		public void FreeBoneWeights()
		{
		}

		private void CreateTransforms(UMASkeleton skeleton)
		{
		}

		private void ComputeBoneNameHashes(Transform[] bones)
		{
		}

		public static implicit operator bool(UMAMeshData obj)
		{
			return false;
		}

		public bool Equals(UMAMeshData other)
		{
			return false;
		}

		public override bool Equals(object other)
		{
			return false;
		}

		public static bool operator ==(UMAMeshData overlay, UMAMeshData obj)
		{
			return false;
		}

		public static bool operator !=(UMAMeshData overlay, UMAMeshData obj)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		internal void ReSortUMABones()
		{
		}

		public UMAMeshData ShallowCopy(Vector3[] ReplacementVerts)
		{
			return null;
		}

		public UMAMeshData ShallowClearCopy()
		{
			return null;
		}

		public UMAMeshData DeepCopy()
		{
			return null;
		}
	}
}
