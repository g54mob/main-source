using NSEipix.Repository;

namespace NSMedieval.BuildingComponents
{
	public class DoorComponentRepository : DynamicJsonRepository<DoorComponentRepository, DoorComponentBlueprint>
	{
		protected override string JsonFile()
		{
			return "Constructables/DoorComponentRepository.json";
		}
	}
}
