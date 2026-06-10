using NSMedieval.StatsSystem;

namespace NSMedieval.Manager
{
	public class DecayModifierManager : FixedCountTicker<DecayModifier>
	{
		protected override int UpdateEntitiesPerFrame => 15;
	}
}
