using Gilzoide.UpdateManager.Jobs.Internal;
using Unity.Burst;
using UnityEngine.Jobs;

namespace Gilzoide.UpdateManager.Jobs
{
	[BurstCompile]
	public struct BurstUpdateTransformJob<TData> : IInternalUpdateTransformJob<TData>, IJobParallelForTransform, IInternalBurstUpdateTransformJob where TData : struct, IUpdateTransformJob
	{
		public UnsafeNativeList<TData> Data { get; set; }

		public void Execute(int index, TransformAccess transform)
		{
			Data.ItemRefAt(index).Execute(transform);
		}
	}
}
