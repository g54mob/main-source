using NSMedieval.Village.Map;

namespace NSMedieval.BuildingComponents
{
	public class GallowsComponentManager : ComponentBaseManager<GallowsComponent, GallowsComponentInstance>
	{
		public GallowsComponentManager(VillageMap map)
			: base(map)
		{
		}
	}
}
