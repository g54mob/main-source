using NSEipix.Repository;

namespace NSMedieval.BuildingComponents
{
	public class SiegeWeaponComponentRepository : DynamicJsonRepository<SiegeWeaponComponentRepository, SiegeWeaponComponentBlueprint>
	{
		protected override string JsonFile()
		{
			return "Constructables/SiegeWeaponComponentRepository.json";
		}
	}
}
