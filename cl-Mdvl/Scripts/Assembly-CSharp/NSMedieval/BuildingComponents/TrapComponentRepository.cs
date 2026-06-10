using NSEipix.Repository;

namespace NSMedieval.BuildingComponents
{
	public class TrapComponentRepository : DynamicJsonRepository<TrapComponentRepository, TrapComponentBlueprint>
	{
		protected override string JsonFile()
		{
			return "Constructables/TrapComponentsRepository.json";
		}
	}
}
