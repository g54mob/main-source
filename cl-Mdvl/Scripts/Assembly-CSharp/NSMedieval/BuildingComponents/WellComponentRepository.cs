using NSEipix.Repository;

namespace NSMedieval.BuildingComponents
{
	public class WellComponentRepository : DynamicJsonRepository<WellComponentRepository, WellComponentBlueprint>
	{
		protected override string JsonFile()
		{
			return "Constructables/WellComponentRepository.json";
		}
	}
}
