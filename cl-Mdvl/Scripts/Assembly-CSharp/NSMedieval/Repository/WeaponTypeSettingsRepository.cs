using NSEipix.Repository;
using NSMedieval.Model;
using NSMedieval.Types;

namespace NSMedieval.Repository
{
	public class WeaponTypeSettingsRepository : DynamicJsonRepository<WeaponTypeSettingsRepository, WeaponTypeSettings>
	{
		public WeaponTypeSettings GetByID(WeaponType type)
		{
			int num = (int)type;
			return GetByID(num.ToString());
		}

		protected override string JsonFile()
		{
			return "Items/WeaponTypeSettings.json";
		}
	}
}
