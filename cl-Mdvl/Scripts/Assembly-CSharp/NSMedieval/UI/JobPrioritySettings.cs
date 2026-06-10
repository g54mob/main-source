using NSMedieval.State.WorkerJobs;

namespace NSMedieval.UI
{
	public class JobPrioritySettings
	{
		public JobType GetJobType { get; }

		public int GetPriority { get; }

		public bool GetJobActive { get; }

		public JobPrioritySettings(JobType jobType, int priority, bool jobActive)
		{
			GetJobType = jobType;
			GetPriority = priority;
			GetJobActive = jobActive;
		}
	}
}
