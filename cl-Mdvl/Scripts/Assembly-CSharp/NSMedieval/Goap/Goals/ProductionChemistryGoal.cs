using NSMedieval.State.WorkerJobs;

namespace NSMedieval.Goap.Goals
{
	public class ProductionChemistryGoal : ProductionBaseGoal
	{
		public ProductionChemistryGoal(Agent selfAgent)
			: base("ProductionChemistryGoal", selfAgent, JobType.Alchemy)
		{
		}
	}
}
