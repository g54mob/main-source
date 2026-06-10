using NSEipix.Repository;

namespace NSMedieval.BuildingComponents
{
	public class StairsComponentRepository : DynamicJsonRepository<StairsComponentRepository, StairsComponentBlueprint>
	{
		protected override string JsonFile()
		{
			return "Constructables/StairsComponentRepository.json";
		}
	}
}
