using NSMedieval.State.WorkerJobs;

namespace NSMedieval.Goap.Goals
{
	public class ProductionAnimalGoal : ProductionBaseGoal
	{
		public ProductionAnimalGoal(Agent selfAgent)
			: base("ProductionAnimalGoal", selfAgent, JobType.Animal)
		{
		}
	}
}
