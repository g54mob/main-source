using NSEipix.Repository;

namespace NSMedieval.BuildingComponents
{
	public class RoofComponentRepository : DynamicJsonRepository<RoofComponentRepository, RoofComponentBlueprint>
	{
		protected override string JsonFile()
		{
			return "Constructables/RoofComponentsRepository.json";
		}
	}
}
