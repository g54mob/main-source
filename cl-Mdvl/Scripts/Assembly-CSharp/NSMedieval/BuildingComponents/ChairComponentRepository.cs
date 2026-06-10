using NSEipix.Repository;

namespace NSMedieval.BuildingComponents
{
	public class ChairComponentRepository : DynamicJsonRepository<ChairComponentRepository, ChairComponentBlueprint>
	{
		protected override string JsonFile()
		{
			return "Constructables/ChairComponentRepository.json";
		}
	}
}
