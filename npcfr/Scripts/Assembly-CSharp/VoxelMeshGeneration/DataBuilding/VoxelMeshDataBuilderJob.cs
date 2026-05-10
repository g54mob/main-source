using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;
using VoxelMeshGeneration.Chunks;

namespace VoxelMeshGeneration.DataBuilding
{
	[BurstCompile]
	public struct VoxelMeshDataBuilderJob : IJob
	{
		[ReadOnly]
		private readonly VoxelMesh.Voxels m_voxels;

		private readonly float3 m_meshDisplacement;

		private readonly VoxelMeshChunkData m_chunkData;

		private readonly VoxelMeshData m_meshData;

		[WriteOnly]
		private NativeArray<VoxelMeshData.Counter> m_outputCounter;

		public VoxelMeshDataBuilderJob(VoxelMesh.Voxels voxels, Vector3 meshDisplacement, VoxelMeshChunkData chunkData, NativeArray<VoxelMeshVertex> vertexes, NativeArray<ushort> indexes, VoxelMeshData.Counter inputCounter, NativeArray<VoxelMeshData.Counter> outputCounter)
		{
			m_voxels = default(VoxelMesh.Voxels);
			m_meshDisplacement = default(float3);
			m_chunkData = default(VoxelMeshChunkData);
			m_meshData = default(VoxelMeshData);
			m_outputCounter = default(NativeArray<VoxelMeshData.Counter>);
		}

		public void Execute()
		{
		}
	}
}
