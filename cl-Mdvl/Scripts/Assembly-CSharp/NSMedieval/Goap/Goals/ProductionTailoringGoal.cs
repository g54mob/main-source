using NSMedieval.State.WorkerJobs;

namespace NSMedieval.Goap.Goals
{
	public class ProductionTailoringGoal : ProductionBaseGoal
	{
		public ProductionTailoringGoal(Agent selfAgent)
			: base("ProductionTailoringGoal", selfAgent, JobType.Tailoring)
		{
		}
	}
}
