using NSEipix.Repository;
using NSMedieval.Model;

namespace NSMedieval.Repository
{
	public class AnimalAttackGroupRepository : DynamicJsonRepository<AnimalAttackGroupRepository, AnimalAttackGroup>
	{
		protected override string JsonFile()
		{
			return "Animal/AnimalAttackGroupRepository.json";
		}
	}
}
