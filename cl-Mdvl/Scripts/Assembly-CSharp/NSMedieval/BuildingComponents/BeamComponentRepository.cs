using NSEipix.Repository;

namespace NSMedieval.BuildingComponents
{
	public class BeamComponentRepository : DynamicJsonRepository<BeamComponentRepository, BeamComponentBlueprint>
	{
		protected override string JsonFile()
		{
			return "Constructables/BeamComponentRepository.json";
		}
	}
}
