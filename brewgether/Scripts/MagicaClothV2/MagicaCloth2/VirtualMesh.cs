using System;
using System.Collections.Generic;
using System.Threading;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

namespace MagicaCloth2
{
	public class VirtualMesh : IDisposable, IValid
	{
		[BurstCompile]
		private struct Import_GenerateTangentJob : IJobParallelFor
		{
			[ReadOnly]
			public NativeArray<float3> localNormals;

			[WriteOnly]
			public NativeArray<float3> localTangents;

			public void Execute(int vindex)
			{
			}
		}

		[BurstCompile]
		private struct Import_CalcSkinningJob : IJobParallelFor
		{
			public NativeArray<float3> localPositions;

			public NativeArray<float3> localNormals;

			public NativeArray<float3> localTangents;

			[ReadOnly]
			public NativeArray<VirtualMeshBoneWeight> boneWeights;

			[ReadOnly]
			public NativeArray<int> skinBoneTransformIndices;

			[ReadOnly]
			public NativeArray<float4x4> bindPoses;

			[ReadOnly]
			public NativeArray<float3> transformPositionArray;

			[ReadOnly]
			public NativeArray<quaternion> transformRotationArray;

			[ReadOnly]
			public NativeArray<float3> transformScaleArray;

			public float4x4 toM;

			public void Execute(int vindex)
			{
			}
		}

		[BurstCompile]
		private struct Import_BoneWeightJob1 : IJob
		{
			public int vcnt;

			[ReadOnly]
			public NativeArray<byte> bonesPerVertexArray;

			[WriteOnly]
			public NativeArray<int> startBoneWeightIndices;

			public void Execute()
			{
			}
		}

		[BurstCompile]
		private struct Import_BoneWeightJob2 : IJobParallelFor
		{
			[ReadOnly]
			public NativeArray<int> startBoneWeightIndices;

			[ReadOnly]
			public NativeArray<BoneWeight1> boneWeightArray;

			[ReadOnly]
			public NativeArray<byte> bonesPerVertexArray;

			[WriteOnly]
			public NativeArray<VirtualMeshBoneWeight> boneWeights;

			public void Execute(int vindex)
			{
			}
		}

		[BurstCompile]
		private struct Import_BoneVertexJob : IJobParallelFor
		{
			public float4x4 WtoL;

			public float4x4 LtoW;

			[ReadOnly]
			public NativeArray<float3> transformPositions;

			[ReadOnly]
			public NativeArray<quaternion> transformRotations;

			[ReadOnly]
			public NativeArray<float3> transformScales;

			[WriteOnly]
			public NativeArray<float3> localPositions;

			[WriteOnly]
			public NativeArray<float3> localNormals;

			[WriteOnly]
			public NativeArray<float3> localTangents;

			[WriteOnly]
			public NativeArray<VirtualMeshBoneWeight> boneWeights;

			[WriteOnly]
			public NativeArray<float4x4> skinBoneBindPoses;

			public void Execute(int vindex)
			{
			}
		}

		[BurstCompile]
		private struct Select_PackVertexJob : IJob
		{
			public int vertexCount;

			[ReadOnly]
			public NativeArray<int> newVertexRemapIndices;

			[ReadOnly]
			public NativeArray<VertexAttribute> attributes;

			[ReadOnly]
			public NativeArray<float3> localPositions;

			[ReadOnly]
			public NativeArray<float3> localNormals;

			[ReadOnly]
			public NativeArray<float3> localTangents;

			[ReadOnly]
			public NativeArray<float2> uv;

			[ReadOnly]
			public NativeArray<VirtualMeshBoneWeight> boneWeights;

			[WriteOnly]
			public NativeArray<int> newReferenceIndices;

			[WriteOnly]
			public NativeArray<VertexAttribute> newAttributes;

			[WriteOnly]
			public NativeArray<float3> newLocalPositions;

			[WriteOnly]
			public NativeArray<float3> newLocalNormals;

			[WriteOnly]
			public NativeArray<float3> newLocalTangents;

			[WriteOnly]
			public NativeArray<float2> newUv;

			[WriteOnly]
			public NativeArray<VirtualMeshBoneWeight> newBoneWeights;

			public void Execute()
			{
			}
		}

		[BurstCompile]
		private struct Select_GridJob : IJob
		{
			public float gridSize;

			[ReadOnly]
			public NativeParallelMultiHashMap<int3, int> gridMap;

			public int selectionCount;

			[ReadOnly]
			public NativeArray<float3> selectionPositions;

			[ReadOnly]
			public NativeArray<VertexAttribute> selectionAttributes;

			public int vertexCount;

			public int triangleCount;

			public float searchRadius;

			[ReadOnly]
			public NativeArray<float3> meshPositions;

			[ReadOnly]
			public NativeArray<int3> meshTriangles;

			public NativeList<int3> newTriangles;

			public NativeArray<int> newVertexRemapIndices;

			[WriteOnly]
			public NativeReference<int> newVertexCount;

			public void Execute()
			{
			}
		}

		[BurstCompile]
		private struct Add_CalcBindPoseJob : IJobParallelFor
		{
			public int skinBoneOffset;

			[ReadOnly]
			public NativeArray<int> srcSkinBoneTransformIndices;

