using NSMedieval.State.WorkerJobs;

namespace NSMedieval.Goap.Goals
{
	public class ProductionArtGoal : ProductionBaseGoal
	{
		public ProductionArtGoal(Agent selfAgent)
			: base("ProductionArtGoal", selfAgent, JobType.Art)
		{
		}
	}
}
