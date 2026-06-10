using NSEipix.Repository;

namespace NSMedieval.BuildingComponents
{
	public class SlopeBuildingComponentRepository : DynamicJsonRepository<SlopeBuildingComponentRepository, SlopeBuildingComponentBlueprint>
	{
		protected override string JsonFile()
		{
			return "Constructables/SlopeBuildingComponentRepository.json";
		}
	}
}
