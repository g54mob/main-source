using System;

namespace MLCN_Localization
{
	[Serializable]
	public class LocalizationOption
	{
		public LocalizationManager.Language language;

		public string localizationKey;

		public LocalizationOption(LocalizationManager.Language language)
		{
			this.language = language;
		}

		public string GetLocalizedName(LocalizationDataTable.Tables table)
		{
			return LocalizationManager.GetLocalizedString(localizationKey, table);
		}
	}
}
