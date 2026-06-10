using NSEipix.Repository;
using NSMedieval.Model;

namespace NSMedieval.Repository
{
	public class FactionTypeRepository : DynamicJsonRepository<FactionTypeRepository, FactionType>
	{
		protected override string JsonFile()
		{
			return "Faction/FactionTypeRepository.json";
		}
	}
}
