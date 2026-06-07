using Gilzoide.UpdateManager.Jobs.Internal;
using Unity.Jobs;

namespace Gilzoide.UpdateManager.Jobs
{
	public class UpdateJobManager<TData> : AUpdateJobManager<TData, IJobUpdatable<TData>, UpdateJobData<TData, IJobUpdatable<TData>>> where TData : struct, IUpdateJob
	{
		public static readonly int JobBatchSize = UpdateJobOptions.GetBatchSize<TData>();

		private static UpdateJobManager<TData> _instance;

		public static UpdateJobManager<TData> Instance
		{
			get
			{
				if (_instance == null)
				{
					return _instance = new UpdateJobManager<TData>();
				}
				return _instance;
			}
		}

		protected override JobHandle ScheduleJob(JobHandle dependsOn)
		{
			if (AUpdateJobManager<TData, IJobUpdatable<TData>, UpdateJobData<TData, IJobUpdatable<TData>>>.IsJobBurstCompiled)
			{
				return Schedule<BurstUpdateJob<TData>>(dependsOn);
			}
			return Schedule<UpdateJob<TData>>(dependsOn);
		}

		protected JobHandle Schedule<TJob>(JobHandle dependsOn) where TJob : struct, IInternalUpdateJob<TData>
		{
			return new TJob
			{
				Data = _jobData.Data
			}.Schedule(_jobData.Length, JobBatchSize, dependsOn);
		}
	}
}
