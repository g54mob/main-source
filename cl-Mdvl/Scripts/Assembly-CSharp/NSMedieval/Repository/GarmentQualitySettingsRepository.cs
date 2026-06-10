using System.Linq;
using NSEipix.Repository;
using NSMedieval.Model;
using NSMedieval.Types;

namespace NSMedieval.Repository
{
	public class GarmentQualitySettingsRepository : DynamicJsonRepository<GarmentQualitySettingsRepository, GarmentQualitySettings>
	{
		protected override string JsonFile()
		{
			return "Items/GarmentQualitySettings.json";
		}

		public GarmentQuality[] GetGarmentQualitiesByType(GarmentType type)
		{
			return GetAllItems().FirstOrDefault((GarmentQualitySettings w) => w.Type.Equals(type))?.QualitySettings;
		}

		public ItemQuality[] GetItemQualitiesByGarmentType(GarmentType type)
		{
			GarmentQuality[] garmentQualitiesByType = GetGarmentQualitiesByType(type);
			ItemQuality[] array = new ItemQuality[garmentQualitiesByType.Length];
			for (int i = 0; i < garmentQualitiesByType.Length; i++)
			{
				array[i] = garmentQualitiesByType[i];
			}
			return array;
		}
	}
}
