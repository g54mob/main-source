using NSEipix.Repository;

namespace NSMedieval.BuildingComponents
{
	public class PenMarkerComponentRepository : DynamicJsonRepository<PenMarkerComponentRepository, PenMarkerComponentBlueprint>
	{
		protected override string JsonFile()
		{
			return "Constructables/PenMarkerComponentRepository.json";
		}
	}
}
