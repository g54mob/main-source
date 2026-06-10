using NSEipix.Repository;

namespace NSMedieval.BuildingComponents
{
	public class SignComponentRepository : DynamicJsonRepository<SignComponentRepository, SignComponentBlueprint>
	{
		protected override string JsonFile()
		{
			return "Constructables/SignComponentRepository.json";
		}
	}
}
