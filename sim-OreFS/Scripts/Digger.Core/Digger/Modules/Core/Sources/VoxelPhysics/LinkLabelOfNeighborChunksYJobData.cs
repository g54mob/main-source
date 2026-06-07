using Unity.Jobs;

namespace Digger.Modules.Core.Sources.VoxelPhysics
{
	public struct LinkLabelOfNeighborChunksYJobData
	{
		public LinkLabelOfNeighborChunksYJob Job;

		public JobHandle Handle;

		public VoxelChunk Chunk1;

		public VoxelChunk Chunk2;
	}
}
