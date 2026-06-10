using NSEipix.Repository;
using NSMedieval.Model;

namespace NSMedieval.Repository
{
	public class HumanAppearanceRepository : DynamicJsonRepository<HumanAppearanceRepository, HumanAppearance>
	{
		protected override string JsonFile()
		{
			return "Human/HumanAppearance.json";
		}
	}
}
