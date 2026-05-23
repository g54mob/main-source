using System.Collections.Generic;
using Unity.Jobs;

namespace Pathfinding.Jobs
{
	public struct JobHandleWithMainThreadWork<T> where T : struct
	{
		private JobDependencyTracker tracker;

		private IEnumerator<(JobHandle, T)> coroutine;

		public JobHandleWithMainThreadWork(IEnumerator<(JobHandle, T)> handles, JobDependencyTracker tracker)
		{
			coroutine = handles;
			this.tracker = tracker;
		}

		public void Complete()
		{
			tracker.timeSlice = TimeSlice.Infinite;
			while (coroutine.MoveNext())
			{
				coroutine.Current.Item1.Complete();
			}
		}

		public IEnumerable<T?> CompleteTimeSliced(float maxMillisPerStep)
		{
			tracker.timeSlice = TimeSlice.MillisFromNow(maxMillisPerStep);
			while (coroutine.MoveNext())
			{
				if (maxMillisPerStep < float.PositiveInfinity)
				{
					while (!coroutine.Current.Item1.IsCompleted)
					{
						yield return null;
						tracker.timeSlice = TimeSlice.MillisFromNow(maxMillisPerStep);
					}
				}
				coroutine.Current.Item1.Complete();
				yield return coroutine.Current.Item2;
				tracker.timeSlice = TimeSlice.MillisFromNow(maxMillisPerStep);
			}
		}
	}
}