			[ReadOnly]
			public NativeArray<float3> srcTransformPositionArray;

			[ReadOnly]
			public NativeArray<quaternion> srcTransformRotationArray;

			[ReadOnly]
			public NativeArray<float3> srcTransformScaleArray;

			public float4x4 dstCenterLocalToWorldMatrix;

			[NativeDisableParallelForRestriction]
			[WriteOnly]
			public NativeArray<float4x4> dstSkinBoneBindPoses;

			public void Execute(int boneIndex)
			{
			}
		}

		[BurstCompile]
		private struct Add_CopyVerticesJob : IJobParallelFor
		{
			public int vertexOffset;

			public int skinBoneOffset;

			public float4x4 toM;

			[ReadOnly]
			public NativeArray<VertexAttribute> srcAttributes;

			[ReadOnly]
			public NativeArray<float3> srclocalPositions;

			[ReadOnly]
			public NativeArray<float3> srclocalNormals;

			[ReadOnly]
			public NativeArray<float3> srclocalTangents;

			[ReadOnly]
			public NativeArray<float2> srcUV;

			[ReadOnly]
			public NativeArray<VirtualMeshBoneWeight> srcBoneWeights;

			[NativeDisableParallelForRestriction]
			[WriteOnly]
			public NativeArray<VertexAttribute> dstAttributes;

			[NativeDisableParallelForRestriction]
			[WriteOnly]
			public NativeArray<float3> dstlocalPositions;

			[NativeDisableParallelForRestriction]
			[WriteOnly]
			public NativeArray<float3> dstlocalNormals;

			[NativeDisableParallelForRestriction]
			[WriteOnly]
			public NativeArray<float3> dstlocalTangents;

			[NativeDisableParallelForRestriction]
			[WriteOnly]
			public NativeArray<float2> dstUV;

			[NativeDisableParallelForRestriction]
			[WriteOnly]
			public NativeArray<VirtualMeshBoneWeight> dstBoneWeights;

			[ReadOnly]
			public NativeArray<int> dstSkinBoneIndices;

			public void Execute(int vindex)
			{
			}
		}

		private struct MappingWorkData
		{
			public float3 position;

			public int vertexIndex;

			public int proxyVertexIndex;

			public float proxyVertexDistance;
		}

		[BurstCompile]
		private struct Mapping_DirectConnectionVertexDataJob : IJob
		{
			public float4x4 toP;

			public int vcnt;

			public DataChunk mergeChunk;

			[ReadOnly]
			public NativeArray<float3> localPositions;

			[WriteOnly]
			public NativeArray<VertexAttribute> attributes;

			[ReadOnly]
			public NativeArray<int> joinIndices;

			[ReadOnly]
			public NativeArray<VertexAttribute> proxyAttributes;

			[ReadOnly]
			public NativeArray<float3> proxyLocalPositions;

			[WriteOnly]
			public NativeArray<MappingWorkData> mappingWorkData;

			public void Execute()
			{
			}
		}

		[BurstCompile]
		private struct Mapping_CalcDirectWeightJob : IJob
		{
			public int vcnt;

			public float weightLength;

			[ReadOnly]
			public NativeArray<MappingWorkData> mappingWorkData;

			[ReadOnly]
			public NativeArray<VertexAttribute> attributes;

			[WriteOnly]
			public NativeArray<VirtualMeshBoneWeight> boneWeights;

			[ReadOnly]
			public NativeArray<float3> proxyLocalPositions;

			[ReadOnly]
			public NativeArray<uint> proxyVertexToVertexIndexArray;

			[ReadOnly]
			public NativeArray<ushort> proxyVertexToVertexDataArray;

			public NativeParallelHashSet<ushort> useSet;

			public void Execute()
			{
			}
		}

		[BurstCompile]
		private struct Mapping_CalcConnectionVertexDataJob : IJob
		{
			public float gridSize;

			public float searchRadius;

			public float4x4 toP;

			public int vcnt;

			[ReadOnly]
			public NativeArray<float3> localPositions;

			[ReadOnly]
			public NativeArray<VirtualMeshBoneWeight> boneWeights;

			[ReadOnly]
			public NativeArray<MagicaObjectId> transformIds;

			[WriteOnly]
			public NativeArray<VertexAttribute> attributes;

			[ReadOnly]
			public NativeParallelMultiHashMap<int3, int> gridMap;

			[ReadOnly]
			public NativeArray<VertexAttribute> proxyAttributes;

			[ReadOnly]
			public NativeArray<float3> proxyLocalPositions;

			[ReadOnly]
			public NativeArray<VirtualMeshBoneWeight> proxyBoneWeights;

			[ReadOnly]
			public NativeArray<MagicaObjectId> proxyTransformIds;

			[WriteOnly]
			public NativeArray<MappingWorkData> mappingWorkData;

			public void Execute()
			{
			}
		}

		[BurstCompile]
		private struct Mapping_CalcWeightJob : IJobParallelFor
		{
			[ReadOnly]
			public NativeArray<MappingWorkData> mappingWorkData;

			public NativeArray<VertexAttribute> attributes;

			[WriteOnly]
			public NativeArray<VirtualMeshBoneWeight> boneWeights;

