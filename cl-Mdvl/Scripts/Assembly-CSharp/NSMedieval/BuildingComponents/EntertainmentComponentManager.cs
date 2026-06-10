using NSMedieval.Village.Map;

namespace NSMedieval.BuildingComponents
{
	public class EntertainmentComponentManager : ComponentBaseManager<EntertainmentComponent, EntertainmentComponentInstance>
	{
		public EntertainmentComponentManager(VillageMap map)
			: base(map)
		{
		}
	}
}
