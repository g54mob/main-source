using NSMedieval.Village.Map;

namespace NSMedieval.BuildingComponents
{
	public class BellComponentManager : ComponentBaseManager<BellComponent, BellComponentInstance>
	{
		public BellComponentManager(VillageMap map)
			: base(map)
		{
		}
	}
}
