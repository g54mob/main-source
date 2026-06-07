using System;
using Unity.Jobs;

namespace Assets.Scripts.Craft.Wings.Physics
{
	public interface IAeroForceProducer
	{
		bool Enabled { get; }

		(JobHandle Handle, IntPtr ResultPtr) ScheduleJobs();

		void OnJobsCompleted();
	}
}
