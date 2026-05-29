using Unity.Jobs.LowLevel.Unsafe;

namespace Pathfinding.Jobs
{
	[JobProducerType(typeof(JobParallelForBatchedExtensions.ParallelForBatchJobStruct<>))]
	public interface IJobParallelForBatched
	{
		bool allowBoundsChecks { get; }

		void Execute(int startIndex, int count);
	}
}
