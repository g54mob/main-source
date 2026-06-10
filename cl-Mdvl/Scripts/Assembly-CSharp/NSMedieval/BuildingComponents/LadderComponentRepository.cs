using NSEipix.Repository;

namespace NSMedieval.BuildingComponents
{
	public class LadderComponentRepository : DynamicJsonRepository<LadderComponentRepository, LadderComponentBlueprint>
	{
		protected override string JsonFile()
		{
			return "Constructables/LadderComponentRepository.json";
		}
	}
}