			[ReadOnly]
			public NativeArray<VertexAttribute> proxyAttributes;

			[ReadOnly]
			public NativeArray<float3> proxyLocalPositions;

			[ReadOnly]
			public NativeArray<float3> proxyLocalNormals;

			[ReadOnly]
			public NativeArray<uint> proxyVertexToVertexIndexArray;

			[ReadOnly]
			public NativeArray<ushort> proxyVertexToVertexDataArray;

			public void Execute(int vindex)
			{
			}
		}

		[BurstCompile]
		private struct Optimize_EdgeToTrianlgeJob : IJob
		{
			public int tcnt;

			[ReadOnly]
			public NativeArray<int3> triangles;

			[ReadOnly]
			public NativeArray<float3> localPositions;

			public NativeParallelHashMap<int2, FixedList128Bytes<int>> edgeToTriangleList;

			[WriteOnly]
			public NativeList<int3> newTriangles;

			public NativeParallelHashSet<int4> useQuadSet;

			public NativeParallelHashSet<int3> removeTriangleSet;

			public void Execute()
			{
			}
		}

		[BurstCompile]
		private struct ProxyNormalRadiationAdjustmentJob : IJobParallelFor
		{
			public float3 center;

			[ReadOnly]
			public NativeArray<float3> localPositions;

			public NativeArray<float3> localNormals;

			public NativeArray<float3> localTangents;

			[WriteOnly]
			public NativeArray<quaternion> normalAdjustmentRotations;

			public void Execute(int vindex)
			{
			}
		}

		[BurstCompile]
		private struct ProxyCreateFixedListAndAABBJob : IJob
		{
			public int vcnt;

			[ReadOnly]
			public NativeArray<VertexAttribute> attributes;

			[ReadOnly]
			public NativeArray<float3> localPositions;

			[ReadOnly]
			public NativeArray<uint> vertexToVertexIndexArray;

			[ReadOnly]
			public NativeArray<ushort> vertexToVertexDataArray;

			[WriteOnly]
			public NativeReference<AABB> outAABB;

			[WriteOnly]
			public NativeList<ushort> fixedList;

			[WriteOnly]
			public NativeReference<float3> localCenterPosition;

			public void Execute()
			{
			}
		}

		[BurstCompile]
		private struct Proxy_CalcTriangleNormalJob : IJobParallelFor
		{
			[ReadOnly]
			public NativeArray<int3> triangles;

			[ReadOnly]
			public NativeArray<float3> localPositins;

			[WriteOnly]
			public NativeArray<float3> triangleNormals;

			public void Execute(int tindex)
			{
			}
		}

		[BurstCompile]
		private struct Proxy_CalcTriangleTangentJob : IJobParallelFor
		{
			[ReadOnly]
			public NativeArray<int3> triangles;

			[ReadOnly]
			public NativeArray<float3> localPositins;

			[ReadOnly]
			public NativeArray<float2> uv;

			[WriteOnly]
			public NativeArray<float3> triangleTangents;

			public void Execute(int tindex)
			{
			}
		}

		[BurstCompile]
		private struct Proxy_CreateVertexToTrianglesJob : IJob
		{
			[ReadOnly]
			public NativeArray<int3> triangles;

			public NativeArray<FixedList32Bytes<uint>> vertexToTriangles;

			public void Execute()
			{
			}
		}

		[BurstCompile]
		private struct Proxy_OrganizeVertexToTrianglsJob : IJobParallelFor
		{
			public NativeArray<FixedList32Bytes<uint>> vertexToTriangles;

			[ReadOnly]
			public NativeArray<float3> triangleNormals;

			[ReadOnly]
			public NativeArray<float3> triangleTangents;

			public NativeArray<VertexAttribute> attributes;

			public void Execute(int vindex)
			{
			}
		}

		[BurstCompile]
		private struct Proxy_CalcVertexNormalTangentFromTriangleJob : IJobParallelFor
		{
			[ReadOnly]
			public NativeArray<float3> triangleNormals;

			[ReadOnly]
			public NativeArray<float3> triangleTangents;

			[ReadOnly]
			public NativeArray<FixedList32Bytes<uint>> vertexToTriangles;

			public NativeArray<float3> localNormals;

			public NativeArray<float3> localTangents;

			public void Execute(int vindex)
			{
			}
		}

		[BurstCompile]
		private struct Proxy_CalcVertexToTransformJob : IJobParallelFor
		{
			public quaternion invRot;

			[ReadOnly]
			public NativeArray<float3> localNormals;

			[ReadOnly]
			public NativeArray<float3> localTangents;

			[WriteOnly]
			public NativeArray<quaternion> vertexToTransformRotations;

			[ReadOnly]
			public NativeArray<quaternion> transformRotations;

			public void Execute(int vindex)
			{
			}
		}

		[BurstCompile]
		private struct Proxy_CalcEdgeToTriangleJob : IJob
		{
			public int tcnt;

			[ReadOnly]
			public NativeArray<int3> triangles;

			public NativeParallelMultiHashMap<int2, ushort> edgeToTriangles;

			public void Execute()
			{
			}
		}

		[BurstCompile]
		private struct Proxy_CalcVertexBindPoseJob2 : IJobParallelFor
		{
			[ReadOnly]
			public NativeArray<float3> localPositions;

