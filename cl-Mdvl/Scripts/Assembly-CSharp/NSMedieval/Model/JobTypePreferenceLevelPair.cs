using System;
using NSMedieval.State.WorkerJobs;

namespace NSMedieval.Model
{
	[Serializable]
	public class JobTypePreferenceLevelPair : SerializablePair<JobType, int>
	{
		public JobTypePreferenceLevelPair()
		{
		}

		public JobTypePreferenceLevelPair(JobType jobType, int preferenceLevel)
			: base(jobType, preferenceLevel)
		{
		}
	}
}
