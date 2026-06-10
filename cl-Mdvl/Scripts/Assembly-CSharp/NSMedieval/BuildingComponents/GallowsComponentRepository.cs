using NSEipix.Repository;

namespace NSMedieval.BuildingComponents
{
	public class GallowsComponentRepository : DynamicJsonRepository<GallowsComponentRepository, GallowsComponentBlueprint>
	{
		protected override string JsonFile()
		{
			return "Constructables/GallowsComponentRepository.json";
		}
	}
}