			[ReadOnly]
			public NativeArray<float3> localNormals;

			[ReadOnly]
			public NativeArray<float3> localTangents;

			[WriteOnly]
			public NativeArray<float3> vertexBindPosePositions;

			[WriteOnly]
			public NativeArray<quaternion> vertexBindPoseRotations;

			public void Execute(int vindex)
			{
			}
		}

		[BurstCompile]
		private struct Proxy_CalcVertexToVertexFromTriangleJob : IJob
		{
			public int triangleCount;

			[ReadOnly]
			public NativeArray<int3> triangles;

			public NativeParallelMultiHashMap<int, ushort> vertexToVertexMap;

			public NativeParallelHashSet<int2> edgeSet;

			public void Execute()
			{
			}
		}

		[BurstCompile]
		private struct Proxy_CalcVertexToVertexFromLineJob : IJob
		{
			public int lineCount;

			[ReadOnly]
			public NativeArray<int2> lines;

			public NativeParallelMultiHashMap<int, ushort> vertexToVertexMap;

			public NativeParallelHashSet<int2> edgeSet;

			public void Execute()
			{
			}
		}

		[BurstCompile]
		private struct Proxy_CreateEdgeFlagJob : IJobParallelFor
		{
			[ReadOnly]
			public NativeArray<int2> edges;

			[ReadOnly]
			public NativeParallelMultiHashMap<int2, ushort> edgeToTriangles;

			[WriteOnly]
			public NativeArray<ExBitFlag8> edgeFlags;

			public void Execute(int eindex)
			{
			}
		}

		private struct SkinningBoneInfo
		{
			public int parentTransformIndex;

			public float3 parentPos;

			public int childTransformIndex;

			public float3 childPos;
		}

		[BurstCompile]
		private struct Proxy_CalcCustomSkinningWeightsJobV2 : IJobParallelFor
		{
			public bool isBoneCloth;

			public float angularAttenuation;

			public float distanceReduction;

			public float distancePow;

			[ReadOnly]
			public NativeArray<VertexAttribute> attributes;

			[ReadOnly]
			public NativeArray<float3> localPositions;

			[ReadOnly]
			public NativeList<SkinningBoneInfo> boneInfoList;

			[WriteOnly]
			public NativeArray<VirtualMeshBoneWeight> boneWeights;

			public void Execute(int vindex)
			{
			}
		}

		[BurstCompile]
		private struct Proxy_ApplySelectionJob : IJobParallelFor
		{
			public float gridSize;

			public float radius;

			[ReadOnly]
			public NativeArray<float3> localPositions;

			public NativeArray<VertexAttribute> attributes;

			[ReadOnly]
			public NativeParallelMultiHashMap<int3, int> gridMap;

			[ReadOnly]
			public NativeArray<float3> selectionPositions;

			[ReadOnly]
			public NativeArray<VertexAttribute> selectionAttributes;

			public void Execute(int vindex)
			{
			}
		}

		[BurstCompile]
		private struct Proxy_BoneClothApplayTransformFlagJob : IJobParallelFor
		{
			[ReadOnly]
			public NativeArray<VertexAttribute> attributes;

			public NativeArray<ExBitFlag8> transformFlags;

			public void Execute(int vindex)
			{
			}
		}

		private struct BaseLineWork : IComparable<BaseLineWork>
		{
			public int vindex;

			public float dist;

			public int CompareTo(BaseLineWork other)
			{
				return 0;
			}
		}

		[BurstCompile]
		private struct BaseLine_Mesh_CreateParentJob2 : IJob
		{
			public int vcnt;

			public float avgDist;

			[ReadOnly]
			public NativeArray<VertexAttribute> attribues;

			[ReadOnly]
			public NativeArray<float3> localPositions;

			[ReadOnly]
			public NativeArray<uint> vertexToVertexIndexArray;

			[ReadOnly]
			public NativeArray<ushort> vertexToVertexDataArray;

			public NativeArray<int> vertexParentIndices;

			public NativeParallelMultiHashMap<int, ushort> vertexChildMap;

			[ReadOnly]
			public NativeList<int> fixedList;

			public NativeList<BaseLineWork> nextList;

			public NativeArray<byte> markBuff;

			public NativeParallelHashMap<int, BaseLineWork> vertexMap;

			public void Execute()
			{
			}
		}

		[BurstCompile]
		private struct BaseLine_Mesh_CareteFixedListJob : IJob
		{
			public int vcnt;

			[ReadOnly]
			public NativeArray<VertexAttribute> attribues;

			public NativeList<int> fixedList;

			public void Execute()
			{
			}
		}

		[BurstCompile]
		private struct BaseLine_Bone_CreateBoneChildInfoJob : IJob
		{
			public int vcnt;

			[ReadOnly]
			public NativeArray<int> parentIndices;

			public NativeParallelMultiHashMap<int, ushort> childMap;

			public void Execute()
			{
			}
		}

		[BurstCompile]
		private struct BaseLine_CalcLocalPositionRotationJob : IJobParallelFor
		{
			[NativeDisableParallelForRestriction]
			public NativeArray<VertexAttribute> attributes;

			[ReadOnly]
			public NativeArray<int> parentIndices;

