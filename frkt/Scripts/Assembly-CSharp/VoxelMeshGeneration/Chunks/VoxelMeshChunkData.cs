using Unity.Mathematics;

namespace VoxelMeshGeneration.Chunks
{
	public struct VoxelMeshChunkData
	{
		public readonly int3 startIndex;

		public readonly int3 endIndex;

		public readonly int chunkIndex;

		public VoxelMeshChunkData(int3 startIndex, int3 endIndex, int chunkIndex)
		{
			this.startIndex = default(int3);
			this.endIndex = default(int3);
			this.chunkIndex = 0;
		}
	}
}
