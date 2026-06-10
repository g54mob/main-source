using NSEipix.Repository;
using NSMedieval.Model;

namespace NSMedieval.Repository
{
	public class AnimalProductionRepository : DynamicJsonRepository<AnimalProductionRepository, AnimalProduction>
	{
		protected override string JsonFile()
		{
			return "Resources/AnimalProductionRepository.json";
		}
	}
}
