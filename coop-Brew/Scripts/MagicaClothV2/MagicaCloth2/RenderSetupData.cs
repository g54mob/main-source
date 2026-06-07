using System;
using System.Collections.Generic;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Profiling;
using UnityEngine;
using UnityEngine.Jobs;

namespace MagicaCloth2
{
	public class RenderSetupData : IDisposable, ITransform
	{
		public enum SetupType
		{
			MeshCloth = 0,
			BoneCloth = 1,
			BoneSpring = 2
		}

		public enum BoneConnectionMode
		{
			Line = 0,
			AutomaticMesh = 1,
			SequentialLoopMesh = 2,
			SequentialNonLoopMesh = 3
		}

		[BurstCompile]
		private struct CalcInverseRotationJob : IJobParallelFor
		{
			[ReadOnly]
			public NativeArray<quaternion> rotations;

			[NativeDisableParallelForRestriction]
			[WriteOnly]
			public NativeArray<quaternion> inverseRotations;

			public void Execute(int index)
			{
			}
		}

		[BurstCompile]
		private struct ReadTransformJob : IJobParallelForTransform
		{
			[NativeDisableParallelForRestriction]
			[WriteOnly]
			public NativeArray<float3> positions;

			[NativeDisableParallelForRestriction]
			[WriteOnly]
			public NativeArray<quaternion> rotations;

			[NativeDisableParallelForRestriction]
			[WriteOnly]
			public NativeArray<float3> scales;

			[NativeDisableParallelForRestriction]
			[WriteOnly]
			public NativeArray<float3> localPositions;

			[NativeDisableParallelForRestriction]
			[WriteOnly]
			public NativeArray<quaternion> localRotations;

			[NativeDisableParallelForRestriction]
			[WriteOnly]
			public NativeArray<quaternion> inverseRotations;

			public void Execute(int index, TransformAccess transform)
			{
			}
		}

		[BurstCompile]
		private struct GetBoneWeightJos : IJob
		{
			public int vcnt;

			[ReadOnly]
			public NativeArray<byte> bonesPerVertexArray;

			[ReadOnly]
			public NativeArray<BoneWeight1> boneWeightArray;

			[WriteOnly]
			public NativeArray<BoneWeight> boneWeights;

			public void Execute()
			{
			}
		}

		[Serializable]
		public class ShareSerializationData
		{
			public ResultCode result;

			public string name;

			public SetupType setupType;

			public Mesh originalMesh;

			public int vertexCount;

			public bool hasSkinnedMesh;

			public bool hasBoneWeight;

			public int skinRootBoneIndex;

			public int skinBoneCount;

			public List<Matrix4x4> bindPoseList;

			public byte[] bonesPerVertexArray;

			public byte[] boneWeightArray;

			public Vector3[] localPositions;

			public Vector3[] localNormals;

			public Vector4[] localTangents;

			public BoneConnectionMode boneConnectionMode;

			public int renderTransformIndex;

			public bool HasTangent => false;
		}

		[Serializable]
		public class UniqueSerializationData : ITransform
		{
			public ResultCode result;

			public Renderer renderer;

			public SkinnedMeshRenderer skinRenderer;

			public MeshFilter meshFilter;

			public Mesh originalMesh;

			public List<Transform> transformList;

			public void GetUsedTransform(HashSet<Transform> transformSet)
			{
			}

			public void ReplaceTransform(Dictionary<MagicaObjectId, Transform> replaceDict)
			{
			}
		}

		public ResultCode result;

		public string name;

		public bool isManaged;

		public SetupType setupType;

		public Renderer renderer;

		public SkinnedMeshRenderer skinRenderer;

		public MeshFilter meshFilter;

		public Mesh originalMesh;

		public int vertexCount;

		public bool hasSkinnedMesh;

		public bool hasBoneWeight;

		public Mesh.MeshDataArray meshDataArray;

		public int skinRootBoneIndex;

		public int skinBoneCount;

		public List<Matrix4x4> bindPoseList;

		public NativeArray<byte> bonesPerVertexArray;

		public NativeArray<BoneWeight1> boneWeightArray;

		public NativeArray<Vector3> localPositions;

		public NativeArray<Vector3> localNormals;

		public NativeArray<Vector4> localTangents;

		public List<MagicaObjectId> rootTransformIdList;

		public BoneConnectionMode boneConnectionMode;

		public List<int> collisionBoneIndexList;

		public List<Transform> transformList;

		public List<MagicaObjectId> transformIdList;

		public List<MagicaObjectId> transformParentIdList;

		public List<FixedList512Bytes<MagicaObjectId>> transformChildIdList;

		public NativeArray<float3> transformPositions;

		public NativeArray<quaternion> transformRotations;

		public NativeArray<float3> transformLocalPositions;

		public NativeArray<quaternion> transformLocalRotations;

		public NativeArray<float3> transformScales;

		public NativeArray<quaternion> transformInverseRotations;

		public int renderTransformIndex;

		public float4x4 initRenderLocalToWorld;

		public float4x4 initRenderWorldtoLocal;

		public quaternion initRenderRotation;

		public float3 initRenderScale;

		private static readonly ProfilerMarker readTransformProfiler;

		public int TransformCount => 0;

		public bool HasMeshDataArray => false;

		public bool HasLocalPositions => false;

		public bool HasTangent => false;

		public bool IsSuccess()
		{
			return false;
		}

		public bool IsFaild()
		{
			return false;
		}

		public RenderSetupData()
		{
		}

		public RenderSetupData(RenderSetupSerializeData referenceInitSetupData, Renderer ren)
		{
		}

		public RenderSetupData(RenderSetupSerializeData referenceInitSetupData, SetupType setType, Transform renderTransform, List<Transform> rootTransforms, List<Transform> collisionBones, BoneConnectionMode connectionMode = BoneConnectionMode.Line, string name = "(no name)")
		{
		}

		private void ReadTransformInformation(bool includeChilds, RenderSetupSerializeData referenceInitSetupData, Transform rendererTransform)
		{
		}

		public void Dispose()
		{
		}

		public void GetUsedTransform(HashSet<Transform> transformSet)
		{
		}

		public void ReplaceTransform(Dictionary<MagicaObjectId, Transform> replaceDict)
		{
		}

		public Transform GetRendeerTransform()
		{
			return null;
		}

		public MagicaObjectId GetRenderTransformId()
		{
			return default(MagicaObjectId);
		}

		public float4x4 GetRendeerLocalToWorldMatrix()
		{
			return default(float4x4);
		}

		public Transform GetSkinRootTransform()
		{
			return null;
		}

		public MagicaObjectId GetSkinRootTransformId()
		{
			return default(MagicaObjectId);
		}

		public int GetTransformIndexFromId(MagicaObjectId id)
		{
			return 0;
		}

		public int GetParentTransformIndex(int index, bool centerExcluded)
		{
			return 0;
		}

		public void GetBoneWeightsRun(NativeArray<BoneWeight> weights)
		{
		}

		public ShareSerializationData ShareSerialize()
		{
			return null;
		}

		public static RenderSetupData ShareDeserialize(ShareSerializationData sdata)
		{
			return null;
		}

		public UniqueSerializationData UniqueSerialize()
		{
			return null;
		}
	}
}
