using System.Linq;
using NSEipix.Repository;
using NSMedieval.Model;
using NSMedieval.Types;

namespace NSMedieval.Repository
{
	public class ArmorQualitySettingsRepository : DynamicJsonRepository<ArmorQualitySettingsRepository, ArmorQualitySettings>
	{
		protected override string JsonFile()
		{
			return "Items/ArmorQualitySettings.json";
		}

		public ArmorQuality[] GetArmorQualitiesByType(ArmorType type)
		{
			return GetAllItems().FirstOrDefault((ArmorQualitySettings w) => w.Type.Equals(type))?.QualitySettings;
		}

		public ItemQuality[] GetItemQualitiesByArmorType(ArmorType type)
		{
			ArmorQuality[] armorQualitiesByType = GetArmorQualitiesByType(type);
			ItemQuality[] array = new ItemQuality[armorQualitiesByType.Length];
			for (int i = 0; i < armorQualitiesByType.Length; i++)
			{
				array[i] = armorQualitiesByType[i];
			}
			return array;
		}
	}
}
