using NSEipix.Repository;

namespace NSMedieval.BuildingComponents
{
	public class SiegeWeaponProjectileRepository : DynamicJsonRepository<SiegeWeaponProjectileRepository, SiegeWeaponProjectileBlueprint>
	{
		protected override string JsonFile()
		{
			return "Constructables/SiegeWeaponProjectileRepository.json";
		}
	}
}
