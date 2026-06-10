using NSEipix.Repository;

namespace NSMedieval.BuildingComponents
{
	public class RallyPointMarkerComponentRepository : DynamicJsonRepository<RallyPointMarkerComponentRepository, RallyPointMarkerComponentBlueprint>
	{
		protected override string JsonFile()
		{
			return "Constructables/RallyPointMarkerComponentRepository.json";
		}
	}
}
