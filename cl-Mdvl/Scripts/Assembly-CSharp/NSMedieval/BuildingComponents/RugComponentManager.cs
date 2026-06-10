using NSMedieval.Village.Map;

namespace NSMedieval.BuildingComponents
{
	public class RugComponentManager : ComponentBaseManager<RugComponent, RugComponentInstance>
	{
		public RugComponentManager(VillageMap map)
			: base(map)
		{
		}
	}
}
