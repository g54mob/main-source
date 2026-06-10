using NSEipix.Repository;
using NSMedieval.Model;

namespace NSMedieval.Repository
{
	public class HumanTypeRepository : DynamicJsonRepository<HumanTypeRepository, HumanType>
	{
		protected override string JsonFile()
		{
			return "Human/HumanType.json";
		}
	}
}
