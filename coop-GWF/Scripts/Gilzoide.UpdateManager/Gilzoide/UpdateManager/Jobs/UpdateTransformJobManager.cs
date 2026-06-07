using Gilzoide.UpdateManager.Jobs.Internal;
using Unity.Jobs;
using UnityEngine.Jobs;

namespace Gilzoide.UpdateManager.Jobs
{
	public class UpdateTransformJobManager<TData> : AUpdateJobManager<TData, ITransformJobUpdatable<TData>, UpdateTransformJobData<TData, ITransformJobUpdatable<TData>>> where TData : struct, IUpdateTransformJob
	{
		public static readonly int JobBatchSize = UpdateJobOptions.GetBatchSize<TData>();

		public static readonly bool ReadOnlyTransformAccess = UpdateJobOptions.GetReadOnlyTransformAccess<TData>();

		private static UpdateTransformJobManager<TData> _instance;

		public static UpdateTransformJobManager<TData> Instance
		{
			get
			{
				if (_instance == null)
				{
					return _instance = new UpdateTransformJobManager<TData>();
				}
				return _instance;
			}
		}

		protected override JobHandle ScheduleJob(JobHandle dependsOn)
		{
			if (AUpdateJobManager<TData, ITransformJobUpdatable<TData>, UpdateTransformJobData<TData, ITransformJobUpdatable<TData>>>.IsJobBurstCompiled)
			{
				return Schedule<BurstUpdateTransformJob<TData>>(dependsOn);
			}
			return Schedule<UpdateTransformJob<TData>>(dependsOn);
		}

		protected JobHandle Schedule<TJob>(JobHandle dependsOn) where TJob : struct, IInternalUpdateTransformJob<TData>
		{
			TJob jobData = new TJob
			{
				Data = _jobData.Data
			};
			if (!ReadOnlyTransformAccess)
			{
				return jobData.Schedule(_jobData.Transforms, dependsOn);
			}
			return jobData.ScheduleReadOnly(_jobData.Transforms, JobBatchSize, dependsOn);
		}
	}
}
