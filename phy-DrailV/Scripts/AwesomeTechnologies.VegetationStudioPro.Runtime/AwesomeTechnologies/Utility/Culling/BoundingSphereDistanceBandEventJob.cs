using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;

namespace AwesomeTechnologies.Utility.Culling
{
	[BurstCompile(CompileSynchronously = true)]
	internal struct BoundingSphereDistanceBandEventJob : IJobParallelForFilter
	{
		[ReadOnly]
		public NativeArray<BoundingSphereInfo> BoundingSphereInfoList;

		public bool Execute(int index)
		{
			if (BoundingSphereInfoList[index].CurrentDistanceBand != BoundingSphereInfoList[index].PreviousDistanceBand)
			{
				return true;
			}
			return false;
		}
	}
}