			[ReadOnly]
			public NativeArray<float3> localPositions;

			[ReadOnly]
			public NativeArray<float3> localNormals;

			[ReadOnly]
			public NativeArray<float3> localTangents;

			[ReadOnly]
			public NativeArray<ushort> baseLineIndices;

			[NativeDisableParallelForRestriction]
			[WriteOnly]
			public NativeArray<float3> vertexLocalPositions;

			[NativeDisableParallelForRestriction]
			[WriteOnly]
			public NativeArray<quaternion> vertexLocalRotations;

			public void Execute(int index)
			{
			}
		}

		[BurstCompile]
		private struct BaseLine_CalcMaxBaseLineLengthJob : IJob
		{
			public int vcnt;

			[ReadOnly]
			public NativeArray<VertexAttribute> attribues;

			[ReadOnly]
			public NativeArray<float3> localPositions;

			[ReadOnly]
			public NativeArray<int> vertexParentIndices;

			[WriteOnly]
			public NativeArray<float> vertexDepths;

			[WriteOnly]
			public NativeArray<int> vertexRootIndices;

			public NativeArray<float> rootLengthArray;

			public void Execute()
			{
			}
		}

		[BurstCompile]
		private struct Reduction_InitVertexToVertexJob2 : IJob
		{
			public int triangleCount;

			[ReadOnly]
			public NativeArray<int3> triangles;

			public NativeParallelMultiHashMap<ushort, ushort> vertexToVertexMap;

			public void Execute()
			{
			}
		}

		[BurstCompile]
		private struct Organize_RemapVertexJob : IJob
		{
			public int oldVertexCount;

			[ReadOnly]
			public NativeArray<int> joinIndices;

			public NativeArray<int> vertexRemapIndices;

			public void Execute()
			{
			}
		}

		[BurstCompile]
		private struct Organize_CollectUseSkinBoneJob : IJob
		{
			public int oldVertexCount;

			[ReadOnly]
			public NativeArray<int> joinIndices;

			[ReadOnly]
			public NativeArray<VirtualMeshBoneWeight> oldBoneWeights;

			[ReadOnly]
			public NativeArray<float4x4> oldBindPoses;

			public NativeParallelHashMap<int, int> useSkinBoneMap;

			public NativeList<int> newSkinBoneTransformIndices;

			public NativeList<float4x4> newSkinBoneBindPoses;

			public NativeReference<int> newSkinBoneCount;

			public NativeList<int> useSkinBoneMapKeyList;

			public void Execute()
			{
			}
		}

		[BurstCompile]
		private struct Organize_CopyVertexJob : IJobParallelFor
		{
			[ReadOnly]
			public NativeArray<int> joinIndices;

			[ReadOnly]
			public NativeArray<int> vertexRemapIndices;

			[ReadOnly]
			public NativeArray<VertexAttribute> oldAttributes;

			[ReadOnly]
			public NativeArray<float3> oldLocalPositions;

			[ReadOnly]
			public NativeArray<float3> oldLocalNormals;

			[ReadOnly]
			public NativeArray<float3> oldLocalTangents;

			[NativeDisableParallelForRestriction]
			[WriteOnly]
			public NativeArray<VertexAttribute> newAttributes;

			[NativeDisableParallelForRestriction]
			[WriteOnly]
			public NativeArray<float3> newLocalPositions;

			[NativeDisableParallelForRestriction]
			[WriteOnly]
			public NativeArray<float3> newLocalNormals;

			[NativeDisableParallelForRestriction]
			[WriteOnly]
			public NativeArray<float3> newLocalTangents;

			public void Execute(int index)
			{
			}
		}

		[BurstCompile]
		private struct Organize_RemapBoneWeightJob : IJobParallelFor
		{
			[ReadOnly]
			public NativeArray<int> joinIndices;

			[ReadOnly]
			public NativeArray<int> vertexRemapIndices;

			[ReadOnly]
			public NativeParallelHashMap<int, int> useSkinBoneMap;

			[ReadOnly]
			public NativeArray<int> oldSkinBoneIndices;

			[ReadOnly]
			public NativeArray<VirtualMeshBoneWeight> oldBoneWeights;

			[NativeDisableParallelForRestriction]
			[WriteOnly]
			public NativeArray<VirtualMeshBoneWeight> newBoneWeights;

			public void Execute(int vindex)
			{
			}
		}

		[BurstCompile]
		private struct Organize_RemapLinkPointArrayJob : IJobParallelFor
		{
			[ReadOnly]
			public NativeArray<int> joinIndices;

			[ReadOnly]
			public NativeArray<int> vertexRemapIndices;

			[ReadOnly]
			public NativeParallelMultiHashMap<ushort, ushort> oldVertexToVertexMap;

			[NativeDisableParallelForRestriction]
			public NativeParallelMultiHashMap<ushort, ushort> newVertexToVertexMap;

			public void Execute(int vindex)
			{
			}
		}

		[BurstCompile]
		private struct Organize_CreateLineTriangleJob : IJob
		{
			public int newVertexCount;

			[ReadOnly]
			public NativeParallelMultiHashMap<ushort, ushort> newVertexToVertexMap;

			[WriteOnly]
			public NativeParallelHashSet<int2> edgeSet;

