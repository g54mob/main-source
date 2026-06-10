using NSMedieval.Village.Map;

namespace NSMedieval.BuildingComponents
{
	public class TradingPostComponentManager : ComponentBaseManager<TradingPostComponent, TradingPostComponentInstance>
	{
		public TradingPostComponentManager(VillageMap map)
			: base(map)
		{
		}
	}
}
