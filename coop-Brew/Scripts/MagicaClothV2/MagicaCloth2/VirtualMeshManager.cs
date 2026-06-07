using System;
using System.Text;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

namespace MagicaCloth2
{
	public class VirtualMeshManager : IManager, IDisposable, IValid
	{
		[BurstCompile]
		private struct CalcMeshConvert_A_Job : IJobParallelFor
		{
			[ReadOnly]
			public NativeArray<TeamManager.TeamData> teamDataArray;

			[ReadOnly]
			public NativeArray<float3> transformPositionArray;

			[ReadOnly]
			public NativeArray<quaternion> transformRotationArray;

			[ReadOnly]
			public NativeArray<float3> transformScaleArray;

			public NativeArray<TeamManager.MappingData> mappingDataArray;

			[ReadOnly]
			public NativeArray<RenderManager.RenderDataWork> renderDataWorkArray;

			public void Execute(int index)
			{
			}
		}

		[BurstCompile]
		private struct CalcMeshConvert_B_Job : IJobParallelFor
		{
			public int workerCount;

			[ReadOnly]
			public NativeArray<TeamManager.TeamData> teamDataArray;

			[ReadOnly]
			public NativeArray<TeamManager.MappingData> mappingDataArray;

			[ReadOnly]
			public NativeArray<VertexAttribute> mappingAttributes;

			[ReadOnly]
			public NativeArray<float3> mappingLocalPositions;

			[ReadOnly]
			public NativeArray<float3> mappingLocalNormals;

			[ReadOnly]
			public NativeArray<float3> mappingLocalTangents;

			[ReadOnly]
			public NativeArray<VirtualMeshBoneWeight> mappingBoneWeights;

			[ReadOnly]
			public NativeArray<int> mappingReferenceIndices;

			[ReadOnly]
			public NativeArray<float3> proxyPositions;

			[ReadOnly]
			public NativeArray<quaternion> proxyRotations;

			[ReadOnly]
			public NativeArray<float3> proxyVertexBindPosePositions;

			[ReadOnly]
			public NativeArray<quaternion> proxyVertexBindPoseRotations;

			[ReadOnly]
			public NativeArray<RenderManager.RenderDataWork> renderDataWorkArray;

			[NativeDisableParallelForRestriction]
			[WriteOnly]
			public NativeArray<float3> renderMeshPositions;

			[NativeDisableParallelForRestriction]
			[WriteOnly]
			public NativeArray<float3> renderMeshNormals;

			[NativeDisableParallelForRestriction]
			public NativeArray<float4> renderMeshTangents;

			[NativeDisableParallelForRestriction]
			[WriteOnly]
			public NativeArray<BoneWeight> renderMeshBoneWeights;

			public void Execute(int dataIndex)
			{
			}
		}

		[BurstCompile]
		private struct PostRenderMeshWorkDataBatchJob : IJobParallelFor
		{
			public NativeArray<RenderManager.RenderDataWork> renderDataWorkArray;

			[NativeDisableParallelForRestriction]
			public NativeArray<TeamManager.MappingData> mappingDataArray;

			public void Execute(int windex)
			{
			}
		}

		public ExNativeArray<short> teamIds;

		public ExNativeArray<VertexAttribute> attributes;

		public ExNativeArray<FixedList32Bytes<uint>> vertexToTriangles;

		public ExNativeArray<float3> vertexBindPosePositions;

		public ExNativeArray<quaternion> vertexBindPoseRotations;

		public ExNativeArray<float> vertexDepths;

		public ExNativeArray<int> vertexRootIndices;

		public ExNativeArray<float3> vertexLocalPositions;

		public ExNativeArray<quaternion> vertexLocalRotations;

		public ExNativeArray<int> vertexParentIndices;

		public ExNativeArray<uint> vertexChildIndexArray;

		public ExNativeArray<ushort> vertexChildDataArray;

		public ExNativeArray<quaternion> normalAdjustmentRotations;

		public ExNativeArray<float2> uv;

		public ExNativeArray<short> triangleTeamIdArray;

		public ExNativeArray<int3> triangles;

		public ExNativeArray<float3> triangleNormals;

		public ExNativeArray<float3> triangleTangents;

		public ExNativeArray<short> edgeTeamIdArray;

		public ExNativeArray<int2> edges;

		public ExNativeArray<ExBitFlag8> edgeFlags;

		public ExNativeArray<ExBitFlag8> baseLineFlags;

		public ExNativeArray<short> baseLineTeamIds;

		public ExNativeArray<ushort> baseLineStartDataIndices;

		public ExNativeArray<ushort> baseLineDataCounts;

		public ExNativeArray<ushort> baseLineData;

		public ExNativeArray<float3> localPositions;

		public ExNativeArray<float3> localNormals;

		public ExNativeArray<float3> localTangents;

		public ExNativeArray<VirtualMeshBoneWeight> boneWeights;

		public ExNativeArray<int> skinBoneTransformIndices;

