using NSMedieval.Village.Map;

namespace NSMedieval.BuildingComponents
{
	public class DecorationComponentManager : ComponentBaseManager<DecorationComponent, DecorationComponentInstance>
	{
		public DecorationComponentManager(VillageMap map)
			: base(map)
		{
		}
	}
}
