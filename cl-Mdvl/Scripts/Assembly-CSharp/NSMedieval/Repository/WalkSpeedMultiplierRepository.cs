using NSEipix.Repository;
using NSMedieval.Model;

namespace NSMedieval.Repository
{
	public class WalkSpeedMultiplierRepository : DynamicJsonRepository<WalkSpeedMultiplierRepository, WalkSpeedMultiplier>
	{
		protected override string JsonFile()
		{
			return "Creature/WalkSpeedMultiplierRepository.json";
		}
	}
}
