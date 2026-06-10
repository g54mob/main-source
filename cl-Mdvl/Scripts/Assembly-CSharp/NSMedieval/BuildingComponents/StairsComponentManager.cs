using NSMedieval.Village.Map;

namespace NSMedieval.BuildingComponents
{
	public class StairsComponentManager : ComponentBaseManager<StairsComponent, StairsComponentInstance>
	{
		public StairsComponentManager(VillageMap map)
			: base(map)
		{
		}
	}
}
