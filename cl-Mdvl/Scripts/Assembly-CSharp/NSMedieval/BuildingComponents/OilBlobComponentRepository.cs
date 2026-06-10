using NSEipix.Repository;

namespace NSMedieval.BuildingComponents
{
	public class OilBlobComponentRepository : DynamicJsonRepository<OilBlobComponentRepository, OilBlobComponentBlueprint>
	{
		protected override string JsonFile()
		{
			return "Constructables/OilBlobComponentRepository.json";
		}
	}
}
