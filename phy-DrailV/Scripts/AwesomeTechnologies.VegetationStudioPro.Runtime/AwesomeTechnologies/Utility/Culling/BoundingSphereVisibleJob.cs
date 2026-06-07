using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;

namespace AwesomeTechnologies.Utility.Culling
{
	[BurstCompile(CompileSynchronously = true)]
	internal struct BoundingSphereVisibleJob : IJobParallelForFilter
	{
		[ReadOnly]
		public NativeArray<BoundingSphereInfo> BoundingSphereInfoList;

		public bool Execute(int index)
		{
			if (BoundingSphereInfoList[index].Visibility == 1 && BoundingSphereInfoList[index].CurrentDistanceBand != -1)
			{
				return true;
			}
			return false;
		}
	}
}
