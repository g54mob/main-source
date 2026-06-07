using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;

namespace Digger.Modules.Core.Sources.Generators
{
	public interface IVoxelGenerator
	{
		JobHandle GenerateVoxels(float[] heightArray, int3 chunkPosition, int sizeVox, float3 heightmapScale, NativeArray<float> heights, NativeArray<Voxel> voxels, bool refreshOnly);
	}
}
