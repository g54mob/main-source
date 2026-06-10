using NSEipix.Repository;

namespace NSMedieval.BuildingComponents
{
	public class ShelfComponentRepository : DynamicJsonRepository<ShelfComponentRepository, ShelfComponentBlueprint>
	{
		protected override string JsonFile()
		{
			return "Constructables/ShelfComponentRepository.json";
		}
	}
}
