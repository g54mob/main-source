using NSEipix.Repository;

namespace NSMedieval.BuildingComponents
{
	public class RugComponentRepository : DynamicJsonRepository<RugComponentRepository, RugComponentBlueprint>
	{
		protected override string JsonFile()
		{
			return "Constructables/RugComponentRepository.json";
		}
	}
}
