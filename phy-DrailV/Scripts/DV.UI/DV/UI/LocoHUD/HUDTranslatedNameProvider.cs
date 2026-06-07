using DV.Localization;

namespace DV.UI.LocoHUD
{
	public class HUDTranslatedNameProvider : HUDElementNameProviderBase
	{
		public string localizationKey;

		private string cacheTranslation;

		private void Awake()
		{
			RefreshTranslation();
		}

		public void RefreshTranslation()
		{
			cacheTranslation = LocalizationAPI.L(localizationKey);
		}

		public override string GetName()
		{
			return cacheTranslation;
		}
	}
}
