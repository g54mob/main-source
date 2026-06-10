using NSEipix.Repository;

namespace NSMedieval.BuildingComponents
{
	public class TradingPostComponentRepository : DynamicJsonRepository<TradingPostComponentRepository, TradingPostComponentBlueprint>
	{
		protected override string JsonFile()
		{
			return "Constructables/TradingPostComponentRepository.json";
		}
	}
}
