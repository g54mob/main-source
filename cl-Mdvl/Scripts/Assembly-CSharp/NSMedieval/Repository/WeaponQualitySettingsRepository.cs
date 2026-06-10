using System.Linq;
using NSEipix.Repository;
using NSMedieval.Model;
using NSMedieval.State;
using NSMedieval.Types;

namespace NSMedieval.Repository
{
	public class WeaponQualitySettingsRepository : DynamicJsonRepository<WeaponQualitySettingsRepository, WeaponQualitySettings>
	{
		protected override string JsonFile()
		{
			return "Items/WeaponQualitySettings.json";
		}

		public WeaponQuality[] GetWeaponQualitiesByType(WeaponType type)
		{
			return GetAllItems().FirstOrDefault((WeaponQualitySettings w) => w.Type.Equals(type))?.QualitySettings;
		}

		public ItemQuality[] GetItemQualitiesByWeaponType(WeaponType type)
		{
			WeaponQuality[] weaponQualitiesByType = GetWeaponQualitiesByType(type);
			ItemQuality[] array = new ItemQuality[weaponQualitiesByType.Length];
			for (int i = 0; i < weaponQualitiesByType.Length; i++)
			{
				array[i] = weaponQualitiesByType[i];
			}
			return array;
		}

		public WeaponQuality GetWeaponQuality(WeaponType weaponType, ProductQuality quality)
		{
			return base.AllItems.FirstOrDefault((WeaponQualitySettings w) => w.Type.Equals(weaponType))?.QualitySettings.FirstOrDefault((WeaponQuality qualitySetting) => qualitySetting.Quality == quality);
		}
	}
}
