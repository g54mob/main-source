using NSEipix.Repository;

namespace NSMedieval.BuildingComponents
{
	public class BellComponentRepository : DynamicJsonRepository<BellComponentRepository, BellComponentBlueprint>
	{
		protected override string JsonFile()
		{
			return "Constructables/BellComponentRepository.json";
		}
	}
}
