using NSEipix.Repository;
using NSMedieval.Model;

namespace NSMedieval.Repository
{
	public class JobPriorityRepository : DynamicJsonRepository<JobPriorityRepository, JobPriority>
	{
		public const string WorkerPriorityId = "worker";

		public const string CaptiveLabourerPriorityId = "captiveLabourer";

		protected override string JsonFile()
		{
			return "GOAP/JobPriority.json";
		}
	}
}
