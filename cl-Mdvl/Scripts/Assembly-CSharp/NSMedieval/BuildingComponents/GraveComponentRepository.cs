using NSEipix.Repository;

namespace NSMedieval.BuildingComponents
{
	public class GraveComponentRepository : DynamicJsonRepository<GraveComponentRepository, GraveComponentBlueprint>
	{
		protected override string JsonFile()
		{
			return "Constructables/GraveComponentsRepository.json";
		}
	}
}
