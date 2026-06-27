using System.Text;
using Restory.Data.Localization;

namespace Restory.Gameplay.Shops.Devices
{
	public static class RandomlyGeneratedDeviceShopLotDescriptionLocalizationKeysExtensions
	{
		public static string GetTranslatedDescription(this RandomlyGeneratedDeviceShopLotDescriptionLocalizationKeys keys, LocalizationSystem localizationSystem)
		{
			string value = (string.IsNullOrEmpty(keys.CommonDescriptionIntroPartKey) ? string.Empty : localizationSystem.GetTranslation(keys.CommonDescriptionIntroPartKey));
			string value2 = (string.IsNullOrEmpty(keys.CommonDescriptionMainPartKey) ? string.Empty : localizationSystem.GetTranslation(keys.CommonDescriptionMainPartKey));
			string value3 = (string.IsNullOrEmpty(keys.CommonDescriptionOptionalPartKey) ? string.Empty : localizationSystem.GetTranslation(keys.CommonDescriptionOptionalPartKey));
			StringBuilder stringBuilder = new StringBuilder();
			if (!string.IsNullOrEmpty(value))
			{
				stringBuilder.Append(value);
			}
			if (!string.IsNullOrEmpty(value2))
			{
				stringBuilder.Append(" ").Append(value2);
			}
			if (!string.IsNullOrEmpty(value3))
			{
				stringBuilder.Append(" ").Append(value3);
			}
			return stringBuilder.ToString();
		}
	}
}
