using NSEipix.Repository;

namespace NSMedieval.BuildingComponents
{
	public class CaravanPostComponentRepository : DynamicJsonRepository<CaravanPostComponentRepository, CaravanPostComponentBlueprint>
	{
		protected override string JsonFile()
		{
			return "Constructables/CaravanPostComponentRepository.json";
		}
	}
}
