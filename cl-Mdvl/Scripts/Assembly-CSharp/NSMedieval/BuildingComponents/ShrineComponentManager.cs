using NSMedieval.Village.Map;

namespace NSMedieval.BuildingComponents
{
	public class ShrineComponentManager : ComponentBaseManager<ShrineComponent, ShrineComponentInstance>
	{
		public ShrineComponentManager(VillageMap map)
			: base(map)
		{
		}
	}
}
