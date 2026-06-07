using Gilzoide.UpdateManager.Jobs.Internal;
using Unity.Burst;
using Unity.Jobs;

namespace Gilzoide.UpdateManager.Jobs
{
	[BurstCompile]
	public struct BurstUpdateJob<TData> : IInternalUpdateJob<TData>, IJobParallelFor, IInternalBurstUpdateJob where TData : struct, IUpdateJob
	{
		public UnsafeNativeList<TData> Data { get; set; }

		public void Execute(int index)
		{
			Data.ItemRefAt(index).Execute();
		}
	}
}
