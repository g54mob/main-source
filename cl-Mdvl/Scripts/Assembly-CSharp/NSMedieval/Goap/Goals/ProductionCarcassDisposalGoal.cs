using NSMedieval.State.WorkerJobs;

namespace NSMedieval.Goap.Goals
{
	public class ProductionCarcassDisposalGoal : ProductionBaseGoal
	{
		public ProductionCarcassDisposalGoal(Agent selfAgent)
			: base("ProductionCarcassDisposalGoal", selfAgent, JobType.Hauling)
		{
		}
	}
}
