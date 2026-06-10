using NSMedieval.State;

namespace NSMedieval.Goap.Goals
{
	public class StockpileUrgentHaulingGoal : StockpileHaulingGoal
	{
		public StockpileUrgentHaulingGoal(Agent selfAgent)
			: base("StockpileUrgentHaulingGoal", selfAgent)
		{
		}

		protected override bool ShouldConsiderPile(ResourcePileInstance pileInstance)
		{
			if (pileInstance.IsUrgentHaul)
			{
				return pileInstance.OwnedByPlayer();
			}
			return false;
		}
	}
}
