using System.Collections.Generic;
using NSEipix.Repository;
using NSMedieval.Model;
using NSMedieval.State.WorkerJobs;

namespace NSMedieval.Repository
{
	public class JobRepository : DynamicJsonRepository<JobRepository, Job>
	{
		private List<Job> sortedJobs;

		private Dictionary<JobType, Job> jobsByType;

		private readonly Dictionary<string, List<Job>> jobsByPriority = new Dictionary<string, List<Job>>();

		private readonly HashSet<string> jobGoalNames = new HashSet<string>();

		public bool IsJobGoal(string goalId)
		{
			return jobGoalNames.Contains(goalId);
		}

		public Job GetByJobType(JobType id)
		{
			if (!jobsByType.ContainsKey(id))
			{
				return null;
			}
			return jobsByType[id];
		}

		public List<Job> GetWorkerJobs()
		{
			return jobsByPriority["worker"];
		}

		public List<Job> GetCaptiveLabourerJobs()
		{
			return jobsByPriority["captiveLabourer"];
		}

		public override void Deserialize()
		{
			base.Deserialize();
			jobsByType = new Dictionary<JobType, Job>();
			foreach (Job allItem in GetAllItems())
			{
				jobsByType.Add(allItem.JobType, allItem);
				string[] goals = allItem.Goals;
				foreach (string item in goals)
				{
					jobGoalNames.Add(item);
				}
			}
			foreach (JobPriority allItem2 in Repository<JobPriorityRepository, JobPriority>.Instance.GetAllItems())
			{
				List<Job> list = new List<Job>();
				JobType[] array = allItem2.JobsByPriority;
				foreach (JobType id in array)
				{
					list.Add(GetByJobType(id));
				}
				jobsByPriority.Add(allItem2.GetID(), list);
			}
		}

		protected override string JsonFile()
		{
			return "GOAP/Job.json";
		}
	}
}
