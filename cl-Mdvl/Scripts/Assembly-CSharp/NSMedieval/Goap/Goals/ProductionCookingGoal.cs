using NSMedieval.State.WorkerJobs;

namespace NSMedieval.Goap.Goals
{
	public class ProductionCookingGoal : ProductionBaseGoal
	{
		public ProductionCookingGoal(Agent selfAgent)
			: base("ProductionCookingGoal", selfAgent, JobType.Cooking)
		{
		}
	}
}
