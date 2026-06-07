using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;

namespace AwesomeTechnologies.VegetationSystem
{
	[BurstCompile(CompileSynchronously = true)]
	public struct MergeCellInstancesJob : IJob
	{
		public NativeList<MatrixInstance> OutputNativeList;

		[ReadOnly]
		public NativeList<MatrixInstance> InputNativeList;

		public void Execute()
		{
			for (int i = 0; i <= InputNativeList.Length - 1; i++)
			{
				OutputNativeList.Add(InputNativeList[i]);
			}
		}
	}
}
