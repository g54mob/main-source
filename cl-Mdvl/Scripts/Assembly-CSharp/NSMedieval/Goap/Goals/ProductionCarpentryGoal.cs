using NSMedieval.State.WorkerJobs;

namespace NSMedieval.Goap.Goals
{
	public class ProductionCarpentryGoal : ProductionBaseGoal
	{
		public ProductionCarpentryGoal(Agent selfAgent)
			: base("ProductionCarpentryGoal", selfAgent, JobType.Carpentry)
		{
		}
	}
}
