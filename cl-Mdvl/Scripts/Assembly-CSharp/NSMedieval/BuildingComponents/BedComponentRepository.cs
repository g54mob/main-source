using NSEipix.Repository;

namespace NSMedieval.BuildingComponents
{
	public class BedComponentRepository : DynamicJsonRepository<BedComponentRepository, BedComponentBlueprint>
	{
		protected override string JsonFile()
		{
			return "Constructables/BedComponentsRepository.json";
		}
	}
}