		public ExNativeArray<float4x4> skinBoneBindPoses;

		public ExNativeArray<quaternion> vertexToTransformRotations;

		public ExNativeArray<float3> positions;

		public ExNativeArray<quaternion> rotations;

		public ExNativeArray<short> mappingIdArray;

		public ExNativeArray<int> mappingReferenceIndices;

		public ExNativeArray<VertexAttribute> mappingAttributes;

		public ExNativeArray<float3> mappingLocalPositins;

		public ExNativeArray<float3> mappingLocalNormals;

		public ExNativeArray<float3> mappingLocalTangents;

		public ExNativeArray<VirtualMeshBoneWeight> mappingBoneWeights;

		private bool isValid;

		public int ProxyVertexCount => 0;

		public int ProxyTriangleCount => 0;

		public int ProxyEdgeCount => 0;

		public int ProxyBaseLineCount => 0;

		public int ProxyLocalPositionCount => 0;

		public int MappingVertexCount => 0;

		public void Dispose()
		{
		}

		public void EnterdEditMode()
		{
		}

		public void Initialize()
		{
		}

		public bool IsValid()
		{
			return false;
		}

		public void RegisterProxyMesh(int teamId, VirtualMeshContainer proxyMeshContainer)
		{
		}

		public void ExitProxyMesh(int teamId)
		{
		}

		public DataChunk RegisterMappingMesh(int teamId, VirtualMeshContainer mappingMeshContainer, int renderDataWorkIndex)
		{
			return default(DataChunk);
		}

		public void ExitMappingMesh(int teamId, int mappingIndex)
		{
		}

		internal static void SimulationPreProxyMeshUpdate(DataChunk chunk, int teamId, ref TeamManager.TeamData tdata, in NativeArray<VertexAttribute> attributes, in NativeArray<float3> localPositions, in NativeArray<float3> localNormals, in NativeArray<float3> localTangents, in NativeArray<VirtualMeshBoneWeight> boneWeights, in NativeArray<int> skinBoneTransformIndices, in NativeArray<float4x4> skinBoneBindPoses, ref NativeArray<float3> positions, ref NativeArray<quaternion> rotations, in NativeArray<float4x4> transformLocalToWorldMatrixArray)
		{
		}

		internal static void SimulationPostProxyMeshUpdateLine(DataChunk chunk, ref TeamManager.TeamData tdata, ref ClothParameters param, ref NativeArray<VertexAttribute> attributes, ref NativeArray<float3> positions, ref NativeArray<quaternion> rotations, ref NativeArray<float3> vertexLocalPositions, ref NativeArray<quaternion> vertexLocalRotations, ref NativeArray<uint> vertexChildIndexArray, ref NativeArray<ushort> vertexChildDataArray, ref NativeArray<ExBitFlag8> baseLineFlags, ref NativeArray<ushort> baseLineStartIndices, ref NativeArray<ushort> baseLineDataCounts, ref NativeArray<ushort> baseLineData, ref NativeArray<float3> tempVectorBufferA, ref NativeArray<quaternion> tempRotationBufferA)
		{
		}

		internal static void SimulationPostProxyMeshUpdateTriangle(DataChunk chunk, ref TeamManager.TeamData tdata, ref NativeArray<float3> positions, ref NativeArray<int3> triangles, ref NativeArray<float3> triangleNormals, ref NativeArray<float3> triangleTangents, ref NativeArray<float2> uvs)
		{
		}

		internal static void SimulationPostProxyMeshUpdateTriangleSum(DataChunk chunk, ref TeamManager.TeamData tdata, ref NativeArray<quaternion> rotations, ref NativeArray<float3> triangleNormals, ref NativeArray<float3> triangleTangents, ref NativeArray<FixedList32Bytes<uint>> vertexToTriangles, ref NativeArray<quaternion> normalAdjustmentRotations)
		{
		}

		internal static void SimulationPostProxyMeshUpdateWorldTransform(DataChunk chunk, ref TeamManager.TeamData tdata, ref NativeArray<float3> positions, ref NativeArray<quaternion> rotations, ref NativeArray<quaternion> vertexToTransformRotations, ref NativeArray<float3> transformPositionArray, ref NativeArray<quaternion> transformRotationArray)
		{
		}

		internal static void SimulationPostProxyMeshUpdateLocalTransform(ref TeamManager.TeamData tdata, ref NativeArray<VertexAttribute> attributes, ref NativeArray<int> parentIndices, ref NativeArray<float3> transformPositionArray, ref NativeArray<quaternion> transformRotationArray, ref NativeArray<float3> transformScaleArray, ref NativeArray<float3> transformLocalPositionArray, ref NativeArray<quaternion> transformLocalRotationArray)
		{
		}

		internal JobHandle PostMappingMeshUpdateBatchSchedule(JobHandle jobHandle, int workerCount)
		{
			return default(JobHandle);
		}

		public void InformationLog(StringBuilder allsb)
		{
		}
	}
}
