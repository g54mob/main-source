using NSMedieval.State.WorkerJobs;

namespace NSMedieval.Goap.Goals
{
	public class ProductionResearchGoal : ProductionBaseGoal
	{
		public ProductionResearchGoal(Agent selfAgent)
			: base("ProductionResearchGoal", selfAgent, JobType.Research)
		{
		}
	}
}
