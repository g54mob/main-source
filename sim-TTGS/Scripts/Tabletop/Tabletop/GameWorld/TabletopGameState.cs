using Simulator.GameWorld;

namespace Tabletop.GameWorld
{
	public class TabletopGameState : GameState
	{
		public override void TriggerXPRewardEvent(ESimulatorXPRewardEvent rewardEvent, int count = 1)
		{
			foreach (var (type, num) in XPSettings.GetSimulatorRewards(rewardEvent))
			{
				GainXP(type, num * count);
			}
		}

		public void TriggerTabletopXPRewardEvent(ETabletopXPRewardEvent rewardEvent, int count = 1)
		{
			foreach (var (type, num) in XPSettings.GetTabletopRewards(rewardEvent))
			{
				GainXP(type, num * count);
			}
		}

		public override void CheckoutProduct(Product product)
		{
			if (product is MiniatureProduct miniatureProduct)
			{
				TriggerTabletopXPRewardEvent(miniatureProduct.Painted ? ETabletopXPRewardEvent.SELL_PAINTED_MINIATURE : ETabletopXPRewardEvent.SELL_MINIATURE);
			}
			else
			{
				base.CheckoutProduct(product);
			}
		}
	}
}
