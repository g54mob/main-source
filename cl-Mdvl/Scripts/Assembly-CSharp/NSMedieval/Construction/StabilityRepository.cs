using NSEipix.Repository;

namespace NSMedieval.Construction
{
	public class StabilityRepository : DynamicJsonRepository<StabilityRepository, Stability>
	{
		protected override string JsonFile()
		{
			return "Constructables/StabilitySettings.json";
		}
	}
}
