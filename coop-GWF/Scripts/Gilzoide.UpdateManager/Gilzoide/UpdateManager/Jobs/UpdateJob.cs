using Gilzoide.UpdateManager.Jobs.Internal;
using Unity.Jobs;

namespace Gilzoide.UpdateManager.Jobs
{
	public struct UpdateJob<TData> : IInternalUpdateJob<TData>, IJobParallelFor where TData : struct, IUpdateJob
	{
		public UnsafeNativeList<TData> Data { get; set; }

		public void Execute(int index)
		{
			Data.ItemRefAt(index).Execute();
		}
	}
}