			public void Execute()
			{
			}
		}

		[BurstCompile]
		private struct Organize_CreateLineTriangleJob2 : IJob
		{
			[ReadOnly]
			public NativeParallelMultiHashMap<ushort, ushort> newVertexToVertexMap;

			[WriteOnly]
			public NativeList<int2> newLineList;

			[ReadOnly]
			public NativeParallelHashSet<int2> edgeSet;

			[WriteOnly]
			public NativeParallelHashSet<int3> triangleSet;

			public void Execute()
			{
			}
		}

		[BurstCompile]
		private struct Organize_CreateNewTriangleJob3 : IJob
		{
			[WriteOnly]
			public NativeList<int3> newTriangleList;

			[ReadOnly]
			public NativeParallelHashSet<int3> triangleSet;

			public void Execute()
			{
			}
		}

		[Serializable]
		public class ShareSerializationData
		{
			public string name;

			public MeshType meshType;

			public bool isBoneCloth;

			public ExSimpleNativeArray<int>.SerializationData referenceIndices;

			public ExSimpleNativeArray<VertexAttribute>.SerializationData attributes;

			public ExSimpleNativeArray<float3>.SerializationData localPositions;

			public ExSimpleNativeArray<float3>.SerializationData localNormals;

			public ExSimpleNativeArray<float3>.SerializationData localTangents;

			public ExSimpleNativeArray<float2>.SerializationData uv;

			public ExSimpleNativeArray<VirtualMeshBoneWeight>.SerializationData boneWeights;

			public ExSimpleNativeArray<int3>.SerializationData triangles;

			public ExSimpleNativeArray<int2>.SerializationData lines;

			public int centerTransformIndex;

			public float4x4 initLocalToWorld;

			public float4x4 initWorldToLocal;

			public quaternion initRotation;

			public quaternion initInverseRotation;

			public float3 initScale;

			public int skinRootIndex;

			public ExSimpleNativeArray<int>.SerializationData skinBoneTransformIndices;

			public ExSimpleNativeArray<float4x4>.SerializationData skinBoneBindPoses;

			public TransformData.ShareSerializationData transformData;

			public AABB boundingBox;

			public float averageVertexDistance;

			public float maxVertexDistance;

			public byte[] vertexToTriangles;

			public byte[] vertexToVertexIndexArray;

			public byte[] vertexToVertexDataArray;

			public byte[] edges;

			public byte[] edgeFlags;

			public int2[] edgeToTrianglesKeys;

			public ushort[] edgeToTrianglesValues;

			public byte[] vertexBindPosePositions;

			public byte[] vertexBindPoseRotations;

			public byte[] vertexToTransformRotations;

			public byte[] vertexDepths;

			public byte[] vertexRootIndices;

			public byte[] vertexParentIndices;

			public byte[] vertexChildIndexArray;

			public byte[] vertexChildDataArray;

			public byte[] vertexLocalPositions;

			public byte[] vertexLocalRotations;

			public byte[] normalAdjustmentRotations;

			public byte[] baseLineFlags;

			public byte[] baseLineStartDataIndices;

			public byte[] baseLineDataCounts;

			public byte[] baseLineData;

			public int[] customSkinningBoneIndices;

			public ushort[] centerFixedList;

			public float3 localCenterPosition;

			public float3 centerWorldPosition;

			public quaternion centerWorldRotation;

			public float3 centerWorldScale;

			public float4x4 toProxyMatrix;

			public quaternion toProxyRotation;

			public override string ToString()
			{
				return null;
			}
		}

		[Serializable]
		public class UniqueSerializationData : ITransform
		{
			public TransformData.UniqueSerializationData transformData;

			public void GetUsedTransform(HashSet<Transform> transformSet)
			{
			}

			public void ReplaceTransform(Dictionary<MagicaObjectId, Transform> replaceDict)
			{
			}
		}

		[BurstCompile]
		private struct Work_AverageTriangleDistanceJob : IJob
		{
			public int vcnt;

			public int tcnt;

			[ReadOnly]
			public NativeArray<float3> localPositions;

			[ReadOnly]
			public NativeArray<int3> triangles;

			public NativeReference<float> averageVertexDistance;

			public NativeReference<int> averageCount;

			public NativeReference<float> maxVertexDistance;

			public void Execute()
			{
			}
		}

		[BurstCompile]
		private struct Work_AverageLineDistanceJob : IJob
		{
			public int vcnt;

			public int lcnt;

			[ReadOnly]
			public NativeArray<float3> localPositions;

			[ReadOnly]
			public NativeArray<int2> lines;

			public NativeReference<float> averageVertexDistance;

			public NativeReference<int> averageCount;

			public NativeReference<float> maxVertexDistance;

			public void Execute()
			{
			}
		}

		[BurstCompile]
		private struct Work_AddVertexIndexGirdMapJob : IJob
		{
			public float gridSize;

			public int vcnt;

			[ReadOnly]
			public NativeArray<float3> positins;

			[WriteOnly]
			public NativeParallelMultiHashMap<int3, int> gridMap;

			public void Execute()
			{
			}
		}

		[BurstCompile]
		private struct Work_IntersectTriangleJob : IJobParallelFor
		{
			public float3 localRayPos;

