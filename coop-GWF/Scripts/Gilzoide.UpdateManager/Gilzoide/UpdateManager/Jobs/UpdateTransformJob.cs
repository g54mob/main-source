using Gilzoide.UpdateManager.Jobs.Internal;
using UnityEngine.Jobs;

namespace Gilzoide.UpdateManager.Jobs
{
	public struct UpdateTransformJob<TData> : IInternalUpdateTransformJob<TData>, IJobParallelForTransform where TData : struct, IUpdateTransformJob
	{
		public UnsafeNativeList<TData> Data { get; set; }

		public void Execute(int index, TransformAccess transform)
		{
			Data.ItemRefAt(index).Execute(transform);
		}
	}
}
