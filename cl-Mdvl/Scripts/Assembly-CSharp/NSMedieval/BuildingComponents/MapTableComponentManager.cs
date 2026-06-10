using NSMedieval.Village.Map;

namespace NSMedieval.BuildingComponents
{
	public class MapTableComponentManager : ComponentBaseManager<MapTableComponent, MapTableComponentInstance>
	{
		public MapTableComponentManager(VillageMap map)
			: base(map)
		{
		}
	}
}
