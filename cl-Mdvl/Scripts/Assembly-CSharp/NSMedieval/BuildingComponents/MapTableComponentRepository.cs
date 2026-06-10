using NSEipix.Repository;

namespace NSMedieval.BuildingComponents
{
	public class MapTableComponentRepository : DynamicJsonRepository<MapTableComponentRepository, MapTableComponentBlueprint>
	{
		protected override string JsonFile()
		{
			return "Constructables/MapTableComponentRepository.json";
		}
	}
}
