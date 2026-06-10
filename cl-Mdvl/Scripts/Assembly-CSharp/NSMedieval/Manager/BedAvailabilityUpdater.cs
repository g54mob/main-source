using NSMedieval.BuildingComponents;

namespace NSMedieval.Manager
{
	public class BedAvailabilityUpdater : FixedCountTicker<BedComponentInstance>
	{
		protected override int UpdateEntitiesPerFrame => 2;
	}
}
