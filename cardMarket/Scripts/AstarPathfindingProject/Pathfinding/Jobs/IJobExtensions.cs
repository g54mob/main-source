using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.Jobs;

namespace Pathfinding.Jobs
{
	public static class IJobExtensions
	{
		private struct ManagedJob : IJob
		{
			public GCHandle handle;

			public void Execute()
			{
				((IJob)handle.Target).Execute();
				handle.Free();
			}
		}

		private struct ManagedActionJob : IJob
		{
			public GCHandle handle;

			public void Execute()
			{
				((Action)handle.Target)();
				handle.Free();
			}
		}

		public static JobHandle Schedule<T>(this T data, JobDependencyTracker tracker) where T : struct, IJob
		{
			if (tracker.forceLinearDependencies)
			{
				Unity.Jobs.IJobExtensions.Run(data);
				return default(JobHandle);
			}
			JobHandle jobHandle = Unity.Jobs.IJobExtensions.Schedule(data, JobDependencyAnalyzer<T>.GetDependencies(ref data, tracker));
			JobDependencyAnalyzer<T>.Scheduled(ref data, tracker, jobHandle);
			return jobHandle;
		}

		public static JobHandle ScheduleBatch<T>(this T data, int arrayLength, int minIndicesPerJobCount, JobDependencyTracker tracker, JobHandle additionalDependency = default(JobHandle)) where T : struct, IJobParallelForBatched
		{
			if (tracker.forceLinearDependencies)
			{
				additionalDependency.Complete();
				data.RunBatch(arrayLength);
				return default(JobHandle);
			}
			JobHandle jobHandle = data.ScheduleBatch(arrayLength, minIndicesPerJobCount, JobDependencyAnalyzer<T>.GetDependencies(ref data, tracker, additionalDependency));
			JobDependencyAnalyzer<T>.Scheduled(ref data, tracker, jobHandle);
			return jobHandle;
		}

		public static JobHandle ScheduleManaged<T>(this T data, JobHandle dependsOn) where T : struct, IJob
		{
			return Unity.Jobs.IJobExtensions.Schedule(new ManagedJob
			{
				handle = GCHandle.Alloc(data)
			}, dependsOn);
		}

		public static JobHandle ScheduleManaged(this Action data, JobHandle dependsOn)
		{
			return Unity.Jobs.IJobExtensions.Schedule(new ManagedActionJob
			{
				handle = GCHandle.Alloc(data)
			}, dependsOn);
		}

		public static JobHandle GetDependencies<T>(this T data, JobDependencyTracker tracker) where T : struct, IJob
		{
			if (tracker.forceLinearDependencies)
			{
				return default(JobHandle);
			}
			return JobDependencyAnalyzer<T>.GetDependencies(ref data, tracker);
		}

		public static IEnumerator<JobHandle> ExecuteMainThreadJob<T>(this T data, JobDependencyTracker tracker) where T : struct, IJobTimeSliced
		{
			if (tracker.forceLinearDependencies)
			{
				data.Execute();
				yield break;
			}
			yield return JobDependencyAnalyzer<T>.GetDependencies(ref data, tracker);
			while (!data.Execute(tracker.timeSlice))
			{
				yield return default(JobHandle);
			}
		}
	}
}
