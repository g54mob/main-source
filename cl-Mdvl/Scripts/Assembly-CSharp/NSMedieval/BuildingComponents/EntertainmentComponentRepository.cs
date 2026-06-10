using NSEipix.Repository;

namespace NSMedieval.BuildingComponents
{
	public class EntertainmentComponentRepository : DynamicJsonRepository<EntertainmentComponentRepository, EntertainmentComponentBlueprint>
	{
		protected override string JsonFile()
		{
			return "Constructables/EntertainmentComponentRepository.json";
		}
	}
}
