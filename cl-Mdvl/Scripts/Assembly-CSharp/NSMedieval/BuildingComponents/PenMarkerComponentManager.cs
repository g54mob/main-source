using NSMedieval.Village.Map;

namespace NSMedieval.BuildingComponents
{
	public class PenMarkerComponentManager : ComponentBaseManager<PenMarkerComponent, PenMarkerComponentInstance>
	{
		public PenMarkerComponentManager(VillageMap map)
			: base(map)
		{
		}
	}
}
