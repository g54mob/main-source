using NSMedieval.State.WorkerJobs;

namespace NSMedieval.Goap.Goals
{
	public class ProductionSmithingGoal : ProductionBaseGoal
	{
		public ProductionSmithingGoal(Agent selfAgent)
			: base("ProductionSmithingGoal", selfAgent, JobType.Smithing)
		{
		}
	}
}
