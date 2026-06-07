using Unity.Jobs;

namespace Digger.Modules.Core.Sources.VoxelPhysics
{
	public struct LinkLabelOfNeighborChunksXJobData
	{
		public LinkLabelOfNeighborChunksXJob Job;

		public JobHandle Handle;

		public VoxelChunk Chunk1;

		public VoxelChunk Chunk2;
	}
}