			public float3 localRayDir;

			public float3 localRayEndPos;

			public bool doubleSide;

			[ReadOnly]
			public NativeArray<float3> localPositions;

			[ReadOnly]
			public NativeArray<int3> triangles;

			[WriteOnly]
			public NativeList<VirtualMeshRaycastHit>.ParallelWriter hitList;

			public void Execute(int tindex)
			{
			}
		}

		[BurstCompile]
		private struct Work_IntersectEdgeJob : IJobParallelFor
		{
			public float3 localRayPos;

			public float3 localRayDir;

			public float3 localRayEndPos;

			public float3 rayDir;

			public float localEdgeRadius;

			[ReadOnly]
			public NativeArray<float3> localPositions;

			[ReadOnly]
			public NativeArray<int2> edges;

			[ReadOnly]
			public NativeParallelMultiHashMap<int2, ushort> edgeToTriangles;

			[WriteOnly]
			public NativeList<VirtualMeshRaycastHit>.ParallelWriter hitList;

			public void Execute(int eindex)
			{
			}
		}

		[BurstCompile]
		private struct Work_IntersectPointJob : IJobParallelFor
		{
			public float3 localRayPos;

			public float3 localRayDir;

			public float3 rayDir;

			public float localPointRadius;

			[ReadOnly]
			public NativeArray<float3> localPositions;

			[ReadOnly]
			public NativeArray<FixedList32Bytes<int>> vertexToTriangles;

			[WriteOnly]
			public NativeList<VirtualMeshRaycastHit>.ParallelWriter hitList;

			public void Execute(int vindex)
			{
			}
		}

		[BurstCompile]
		private struct Work_IntersetcSortJob : IJob
		{
			public NativeList<VirtualMeshRaycastHit> hitList;

			public void Execute()
			{
			}
		}

		public enum MeshType
		{
			NormalMesh = 0,
			NormalBoneMesh = 1,
			ProxyMesh = 2,
			ProxyBoneMesh = 3,
			Mapping = 4
		}

		public string name;

		public ResultCode result;

		public bool isManaged;

		public MeshType meshType;

		public bool isBoneCloth;

		public ExSimpleNativeArray<int> referenceIndices;

		public ExSimpleNativeArray<VertexAttribute> attributes;

		public ExSimpleNativeArray<float3> localPositions;

		public ExSimpleNativeArray<float3> localNormals;

		public ExSimpleNativeArray<float3> localTangents;

		public ExSimpleNativeArray<float2> uv;

		public ExSimpleNativeArray<VirtualMeshBoneWeight> boneWeights;

		public ExSimpleNativeArray<int3> triangles;

		public ExSimpleNativeArray<int2> lines;

		public int centerTransformIndex;

		public float4x4 initLocalToWorld;

		public float4x4 initWorldToLocal;

		public quaternion initRotation;

		public quaternion initInverseRotation;

		public float3 initScale;

		public int skinRootIndex;

		public ExSimpleNativeArray<int> skinBoneTransformIndices;

		public ExSimpleNativeArray<float4x4> skinBoneBindPoses;

		public TransformData transformData;

		public NativeReference<AABB> boundingBox;

		public NativeReference<float> averageVertexDistance;

		public NativeReference<float> maxVertexDistance;

		public DataChunk mergeChunk;

		public NativeArray<int> joinIndices;

		public NativeArray<FixedList32Bytes<uint>> vertexToTriangles;

		public NativeArray<uint> vertexToVertexIndexArray;

		public NativeArray<ushort> vertexToVertexDataArray;

		public NativeArray<int2> edges;

		public const byte EdgeFlag_Cut = 1;

		public NativeArray<ExBitFlag8> edgeFlags;

		public NativeParallelMultiHashMap<int2, ushort> edgeToTriangles;

		public NativeArray<float3> vertexBindPosePositions;

		public NativeArray<quaternion> vertexBindPoseRotations;

		public NativeArray<quaternion> vertexToTransformRotations;

		public NativeArray<float> vertexDepths;

		public NativeArray<int> vertexRootIndices;

		public NativeArray<int> vertexParentIndices;

		public NativeArray<uint> vertexChildIndexArray;

		public NativeArray<ushort> vertexChildDataArray;

		public NativeArray<float3> vertexLocalPositions;

		public NativeArray<quaternion> vertexLocalRotations;

		public NativeArray<quaternion> normalAdjustmentRotations;

		public const byte BaseLineFlag_IncludeLine = 1;

		public NativeArray<ExBitFlag8> baseLineFlags;

		public NativeArray<ushort> baseLineStartDataIndices;

		public NativeArray<ushort> baseLineDataCounts;

		public NativeArray<ushort> baseLineData;

		public int[] customSkinningBoneIndices;

		public ushort[] centerFixedList;

		public NativeReference<float3> localCenterPosition;

		public VirtualMesh mappingProxyMesh;

		public float3 centerWorldPosition;

		public quaternion centerWorldRotation;

		public float3 centerWorldScale;

		public float4x4 toProxyMatrix;

		public quaternion toProxyRotation;

		public int mappingId;

		public float InitCalcScale => 0f;

		public bool IsSuccess => false;

		public bool IsError => false;

		public bool IsProcess => false;

		public int VertexCount => 0;

