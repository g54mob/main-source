using NSMedieval.State;

namespace NSMedieval.Manager
{
	public class PlantUpdateManager : FixedCountTicker<PlantMapResourceInstance>
	{
		protected override int UpdateEntitiesPerFrame => 8;
	}
}
