using NSMedieval.State.WorkerJobs;

namespace NSMedieval.Goap.Goals
{
	public class ProductionCraftingGoal : ProductionBaseGoal
	{
		public ProductionCraftingGoal(Agent selfAgent)
			: base("ProductionCraftingGoal", selfAgent, JobType.Crafting)
		{
		}
	}
}