		public int TriangleCount => 0;

		public int LineCount => 0;

		public int SkinBoneCount => 0;

		public int TransformCount => 0;

		public bool IsProxy => false;

		public bool IsMapping => false;

		public int BaseLineCount => 0;

		public int EdgeCount => 0;

		public int CustomSkinningBoneCount => 0;

		public int CenterFixedPointCount => 0;

		public int NormalAdjustmentRotationCount => 0;

		public void ImportFrom(RenderSetupData rsetup, int uvChannel)
		{
		}

		private void ImportMeshType(RenderSetupData rsetup, int[] transformIndices, int uvChannel)
		{
		}

		private void ImportMeshSkinning()
		{
		}

		private void ImportBoneType(RenderSetupData rsetup, int[] transformIndices)
		{
		}

		public void ImportFrom(RenderData renderData, int uvChannel)
		{
		}

		public void SelectionMesh(SelectionData selectionData, float4x4 selectionLocalToWorldMatrix, float mergin)
		{
		}

		public float CalcSelectionMergin(ReductionSettings settings)
		{
			return 0f;
		}

		public void AddMesh(VirtualMesh cmesh)
		{
		}

		public void SetTransform(Transform center, Transform skinRoot, MagicaObjectId centerId, MagicaObjectId skinRootId)
		{
		}

		public void SetTransform(TransformRecord centerRecord, TransformRecord skinRootRecord = null)
		{
		}

		public void SetCenterTransform(Transform t, MagicaObjectId tid)
		{
		}

		public void SetSkinRoot(Transform t, MagicaObjectId tid)
		{
		}

		public Transform GetCenterTransform()
		{
			return null;
		}

		public void SetCustomSkinningBones(TransformRecord clothTransformRecord, List<TransformRecord> bones)
		{
		}

		public bool CompareSpace(VirtualMesh target)
		{
			return false;
		}

		public float4x4 CenterTransformTo(VirtualMesh to)
		{
			return default(float4x4);
		}

		public void Mapping(VirtualMesh proxyMesh)
		{
		}

		private static float4 CalcVertexWeights(float4 distances)
		{
			return default(float4);
		}

		public void Optimization()
		{
		}

		private void RemoveDuplicateTriangles()
		{
		}

		private bool CheckTwoTriangleOpen(in int3 tri1, in int3 tri2, in int2 edge, in float3 tri1n)
		{
			return false;
		}

		private float CalcTwoTriangleAngle(in int3 tri1, in int3 tri2, in int2 edge)
		{
			return 0f;
		}

		public void ConvertProxyMesh(ClothSerializeData sdata, TransformRecord clothTransformRecord, List<TransformRecord> customSkinningBoneRecords, TransformRecord normalAdjustmentTransformRecord)
		{
		}

		private void ProxyNormalAdjustment(ClothSerializeData sdata, TransformRecord normalAdjustmentTransformRecord)
		{
		}

		private void ProxyCreateFixedListAndAABB()
		{
		}

		private void OptimizeTriangleDirection(NativeArray<float3> triangleNormals, float sameSurfaceAngle)
		{
		}

		private void CreateCustomSkinning(CustomSkinningSettings setting, List<TransformRecord> bones)
		{
		}

		public void ApplySelectionAttribute(SelectionData selectionData)
		{
		}

		private void CreateMeshBaseLine()
		{
		}

		private void CreateTransformBaseLine()
		{
		}

		private void CreateBaseLinePose()
		{
		}

		private void CreateVertexRootAndDepth()
		{
		}

		public void Reduction(ReductionSettings settings, CancellationToken ct)
		{
		}

		private void InitReductionWorkData(ReductionWorkData workData)
		{
		}

		private void Organization(ReductionSettings setting, ReductionWorkData workData)
		{
		}

		private void OrganizationInit(ReductionSettings setting, ReductionWorkData workData)
		{
		}

		private void OrganizationCreateRemapData(ReductionWorkData workData)
		{
		}

		private void OrganizationCreateBasicData(ReductionWorkData workData)
		{
		}

		private void OrganizationCreateLineTriangle(ReductionWorkData workData)
		{
		}

		private void OrganizeStoreVirtualMesh(ReductionWorkData workData)
		{
		}

		public ShareSerializationData ShareSerialize()
		{
			return null;
		}

		public static VirtualMesh ShareDeserialize(ShareSerializationData sdata)
		{
			return null;
		}

		public UniqueSerializationData UniqueSerialize()
		{
			return null;
		}

		internal void CalcAverageAndMaxVertexDistanceRun()
		{
		}

		internal GridMap<int> CreateVertexIndexGridMapRun(float gridSize)
		{
			return null;
		}

		public VirtualMeshRaycastHit IntersectRayMesh(float3 rayPos, float3 rayDir, bool doubleSide, float pointRadius)
		{
			return default(VirtualMeshRaycastHit);
		}

		public VirtualMesh()
		{
		}

		public VirtualMesh(bool initialize)
		{
		}

		public VirtualMesh(string name)
		{
		}

		public void Dispose()
		{
		}

		public void SetName(string newName)
		{
		}

		public bool IsValid()
		{
			return false;
		}

		public override string ToString()
		{
			return null;
		}
	}
}
