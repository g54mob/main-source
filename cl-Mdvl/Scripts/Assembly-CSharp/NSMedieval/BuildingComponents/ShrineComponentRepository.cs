using NSEipix.Repository;

namespace NSMedieval.BuildingComponents
{
	public class ShrineComponentRepository : DynamicJsonRepository<ShrineComponentRepository, ShrineComponentBlueprint>
	{
		protected override string JsonFile()
		{
			return "Constructables/ShrineComponentRepository.json";
		}
	}
}
