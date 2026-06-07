using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;

namespace AwesomeTechnologies.Utility.Culling
{
	[BurstCompile(CompileSynchronously = true)]
	internal struct BoundingSphereEventJob : IJobParallelForFilter
	{
		[ReadOnly]
		public NativeArray<BoundingSphereInfo> BoundingSphereInfoList;

		public bool Execute(int index)
		{
			if (BoundingSphereInfoList[index].LastVisisbility != BoundingSphereInfoList[index].Visibility)
			{
				return true;
			}
			return false;
		}
	}
}
