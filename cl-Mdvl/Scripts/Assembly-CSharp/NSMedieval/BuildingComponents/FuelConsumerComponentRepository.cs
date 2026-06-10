using NSEipix.Repository;

namespace NSMedieval.BuildingComponents
{
	public class FuelConsumerComponentRepository : DynamicJsonRepository<FuelConsumerComponentRepository, FuelConsumerComponentBlueprint>
	{
		protected override string JsonFile()
		{
			return "Constructables/FuelConsumerComponentRepository.json";
		}
	}
}
